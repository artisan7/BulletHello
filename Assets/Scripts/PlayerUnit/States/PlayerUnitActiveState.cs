using System.Collections.Generic;

public class PlayerUnitActiveState : PlayerUnitState
{
    private List<MuzzleController> muzzles;

    public override void Initialize(PlayerUnitController unit)
    {
        muzzles = unit.Muzzles;
        foreach (MuzzleController muzzle in muzzles)
            muzzle.Setup(20 / unit.BaseStats.attackSpeed, unit.BaseStats.bulletPrefab, unit.BaseStats.damage, unit.BaseStats.bulletSpeed, unit.BaseStats.bulletLifetime);
    }

    public override void Terminate(PlayerUnitController unit)
    {
        foreach (MuzzleController muzzle in muzzles)
            muzzle.StopShooting();
    }

    public override void Update(PlayerUnitController unit)
    {
    }
}