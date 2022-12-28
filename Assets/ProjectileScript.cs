using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField]
    private float rotation;
    [SerializeField]
    private float movespeed = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotation = transform.rotation.z;
        transform.Translate(new Vector3(Mathf.Sin(Mathf.Deg2Rad * rotation)*movespeed, Mathf.Cos(Mathf.Deg2Rad * rotation)*movespeed));
    }
}
