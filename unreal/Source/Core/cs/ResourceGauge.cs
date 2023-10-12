using UnityEngine;
using UnityEngine.Events;
using System;

namespace GSG
{
    public class ResourceGauge : MonoBehaviour
    {
        public string resourceID;
        public int minPoints;
        public int maxPoints;
        public int currentPoints;

        public UnityEvent OnResourceGaugeMaxPointsReached;
        public UnityEvent OnResourceGaugeChanged;
        public UnityEvent OnResourceGaugeReset;
    }
}