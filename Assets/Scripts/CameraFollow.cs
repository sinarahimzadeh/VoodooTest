using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    public GameObject target;
    public Transform character;
    private Vector3 offSet;

    void Start()
    {
        offSet = target.transform.position - transform.position;
    }
    void LateUpdate()
    {
        if (transform!=null)
        {
            transform.position = new Vector3(
                character.position.x,
                target.transform.position.y-offSet.y,
                target.transform.position.z-offSet.z);
        }
     
    }
}
