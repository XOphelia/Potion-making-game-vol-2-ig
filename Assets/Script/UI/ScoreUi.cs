using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private void OnEnable() { GameEvents.OnScoreChanged += UpdateText; }
    private void OnDisable() { GameEvents.OnScoreChanged -= UpdateText; }

    private void Start() { UpdateText(0); }

    private void UpdateText(int totalScore)
    {
        scoreText.text = "Score : " + totalScore;
    }
}