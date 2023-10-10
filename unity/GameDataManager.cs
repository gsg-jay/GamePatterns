using UnityEngine;
using UnityEngine.Events;
using System;

namespace GSG
{
    public class GameDataManager : MonoBehaviour
    {
        public event OnSaveDataStart;
        public event OnSaveDataExit;
        public event OnLoadDataStart;
        public event OnLoadDataExit;
        }
    }