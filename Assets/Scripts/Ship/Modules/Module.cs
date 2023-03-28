using UnityEngine;

public abstract class Module : MonoBehaviour
{
    [HideInInspector] public Ship Parent;
    [HideInInspector] public Slot Slot;

    [SerializeField] private SlotType MyType;

    protected IShield shield;
    protected IHealth health;
    protected IReloadMultiplier reloadMultiplier;
    protected IShieldRecoverMultiplier shieldRecoverMultiplier;
    protected IWeapon weapon;

    public GameObject MyPrefab;
    public Sprite MyIcon;
    [TextArea] public string Description;
    #region Interface init
    public void SetShieldBehaviour(IShield shieldBehaviour)
    {
        shield = shieldBehaviour;
    }
    public void SetHealthBehaviour(IHealth healthBehaviour)
    {
        health = healthBehaviour;
    }
    public void SetReloadMultiplier(IReloadMultiplier reloadMultiplier)
    {
        this.reloadMultiplier = reloadMultiplier;
    }
    public void SetShieldRecoverMultiplier(IShieldRecoverMultiplier recoverMultiplier)
    {
        shieldRecoverMultiplier = recoverMultiplier;
    }
    public void SetWeaponBehaviour(IWeapon weapon)
    {
        this.weapon = weapon;
    }
    #endregion
    #region Functionality
    protected void ApplyShield()
    {
        shield.AddShield();
    }
    protected void RemoveShield()
    {
        shield.RemoveShield();
    }
    protected void ApplyHealth()
    {
        health.AddHealth();
    }
    protected void RemoveHealth()
    {
        health.RemoveHealth();
    }
    protected void ApplyReloadMultiplier()
    {
        reloadMultiplier.SetReloadMultiplier();
    }
    protected void RevertReloadMultiplier()
    {
        reloadMultiplier.RevertReloadMultiplier();
    }
    protected void ApplyShieldRecoverMultiplier()
    {
        shieldRecoverMultiplier.SetShieldMultiplier();
    }
    protected void RevertShieldRecoverMultiplier()
    {
        shieldRecoverMultiplier.RevertShieldMultiplier();
    }
    #endregion
    private void OnMouseDown()
    {
        Slot.used = false;
        Destroy(gameObject);
    }
    public SlotType GetMyType()
    {
        return MyType;
    }
    public void InitModule(Slot currentSlot)
    {
        Parent = currentSlot.Parent;
        Slot = currentSlot;
        Parent.Modules.Add(this);
    }
}