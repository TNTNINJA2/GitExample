using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    [SerializeField]
    GameObject acceleratingEnemy;
    [SerializeField]
    GameObject shooterEnemy;
    [SerializeField]
    GameObject velocityEnemy;
    [SerializeField]
    GameObject player;

    [SerializeField]
    private float baseSpawnRate;
    [SerializeField]
    private float spawnRateIncrease;
    private float currentSpawnRate;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        currentSpawnRate = baseSpawnRate;
        spawnEnemy(acceleratingEnemy);
    }

    // Update is called once per frame
    void Update()
    {
        currentSpawnRate += spawnRateIncrease * Time.deltaTime;

        if (timer < 5)
        {
            timer += currentSpawnRate * Time.deltaTime;
        }
        else
        {
            timer = 0;
            float randomValue = Random.value;
            if (randomValue < 0.5)
            {
                spawnEnemy(acceleratingEnemy);
            }
            else if (randomValue < 0.8)
            {
                spawnEnemy(shooterEnemy);
            }
            else
            {
                spawnEnemy(velocityEnemy);
            }
        }

    }
    private void spawnEnemy(GameObject enemy)
    {
        float maxXDiff = 7.5f;
        float maxYDiff = 3.5f;

        // Get a valid spawn location
        Vector3 spawnPos = new Vector3(Random.Range(-maxXDiff, maxXDiff), Random.Range(-maxYDiff, maxYDiff), 0);
        while ((spawnPos - player.transform.position).sqrMagnitude < 9)
        {
            spawnPos = new Vector3(Random.Range(-maxXDiff, maxXDiff), Random.Range(-maxYDiff, maxYDiff), 0);
        }

        // spawn it
        Instantiate(enemy, spawnPos, Quaternion.Euler(0, 0, 0));
    }
}
