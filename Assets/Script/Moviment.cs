using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moviment : MonoBehaviour
{
  private BallController controller;


    public float moveSpeed = 1.0f;
    private float speed;
    public float sprintTime = 3.6f;
    private float currentSprintTime;

    private Vector3 axisVector;
    private Vector3 lookedAtPoint;
   
    Vector3 lastPosition;
    private Vector3 mousePosition;  // Start is called before the first frame update
    void Start()
    {
        speed = moveSpeed;
        controller = GetComponent<BallController>();

        currentSprintTime = sprintTime;
    }

    // Update is called once per frame
    void Update()
    {


        //Movement


        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 moveInput = new Vector3(horizontal, 0f, vertical);
        Vector3 moveVelocity = moveInput.normalized;
        //Sprint


        //animation
        axisVector = new Vector3(horizontal,0,vertical);
        lookedAtPoint = mousePosition;
        


        if (Input.GetKey(KeyCode.LeftShift) && currentSprintTime  > 0)
        {
            speed = moveSpeed;
            moveVelocity = moveVelocity * speed;
            controller.Move(moveVelocity);
            currentSprintTime -= Time.deltaTime;
        }
        else
        {
            moveVelocity = moveVelocity * speed;
            controller.Move(moveVelocity);
            //Reset Speed
            speed = moveSpeed;
            currentSprintTime = sprintTime;
        }
    }
}
