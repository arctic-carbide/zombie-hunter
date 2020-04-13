using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyVulnarability : MonoBehaviour
{
    public string[] damageSourceTags = { "Projectile" };

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (damageSourceTags.Any(t => collision.collider.CompareTag(t)))
        {
            GetComponent<HealthSystem>().Damage(1);
        }
    }
}
