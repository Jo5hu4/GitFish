using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{
    public float rotationSpeed = 10.0f; // The speed at which the sprite rotates when collided with
    private bool isColliding = false; // Flag to check if the sprite is currently colliding

    private void Update()
    {
        if (isColliding)
        {
            // Rotate the sprite around the z-axis
            transform.Rotate(0.0f, 0.0f, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with another sprite
        if (collision.gameObject.CompareTag("Sprite"))
        {
            // Set the isColliding flag to true
            isColliding = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the collision is with another sprite
        if (collision.gameObject.CompareTag("Sprite"))
        {
            // Set the isColliding flag to false
            isColliding = false;
        }
    }
}
