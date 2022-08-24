using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BonusPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] particles;
    public GameObject Standleft, StandRight;
    void Start()
    {
     

    }

 
    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBonusText(string text) {
        gameObject.GetComponentsInChildren<TextMeshPro>()[0].text = text;

        
    }

    public void StartParticles() {
        particles[0].SetActive(true);
        particles[1].SetActive(true);

    }
    private void OnTriggerEnter(Collider other)
    {
        StartParticles();
    }



}
