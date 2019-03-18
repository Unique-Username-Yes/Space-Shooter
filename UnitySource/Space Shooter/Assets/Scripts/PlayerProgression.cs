using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgression : MonoBehaviour
{
    public static PlayerProgression instance;

    int experiencePoints = 0;
    int level = 0;
    PlayerShip pShip;
    PlayerShooting pShooting;
    public Level[] levels;
    public bool isLevelingUp = false;

    void Awake()
    {
        if (!instance)
            instance = this;
        pShip = GetComponent<PlayerShip>();
        if (!pShip)
            Debug.LogError("No player ship found");

        pShooting = GetComponent<PlayerShooting>();
        if (!pShooting)
            Debug.LogError("No player shooting controls found in progression");
    }

    private void Start()
    {
        WaveSpawner.instance.ChangeWave(levels[level].wave);
        UIControl.instance.UpdateLevel(level);
    }

    public void GiveXP(int xp)
    {
        experiencePoints += xp;
        if(experiencePoints>= levels[level+1].xpRequirement)
        {
            LevelUp();
        }
        UIControl.instance.UpdateXP((float)experiencePoints / levels[level+1].xpRequirement);
    }

    private void LevelUp()
    {
        Debug.Log("Leveld up!");

        Reward reward = levels[level].reward;

        // Increase max health
        pShip.maxHealth += reward.bonusHp;

        pShip.health = pShip.maxHealth;
        experiencePoints = 0;

        if (reward.newWeapon)
        {
            pShooting.weapon = reward.newWeapon;
        }

        level++;

        UIControl.instance.UpdateLevel(level);
        UIControl.instance.UpdateXP((float)experiencePoints / levels[level + 1].xpRequirement);
        UIControl.instance.UpdateHealth((float)pShip.health / pShip.maxHealth);

        WaveSpawner.instance.ChangeWave(levels[level].wave);
    }
}
