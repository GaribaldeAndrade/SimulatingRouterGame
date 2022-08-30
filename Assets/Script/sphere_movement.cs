using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class sphere_movement : MonoBehaviour
{
    const int CONST_VELOCITY = 1;
    private Vector3 velocity;
    private Rigidbody myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        int angle = Random.Range(0, 360);
        velocity = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
        myRigidbody.velocity = velocity * CONST_VELOCITY;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = myRigidbody.velocity.normalized;
        myRigidbody.velocity = velocity * CONST_VELOCITY;
    }
}
