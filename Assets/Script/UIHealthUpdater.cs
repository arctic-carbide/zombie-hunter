using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthUpdater : MonoBehaviour
{
    public HealthSystem target;

    private void Awake()
    {
        target.OnHealthChangedEvent += UpdateText;
    }

    public void UpdateText(int amount)
    {
        GetComponent<Text>().text = amount.ToString();
    }

}
