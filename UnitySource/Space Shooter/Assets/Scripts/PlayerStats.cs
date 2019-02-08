using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public enum PlayerStates
    {
        FLY,
        DIE,
        LVLUP,
        PAUSE
    }

    PlayerStates currentState;
    public float totalHealth = 100f;
    public float health = 100f;
    public float xp = 0f;
    public float xpUntilNextLvl = 10f;
    public float currentLvl = 0f;
    public float size = 1f;
    public PlayerMovement movement;

    public float increaseHealthBy = 1f;
    public float increaseSpeedBy = 1f;
    public float increaseSizeBy = 0.1f;

    public float maxSpeed = 20f;
    public float maxSize = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerStates.PAUSE;
        health = totalHealth;
        movement = GetComponent<PlayerMovement>();
        transform.localScale = new Vector3(size, size, size);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GiveXP(float xp)
    {
        this.xp += xp;
        // Increase stats
        if (xp >= xpUntilNextLvl)
        {
            LevelUp();
            currentState = PlayerStates.LVLUP;
        }
    }

    public void LevelUp()
    {
        // Increase xp needed for next lvl

        currentLvl++;
        size += (size<maxSize)?increaseSizeBy:0;
        transform.localScale = new Vector3(size, size, size);

        movement.speed += (movement.speed<maxSpeed)?increaseSpeedBy:0;

        totalHealth += increaseHealthBy;

        // Reset health to full
        health = totalHealth;
        // Reset xp
        xp = 0f;

        // Switch back to flying state
        currentState = PlayerStates.FLY;
    }
}
