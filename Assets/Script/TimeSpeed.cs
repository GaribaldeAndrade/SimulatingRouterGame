using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimeSpeed : MonoBehaviour
{
    
    public static float modifiedScale = 1;

    public void doubleTime()
    {
        if (modifiedScale == 1) {
            modifiedScale = 20;
        }
        else 
        {
            modifiedScale = 1;
        }
    }

    void Update()
    {
        Time.timeScale = modifiedScale;
    }
}
