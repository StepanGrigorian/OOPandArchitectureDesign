public interface IShield
{
    public void AddShield();
    public void RemoveShield();
}
public class ShieldBehaviour : IShield
{
    private float shield;
    private Ship parent;
    public ShieldBehaviour(float shield, Ship parent)
    {
        this.shield = shield;
        this.parent = parent;
    }

    public void AddShield()
    {
        parent.ApplyShieldBuff(shield);
    }
    public void RemoveShield()
    {
        parent.ApplyShieldBuff(-shield);
    }
}