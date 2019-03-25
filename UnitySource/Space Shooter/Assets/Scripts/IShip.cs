using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShip
{
    void TakeDamage(int dmg);
    void Die();
    int CalcDamage(bool isRangedAttack);
}
