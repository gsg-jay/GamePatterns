using UnityEngine;
using UnityEngine.Events;
using System;

namespace GSG
{
    public class GameSession : MonoBehaviour
    {
        // (Unreal) each Lobby class inherits from AGameModeBase
        public Lobby currentLobby;
        public enum GAME_MODE_TYPE
        {
            STORY,
            LOBBY,
            CHARACTER_LOADOUT,
            VS_MATCH,
            TRAINING
        };
        public GAME_MODE_TYPE currentGameMode;
        public List<Player> players = new List<Player>();
        public int maxPlayers;
        public int currentTimeElapsedInMs;
        public int maxMatchTimeInMs;
        public int timeElapsedInMs;
        public int timeRemaining;
        public UnityEvent OnMatchAborted;
        public UnityEvent OnMatchStart;
        public UnityEvent OnMatchEnd;
        public UnityEvent OnMatchStateChanged;
        public UnityEvent<string> OnLobbySearch;

        public void HandleAddPlayer(Player nextPlayer)
        {
            if (players.Count() < maxPlayers)
            {
                players.Add(nextPlayer);
            }
        }
        public void HandlePlayerSignIn()
        {
            throw new NotImplementedException("GameSession::HandlePlayerSignIn not implemented!");
        }
        public void HandlePlayerSignOut()
        {
            throw new NotImplementedException("GameSession::HandlePlayerSignOut not implemented!");
        }
        public void HandleLobbySearch()
        {
            throw new NotImplementedException("GameSession::HandleLobbySearch not implemented!");
        }
        public void HandleMatchEnd()
        {
            throw new NotImplementedException("GameSession::HandleMatchEnd not implemented!");
        }
        public void HandleMatchStart()
        {
            throw new NotImplementedException("GameSession::HandleMatchStart not implemented!");
        }
        public void HandleMatchAbort()
        {
            throw new NotImplementedException("GameSession::HandleMatchAbort not implemented!");
        }
    }
}