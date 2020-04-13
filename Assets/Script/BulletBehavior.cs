using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{

    /* NOTE ~ Mitchell
     * assigned null to private fields to suppress warnings in the unity console
     * only have to do this for private fields; if they were public, they'd still show up in the inspector and without warnings
     */

    //private Transform barrelTip = null;

    [SerializeField]
    private GameObject bullet = null;
    [SerializeField]
    private AudioSource bang = null;
    
    private Vector2 direction;
    private float lookAngle;


    // Start is called before the first frame update
    void Update()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle - 90f);
        if(Input.GetMouseButtonDown(0)){
            FireBullet();
        }
        
    }

    private void FireBullet(){
        GameObject firedBullet = Instantiate(bullet, transform.position, transform.rotation);
        Physics2D.IgnoreCollision(transform.parent.GetComponent<Collider2D>(), firedBullet.GetComponent<Collider2D>());
        firedBullet.GetComponent<Rigidbody2D>().velocity = transform.up * 5f;
        bang.Play();                
    }
}
