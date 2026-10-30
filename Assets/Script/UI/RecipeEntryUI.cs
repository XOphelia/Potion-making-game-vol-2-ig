using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipeEntryUI : MonoBehaviour
{
    [SerializeField] private Image potionIcon;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text ingredientsText;

    public void Setup(RecipeData recipe, bool discovered)
    {
        if (!discovered)
        {
            potionIcon.sprite = recipe.ResultPotion.Icon;
            potionIcon.color = Color.black; // silhouette
            nameText.text = "???";
            ingredientsText.text = "???";
            return;
        }

        potionIcon.sprite = recipe.ResultPotion.Icon;
        potionIcon.color = Color.white;
        nameText.text = recipe.ResultPotion.DisplayName;

        List<string> names = new List<string>();
        foreach (IngredientData ingredient in recipe.RequiredIngredients)
        {
            names.Add(ingredient.DisplayName);
        }
        ingredientsText.text = string.Join(" + ", names);
    }
}