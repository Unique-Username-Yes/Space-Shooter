using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : BaseShip
{
    public override void TakeDamage(int dmg)
    {
        if (!PlayerProgression.instance.isLeveling)
        {
            base.TakeDamage(dmg);
            UIControl.instance.UpdateHealth((float)currentHealth / maxHealth);
        }
    }

    public override void Die()
    {
        // Player lost, restart game
        GameControls.instance.EndScreen();
    }
}
