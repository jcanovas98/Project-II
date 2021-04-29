using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{
    public GameObject[] Allys;
    public List<GameObject> Players = new List<GameObject>();
    // Start is called before the first frame update
    void Awake()
    {
        
        Allys = GameObject.FindGameObjectsWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToList(GameObject g)
    {
        Players.Add(g);
    }

    public void RemoveToList(GameObject g)
    {
        var f = Players.IndexOf(g);
        Players.Remove(g);
        for(int i = Players.Count - 1; i < f; i--)
        {
            
            Players[i - 1] = Players[i];
            
            
        }
        
    }
}
