using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgression : MonoBehaviour
{
    public static PlayerProgression instance;

    int experiencePoints = 0;
    int level = 0;
    PlayerShip pShip;
    PlayerMovement pMovement;
    PlayerShooting pShooting;
    public Level[] levels;

    public bool isLevelingUp = false;
    private bool isWaitingForUpgrade = false;

    public PlayerStats stats;
    public PlayerStats maxStats;

    private IEnumerator waitForChoice;

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
        WaveSpawner.instance.ChangeWave(levels[level].wave);
        UIControl.instance.UpdateLevel(level);
        waitForChoice = Choice();
        SetStats(stats);
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

    private IEnumerator Choice()
    {
        isWaitingForUpgrade = true;
        Reward reward = levels[level].reward;


        while (isWaitingForUpgrade)
        {
            Debug.Log("Waiting");
            if (Input.GetKey(KeyCode.Alpha1) &&
                (stats.movementSpeed + reward.statsUpgrade.movementSpeed) <= maxStats.movementSpeed)
            {
                // Movement speed
                stats.movementSpeed += reward.statsUpgrade.movementSpeed;
                isWaitingForUpgrade = false;
            }
            else if (Input.GetKey(KeyCode.Alpha2) &&
                (stats.fireRate + reward.statsUpgrade.fireRate) <= maxStats.fireRate)
            {
                // Fire rate
                stats.fireRate += reward.statsUpgrade.fireRate;
                isWaitingForUpgrade = false;
            }
            else if (Input.GetKey(KeyCode.Alpha3) &&
                (stats.maxHealth + reward.statsUpgrade.maxHealth) <= maxStats.maxHealth)
            {
                // Health
                stats.maxHealth += reward.statsUpgrade.maxHealth;
                isWaitingForUpgrade = false;
            }
            yield return null;
        }

        Debug.Log("Not waiting");
        SetStats(stats);

        WaveSpawner.instance.AllowSpawning(true);
        UIControl.instance.CloseUpgradePanel();
    }

    private void LevelUp()
    {
        Debug.Log("Leveld up!");
        Reward reward = levels[level].reward;

        // TODO: Show potential weapon upgrades
        PlayerStats percentStats = stats;
        percentStats.fireRate /= maxStats.fireRate;
        percentStats.maxHealth /= maxStats.maxHealth;
        percentStats.movementSpeed /= maxStats.movementSpeed;

        UIControl.instance.ShowUpgrades(percentStats, reward.statsUpgrade);

        WaveSpawner.instance.AllowSpawning(false);
        WaveSpawner.instance.ChangeWave(levels[level].wave);

        // TODO: Wait for player to pick upgrades
        StartCoroutine(Choice());

        // TODO: Get stats upgrade and add it to current stats

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

        Debug.Log(isWaitingForUpgrade);
    }

    private void SetStats(PlayerStats statsToSet)
    {
        pShip.maxHealth = stats.maxHealth;
        pMovement.speed = stats.movementSpeed;
        pShooting.weapon.fireRate = stats.fireRate;
    }
}
