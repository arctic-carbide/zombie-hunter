using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour
{

    public GameObject reset;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<HealthSystem>().OnDeathEvent += GameOver;
    }


    private void GameOver()
    {
        reset.SetActive(true);
    }

    public static void Reload()
    {
        SceneManager.LoadScene(0);
    }
}
