using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Added to use the Image component
using DG.Tweening; // Added to use DoTween

#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// Class that provides functionality for the title screen.
/// </summary>
public class Title : MonoBehaviour
{
    [SerializeField]Image panel; // Attach the Image component of the Panel
    [SerializeField] private float fadeDuration = 0.5f; // Duration of the fade out effect, adjustable in the inspector

    private void Start()
    {
        // Ensure the panel is disabled at the start
        panel.gameObject.SetActive(false);
    }

    /// <summary>
    /// Transitions to the main game scene with a fade out effect.
    /// </summary>
    public void StartGame()
    {
        FadeOut(() => SceneManager.LoadScene("Vide"));
    }

    /// <summary>
    /// Transitions to the credits scene with a fade out effect.
    /// </summary>
    public void OpenCredits()
    {
        FadeOut(() => SceneManager.LoadScene("CreditScene"));
    }

    public void BackToTitle()
    {
        FadeOut(() => SceneManager.LoadScene("Title"));
    }

    /// <summary>
    /// Exits the game with a fade out effect.
    /// </summary>
    public void ExitGame()
    {
        FadeOut(() =>
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        });
    }

    /// <summary>
    /// Fades out the screen and calls the provided action after the animation.
    /// </summary>
    /// <param name="onComplete">Action to call after the fade out completes.</param>
    private void FadeOut(System.Action onComplete)
    {
        // Ensure the panel is visible before starting the fade
        panel.gameObject.SetActive(true);
        panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0); // Start from transparent
        panel.DOFade(1, fadeDuration) // Fade to opaque over specified duration
            .OnComplete(() => onComplete()); // Call onComplete after the animation completes
    }
}
