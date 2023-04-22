using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUp : MonoBehaviour
{
    public float scaleTime = 1.0f;  // The amount of time it takes to scale up the sprite
    public float scaleSpeed = 1.0f; // The speed at which the sprite scales up
    private Vector3 originalScale;  // The sprite's original scale
    private bool isCollided = false; // Whether the sprite has collided with another sprite

    private void Start()
    {
        originalScale = transform.localScale; // Store the original scale
    }

    private void Update()
    {
        // Check if the sprite should be scaling up
        if (Input.GetMouseButtonDown(0) && isCollided)
        {
            // Start scaling up the sprite
            StartCoroutine(ScaleUpCoroutine());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the sprite collided with another sprite
        if (collision.gameObject.tag == "Sprite")
        {
            isCollided = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Reset the collided state if the other sprite exits the collision
        if (collision.gameObject.tag == "Sprite")
        {
            isCollided = false;
        }
    }

    private IEnumerator ScaleUpCoroutine()
    {
        float currentScale = 1.0f; // The current scale of the sprite
        while (currentScale < 2.0f)
        {
            // Increase the scale of the sprite based on the scale speed
            currentScale += scaleSpeed * Time.deltaTime;

            // Update the sprite's scale
            transform.localScale = originalScale * currentScale;

            yield return null;
        }

        // Set the final scale to twice the original size to ensure accuracy
        transform.localScale = originalScale * 2.0f;
    }
}
