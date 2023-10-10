using UnityEngine;
using UnityEngine.Events;
using System;

namespace GSG
{
    public class ImpactEffect : MonoBehaviour
    {
        public int timeToLiveMs // -1 = Exist indefinitely
        public AudioClip impactAudioClip;
        public GameObject impactPrefab;

        void Start()
        {
            if (timeToLiveMs <= -1) return;
            Destroy(timeToLiveMs);
        }
        void OnCollisionEnter(Collider other)
        {
            throw new NotImplementedException("Projectile collision code not implemented");
        }
    }

}
