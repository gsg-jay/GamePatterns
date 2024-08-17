public class PlayerCharacter : MonoBehaviour {
    #region Variables
    // Use all public variables 
    // public ... 
    public bool IsProjectileVulnerable = false;
    public bool IsMeleeVulnerable = false;
    public bool IsControlEnabled = false;
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
        if (_isGrounded && Input.GetKeyDown(KeyCode.Space)){
            Action_Jump();
        }
        if (_canAttack && Input.GetKeyDown(KeyCode.JoystickButton1)){
            Action_AttackCombo();
        }
    }
    #endregion

    #region Methods
    private void DoSomethingOne() { /* ... */ }
    private void SetDashFrameData(string context, bool isCancellable){}
    private void SetAttackComboFrameData(string context, bool isCancellable){
          if (context == "startup_frames"){
              IsAttackCancellable = false;
              IsProjectileVulnerable = true;
              IsMeleeVulnerable = true;
              IsControlEnabled = false;
              return;
          }
          if (context == "active_frames"){
              IsAttackCancellable = false;
              IsProjectileVulnerable = true;
              IsControlEnabled = false;
              IsMeleeVulnerable = false;
              return;
          }
          if (context == "cancel_frames"){
              IsAttackCancellable = isCancellable;
              IsProjectileVulnerable = true;
              IsControlEnabled = true;
              IsMeleeVulnerable = false;
              return;
          }
          if (context == "recovery_frames"){
              IsAttackCancellable = false;
              IsProjectileVulnerable = true;
              IsControlEnabled = false;
              IsMeleeVulnerable = true;
              return;
          }
    }
    #endregion

    #region Actions + Event Handlers
    // ----------------------------------------------
    // Jump
    // ----------------------------------------------
    // 1) Action
    private void Action_Jump(){
        EventManager.Dispatch(new CharacterEvents.OnJumpEvent() {
            Character = this,
            // ...
        })
    }
    // 2) Event Handler
    private void EventHandler_OnJumpEvent(CharacterEvents.OnJumpEvent evt) {
        if (evt.Character != this) return;
        // ...
    }
    // 3) Animation Event Handler (where applicable)
    private void AnimationEventHandler_OnJumpAnimationEvent(CharacterEvents.AnimationEvents.OnJumpAnimationEvent evt) {
        if (evt.Character != this) return;
        // ...
    }

    // ----------------------------------------------
    // Attack Combo
    // ----------------------------------------------
    // 1) Action
    private void Action_AttackCombo(){
        EventManager.Dispatch(new CharacterEvents.OnPlayerJumpEvent() {
            Character = this,
            // ...
        })
    }
    // 2) Event Handler
    private void EventHandler_OnAttackCombo(CharacterEvents.OnAttackComboEvent evt) {
        if (evt.Character != this) return;
        // ...
    }
    // 3) Animation Event Handler (where applicable)
    private void AnimationEventHandler_OnAttackComboAnimationEvent(CharacterEvents.AnimationEvents.OnAttackComboAnimationEvent evt) {
        if (evt.Character != this) return;
        if (!evt.Context || !evt.Data) return;
        const bool COMBO_CANCEL_ENABLED = true;
        const bool COMBO_CANCEL_DISABLED = false;
        if (evt.Data.Contains("attack1") || evt.Data.Contains("attack2")){
          SetAttackComboFrameData(evt.Context, COMBO_CANCEL_ENABLED);
        }
        if (evt.Data.Contains("attack3"){
          SetAttackComboFrameData(evt.Context, COMBO_CANCEL_DISABLED);
        }
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
                EventManager.Dispatch(new CharacterEvents.AnimationEvents.OnJumpAnimationEvent(){
                    Character = this,
                    Context = context, // start_up, climax, end, iframes, etc
                    Data = data,
                });
            case "take_down":
                EventManager.Dispatch(new CharacterEvents.AnimationEvents.OnJumpAnimationEvent(){
                    Character = this,
                    Context = context, // start_up, climax, end, iframes, etc
                    Data = data,
                });
            //...
        }
    }
    #endregion
}
