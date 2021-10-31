using UnityEngine;
using System.Collections;
 
public class EnemyHealth: MonoBehaviour {
 
 public int hitsNeeded = 7;
 public int hitsTaken;
 
     void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Untagged")
        {
          hitsTaken += 1;
          Debug.Log ("a collision occured, hitsTaken:" + hitsTaken);
          Debug.Log("Attacked Player");
          if (hitsTaken >= hitsNeeded) {
             Destroy (gameObject);
     } } } } 