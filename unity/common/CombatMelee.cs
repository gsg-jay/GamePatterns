using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GSG
{
    public class CombatMelee : MonoBehaviour
    {
        public List<Hitbox> activeHitbox = new List<Hitbox>();
        public UnityEvent OnAttackEnabledEnter;
        public UnityEvent OnAttackEnabledExit;
        public UnityEvent OnDefendEnabledEnter;
        public UnityEvent OnDefendEnabledExit;
        public UnityEvent OnAttackDisabledEnter;
        public UnityEvent OnAttackDisabledExit;
        public UnityEvent OnAttackEnter;
        public UnityEvent OnAttackExit;
        public UnityEvent OnAttackNextComboMoveEnter;
        public UnityEvent OnAttackNextComboMoveExit;
        public UnityEvent OnDefendEnter;
        public UnityEvent OnDefendExit;
        public UnityEvent OnDefendStateActiveEnter;
        public UnityEvent OnDefendStateActiveExit;
        public UnityEvent OnAttackChargeStateEnter;
        public UnityEvent OnAttackChargeStateExit;
        public UnityEvent OnCooldownActiveEnter;
        public UnityEvent OnCooldownActiveExit;
        public UnityEvent OnHitboxActiveEnter;
        public UnityEvent OnHitboxActiveExit;
        public UnityEvent OnHurtboxActiveEnter;
        public UnityEvent OnHurtboxActiveExit;
        public UnityEvent OnThrowboxActiveEnter;
        public UnityEvent OnThrowboxActiveExit;
        public UnityEvent OnAerialStateEnter;
        public UnityEvent OnAerialStateExit;
        public UnityEvent OnGroundedStateEnter;
        public UnityEvent OnGroundedStateExit;
        public UnityEvent OnInvincibleStateEnter;
        public UnityEvent OnInvincibleStateExit;
    }
}