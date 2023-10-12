using UnityEngine;
using UnityEngine.Events;
using System;

namespace GSG
{
    public class Quest : MonoBehaviour
    {
        public string questName;
        public enum QUEST_STATE
        {
            STARTED,
            ABORTED,
            SUCCEEDED,
            FAILED
        }
        public UnityEvent OnQuestStarted;
        public UnityEvent OnQuestAborted;
        public UnityEvent OnQuestSucceeded;
        public UnityEvent OnQuestFailed;
    }
}