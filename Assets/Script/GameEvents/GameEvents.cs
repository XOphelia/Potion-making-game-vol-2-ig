using System;

public static class GameEvents
{
    public static event Action OnInventoryChanged;
    public static event Action<IngredientData> OnIngredientAddedToCauldron;
    public static event Action OnCauldronCleared;
    public static event Action<PotionData> OnBrewSucceeded;
    public static event Action OnBrewFailed;
    public static event Action<OrderData> OnOrderStarted;
    public static event Action<OrderData> OnOrderCompleted;
    public static event Action<int> OnScoreChanged;
    public static event Action<PotionData> OnRecipeDiscovered;

    public static void TriggerInventoryChanged() { OnInventoryChanged?.Invoke(); }
    public static void TriggerIngredientAddedToCauldron(IngredientData ingredient) { OnIngredientAddedToCauldron?.Invoke(ingredient); }
    public static void TriggerCauldronCleared() { OnCauldronCleared?.Invoke(); }
    public static void TriggerBrewSucceeded(PotionData potion) { OnBrewSucceeded?.Invoke(potion); }
    public static void TriggerBrewFailed() { OnBrewFailed?.Invoke(); }
    public static void TriggerOrderStarted(OrderData order) { OnOrderStarted?.Invoke(order); }
    public static void TriggerOrderCompleted(OrderData order) { OnOrderCompleted?.Invoke(order); }
    public static void TriggerScoreChanged(int totalScore) { OnScoreChanged?.Invoke(totalScore); }
    public static void TriggerRecipeDiscovered(PotionData potion) { OnRecipeDiscovered?.Invoke(potion); }
}