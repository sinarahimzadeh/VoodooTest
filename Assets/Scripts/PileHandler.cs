 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
 public class PileHandler : MonoBehaviour
 {
     public PileHandler instance;

     [HideInInspector]
     public int injuryCounter; 
     void Start()
     {
         instance = this;
     }

     void OnCollisionEnter(Collision collision)
     {
         if (collision.transform.tag=="gate")
         {
            GameManager.shared.Lose();
         }
    }
     
     
 }
