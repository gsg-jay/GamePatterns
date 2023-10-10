using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections.Generic;

namespace GSG
{
  public class Player : MonoBehaviour, ICharacterBase
  {

    public CombatGunner gunCombat;
    public CombatMelee meleeCombat;

    public enum TRIGGERED_STATE_TYPE { };   // TODO Define in own class
    public enum ABILITY_TYPE { };           // TODO Define in own class
    public enum MOUNT_TYPE { };             // TODO Define in own class
    public enum GRAB_TYPE { };              // TODO Define in own class
    public enum ATTACK_TYPE { };            // TODO Define in own class
    public enum INVENTORY_ITEM_TYPE { };    // TODO Define in own class
    public enum INTERACTION_TYPE { };       // TODO Define in own class
    public enum ITEM_TYPE { };              // TODO Define in own class
    public enum DEATH_TYPE { };             // TODO Define in own class

    public void Respawn()
    {
      throw new NotImplementedException("Player::Die not implemented!");
    }
    public void Die(DEATH_TYPE deathType)
    {
      throw new NotImplementedException("Player::Die not implemented!");
    }
    public void Move(Vector3 movement)
    {
      throw new NotImplementedException("Player::Move not implemented!");
    }
    public void Interact(INTERACTION_TYPE interactionType)
    {
      throw new NotImplementedException("Player::Interact not implemented!");
    }
    public void Jump()
    {
      throw new NotImplementedException("Player::Jump not implemented!");
    }
    public void DoubleJump()
    {
      throw new NotImplementedException("Player::DoubleJump not implemented!");
    }
    public void ComboAttack()
    {
      throw new NotImplementedException("Player::ComboAttack not implemented!");
    }
    public void SpecialAttack()
    {
      throw new NotImplementedException("Player::SpecialAttack not implemented!");
    }
    public void EnterTriggeredState(TRIGGERED_STATE_TYPE triggeredStateType)
    {
      throw new NotImplementedException("Player::EnterTriggeredState not implemented!");
    }
    public void ExitTriggeredState()
    {
      throw new NotImplementedException("Player::ExitTriggeredState not implemented!");
    }
    public void UseAbility(ABILITY_TYPE abilityType, ResourceGauge gaugeToUse, int gaugeChange)
    {
      throw new NotImplementedException("Player::UseAbility not implemented!");
    }
    public void Equip()
    {
      throw new NotImplementedException("Player::Equip not implemented!");
    }
    public void UseItem(INVENTORY_ITEM_TYPE itemType)
    {
      throw new NotImplementedException("Player::UseItem not implemented!");
    }
    public void Grab(GRAB_TYPE grabType)
    {
      throw new NotImplementedException("Player::Grab not implemented!");
    }
    public void Throw()
    {
      throw new NotImplementedException("Player::Throw not implemented!");
    }
    public void Summon()
    {
      throw new NotImplementedException("Player::Summon not implemented!");
    }
    public void Dismiss()
    {
      throw new NotImplementedException("Player::Dismiss not implemented!");
    }
    public void ToggleInventory()
    {
      throw new NotImplementedException("Player::ToggleInventory not implemented!");
    }
  }
}
