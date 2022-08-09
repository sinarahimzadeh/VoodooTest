using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
     private Vector3 mousePos;
     [SerializeField] private float leftBoundry, rightBoundry;
     [SerializeField] private float sideSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            mousePos = Input.mousePosition;
        }
        if (GameManager.shared.move)
        {
            if (Input.GetMouseButton(0))
            {
                if (Input.mousePosition.x-mousePos.x>10)
                {
                    moveSideWays(1);
                }
                else if(mousePos.x-Input.mousePosition.x>10)
                {
                    moveSideWays(-1);
                }
            }

        }

        if (transform.position.x>=rightBoundry)
        {
            transform.position=new Vector3(rightBoundry,transform.position.y,transform.position.z);
        }
        if (transform.position.x<=leftBoundry)
        {
            transform.position=new Vector3(leftBoundry,transform.position.y,transform.position.z);
        }
        
    }
    
    
    void moveSideWays(int side)
    {
        transform.Translate(side*sideSpeed*Time.deltaTime,0,0);
    }

}
