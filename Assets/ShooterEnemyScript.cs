using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemyScript : MonoBehaviour
{
    public float fireRate = 10;
    private float timer = 0;
    public GameObject Projectile;
    public GameObject Player;
    [SerializeField]
    private float spread = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
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
        Vector2 playerPos = new Vector2(Player.transform.position.x, Player.transform.position.y);
        Vector2 shooterPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 gap = playerPos - shooterPos;
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
        if (gap.y<0)
        {
            angle += 180;
        }
        angle += Random.Range(-spread, spread);
        Instantiate(Projectile, new Vector3(transform.position.x,transform.position.y,0),Quaternion.Euler(0,0,angle));
        Debug.Log("Shoot");
        Debug.Log(gap.ToString());
        Debug.Log(angle.ToString());
    }
}
