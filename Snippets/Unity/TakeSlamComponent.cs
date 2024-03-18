using UnityEngine;
using System;

namespace GSG {
  
  public class TakeSlamComponent : MonoBehaviour {
    private Animator _animator;
    private Bot _bot;
    private bool _isTakingThrow;
    private PlayableCharacter _playableCharacter;
    private MainCamera _mainCamera;

    void Start() {
      _camera = FindObjectOfType<MainCamera>();
      _animator = GetComponent<Animator>();
      _bot = GetComponent<Bot>();
      _playableCharacter = GetComponent<PlayableCharacter>();
    }

    void Update() {
      if (IsTakingThrow){
        CheckForWallBounce();
      }
    }
    
    public void TakeThrowBegin(Transform target) {
      gameObject.transform.SetParent(target);
      var recipient = _bot || _playable;
        recipient.SuspendControl();
        recipient.Play("TakeThrow");
    }

    public void GroundBounce() {
      var recipient = _bot || _playable;
      var direction = recipient.GetDirection();
      var bounceForce = direction == "left" 
          ? new Vector2(5,3);
          : new Vector2(-5,3);
      recipient.GetComponent<Rigidbody>().AddForce(bounceForce, ForceMode.Impulse);
    }

    private void CheckForWallBounce() {
      var recipient = _bot || _playable;
      var rigidbody = recipient.GetComponent<Rigidbody>();
      var direction = recipient.GetDirection();
      if (transform.position.x < _mainCamera.GetCameraMinBounds().x) {
          var bounceForce = new Vector2(5, -2);
          rigidbody.velocity = new Vector3(0, rigidbody.velocity.y);
          recipient.GetComponent<Rigidbody>().AddForce(bounceForce, ForceMode.Impulse);
          return;
      }
      if (transform.position.x > _mainCamera.GetCameraMaxBounds().x) {
          var bounceForce = new Vector2(-5, -2);
          rigidbody.velocity = new Vector3(0, rigidbody.velocity.y);
          recipient.GetComponent<Rigidbody>().AddForce(bounceForce, ForceMode.Impulse);
          return;
      }
    }
    
    public void TakeThrowEnd(Transform target) {
      gameObject.transform.SetParent(null);
      _animator.Play("Knockdown");
    }
    
    public void TakeDamageFromSlam(int damage) {
      var recipient = _bot || _playable; 
      recipient.TakeDamage(damage);
    }                  
  }
}
