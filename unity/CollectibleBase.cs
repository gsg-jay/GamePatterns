using UnityEngine;
using UnityEngine.Events;
using System;

namespace GSG
{
    public class CollectibleBase : MonoBehaviour
    {
        public UnityEvent OnSpawned;
        public UnityEvent OnDestroyed;
        public UnityEvent OnCollected;
    }
}