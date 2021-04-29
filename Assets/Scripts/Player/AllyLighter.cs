using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyLighter : MonoBehaviour
{
    public GameObject ligtherPrefab;
    // Start is called before the first frame update
    private bool Once;
    void Start()
    {
        Once = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject == GameObject.Find("Players").transform.GetChild(0).gameObject && Once == false)
        {
            Instantiate(ligtherPrefab, gameObject.transform.position, gameObject.transform.rotation, gameObject.transform);
            gameObject.transform.GetChild(0).gameObject.GetComponentInChildren<Lighter>().gameObject.SetActive(false);
            Once = true;
        }
        
    }
}
