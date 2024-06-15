using UnityEngine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

public class GreenTitleSlime : MonoBehaviour
{
    
    void Start()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(this.transform.DOLocalMove(new Vector3(260f, 50f, 0f),0.7f).SetLoops(-1, LoopType.Yoyo));
        sequence.Join(this.transform.DOPunchScale(new Vector3(0.15f, 0.15f),1.4f).SetLoops(-1, LoopType.Restart));
    }

    void Update()
    {
        
    }
}

