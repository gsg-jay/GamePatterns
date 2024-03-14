using UnityEngine;

namespace GSG {
  public class PlayerStateMachine : MonoBehaviour
  {
      private Animator _animator;
      private Rigidbody2D _rb;

      private PlayerState _currentState;
  
      // Define states
      public enum PlayerState
      {
          Idle,
          Running,
          Jumping,
          Falling,
          Attacking_01,
          Attacking_02,
          Attacking_03,
          Attacking_04,
          // Add more states as needed
      }
  
      void Start()
      {
          _animator = GetComponent<Animator>();
          _rb = GetComponent<Rigidbody2D>();
  
          // Set initial state
          ChangeState(PlayerState.Idle);
      }
  
      void Update()
      {
          // Check for state transitions
          var isAtacking = 
            
          var isAirborneAndNotAttacking = !_isGrounded && !isAttacking;
          var isFalling = _rb.velocity.y < -0.1f;
          var isRising = _rb.velocity.y > 0.1f;
          var hasHorizontalSpeed = Mathf.Abs(_rb.velocity.x) > 0.1f;
          
          else if (isAirborneAndNotAttacking && isRising)
          {
              ChangeState(PlayerState.Jumping);
          }
          else if (isAirborneAndNotAttacking && isFalling)
          {
              ChangeState(PlayerState.Falling);
          }
          else if (hasHorizontalSpeed)
          {
              ChangeState(PlayerState.Running);
          }
          else
          {
              ChangeState(PlayerState.Idle);
          }
  
          // Handle player input to trigger attacks, etc.
          // Neutral + Attack
          if (!hasHorizontalSpeed && Input.GetKeyDown(KeyCode.LeftControl))
          {
              ChangeState(PlayerState.Attacking_01);
          }
          // Attack
          if (!hasHorizontalSpeed && Input.GetKeyDown(KeyCode.Up) Input.GetKeyDown(KeyCode.LeftControl))
          {
              ChangeState(PlayerState.Attacking_01);
          }
      }
  
      // Change state and trigger animations accordingly
      private void ChangeState(PlayerState newState)
      {
          if (newState != currentState)
          {
              currentState = newState;
  
              // Trigger animations based on state
              switch (currentState)
              {
                  case PlayerState.Idle:
                      animator.Play("Idle");
                      break;
                  case PlayerState.Running:
                      animator.Play("Run");
                      break;
                  case PlayerState.Jumping:
                      animator.Play("Jump");
                      break;
                  case PlayerState.Falling:
                      animator.Play("Fall");
                      break;
                  case PlayerState.Attacking:
                      animator.Play("Attack");
                      break;
                  // Add more cases as needed
                  default:
                      break;
              }
          }
      }
  }
}
