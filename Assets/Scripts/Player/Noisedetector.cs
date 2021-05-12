using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noisedetector : MonoBehaviour
{
    private PlayersManager PM;
    private GameObject _NoiseDetector => gameObject;
    private Transform _Player;
    private Transform _Enemy;

    private float MaxDistance;
    private float minRange = 1f;
    private bool alpha;
    
    // Start is called before the first frame update
    void Start()
    {
        PM = GameObject.Find("PlayersManager").GetComponent<PlayersManager>();
        _Player = PM.Players[0].transform;                
        MaxDistance = 10;
        alpha = true;
        ChangeAlpha(alpha);
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyClose())
        {
            if(IsEnemyMoving())
            {
                alpha = false;
                PlaceMarker();
                ChangeAlpha(alpha);
            }
            
        }
        else
        {
            alpha = true;
        }

        

        

    }
    
    private bool EnemyClose()
    {
       for(int i = 0; i < PM.Enemies.Count; i++)
       {
            if((PM.Enemies[i].transform.position - _Player.position).magnitude < MaxDistance)
            {
                _Enemy = PM.Enemies[i].transform;
                return true;
            }            
       }

        return false;
    }

    private bool IsEnemyMoving()
    {
        return _Enemy.GetComponent<Animator>().GetBool("IsPatroling") || _Enemy.GetComponent<Animator>().GetBool("IsChasing");
    }

    private void PlaceMarker()
    {
        _Player = PM.Players[0].transform;
        _NoiseDetector.transform.position = _Player.position + (_Enemy.position - _Player.position).normalized;
        
    }

    private float DistanceFraction()
    {
        float distance = Vector3.Distance(_Player.position, _Enemy.position);
        float lerpAmt = 1.0f - Mathf.Clamp01((distance - minRange) / (MaxDistance - minRange));        
        return lerpAmt;
    }

    private void ChangeAlpha(bool zero)
    {
        var _color = _NoiseDetector.GetComponent<SpriteRenderer>().color;
        if (zero)
        {           
            _color.a = 0f;            
        }
        else
        {            
            _color.a = DistanceFraction();            
        }
        _NoiseDetector.GetComponent<SpriteRenderer>().color = _color;

    }

   

}
