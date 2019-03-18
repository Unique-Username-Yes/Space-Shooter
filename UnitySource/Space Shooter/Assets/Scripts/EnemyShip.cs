using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : BaseShip
{
    public int collisionDmg = 10;
    public int pt = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerShip pShip = collision.collider.GetComponent<PlayerShip>();
        if (pShip)
        {
            pShip.TakeDamage(collisionDmg);
            // Remove ship after collision
            base.Die();
        }
    }

    public override void Die()
    {
        // Reward player for killing this unit
        // TODO: implement
        PlayerProgression.instance.GiveXP(pt);
        base.Die();
    }
}
