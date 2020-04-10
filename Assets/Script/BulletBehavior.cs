using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField]
    private Transform barrelTip;

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private AudioSource bang;
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
        GameObject firedBullet = Instantiate(bullet, barrelTip.position, barrelTip.rotation);
        firedBullet.GetComponent<Rigidbody2D>().velocity = barrelTip.up * 10f;
        bang.Play();
        Destroy(firedBullet, 0.5f);
    }
}
