using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
   }

   public void Win()
   {
   }

   public void Reset()
   {
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
