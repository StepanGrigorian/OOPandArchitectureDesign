using UnityEngine;

public class ShieldModule : Module
{
    [SerializeField] private float Shield;
    private void Start()
    {
        SetShieldBehaviour(new ShieldBehaviour(Shield, Parent));
        ApplyShield();
    }
    private void OnDestroy()
    {
        RemoveShield();
    }
}