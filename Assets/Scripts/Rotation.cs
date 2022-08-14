using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Vector3 rotation;
    [SerializeField] private float duration;
    void Start()
    {
        //transform.DORotate(
        //    rotation,
        //    duration
        //    )
        //    .SetLoops(-1,LoopType.Incremental).SetEase(Ease.Linear);
        transform.DOLocalRotate(rotation,
             duration,RotateMode.FastBeyond360
             )
             .SetLoops(-1).SetEase(Ease.Linear);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
