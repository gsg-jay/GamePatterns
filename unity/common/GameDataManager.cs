using UnityEngine;
using UnityEngine.Events;
using System;

namespace GSG
{
    public class GameDataManager : MonoBehaviour
    {
        public class GameData
        {
            public Vector3 player1Position;
        }
        public GameData gameData;
        public UnityEvent OnSaveDataStart;
        public UnityEvent OnSaveDataExit;
        public UnityEvent OnLoadDataStart;
        public UnityEvent OnLoadDataExit;
    }
}