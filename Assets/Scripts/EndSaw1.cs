using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;
using DG.Tweening;

public class EndSaw1 : MonoBehaviour
{
    [SerializeField] private GameObject DISChain;
    [SerializeField] private GameObject saw;
    [SerializeField] private ObiSolver solver;
    [SerializeField] private Material material;

    [SerializeField] private GameObject test;

    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        transform.DOScale(new Vector3(0.44f, 2, 1.93f), 0.3f).OnComplete(() => {

            gameObject.GetComponent<Animator>().enabled = true;
            DISChain.GetComponent<ObiRope>().tearingEnabled = true;
            DISChain.GetComponent<ObiRope>().tearResistanceMultiplier = 10;
            test.layer = 10;
            camera.cullingMask = LayerMask.GetMask("Default");

            transform.DOScale(new Vector3(0.44f, 2, 1.93f), 0.3f).SetDelay(0.3f).OnComplete(() => {
                saw.SetActive(false);
                //DISChain.GetComponent<ObiRope>().AddForce(new Vector3(0, Random.Range(-10, -20), 0), ForceMode.Impulse);
                solver.gravity = new Vector3(0, -25, 0);

            });

            transform.DOScale(Vector3.zero, 0.3f).SetDelay(0.6f);
            

            DISChain.GetComponent<ObiRope>().AddForce(new Vector3(0, Random.Range(50, 60), 0), ForceMode.Impulse);

        });
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           


        }
    }
}
