using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceleratingEnemyScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
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
        Vector3 deccelerationDirection = rigidBody2D.velocity * -decceleration * Time.deltaTime;
        rigidBody2D.velocity += new Vector2(deccelerationDirection.x, deccelerationDirection.y);

        Vector3 accelerationDirection = Vector3.Normalize(player.transform.position - 
            (transform.position + new Vector3(rigidBody2D.velocity.x, rigidBody2D.velocity.y, 0) * 0.5f));
        accelerationDirection *= acceleration * accelerationDirection.magnitude * Time.deltaTime;
        rigidBody2D.velocity += new Vector2(accelerationDirection.x, accelerationDirection.y);
        Mathf.Clamp(rigidBody2D.velocity.x, -maxSpeed, maxSpeed);
        Mathf.Clamp(rigidBody2D.velocity.y, -maxSpeed, maxSpeed);

    }
}
