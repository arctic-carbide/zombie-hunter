using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int lifetime = 5;
    private void Start()
    {
        Destroy(gameObject, lifetime);   
    }
}
