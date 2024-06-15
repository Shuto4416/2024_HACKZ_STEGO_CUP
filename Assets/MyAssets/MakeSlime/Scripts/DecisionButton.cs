using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class DecisionButton : MonoBehaviour
{
    float ExpandingScale = 1.1f;
    float ShrinkScale = 1f;
    float ScaleChangeTime = 0.5f;
    [SerializeField] private SCENES scene;
    [SerializeField] private DecisionButton decisionButton;
    [SerializeField] private Image SceneImage;
    [SerializeField] EventSystem eventSystem;
    GameObject selectedObject;
    GameObject currentSelectedGameObject = null;




    void Start()
    {
        SceneImage.DOFade(0f,1f);
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
            if(selectedObject == decisionButton.gameObject)
            {
                decisionButton.OnClicked();
            }
        }
    }

    public void OnClicked()
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
}