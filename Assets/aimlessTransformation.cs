using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimlessTransformation : MonoBehaviour
{
  public float speed = 5.0f; // The speed at which the sprite moves
    public float minX = -5.0f; // The minimum x value of the random target positions
    public float maxX = 5.0f; // The maximum x value of the random target positions
    public float minY = -2.0f; // The minimum y value of the random target positions
    public float maxY = 2.0f; // The maximum y value of the random target positions
    private bool isFacingRight = false; // Whether the sprite is facing right
    private Vector3 targetPosition; // The target position for the sprite to move towards

    private void Start()
    {
        // Start by moving left
        targetPosition = new Vector3(minX, Random.Range(minY, maxY), transform.position.z);
        Flip();
    }

    private void Update()
    {
        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // If the sprite has reached the target position, choose a new target and flip
        if (transform.position == targetPosition)
        {
            if (isFacingRight)
            {
                targetPosition = new Vector3(Random.Range(minX, transform.position.x), Random.Range(minY, maxY), transform.position.z);
            }
            else
            {
                targetPosition = new Vector3(Random.Range(transform.position.x, maxX), Random.Range(minY, maxY), transform.position.z);
            }
            Flip();
        }
    }

    private void Flip()
    {
        // Flip the sprite horizontally
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
