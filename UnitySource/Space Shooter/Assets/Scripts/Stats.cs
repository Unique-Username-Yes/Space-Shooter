[System.Serializable]
public class Stats
{
    public int MaxUpgrades { get; } = 8;
    public int CurrentUpgradePoints { get; set; } = 0;

    public float baseRange = 20.0f;
    public float baseMaxHeal = 100.0f;
    public float baseFireRate = 1.0f;
    public float baseBulletDmg = 15.0f;
    public float baseBulletSpeed = 15.0f;
    public float baseMovementSpeed = 4.0f;

    public int RangeUpgrades { get; private set; } = 0;
    public int HealthUpgrades { get; private set; } = 0;
    public int FireRateUpgrades { get; private set; } = 0;
    public int BulletDmgUpgrades { get; private set; } = 0;
    public int BulletSpeedUpgrades { get; private set; } = 0;
    public int MovementSpeedUpgrades { get; private set; } = 0;

    private float rangeMult = 4.0f;
    private float healthMult = 20.0f;
    private float fireRateMult = 1.0f;
    private float bulletDmgMult = 2.0f;
    private float bulletSpeedMult = 1.0f;
    private float movementSpeedMult = 1.0f;

    public float Range { get => baseRange + (RangeUpgrades * rangeMult); }
    public float MaxHealth { get => baseMaxHeal + (HealthUpgrades * healthMult); }
    public float FireRate { get => baseFireRate + (FireRateUpgrades * fireRateMult); }
    public float BulletDmg { get => baseBulletDmg + (BulletDmgUpgrades * bulletDmgMult); }
    public float BulletSpeed { get => baseBulletSpeed + (BulletSpeedUpgrades * bulletSpeedMult); }
    public float MovementSpeed { get => baseMovementSpeed + (MovementSpeedUpgrades * movementSpeedMult); }

    public void GiveRangeUpgrade() { RangeUpgrades += RangeUpgrades < MaxUpgrades ? 1 : 0; }
    public void GiveHealthUpgrade() { HealthUpgrades += HealthUpgrades < MaxUpgrades ? 1 : 0; }
    public void GiveFireRateUpgrade() { FireRateUpgrades += FireRateUpgrades < MaxUpgrades ? 1 : 0; }
    public void GiveBulletDmgUpgrade() { BulletDmgUpgrades += BulletDmgUpgrades < MaxUpgrades ? 1 : 0; }
    public void GiveBulletSpeedUpgrade() { BulletSpeedUpgrades += BulletSpeedUpgrades < MaxUpgrades ? 1 : 0; }
    public void GiveMovementSpeedUpgrade() { MovementSpeedUpgrades += MovementSpeedUpgrades < MaxUpgrades ? 1 : 0; }

    /*
     * - Current level
     * - Current health
     * - Current xp
     * - Current weapon
     * 
     * ! Have methods to update stats
     * 
     * - Max upgrade
     * - Upgrade multipliers
     * - Range Upgrade = Bullet.cs
     * - Health Upgrade = BaseShip.cs
     * - Bullet Dmg upgrade = Bullet.cs
     * - Bullet Speed upgrade = Bullet.cs
     * - Movement Speed upgrade = PlayerMovement.cs
     * ? Helth regen upgrade = ?
     * - Fire rate = BaseWeapon.cs
     */
}
