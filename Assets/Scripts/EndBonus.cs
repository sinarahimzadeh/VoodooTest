using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndBonus : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] BonusPlatform[] platforms;
    void Start() 
    {
        for (int i = 0; i < platforms.Length; i++) {
            platforms[i].SetBonusText("X " + (i * 0.2f + 1).ToString("F1"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
