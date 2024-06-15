using UnityEngine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

public class YellowTitleSlime : MonoBehaviour
{
    
    void Start()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(this.transform.DOLocalMove(new Vector3(-20f, 30f, 0f),1.5f).SetLoops(-1, LoopType.Yoyo));
        sequence.Join(this.transform.DOPunchScale(new Vector3(0.15f, 0.15f),3f).SetLoops(-1, LoopType.Restart));
    }

    void Update()
    {
        
    }
}
