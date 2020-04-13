using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureScript : MonoBehaviour
{
    public GameObject treasure;
    //public bool collectedTreasure = false;
    // Start is called before the first frame update

    public AudioClip pickupSound;
    private AudioSystem system;

    void Start()
    {
        system = GameObject.Find("AudioManager").GetComponent<AudioSystem>();
        treasure =  GameObject.Find("Grid/treasure");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("anything", treasure);
        if (other.gameObject.tag == "Player") 
        {
            //collectedTreasure = true;

            system.Play(pickupSound);

            Destroy(gameObject);
            ScoringSystem.Increase(1);
        }
    }
}
