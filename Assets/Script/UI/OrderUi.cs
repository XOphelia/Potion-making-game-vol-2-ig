using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrderUI : MonoBehaviour
{
    [SerializeField] private TMP_Text customerText;
    [SerializeField] private TMP_Text requestText;
    [SerializeField] private Image potionIcon;

    private void OnEnable() { GameEvents.OnOrderStarted += ShowOrder; }
    private void OnDisable() { GameEvents.OnOrderStarted -= ShowOrder; }

    private void ShowOrder(OrderData order)
    {
        customerText.text = order.CustomerName;
        requestText.text = "Je voudrais : " + order.RequestedPotion.DisplayName;
        potionIcon.sprite = order.RequestedPotion.Icon;
    }
}