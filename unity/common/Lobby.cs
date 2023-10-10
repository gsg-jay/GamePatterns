using UnityEngine;
using UnityEngine.Events;
using System;

namespace GSG
{
    public class Lobby : MonoBehaviour
    {
        public UnityEvent OnPlayerLobbyJoin;
        public UnityEvent OnPlayerLobbyExit;
        public UnityEvent OnPlayerLobbyKicked;

        public void HandlePlayerLobbyJoin()
        {
            throw new NotImplementedException("Lobby::HandlePlayerLobbyJoin not implemented!");
        }
        public void HandlePlayerLobbyKicked()
        {
            throw new NotImplementedException("Lobby::HandlePlayerLobbyKicked not implemented!");
        }
        public void HandlePlayerLobbyExit()
        {
            throw new NotImplementedException("Lobby::HandlePlayerLobbyExit not implemented!");
        }
    }
}