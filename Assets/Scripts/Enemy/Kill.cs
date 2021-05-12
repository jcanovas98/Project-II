using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    
    private PlayersManager PM;
    private Character Ch;
    // Start is called before the first frame update
    void Start()
    {
        
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

            PM.RemoveToList(collision.gameObject, PM.Players);
            PM.RemoveToList(collision.gameObject, PM.Allys);
            Destroy(collision.gameObject);
            Ch.kill = true;
            PM.RemoveToList(gameObject, PM.Enemies);
            Destroy(gameObject);
            
        }
    }
}
