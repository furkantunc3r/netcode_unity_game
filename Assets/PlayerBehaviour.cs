using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : NetworkBehaviour
{
    private PlayerInput PlayerInput;
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        PlayerInput = GetComponent<PlayerInput>();

        if (IsClient && IsLocalPlayer)
        {
            PlayerInput.enabled = true;

            Debug.Log("Hello World");

        }
        else if (IsClient && !IsLocalPlayer)
        {
            PlayerInput.enabled=false;

        }
    }


}
