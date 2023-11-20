using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
     public float moveSpeed = 5f;
    public Sprite[] walkUpFrames;
    public Sprite[] walkDownFrames;
    public Sprite[] walkLeftFrames;
    public Sprite[] walkRightFrames;

    private SpriteRenderer spriteRenderer;
    private int currentFrameIndex;
    private float animationTimer;
    private float animationInterval = 0.1f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
        Animate();
    }

    void Move()
{
    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");

    Vector3 movement = new Vector3(horizontalInput, verticalInput, 0).normalized;
    
    // Ensure movement is strictly horizontal or vertical
    if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
    {
        // Horizontal movement
        transform.position += new Vector3(movement.x * moveSpeed * Time.deltaTime, 0, 0);
    }
    else
    {
        // Vertical movement
        transform.position += new Vector3(0, movement.y * moveSpeed * Time.deltaTime, 0);
    }

    // Update animation direction based on movement
    if (movement != Vector3.zero)
    {
        UpdateAnimationDirection(horizontalInput, verticalInput);
    }
}

    void Animate()
    {
        // Check if enough time has passed to switch to the next frame
        animationTimer += Time.deltaTime;
        if (animationTimer >= animationInterval)
        {
            // Reset the timer
            animationTimer = 0f;

            // Switch to the next frame
            currentFrameIndex = (currentFrameIndex + 1) % walkDownFrames.Length;

            // Update the sprite based on the current direction
            UpdateSpriteBasedOnDirection();
        }
    }

    void UpdateAnimationDirection(float horizontalInput, float verticalInput)
    {
        // Determine the animation direction based on input
        if (Mathf.Abs(horizontalInput) > Mathf.Abs(verticalInput))
        {
            // Horizontal movement is more significant, prioritize it
            spriteRenderer.sprite = (horizontalInput > 0) ? walkRightFrames[currentFrameIndex] : walkLeftFrames[currentFrameIndex];
        }
        else
        {
            // Vertical movement is more significant, prioritize it
            spriteRenderer.sprite = (verticalInput > 0) ? walkUpFrames[currentFrameIndex] : walkDownFrames[currentFrameIndex];
        }
    }

    void UpdateSpriteBasedOnDirection()
    {
        // Update the sprite based on the current animation direction
        if (spriteRenderer.sprite == walkUpFrames[currentFrameIndex])
            spriteRenderer.sprite = walkUpFrames[currentFrameIndex];
        else if (spriteRenderer.sprite == walkDownFrames[currentFrameIndex])
            spriteRenderer.sprite = walkDownFrames[currentFrameIndex];
        else if (spriteRenderer.sprite == walkLeftFrames[currentFrameIndex])
            spriteRenderer.sprite = walkLeftFrames[currentFrameIndex];
        else if (spriteRenderer.sprite == walkRightFrames[currentFrameIndex])
            spriteRenderer.sprite = walkRightFrames[currentFrameIndex];
    }
}