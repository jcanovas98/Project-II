using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto : MonoBehaviour
{    
    private float maxDistance = 0.5f;
    private GameObject _Player;
    public bool close;
    // Start is called before the first frame update
    void Start()
    {
        _Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        close = PlayerClose();
        if (PlayerClose())
        {
            if(Input.GetKeyDown("e"))
            {
                Destroy(gameObject);
            }
            
        }
            
    }

    private bool PlayerClose()
    {
        var dist = Vector3.Distance(gameObject.transform.position, _Player.transform.position);
        return dist < maxDistance;
    }
}
