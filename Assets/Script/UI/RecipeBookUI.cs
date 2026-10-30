using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeBookUI : MonoBehaviour
{
    [SerializeField] private RecipeBook recipeBook;
    [SerializeField] private RecipeDiscovery discovery;
    [SerializeField] private RecipeEntryUI entryPrefab;
    [SerializeField] private Transform entriesContainer;
    [SerializeField] private GameObject openBookPanel;
    [SerializeField] private Button openButton;
    [SerializeField] private Button closeButton;

    private readonly List<RecipeEntryUI> entries = new List<RecipeEntryUI>();

    private void OnEnable()
    {
        GameEvents.OnRecipeDiscovered += HandleRecipeDiscovered;
        openButton.onClick.AddListener(Open);
        closeButton.onClick.AddListener(Close);
    }

    private void OnDisable()
    {
        GameEvents.OnRecipeDiscovered -= HandleRecipeDiscovered;
        openButton.onClick.RemoveListener(Open);
        closeButton.onClick.RemoveListener(Close);
    }

    private void Start()
    {
        foreach (RecipeData recipe in recipeBook.Recipes)
        {
            entries.Add(Instantiate(entryPrefab, entriesContainer));
        }
        Refresh();
        Close();
    }

    private void HandleRecipeDiscovered(PotionData potion) { Refresh(); }

    private void Refresh()
    {
        for (int i = 0; i < entries.Count; i++)
        {
            RecipeData recipe = recipeBook.Recipes[i];
            entries[i].Setup(recipe, discovery.IsDiscovered(recipe.ResultPotion));
        }
    }

    private void Open()
    {
        openBookPanel.SetActive(true);
        openButton.gameObject.SetActive(false);
    }

    private void Close()
    {
        openBookPanel.SetActive(false);
        openButton.gameObject.SetActive(true);
    }
}