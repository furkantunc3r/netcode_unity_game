using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerServerSideMovement : NetworkBehaviour
{

    [SerializeField]
    private float _speed = 1f;

    private Rigidbody rb;

    private PlayerInputs playerInputs;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        playerInputs = new();
        playerInputs.Enable();
    }



    private void Update()
    {
        Vector2 inputVectors = playerInputs.Player.Movement.ReadValue<Vector2>();


        if (IsServer && IsLocalPlayer)
        {

            Move(inputVectors);

        }
        else if (IsClient && IsLocalPlayer)
        {
            MoveServerRpc(inputVectors);
        }

    }

    private void Move(Vector2 inputVectors)
    {

        Vector3 calculateMoveVector = new Vector3(inputVectors.x * _speed * Time.deltaTime,
                                   rb.velocity.y,
                                  inputVectors.y * _speed * Time.deltaTime);

        rb.velocity = calculateMoveVector;

    }


    [ServerRpc]
    private void MoveServerRpc(Vector2 inputVector)
    {

        Move(inputVector);


    }
}
