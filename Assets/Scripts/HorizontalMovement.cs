using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed;

    private float multiplier = 2f;
    private Touch touch;

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.shared.isTestingOnDesktop)
        {
            float horizentalAxis = Input.GetAxis("Horizontal");
            print(horizentalAxis);
            transform.position = new Vector3(
                         transform.position.x +  speed * horizentalAxis * multiplier,
                         transform.position.y,
                         transform.position.z);
            if (transform.position.x >= 11)
            {
                transform.position = new Vector3(11, transform.position.y, transform.position.z);
            }
            if (transform.position.x <= -11)
            {
                transform.position = new Vector3(-11, transform.position.y, transform.position.z);
            }
        }
        else
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    //transform.position = new Vector3(
                    //     transform.position.x + touch.deltaPosition.x * speed * multiplier,
                    //     transform.position.y,
                    //     transform.position.z);

                    transform.Translate(new Vector3(
                        touch.deltaPosition.x *Time.deltaTime* speed * multiplier,
                        0,
                        0));
                    if (transform.position.x >= 11)
                    {
                        transform.position = new Vector3(11, transform.position.y, transform.position.z);
                    }
                    if (transform.position.x <= -11)
                    {
                        transform.position = new Vector3(-11, transform.position.y, transform.position.z);
                    }
                }
            }
        }

    }
}
