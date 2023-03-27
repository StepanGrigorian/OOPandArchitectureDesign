public interface IShieldRecoverMultiplier
{
    public void SetShieldMultiplier();
    public void RevertShieldMultiplier();
}
public class ShieldRecoverBehaviour : IShieldRecoverMultiplier
{
    private float shield;
    private Ship parent;
    public ShieldRecoverBehaviour(float shield, Ship parent)
    {
        this.shield = shield;
        this.parent = parent;
    }

    public void SetShieldMultiplier()
    {
        parent.ApplyShieldRegenBuff(shield);
    }

    public void RevertShieldMultiplier()
    {
        parent.ApplyShieldRegenBuff(1 / shield);
    }
}