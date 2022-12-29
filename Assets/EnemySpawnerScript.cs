using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    [SerializeField]
    GameObject acceleratingEnemy;
    [SerializeField]
    GameObject ShooterEnemy;
    [SerializeField]
    GameObject velocityEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void spawnEnemy(GameObject enemy)
    {

        float maxXDiff = 7.5;
        float maxYDiff = 3.5f;

        Vector3 spawnPos = new Vector3(Random.Range(-maxXDiff, maxXDiff), Random.Range(-maxYDiff, maxYDiff), 0);
        while ((spawnPos - transform.position).sqrMagnitude < 9)
        {
            spawnPos = new Vector3(Random.Range(-maxXDiff, maxXDiff), Random.Range(-maxYDiff, maxYDiff), 0);
        }
        collision.gameObject.transform.position = spawnPos;

        Instantiate(enemy, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(0, 0, 0));
    }
}
