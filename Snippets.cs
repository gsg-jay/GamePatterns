// Mystical Medic

public class FightingAction : MonoBehaviour {
  private PlayableCharacter playableCharacter;
  private string commaSeparatedCancelOptions;
  
  void Start() {
    playableCharacter = GetComponent<PlayableCharacter>();
  }
  
  void Update() {
    var attackNeutral = playableCharacter.DidReceiveAttackCommand("attackNeutral");       // ▢
    var specialNeutral = playableCharacter.DidReceiveAttackCommand("specialNeutral");     // ○
    var specialUp = playableCharacter.DidReceiveAttackCommand("specialUp");               // ↑ + ○ 
    var specialDown = playableCharacter.DidReceiveAttackCommand("specialDown");           // ↓ + ○
    var specialForward = playableCharacter.DidReceiveAttackCommand("specialForward");     // → ○
    
    if (commaSeparatedCancelOptions.Includes("attackNeutral") && attackNeutral){
      playableCharacter.Attack("normal");
      return;
    }
    if (commaSeparatedCancelOptions.Includes("specialNeutral") && specialNeutral){
      playableCharacter.Attack("specialNeutral");
    }
    if (commaSeparatedCancelOptions.Includes("specialDown") && specialDown){
      playableCharacter.Attack("specialDown");
    }
    if (commaSeparatedCancelOptions.Includes("specialUp") && specialUp){
      playableCharacter.Attack("specialUp");
    }
  }

  public void SetAttackCancelOptions(string commaSeparatedCommands) {
    commaSeparatedCancelOptions = commaSeparatedCommands;
  }
  
}
