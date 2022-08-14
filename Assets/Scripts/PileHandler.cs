 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
 public class PileHandler : MonoBehaviour
 {
     [SerializeField] private int counter; 
     void OnCollisionEnter(Collision collision)
     {
         if (collision.transform.tag=="gate")
         {
            //GameManager.shared.Lose();
            Vector3 globalPositionOfContact =
                     collision
                     .contacts[0]
                     .point;
            print(globalPositionOfContact);

            float x = ((globalPositionOfContact.x - transform.position.x) / (transform.localScale.x / 2)) / 2;
            print(x);
            transform.DORotate(new Vector3(0, -90 * (x - 1), 0), 0.1f).OnComplete(() =>
            {
                transform.DORotate(new Vector3(0, 0, 0), 0.1f).SetDelay(0.2f);
            });

        }
    }
     
     
 }
