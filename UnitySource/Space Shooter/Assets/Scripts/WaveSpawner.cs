using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public static WaveSpawner instance;

    public float spawnRadius = 10.0f;
    private Wave currentWave;

    private float timeToSpawn = 0.0f;

    private List<GameObject> enemyShips;

    public bool isAllowedToSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        if (!instance)
            instance = this;

        enemyShips = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= timeToSpawn && isAllowedToSpawn)
        {
            
            SpawnWave();
            timeToSpawn = Time.time + currentWave.waveCooldown;
        }
    }

    private void SpawnWave()
    {
        for(int i=0; i<currentWave.enemyShipCount; ++i)
        {
            foreach (var enemyShip in currentWave.enemyShips)
            {
                if (Random.value <= enemyShip.rarity)
                {
                    SpawnShip(enemyShip.enemyShipP);
                }
            }
        }
    }

    private void RemoveAllEnemyShips()
    {
        foreach(var enemyShip in enemyShips)
        {
            // TODO: Make them explode?
            Destroy(enemyShip);
        }
    }

    private void SpawnShip(GameObject ship)
    {
        Vector2 playerPos = PlayerMovement.pos;
        Vector2 spawnPos = playerPos + (Random.insideUnitCircle.normalized * spawnRadius);

        GameObject enemyS = Instantiate(ship, spawnPos, Quaternion.identity);
        enemyShips.Add(enemyS);
    }

    public void AllowSpawning(bool value)
    {
        isAllowedToSpawn = value;
    }

    public void ChangeWave(Wave newWave)
    {
        // TODO: remove all enemy ships and particles
        if(currentWave!=null)
            RemoveAllEnemyShips();

        // TODO: change wave
        currentWave = newWave;
    }
}
