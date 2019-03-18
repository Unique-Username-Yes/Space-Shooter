using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyShipType
{
    [Range(0.0f,1.0f)]
    public float rarity = 0.0f;

    public GameObject enemyShipP;
}
