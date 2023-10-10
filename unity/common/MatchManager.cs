using UnityEngine;
using UnityEngine.Events;
using System;

namespace GSG
{
    public class MatchManager : MonoBehaviour
    {
        public UnityEvent OnMatchAborted;
        public UnityEvent OnMatchStart;
        public UnityEvent OnMatchEnd;
        public UnityEvent OnMatchStateChanged;
    }
}