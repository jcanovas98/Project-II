using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{
    public List<GameObject> Allys;
    public List<GameObject> Players = new List<GameObject>();
    public List<GameObject> Enemies;
    public Vector3 Pposition;
    
    // Start is called before the first frame update
    void Awake()
    {
        
        Allys = GameObject.FindGameObjectsWithTag("Player").ToList<GameObject>();
        Enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList<GameObject>();
        Players.Add(GameObject.Find("Player"));
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Players.Count == 0)
        {            
            UnityEditor.EditorApplication.isPlaying = false;
            //Application.Quit();
        }
    }

    public void AddToList(GameObject g)
    {
        Players.Add(g);
    }

    public void RemoveToList(GameObject g, List<GameObject> list)
    {        
        list.Remove(g);       

    }

   

}
