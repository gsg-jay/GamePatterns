using UnityEngine;
using UnityEngine.Events;
using System;

namespace GSG
{
    public interface IDestructible
    {
        public UnityEvent OnDestroyed;
        public void HandleDestroyed();
        public void HandleDestructionStart();
        public void HandleDestructionExit();
    }
}