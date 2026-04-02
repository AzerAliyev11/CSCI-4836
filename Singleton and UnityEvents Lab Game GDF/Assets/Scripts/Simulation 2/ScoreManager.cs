using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public UnityEvent<int> OnScoreChanged;
    int score = 0;

    void Awake()
    {
        Instance = this;
    }

    public void AddScore(int amount)
    {
        score += amount;
        OnScoreChanged.Invoke(score);
    }
}
