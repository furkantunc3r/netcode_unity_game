using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Components;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowScript : NetworkBehaviour
{
    private NetworkObject m_SpawnedObject;

    private void Start()
    {
        m_SpawnedObject = GetComponent<NetworkObject>();
        if (IsServer)
            StartCoroutine(DespawnTimer());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsClient && IsOwner)
        {
            Destroy(GetComponent<NetworkRigidbody>());
            Destroy(GetComponent<Rigidbody>());
        }
    }

    private IEnumerator DespawnTimer()
    {
        yield return new WaitForSeconds(20);
        m_SpawnedObject.Despawn();
    }
}
