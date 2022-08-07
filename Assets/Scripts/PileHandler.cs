using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileHandler : MonoBehaviour
{
public Rigidbody rigidbody;
private bool fall;
public float maxY,currentY,upRate ; 
public static PileHandler instance; 
[SerializeField] private float force;
    public enum States
    {
        onRail,
        inAir,
        falling
    };

   public  States states= new States();
    // Start is called before the first frame update
    void Start()
    {
    
    instance=this;
     currentY=this.gameObject.transform.position.y;   
    }

     public void OnCollisionEnter(Collision other) {
        if (other.transform.tag=="rail"){states=States.onRail;}
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            if(states==States.onRail){
            currentY=transform.position.y;
            jump();}

        }
        
        if(states==States.inAir){
           if( currentY+maxY>=transform.position.y){
            transform.position=new Vector3(transform.position.x,transform.position.y+upRate,transform.position.z);
           }
           else{
               states=States.falling;
           }
        }

    
    }

    public void jump(){
        states=States.inAir;
         rigidbody.AddForce(Vector3.up*force*Time.deltaTime);
         }
}
