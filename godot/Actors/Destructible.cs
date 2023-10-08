using Godot;
using System;

namespace GSG
{
    public class Destructible
    {
        public event OnDestroyed;
        public event OnDestructionStart;
        public event OnDestructionExit;
        }
    }