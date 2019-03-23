using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyStats : Stats
{
    public float baseBodyDmg = 15.0f;
    public float baseRotationSpeed = 20.0f;

    // TODO: ?Add posibility to upgrade these
    public float BodyDmg { get => baseBodyDmg; }
    public float RotationSpeed { get => baseRotationSpeed; }
}
