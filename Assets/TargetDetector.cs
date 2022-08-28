using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDetector : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] DumbPolice dumbPolice;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Character") {
            dumbPolice.target = other.gameObject;
        }
    }
}
