using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
  public float followSpeed = 5.0f; // The speed at which the fish follows the mouse
    public float lagTime = 0.2f; // The amount of lag time between the mouse and the fish
    private Vector3 mousePosition; // The current mouse position
    private Vector3 targetPosition; // The target position for the fish to move towards
    private bool isFacingRight = true; // Whether the fish is facing right

    private void Update()
    {
        // Get the current mouse position in world space
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z;

        // Calculate the target position with a lag
        targetPosition = Vector3.Lerp(targetPosition, mousePosition, followSpeed * Time.deltaTime / lagTime);

        // Update the fish's position to move towards the target position
        transform.position = targetPosition;

        // Determine the direction of movement and flip the fish sprite if necessary
        if ((isFacingRight && targetPosition.x < transform.position.x) ||
            (!isFacingRight && targetPosition.x > transform.position.x))
        {
            Flip();
        }

        // Offset the mouse position to be at the end of the fish sprite
        Vector3 mouseOffset = transform.right * (GetComponent<SpriteRenderer>().bounds.size.x / 2.0f);
        mousePosition -= mouseOffset;

        // Rotate the fish to face the direction of movement
        Vector3 direction = targetPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void Flip()
    {
        // Flip the fish horizontally
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
}
