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
}
