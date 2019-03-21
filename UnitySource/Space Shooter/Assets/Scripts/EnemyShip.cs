using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : BaseShip
{
    public int shipHealth;
    public int collisionDmg;
    [Range(0.0f,1.0f)]
    public float ptCollisionPenalty;
    public int pt;

    private void Start()
    {
        health = shipHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerShip pShip = collision.collider.GetComponent<PlayerShip>();
        if (pShip)
        {
            PlayerProgression.instance.GiveXP((int)(pt*ptCollisionPenalty));
            pShip.TakeDamage(collisionDmg);
            WaveSpawner.instance.enemyShips.Remove(gameObject);
            base.Die();
        }
    }

    public override void Die()
    {
        // Reward player for killing this unit
        // TODO: implement
        PlayerProgression.instance.GiveXP(pt);
        WaveSpawner.instance.enemyShips.Remove(gameObject);
        base.Die();
    }
}
