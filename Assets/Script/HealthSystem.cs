using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{
    public delegate void HealthChangedDelegate(int currentHealth);
    public delegate void HealDelegate(int amount);
    public delegate void DamageDelegate(int amount);
    public delegate void DeathDelegate();

    // EVENTS
    public event DamageDelegate OnDamagedEvent;
    public event HealDelegate OnHealEvent;
    public event HealthChangedDelegate OnHealthChangedEvent;
    public event DeathDelegate OnDeathEvent;

    public int CurrentHealth => _currentHealth;
    private int _currentHealth;

    [SerializeField]
    private int startingHealth = 3;

    private void Start()
    {
        _currentHealth = startingHealth;

        // NOTE: the ? before an event is a null test; effectively "if (event != null)" 

        OnHealthChangedEvent?.Invoke(_currentHealth);
        
    }

    public void Damage(int amount)
    {
        _currentHealth -= amount;

        if (_currentHealth < 1)
        {
            Die();
        }
        else
        {
            OnDamagedEvent?.Invoke(amount);
        }
            
        OnHealthChangedEvent?.Invoke(_currentHealth);
    }

    public void Heal(int amount)
    {
        _currentHealth += amount;

        OnHealEvent?.Invoke(amount);
        OnHealthChangedEvent?.Invoke(_currentHealth);
    }

    public void Die()
    {
        // do something like destroy the player object or whatever
        OnDeathEvent?.Invoke();
    }
}
