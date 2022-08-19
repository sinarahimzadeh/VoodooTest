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
     [SerializeField] private float fevermodeTime;
     public bool feverMode;
     [SerializeField] private Transform breakable,fractured;
     void OnCollisionEnter(Collision collision)
     {
         if (collision.transform.tag=="gate")
         {
             if (GameManager.shared.feverMode)
             {
                 Destroy(collision.transform.gameObject);
                 fractured = Instantiate(breakable,new Vector3( collision.transform.position.x, collision.transform.position.y-2.5f, collision.transform.position.z), quaternion.identity);
                 fractured.SetParent(GameObject.Find("Level").transform);
                 
                 foreach (Transform i in fractured)
                 {
                     i.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-force,force),Random.Range(-force,force),Random.Range(0,force*5)));
                 }
             }
             else
             {
                 GameManager.shared.Lose();

             }

        }
         if (collision.transform.tag=="dumbpolice")
         {
          GameManager.shared.FeverMove();
          GameManager.shared.Invoke("NormalMode",fevermodeTime);
            collision.gameObject.transform.DOMoveY(5, 2f);
            collision.gameObject.GetComponentInChildren<Animator>().SetBool("isDead",true);

         }
    }



  

  



 }
