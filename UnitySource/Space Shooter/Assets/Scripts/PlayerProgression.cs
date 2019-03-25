using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;



public class PlayerProgression : MonoBehaviour
{
    public static PlayerProgression instance;

    /*
     * Track player's level
     * Give player exp
     * When reached needed ammount - level up
     * Store levels
     * Easy level up
     * Easy points
     * Leveling up: give player choice to put points in specific skill
     */
    public Level[] levels;

    public bool isLeveling = false;

    public int currentXP = 0;
    private int level = 0;

    public int upgradePoints = 0;

    private Stats pStats;
    private PlayerShip pShipControls;

    private void Awake()
    {
        if (!instance)
            instance = this;

        pShipControls = GameObject.Find("Player").GetComponent<PlayerShip>();
        if (!pShipControls)
            Debug.LogError("No player ship control found");

        pStats = pShipControls.stats;
    }

    private void Start()
    {
        UIControl.instance.UpdateLevel(level);
        WaveSpawner.instance.ChangeWave(levels[level].wave);
    }

    private IEnumerator ChooseUpgrade()
    {
        WaveSpawner.instance.AllowSpawning(false);
        UIControl.instance.ShowUpgrades(true);
        while (upgradePoints > 0)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log("GIVING HELTH");
                if (pStats.GiveHealthUpgrade)
                    upgradePoints--;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (pStats.GiveMovementSpeedUpgrade)
                    upgradePoints--;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (pStats.GiveRangeUpgrade)
                    upgradePoints--;
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                if (pStats.GiveBulletDmgUpgrade)
                    upgradePoints--;
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                if (pStats.GiveBulletSpeedUpgrade)
                    upgradePoints--;
            }
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                if (pStats.GiveFireRateUpgrade)
                    upgradePoints--;
            }
            UIControl.instance.UpdateUpgradePanel();
            yield return null;
        }
        // Wrap up
        isLeveling = false;
        UIControl.instance.ShowUpgrades(false);
        WaveSpawner.instance.AllowSpawning(true);
    }

    public void LevelUp()
    {
        if (level + 1 >= levels.Count())
        {
            GameControls.instance.EndScreen();
        }
        else
        {
            isLeveling = true;
            currentXP = 0;
            pShipControls.ResetHealth();

            WaveSpawner.instance.RemoveAllEnemyShips();

            Reward currentReward = levels[level].reward;

            upgradePoints += currentReward.upgradePoints;

            StopAllCoroutines();
            StartCoroutine(ChooseUpgrade());

            level++;
            UIControl.instance.UpdateLevel(level);
            WaveSpawner.instance.ChangeWave(levels[level].wave);
        }
    }

    public void GiveUpgradePoints(int ammount)
    {
        upgradePoints += ammount;
        UIControl.instance.UpdateUpgradePanel();
    }

    public void GiveXP(int ammount)
    {
        currentXP += ammount;
        if (currentXP >= levels[level].xpRequirement)
        {
            // TODO: level up
            LevelUp();
        }
        UIControl.instance.UpdateXP((float)currentXP / levels[level].xpRequirement);
    }
}
