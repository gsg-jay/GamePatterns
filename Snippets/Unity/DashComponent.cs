using UnityEngine;

public class DashComponent : MonoBehaviour
{
    public float dashForce = 10f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;

    private Rigidbody2D rb;
    private bool canDash = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check for dash input
        if (Input.GetButtonDown("Dash") && canDash)
        {
            DoDash();
        }
    }

    void DoDash()
    {
        // Apply a force in the direction of the character's movement
        Vector2 dashDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        rb.AddForce(dashDirection * dashForce, ForceMode2D.Impulse);

        // Disable dashing temporarily
        canDash = false;
        Invoke("ResetDashCooldown", dashCooldown);
    }

    void ResetDashCooldown()
    {
        canDash = true;
    }
}
