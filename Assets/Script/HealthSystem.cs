using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public delegate void OnHealthChanged(int currentHealth);
    public delegate void OnDamage(int amount);
    public delegate void OnDeath();
    public delegate void OnHeal(int amount);

    // EVENTS
    public event OnDamage OnDamagedEvent;
    public event OnHeal OnHealEvent;
    public event OnHealthChanged OnHealthChangedEvent;
    public event OnDeath OnDeathEvent;

    public const int StartingHealth = 3;
    public int CurrentHealth { get; private set; } = StartingHealth;

    private void Start()
    {
        CurrentHealth = StartingHealth;
        OnHealthChangedEvent(CurrentHealth);
    }

    public void Damage(int amount)
    {
        CurrentHealth -= amount;
        OnDamagedEvent(amount);

        if (CurrentHealth < 1)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        CurrentHealth += amount;
        OnHealEvent(amount);
    }

    public void Die()
    {

        OnDeathEvent();
    }
}
