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
        OnDamagedEvent?.Invoke(amount);

        if (_currentHealth < 1)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        _currentHealth += amount;
        OnHealEvent?.Invoke(amount);
    }

    public void Die()
    {

        OnDeathEvent?.Invoke();
    }
}
