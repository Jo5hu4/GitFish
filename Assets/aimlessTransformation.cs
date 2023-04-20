using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimlessTransformation : MonoBehaviour
{
    public float wanderSpeed = 1.0f; // The speed at which the sprite wanders
    public float wanderDistance = 5.0f; // The maximum distance the sprite can wander from its starting position
    private Vector3 startPosition; // The starting position of the sprite
    private Vector3 targetPosition; // The target position for the sprite to wander to

    private void Start()
    {
        // Set the starting position
        startPosition = transform.position;

        // Set a random target position within the wander distance
        targetPosition = startPosition + new Vector3(Random.Range(-wanderDistance, wanderDistance), Random.Range(-wanderDistance, wanderDistance), 0.0f);
    }

    private void Update()
    {
        // Move the sprite towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, wanderSpeed * Time.deltaTime);

        // If the sprite has reached the target position, set a new target position
        if (transform.position == targetPosition)
        {
            // Set a random target position within the wander distance
            targetPosition = startPosition + new Vector3(Random.Range(-wanderDistance, wanderDistance), Random.Range(-wanderDistance, wanderDistance), 0.0f);
        }
    }
}
