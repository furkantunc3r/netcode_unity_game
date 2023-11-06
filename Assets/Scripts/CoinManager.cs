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

        // FIX OBJECT DESPAWNED

        transform.DOLocalMoveY(1.5f, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        transform.DORotate(new Vector3(0f, 360f, 0f), 5f, RotateMode.FastBeyond360).SetLoops(-1).SetRelative().SetEase(Ease.Linear);
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
