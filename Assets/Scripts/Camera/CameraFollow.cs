using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    private Transform cameraTransform => gameObject.transform;
    private Transform Target;
    private float Z = -10;
    
    private Vector3 camVel;
    [Range(0, 1)]
    public float globalSmoothing;
    
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.Find("Player").transform;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Follow();
    }

    void Follow()
    {
        
        Vector3 pos = new Vector3 (Target.position.x, Target.position.y, Z);
        cameraTransform.position = Vector3.SmoothDamp(cameraTransform.position, pos, ref camVel, globalSmoothing);
    }
}