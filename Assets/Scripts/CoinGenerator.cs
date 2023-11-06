using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class CoinGenerator : NetworkBehaviour
{
    [SerializeField]
    private Transform coinLoc;

    [SerializeField]
    private Transform coinPrefab;

    private void Start()
    {
        NetworkManager.Singleton.OnServerStarted += SpawnCoin;
    }

    private void SpawnCoin()
    {
        NetworkManager.Singleton.OnServerStarted -= SpawnCoin;
        Transform spawnedCoin = Instantiate(coinPrefab, coinLoc.position, coinPrefab.rotation);
        spawnedCoin.GetComponent<NetworkObject>().Spawn(true);
    }
}
