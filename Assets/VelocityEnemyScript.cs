using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityEnemyScript : MonoBehaviour
{
    public GameObject player;
    public float movespeed = 2;
    public float turnRate = 2;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
       // get the vector from the enemy to the player
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 shooterPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 gap = playerPos - shooterPos;

        // Make the x and y non-zero
        if (gap.x == 0)
        {
            gap.x += 0.01f;
        }
        if (gap.y == 0)
        {
            gap.y += 0.01f;
        }

        // get the angle the enemy should be at and put it in degrees
        float angle = Mathf.Atan(-gap.x / gap.y);
        angle *= Mathf.Rad2Deg;
        if (gap.y < 0)
        {
            angle += 180;
        }

        //get the current angle
        float thisAngle = transform.rotation.eulerAngles.z;

        // get the angle that needs to be added to current to get target angle
        float value = angle - thisAngle;
        // make it between -180 and 180
        if (value > 180 || value < -180)
        {
            value = -value;
        }

        // Clamp the turn. This enforces the turning radius
        float diffAngle = Mathf.Clamp(value, -turnRate*Time.deltaTime, turnRate*Time.deltaTime);
       
        // turn the enemy
        transform.Rotate(new Vector3(0, 0, diffAngle));
        // move forward
        transform.Translate(new Vector3(
            (float)(Mathf.Sin(Mathf.Deg2Rad * transform.rotation.z) * movespeed * Time.deltaTime),
            (float)(Mathf.Cos(Mathf.Deg2Rad * transform.rotation.z) * movespeed * Time.deltaTime),
            0));
       
    }
}
