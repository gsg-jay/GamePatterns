using UnityEngine;
using System;

namespace GSG
{
    public interface IDamageReceiver
    {
        public UnityEvent OnReceiveDamage;
        public UnityEvent OnRecoverDamage;
        public UnityEvent OnDamageChanged;

        void HandleReceiveDamage();
        void HandleRecoverDamage();
        void HandleDamageChanged();

    }
}