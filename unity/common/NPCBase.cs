using UnityEngine;
using UnityEngine.Events;
using System;

namespace GSG
{
    public class NPCBase : MonoBehaviour, ICharacter
    {
        public enum NPC_ALIGNMENT
        {
            ENEMY,
            TRADER,
            ALLY,
            NEUTRAL,
        }
        public string instructionSetJSON;
        bool _hasEnteredClinchState = false;
        public bool isPlayerCommandable = false;
        public UnityEvent OnCommandStarted;
        public UnityEvent OnCommandCompleted;
        public UnityEvent OnCommandStateChanged;

        public bool SetNPCAlignment(int playerIndex)
        {
            throw new NotImplementedException("Player controls not implemented yet.");
        }
    }
}
