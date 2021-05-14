using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimDirection : MonoBehaviour
{
    private Vector3 targetPosition;
    private Vector3 playerPosition;
    public float angleOffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = GameObject.Find("Players").transform.GetChild(0).transform.position;
        targetPosition = GetMouseWorldPosition();
        Vector3 aimDir = (targetPosition - playerPosition).normalized;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - angleOffset, Vector3.forward);
        transform.rotation = rotation;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vec.z = 0f;
        return vec;
    }
}
