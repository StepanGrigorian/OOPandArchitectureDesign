using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Ship : MonoBehaviour
{
    [SerializeField] private ShipUI myUI;
    [SerializeField] private float health;
    [SerializeField] private float shield;
    [SerializeField] private float shieldRegeneration;

    private float currentHealth;
    private float CurrentHealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            if (value > 0)
            {
                currentHealth = value;
            }
            else
            {
                currentHealth = 0;
                OnLose?.Invoke(this);
            }
            UpdateUI();
        }
    }
    private float currentShield;
    private float CurrentShield
    {
        get
        {
            return currentShield;
        }
        set
        {
            if (value > 0)
            {
                currentShield = value;
            }
            else
            {
                CurrentHealth += value;
                currentShield = 0;
            }
            UpdateUI();
        }
    }
    public float ReloadMultiplier { get; private set; } = 1f;
    public float ShieldRegenerationMultiplier { get; private set; } = 1f;
    private Rigidbody2D rb;
    public List<Module> Modules { get; private set; } = new();
    public List<WeaponModule> Weapons { get; private set; } = new();

    public delegate void Lose(Ship loser);
    public event Lose OnLose;
    private void Start()
    {
        currentShield = shield;
        currentHealth = health;
        UpdateUI();
    }
    #region Modules functions
    public void ApplyShieldBuff(float shield)
    {
        this.shield += shield;
        CurrentShield = this.shield;
    }
    public void ApplyHealthBuff(float health)
    {
        this.health += health;
        CurrentHealth = this.health;
        UpdateUI();
    }
    public void ApplyReloadBuff(float multiplier)
    {
        ReloadMultiplier *= multiplier;
    }
    public void ApplyShieldRegenBuff(float multiplier)
    {
        ShieldRegenerationMultiplier *= multiplier;
    }
    #endregion
    public void TakeDamage(float damage)
    {
        CurrentShield -= damage;
    }
    public void Activate()
    {
        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
        currentShield = shield;
        currentHealth = health;
        StartCoroutine(ShieldRegeneration());
    }
    public void Deactivate()
    {
        StopAllCoroutines();
        foreach (var weapon in Weapons)
        {
            Destroy(weapon);
        }
        OnLose = null;
    }
    IEnumerator ShieldRegeneration()
    {
        while (true)
        {
           yield return new WaitForSeconds(1f);
            CurrentShield += shieldRegeneration * ShieldRegenerationMultiplier;
            if (CurrentShield > shield)
                CurrentShield = shield;
        }
    }
    private void UpdateUI()
    {
        myUI.UpdateUI(currentHealth, health, currentShield, shield);
    }
}