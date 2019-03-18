using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class BaseWeapon : ScriptableObject
{
    public GameObject bulletP;
    public float fireRate = 0.0f;
    public LayerMask toHit;
    bool enemyWeapon = false;


    public void Pewpew(Transform firePoint)
    {
        GameObject bullet = Instantiate(bulletP, firePoint.position, firePoint.rotation);
    }
}
