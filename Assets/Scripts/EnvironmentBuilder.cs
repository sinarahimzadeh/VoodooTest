using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnvironmentBuilder : MonoBehaviour
{
    public GameObject apartment;

    // Start is called before the first frame update
    void Start()
    {
        Build();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Build()
    {
        for (int i = 0; i < 150; i++) {
            if (i > 130)
            {
                GameObject newApartment = Instantiate(apartment, new Vector3(UnityEngine.Random.Range(0, 70), UnityEngine.Random.Range(-0f, -30f), i * 7), quaternion.identity);
                GameObject newApartment2 = Instantiate(apartment, new Vector3(UnityEngine.Random.Range(0, -70), UnityEngine.Random.Range(-0f, -45f), i * 7), quaternion.identity);

                newApartment.transform.SetParent(gameObject.transform);
                newApartment2.transform.SetParent(gameObject.transform);
            }
            else {
                GameObject newApartment = Instantiate(apartment, new Vector3(UnityEngine.Random.Range(25, 70), UnityEngine.Random.Range(-0f, -30f), i * 7), quaternion.identity);
                GameObject newApartment2 = Instantiate(apartment, new Vector3(UnityEngine.Random.Range(-25, -70), UnityEngine.Random.Range(-0f, -45f), i * 7), quaternion.identity);

                newApartment.transform.SetParent(gameObject.transform);
                newApartment2.transform.SetParent(gameObject.transform);
            }
      

        }

    }
}
