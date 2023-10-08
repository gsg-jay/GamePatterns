using Godot;
using System;

namespace GSG
{
    public class Combatant
    {
        public event OnAttackEnabledEnter;
        public event OnAttackEnabledExit;
        public event OnDefendEnabledEnter;
        public event OnDefendEnabledExit;
        public event OnAttackDisabledEnter;
        public event OnAttackDisabledExit;
        public event OnAttackEnter;
        public event OnAttackExit;
        public event OnAttackNextComboMoveEnter;
        public event OnAttackNextComboMoveExit;
        public event OnDefendEnter;
        public event OnDefendExit;
        public event OnDefendStateActiveEnter;
        public event OnDefendStateActiveExit;
        public event OnAttackChargeStateEnter;
        public event OnAttackChargeStateExit;
        public event OnCooldownActiveEnter;
        public event OnCooldownActiveExit;
        public event OnHitboxActiveEnter;
        public event OnHitboxActiveExit;
        public event OnHurtboxActiveEnter;
        public event OnHurtboxActiveExit;
        public event OnThrowboxActiveEnter;
        public event OnThrowboxActiveExit;
        public event OnAerialStateEnter;
        public event OnAerialStateExit;
        public event OnGroundedStateEnter;
        public event OnGroundedStateExit;
        public event OnInvincibleStateEnter;
        public event OnInvincibleStateExit;
        }
    }