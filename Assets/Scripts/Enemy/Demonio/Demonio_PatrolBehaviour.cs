using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demonio_PatrolBehaviour : StateMachineBehaviour
{
    public float StayTime;
   
    
    private float _timer;
    
    private Vector2 _startPos;

   
    private Transform _edgedetectionPoint;
    public LayerMask WhatIsGround;
    public LayerMask lighter;
    public float Speed;
    private float RotationAngle = 0;

    
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
        _timer = 0;
        _startPos = new Vector2(animator.transform.position.x, animator.transform.position.y);
       

        _edgedetectionPoint = animator.gameObject.transform.GetChild(0);


    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        var timeUp = IsTimeUp();

        
        var lightClose = IsLightDetectedRight() || IsLightDetectedLeft();

        
        animator.SetBool("IsChasing", lightClose);
        
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
            0.5f, WhatIsGround);

        return hit.collider == null;
    }

    private bool EdgeWallDetectedLeft()
    {
        RaycastHit2D hit = Physics2D.Raycast(_edgedetectionPoint.position, Vector2.left,
            0.5f, WhatIsGround);

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

        animator.transform.Rotate(0 ,RotationAngle, 0);
        
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
