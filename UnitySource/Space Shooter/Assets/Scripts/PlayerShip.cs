using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : BaseShip
{
    private int shipMaxHealth;

    public int SetMaxHealth
    {
        set
        {
            shipMaxHealth = value;
            health = shipMaxHealth;
            UIControl.instance.UpdateHealth((float)health / shipMaxHealth);
        }
    }

    protected void Awake()
    {
        health = shipMaxHealth;
    }

    public override void TakeDamage(int dmg)
    {
        if (!PlayerProgression.instance.isLevelingUp)
        {
            base.TakeDamage(dmg);
            UIControl.instance.UpdateHealth((float)health / shipMaxHealth);
        }
    }

    public override void Die()
    {
        // Player lost, restart game
        WaveSpawner.instance.AllowSpawning(false);
        GameControls.instance.isPlayerDead = true;
        base.Die();
    }
}
