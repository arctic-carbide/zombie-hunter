using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureScript : MonoBehaviour
{
    public GameObject treasure;
    //public bool collectedTreasure = false;
    // Start is called before the first frame update

    public AudioClip pickupSound;
    public AudioClip spawnSound;
    private AudioSystem system;
    private ScoringSystem score;

    void Start()
    {
        system = GameObject.Find("AudioManager").GetComponent<AudioSystem>();
        treasure =  GameObject.Find("Grid/treasure");
        score = GameObject.Find("ScoreManager").GetComponent<ScoringSystem>();

        AudioSource.PlayClipAtPoint(spawnSound, Camera.main.transform.position);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("anything", treasure);
        if (other.gameObject.tag == "Player") 
        {
            //collectedTreasure = true;

            AudioSource.PlayClipAtPoint(pickupSound, Camera.main.transform.position);
            score.Increase(1);

            Destroy(gameObject);
        }
    }
}
