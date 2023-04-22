using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shark : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float distance = 5f;
    public float bobFrequency = 2f;
    public float bobAmplitude = 0.5f;
    public float maxTiltAngle = 20f;

    private Vector3 startPosition;
    private float moveDistance;
    private float bobOffset = 0f;

    private bool isMovingRight = true;

    private void Start()
    {
        startPosition = transform.position;
        moveDistance = distance;
    }

    private void Update()
    {
        // Update bob offset based on frequency and time
        bobOffset += Time.deltaTime * bobFrequency;

        if (isMovingRight)
        {
            // Move right
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

            if (transform.position.x >= startPosition.x + moveDistance)
            {
                // Flip sprite and start moving left
                isMovingRight = false;
                moveDistance = -distance;
                FlipSprite();
            }
        }
        else
        {
            // Move left
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

            if (transform.position.x <= startPosition.x + moveDistance)
            {
                // Flip sprite and start moving right
                isMovingRight = true;
                moveDistance = distance;
                FlipSprite();
            }
        }

        // Apply bobbing
        float bobHeight = Mathf.Sin(bobOffset) * bobAmplitude;
        transform.position = new Vector3(transform.position.x, startPosition.y + bobHeight, transform.position.z);

        // Apply tilting
        float tiltAngle = Mathf.Sin(bobOffset * 2f) * maxTiltAngle;
        transform.rotation = Quaternion.Euler(tiltAngle, 0f, 0f);
    }

    private void FlipSprite()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
