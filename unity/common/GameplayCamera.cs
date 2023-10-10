using UnityEngine;
using UnityEngine.Events;
using System;

namespace GSG
{
    public class GameplayCamera : MonoBehaviour
    {
        public UnityEvent OnCinematicCameraEnter;
        public UnityEvent OnCinematicCameraExit;
        public UnityEvent OnGameplayCameraEnter;
        public UnityEvent OnCameraPerspectiveChanged;
        public UnityEvent OnGameplayCameraExit;
    }
}