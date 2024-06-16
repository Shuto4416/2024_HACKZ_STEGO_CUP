using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

/// <summary>
/// タイトル画面におけるボタンの動きを管理するクラス
/// </summary>
public class Button : MonoBehaviour
{
    float ExpandingScale = 1.1f;
    float ShrinkScale = 1f;
    float ScaleChangeTime = 0.5f;
    [SerializeField] private SCENES scene;
    [SerializeField] private Button StartButton;
    [SerializeField] private Button MaterialButton;
    //[SerializeField] private Image SceneImage;
    [SerializeField] private Image GlasslandImage;
    [SerializeField] private Image MountainImage1;
    [SerializeField] private Image MountainImage2;
    [SerializeField] private Image GlassImage;
    [SerializeField] private Image SlimeImage;
    [SerializeField] private Image SkyImage;
    [SerializeField] EventSystem eventSystem;
    GameObject selectedObject;
    GameObject currentSelectedGameObject = null;




    void Start()
    {
        var sequence = DOTween.Sequence();
            sequence.Append(SlimeImage.transform.DOLocalMove(new Vector3(0f,900f,0f),1f));
            sequence.Join(GlassImage.transform.DOLocalMove(new Vector3(-365f, -900f, 0f),1f).SetDelay(0.05f));
            sequence.Join(MountainImage2.transform.DOLocalMove(new Vector3(180f, -870f, 0f),1f).SetDelay(0.1f));
            sequence.Join(MountainImage1.transform.DOLocalMove(new Vector3(-180f, -900f, 0f),1f).SetDelay(0.15f));
            sequence.Join(GlasslandImage.transform.DOLocalMove(new Vector3(0f, -700f, 0f),1f).SetDelay(0.2f));
            sequence.Join(SkyImage.transform.DOLocalMove(new Vector3(0f, -500f, 0f),0.5f).SetDelay(0.25f));
        /*Color color = SceneImage.color;
        color.a = 0f;
        SceneImage.color = color;*/
    }

    public enum SCENES
    {
        InGame,
        GameOver,
        Result,
        Title,
        MakeSlime,
    }

    void Update() 
    {
        GameObject currentObject = EventSystem.current.currentSelectedGameObject;
        if (currentObject)
        {
            currentSelectedGameObject = currentObject;
        } 
        else
        {
            if(currentSelectedGameObject != null)
            {
                EventSystem.current.SetSelectedGameObject(currentSelectedGameObject);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            selectedObject = eventSystem.currentSelectedGameObject.gameObject;
            if(selectedObject == StartButton.gameObject)
            {
                StartButton.StartOnClicked();
            }
            else if(selectedObject == MaterialButton.gameObject)
            {
                MaterialButton.MaterialOnClicked();
            }
        }
    }
    /// <summary>
    ///
    /// </summary>
    public void StartOnClicked()
    {        
        transform.DOScale(ExpandingScale,ScaleChangeTime)
        .SetEase(Ease.OutElastic)
        .OnComplete(() => 
        {
            transform.DOScale(ShrinkScale,ScaleChangeTime)
            .OnComplete(() => 
            {
                /*SceneImage.DOFade(1f,1f)*/
                var sequence = DOTween.Sequence();
                sequence.Append(SkyImage.transform.DOLocalMove(new Vector3(0f,0f,0f),0.5f));
                sequence.Join(GlasslandImage.transform.DOLocalMove(new Vector3(0f, -240f, 0f),1f).SetDelay(0.05f));
                sequence.Join(MountainImage1.transform.DOLocalMove(new Vector3(-180f, -370f, 0f),1f).SetDelay(0.1f));
                sequence.Join(MountainImage2.transform.DOLocalMove(new Vector3(180f, -340f, 0f),1f).SetDelay(0.15f));
                sequence.Join(GlassImage.transform.DOLocalMove(new Vector3(-365f, -150f, 0f),1f).SetDelay(0.2f));
                sequence.Join(SlimeImage.transform.DOLocalMove(new Vector3(0f, 0f, 0f),1f).SetDelay(0.25f))
                .OnComplete(()=>
                {
                    SceneManager.LoadScene($"{scene}");
                });
            });
        });
    }

    public void MaterialOnClicked()
    {
        transform.DOScale(ExpandingScale,ScaleChangeTime)
        .SetEase(Ease.OutElastic)
        .OnComplete(() => 
        {
            transform.DOScale(ShrinkScale,ScaleChangeTime)
            .OnComplete(() => 
            {
                var sequence = DOTween.Sequence();
                sequence.Append(SkyImage.transform.DOLocalMove(new Vector3(0f,0f,0f),0.5f));
                sequence.Join(GlasslandImage.transform.DOLocalMove(new Vector3(0f, -240f, 0f),1f).SetDelay(0.05f));
                sequence.Join(MountainImage1.transform.DOLocalMove(new Vector3(-180f, -370f, 0f),1f).SetDelay(0.1f));
                sequence.Join(MountainImage2.transform.DOLocalMove(new Vector3(180f, -340f, 0f),1f).SetDelay(0.15f));
                sequence.Join(GlassImage.transform.DOLocalMove(new Vector3(-365f, -150f, 0f),1f).SetDelay(0.2f));
                sequence.Join(SlimeImage.transform.DOLocalMove(new Vector3(0f, 0f, 0f),1f).SetDelay(0.25f))
                .OnComplete(()=>
                {
                    SceneManager.LoadScene($"{scene}");
                });
            });
        });
    }
}