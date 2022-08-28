using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DumbPolice : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    [SerializeField] ForwardMovement fm;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null) {
            transform.DOMoveX(target.transform.position.x, 1.5f).SetDelay(0.4f);
            fm.enabled = true;

        }
    }
}
