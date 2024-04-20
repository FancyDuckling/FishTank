using UnityEngine;

/// <summary>
/// Controls a fish GameObject with keyboard inputs using the WASD or arrow keys.
/// This script should be attached to a fish GameObject. It allows for smooth movement and rotation towards the direction of input.
/// Physics-based movement is used for consistency across different frame rates.
/// </summary>
public class PlayerControlledFishMover : MonoBehaviour
{
    [SerializeField,Tooltip("The fish move speed")] float speed = 5.0f; // The speed at which the fish moves.

    private Vector3 moveDirection = Vector3.zero; // Current movement direction.

    /// <summary>
    /// Update is called once per frame. It captures player input from the keyboard.
    /// </summary>
    void Update()
    {
        // Get input from WASD or arrow keys for horizontal and vertical movement.
        float horizontal = Input.GetAxis("Horizontal"); // Horizontal movement input.
        float vertical = Input.GetAxis("Vertical"); // Vertical movement input.

        // Calculate the new direction based on input, ignoring vertical (up/down) movement.
        moveDirection = new Vector3(horizontal, 0, vertical).normalized;
    }

    /// <summary>
    /// FixedUpdate is called at a consistent rate. It handles physics-based movement.
    /// </summary>
    void FixedUpdate()
    {
        // Execute movement based on the calculated direction and speed.
        transform.Translate(moveDirection * speed * Time.fixedDeltaTime, Space.World);

        // Rotate the fish to face the direction of movement, if there is any movement.
        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), 0.15f);
        }
    }
}
