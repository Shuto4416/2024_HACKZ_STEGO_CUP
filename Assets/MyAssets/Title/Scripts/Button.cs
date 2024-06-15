
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
    [SerializeField] private Image SceneImage;
    [SerializeField] EventSystem eventSystem;
    GameObject selectedObject;
    GameObject currentSelectedGameObject = null;




    void Start()
    {
        Color color = SceneImage.color;
        color.a = 0f;
        SceneImage.color = color;
    }

    public enum SCENES
    {
        InGame,
        GameOver,
        Result,
        Title,
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
                SceneImage.DOFade(1f,1f)
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
        .OnComplete(() => transform.DOScale(ShrinkScale,ScaleChangeTime))
        .OnComplete(() => SceneManager.LoadScene($"{scene}"));
    }
}