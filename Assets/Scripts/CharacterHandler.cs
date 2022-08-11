using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHandler : MonoBehaviour
{
    [SerializeField] private Animator _animator;

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
    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "add")
        {
            SizeManager.instace.Grow();
            Destroy(collider.transform.gameObject);
        }

        else if (collider.transform.tag == "win")
        {
            GameManager.shared.Win();
        }
    }

    
}
