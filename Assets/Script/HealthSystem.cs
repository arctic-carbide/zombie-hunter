using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
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

    public string[] damageSourceTags = { "Projectile" };
    public int CurrentHealth => currentHealth;
    private int currentHealth;
    private bool invincible = false;
    public int invincibilityTime = 3; // in seconds

    [SerializeField]
    private int startingHealth = 3;

    private void Start()
    {
        currentHealth = startingHealth;

        // NOTE: the ? before an event is a null test; effectively "if (event != null)" 

        OnHealthChangedEvent?.Invoke(currentHealth);
        
    }

    public void Damage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth < 1)
        {
            Die();
        }
        else
        {
            OnDamagedEvent?.Invoke(amount);
        }
            
        OnHealthChangedEvent?.Invoke(currentHealth);

        StartCoroutine(ToggleInvincibility(invincibilityTime));
    }

    public void Heal(int amount)
    {
        currentHealth += amount;

        OnHealEvent?.Invoke(amount);
        OnHealthChangedEvent?.Invoke(currentHealth);
    }

    public void Die()
    {
        // do something like destroy the player object or whatever
        OnDeathEvent?.Invoke();
        Destroy(gameObject);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (invincible) return;

        if (damageSourceTags.Any(t => collision.collider.CompareTag(t)))
        {
            Damage(1);
            // Destroy(collision.gameObject);
        }
    }

    private IEnumerator ToggleInvincibility(int time)
    {
        invincible = true;

        yield return new WaitForSeconds(time);

        invincible = false;
    }
}
