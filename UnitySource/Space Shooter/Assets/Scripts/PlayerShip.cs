using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : BaseShip
{
    public override void TakeDamage(int dmg)
    {
        if (!PlayerProgression.instance.isLevelingUp)
        {
            base.TakeDamage(dmg);
            UIControl.instance.UpdateHealth((float)health / maxHealth);
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
