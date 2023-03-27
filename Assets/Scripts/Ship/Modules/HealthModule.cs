using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthModule : Module
{
    [SerializeField] private float Health;
    private void Start()
    {
        SetHealthBehaviour(new HealthBehaviour(Health, Parent));
        ApplyHealth();
    }
    private void OnDestroy()
    {
        RemoveHealth();
    }
}