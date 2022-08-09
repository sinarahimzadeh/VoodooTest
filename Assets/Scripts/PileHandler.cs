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
             GameManager.shared.Lose();

         }
     }
     
     
 }
