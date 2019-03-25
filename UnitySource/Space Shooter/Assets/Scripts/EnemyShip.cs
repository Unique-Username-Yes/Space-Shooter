using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : BaseShip
{
    [Range(0.0f, 1.0f)]
    public float ptCollisionPenalty;
    public int pt;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerShip pShip = collision.collider.GetComponent<PlayerShip>();
        if (pShip)
        {
            pShip.TakeDamage(CalcDmg(false));
            PlayerProgression.instance.GiveXP((int)(pt*ptCollisionPenalty));
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
        Destroy(gameObject);
    }
}
