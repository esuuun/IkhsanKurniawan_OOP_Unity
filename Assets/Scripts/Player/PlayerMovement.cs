using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Vector2 maxSpeed;
    [SerializeField] Vector2 timeToFullSpeed;
    [SerializeField] Vector2 timeToStop;
    [SerializeField] Vector2 stopClamp;

    private Vector2 moveDirection;
    private Vector2 moveVelocity;
    private Vector2 moveFriction;
    private Vector2 stopFriction;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true; // Prevent rotation

        // Calculate initial acceleration and friction values
        moveVelocity = 2 * maxSpeed / timeToFullSpeed;
        moveFriction = -2 * maxSpeed / (timeToFullSpeed * timeToFullSpeed);
        stopFriction = -2 * maxSpeed / (timeToStop * timeToStop);
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        // Capture input for movement
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        if (moveDirection != Vector2.zero)
        {
            // Gradually increase velocity towards max speed
            Vector2 targetVelocity = moveDirection * maxSpeed;
            rb.velocity = Vector2.MoveTowards(rb.velocity, targetVelocity, moveVelocity.magnitude * Time.deltaTime);
        }
        else
        {
            // Apply friction to gradually slow down the player
            Vector2 frictionForce = GetFriction();
            rb.velocity = Vector2.MoveTowards(rb.velocity, Vector2.zero, frictionForce.magnitude * Time.deltaTime);

            // Stop movement if velocity is very low to avoid sliding
            if (rb.velocity.magnitude < stopClamp.magnitude)
            {
                rb.velocity = Vector2.zero;
            }
        }

        // Clamp the velocity separately on each axis to avoid excessive speed
        rb.velocity = new Vector2(
            Mathf.Clamp(rb.velocity.x, -maxSpeed.x, maxSpeed.x),
            Mathf.Clamp(rb.velocity.y, -maxSpeed.y, maxSpeed.y)
        );
    }

    public Vector2 GetFriction()
    {
        // If there's input (player is moving), use moveFriction to slow down movement
        if (moveDirection != Vector2.zero)
        {
            return new Vector2(
                moveDirection.x != 0 ? moveFriction.x : 0,
                moveDirection.y != 0 ? moveFriction.y : 0
            );
        }
        else // If there's no input, use stopFriction to bring the player to a stop
        {
            return new Vector2(
                rb.velocity.x != 0 ? stopFriction.x : 0,
                rb.velocity.y != 0 ? stopFriction.y : 0
            );
        }
    }

    public void MoveBound()
    {
        // Implement boundary conditions if necessary
    }

    public bool IsMoving()
    {
        return rb.velocity != Vector2.zero;
    }

    void LateUpdate()
    {
        LimitMovementToCamera();
    }

    private void LimitMovementToCamera()
    {
        Vector3 position = transform.position;
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(position);

        viewportPosition.x = Mathf.Clamp(viewportPosition.x, 0.01f, 0.99f);
        viewportPosition.y = Mathf.Clamp(viewportPosition.y, 0.0f, 0.95f); // Limit top movement

        transform.position = Camera.main.ViewportToWorldPoint(viewportPosition);
    }
}
