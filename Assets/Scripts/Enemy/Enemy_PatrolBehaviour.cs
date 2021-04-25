﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_PatrolBehaviour : StateMachineBehaviour
{
    public float StayTime;
    public float PlayerDistance;

    private float _timer;
    private Transform _player; 
    private Vector2 _target;
    private Vector2 _startPos;

    //Edge
    private Transform _edgedetectionPoint;
    public LayerMask WhatIsGround;
    public float Speed;

    //Angle
    [Range(0f,360f)]
     public float visionAngle;
     public float visionDistance;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _timer = 0;
        _startPos = new Vector2(animator.transform.position.x, animator.transform.position.y);
        //--
        _target = new Vector2(_startPos.x + Random.Range(-1f, 1f), _startPos.y + Random.Range(0f, 0f));
        //--

        _edgedetectionPoint = GameObject.FindGameObjectWithTag("EdgeDet").transform;

        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Check triggers
        var playerClose = IsPlayerClose(animator.transform);
        var timeUp = IsTimeUp();

        //Angle
        var playerAngle = IsPlayerInAngle(animator.transform);
        
        animator.SetBool("IsChasing", playerClose && playerAngle);
        animator.SetBool("IsPatroling", !timeUp);

        //Edge
        if (EdgeDetected() || !EdgeWallDetected())
            Flip(animator, stateInfo, layerIndex);
        Move(animator, stateInfo, layerIndex);

    }
    

    private bool IsTimeUp()
    {
        _timer += Time.deltaTime;
        return _timer > StayTime;
    }

    private bool IsPlayerClose(Transform transform)
    {
        var dist = Vector3.Distance(transform.position, _player.position);
        return dist < PlayerDistance;
    }


    //Angle
    private bool IsPlayerInAngle(Transform transform)
    {
        var dist = _player.position - transform.position;
        
        return (Vector3.Angle(dist, transform.right) < visionAngle * 0.5f) && (dist.magnitude < visionDistance);
    }

    //EDGE
    private bool EdgeDetected()
    {
        RaycastHit2D hit = Physics2D.Raycast(_edgedetectionPoint.position, Vector2.down,
            1.5f, WhatIsGround);
        return hit.collider == null;
    }
    private bool EdgeWallDetected()
    {
        RaycastHit2D hit = Physics2D.Raycast(_edgedetectionPoint.position, Vector2.right,
            0.5f, WhatIsGround);
        return hit.collider == null;
    }

    private void Move(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.Translate(animator.transform.right * Speed * Time.deltaTime, Space.World);
        
    }

    private void Flip(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.Rotate(0,180,0);
    }
    
}
