using UnityEngine;
using System.Collections;

public class MovementBehavior : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 10.0f;
    public float dashSpeed = 0.5f;
    public float dashDuration = 0.2f;
    private Vector3 targetPosition;
    private bool isMoving = false;
    private bool isDashing = false;
    private Animator animator;
    private Rigidbody rb; // Add Rigidbody reference
    public float dashCooldown = 5.0f;  // Dash cooldown in seconds
    public ChangeColor dashCooldownChangeColor;
    private float nextDashTime = 0.0f;  // When the next dash is allowed
    public CooldownTimer dashTextTimer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>(); // Initialize Rigidbody reference
    }

    void Update()
    {
        if (isMoving && !isDashing)
        {
            float step = speed * Time.deltaTime;

            // Make the object face towards the target position
            Vector3 directionToFace = targetPosition - transform.position;
            directionToFace.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(directionToFace);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            // Move towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
                animator.SetBool("Walk", false);
            }
        }
    }

    public void MoveToPosition(Vector3 newPosition)
    {
        targetPosition = newPosition;
        isMoving = true;
        animator.SetBool("Walk", true);
    }

    public void DashTo(Vector3 newPosition)
    {
        if (Time.time >= nextDashTime && !isDashing)
        {
            StartCoroutine(PerformDash(newPosition));
            nextDashTime = Time.time + dashCooldown;
            dashCooldownChangeColor.swapColor(); // Change to cooldown color

            dashTextTimer.StartCountDown(dashCooldown);
            // Start the cooldown coroutine
            StartCoroutine(CooldownTimer());
        }
    }

    IEnumerator PerformDash(Vector3 newPosition)
    {
        isDashing = true;
        Vector3 dashDirection = (newPosition - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(dashDirection);
        rb.AddForce(dashDirection * dashSpeed, ForceMode.Impulse);
        yield return new WaitForSeconds(dashDuration);
        StopDash(dashDirection);
    }

    IEnumerator CooldownTimer()
    {
        // Wait for the cooldown period to expire
        yield return new WaitForSeconds(dashCooldown);

        // Reset the color (or any other action) when the cooldown is up
        dashCooldownChangeColor.resetColor(); // Assume you have a method to reset color
    }
    void StopDash(Vector3 facingDirection)
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        facingDirection.y = 0;  // Keeps the penguin upright
        transform.rotation = Quaternion.LookRotation(facingDirection);
        isDashing = false;
        Stop();
    }
    public void Stop()
    {
        isMoving = false;
        animator.SetBool("Walk", false);
    }
}
