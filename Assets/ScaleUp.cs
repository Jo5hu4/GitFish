using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUp : MonoBehaviour
{
   public float scaleTime = 1.0f; // The amount of time it takes to scale up the sprite
    private Vector3 originalScale; // The sprite's original scale
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
        float currentTime = 0.0f; // The current time
        while (currentTime < scaleTime)
        {
            // Calculate the new scale based on the current time
            float t = currentTime / scaleTime;
            Vector3 newScale = Vector3.Lerp(originalScale, originalScale * 2.0f, t);

            // Update the sprite's scale
            transform.localScale = newScale;

            // Increase the current time
            currentTime += Time.deltaTime;

            yield return null;
        }

        // Set the final scale to twice the original size to ensure accuracy
        transform.localScale = originalScale * 2.0f;
    }
}
