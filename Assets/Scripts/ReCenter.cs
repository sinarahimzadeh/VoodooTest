using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ReCenter : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform playerTransform;
    [SerializeField] float duration;
    [SerializeField] float delay;

    private void Start()
    {
        DoReCenter();
    }
    private void LateUpdate()
    {
        if (playerTransform.position.x != transform.position.x) {
            transform.DOMoveX(playerTransform.position.x, duration).SetDelay(delay);

        }
    }
    public void DoReCenter() {
        transform.DOMoveX(playerTransform.position.x, duration).SetDelay(delay);
    }
}
