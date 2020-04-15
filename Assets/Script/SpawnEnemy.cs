using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;

    private Transform[] spawnPoints;
    public float cooldown = 0.5f;
    private bool locked = false;
    private int num = 0;


    void Start()
    {

        spawnPoints = GetComponentsInChildren<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!locked)
        {

            StartCoroutine(Spawn(spawnPoints[num % spawnPoints.Length]));
            num++;
        }
    }

    private IEnumerator Spawn(Transform spawnPoint)
    {
        locked = true;
        
        Instantiate(enemy, spawnPoint.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(cooldown);

        locked = false;
    }
}
