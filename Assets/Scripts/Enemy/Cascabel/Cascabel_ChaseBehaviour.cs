using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cascabel_ChaseBehaviour : StateMachineBehaviour
{
    
    public float Speed = 2;   

    private Transform _Player;
    private Transform _gameObject;
    public float _PlayerMaxDist;



    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {        

        _Player = GameObject.Find("Players").transform.GetChild(0).transform;
        _gameObject = animator.gameObject.transform;

    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {


        var playerClose = IsPlayerDetected();



        animator.SetBool("IsIdle", !playerClose);




        Vector2 dir = _Player.position - animator.transform.position;
        animator.transform.position += (Vector3)dir.normalized * Speed * Time.deltaTime;

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("IsChasing", false);
    }

    private bool IsPlayerDetected()
    {
        _Player = GameObject.Find("Players").transform.GetChild(0).transform;

        return Vector3.Distance(_Player.position, _gameObject.position) < _PlayerMaxDist;

    }
}
