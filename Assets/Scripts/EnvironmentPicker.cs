using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnvironmentPicker : MonoBehaviour
{
    [SerializeField] GameObject env1;
    [SerializeField] GameObject env2;
    [SerializeField] GameObject env3;
    [SerializeField] GameObject env4;

    [SerializeField] Material sky1;
    [SerializeField] Material sky2;
    [SerializeField] Material sky3;
    [SerializeField] Material sky4;

    [SerializeField] Color color1;
    [SerializeField] Color color2;
    [SerializeField] Color color3;
    [SerializeField] Color color4;
    int env = 0;


    // Start is called before the first frame update
    void Start()
    {

        env = PlayerPrefs.GetInt("lvl") % 4;



        switch (env)
        {
            case 0:
                
                env1.SetActive(true);
                Instantiate(env1, new Vector3(0,0,0), quaternion.identity);
                RenderSettings.skybox = sky1;
                RenderSettings.fogColor = color1;

                break;
            case 1:
                Instantiate(env2, new Vector3(0, 0, 0), quaternion.identity);
                RenderSettings.skybox = sky2;
                RenderSettings.fogColor = color2;


                break;
            case 2:
                Instantiate(env3, new Vector3(0, 0, 0), quaternion.identity);
                RenderSettings.skybox = sky3;
                RenderSettings.fogColor = color3;


                break;
            case 3:
                Instantiate(env4, new Vector3(0, 0, 0), quaternion.identity);
                RenderSettings.skybox = sky4;
                RenderSettings.fogColor = color4;

                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
