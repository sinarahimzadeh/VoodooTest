using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndBonus : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] BonusPlatform[] platforms;
    [SerializeField]     private GameObject leftGate, rightGate;
[SerializeField]  private float distance,difference;
    void Start()
    {
        //distance = (10f / platforms.Length) / 2f;
        //difference = distance;
        for (int i = 0; i < platforms.Length; i++)
        {
            platforms[i].SetBonusText("X " + (i * 0.2f + 1).ToString("F1"));
            //leftGate = platforms[i].transform.Find("StandEndBonusleft").gameObject;
            //rightGate = platforms[i].transform.Find("StandEndBonusRight").gameObject;

            //leftGate.transform.localPosition = new Vector3(leftGate.transform.localPosition.x + Random.Range(distance - difference, difference), leftGate.transform.localPosition.y, leftGate.transform.localPosition.z);
            //rightGate.transform.localPosition = new Vector3(rightGate.transform.localPosition.x - Random.Range(distance - difference, difference), rightGate.transform.localPosition.y, rightGate.transform.localPosition.z);
            //distance += difference;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
