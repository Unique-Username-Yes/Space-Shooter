using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class BaseWeapon : ScriptableObject
{
    public GameObject bulletP;
    public float recoil;
    public float weaponDmgBonus;
    public float weaponFireRateBonus;
    public float weaponRangeBonus;
    public float bulletSpeedBonus;


    //public float bulletSpeed;
    //public float range;

    //public void Pewpew(Transform firePoint)
    //{
    //    GameObject bullet = Instantiate(bulletP, firePoint.position, firePoint.rotation);
    //    Bullet b = bullet.transform.Find("Bullet").GetComponent<Bullet>();
    //    if (!b)
    //        Debug.LogError("No bullet control found in BaseWeapon");
    //}
}
