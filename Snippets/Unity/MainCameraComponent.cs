using UnityEngine;
using System;

namespace GSG {

  public class MainCameraComponent : MonoBehaviour {
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
}
