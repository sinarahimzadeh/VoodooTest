 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class PileHandler : MonoBehaviour
 {
     [SerializeField] private int counter; 
     void OnCollisionEnter(Collision collision)
     {
         if (collision.transform.tag=="gate")
         {
             counter++;
            // Time.timeScale = 0;
         }
     }
     
     void OnCollisionExit(Collision collision)
     {
         if (collision.transform.tag=="gate"&&counter<2)
         {
             counter=0;
             // Time.timeScale = 0;
         }
     }

     void Update()
     {
         if (counter>=2)
         {
             GameManager.shared.Lose();
         }
     }
 }
