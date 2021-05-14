using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cascabel_AttractBehaviour : StateMachineBehaviour
{
    PlayersManager PM;
    public float Speed = 2;
    private Transform _player;
    private float _timer;
    public float StayTime;
    private Vector3 chase;
    // Start is called before the first frame update
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = GameObject.Find("Players").transform.GetChild(0).transform;
        _timer = 0;
        PM = GameObject.Find("PlayersManager").GetComponent<PlayersManager>();
        chase = PM.Pposition;
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        var timeUp = IsTimeUp();


        animator.SetBool("IsIdle", timeUp);




        Vector2 dir = chase - animator.transform.position;
        animator.transform.position += (Vector3)dir.normalized * Speed * Time.deltaTime;
        if((chase - animator.transform.position).magnitude < 0.3f)
        {
            Speed = 0;
        }

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Attract", false);

    }

    private bool IsTimeUp()
    {
        _timer += Time.deltaTime;
        return _timer > StayTime;
    }


}
