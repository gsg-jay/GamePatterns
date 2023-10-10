using UnityEngine;
using UnityEngine.Events;
using System;

namespace GSG
{
    public class GameEntityBase : MonoBehaviour, IDamageReceiver
    {
        public enum ENTITY_STATE
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
        bool _isDead = false;

        public bool SetIsDead(bool newValue)
        {
            return _isDead = newValue;
        }
    }
}