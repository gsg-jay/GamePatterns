// Mystical Medic

public class FightingAction : MonoBehaviour {
  private Player _player;
  private PlayableCharacter _playableCharacter;
  private string _commaSeparatedCancelOptions;
  private float _gamepadDeadZone; 
  
  void Start() {
    _playableCharacter = GetComponent<PlayableCharacter>();
    _player = _playableCharacter.GetPlayer();
    _gamepadDeadZone = _player.GetGamepadDeadZone();
  }

  private bool CommandReceivedNormalAttack() {
    return !_player.buttonSpecial.IsPressed() && _player.buttonAttack.IsPressed();
  }
  private bool CommandReceivedForwardSpecial() {
    return _player.IsMoving() && _player.buttonSpecial.IsPressed();
  }
  private bool CommandReceivedDownSpecial() {
    return _player.IsCrouching() && _player.buttonSpecial.IsPressed();
  }
  private bool CommandReceivedUpSpecial() {
    return _player.leftStickY > _gamepadDeadZone && _player.buttonSpecial.IsPressed();
  }
  private bool CommandReceivedNeutralSpecial() {
    return (
      Math.Abs(_player.leftStick.y) < _gamepadDeadZone 
      && Math.Abs(_player.leftStick.y) < _gamepadDeadZone  
      && _player.buttonSpecial.IsPressed()
    )
  }
  
  void Update() {
    var attackNeutral = CommandReceivedNormalAttack();                                     // ▢
    var specialNeutral = CommandReceivedNeutralSpecial();     // ○
    var specialUp = CommandReceivedUpSpecial();               // ↑ + ○ 
    var specialDown = CommandReceivedDownSpecial();           // ↓ + ○
    var specialForward = CommandReceivedForwardSpecial();     // → ○
    
    if (commaSeparatedCancelOptions.Includes("specialUp") && specialUp){
      playableCharacter.Attack("specialUp");
      return;
    }
    if (commaSeparatedCancelOptions.Includes("specialDown") && specialDown){
      playableCharacter.Attack("specialDown");
      return;
    }
    if (commaSeparatedCancelOptions.Includes("specialForward") && specialForward){
      playableCharacter.Attack("specialForward");
      return;
    }
    if (commaSeparatedCancelOptions.Includes("specialNeutral") && specialNeutral){
      playableCharacter.Attack("specialNeutral");
      return;
    }
    if (commaSeparatedCancelOptions.Includes("attackNeutral") && attackNeutral){
      playableCharacter.Attack("normal");
      return;
    }
  }

  public void SetAttackCancelOptions(string commaSeparatedCommands) {
    commaSeparatedCancelOptions = commaSeparatedCommands;
  }
  
}
