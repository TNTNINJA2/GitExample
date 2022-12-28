using UnityEngine;

public class ShooterEnemyScript : MonoBehaviour
{
    public float fireRate = 10;
    private float timer = 0;
    public GameObject projectile;
    public GameObject player;
    [SerializeField]
    private float spread = 10;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {   
        // timer for projectiles
        if (timer < fireRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            shootProjectile();
            timer = 0;
        }
    }
    void shootProjectile()
    {
        // Find the vector from the shooter to the player
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 shooterPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 gap = playerPos - shooterPos;

        // Make the x and y values non-zero
        if (gap.x == 0) 
        {
            gap.x += 0.01f;
        };
        if (gap.y == 0)
        {
            gap.y += 0.01f;
        };

        // find the angle it should be shot at
        float angle = Mathf.Atan(-gap.x / gap.y);
        angle *= Mathf.Rad2Deg;
        if (gap.y<0)
        {
            angle += 180;
        }

        // add a little random spread to the angle
        angle += Random.Range(-spread, spread);

        //spawn it
        Instantiate(projectile, new Vector3(transform.position.x,transform.position.y,0),Quaternion.Euler(0,0,angle));
    }
}
