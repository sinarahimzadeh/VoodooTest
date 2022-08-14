using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POliceManager : MonoBehaviour
{
   [SerializeField]  private Animator animator;

   [SerializeField] private GameObject target;

   [SerializeField] private float aproachSpeed,speed;

   [SerializeField] private float rangeX, rangez,randomXposition,randomZposition; 
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
            transform.position = Vector3.MoveTowards (transform.position, target.transform.position, Time.deltaTime * aproachSpeed);
        }
        
    }
}
