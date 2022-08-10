using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHandler : MonoBehaviour
{
    public bool hit;
    [SerializeField] private Animator _animator;
    void OnTriggerEnter(Collider collider){
                   if(collider.transform.tag=="add"){
                    hit=true;  
                    SizeManager.instace.Grow();
                    Destroy(collider.transform.gameObject);
                   }

                   if (collider.transform.tag=="win")
                   {
                       GameManager.shared.Win();
                   }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.shared.lose)
        {
            _animator.SetBool("die",true);

        }
        if (GameManager.shared.win)
        {
            _animator.SetBool("win",true);

        }
        if (GameManager.shared.move)
        {
            _animator.enabled = true;
        }
       
    }
}
