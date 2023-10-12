using UnityEngine;
using System;

namespace GSG
{
    public class CombatGunner : MonoBehaviour
    {
        public UnityEvent OnGunnerAimStart;
        public UnityEvent OnGunnerAimExit;
        public UnityEvent OnGunnerFireWeapon;
        public UnityEvent OnGunnerReload;
        public UnityEvent OnGunnerChargeWeapon;
        public UnityEvent OnGunnerMaxWeaponChargeReached;
        public UnityEvent OnGunnerChangeWeapon;
    }
}
