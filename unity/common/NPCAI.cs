using UnityEngine;
using UnityEngine.Events;
using System;

namespace GSG
{
    public class NPCAI : NPCBase, GameEntityBase
    {
        public enum AI_STRATEGY
        {
            IDLE,
            DEFEND_IN_CONTEXT,
            NEUTRAL_IN_CONTEXT,
            AGGRESSION_IN_CONTEXT,
            RETREAT,
            CHASE,
            SEEK_ADVANTAGE,
        }

        public UnityEvent OnStrategyChanged;
        public UnityEvent OnClinchStateEnter;
        public UnityEvent OnClinchStateExit;

        void Start()
        {
            UseCPUControl(instructionSetJSON);
        }
        public bool UsePlayerControl(int playerIndex)
        {
            throw new NotImplementedException("Player controls not implemented yet.");
        }
        public bool UseCPUControl(string instructionsJSON)
        {
            return instructionSetJSON = instructionsJSON;
        }
    }

}