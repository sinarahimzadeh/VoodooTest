using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileHandler : MonoBehaviour
{
public Rigidbody rigidbody;
private bool fall;
public bool move;
[SerializeField] private Vector3 mousePos;

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
        
        if (Input.GetMouseButton(0))
            {
                if (Input.mousePosition.x>mousePos.x)
                {
                    moveSideWays(1);
                }
                else if(Input.mousePosition.x<mousePos.x)
                {
                    moveSideWays(-1);
                }
            }
        if(Input.GetMouseButtonDown(1)){
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

 void moveSideWays(int side)
    {
        transform.Translate(side*sideSpeed*Time.deltaTime,0,0);
    }
     void _moveForward()
    {
        transform.Translate( transform.forward * forwardSpeed * Time.deltaTime);
    }
}
