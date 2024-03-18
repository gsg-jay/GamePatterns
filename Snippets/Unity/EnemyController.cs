using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float patrolSpeed = 2f;
    public float attackRange = 3f;
    public float meleeAttackDamage = 10f;
    public GameObject projectilePrefab;
    public float projectileSpeed = 5f;
    public float rangedAttackCooldown = 6f;

    private Rigidbody2D rb;
    private Transform player;
    private float lastRangedAttackTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform; // Assuming player tag is "Player"
        lastRangedAttackTime = -rangedAttackCooldown; // So that the enemy can attack immediately when the game starts
    }

    void Update()
    {
        Patrol();

        // Check if player is in attack range
        if (Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            // Perform melee attack
            MeleeAttack();
        }
        else
        {
            // Check if it's time to perform ranged attack
            if (Time.time - lastRangedAttackTime >= rangedAttackCooldown)
            {
                // Perform ranged attack
                RangedAttack();
                lastRangedAttackTime = Time.time;
            }
        }
    }

    void Patrol()
    {
        // Implement patrol behavior here
        // For example, you could move the enemy back and forth between two points
        // Example:
        // rb.velocity = new Vector2(patrolSpeed, 0f);
    }

    void MeleeAttack()
    {
        // Implement melee attack behavior here
        // For example, you could deal damage to the player
        // Example:
        // player.GetComponent<PlayerHealth>().TakeDamage(meleeAttackDamage);
    }

    void RangedAttack()
    {
        // Implement ranged attack behavior here
        // For example, you could instantiate a projectile and launch it towards the player
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Vector2 direction = (player.position - transform.position).normalized;
        projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
    }
}
