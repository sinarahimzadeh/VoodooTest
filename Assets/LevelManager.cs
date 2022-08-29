using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LoadScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadScene() {
        int levelIndex = PlayerPrefs.GetInt("lvl");
        if (levelIndex == 0) {
            levelIndex = 1;
        }
        if (levelIndex >= 14)
        {
            SceneManager.LoadScene(14);

        }
        else { SceneManager.LoadScene(levelIndex); }


        TinySauce.OnGameStarted(levelIndex.ToString());


    }
}
