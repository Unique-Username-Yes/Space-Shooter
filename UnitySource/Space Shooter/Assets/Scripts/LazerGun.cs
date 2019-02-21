using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerGun : MonoBehaviour
{
    public Transform firePoint;
    public float damage = 1f;
    public float range = 1f;
    public GameObject bulletP;

    private float currentLazerSize = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject laser = Instantiate(bulletP);
        laser.GetComponent<Lazer>().SetDmg(damage);
        laser.transform.position = transform.position;
        laser.transform.up = transform.up;

        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.up, range);

        if (hitInfo)
        {
            if(!hitInfo.transform.GetComponent<Lazer>())
                currentLazerSize = Vector2.Distance(transform.position, hitInfo.transform.position);            
        }
        else
        {
            currentLazerSize = range;
        }

        laser.transform.localScale = new Vector3(0.1f, currentLazerSize,1);
        laser.transform.Translate(laser.transform.up * (currentLazerSize/2.0f), Space.World);
    }
}
