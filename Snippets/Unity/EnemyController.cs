using System;
using UnityEngine;

// TODO: Refactor the animation booleans to reflect the enemy's current state (_canPatrol, _canShoot, _canAttackMelee, etc.) 
public class EnemyController : MonoBehaviour
{
    public float PatrolSpeed = 2f;
    public float AttackRange = 3f;
    public float MeleeAttackDamage = 10f;
    public GameObject BulletLightPrefab;
    public GameObject BulletStrongPrefab;
    public GameObject BulletUltimatePrefab;
    public float BulletBasicSpeed = 5f;
    public float BulletStrongSpeed = 5f;
    public float BulletUltimateSpeed = 5f;
    public float rangedAttackCooldown = 6f;

    [SerializeField] private float _basicRangedAttackProbability = 0.5f;
    [SerializeField] private float _strongRangedAttackProbability = 0.88f;
    private Rigidbody2D _rb;
    private Transform _player;
    private float _lastRangedAttackTime;
    private Animator _animator;
    private _canMove = true;
    private _canShoot = true;
    private _canAttackMelee = true;

    
    #region Hooks
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player").transform; // Assuming _player tag is "Player"
        _lastRangedAttackTime = -rangedAttackCooldown; // So that the enemy can attack immediately when the game starts
    }
    void Update()
    {
        Patrol();
        TurnToFacePlayer();
        MeleeAttackWhenInRange();
        else
        {
            // Check if it's time to perform ranged attack
            if (Time.time - _lastRangedAttackTime >= rangedAttackCooldown)
            {
                // Perform ranged attack
                PerformRangedAttackGivenProbabilityIntervals(_basicRangedAttackProbability, _strongRangedAttackProbability);
                _lastRangedAttackTime = Time.time;
            }
        }
    }
    #endregion

    #region Actions
    void TurnToFacePlayer() {
        // Flip sprite to face player
        if (_player.position.x > transform.position.x) {
            transform.localScale = new Vector3(-1, 1, 1);
        } else {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    void Patrol()
    {
        // Implement patrol behavior here
        // For example, you could move the enemy back and forth between two points
        // Example:
        // _rb.velocity = new Vector2(PatrolSpeed, 0f);
        _animator.SetBool("isPatrolling", true);
    }
    private void MeleeAttackWhenInRange() {
        if (Vector2.Distance(transform.position.x, _player.position.x) <= AttackRange)
        {
            MeleeAttack();
        }
    }
    void MeleeAttack()
    {
        // Implement melee attack behavior here
        // For example, you could deal damage to the _player
        // Example:
        // _player.GetComponent<PlayerHealth>().TakeDamage(MeleeAttackDamage);
        _animator.SetBool("isAttackingMelee", true);
        _animator.SetBool("isShooting", false);
    }
    private void PerformRangedAttackGivenProbabilityIntervals(float basicRangedAttackProbability, float strongRangedAttackProbability){
        Math.Random(0, basicRangedAttackProbability) < basicRangedAttackProbability ? RangedAttackBasic() 
        : Random.Range(basicRangedAttackProbability < strongRangedAttackProbability) ? RangedAttackStrong() 
        : RangedAttackHeavy();
    }

    public virtual void RangedAttackBasic()
    {
        // Implement ranged attack behavior here
        // For example, you could instantiate a projectile and launch it towards the _player
        GameObject bullet = Instantiate(BulletLightPrefab, transform.position, Quaternion.identity);
        Vector2 direction = (_player.position - transform.position).normalized;
        bullet.GetComponent<Bullet>().Fire(direction);
    }
    public virtual void RangedAttackStrong()
    {
        // Implement ranged attack behavior here
        // For example, you could instantiate a bullet and launch it towards the _player
        GameObject bullet = Instantiate(BulletStrongPrefab, transform.position, Quaternion.identity);
        Vector2 direction = (_player.position - transform.position).normalized;
        bullet.GetComponent<Bullet>().Fire(direction);
    }
    public virtual void RangedAttackUltimate()
    {
        // Implement ranged attack behavior here
        // For example, you could instantiate a bullet and launch it towards the _player
        GameObject bullet = Instantiate(BulletUltimatePrefab, transform.position, Quaternion.identity);
        Vector2 direction = (_player.position - transform.position).normalized;
        bullet.GetComponent<Bullet>().Fire(direction);
    }
    #endregion
}
