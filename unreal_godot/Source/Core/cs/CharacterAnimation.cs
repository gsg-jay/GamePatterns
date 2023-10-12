using UnityEngine;
using System;

namespace GSG
{
    public class CharacterAnimation : MonoBehaviour
    {
        public const string animationID;
        public Animation anim;
        public const int defaultAnimationSpeed = 1;
        public float animationSpeed = 1;
        public UnityEvent<string> OnAnimationStateEnter;
        public UnityEvent<string> OnAnimationStateExit;

        void Start()
        {
            anim = GetComponent<Animation>();
        }

        public void EnterState()
        {
            if (!anim.isPlaying)
            {
                OnAnimationStateEnter?.Invoke(animationID);
                anim[animationID].speed = animationSpeed || defaultAnimationSpeed;
                anim.Play(animationID);
            }
        }
        public bool IsPlaying()
        {
            return anim.isPlaying;
        }
        public void ExitState()
        {
            if (!!anim.isPlaying)
            {
                OnAnimationStateEnter?.Execute(animationID);
                anim[animationID].speed = defaultAnimationSpeed;
                anim.Stop(animationID);
            }
        }

    }
}