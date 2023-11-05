using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkedHealth : NetworkBehaviour
{
    public NetworkVariable<int> _health = new NetworkVariable<int>();

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        _health.Value = 100;
    }
}
