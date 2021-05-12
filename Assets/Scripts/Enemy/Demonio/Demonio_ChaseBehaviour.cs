using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demonio_ChaseBehaviour : StateMachineBehaviour
{
    
    public float Speed = 2;
    private Transform _player;
    private Transform _edgedetectionPoint;
    public LayerMask lighter;
    
    

    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = GameObject.Find("Players").transform.GetChild(0).transform;
        _edgedetectionPoint = animator.gameObject.transform.GetChild(0);


    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        
        var lightClose = IsLightDetectedRight() || IsLightDetectedLeft();



        animator.SetBool("IsIdle", !lightClose);
        
       

        
        Vector2 dir = _player.position - animator.transform.position;
        animator.transform.position += (Vector3)dir.normalized * Speed * Time.deltaTime;

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("IsChasing", false);
    }

    private bool IsLightDetectedRight()
    {
        RaycastHit2D hit = Physics2D.Raycast(_edgedetectionPoint.position, Vector2.right,
            0.5f, lighter);
        return hit.collider != null;
    }

    private bool IsLightDetectedLeft()
    {
        RaycastHit2D hit = Physics2D.Raycast(_edgedetectionPoint.position, Vector2.left,
            0.5f, lighter);
        return hit.collider != null;
    }
}
