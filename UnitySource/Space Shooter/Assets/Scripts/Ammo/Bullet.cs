using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;

    private BaseShip ship;
    private Stats stats;

    private GameObject effect;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!rb)
            Debug.LogError("No bullet body found");
    }

    private void Start()
    {
        ship = transform.parent.parent.GetComponent<BaseShip>();
        if (!ship)
            Debug.LogError("No base ship found in bullet");

        stats = ship.stats;
        effect = ship.effects;
        rb.velocity = transform.up * (stats.BulletSpeed+ship.weapon.bulletSpeedBonus);
        transform.parent.parent = null;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.parent.position,transform.position) >= (stats.Range + ship.weapon.weaponRangeBonus))
        {
            // Bullet range reached
            Remove(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ship as EnemyShip)
        {
            Debug.Log("Enemy bullet collision found");
            // Bullet belongs to enemy - Deal damage only to player ship
            PlayerShip pShip = collision.GetComponent<PlayerShip>();
            if (pShip)
            {
                pShip.TakeDamage(ship.CalcDmg(true));
                Remove(gameObject);
            }
        }
        else
        {
            // Bullet belongs to player - Deal damage only to enemy ships
            EnemyShip eShip = collision.GetComponent<EnemyShip>();
            if (eShip)
            {
                eShip.TakeDamage(ship.CalcDmg(true));
                Remove(gameObject);
                return;
            }
            // TODO: Refactoring point
            BossShip bShip = collision.GetComponent<BossShip>();
            if (bShip)
            {
                bShip.TakeDamage(ship.CalcDmg(true));
                Remove(gameObject);
                return;
            }
        }
    }

    private void Remove(GameObject obj)
    {
        GameObject effectEn = Instantiate(effect, transform.position, Quaternion.identity);
        effectEn.GetComponent<ParticleSystem>().Play();

        Destroy(effectEn, 5.0f);
        Destroy(obj.transform.parent.gameObject);
    }
}
