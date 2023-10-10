using UnityEngine;
using UnityEngine.Events;
using System;

namespace GSG
{
    public interface ICharacterBase
    {
        public int health;
        public int maxHealth;
        public int speed;
        public int maxSpeed;
        public bool isDead;
    }
}
