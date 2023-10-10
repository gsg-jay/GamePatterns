using UnityEngine;
using UnityEngine.Events;
using System;

namespace GSG
{
    public class GameplayCamera : MonoBehaviour
    {
        public event OnCinematicCameraEnter;
        public event OnCinematicCameraExit;
        public event OnGameplayCameraEnter;
        public event OnGameplayCameraExit;
        }
    }