using UnityEngine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

public class GameOverSlimeTears : MonoBehaviour
{
    void Start()
    {
        this.transform.DOLocalMove(new Vector3(25f, -50f, 0f),0.7f).SetDelay(1f).SetLoops(-1, LoopType.Restart);
    }

    void Update()
    {
        
    }
}
