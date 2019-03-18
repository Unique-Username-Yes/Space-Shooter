using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UIControl : MonoBehaviour
{
    public static UIControl instance;

    private Transform playerStats;
    private Transform shipStats;

    private Slider levelSlider;
    private Slider healthSlider;
    private Text level;

    private bool isUpgradesActive = false;

    private void Awake()
    {
        if (!instance)
            instance = this;

        playerStats = transform.Find("PlayerStats");
        if (!playerStats)
            Debug.LogError("Player stats ui not found");

        levelSlider = playerStats.Find("XPSlider").GetComponent<Slider>();
        if(!levelSlider)
            Debug.LogError("Level slider not found");

        healthSlider = playerStats.Find("HealthSlider").GetComponent<Slider>();
        if (!healthSlider)
            Debug.LogError("Health slider not found");
        shipStats = transform.Find("ShipStats");
        if (!shipStats)
            Debug.LogError("Ship stats ui not found");
        shipStats.gameObject.SetActive(false);

        level = playerStats.Find("Level").GetComponent<Text>();
    }

    public void UpdateXP(float newXp)
    {
        levelSlider.value = newXp;
    }

    public void UpdateHealth(float newHealth)
    {
        healthSlider.value = newHealth;
    }

    public void UpdateLevel(int newLevel)
    {
        level.text = newLevel.ToString();
    }

    public void ShowUpgrades(PlayerStats statPercentage, PlayerStats upgrades)
    {
        isUpgradesActive = true;

        ChangeUpgradePanelValue("HealthUpgrade", statPercentage.maxHealth, upgrades.maxHealth);
        ChangeUpgradePanelValue("FireRateUpgrade", statPercentage.fireRate, upgrades.fireRate);
        ChangeUpgradePanelValue("MovementSpeedUpgrade", statPercentage.movementSpeed, upgrades.movementSpeed);
        shipStats.gameObject.SetActive(true);
        // TODO: set stats here
    }

    private void ChangeUpgradePanelValue(string bar, float maxValue, float upgradeValue)
    {
        shipStats.Find(bar).Find("Slider").GetComponent<Slider>().value = maxValue;
        shipStats.Find(bar).Find("Level").GetComponent<Text>().text = "+"+upgradeValue.ToString();
    }

    public void CloseUpgradePanel()
    {
        if (isUpgradesActive)
        {
            // TODO: make panel inactive
            shipStats.gameObject.SetActive(false);
        }
    }
}
