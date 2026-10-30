using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int totalScore;

    public int TotalScore => totalScore;

    private void OnEnable() { GameEvents.OnOrderCompleted += HandleOrderCompleted; }
    private void OnDisable() { GameEvents.OnOrderCompleted -= HandleOrderCompleted; }

    private void HandleOrderCompleted(OrderData order)
    {
        totalScore += order.RewardPoints;
        GameEvents.TriggerScoreChanged(totalScore);
    }
}