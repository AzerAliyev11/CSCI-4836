using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public TMP_Text scoreText;

    void Start()
    {
        ScoreManager.Instance.OnScoreChanged.AddListener(UpdateScore);
    }

    public void UpdateScore(int score)
    {
        Debug.Log("Hi");
        scoreText.text = score.ToString();
    }

    void OnDisable()
    {
        ScoreManager.Instance.OnScoreChanged.RemoveAllListeners();
    }

    void OnDestroy()
    {
        ScoreManager.Instance.OnScoreChanged.RemoveAllListeners();
    }

    void OnApplicationQuit()
    {
        ScoreManager.Instance.OnScoreChanged.RemoveAllListeners();
    }
}
