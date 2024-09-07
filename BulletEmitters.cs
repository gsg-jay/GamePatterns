using UnityEngine;
using System.Collections.Generic;

public class CrossEmitter {

  public int BulletPoolSize = 500;
  public List<Vector3> Angles = new();
  public List<GameObject> Bullets = new();
  public GameObject BulletPrefab;
  public Vector3 BulletStartPosition;
  
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
      bulletLogic.SetBehaviour(bulletIndexID, "pattern_cross", this);
      Bullets.Add(bullet);
  } 

  public void RemoveBulletFromPool(int bulletIndexID){
    Bullets.RemoveAt(bulletIndexID);
  }

}