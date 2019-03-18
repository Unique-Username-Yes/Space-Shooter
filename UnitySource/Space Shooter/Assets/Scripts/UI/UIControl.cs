using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public static UIControl instance;

    private Transform stats;
    private Slider levelSlider;
    private Slider healthSlider;
    private Text level;

    private void Awake()
    {
        if (!instance)
            instance = this;

        stats = transform.Find("PlayerStats");
        if (!stats)
            Debug.LogError("Player stats ui not found");

        levelSlider = stats.Find("XPSlider").GetComponent<Slider>();
        if(!levelSlider)
            Debug.LogError("Level slider not found");

        healthSlider = stats.Find("HealthSlider").GetComponent<Slider>();
        if (!healthSlider)
            Debug.LogError("Health slider not found");

        level = stats.Find("Level").GetComponent<Text>();
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
}
