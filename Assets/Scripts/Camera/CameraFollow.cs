using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    PlayersManager PM;
    PlayerMovement PMove;
    private Transform cameraTransform => gameObject.transform;
    private Transform Target;
    private float Z = -10;
    private float XOffset;
    
    private Vector3 camVel;
    [Range(0, 1)]
    public float globalSmoothing;

    private void Awake()
    {
        PM = GameObject.Find("PlayersManager").GetComponent<PlayersManager>();
        PMove = GameObject.Find("Players").GetComponent<PlayerMovement>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        Target = PM.Players[0].gameObject.transform;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Target = PM.Players[0].gameObject.transform;
        Follow();
    }

    void Follow()
    {
        if(PMove.Right)
        {
            XOffset = 1.5f;
        }
        else
        {
            XOffset = -1.5f;
        }
        
        Vector3 pos = new Vector3 (Target.position.x + XOffset, Target.position.y + 0.3f, Z);
        cameraTransform.position = Vector3.SmoothDamp(cameraTransform.position, pos, ref camVel, globalSmoothing);
    }
}
