using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    public delegate void ScoreChanged(int score);

    public static event ScoreChanged OnScoreChangedEvent;

    private static int _currentScore;
    private const int StartingScore = 0;

    public static int CurrentScore => _currentScore;

    void Start()
    {
        _currentScore = StartingScore;

        OnScoreChangedEvent?.Invoke(_currentScore);
    }

    public static void Increase(int amount)
    {
        _currentScore += amount;

        OnScoreChangedEvent?.Invoke(_currentScore);
    }

    public static void Decrease(int amount)
    {
        _currentScore -= amount;

        OnScoreChangedEvent?.Invoke(_currentScore);
    }

}
