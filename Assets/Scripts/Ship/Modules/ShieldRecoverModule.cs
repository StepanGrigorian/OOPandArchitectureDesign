using UnityEngine;

public class ShieldRecoverModule : Module
{
    [SerializeField] private float Multiplier;
    private void Start()
    {
        SetShieldRecoverMultiplier(new ShieldRecoverBehaviour(Multiplier, Parent));
        ApplyShieldRecoverMultiplier();
    }
    private void OnDestroy()
    {
        RevertShieldRecoverMultiplier();
    }
}