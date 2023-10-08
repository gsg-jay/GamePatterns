using Godot;
using System;

namespace GSG
{
    public class GameDataManager
    {
        public event OnSaveDataStart;
        public event OnSaveDataExit;
        public event OnLoadDataStart;
        public event OnLoadDataExit;
        }
    }