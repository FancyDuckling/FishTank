using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the life system for a character, such as a fish, in a game.
/// This class controls the display and management of lives using UI images,
/// decrementing life count upon damage, and handling game over conditions.
/// </summary>
public class LifeSystem : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Array of Image objects representing each life visually.")]
    private Image[] lives; // Array of Image objects for visual representation of lives

    [SerializeField]
    [Tooltip("Current number of lives remaining.")]
    private int currentLives; // Current count of remaining lives

    /// <summary>
    /// Initializes life count based on the number of assigned life images.
    /// </summary>
    void Start()
    {
        // Set the initial number of lives to the length of the lives array
        currentLives = lives.Length;
    }

    /// <summary>
    /// Reduces the number of lives by one when called, typically in response to damage.
    /// Disables the rightmost active life image. Triggers game over logic if lives reach zero.
    /// </summary>
    public void TakeDamage()
    {
        if (currentLives <= 0) return; // Do nothing if no lives are left

        // Decrement the life count
        currentLives--;
        // Disable the corresponding life image
        lives[currentLives].enabled = false;

        // Check for game over condition
        if (currentLives == 0)
        {
            GameOver();
        }
    }

    /// <summary>
    /// Handles game over logic. This method can be expanded to include additional game over procedures.
    /// </summary>
    void GameOver()
    {
        Debug.Log("Game Over!");
        // Implement game over screen display or other game over behavior here
    }
}
