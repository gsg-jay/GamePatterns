using UnityEngine;
using UnityEngine.Events;
using System;

namespace GSG
{
    public class HealthGauge : ResourceGauge
    {
        void Start()
        {
            this.resourceID = "health";
        }
    }
}