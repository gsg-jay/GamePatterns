using UnityEngine;
using UnityEngine.Events;
using System;

namespace GSG
{
    public class NPCAI : NPCBase, GameEntityBase
    {
        void Start()
        {
            this.NPC_ALIGNMENT = NPC_ALIGNMENT.ENEMY;
        }
    }

}