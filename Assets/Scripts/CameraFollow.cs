using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    public GameObject target;

    public Vector3 offSet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position=new Vector3(transform.position.x,target.transform.position.y-offSet.y,target.transform.position.z-offSet.z);
    }
}
