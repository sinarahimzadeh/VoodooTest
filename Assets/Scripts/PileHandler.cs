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
    [SerializeField] Camera mainCamera;
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
                 if (!GameManager.shared.boe)
                 {
                     collision.gameObject.GetComponentInChildren<ParticleSystem>().Play();
                     mainCamera.DOShakeRotation(0.5f,5,5,30,true);

                     GameManager.shared.Lose();
                 }
                 else
                 {
                    collision.gameObject.GetComponentInChildren<ParticleSystem>().Play();

                    GameManager.shared.Win();
                    
                 }


             }

        }
         if (collision.transform.tag=="dumbpolice")
         {
          GameManager.shared.FeverMove();
          GameManager.shared.Invoke("NormalMode",fevermodeTime);
            collision.gameObject.transform.DOMoveY(5, 0.25f).SetLoops(2,LoopType.Yoyo);
            collision.gameObject.GetComponentInChildren<Animator>().SetBool("isDead",true);

         }
    }



  

  



 }
