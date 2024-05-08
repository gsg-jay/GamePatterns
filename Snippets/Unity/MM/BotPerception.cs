using UnityEngine;
using UnityEngine.Events;

namespace GSG {
    public class BotPerception : MonoBehaviour {
       public bool IsTargetCloseRange;
       public bool IsTargetFarRange;
       public bool IsTargetOutOfRange;

       public UnityEvent OnTargetCloseRangeEnter;
       public UnityEvent OnTargetCloseRangeExit;
       public UnityEvent OnTargetFarRangeEnter;
       public UnityEvent OnTargetFarRangeExit; // Out of Range

    }
}
