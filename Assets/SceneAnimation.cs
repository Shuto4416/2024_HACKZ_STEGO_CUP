using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneAnimation : MonoBehaviour
{
    [SerializeField] private Image GlasslandImage;
    [SerializeField] private Image MountainImage1;
    [SerializeField] private Image MountainImage2;
    [SerializeField] private Image GlassImage;
    [SerializeField] private Image SlimeImage;
    [SerializeField] private Image SkyImage;
    [SerializeField] EventSystem eventSystem;
    void Start()
    {
        
    }

    void Update()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(SkyImage.transform.DOLocalMove(new Vector3(0f,0f,0f),0.5f));
        sequence.Join(GlasslandImage.transform.DOLocalMove(new Vector3(0f, -240f, 0f),1f).SetDelay(0.05f));
        sequence.Join(MountainImage1.transform.DOLocalMove(new Vector3(-180f, -370f, 0f),1f).SetDelay(0.1f));
        sequence.Join(MountainImage2.transform.DOLocalMove(new Vector3(180f, -340f, 0f),1f).SetDelay(0.15f));
        sequence.Join(GlassImage.transform.DOLocalMove(new Vector3(-365f, -150f, 0f),1f).SetDelay(0.2f));
        sequence.Join(SlimeImage.transform.DOLocalMove(new Vector3(0f, 0f, 0f),1f).SetDelay(0.25f));
    }
}
