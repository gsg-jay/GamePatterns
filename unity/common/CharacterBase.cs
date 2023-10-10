using UnityEngine;
using UnityEngine.Events;
using System;

namespace GSG
{
    public class CharacterBase : MonoBehaviour, IDamageReceiver
    {
        public enum CHARACTER_STATE
        {
            IDLE,
            AGGRESSION_IN_CONTEXT,
            RETREAT,
            DEFEND,
            CHASE,
            SEEK_ADVANTAGE,
        }
        public int health;
        public int maxHealth;
        public int speed;
        public int maxSpeed;
        public bool isDead = false;
    }
}
