using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkedGameHandler : NetworkBehaviour
{
    public GameObject CoinPrefab;
    public Transform CoinSpawnPoint;
    private NetworkObject m_SpawnedNetworkObject;
    public override void OnNetworkSpawn()
    {
        if (!IsServer) { return; }



        base.OnNetworkSpawn();

        Debug.Log("Network is spawned.");

        GameObject coinObj= Instantiate(CoinPrefab, CoinSpawnPoint);



        m_SpawnedNetworkObject = coinObj.GetComponent<NetworkObject>();
        m_SpawnedNetworkObject.Spawn();



    }
    public override void OnNetworkDespawn()
    {
        base.OnNetworkDespawn();


    }





}
