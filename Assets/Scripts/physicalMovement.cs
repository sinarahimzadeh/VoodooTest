using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physicalMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rigidbody.AddForce(transform.forward*100000*Time.deltaTime);

        }
    }
}
