using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    
    public Transform Player;
    public GameObject AllyG => gameObject;
    public Transform Ally => gameObject.transform;
    public float speedX;
       

    public float playerMaxDist;
    [Range(0, 1)]
    public float smoothFollow;
    private Vector2 speed;
    Rigidbody2D _rigidbody;


    public int pos;


    // Start is called before the first frame update
    void Start()
    {
        /*_rigidbody = gameObject.GetComponent<Rigidbody2D>();
        speed = new Vector2(speedX, _rigidbody.velocity.y);*/

        pos = Random.Range(1, 3);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       //playerIsClose();
       


        
    }

    void playerIsClose()
    {
        if(!((Player.position - Ally.position).magnitude < playerMaxDist))
        {
            Vector2 dir = (Player.position - Ally.position).normalized;

            Ally.position = Vector2.SmoothDamp(Ally.position, Player.position, ref speed, smoothFollow);
            if (Player.position.y - Ally.position.y > 0 && Player.position.x - Ally.position.x > 0)
            {
                _rigidbody.AddForce(new Vector2(2, 2));
            }
            if (Player.position.y - Ally.position.y > 0 && Player.position.x - Ally.position.x < 0)
            {
                _rigidbody.AddForce(new Vector2(-2, 2));
            }
        }
    }
}
