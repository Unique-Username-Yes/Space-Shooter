using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Reward
{
    public int bonusHp;
    public BaseWeapon newWeapon;
    // TODO: Give player weapon upgrade choice
    public PlayerStats statsUpgrade;
}
