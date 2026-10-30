using UnityEngine;

[CreateAssetMenu(fileName = "NewOrder", menuName = "Potion Maker/Order")]
public class OrderData : ScriptableObject
{
    [SerializeField] private string customerName;
    [SerializeField] private PotionData requestedPotion;
    [SerializeField] private int rewardPoints = 10;

    public string CustomerName => customerName;
    public PotionData RequestedPotion => requestedPotion;
    public int RewardPoints => rewardPoints;
}