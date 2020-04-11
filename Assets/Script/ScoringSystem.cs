using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    public delegate void ScoreChanged(int score);

    public event ScoreChanged OnScoreChangedEvent;

    private int _currentScore;
    private const int StartingScore = 0;

    public int CurrentScore => _currentScore;

    void Start()
    {
        _currentScore = StartingScore;

        OnScoreChangedEvent?.Invoke(_currentScore);
    }

    public void Increase(int amount)
    {
        _currentScore += amount;

        OnScoreChangedEvent?.Invoke(_currentScore);
    }

    public void Decrease(int amount)
    {
        _currentScore -= amount;

        OnScoreChangedEvent?.Invoke(_currentScore);
    }

}
