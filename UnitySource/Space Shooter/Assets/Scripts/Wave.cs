using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public float enemyShipCount = 5;
    public float waveCooldown = 0.0f;
    public EnemyShipType[] enemyShips;
    public bool isBossWave = false;
}
