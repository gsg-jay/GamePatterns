using UnityEngine;
using UnityEngine.Events;
using System;

namespace GSG
{
    public interface ICharacterBase
    {
        public bool isGrabbable;
        public int health;
        public int maxHealth;
        public int speed;
        public int maxSpeed;
        public bool isDead;
    }
}
