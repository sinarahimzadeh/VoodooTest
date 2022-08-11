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
        transform.DORotate(
            rotation,
            duration,
            RotateMode.FastBeyond360)
            .SetLoops(-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
