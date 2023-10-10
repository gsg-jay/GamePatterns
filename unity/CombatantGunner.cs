using UnityEngine;
using System;

namespace GSG
{
    public class CombatantGunner : CombatantBase
    {
        public event OnGunnerAimStart;
        public event OnGunnerAimExit;
        public event OnGunnerFireWeapon;
        public event OnGunnerReload;
        public event OnGunnerChargeWeapon;
        public event OnGunnerMaxWeaponChargeReached;
        public event OnGunnerChangeWeapon;
        }
    }
    