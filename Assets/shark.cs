using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shark : MonoBehaviour
{
    public float speed = 5.0f; // speed of movement
    public float distance = 2.0f; // distance to move before flipping
    public float amplitude = 0.5f; // amplitude of the bobbing motion
    public float frequency = 1.0f; // frequency of the bobbing motion
    private Vector2 startPosition; // starting position of the sprite
    private Vector2 targetPosition; // target position of the sprite
    private bool isMovingRight = true; // flag to track movement direction

    void Start()
    {
        startPosition = transform.position;
        targetPosition = new Vector2(startPosition.x + distance, startPosition.y);
    }

    void Update()
    {
        // calculate vertical offset based on time and frequency
        float yOffset = Mathf.Sin(Time.time * frequency) * amplitude;

        // apply vertical offset to sprite's position
        transform.position = new Vector2(transform.position.x, startPosition.y + yOffset);

        if (isMovingRight)
        {
            // move sprite right
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            // if sprite reaches target position, flip its orientation and start moving left
            if (transform.position.x >= targetPosition.x)
            {
                transform.position = new Vector2(targetPosition.x, startPosition.y + yOffset);
                isMovingRight = false;
                FlipSprite();
            }
        }
        else
        {
            // move sprite left
            transform.Translate(Vector2.left * speed * Time.deltaTime);

            // if sprite reaches original position, flip its orientation and start moving right
            if (transform.position.x <= startPosition.x)
            {
                transform.position = new Vector2(startPosition.x, startPosition.y + yOffset);
                isMovingRight = true;
                FlipSprite();
            }
        }
    }

    void FlipSprite()
    {
        // flip sprite horizontally
        Vector3 scale = transform.localScale;
        scale.x = -scale.x;
        transform.localScale = scale;
    }
}
