using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed;
    public float turnRate;
    public float slowSpeed;
    public float fastSpeed;
    public bool isAlive = true;
    public InputAction turningControls;
    public InputAction speedControls;
    public Collider2D hitbox;
    public Collider2D hurtbox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        turningControls.Enable();
        speedControls.Enable();
    }

    private void OnDisable()
    {
        turningControls.Disable();
        speedControls.Disable();
    }
    
    // Update is called once per frame
    void Update()
    {

        if (isAlive)
        {
            float speedModifier;

            if (speedControls.ReadValue<float>() == 1)
            {
                speedModifier = fastSpeed;
            }
            else if (speedControls.ReadValue<float>() == -1)
            {
                speedModifier = slowSpeed;
            }
            else
            {
                speedModifier = 1;
            }
            
            transform.Translate(new Vector3(
                (float)(Mathf.Sin(Mathf.Deg2Rad * transform.rotation.z) * moveSpeed * speedModifier * 0.01 * Time.deltaTime),
                (float)(Mathf.Cos(Mathf.Deg2Rad * transform.rotation.z) * moveSpeed * speedModifier * 0.01 * Time.deltaTime),
                0));

            transform.Rotate(0, 0, turningControls.ReadValue<float>() * -turnRate * Time.deltaTime / (speedModifier / 2));
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.IsTouching(hurtbox))
        {
            isAlive = false;
        }
        else if (collision.IsTouching(hitbox))
        {
            Destroy(collision);
        }


    }

    
}
