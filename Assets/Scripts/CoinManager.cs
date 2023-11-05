using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.Netcode;
using StarterAssets;

public class CoinManager : NetworkBehaviour
{
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        transform.DOLocalMoveY(1.5f, 1f).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (!IsServer) return;

        if (other.TryGetComponent(out ThirdPersonController pController))
        {
            pController.takeDamage();
        }

        NetworkObject.Despawn();
    }
}
