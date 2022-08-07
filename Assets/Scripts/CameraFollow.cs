using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    public GameObject target;

    private Vector3 offSet;
    // Start is called before the first frame update
    void Start()
    {
        offSet = target.transform.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position=new Vector3(transform.position.x,target.transform.position.y-offSet.y,target.transform.position.z-offSet.z);
    }
}
