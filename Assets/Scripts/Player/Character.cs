using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Lighter lighter;
    
    public GameObject ligtherPrefab;
    private GameObject g;
    private Vector3 targetPosition;
    private Vector3 playerPosition;
    public bool kill;

    // Start is called before the first frame update
    void Awake()
    {
        
        g = GameObject.Find("Players").transform.GetChild(0).gameObject;

    }
    void Start()
    {
        InstantiateLight();
        kill = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(kill)
        {
            g = GameObject.Find("Players").transform.GetChild(0).gameObject;
            InstantiateLight();
        }
        playerPosition = GameObject.Find("Players").transform.GetChild(0).transform.position;
        targetPosition = GetMouseWorldPosition();
        Vector3 aimDir = (targetPosition - playerPosition).normalized;
        lighter.SetAimDirection(aimDir);
        lighter.SetOrigin(playerPosition);
        
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vec.z = 0f;
        return vec;
    }

    public void InstantiateLight()
    {
        Instantiate(ligtherPrefab, g.transform.position, g.transform.rotation, g.transform);
        lighter = g.transform.GetChild(0).gameObject.GetComponentInChildren<Lighter>();
        g.transform.GetChild(0).gameObject.GetComponentInChildren<Lighter>().gameObject.SetActive(false);
        kill = false;
        
    }

    


}
