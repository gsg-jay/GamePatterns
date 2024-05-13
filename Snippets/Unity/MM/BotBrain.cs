using UnityEngine;
using System.Collections.Generic;

namespace GSG {
  
  public class BotBrain : MonoBehaviour {

    [SerializeField] Animator _animator;

    public enum ActionMode {
      Recovery,
      Sentry,
      Offense,
      Dead,
    }
    
    private ActionMode actionMode = ActionMode.Sentry;
    
    public TargetDetectionEnum {
      Close,
      Far,
      Null
    };
    
    TargetDetectionEnum playerDetected;

    [SerializeField] int _ultraGaugeCurrent;
    [SerializeField] int _ultraGainOnTakeDamage;
    [SerializeField] int _ultraGainOnPlayerHit;

    [SerializeField] int _ultraGaugeInitial;
    [SerializeField] int _ultraGaugeMax;
    
    [SerializeField] int _attackTurnsClose = 0;
    [SerializeField] int _attackTurnsCloseMax;
    [SerializeField] int _attackTurnsFar = 0;
    [SerializeField] int _attackTurnsFarMax;
    [SerializeField] float _afterPatrolWaitTime;

    public AnimationClip DeathAnim;
    public AnimationClip DefenseAnim;
    public AnimationClip IdleAnim;
    public AnimationClip PatrolAnim;
    public AnimationClip AttackCloseAnim;
    public AnimationClip AttackFarAnim;
    public AnimationClip AttackUltraAnim;

    protected void Start() {
      StartCoroutine(Execute);
      ultraGaugeCurrent = ultraGaugeInitial;
    }

    bool IsUltraGaugeFull() {
      return ultraGaugeCurrent >= ultraGaugeMax;
    }
    
    IEnumerator Execute() {
      while (true){ 
          if (_isRecoveryMode){
            yield return StartCoroutine(Recovery());
          }
          if (_isSentryMode){
            yield return StartCoroutine(Sentry());
          }
          if (_isOffenseMode) {
            yield return StartCoroutine(Offense());
          }
          // etc..
      }
    }
  
    IEnumerator Offense() {
      if (IsUltraGaugeFull()){
        // ...
      }
    }
    

    public float Attack(string context) {
      if (context == "ultra"){
        _animator.Play(AttackUltra);
        return AttackUltra.length;
      }
    }
    
    
    // Pvt
    private void DecrementAttackTurns(string context, int turns) {
      if (context == "close"){
        attackTurnsClose -= turns;
        return;
      }
      if (context == "far"){
        attackTurnsFar -= turns;
        return;
      }
    }
    private void ResetAttackTurns(string context, int turns) {
      if (context == "close"){
        attackTurnsClose = attackTurnsCloseMax;
        return;
      }
      if (context == "far"){
        attackTurnsFar = attackTurnsFarMax;
        return;
      }
    }
    
    // Pub
    public void SetPlayerDetected (TargetDetectionEnum status){
      playerDetected = status;
    }
    
    public void Idle() {

    }
    public void Patrol() {

    }
    public void Attack() {

    }
    public void Wait() {

    }
    
  }
}
