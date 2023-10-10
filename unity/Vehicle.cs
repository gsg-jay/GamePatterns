using UnityEngine;
using UnityEngine.Events;
using System;

namespace GSG
{
    public class Vehicle : MonoBehaviour, Destructible
    {
        public int maxSpeed { get; set; };
        public bool canBoost { get; set; };
        public bool isBoosting { get; set; };
        public UnityEvent OnBrakeStart;
        public UnityEvent OnBrakeExit;
        public UnityEvent OnBoostStart;
        public UnityEvent OnBoostExit;
        public UnityEvent OnAccelerationStart;
        public UnityEvent OnAccelerationExit;
        public UnityEvent OnPilotEnter;
        public UnityEvent OnPilotExit;

        public void Move()
        {
            throw new NotImplementedException("Vehicle::Move not implemented");
        }
        public void Turn()
        {
            throw new NotImplementedException("Vehicle::Turn not implemented");
        }
        public bool IsBoostReady()
        {
            return canBoost;
        }
        public void ToggleBoost()
        {
            isBoosting = !isBoosting;
            throw new NotImplementedException("VehicleFlying boost not implemented");
        }
    }
}