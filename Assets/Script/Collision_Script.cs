using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Collision_Script : MonoBehaviour
{
    public string fofocas = "";
    GameObject transferData;
    public Material[] materials;
    public MeshRenderer mr;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mr.material = materials[0];
    }

   void OnCollisionEnter(Collision collisionInfo) 
   {
        if (collisionInfo.collider.tag == "ball")
        {
            if (fofocas.Length > 0)
            {
                transferData = collisionInfo.gameObject;
            }

        }
   }

   void LateUpdate()
   {
       if (transferData != null)
       {
           mr.material = materials[0];
           fofocas = "";
           transferData.GetComponent<MeshRenderer>().material = materials[1];
           transferData.GetComponent<Collision_Script>().fofocas = "fofoquinhas";
           transferData = null;
       }
   }
}
