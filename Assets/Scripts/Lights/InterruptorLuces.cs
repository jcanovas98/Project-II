using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterruptorLuces : MonoBehaviour
{
    public List<GameObject> lights;    
    public LayerMask player;
    private PlayersManager PM;
    public bool doorLeft;
    // Start is called before the first frame update
    void Start()
    {
        PM = GameObject.Find("PlayersManager").GetComponent<PlayersManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(doorLeft)
        {
            if (IsPlayerDetectedLeft())
            {
                TurnLightsOff();
                ZoomIn();
            }
            if (IsPlayerDetectedRight())
            {
                TurnLightsOn();
                ZoomOut();
            }
        }
        else
        {
            if (IsPlayerDetectedLeft())
            {
                TurnLightsOn();
                ZoomOut();
            }
            if (IsPlayerDetectedRight())
            {
                TurnLightsOff();
                ZoomIn();
            }
        }
        
    }


    private bool IsPlayerDetectedLeft()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left,
            0.5f, player);
        return hit.collider == PM.Players[0].GetComponent<Collider2D>();        
        
    }

    private bool IsPlayerDetectedRight()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right,
            0.5f, player);
        return hit.collider == PM.Players[0].GetComponent<Collider2D>();

    }

    private void TurnLightsOn()
    {
        for(int i = 0; i < lights.Count; i++)
        {
            lights[i].GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().enabled = true;
        }
    }

    private void TurnLightsOff()
    {
        for (int i = 0; i < lights.Count; i++)
        {
            lights[i].GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().enabled = false;
        }
    }

    private void ZoomOut()
    {
        Camera.main.orthographicSize = 2.5f;
    }

    private void ZoomIn()
    {
        Camera.main.orthographicSize = 1.5f;
    }
}
