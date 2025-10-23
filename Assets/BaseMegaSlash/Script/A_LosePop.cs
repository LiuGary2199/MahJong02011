// Project  Repository-BaseA
// FileName  A_LosePop.cs
// Author  AX
// Desc
// CreateAt  2025-09-08 16:09:13 
//


using System;
using UnityEngine;
using UnityEngine.UI;

public class A_LosePop : MonoBehaviour
{
    public Button replayBtn;

    public Text levelText;

    public Text proText;

    public Image sliderImg;


    private void Start()
    {
        replayBtn.onClick.AddListener(ClosePanel);
    }


    private void OnEnable()
    {
        ShowUI();
    }


    private void ShowUI()
    {
        levelText.text = A_LevelManager.Instance.GetGameLevel() + "";
        float leftPro = A_LevelManager.Instance.GetLeftPro();
        sliderImg.fillAmount = leftPro;
        proText.text = Mathf.Round(leftPro * 100) + "%";
    }


    private void ClosePanel()
    {
        A_AudioManager.Instance.PlaySound("Click");
        A_BattleAxeManager.Instance.ReplayGame();
        gameObject.SetActive(false);
    }
}