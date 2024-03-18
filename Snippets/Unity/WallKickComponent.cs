using UnityEngine;

public class WallKickComponent : MonoBehaviour
{
    public float kickForce = 10f;
    public float kickCooldown = 0.5f;

    private Rigidbody2D rb;
    private bool canKick = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check for wall-kick input
        if (Input.GetButtonDown("WallKick") && canKick)
        {
            Kick();
        }
    }

    void Kick()
    {
        // Check if the character is in contact with a wall (you might want to use more sophisticated collision detection)
        if (IsTouchingWall())
        {
            // Apply a force in the opposite direction of the wall normal
            Vector2 kickDirection = GetWallNormal() * -1;
            rb.AddForce(kickDirection * kickForce, ForceMode2D.Impulse);

            // Set kick cooldown
            canKick = false;
            Invoke("ResetKickCooldown", kickCooldown);
        }
    }

    bool IsTouchingWall()
    {
        // Implement your collision detection logic here
        // For example, you can use Raycasting or Collider detection to check if the character is touching a wall
        // Return true if touching a wall, false otherwise
        return false;
    }

    Vector2 GetWallNormal()
    {
        // Implement logic to get the normal vector of the wall
        // This can be obtained from the collision information or using Raycasting
        // Return the wall normal vector
        return Vector2.zero;
    }

    void ResetKickCooldown()
    {
        canKick = true;
    }
}
