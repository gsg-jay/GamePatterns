using UnityEngine;
using UnityEngine.Events;
using System;

namespace GSG
{
    public class InteractibleApparatus : InteractibleBase
    {
        public string currentState;
        public UnityEvent OnApparatusStateChanged;
    }
}