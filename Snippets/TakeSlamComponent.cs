using UnityEngine;
using System;

namespace GSG {
  public class TakeSlamComponent : MonoBehaviour {
    private Animator _animator;
    private Bot _bot;
    private PlayableCharacter _playableCharacter;

    void Start() {
      _animator = GetComponent<Animator>();
      _bot = GetComponent<Bot>();
      _playableCharacter = GetComponent<PlayableCharacter>();
    }
    
    public void TakeThrowBegin(Transform target) {
      gameObject.transform.SetParent(target);
      var recipient = _bot || _playable;
        recipient.SuspendControl();
        recipient.Play("TakeThrow");
    }
    
    public void TakeThrowEnd(Transform target) {
      gameObject.transform.SetParent(null);
      _animator.Play("Knockdown");
    }
    
    public void TakeDamageFromSlam(int damage) {
      var recipient = _bot || _playable; 
      recipient.TakeDamage(damage);
    }                  
  }
}
