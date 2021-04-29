using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    private BoxCollider2D col;
    private PlayersManager PM;
    private Character Ch;
    // Start is called before the first frame update
    void Start()
    {
        col = gameObject.GetComponent<BoxCollider2D>();
        PM = GameObject.Find("PlayersManager").GetComponent<PlayersManager>();
        Ch = GameObject.Find("Players").GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            PM.RemoveToList(collision.gameObject);            
            Destroy(collision.gameObject);
            Ch.kill = true;
            Destroy(gameObject);
            
        }
    }
}
