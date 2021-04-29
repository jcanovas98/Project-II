using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : MonoBehaviour
{
    
    [SerializeField] private LayerMask layerMask;
    private Mesh mesh;
    
    private EdgeCollider2D col;
    private float fov;
    private Vector3 origin;
    private float startingAngle;
    private int rayCount = 10;
    
    float angleIncrease;
    float viewDistance = 2.5f;

    Vector3[] vertices;
    Vector2[] uv;
    int[] triangles;

    int vertexIndex = 1;
    int triangleIndex = 0;
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        col = GetComponent<EdgeCollider2D>();
        fov = 40.0f;
        angleIncrease = fov / rayCount;
        vertices = new Vector3[rayCount + 1 + 1];
        uv = new Vector2[vertices.Length];
        triangles = new int[rayCount * 3];
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        float angle = startingAngle;
        
        vertices[0] = origin - gameObject.transform.position;
        
        vertexIndex = 1;
        triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance, layerMask);
            
            if (raycastHit2D.collider == null)
            {
                vertex = (origin - gameObject.transform.position) + GetVectorFromAngle(angle) * viewDistance;
                //Debug.Log(vertex);
            }
            else
            {

                vertex = raycastHit2D.point - new Vector2(gameObject.transform.position.x, gameObject.transform.position.y); //+ new Vector2(1.2f, -0.66f);
                //vertex = origin + GetVectorFromAngle(angle) * viewDistance;
                //Debug.Log(vertex);

            }
            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;
        }



        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        CreateCollider();


    }

    

    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
        
    }

    public void SetAimDirection(Vector3 aimDirection)
    {
        startingAngle = GetAngleFromVectorFloat(aimDirection) + fov / 2f;
    }

    public Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    public float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        
        if (n < 0) n += 360;

        return n;
    }
    public void CreateCollider()
    {
        Vector2[] coliderVertices = new Vector2[mesh.vertices.Length];
        for (int i = 0; i < mesh.vertices.Length; i++)
        {        
            if(i == mesh.vertices.Length - 1)
            {
                coliderVertices[i] = mesh.vertices[0];
                
            }
            else
            {
                coliderVertices[i] = mesh.vertices[i];
            }
                        

        }
        col.points = coliderVertices;
        
    }
}
