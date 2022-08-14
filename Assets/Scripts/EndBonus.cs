using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndBonus : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] BonusPlatform[] platforms;
    [SerializeField] private float range;
    void Start() 
    {
        for (int i = 0; i < platforms.Length; i++) {
            if (i>0)
            {
                range=i/2;
            }
            platforms[i].SetBonusText("X " + (i * 0.2f + 1).ToString("F1"));
            platforms[i].gate1.transform.position = new Vector3(platforms[i].gate1.transform.position.x+Random.Range(0,range),platforms[i].gate1.transform.position.y,platforms[i].gate1.transform.position.z);
            platforms[i].gate2.transform.position = new Vector3(platforms[i].gate2.transform.position.x-Random.Range(0,range),platforms[i].gate2.transform.position.y,platforms[i].gate2.transform.position.z);

            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
