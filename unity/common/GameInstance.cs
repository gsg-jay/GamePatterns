using UnityEngine;
using UnityEngine.Events;
using System;

namespace GSG
{
    public class GameInstance : MonoBehaviour
    {
        public UnityEvent OnSceneChanged;
        public UnityEvent OnGamePausedEnter;
        public UnityEvent OnGamePausedExit;
        public UnityEvent<int> OnPlayerJoinGame;
        void Start()
        {

        }

        public void HandlePauseGame()
        {
            throw new NotImplementedException("GameInstance::HandlePauseGame not implemented");
        }
        public void HandlePlayerJoinGame(int nextPlayer)
        {
            throw new NotImplementedException("GameInstance::HandlePlayerJoinGame not implemented");
        }
        public void HandleSuspendPlayerControls(bool allowSkip)
        {
            throw new NotImplementedException("GameInstance::HandleSuspendPlayerControls not implemented");
        }
    }
}