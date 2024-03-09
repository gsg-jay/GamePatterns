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
      playableCharacter.Attack("Normal");
      return;
    }
    if (commaSeparatedCancelOptions.Includes("specialNeutral") && specialNeutral){
      playableCharacter.Attack("SpecialNeutral");
    }
    if (commaSeparatedCancelOptions.Includes("specialDown") && specialDown){
      playableCharacter.Attack("SpecialDown");
    }
    if (commaSeparatedCancelOptions.Includes("specialUp") && specialUp){
      playableCharacter.Attack("SpecialUp");
    }
  }

  public void SetAttackCancelOptions(string commaSeparatedCommands) {
    commaSeparatedCancelOptions = commaSeparatedCommands;
  }
  
}
