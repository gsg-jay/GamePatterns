using UnityEngine;
using System.Collections.Generic;


// ------------------------------------
// Bullet
// ------------------------------------
public class Bullet: MonoBehaviour {
  BulletEmitter _bulletEmitterRef;
  EBulletBehaviour _behaviourCurrent;
  bool _isActive = false;
  int _ID;
  float _velocityInitial;
  float _velocityChange;
  float _direction;
  float _lifetime;

  void Update(){
     if (!_isActive) return;
     switch (_behaviourCurrent){
        /* ... */
     }
  }

  public void SetBehaviour(int ID, BulletEmitter bulletEmitter, EBulletBehaviour behaviour, float velocityChange, float lifetime){
     _ID = ID;
     _behaviourCurrent = behaviour;
     _bulletEmitterRef = bulletEmitter;
     _velocityChange = velocityChange;
     _lifetime = lifetime;
     _isActive = true; // Activate bullet;
  }
}

// ------------------------------------
// Beam
// ------------------------------------
public class BeamEmitter : MonoBehaviour {
  /* ... */
}


// ------------------------------------
// Bullet Emitter / Pool
// ------------------------------------
public class BulletEmitter : MonoBehaviour {
  public enum EBulletBehaviour {
     Unset,
     Linear1,
     RapidLinear3,
     RapidLinear6,
     RapidLinear9,
     Spread4,
     Spread8,
     Spread16,
     Spread32, // Circle shot
     LockOn1, 
     LockOn3,
     LockOn5,
     SineWave2,
     SineWave4,
     SineWave8,
     Beam,
  }
  public EBulletBehaviour BulletBehaviour;
  public int BulletPoolSize = 500;
  public string BulletBehaviourName;
  public List<Vector3> Angles = new();
  public List<GameObject> Bullets = new();
  public GameObject BulletPrefab;
  public Vector3 BulletStartPosition;
  public float BulletLifetime;
  public float VelocityChange; // + or -
  
  // Todo : Add pooling
  void Start(){
    for (int i=0;i<BulletPoolSize;i++){
      AddBulletToPool(i);
    }
  } 

  void AddBulletToPool(int bulletIndexID){
     var bullet = Instantiate
     (BulletPrefab, 
      BulletStartPosition,
      Quaternion.Identity);
      var bulletLogic = bullet.GetComponent<Bullet>();
      bulletLogic.SetBehaviour(bulletIndexID, this, BulletBehaviour, VelocityChange, BulletLifetime);
      Bullets.Add(bullet);
  } 

  public void RemoveBulletFromPool(int bulletIndexID){
    Bullets.RemoveAt(bulletIndexID);
  }

}
