using UnityEngine;
using UnityEngine.Events;
using System;

namespace GSG
{
    public class InteractibleHazard : InteractibleBase
    {
        public UnityEvent OnHazardStateChanged;
    }
}