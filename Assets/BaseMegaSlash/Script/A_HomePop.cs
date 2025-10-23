// Project  Repository-BaseA
// FileName  A_HomePop.cs
// Author  AX
// Desc
// CreateAt  2025-09-05 08:09:35 
//


using System;
using UnityEngine;
using UnityEngine.UI;

public class A_HomePop : MonoBehaviour
{
    public Button startBtn;

    public Button setBtn;

    public Button shopBtn;

    public Text coinText;


    private void Start()
    {
        startBtn.onClick.AddListener(StartGame);

        setBtn.onClick.AddListener(OpenSetPop);

        shopBtn.onClick.AddListener(OpenShopPop);

        InitData();
    }

    private void InitData()
    {
        ShowUI();
    }

    public void ShowUI()
    {
        coinText.text = A_PlayerManager.Instance.GetCoin() + "";
    }


    private void StartGame()
    {
        A_AudioManager.Instance.PlaySound("Click");
        A_BattleAxeManager.Instance.ShowGamePop();
    }

    private void OpenSetPop()
    {
        A_AudioManager.Instance.PlaySound("Click");
        A_BattleAxeManager.Instance.ShowSetPop(false);
    }

    private void OpenShopPop()
    {
        A_AudioManager.Instance.PlaySound("Click");
        A_BattleAxeManager.Instance.ShowShopPop();
    }
}