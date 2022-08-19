 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
 using Unity.Mathematics;
 using UnityEngine.Windows.Speech;
 using Random = UnityEngine.Random;

 public class PileHandler : MonoBehaviour
 {
     
     [SerializeField] private int counter;
     [SerializeField] private float force;
     public bool feverMode;
     [SerializeField] private Transform breakable,fractured;
     [SerializeField] private GameObject fireparticle1, fireparticle2;
     void OnCollisionEnter(Collision collision)
     {
         if (collision.transform.tag=="gate")
         {
             if (feverMode)
             {
                 Destroy(collision.transform.gameObject);
                 fractured = Instantiate(breakable,new Vector3( collision.transform.position.x, collision.transform.position.y-2.5f, collision.transform.position.z), quaternion.identity);
                 fractured.SetParent(GameObject.Find("Level").transform);
                 foreach (Transform i in fractured)
                 {
                     i.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-force,force),Random.Range(-force,force),Random.Range(-force,force)));
                 }
             }
             else
             {
                 GameManager.shared.Lose();

             }

        }
    }

     void Update()
     {
         if (Input.GetKeyDown(KeyCode.Space))
         {
             feverMode = true;
             GameManager.shared.speed = -30;
             fireparticle1.SetActive(true);
             fireparticle2.SetActive(true);
         }
     }

     void OnTriggerEnter(Collider collider)
     {
         if (collider.transform.tag=="dumbpolice")
         {
             FeverMove();
         }
     }

     void FeverMove()
     {
         feverMode = true;
        // GameManager.shared.speed
     }



 }
