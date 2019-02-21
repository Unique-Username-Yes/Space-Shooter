using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject bulletP;
    public Transform gunPoint;
    public int damage;
    public float bulletSpeed;
    public float range;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Shoot();
    }

    void Shoot()
    {
        // Set up bullet
        // Instantiate it at the location of cannon
        GameObject bullet = Instantiate(bulletP, gunPoint.position, gunPoint.rotation);
        BaseAmmo ammo = bullet.GetComponent<BaseAmmo>();
        ammo.Damage = damage;
        ammo.Speed = bulletSpeed;
        ammo.Range = range;
        ammo.StartPos = gunPoint.position;
        // let it go
    }
}
