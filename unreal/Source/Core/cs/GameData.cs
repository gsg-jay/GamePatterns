using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections.Generic;

namespace GSG
{
    public class GameData : MonoBehaviour
    {
        public string jsonStringGameData;
        public UnityEvent OnSaveDataStart;
        public UnityEvent OnSaveDataExit;
        public UnityEvent OnLoadDataStart;
        public UnityEvent OnLoadDataExit;
    }
}
