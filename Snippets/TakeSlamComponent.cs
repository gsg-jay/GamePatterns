using UnityEngine;
using System;



namespace GSG {

  public class MainCamera : MonoBehaviour {
        // Get the main camera
        private Camera mainCamera; 
        private Vector2 _camMinBoundsXY;
        private Vector2 _camMaxBoundsXY;

        void Start() {
          mainCamera = Camera.main;
        }
    
        void Update() {
          CalculateCameraBounds();
        }
    
        private void CalculateCameraBounds() {
          // Get the size of the camera's viewport in world units
          float cameraHeight = 2f * mainCamera.orthographicSize;
          float cameraWidth = cameraHeight * mainCamera.aspect;
  
          // Get the position of the camera
          Vector3 cameraPosition = mainCamera.transform.position;

          // Calculate the bounds of the camera
          float cameraMinX = cameraPosition.x - cameraWidth / 2;
          float cameraMaxX = cameraPosition.x + cameraWidth / 2;
          float cameraMinY = cameraPosition.y - cameraHeight / 2;
          float cameraMaxY = cameraPosition.y + cameraHeight / 2;

          _camMinBoundsXY = new Vector2(cameraMinX, cameraMinY);
          _camMaxBoundsXY = new Vector2(cameraMaxX, cameraMaxY);
        }
        public Vector2 GetCameraMinBounds() {
          return _camMinBoundsXY;
        }
        public Vector2 GetCameraMaxBounds() {
          return _camMaxBoundsXY;
        }
  }
  
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
