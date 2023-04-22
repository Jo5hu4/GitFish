using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public float moveSpeed = 5.0f; // The speed at which the sprite moves towards the mouse cursor
    private Vector3 mousePosition; // The current mouse position
    private bool isFacingRight = true; // Whether the sprite is facing right

    private void Update()
    {
        // Get the current mouse position in world space
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z;

        // Move towards the mouse cursor
        transform.position = Vector3.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);

        // Determine the direction of movement and flip the sprite if necessary
        if ((isFacingRight && mousePosition.x < transform.position.x) ||
            (!isFacingRight && mousePosition.x > transform.position.x))
        {
            Flip();
        }
    }

    private void Flip()
    {
        // Flip the sprite horizontally
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
}
