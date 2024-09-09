using UnityEngine;
using System.Collections.Generic;

public class Bullet : MonoBehaviour {
  public float LifetimeInitial;
  public float VelocityInitial;
  public float Acc;
  public Vector3 PositionInitial;
  public Vector3 RotationInitial;
  public Vector3 Trajectory;
  
  private bool _isActive = false;
  private float _lifetimeRemaining;
  private float _velocity;
  
  void Start(){
    _velocity = VelocityInitial;
    _lifetimeRemaining = LifetimeInitial;
  }
  
  void Update(){
    if (!_isActive) return;
    
    if (Lifetime > 0) { 
      _lifetimeRemaining -= Time.deltaTime 
      Move();
      return;
    }
    
    _isActive = false; 
  }
  
  void Reset(){
    _velocity = VelocityInitial;
    transform.position = PositionInitial;
    transform.rotation = RotationInitial;
    _lifetimeRemaining = LifetimeInitial;
    _isActive = false;
  }

  public void Fire(){
    _lifetimeRemaining = LifetimeInitial;
    _isActive = true;
  }
  
  void Move(){
    // No acceleration
    if (!Acc){
      transform.Translate(Trajectory * VelocityInitial); 
      return;
    }
    // With acceleration
    _velocity += (Acc * Time.deltaTime);
    transform.Translate(Trajectory * _velocity); 
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
  /*
     Create prefabs for the following bullet patterns:
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
  */
  
  public float BulletFireInterval;          // Time between shots
  public int BulletPoolSize = 500;          // Number of available bullets
  public List<Transform> SpawnPoints;       // Where to Spawn 
  
  public GameObject BulletPrefab; // Create different bullet types (accelerating, decelerating, linear)
  
  public float BulletLifetime;
  public float VelocityChange; // + or -
  
  // Todo : Add pooling
  void Start(){
    for (int i=0;i<BulletPoolSize;i++){
      AddBulletToPool(i);
    }
  } 

  public void Fire(){
    // TODO
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
