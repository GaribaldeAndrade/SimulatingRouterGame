using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Collision_Script : MonoBehaviour
{
    public bool isOn = false;
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
            if (isOn)
            {
                transferData = collisionInfo.gameObject;
            }

        }
   }

    void LateUpdate()
    {
        if (transferData != null && !transferData.GetComponent<Collision_Script>().isOn)
        {
            mr.material = materials[0];
            isOn = false;
            transferData.GetComponent<MeshRenderer>().material = materials[1];
            transferData.GetComponent<Collision_Script>().isOn = true;
            transferData = null;
        }
    }
}
