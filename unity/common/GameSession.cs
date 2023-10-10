using UnityEngine;
using UnityEngine.Events;
using System;

namespace GSG
{
    public class GameSession : MonoBehaviour
    {
        public enum GAME_MODE_TYPE
        {
            STORY,
            VS_BATTLE,
            TRAINING
        };
        public GAME_MODE_TYPE currentGameMode;
        public List<Player> players = new List<Player>();
        public int[] scores;
        public int currentTimeElapsedInMs;
        public int maxMatchTimeInMs;
        public int timeElapsedInMs;
        public int timeRemaining;
        public UnityEvent OnMatchAborted;
        public UnityEvent OnMatchStart;
        public UnityEvent OnMatchEnd;
        public UnityEvent OnMatchStateChanged;
    }
}