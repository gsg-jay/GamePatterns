using UnityEngine;
using System;


public class Weapon : MonoBehaviour {
  public int damage;
  public enum WEAPON_EFFECT {
    NONE,
    FIRE,
    ELECTRIC,
    ICE,
    MYSTIC_LIGHT,
    MYSTIC_DARK
  };
  public WEAPON_EFFECT weaponEffect;
}
