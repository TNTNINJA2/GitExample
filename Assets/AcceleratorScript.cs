using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public CircleCollider2D circleCollider2D;
    [SerializeField]
    private Rigidbody2D rigidBody2D;
    [SerializeField]
    private float acceleration;
    [SerializeField]
    private float decceleration;
    [SerializeField]
    private float maxSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {
        // Get the direction opposite to it velocity and slow it down in that direction
        //Vector3 deccelerationDirection = rigidBody2D.velocity * -decceleration * Time.deltaTime;
        //rigidBody2D.velocity += new Vector2(deccelerationDirection.x, deccelerationDirection.y);

        // Get the vector for it to accelerate toward the player
        // Vector3 accelerationDirection = Vector3.Normalize(player.transform.position - 
        //  (transform.position + new Vector3(rigidBody2D.velocity.x, rigidBody2D.velocity.y, 0) * 0.5f));

        // Increase the magnitude
        // accelerationDirection *= acceleration * accelerationDirection.magnitude * Time.deltaTime;

        // apply the velocity change
        //rigidBody2D.velocity += new Vector2(accelerationDirection.x, accelerationDirection.y);


    }

}
