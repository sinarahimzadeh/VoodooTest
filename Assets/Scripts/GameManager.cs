using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public bool isTestingOnDesktop = false;
    public bool move;
    public static GameManager shared;
    // Start is called before the first frame update
    void Start()
    {
        shared = this;
    }

   public void Move()
    {
        move = true;
    }

   public void Lose()
   {
       Invoke("Reset",1);
       move = false;
   }

   public void Win()
   {
       Invoke("Reset", 1);
       move = false;

   }

   public void Reset()
   {
       SceneManager.LoadScene(0);
   }

   // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Move();
        }
    }
}
