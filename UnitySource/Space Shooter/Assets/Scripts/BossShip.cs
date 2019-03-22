using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShip : BaseShip
{
    public string bossName;
    public float pushForce = 1.0f;
    public int shipHealth;
    public int collisionDmg;
    public int pt;

    private void Start()
    {
        health = shipHealth;
        UIControl.instance.ShowBossStats(true);
        UIControl.instance.UpdateBossStats((float)health / shipHealth,bossName);
    }

    public override void TakeDamage(int dmg)
    {
        base.TakeDamage(dmg);
        UIControl.instance.UpdateBossStats((float)health / shipHealth, bossName);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerShip pShip = collision.GetComponent<PlayerShip>();
        if (pShip)
        {
            Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();

            Vector2 dir = (playerRb.position - rb.position).normalized;

            collision.GetComponent<Rigidbody2D>().AddForce(dir * pushForce);

            pShip.TakeDamage(collisionDmg);
        }
    }

    public override void Die()
    {
        // Reward player for killing this unit
        // TODO: implement
        PlayerProgression.instance.ExpForBoss();
        WaveSpawner.instance.BossDefeated();
        base.Die();
    }
}
