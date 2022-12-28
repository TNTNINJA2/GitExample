using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityEnemyScript : MonoBehaviour
{
    public GameObject Player;
    public float movespeed = 2;
    public float turnRate = 2;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
       
        Vector2 playerPos = new Vector2(Player.transform.position.x, Player.transform.position.y);
        Vector2 shooterPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 gap = playerPos - shooterPos;
        float thisAngle = transform.rotation.eulerAngles.z; 
        if (gap.x == 0)
        {
            gap.x += 0.01f;
        };
        if (gap.y == 0)
        {
            gap.y += 0.01f;
        };
        float angle = Mathf.Atan(-gap.x / gap.y);
        angle *= Mathf.Rad2Deg;
        if (gap.y < 0)
        {
            angle += 180;
        }
        float value = angle - thisAngle;
        if (value > 180 || value < -180)
        {
            value = -value;
        }
        float diffAngle = Mathf.Clamp(value, -turnRate*Time.deltaTime, turnRate*Time.deltaTime);
       
        transform.Rotate(new Vector3(0, 0, diffAngle));
        transform.Translate(new Vector3(
            (float)(Mathf.Sin(Mathf.Deg2Rad * transform.rotation.z) * movespeed * Time.deltaTime),
            (float)(Mathf.Cos(Mathf.Deg2Rad * transform.rotation.z) * movespeed * Time.deltaTime),
            0));
        Debug.Log("value is" + value);
        Debug.Log("angle is" + angle);
        Debug.Log("thisAngle is" + thisAngle);
        Debug.Log("diffAngle is" + diffAngle);
       
    }
}
