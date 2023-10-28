using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField]
    private float speed = 0.05f;


    private Rigidbody myRigidbody;
    //private CharacterController cc;
    private float horizontal;
    private float vertical;

    private PlayerInputs InputActions;



    private void Awake()
    {

        myRigidbody = GetComponent<Rigidbody>();
        //cc=GetComponent<CharacterController>();

        InputActions = new();
        InputActions.Enable();


    }

    void Update()
    {
        if (!IsOwner) { return; }


        Vector2 InputVector = InputActions.Player.Movement.ReadValue<Vector2>();

        // horizontal = Input.GetAxis("Horizontal");
        horizontal = InputVector.x;

        //vertical = Input.GetAxis("Vertical");
        vertical = InputVector.y;
    }
    private void FixedUpdate()
    {

        if (!IsOwner) { return; }



        Move(myRigidbody);
        //Move(cc);

    }
    void Move(Rigidbody Rigidbody)
    {

        Vector3 newPos = new Vector3(horizontal * speed * Time.fixedDeltaTime,
                                       Rigidbody.velocity.y,
                                      vertical * speed * Time.fixedDeltaTime);

        Rigidbody.velocity = newPos;



    }
    //    void Move(CharacterController CharacterController)
    //{

    //    Vector3 newPos = new Vector3(horizontal * speed * Time.fixedDeltaTime,
    //                                   0,
    //                                  vertical * speed * Time.fixedDeltaTime);

    //    //Rigidbody.velocity = newPos;
    //    CharacterController.Move(newPos);


    //}
}
