public abstract class PlayerUnitState
{
    public abstract void Initialize(PlayerUnitController unit);
    public abstract void Terminate(PlayerUnitController unit);
    public abstract void Update(PlayerUnitController unit);
}
