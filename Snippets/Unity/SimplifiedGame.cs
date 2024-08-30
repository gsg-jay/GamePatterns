using InControl;

public class Character : MonoBehaviour {
  public enum EGaugeID {
    Health,
    Stun
    Super,
  }
  #region Variables
  public int HealthCurrent;
  public int HealthMax;
  public int StunCurrent;
  public int StunMax;
  public int SuperCurrent;
  public int SuperMax;
  public bool CanMove; 
  public bool CanAttack;
  public bool CanJump;
  public bool IsGrounded;
  #endregion
    
  #region Hooks
  void OnEnable() {
    EventManager.Character<CharacterTakeDamageEvent>(TakeDamage);   
  }
  void OnDisable() {
    EventManager.Unsubscribe<CharacterTakeDamageEvent>(TakeDamage);   
  }
  void Start() {
    StartCoroutine(WaitInPlace(0));
  }
  void Update () {
    HandleControls();
  }
  #endregion
    
  #region Methods
  void HandleControls(){
    // Action 1 = ( x ) = Jump
    if (IsGrounded && InputManager.ActiveDevice.Action1.WasPressed)
    {
        Jump();
    }
    // Action 2 = ( ○ ) = Dash
    if (InputManager.ActiveDevice.Action2.WasPressed)
    {
        Dash();
    }
    // Action 3 = ( ▢ ) = Attack
    if (InputManager.ActiveDevice.Action3.WasPressed)
    {
        Attack();
    }
    // Action 4 = ( △ ) = Take Down
    if (InputManager.ActiveDevice.Action4.WasPressed)
    {
        TakeDown();
    }
  }
  void Attack(){
    // ..
  }
  void Idle(){
    // .. 
  }
  void ResetGauge(EGaugeID gauge) {
    switch (gauge){
      case EGaugeID.Health:
        Health = 0;
      case EGaugeID.Stun: 
        Stun = 0;
      case EGaugeID.Super:
        Super = 0;
    }
  }
  void IncrementGauge(EGaugeID gauge, int points){
     switch (gauge){
        case EGaugeID.Health:
            int newHealthValue = (HealthCurrent + points);
            HealthCurrent = Mathf.Clamp(newHealthValue, 0, HealthMax);
            break;
        case EGaugeID.Stun: 
            int newStunValue = (StunCurrent + points);
            StunCurrent = Mathf.Clamp(newStunValue, 0, StunMax);
            break;
        case EGaugeID.Super:
            int newSuperValue = (SuperCurrent + points);
            StunCurrent = Mathf.Clamp(newSuperValue, 0, StunMax);
            break;
     }
  }
  void Jump(){
    // ..
  }
  void Move(){
    // ..
  }
  void Spawn(){ 
    // ..
  }
  void TakeDamage(int damage) {
    // ..
  }
  IEnumerator WaitInPlace(float duration){
    yield return new WaitForSeconds(duration);
  }
  #endregion
}
