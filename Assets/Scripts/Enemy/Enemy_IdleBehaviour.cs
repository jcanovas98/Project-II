using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_IdleBehaviour : StateMachineBehaviour
{
    public float StayTime;
    //public float PlayerDistance;

    private float _timer;
    //private Transform _player;

    private Transform _edgedetectionPoint;    
    public LayerMask lighter;
    //Angle
    [Range(0f, 360f)]
    public float visionAngle;
    public float visionDistance;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //_player = GameObject.FindGameObjectWithTag("Player").transform;
        _timer = 0;

        _edgedetectionPoint = GameObject.FindGameObjectWithTag("EdgeDet").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Check triggers
        //var playerClose = IsPlayerClose(animator.transform);
        var timeUp = IsTimeUp();

        //var playerAngle = IsPlayerInAngle(animator.transform);
        var lightClose = IsLightDetected();

        animator.SetBool("IsChasing", lightClose);
        animator.SetBool("IsPatroling", timeUp);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("IsIdle", false);
    }

    private bool IsTimeUp()
    {
        _timer += Time.deltaTime;
        return _timer > StayTime;
    }

    /*private bool IsPlayerClose(Transform transform)
    {
        var dist = Vector3.Distance(transform.position, _player.position);
        return dist < PlayerDistance;
    }

    //Angle
    private bool IsPlayerInAngle(Transform transform)
    {
        var dist = _player.position - transform.position;

        return (Vector3.Angle(dist, transform.right) < visionAngle * 0.5f) && (dist.magnitude < visionDistance);
    }*/

    private bool IsLightDetected()
    {
        RaycastHit2D hit = Physics2D.Raycast(_edgedetectionPoint.position, Vector2.right,
            1f, lighter);
        return hit.collider != null;
    }



}
