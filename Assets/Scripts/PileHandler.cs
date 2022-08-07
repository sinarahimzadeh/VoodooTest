using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileHandler : MonoBehaviour
{
public Rigidbody rigidbody;
[SerializeField] private float force;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        rigidbody.AddForce(Vector3.up*force*Time.deltaTime);
        //hi
        
    }
}
