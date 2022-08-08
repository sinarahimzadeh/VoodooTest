using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed,sideSpeed;
     private Vector3 mousePos;

    private float multiplier = 0.1f;
    private Touch touch;

    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {

        if(Input.GetMouseButtonDown(0))
            mousePos = Input.mousePosition;    
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
        if (GameManager.shared.isTestingOnDesktop)
        {
            float horizentalAxis = Input.GetAxis("Horizontal");
            transform.position = new Vector3(
                         transform.position.x +  speed * horizentalAxis * multiplier,
                         transform.position.y,
                         transform.position.z
                    );
        }
        else
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    transform.position = new Vector3(
                         transform.position.x + touch.deltaPosition.x * speed * multiplier,
                         transform.position.y,
                         transform.position.z
                    );
                }
            }
        }

    }

    void moveSideWays(int side)
    {
        transform.Translate(side*sideSpeed*Time.deltaTime,0,0);
    }
     
}
