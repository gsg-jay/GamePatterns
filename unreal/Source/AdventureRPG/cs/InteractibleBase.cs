using UnityEngine;
using UnityEngine.Events;
using System;

namespace GSG
{
    public class InteractibleBase : MonoBehaviour
    {
        public string currentState;
        public UnityEvent OnInteraction;
    }
}