using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHandler : MonoBehaviour
{
    public bool hit;
    void OnTriggerEnter(Collider collider){
        if(collider.transform.tag=="add"){
        Destroy(collider.gameObject);
        hit=true;
        SizeManager.instace.Grow();}
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
