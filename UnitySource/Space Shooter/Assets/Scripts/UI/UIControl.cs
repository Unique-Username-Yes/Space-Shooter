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
    }

    private void Start()
    {
        ShowUpgrades(false);
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

    public void ShowUpgrades(bool value)
    {
        if (value)
            UpdateUpgradePanel();
        shipStats.gameObject.SetActive(value);
    }
    public void UpdateUpgradePanel()
    {
        Stats pStats = PlayerProgression.instance.playerStats;
        // Update points
        shipStats.Find("UpgradePoints").GetComponent<Text>().text = pStats.CurrentUpgradePoints.ToString();
        // Update sliders
        float maxUp = pStats.MaxUpgrades;
        UpdateSlider("FireRateUpgrade", pStats.FireRateUpgrades / maxUp);
        UpdateSlider("BulletSpeedUpgrade", pStats.BulletSpeedUpgrades / maxUp);
        UpdateSlider("BulletDamageUpgrade", pStats.BulletDmgUpgrades / maxUp);
        UpdateSlider("RangeUpgrade", pStats.RangeUpgrades / maxUp);
        UpdateSlider("MovementSpeedUpgrade", pStats.MovementSpeedUpgrades / maxUp);
        UpdateSlider("MaxHealthUpgrade", pStats.HealthUpgrades / maxUp);
    }

    private void UpdateSlider(string sliderName, float value)
    {
        shipStats.Find(sliderName).Find("Slider").GetComponent<Slider>().value = value;
    }
}
