using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerShooting : MonoBehaviour
{
    PlayerShip playerShip;

    private void Awake()
    {

        playerShip = GetComponent<PlayerShip>();
        if (!playerShip)
            Debug.LogError("No player ship found in PlayerShooting");
    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            playerShip.Shoot();
        }
    }


}
