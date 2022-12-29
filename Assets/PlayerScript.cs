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
    [SerializeField]
    private LogicScript logicScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        // enable controls (mandatory for controls to work)
        turningControls.Enable();
        speedControls.Enable();
    }

    private void OnDisable()
    {
        // disable controls (mandatory for controls to work)
        turningControls.Disable();
        speedControls.Disable();
    }
    
    // Update is called once per frame
    void Update()
    {

        if (isAlive)
        {
            float speedModifier;

            // Determine the speed modifier based on what keys are pressed.
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
            
            // move forward by an amount determined by the speedModifier
            transform.Translate(new Vector3(
                (float)(Mathf.Sin(Mathf.Deg2Rad * transform.rotation.z) * moveSpeed * speedModifier * 0.01 * Time.deltaTime),
                (float)(Mathf.Cos(Mathf.Deg2Rad * transform.rotation.z) * moveSpeed * speedModifier * 0.01 * Time.deltaTime),
                0));

            // Turn based  on control input and turn tighter the lower the speedModifier
            transform.Rotate(0, 0, turningControls.ReadValue<float>() * -turnRate * Time.deltaTime / (speedModifier / 2));
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isAlive)
        {
            // If the other gameObject is a Star, increase the score and respawn the star away from the player, but not near the edge
            if (collision.gameObject.tag.Equals("Star"))
            {
                logicScript.IncreaseScore(1);

                float maxXDiff = 7.5f;
                float maxYDiff = 3.5f;

                Vector3 newPos = new Vector3(Random.Range(-maxXDiff, maxXDiff), Random.Range(-maxYDiff, maxYDiff), 0);
                while ((newPos - transform.position).sqrMagnitude < 9)
                {
                    newPos = new Vector3(Random.Range(-maxXDiff, maxXDiff), Random.Range(-maxYDiff, maxYDiff), 0);
                }
                collision.gameObject.transform.position = newPos;
            }
            else
            {
                // if player was hit
                if (collision.IsTouching(hurtbox))
                {
                    // TODO: add gameover screen and enable it here
                    // TODO: add sound effect
                    isAlive = false;
                    logicScript.GameOver();
                }
                else if (collision.IsTouching(hitbox)) // if player hit the object
                {
                    logicScript.IncreaseKillCount(collision.gameObject.name);
                    Destroy(collision.gameObject);
                    // TODO: add sound effect
                }
            }
        }

        


    }

    
}
