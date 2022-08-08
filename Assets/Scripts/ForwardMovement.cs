using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =
            transform.position +
            Vector3.forward *
            speed *
            Time.deltaTime;
    }
}