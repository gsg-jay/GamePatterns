using UnityEngine;
using System;

namespace GSG {
  public class TakeSlamComponent : MonoBehaviour {
    
    private Animator _animator;
    
    public void TakeSlam(Transform target) {
      gameObject.SetParent(target);
      _animator.Play("TakeThrow");
      
      var bot = gameObject.GetComponent<Bot>();
      var playable = gameObject.GetComponent<PlayableCharacter>();
      
      if (bot) {
        bot.TakeDamage();
        return;
      } else {
        playable.TakeDamage();
      }
    }
    
    public void TakeDamage() {

    }
                           
  }
}
