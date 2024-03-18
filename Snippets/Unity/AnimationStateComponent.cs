using UnityEngine;
using System;

namespace GSG {
  public class AnimationStateComponent : MonoBehaviour {

    private Animator _animator;
    private string _currentAnimation;
    private AnimatorStateInfo _animatorInfo;
    
    void Start() {
      _animator = GetComponent<Animator>();
    }
    
    void Update() {
        // Check if the animator is not null
        if (_animator != null)
        {
            // Get the current state information from the Animator
            _animatorInfo = _animator.GetCurrentAnimatorStateInfo(0);
        }
    }
    
    public bool IsAnimationPlaying(string animationName) {
        return IsPlaying(_animatorInfo.IsName("Base Layer.Idle"));
    }
    
  }

}
