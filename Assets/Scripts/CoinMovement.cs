using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CoinMovement : MonoBehaviour
{

    private void Start()
    {
        //TODO : SetEase eklenecek ve SetLoops açıklanacak.
        transform.DOLocalMoveY(1.5f, 1f).SetLoops(-1,LoopType.Yoyo);
    }



}
