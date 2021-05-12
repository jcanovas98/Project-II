using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demonio_IdleBehaviour : StateMachineBehaviour
{
    public float StayTime;
    

    private float _timer;
    

    private Transform _edgedetectionPoint;    
    public LayerMask lighter;
    
    
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Attract", false);
        _timer = 0;

        _edgedetectionPoint = animator.gameObject.transform.GetChild(0);
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        var timeUp = IsTimeUp();


        var lightClose = IsLightDetectedRight() || IsLightDetectedLeft();

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
