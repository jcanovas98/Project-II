using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ChaseBehaviour : StateMachineBehaviour
{
    public float PlayerDistance;
    public float Speed = 2;

    private Transform _player;

    //Angle
    [Range(0f, 360f)]
    public float visionAngle;
    public float visionDistance;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Check triggers
        var playerClose = IsPlayerClose(animator.transform);
        var playerAngle = IsPlayerInAngle(animator.transform);

        animator.SetBool("IsChasing", playerClose && playerAngle);
        //animator.SetBool("IsChasing", playerClose);

        //Move to player
        Vector2 dir = _player.position - animator.transform.position;
        animator.transform.position += (Vector3)dir.normalized * Speed * Time.deltaTime;

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
}
