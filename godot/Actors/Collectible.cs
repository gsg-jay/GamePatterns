using Godot;
using System;

namespace GSG
{
    public class Collectible
    {
        public event OnSpawned;
        public event OnDestroyed;
        public event OnCollected;
        }
    }