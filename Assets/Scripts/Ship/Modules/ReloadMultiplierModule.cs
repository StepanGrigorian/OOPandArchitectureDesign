using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadMultiplierModule : Module
{
    [SerializeField] private float Multiplier;
    private void Start()
    {
        SetReloadMultiplier(new ReloadMultiplierBehaviour(Multiplier, Parent));
        ApplyReloadMultiplier();
    }
    private void OnDestroy()
    {
        RevertReloadMultiplier();
    }
}