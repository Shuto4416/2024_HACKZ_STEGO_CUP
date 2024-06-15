using UnityEngine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

public class BlueTitleSlime : MonoBehaviour
{
    
    void Start()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(this.transform.DOLocalMove(new Vector3(121f, 30f, 0f),1f).SetLoops(-1, LoopType.Yoyo));
        sequence.Join(this.transform.DOPunchScale(new Vector3(0.15f, 0.15f),2f).SetLoops(-1, LoopType.Restart));
    }

    void Update()
    {
        
    }
}
