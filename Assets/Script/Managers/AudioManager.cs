using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioClip ingredientAddedClip;
    [SerializeField] private AudioClip brewSuccessClip;
    [SerializeField] private AudioClip brewFailClip;
    [SerializeField] private AudioClip orderCompletedClip;
    [SerializeField] private AudioClip musicClip;

    private void OnEnable()
    {
        GameEvents.OnIngredientAddedToCauldron += HandleIngredientAdded;
        GameEvents.OnBrewSucceeded += HandleBrewSucceeded;
        GameEvents.OnBrewFailed += HandleBrewFailed;
        GameEvents.OnOrderCompleted += HandleOrderCompleted;
    }

    private void OnDisable()
    {
        GameEvents.OnIngredientAddedToCauldron -= HandleIngredientAdded;
        GameEvents.OnBrewSucceeded -= HandleBrewSucceeded;
        GameEvents.OnBrewFailed -= HandleBrewFailed;
        GameEvents.OnOrderCompleted -= HandleOrderCompleted;
    }

private void Start()
{
    musicSource.clip = musicClip;
    musicSource.loop = true;
    musicSource.Play();
}
    private void HandleIngredientAdded(IngredientData ingredient) { Play(ingredientAddedClip); }
    private void HandleBrewSucceeded(PotionData potion) { Play(brewSuccessClip); }
    private void HandleBrewFailed() { Play(brewFailClip); }
    private void HandleOrderCompleted(OrderData order) { Play(orderCompletedClip); }

    private void Play(AudioClip clip)
    {
        if (clip != null) sfxSource.PlayOneShot(clip);
    }
}