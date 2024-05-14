using UnityEngine;
using System.Collections.Generic;

namespace GSG {
  [Serializable]
  public class BotGauge {
    public string id { get; private set; }
    constructor (string gaugeName) {
      
    }
    public bool IsGaugeFull(string gauge) {
      switch (gaugeName){
        case "ultra":
          return ultraGaugeCurrent >= ultraGaugeMax;
        default: 
          return healthGaugeCurrent >= healthGaugeMax;
      }
    }
    public bool IsGaugeEmpty(string gauge) {
      switch (gaugeName){
        case "ultra":
          return ultraGaugeCurrent >= ultraGaugeMax;
        default: 
          return healthGaugeCurrent >= healthGaugeMax;
      }
    }
  }
  
  public class BotBrain : MonoBehaviour {

    [SerializeField] Animator _animator;
    public enum ActionMode {
      Recovery,
      Sentry,
      Offense,
      Dead,
    }
    private ActionMode _actionMode = ActionMode.Sentry;
    private bool _isDying;
    private bool _isDead;
    
    public TargetDetectionEnum {
      Close,
      Far,
      Null
    };
    public GaugeEnum {
      Ultra,
      Health,
    }
    
    TargetDetectionEnum playerDetected;

    // ULTRA GAUGE
    // Note - Enemies gain their health back if their bullets hit you.
    [SerializeField] int _ultraGaugeCurrent;
    [SerializeField] int _ultraGainOnTakeDamage;
    [SerializeField] int _ultraGainOnTargetHit;
    [SerializeField] int _ultraGaugeInitial;
    [SerializeField] int _ultraGaugeMax;
    
    // HEALTH GAUGE
    // Note - Enemies gain their health back if their bullets hit you.
    [SerializeField] int _healthGaugeCurrent;
    [SerializeField] int _healthDrainOnTakeDamage;
    [SerializeField] int _healthGainOnTargetHit;
    [SerializeField] int _healthGaugeInitial;
    [SerializeField] int _healthGaugeMax;
    
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


    
    IEnumerator Execute() {
      while (true){ 
          if (IsGaugeFull(ultra)) {
            
          }
          switch (_actionMode){
            case ActionMode.Dead:
              yield return StartCoroutine(Dead());
            case ActionMode.Offense:
              yield return StartCoroutine(Offense());
            case ActionMode.Recovery:
              yield return StartCoroutine(Recovery());
            default:
              yield return StartCoroutine(Sentry());
          }
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
