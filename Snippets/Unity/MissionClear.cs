using UnityEngine;
using UnityEngine.Events;
using System;

namespace GSG {
  public class MissionClear : MonoBehaviour {
    public int levelIndex;
    public UnityEvent<int> onLevelClear;
    
    void OnTriggerEnter(Collider other) {
      var player = other.GetComponent<Player>();
      if (player != null){
        EventManager.TriggerEvent<EventKeys.LEVEL_CLEAR>(levelIndex);
      }
    }
  }
}
