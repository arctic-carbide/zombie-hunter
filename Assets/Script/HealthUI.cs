using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

    public HealthSystem player;
    private Text value;



    private void Start()
    {
        value = GetComponentsInChildren<Text>()[1];
        player.OnHealthChangedEvent += UpdateText;
    }

    public void UpdateText(int amount)
    {
        value.text = amount.ToString();
    }

}
