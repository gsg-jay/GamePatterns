using System;
using UnityEngine;

public class PlayableCharacter : MonoBehaviour {
	public Player Player;
	public bool IsDead = false;
	protected void Update(){
		if (IsDead){
			HandleDead();
			return;
		}
		if (IsAnimationPlaying(CharacterAnimation.TakeDamage){
			player.SuspendControls();
		}
		if (IsAnimationPlayingOneOf(
			CharacterAnimation.TakeDamageHeavy,
			CharacterAnimation.TakeDamageLight,
			CharacterAnimation.Die,
			CharacterAnimation.Respawn,
			CharacterAnimation.ThrowGroundSuplex,
			CharacterAnimation.ThrowGroundForwardThrow,
			CharacterAnimation.ThrowAirCatch,
			CharacterAnimation.ThrowAirIzunaDrop,
			CharacterAnimation.Victory,
			CharacterAnimation.Okizeme,
		){
			player.SuspendControls();
		} else {
			player.EnableControls();
		}
	}
	
	public void IsCharacterAnimationOneOf(CharacterAnimation[] animations){
		int counter = 0;
		foreach (var anim in animations){
			bool isPlaying = IsCharacterAnimationPlaying(anim);
			if (isPlaying) counter++;
			break;
		}
		return counter >= 1;
	}

}

public class Wrestling : MonoBehaviour {

	[SerializeField] PlayableCharacter _owner;
	GameObject _victim;

	public void SetVictimToThrow(GameObject victim){
		_victim = victim;
	}
	public void UnsetVictimToThrow(GameObject victim){
		_victim = null;
	}
	private void ParentVictimToCharacter(){
		_victim.SetParent(_character.ThrowBox);
	}
	private void UnparentVictimFromCharacter(){
		_victim.SetParent(null);
		UnsetVictimToThrow(_victim);
	}
	public void HandleThrowAttempt(){
		_owner.ChangeAnimationState(CharacterAnimation.ThrowAttempt);
	}
	public void HandleThrowGroundForwardThrow(){
		_owner.ChangeAnimationState(CharacterAnimation.ThrowGroundForwardThrow);
	}
	public void HandleThrowAirIzunaDrop() {
		_owner.ChangeAnimationState(CharacterAnimation.ThrowAirIzunaDrop);
	}
	public void HandleThrowGroundSuplex(){
		_owner.ChangeAnimationState(CharacterAnimation.ThrowGroundSuplex);
	}
}



// System
public class GameManager : MonoBehaviour {
	
	// Singleton
	public static GameManager Instance;
	
	protected void Awake() {
		if (Instance == null){
			Instance = this;
		}
	}
	protected void OnEnable(){
		
	}
	protected void OnDisable(){
		
	}

	// Events
	public class Events {
		public UnityEvent<string data> OnGameStart;
		// etc...
	}
	
	// Level
	public class LevelManager {
	 public static void CompleteLevel(string levelName);
	}
	
	public class IOManager {
	 public static void Pause();
	 public static void SetCheckpoint(string currentSavePoint);
	 public static void SetSaveFile(string saveFileName);
	 public static void Save(string currentSaveFileName);
	 public static void Load(string saveFileName)
	}
	
	// Screen FX
	public class VFXManager {
	 public void VFXScreenFreeze(/* args */);
	 public void VFXTakeHeavyDamage(/* args */);
	 public void VFXSuperAttack(/* args */);
	 public void VFXBossDefeatedFX(/* args */);
	}

	// Tips + UI
	public class TutorialManager {
		public void FetchTip();
		public void ShowNextTip();
		public void HideTip();
	}
	
	
	// Game IO
	public void HandleLoadNextLevel(string levelName);
	public void 
	
} 

	public void HandleGameOver();
public class PlayableCharacter : MonoBehaviour;

// Bot
public class Bot : MonoBehaviour;
public class BotXXXComponent : MonoBehaviour;

// Player
public class XXXXComponent : MonoBehaviour;
