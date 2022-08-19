using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFollow : MonoBehaviour
{
    [SerializeField] private GameObject pile;

    [SerializeField] private bool right;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (right)
        {
            transform.position = new Vector3(pile.transform.position.x+pile.transform.localScale.x,transform.position.y,transform.position.z);
        }
        else
        {
            transform.position = new Vector3(pile.transform.position.x-pile.transform.localScale.x,transform.position.y,transform.position.z);

        }
    }
}
