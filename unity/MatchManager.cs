using UnityEngine;
using UnityEngine.Events;
using System;

namespace GSG
{
    public class MatchManager : MonoBehaviour
    {
        public UnityEvent OnMatchStateChanged;
        public UnityEvent OnMatchStart;
        public UnityEvent OnMatchExit;
    }
}