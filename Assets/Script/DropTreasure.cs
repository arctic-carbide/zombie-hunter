using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTreasure : MonoBehaviour
{

    public GameObject treasure;

    private void OnDisable()
    {
        Random rng = new Random();

        if (Random.value > 0.75)
        {
            Instantiate(treasure, transform.position, Quaternion.identity);
        }

    }
}
