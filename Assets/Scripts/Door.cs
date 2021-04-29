using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    PlayersManager PM;
    private float maxDistance = 2;
    private GameObject door => gameObject;
    private GameObject Player;
    public GameObject Out;
    public GameObject In;

    public bool closed = true;
    
    // Start is called before the first frame update

    void Awake()
    {
        PM = GameObject.Find("PlayersManager").GetComponent<PlayersManager>();
        
    }
    void Start()
    {
        Player = PM.Players[0].gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Player = PM.Players[0].gameObject;

        if ((PlayerClose(In) || PlayerClose(Out)) && Input.GetKeyDown("e"))
        {
            
            if(closed)
            {
                IgnoreCollisions(closed);
                
                
            }
            else
            {
                IgnoreCollisions(closed);
                
                
            }
            
        }
    }

    private void IgnoreCollisions(bool enable)
    {
        Debug.Log(PM.Players.Count);
        door.GetComponent<Collider2D>().enabled = !enable;
        closed = !closed;
    }

    private bool PlayerClose(GameObject InOut)
    {
        var dist = Vector3.Distance(InOut.transform.position, Player.transform.position);        
        return dist < maxDistance;
    }
}
