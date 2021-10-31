using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
 public Transform target;
 public float within_range;
 public float speed;
 
 public void Update(){
     float dist = Vector3.Distance(target.position, transform.position);
     //check if it is within the range you set
     if(dist <= within_range){
       transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);      
     } } }