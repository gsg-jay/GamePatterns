using UnityEngine;
using UnityEngine.Events;
using System;

namespace GSG {
  public class MissionClear : MonoBehaviour {
    public int taskIndex;
    public UnityEvent<int> onTaskClear;
    
    void OnTriggerEnter(Collider other) {
      var player = other.GetComponent<Player>();
      if (player != null){
        EventManager.TriggerEvent<EventKeys.OnTaskClear>(taskIndex);
      }
    }
  }
}
