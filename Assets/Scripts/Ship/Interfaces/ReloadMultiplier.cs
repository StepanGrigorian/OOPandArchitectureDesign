public interface IReloadMultiplier
{
    public void SetReloadMultiplier();
    public void RevertReloadMultiplier();
}
public class ReloadMultiplierBehaviour : IReloadMultiplier
{
    private float reload;
    private Ship parent;
    public ReloadMultiplierBehaviour(float reload, Ship parent)
    {
        this.reload = reload;
        this.parent = parent;
    }

    public void SetReloadMultiplier()
    {
        parent.ApplyReloadBuff(reload);
    }
    public void RevertReloadMultiplier()
    {
        parent.ApplyReloadBuff(1 / reload);
    }
}