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

    public Collider2D hitbox;
    public Collider2D hurtbox;
    [SerializeField]
    private LogicScript logicScript;
    [SerializeField]
    private GameObject starCollect;
    [SerializeField]
    private GameObject playerDeath;
    [SerializeField]
    private GameObject enemyDeath;

    public float turning = 0;
    public float speed = 0;

    InputActions controls;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        controls = new InputActions();

        controls.Controls.Turning.performed += ctx =>
        {
            turning = ctx.ReadValue<float>();
            Debug.Log("Turning was performed and turning is: " + turning);
        };
        controls.Controls.Turning.canceled += ctx =>
        {
            turning = 0;

        };

        controls.Controls.Speed.performed += ctx => speed = ctx.ReadValue<float>();
        controls.Controls.Speed.canceled += ctx => speed = 0;
    }

    void Turn()
    {

    }

    private void OnEnable()
    {

        controls.Controls.Enable(); 
    }

    private void OnDisable()
    {
        // disable controls (mandatory for controls to work)

        controls.Controls.Disable();
    }
    
    // Update is called once per frame
    void Update()
    {

        if (isAlive)
        {
            float speedModifier;

            // Determine the speed modifier based on what keys are pressed.
            if (speed > 0)
            {
                speedModifier = fastSpeed;
            }
            else if (speed < 0)
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
            transform.Rotate(0, 0, turning * -turnRate * Time.deltaTime / (speedModifier / 2));
            
        } else if (speed > 0)
        {
            logicScript.RestartGame();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isAlive)
        {
            // If the other gameObject is a Star, increase the score and respawn the star away from the player, but not near the edge
            if (collision.gameObject.tag.Equals("Star"))
            {
                starCollect.GetComponent<AudioSource>().Play();
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
                    playerDeath.GetComponent<AudioSource>().Play();
                    isAlive = false;
                    logicScript.GameOver();
                }
                else if (collision.IsTouching(hitbox)) // if player hit the object
                {
                    enemyDeath.GetComponent<AudioSource>().Play();
                    logicScript.IncreaseKillCount(collision.gameObject.name);
                    Destroy(collision.gameObject);
                    // TODO: add sound effect
                }
            }
        }

        


    }

    
}
