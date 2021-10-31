using UnityEngine;
using System.Collections;
using System.Threading;
using UnityEngine.SceneManagement;

public class PlayerHealth2 : MonoBehaviour {
 
     // initialize variables

     public int hitsNeeded = 10;
     public int maxHealth = 10;
     public int curHealth;
     public int newHealth;
     public int hitsTaken;
     public Texture2D bgImage; 
     public Texture2D fgImage; 
     public float healthBarLength;
    
     // initialize health bar length
     void Start () {   
        healthBarLength = Screen.width /2;    
     }
 
     void OnGUI () {
         // Creates a group that has both images
         GUI.BeginGroup (new Rect (0,0, healthBarLength,32));
 
         // Draws background image
         GUI.Box (new Rect (0,0, healthBarLength,32), bgImage);
 
         // Creates second Group 
         // We want to clip the image and not scale it, which is why we need the second Group
         GUI.BeginGroup (new Rect (0,0, curHealth / maxHealth * healthBarLength, 32));
 
         // Draws main image
         GUI.Box (new Rect (0,0,healthBarLength,32), fgImage);
 
         // End both Groups
         GUI.EndGroup ();
 
         GUI.EndGroup ();
     }
 
     void OnCollisionEnter(Collision col) {
     if (col.gameObject.tag == "Enemy")
        {
          curHealth = hitsTaken += 1;
          newHealth = maxHealth-curHealth; 
          healthBarLength =(Screen.width /2) * (newHealth / (float)maxHealth);
          Debug.Log ("a collision occured, hitsTaken:" + hitsTaken);
          if (hitsTaken >= hitsNeeded) {
	     Debug.Log("Player killed by enemy. Game over.");
             SceneManager.LoadScene("Death Scene");
	     Thread.Sleep(3000);
             #if UNITY_EDITOR
             UnityEditor.EditorApplication.isPlaying = false;
             #elif UNITY_WEBPLAYER
             Application.OpenURL(webplayerQuitURL);
             #else
             Application.Quit();
             #endif

     } } } }