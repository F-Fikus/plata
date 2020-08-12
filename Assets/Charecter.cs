using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charecter : MonoBehaviour
{
    public float speedMove;
    public float jumpPower;
    private float gravityForce;
    private Vector3 moveVector;
    private CharacterController ch_controller;
    private MobileController mContr;
    void Start()
    {
        ch_controller = GetComponent<CharacterController>();
        mContr = GameObject.FindGameObjectWithTag("Joystick").GetComponent<MobileController>();
    }

    // Update is called once per frame 
    void Update()
    {
        CharacterMove();
        GamingGravity();
    }
    private void CharacterMove()
    {
        moveVector = Vector3.zero;
        moveVector.x = mContr.Horizontal() * speedMove;
        moveVector.z = mContr.Vertical() * speedMove;

        

        
        if (Vector3.Angle(Vector3.forward, moveVector) > 1f || Vector3.Angle(Vector3.forward, moveVector) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, moveVector, speedMove, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }
        moveVector.y = gravityForce;
        ch_controller.Move(moveVector * Time.deltaTime);
    }
    private void GamingGravity()
    {
        if (!ch_controller.isGrounded)gravityForce -= 20f * Time.deltaTime;
        else gravityForce = -1f;
       
    }
}