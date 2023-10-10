using UnityEngine;
using UnityEngine.Events;
using System;

namespace GSG
{
    public class GameInstance : MonoBehaviour
    {
        #region Declare Singleton
        // (Unreal) GameInstance is a singleton by default
        private static GameInstance _instance;
        public static GameInstance Instance
        {
            get
            {
                // If there is no instance yet, find or create it.
                if (_instance == null)
                {
                    _instance = FindObjectOfType<GameInstance>();

                    // If no instance exists in the scene, create an empty GameObject and attach the script.
                    if (_instance == null)
                    {
                        GameObject gameInstanceObj = new GameObject(typeof(GameInstance).Name);
                        _instance = gameInstanceObj.AddComponent<GameInstance>();
                    }
                }
                return _instance;
            }
        }
        #endregion

        public UnityEvent<int> OnSceneChanged;
        public UnityEvent OnGamePausedEnter;
        public UnityEvent OnGamePausedExit;
        public UnityEvent<int> OnPlayerJoinGame;
        void Start()
        {
            HandleBootGame();
        }
        public void HandleBootGame()
        {
            OnSceneChanged?.Invoke(0);
        }
        public void HandleOnSceneChanged()
        {
            throw new NotImplementedException("GameInstance::HandleOnSceneChanged not implemented");
        }
        public void HandleToggleGamePaused()
        {
            throw new NotImplementedException("GameInstance::HandleToggleGamePaused not implemented");
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