using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningManager : MonoBehaviour
{
   public bool hit;
 [SerializeField]  List<Renderer> warning = new List<Renderer>();
 [SerializeField] private Material green;
      void OnTriggerEnter(Collider collider)
   {
      if (collider.transform.name=="Character"&&!GameManager.shared.lose)
      {
         foreach (var i in warning)
         {
            hit = true;

            i.material.color = green.color;
         }
      }
   }
}
