using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTreasure : MonoBehaviour
{

    public GameObject treasure;

    [Range(0, 1)]
    public float dropChance = 0.25f;

    private void Start()
    {
        GetComponent<HealthSystem>().OnDeathEvent += Drop;
    }

    private void Drop()
    {
        Random rng = new Random();

        if (Random.value <= dropChance)
        {
            Instantiate(treasure, transform.position, Quaternion.identity);
        }
    }
}
