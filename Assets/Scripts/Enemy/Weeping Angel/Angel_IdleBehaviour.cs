using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angel_IdleBehaviour : StateMachineBehaviour
{
    public float playerMaxDistance;
    private Transform _Player;
    public LayerMask lighter;
    private Animator anim;
    



    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _Player = GameObject.Find("Players").transform.GetChild(0).transform;
        anim = animator;
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        var lightClose = (IsLightDetectedRight(0.3f) || IsLightDetectedLeft(0.3f)) || (IsLightDetectedRight(2f) && IsLightDetectedLeft(2f));
        var playerClose = IsPlayerClose();

        animator.SetBool("IsChasing", !lightClose && playerClose);
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
    
    private bool IsPlayerClose()
    {
        _Player = GameObject.Find("Players").transform.GetChild(0).transform;
        return (_Player.position - anim.gameObject.transform.position).magnitude < playerMaxDistance;
    }

    private bool IsLightDetectedRight(float distance)
    {
        RaycastHit2D hit = Physics2D.Raycast(anim.transform.position, Vector2.right,
            distance, lighter);
        return hit.collider != null;
    }

    private bool IsLightDetectedLeft(float distance)
    {
        RaycastHit2D hit = Physics2D.Raycast(anim.transform.position, Vector2.left,
            distance, lighter);
        return hit.collider != null;
    }



}
