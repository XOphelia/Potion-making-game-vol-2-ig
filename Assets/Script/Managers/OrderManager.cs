using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    [SerializeField] private List<OrderData> possibleOrders = new List<OrderData>();

    private OrderData currentOrder;

    public OrderData CurrentOrder => currentOrder;

    private void OnEnable() { GameEvents.OnBrewSucceeded += HandleBrewSucceeded; }
    private void OnDisable() { GameEvents.OnBrewSucceeded -= HandleBrewSucceeded; }

    private void Start() { StartNewOrder(); }

    private void StartNewOrder()
    {
        if (possibleOrders.Count == 0) return;

        currentOrder = possibleOrders[Random.Range(0, possibleOrders.Count)];
        GameEvents.TriggerOrderStarted(currentOrder);
    }

    private void HandleBrewSucceeded(PotionData potion)
    {
        if (currentOrder == null) return;
        if (potion != currentOrder.RequestedPotion) return;

        GameEvents.TriggerOrderCompleted(currentOrder);
        StartNewOrder();
    }
}