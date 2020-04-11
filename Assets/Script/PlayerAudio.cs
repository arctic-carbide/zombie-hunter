using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioClip[] hurtSFX = new AudioClip[1];
    public AudioClip[] deathSFX = new AudioClip[1];

    private HealthSystem system;
    private AudioSource source;
    private System.Random rng = new System.Random();
    private const string damageTag = "Damage Source";

    void Start()
    {
        source = GetComponent<AudioSource>();
        system = GetComponent<HealthSystem>();

        if (system != null)
        {
            system.OnDamagedEvent += PlayHurtSound;
            system.OnDeathEvent += PlayDeathSound;
        }

    }

    private void OnEnable()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) { 

        switch (collision.collider.tag)
        {

            case damageTag: PlaySound(hurtSFX);
                break;

        }

    }

    public void PlayDeathSound()
    {
        PlaySound(deathSFX);
    }

    public void PlayHurtSound(int amount)
    {
        PlaySound(hurtSFX);
    }

    private void PlaySound(params AudioClip[] clips)
    {
        Debug.Assert(clips != null);

        if (clips != null && clips.Length > 0)
        {
            source.clip = clips[rng.Next(0, clips.Length) % clips.Length];
            source.Play();
            
        }
    }
}
