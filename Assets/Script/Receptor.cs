using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receptor : MonoBehaviour
{
    public int counter = 0;
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "ball" && counter < 10)
        {
            GameObject ball = collisionInfo.gameObject;
            Collision_Script cs = ball.GetComponent<Collision_Script>();
            if (cs.fofocas.Length > 0)
            {
                cs.fofocas = "fofoquinha";
                cs.mr.material = cs.materials[0];
                counter++;
                if (counter >= 10)
                {
                    GetComponent<MeshRenderer>().material = cs.materials[1];
                    TimeSpeed.modifiedScale = 0;
                }
          

            }
        }
    }
}
