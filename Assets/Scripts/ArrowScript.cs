using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Components;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowScript : NetworkBehaviour
{
    private void Start()
    {
        if (IsClient && IsOwner)
            DestroyServerRpc();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsClient && IsOwner)
        {
            Destroy(GetComponent<NetworkRigidbody>());
            Destroy(GetComponent<Rigidbody>());
        }
    }

    [ServerRpc]
    private void DestroyServerRpc()
    {
        Destroy(gameObject, 20);
    }
}
