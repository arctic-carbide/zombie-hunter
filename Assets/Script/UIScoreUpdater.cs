using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScoreUpdater : MonoBehaviour
{

    public ScoringSystem target;
    private Text score;

    private void Start()
    {
        score = GetComponent<Text>();
        ScoringSystem.OnScoreChangedEvent += UpdateScoreText;
    }

    public void UpdateScoreText(int reportedScoreValue)
    {
        score.text = reportedScoreValue.ToString();
    }

}
