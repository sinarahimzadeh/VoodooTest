using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileHandler : MonoBehaviour
{
public Rigidbody rigidbody;

public static PileHandler instance; 
[SerializeField] private float force;
    public enum States
    {
        onRail,
        inAir,
    };

   public  States states= new States();
    // Start is called before the first frame update
    void Start()
    {
        instance=this;
     states=States.onRail;   
    }

     private void OnCollisionEnter(Collision other) {
        if (other.transform.tag=="rail"){states=States.onRail;}
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            if(states!=States.inAir)
            jump();

        }
        

    }

    public void jump(){
        states=States.inAir;
         rigidbody.AddForce(Vector3.up*force*Time.deltaTime);
         }
}
