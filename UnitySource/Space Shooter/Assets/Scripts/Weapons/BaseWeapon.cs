using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class BaseWeapon : ScriptableObject
{
    public GameObject bulletP;
    public float recoil;

    public float range;
    public float bulletDmg;
    public float bulletSpeed;

    public void Pewpew(Transform firePoint)
    {
        GameObject bullet = Instantiate(bulletP, firePoint.position, firePoint.rotation);
        Bullet b = bullet.transform.Find("Bullet").GetComponent<Bullet>();
        if (!b)
            Debug.LogError("No bullet control found in BaseWeapon");

        b.bulletRange = range;
        b.bulletSpeed = bulletSpeed;
        b.bulletDamage = (int)bulletDmg;
    }
}
