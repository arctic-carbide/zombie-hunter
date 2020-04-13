using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int lifetime = 1;
    public GameObject project;
    private void Start()
    {
        Destroy(project, lifetime);   
    }
}
