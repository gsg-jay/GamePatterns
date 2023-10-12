using UnityEngine;

namespace GSG {
  public class Gun : WeaponBase {

    public bool hasAltFire;
    public Bullet bulletFireMode1Prefab;
    public Bullet bulletFireMode2Prefab;
    private int _currentFireMode // 1 = default, 2 = alt 
    
    public enum AMMO_TYPE {};
    public enum GUN_ATTRIBUTE_TYPE {
      MAX_AMMO,
      MAX_FIRE_RATE,
      MAX_POWER,
    };
    public AMMO_TYPE ammoType;
    public int maxAmmo;
    public int maxClip;
    public int fireRate;
    public int maxPower;
    public int currentAmmo;
    public int currentClip;

    public void SetFireMode(int fireMode) {
      _currentFireMode = fireMode;
    }
    public void Reload(){
      throw new NotImplementedException("Gun::Reload not implemented!");
    }
    public void Upgrade(GUN_ATTRIBUTE_TYPE attribute, int points){
      throw new NotImplementedException("Gun::Upgrade not implemented!");
    }
    public void Fire(){
      throw new NotImplementedException("Gun::Fire not implemented!");
    }
  }
}
