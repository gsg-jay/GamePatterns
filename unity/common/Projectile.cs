using UnityEngine;
using UnityEngine.Events;
using System;

namespace GSG
{
    public class Projectile : MonoBehaviour
    {
        public UnityEvent OnProjectileSpawned;
        public UnityEvent OnProjectileCollided;

        void Start()
        {
            OnProjectileSpawned?.Invoke();
        }
        void OnCollisionEnter(Collider other)
        {
            throw new NotImplementedException("Projectile collision code not implemented");
        }
    }

}