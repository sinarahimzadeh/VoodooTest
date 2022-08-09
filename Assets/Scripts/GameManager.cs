using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public bool isTestingOnDesktop = false;
    public bool move,lose;
    [SerializeField] private GameObject panel;
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

       move = false;
       lose = true;
       Invoke("resetPanel",1);
   }

   public void Win()
   {
       move = false;
        panel.SetActive(true);
   }

   void resetPanel()
   {
       panel.SetActive(true);

   }

   public void Reset()
   {
       SceneManager.LoadScene(0);
   }

   // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&!lose)
        {
            Move();
        }
    }
}
