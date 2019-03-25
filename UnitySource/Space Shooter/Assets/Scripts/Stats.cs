using UnityEngine;

[System.Serializable]
public class Stats
{
    public int MaxUpgrades { get; } = 8;

    public float baseRange = 20.0f;
    public float baseMaxHeal = 100.0f;
    public float baseFireRate = 5.0f;
    public float baseBulletDmg = 15.0f;
    public float baseBulletSpeed = 15.0f;
    public float baseMovementSpeed = 4.0f;
    public float baseBodyDmg = 15.0f;
    public float baseRotationSpeed = 20.0f;

    public int RangeUpgrades { get; private set; } = 0;
    public int HealthUpgrades { get; private set; } = 0;
    public int FireRateUpgrades { get; private set; } = 0;
    public int BulletDmgUpgrades { get; private set; } = 0;
    public int BulletSpeedUpgrades { get; private set; } = 0;
    public int MovementSpeedUpgrades { get; private set; } = 0;

    protected float rangeMult = 4.0f;
    protected float healthMult = 20.0f;
    protected float fireRateMult = .2f;
    protected float bulletDmgMult = 2.0f;
    protected float bulletSpeedMult = 1.0f;
    protected float movementSpeedMult = 1.0f;

    public float Range { get => baseRange + (RangeUpgrades * rangeMult); }
    public float MaxHealth { get => baseMaxHeal + (HealthUpgrades * healthMult); }
    public float FireRate { get => baseFireRate + (FireRateUpgrades * fireRateMult); }
    public float BulletDmg { get => baseBulletDmg + (BulletDmgUpgrades * bulletDmgMult); }
    public float BulletSpeed { get => baseBulletSpeed + (BulletSpeedUpgrades * bulletSpeedMult); }
    public float MovementSpeed { get => baseMovementSpeed + (MovementSpeedUpgrades * movementSpeedMult); }

    // TODO: ?Add posibility to upgrade these
    public float BodyDmg { get => baseBodyDmg; }
    public float RotationSpeed { get => baseRotationSpeed; }

    public bool GiveRangeUpgrade
    {
        get
        {
            if (RangeUpgrades < MaxUpgrades)
            {
                RangeUpgrades++;
                return true;
            }
            else
                return false;
        }
    }
    public bool GiveHealthUpgrade
    {
        get
        {
            if (HealthUpgrades < MaxUpgrades)
            {
                HealthUpgrades++;
                Debug.Log(HealthUpgrades);
                return true;
            }
            else
                return false;
        }
    }
    public bool GiveFireRateUpgrade
    {
        get
        {
            if (FireRateUpgrades < MaxUpgrades)
            {
                FireRateUpgrades++;
                return true;
            }
            else
                return false;
        }
    }
    public bool GiveBulletDmgUpgrade
    {
        get
        {
            if (BulletDmgUpgrades< MaxUpgrades)
            {
                BulletDmgUpgrades++;
                return true;
            }
            else
                return false;
        }
    }
    public bool GiveBulletSpeedUpgrade
    {
        get
        {
            if (BulletSpeedUpgrades< MaxUpgrades)
            {
                BulletSpeedUpgrades++;
                return true;
            }
            else
                return false;
        }
    }
    public bool GiveMovementSpeedUpgrade
    {
        get
        {
            if (MovementSpeedUpgrades< MaxUpgrades)
            {
                MovementSpeedUpgrades++;
                return true;
            }
            else
                return false;
        }
    }
}
