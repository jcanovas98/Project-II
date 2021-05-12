using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Cascabel_PatrolBehaviour : StateMachineBehaviour
{
    public float StayTime;


    private float _timer;

    private Vector2 _startPos;


    private Transform _edgedetectionPoint;
    public LayerMask WhatIsGround;    
    public float Speed;
    private float RotationAngle = 0;

    private GameObject _Player;
    private Transform _gameObject;
    public float _PlayerMaxDist;



    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        _timer = 0;
        _startPos = new Vector2(animator.transform.position.x, animator.transform.position.y);


        _edgedetectionPoint = animator.gameObject.transform.GetChild(0);

        _Player = GameObject.Find("Players").transform.GetChild(0).gameObject;
        _gameObject = animator.gameObject.transform;
        
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        var timeUp = IsTimeUp();


        var noiseHeard = IsPlayerClose() && (IsPlayerMoving() || IsRadioOn());
        animator.SetBool("IsChasing", noiseHeard);

        animator.SetBool("IsPatroling", !timeUp);



        if (EdgeDetected() || !EdgeWallDetectedRight() || !EdgeWallDetectedLeft())
            Flip(animator, stateInfo, layerIndex);
        Move(animator, stateInfo, layerIndex);

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("IsPatroling", false);
    }
    private bool IsTimeUp()
    {
        _timer += Time.deltaTime;
        return _timer > StayTime;
    }



    private bool EdgeDetected()
    {
        RaycastHit2D hit = Physics2D.Raycast(_edgedetectionPoint.position, Vector2.down,
            1.5f, WhatIsGround);
        return hit.collider == null;
    }
    private bool EdgeWallDetectedRight()
    {
        RaycastHit2D hit = Physics2D.Raycast(_edgedetectionPoint.position, Vector2.right,
            0.2f, WhatIsGround);

        return hit.collider == null;
    }

    private bool EdgeWallDetectedLeft()
    {
        RaycastHit2D hit = Physics2D.Raycast(_edgedetectionPoint.position, Vector2.left,
            0.2f, WhatIsGround);

        return hit.collider == null;
    }



    private void Move(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.Translate(animator.transform.right * Speed * Time.deltaTime, Space.World);

    }

    private void Flip(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (RotationAngle == 0) RotationAngle = 180;
        else RotationAngle = 0;

        animator.transform.Rotate(0, RotationAngle, 0);

    }

    private bool IsPlayerClose()
    {
        _Player = GameObject.Find("Players").transform.GetChild(0).gameObject;

        return Vector3.Distance(_Player.transform.position, _gameObject.position) < _PlayerMaxDist;
            

    }

    private bool IsPlayerMoving()
    {
        
        return _Player.GetComponent<Rigidbody2D>().velocity != new Vector2(0, 0);
    }

    private bool IsRadioOn()
    {
        
        return _Player.transform.GetChild(1).GetComponent<Radio>().On == true;
    }


    
}
