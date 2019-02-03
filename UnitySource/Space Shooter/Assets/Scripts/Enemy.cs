using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int healthPoints = 100;
    public int xpWorth = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Enemy movement and attacks
    }

    public void TakeDamage(int dmg)
    {
        healthPoints -= dmg;
        if (healthPoints < 0)
        {
            Death();
        }
    }

    private void Death()
    {
        // TODO: Give xp

        Destroy(gameObject);
    }
}
