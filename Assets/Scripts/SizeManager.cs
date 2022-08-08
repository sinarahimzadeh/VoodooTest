using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeManager : MonoBehaviour
{
    public static SizeManager instace;

    public  Vector3 globalPositionOfContact;
    public float xScale,currentScale;
    //how fast it grows 
    public float growthRate;
    //how much the pile increases each time
    public float maxInc;

    //determines wether the pile should grow or shrink
    public bool grow,shrink;
    // Start is called before the first frame update
    void Start()
    {
        instace = this;
        xScale = gameObject.transform.localScale.x;
        currentScale = xScale;
    }
  public void OnCollisionEnter(Collision collision){
      if(collision.transform.tag=="spike")
      globalPositionOfContact = collision.contacts[0].point;
   }
    // Update is called once per frame
      void FixedUpdate()
    {
        if (grow)
        {
            if (xScale-currentScale<=maxInc)
            {
                gameObject.transform.localScale=new Vector3(transform.localScale.x,xScale,transform.localScale.z);
                xScale += growthRate;
            }
            else
            {
                grow = false;
                currentScale = xScale;
            }
        
        }
        
        if (shrink)
        {
            if (currentScale-xScale<=maxInc)
            {
                gameObject.transform.localScale=new Vector3( transform.localScale.x,xScale,transform.localScale.z);
                xScale -= growthRate;
            }
            else
            {
                shrink = false;
                currentScale = xScale;
            }
        
        }
     
    }

    public void Grow()
    {
        grow = true;
    }

    public void Shrink()
    {
        shrink = true;

    }

}
