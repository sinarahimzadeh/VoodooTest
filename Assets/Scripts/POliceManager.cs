using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class POliceManager : MonoBehaviour
{
   [SerializeField]  private Animator animator;

   [SerializeField] private GameObject target;

   [SerializeField] private float aproachSpeed,speed;

   [SerializeField] private float rangeX, rangez,randomXposition,randomZposition;

    [SerializeField] GameObject pile;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("xpositionGenerator",2,2);
    }

    void xpositionGenerator()
    {
        randomXposition = Random.Range(-rangeX, rangeX);
        randomZposition = Random.Range(-rangez, rangez);

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.shared.move)
        {
            animator.SetInteger("state",1);
            transform.position = Vector3.MoveTowards(transform.position,new Vector3(randomXposition,transform.position.y,transform.position.z-randomZposition),speed*Time.deltaTime);
            
        }
        else if (GameManager.shared.lose)
        {

            if (!GameManager.shared.isPolicPulling) {
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * aproachSpeed);

            }

        }

        if (GameManager.shared.boe)
        {
            animator.SetBool("boe",true);
            speed = 0;
            transform.SetParent(GameObject.Find("Level").transform);
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "pile") {

            GameManager.shared.isPolicPulling = true;
            animator.SetBool("isPulling", true);
;            transform.DOMoveZ(transform.position.z-6, 1);
            pile.transform.DOMoveZ(pile.transform.position.z - 6, 1).OnComplete(() => {
                GameManager.shared.MoveOut();
            });

        }
    }
}
