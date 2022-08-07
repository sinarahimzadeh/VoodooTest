using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileHandler : MonoBehaviour
{
    public float yDistance,maxYdistance;
public Rigidbody rigidbody;
private bool fall;
public bool move;
[SerializeField] private Vector3 mousePos;
[SerializeField] private float fieldSpeed,fieldmax,fieldmin;
public float maxY,currentY,upRate,forwardSpeed,sideSpeed ; 
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
        if(move)_moveForward();
        if(Input.GetMouseButtonDown(0)){
            mousePos = Input.mousePosition;

        }
         if(Input.GetMouseButtonUp(0)){

            if(states==States.onRail&&yDistance<-maxYdistance){
            currentY=transform.position.y;
            jump();
                    }
                }
        if (Input.GetMouseButton(0))
            {
            
                if (Input.mousePosition.x-mousePos.x>100)
                {
                    moveSideWays(1);
                }
                else if(mousePos.x-Input.mousePosition.x>100)
                {
                    moveSideWays(-1);
                }
                if(mousePos.y-Input.mousePosition.y>maxYdistance){
            yDistance =Input.mousePosition.y-mousePos.y;
            }
            }
        
        if(states==States.inAir){
           if( currentY+maxY>=transform.position.y){
               forwardSpeed=8;
            transform.position=new Vector3(transform.position.x,transform.position.y+upRate,transform.position.z);
            if (Camera.main.fieldOfView<fieldmax){Camera.main.fieldOfView+=0.01f;}
            Camera.main.fieldOfView+=fieldSpeed;
           }
           else{
               states=States.falling;
           }
        }

        if(states==States.falling){if (Camera.main.fieldOfView>fieldmin){Camera.main.fieldOfView-=fieldSpeed;}
}

    
    }

    public void jump(){
        yDistance=0;
        states=States.inAir;
         rigidbody.AddForce(Vector3.up*force*Time.deltaTime);
         }

 void moveSideWays(int side)
    {
        transform.Translate(side*sideSpeed*Time.deltaTime,0,0);
    }
     void _moveForward()
    {
        transform.Translate( transform.forward * forwardSpeed * Time.deltaTime);
    }
}
