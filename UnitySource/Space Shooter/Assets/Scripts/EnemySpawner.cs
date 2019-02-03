using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static float minSpawnRadius = 5f;
    public float startSpawnRadius = 10f;
    private float currentSpawnRadius;

    public int currentWave;
    public float timeUntilNextWave;
    public float waveCooldown = 10f;
    public int waveSize = 5;

    // TODO: change spawning when more enemies created
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        currentSpawnRadius = startSpawnRadius;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeUntilNextWave <= 0)
        {
            if (!FindObjectOfType<Enemy>())
            {
                Debug.Log("Spawning");
                timeUntilNextWave = waveCooldown;
                SpawnWave();
            }
            else
                Debug.Log("Wave not defeated");
        }
        else
        {
            timeUntilNextWave -= Time.deltaTime;
        }

    }

    void SpawnWave()
    {
        // TODO: Dynamicaly increase wave size
        for(int i=0; i < waveSize; ++i)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        Vector2 spawnPos = PlayerMovement.pos;
        spawnPos += Random.insideUnitCircle.normalized * Random.Range(minSpawnRadius,currentSpawnRadius);
        Instantiate(enemy, spawnPos, Quaternion.Euler(0f,0f,Random.Range(0f,360f)));
    }
}
