using UnityEngine;

public class PlayerUnitDeadState : PlayerUnitState
{
    public override void Initialize(PlayerUnitController unit)
    {
        unit.Body.isKinematic = false;
        unit.Sprite.color = Color.red;
    }

    public override void Terminate(PlayerUnitController unit)
    {
    }

    public override void Update(PlayerUnitController unit)
    {
    }
}