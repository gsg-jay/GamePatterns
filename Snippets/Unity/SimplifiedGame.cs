using InControl;

public class Character : MonoBehaviour {
  public enum EGaugeID {
    Health,
    Stun,
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

  private string _actionCurrent;
  [SerializeField] Animator animator;
  [SerializeField] AnimationClip animAttack;
  [SerializeField] AnimationClip animDash;
  [SerializeField] AnimationClip animDie;
  [SerializeField] AnimationClip animIdle;
  [SerializeField] AnimationClip animJump;
  [SerializeField] AnimationClip animRun;
  [SerializeField] AnimationClip animSpawn;
  [SerializeField] AnimationClip animTakeDown;
  [SerializeField] AnimationClip animVictory;
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
    if (_actionCurrent == "spawn") 
    {
      Spawn(); return;
    }
    if (_actionCurrent == "die") 
    {
      Die(); return;
    }
    if (_actionCurrent == "victory") 
    {
      Victory(); return;
    }
    // [Action 1 = ( x CROSS )] = Jump
    if (IsGrounded && InputManager.ActiveDevice.Action1.WasPressed)
    {
        if (_actionCurrent == "run" || _actionCurrent == "idle"){
          Jump();
        }
    }
    // [Action 2 = ( ○ CIRCLE )] = Dash
    else if (InputManager.ActiveDevice.Action2.WasPressed)
    {
        if (_actionCurrent == "jump" || _actionCurrent == "idle"){
          Dash();
        }
    }
    // [Action 3 = ( ▢ SQUARE)] = Attack
    else if (InputManager.ActiveDevice.Action3.WasPressed)
    {
        if (_actionCurrent == "attack" && CanCancelAttack == true || _actionCurrent == "idle" || _actionCurrent == "run"){
          Attack();
        }
    }
    // [Action 4 = ( △ TRIANGLE)] = Take Down
    else if (InputManager.ActiveDevice.Action4.WasPressed)
    {
        if (_actionCurrent == "attack" && CanCancelAttack == true || _actionCurrent == "idle" || _actionCurrent == "run") {
          TakeDown();
        }
    }
    else {
      // Left Stick = Run
      // Read the left stick input (for horizontal and vertical movement)
      Vector2 movementInput = new Vector2(inputDevice.LeftStickX, inputDevice.LeftStickY);

      // Check if there is any movement input on X-Axis
      if (Mathf.Abs(movementInput.x) > 0.1f){
        Run();
      } else {
        Idle(); 
      }
    }
  }
  void Attack(){
    AnimUtil.PlayAnimation(animator, animAttack);
  }
  void Die(){ 
    AnimUtil.PlayAnimation(animator, animDie);
  }
  public void Idle(){
    AnimUtil.PlayAnimation(animator, animIdle);
  }
  void Jump(){
    AnimUtil.PlayAnimation(animator, animJump);
  }
  void Move(){
    AnimUtil.PlayAnimation(animator, animMove);
  }
  void Spawn(){ 
    AnimUtil.PlayAnimation(animator, animSpawn);
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
            SuperCurrent = Mathf.Clamp(newSuperValue, 0, StunMax);
            break;
     }
  }
  void TakeDamage(Events.CharacterEvents.CharacterTakeDamageEvent evt) {
    if (evt.Character != this) return;
    var attack = evt.Attack;
    var damage = attack.Damage;
    
    IncrementGauge(EGaugeID.Health, -damage);
    if (attack.Stun) IncrementGauge(EGaugeID.Stun, attack.Stun);
    if (attack.Super) IncrementGauge(EGaugeID.Super, attack.Super); 
  }
  IEnumerator WaitInPlace(float duration){
    yield return new WaitForSeconds(duration);
  }
  #endregion
}
