using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DORotate(new Vector3(360,0,90), 1f, RotateMode.FastBeyond360).SetLoops(-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
