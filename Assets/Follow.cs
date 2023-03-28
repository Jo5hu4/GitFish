using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public float speed = 10f;

    private Vector3 targetPosition;
    private bool facingRight = true;

    void Update()
    {
        // Get the current mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        // Set the target position to the mouse position
        targetPosition = mousePosition;

        // Move the sprite towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Flip the sprite if necessary
        if ((targetPosition.x > transform.position.x && !facingRight) ||
            (targetPosition.x < transform.position.x && facingRight))
        {
            Flip();
        }
    }

    void Flip()
    {
        // Switch the direction the sprite is facing
        facingRight = !facingRight;

        // Flip the sprite by scaling its x-axis by -1
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }







}
