using UnityEngine;
using System.Collections.Generic;

public class BulletEmitter : MonoBehaviour {
  
  public enum EBulletBehaviour {
   //...
  }
  public EBulletBehaviour BulletBehaviour;
  public int BulletPoolSize = 500;
  public string BulletBehaviourName;
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
      bulletLogic.SetBehaviour(bulletIndexID, BulletBehaviour, this);
      Bullets.Add(bullet);
  } 

  public void RemoveBulletFromPool(int bulletIndexID){
    Bullets.RemoveAt(bulletIndexID);
  }

}