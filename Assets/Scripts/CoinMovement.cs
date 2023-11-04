using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.Netcode;

public class CoinMovement : NetworkBehaviour
{
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        transform.DOLocalMoveY(1.5f, 1f).SetLoops(-1, LoopType.Yoyo);
    }
}
