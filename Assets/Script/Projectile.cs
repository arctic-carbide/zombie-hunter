using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int lifetime = 1;
    public AudioClip hitSound;
    private void Start()
    {
        Destroy(gameObject, lifetime);   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            collision.collider.gameObject.GetComponent<HealthSystem>().Damage(1);
            AudioSource.PlayClipAtPoint(hitSound, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
