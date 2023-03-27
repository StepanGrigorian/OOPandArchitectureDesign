public interface IHealth
{
    public void AddHealth();
    public void RemoveHealth();
}
public class HealthBehaviour : IHealth
{
    private float health;
    private Ship parent;
    public HealthBehaviour(float health, Ship parent)
    {
        this.health = health;
        this.parent = parent;
    }

    public void AddHealth()
    {
        parent.ApplyHealthBuff(health);
    }
    public void RemoveHealth()
    {
        parent.ApplyHealthBuff(-health);
    }
}