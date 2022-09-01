using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mensageiro : MonoBehaviour
{
    public int counter = 10;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "ball" && counter > 0)
        {
            GameObject ball = collisionInfo.gameObject;
            Collision_Script cs = ball.GetComponent<Collision_Script>();
            if (!(cs.fofocas.Length > 0))
            {
                cs.fofocas = "fofoquinha";
                cs.mr.material = cs.materials[1];
                counter--;
                if (counter == 0)
                    GetComponent<MeshRenderer>().material = cs.materials[2];
            }
        }
    }
}
