using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ScriptedFishMovement : MonoBehaviour
{
    [SerializeField, Tooltip("The fish move speed")] float speed = 5.0f; // The speed at which the fish moves.

    private Vector3 moveDirection = Vector3.zero; // Current movement direction.

    private void Start()
    {
        MoveToGoal();
    }
    /// <summary>
    /// Update is called once per frame. It captures player input from the keyboard.
    /// </summary>
    void MoveToGoal()
    {
        float X = Random.Range(1, 7.4f);
        float Y = Random.Range(0.73f, 8.63f);
        float Z = Random.Range(-7, 7);
        // Calculate the new direction based on input, ignoring vertical (up/down) movement.
        Debug.Log(X);
        Debug.Log(Y);
        Debug.Log(Z);
        moveDirection = new Vector3(X, Y, Z);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), 0.15f);
    }

    /// <summary>
    /// FixedUpdate is called at a consistent rate. It handles physics-based movement.
    /// </summary>
    void FixedUpdate()
    {
        // MAX Y, MIN Y : 8.63 , 0.73 
        // MAX X, MIN X : 7.4 , 1
        // MAX Z, MIN Z : 7 , -7
        // Execute movement based on the calculated direction and speed.
        Vector3 movement = moveDirection;
        //* Time.fixedDeltaTime;
        //Mathf.Clamp(movement.x, 1, 7.4f);
        //Mathf.Clamp(movement.y, 0.73f, 8.63f);
        //Mathf.Clamp(movement.z, -7, 7);
        transform.position = Vector3.MoveTowards(transform.position, movement, speed * Time.fixedDeltaTime);
        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, movement) < 0.001f)
        {
            MoveToGoal();
        } 
        // Rotate the fish to face the direction of movement, if there is any movement.
       
    }
}
