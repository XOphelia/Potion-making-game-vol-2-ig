using System.Collections.Generic;
using UnityEngine;

public class RecipeDiscovery : MonoBehaviour
{
    private readonly HashSet<PotionData> discovered = new HashSet<PotionData>();

    private void OnEnable() { GameEvents.OnBrewSucceeded += HandleBrewSucceeded; }
    private void OnDisable() { GameEvents.OnBrewSucceeded -= HandleBrewSucceeded; }

    public bool IsDiscovered(PotionData potion)
    {
        return discovered.Contains(potion);
    }

    private void HandleBrewSucceeded(PotionData potion)
    {
        
        if (discovered.Add(potion))
        {
            GameEvents.TriggerRecipeDiscovered(potion);
        }
    }
}