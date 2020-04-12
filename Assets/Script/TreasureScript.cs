using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureScript : MonoBehaviour
{
    public GameObject treasure;
    public bool collectedTreasure = false;
    // Start is called before the first frame update
    void Start()
    {
        treasure =  GameObject.Find("Grid/treasure");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("anything", treasure);
        if (other.gameObject.tag == "Player") 
        {
            collectedTreasure = true;
            Destroy (treasure.gameObject);

            ScoringSystem.Increase(1);
        }
    }
}
