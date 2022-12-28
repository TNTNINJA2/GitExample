using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField]
    private float rotation;
    [SerializeField]
    private float movespeed = 2;
    private float timer = 0;
    [SerializeField]
    private float lifeSpan;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get the rotation and move the projectile forward based on it
        rotation = transform.rotation.z;
        transform.Translate(new Vector3(Mathf.Sin(Mathf.Deg2Rad * rotation) * movespeed * Time.deltaTime, Mathf.Cos(Mathf.Deg2Rad * rotation) * movespeed * Time.deltaTime));
        
        // kill the projectile after its lifeTime.
        if (timer < lifeSpan)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);     
        }
    }
}
