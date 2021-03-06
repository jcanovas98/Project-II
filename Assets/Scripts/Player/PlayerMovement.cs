using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    //private List<GameObject> Players = new List<GameObject>();
    public float Speed;    
    public float speedChange;
    public bool Right;
    PlayersManager PM;
    private GameObject Player => GameObject.Find("Player");
    public float playerMaxDist = 0.5f;

    //private float _horizontal = 1;
    // Start is called before the first frame update
    void Awake()
    {
        PM = GameObject.Find("PlayersManager").GetComponent<PlayersManager>();
        

    }

    private void Start()
    {
        Right = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();       
        
    }

    void Move()
    {
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedChange = 1;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            speedChange = -1.5f;
        }
        else
        {
            speedChange = 0;
        }


        if(Input.GetKey("d"))
        {
            Speed = 2.5f + speedChange;
            Right = true;
        }
        else if(Input.GetKey("a"))
        {
            Speed = -2.5f - speedChange;
            Right = false;
        }
        else
        {
            Speed = 0;
            
            
        }

        
        


        Vector2 vel1 = PM.Players[0].GetComponent<Rigidbody2D>().velocity;
        vel1.x = Speed;
        PM.Players[0].GetComponent<Rigidbody2D>().velocity = vel1;

        if (PM.Players.Count > 1)
        {
            for (int i = 1; i < PM.Players.Count; i++)
            {
                if ((PM.Players[i].transform.position - PM.Players[i - 1].transform.position).magnitude > playerMaxDist && PM.Players[i] != null)
                {
                    Vector2 vel = PM.Players[i].GetComponent<Rigidbody2D>().velocity;
                    vel.x = Speed;
                    PM.Players[i].GetComponent<Rigidbody2D>().velocity = vel;
                }
                
            }
        }     
        
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        
        if (collision.gameObject.layer == 8)
        {
            if(PM.Players.Count > 2)
            {
                int side;
                if (PM.Players[PM.Players.Count - 1].transform.position.magnitude < PM.Players[PM.Players.Count - 2].transform.position.magnitude)
                {
                    side = -1;
                }
                else
                {
                    side = 1;
                }
                collision.gameObject.transform.position = PM.Players[PM.Players.Count - 1].transform.position - new Vector3(side * 0.5f, 0, 0);
                PM.Players.Add(collision.gameObject);
                collision.gameObject.layer = 3;
            }
            else
            {
                collision.gameObject.transform.position = PM.Players[PM.Players.Count - 1].transform.position - new Vector3(0.5f, 0, 0);
                PM.Players.Add(collision.gameObject);
                collision.gameObject.layer = 3;
            }
            
            

        }
    }

    
    
}
