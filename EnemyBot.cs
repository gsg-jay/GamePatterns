public class BotEnemy : MonoBehaviour {
    #region Variables
    // Use all public variables 
    // public ... 
    public string BehaviourState = "patrol";
    public bool CanAttack = true;
    public bool IsProjectileVulnerable = false;
    public bool IsMeleeVulnerable = false;
    public bool IsActive = false;
    public bool IsDead = false;
    #endregion

    #region Hooks
    protected void OnEnable(){
        // ...
    }
    protected void OnDisable(){
        // ...
    }
    protected void Start(){
        // ...
    }
    protected void Update(){
        // Skip all actions
        if (health < 0 && !IsDead) {
          Action_Die();
        }
        if (!IsActive) return;

        if (CanAttack && BehaviourState == "attack")){
            Action_Attack();
        }
        if (_canAttack && Input.GetKeyDown(KeyCode.JoystickButton1)){
            Action_AttackCombo();
        }
    }
    #endregion

    #region Methods
    private void SetDashFrameData(string context, bool isCancellable){}
    private void SetAttackComboFrameData(string context, bool isCancellable){
          if (context == "startup_frames"){
              IsAttackCancellable = false;
              IsProjectileVulnerable = true;
              CanChangeCommand = false;
              IsVulnerable = true;
              return;
          }
          if (context == "active_frames"){
              IsAttackCancellable = false;
              IsProjectileVulnerable = true;
              CanChangeCommand = false;
              IsVulnerable = false;
              return;
          }
          if (context == "cancel_frames"){
              IsAttackCancellable = isCancellable;
              IsProjectileVulnerable = true;
              CanChangeCommand = true;
              IsVulnerable = false;
              return;
          }
          if (context == "recovery_frames"){
              IsAttackCancellable = false;
              IsProjectileVulnerable = true;
              CanChangeCommand = false;
              IsVulnerable = true;
              return;
          }
          if (context == "last_frame"){
              IsAttackCancellable = false;
              IsProjectileVulnerable = true;
              CanChangeCommand = true;
              IsVulnerable = true;
              return;
          }
    }
    #endregion


    #region External Events
    // 2) Event Handler
    private void EventHandler_OnLevelStartEvent(LevelEvents.LevelStartEvent evt) {
        // ...
    }
    #endregion
        
    #region Actions
    // ----------------------------------------------
    // Jump
    // ----------------------------------------------
    // 1) Action
    private void Action_Die(){
        EventManager.Dispatch(new EnemyEvents.DieEvent() {
            Enemy = this,
            // ...
        });
    }
    // 2) Animation Event Handler (where applicable)
    private void AnimationEventHandler_OnJumpAnimationEvent(EnemyEvents.AnimationEvents.JumpAnimationEvent evt) {
        if (evt.Character != this) return;
        // ...
    }
    #endregion

    #region Animation Event Action Handler
    // 4) AnimEventActionHandler = Dispatches an Event in response to an AnimationEvent,
    //    this is the sole public AnimationEvent callback function used on the timeline.
    public void AnimEventActionHandler(string animationEventData){
        var payload = AnimEventUtil.ExtractData(animationEventData);
        string animation = payload.animation;
        string context = payload.context;
        string data = payload.data;
        switch (animation) { 
            case "jump":
                EventManager.Dispatch(new EnemyEvents.AnimationEvents.OnJumpAnimationEvent(){
                    Character = this,
                    Context = context, // start_up, climax, end, iframes, etc
                    Data = data,
                });
            case "take_down":
                EventManager.Dispatch(new EnemyEvents.AnimationEvents.OnJumpAnimationEvent(){
                    Character = this,
                    Context = context, // start_up, climax, end, iframes, etc
                    Data = data,
                });
            //...
        }
    }
    #endregion
}
