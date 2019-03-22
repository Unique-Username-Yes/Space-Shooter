using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public enum Upgrade
{
    FireRate=0,
    BulletDmg=1,
    BulletSpeed=2,
    Range=3,
    MovementSpeed=4,
    MaxHealth=5,

}

public class PlayerProgression : MonoBehaviour
{
    public static PlayerProgression instance;

    public Stats playerStats;
    int experiencePoints = 0;
    public int level = 0;
    PlayerShip pShip;
    PlayerMovement pMovement;
    PlayerShooting pShooting;
    public Level[] levels;

    public bool isLevelingUp = false;
    private bool isWaitingForUpgrade = false;

    private IEnumerator choice;

    void Awake()
    {
        if (!instance)
            instance = this;
        pShip = GetComponent<PlayerShip>();
        if (!pShip)
            Debug.LogError("No player ship found in progression");

        pShooting = GetComponent<PlayerShooting>();
        if (!pShooting)
            Debug.LogError("No player shooting controls found in progression");

        pMovement = GetComponent<PlayerMovement>();
        if (!pMovement)
            Debug.LogError("No player movement controls found in progression");
    }

    private void Start()
    {
        // Update stats to default values
        foreach(Upgrade upg in Enum.GetValues(typeof(Upgrade))) { UpdateStat(upg); }

        choice = ChooseUpgrade();

        WaveSpawner.instance.ChangeWave(levels[level].wave);
        UIControl.instance.UpdateLevel(level);
    }

    public void NextLvl()
    {
        // TODO: Refactor point
        StopAllCoroutines();
        int xpForNext = levels[level].xpRequirement - experiencePoints;
        GiveXP(xpForNext);
    }

    public void GiveUpgradePoints()
    {
        // TODO: Refactor point
        playerStats.CurrentUpgradePoints += 5;
        UIControl.instance.UpdateUpgradePanel();
    }

    public void ExpForBoss()
    {
        // Refactor point
        if (levels[level].wave.isBossWave)
        {
            // Progress to the next lvl
            int xpForNext = levels[level].xpRequirement - experiencePoints;
            GiveXP(xpForNext);
        }
    }

    public void GiveXP(int xp)
    {
        experiencePoints += xp;
        Debug.Log(level + 1);
        if(experiencePoints>= levels[level].xpRequirement)
        {
            Debug.Log("Level: " + (level + 1) + " Count: " + levels.Count());
            if ((level + 1) >= levels.Count())
            {
                // End of game
                GameControls.instance.EndScreen();
            }
            else
            {
                RewardPlayer();
            }
        }
        UIControl.instance.UpdateXP((float)experiencePoints / levels[level].xpRequirement);
    }

    private IEnumerator ChooseUpgrade()
    {
        UIControl.instance.ShowUpgrades(true);

        while (playerStats.CurrentUpgradePoints > 0)
        {
            // Health
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                UpgradeStat(Upgrade.MaxHealth);
            }

            // Movement Speed
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                UpgradeStat(Upgrade.MovementSpeed);
            }

            // Range
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                UpgradeStat(Upgrade.Range);
            }

            // Bullet dmg
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                UpgradeStat(Upgrade.BulletDmg);
            }

            // Bullet speed
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                UpgradeStat(Upgrade.BulletSpeed);
            }

            // Fire rate
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                UpgradeStat(Upgrade.FireRate);
            }
            yield return null;
        }

        UIControl.instance.ShowUpgrades(false);
        WaveSpawner.instance.AllowSpawning(true);
    }

    private void UpgradeStat(Upgrade upgrade)
    {
        switch (upgrade)
        {
            case Upgrade.FireRate:
                {
                    playerStats.GiveFireRateUpgrade();
                    pShooting.fireRate = playerStats.FireRate;
                    playerStats.CurrentUpgradePoints--;
                    break;
                }
            case Upgrade.BulletDmg:
                {
                    playerStats.GiveBulletDmgUpgrade();
                    pShooting.weapon.bulletDmg = (int)playerStats.BulletDmg;
                    playerStats.CurrentUpgradePoints--;
                    break;
                }
            case Upgrade.BulletSpeed:
                {
                    playerStats.GiveBulletSpeedUpgrade();
                    pShooting.weapon.bulletSpeed = playerStats.baseBulletSpeed;
                    playerStats.CurrentUpgradePoints--;
                    break;
                }
            case Upgrade.Range:
                {
                    playerStats.GiveRangeUpgrade();
                    pShooting.weapon.range = playerStats.Range;
                    playerStats.CurrentUpgradePoints--;
                    break;
                }
            case Upgrade.MaxHealth:
                {
                    // TODO: Give one upgrade
                    playerStats.GiveHealthUpgrade();
                    // TODO: Update stats
                    pShip.SetMaxHealth = (int)playerStats.MaxHealth;
                    // TODO: subtract one point from total point count
                    playerStats.CurrentUpgradePoints--;
                    break;
                }
            case Upgrade.MovementSpeed:
                {
                    playerStats.GiveMovementSpeedUpgrade();
                    pMovement.speed = playerStats.MovementSpeed;
                    playerStats.CurrentUpgradePoints--;
                    break;
                }
        }
        // TODO: Update upgrade on gui
        UIControl.instance.UpdateUpgradePanel();
    }

    private void UpdateStat(Upgrade upgrade)
    {
        switch (upgrade)
        {
            case Upgrade.FireRate:
                {
                    pShooting.fireRate = playerStats.FireRate;
                    break;
                }
            case Upgrade.BulletDmg:
                {
                    pShooting.weapon.bulletDmg = (int)playerStats.BulletDmg;
                    break;
                }
            case Upgrade.BulletSpeed:
                {
                    pShooting.weapon.bulletSpeed = playerStats.baseBulletSpeed;
                    break;
                }
            case Upgrade.Range:
                {
                    pShooting.weapon.range = playerStats.Range;
                    break;
                }
            case Upgrade.MaxHealth:
                {
                    pShip.SetMaxHealth = (int)playerStats.MaxHealth;
                    break;
                }
            case Upgrade.MovementSpeed:
                {
                    pMovement.speed = playerStats.MovementSpeed;
                    break;
                }
        }
    }

    private void RewardPlayer()
    {
        WaveSpawner.instance.AllowSpawning(false);

        WaveSpawner.instance.ChangeWave(levels[level + 1].wave);

        playerStats.CurrentUpgradePoints += levels[level].reward.upgradePoints;

        StartCoroutine(ChooseUpgrade());

        pShip.SetMaxHealth = (int)playerStats.MaxHealth;
        experiencePoints = 0;
        level++;
        UIControl.instance.UpdateLevel(level);
        UIControl.instance.UpdateXP((float)experiencePoints / levels[level].xpRequirement);
    }
}
