using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject particle;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Character") {
           
            particle.SetActive(true);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            GameManager.shared.CoinCollected();
        }
    }
}
