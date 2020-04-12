using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public int health;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        rb.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0){
            Debug.Log("DIE");
            Destroy(rb.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collide){
        if(collide.gameObject.tag == "Bullet"){
            health -= 25;
        }
    }
}
