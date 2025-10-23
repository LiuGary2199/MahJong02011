// Project  Repository-BaseA
// FileName  A_ShopPop.cs
// Author  AX
// Desc
// CreateAt  2025-09-10 09:09:08 
//


using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class A_ShopPop : MonoBehaviour
{
    public Button damageBtn;

    public Button hpBtn;

    public Button closeBtn;

    public Text hpCostText;

    public Text damageCostText;

    public Text curHpText;

    public Text curDamageText;

    public GameObject windowPop;

    public GameObject hpMask;

    public GameObject damageMask;

    private readonly List<int> _costList = new()
    {
        10, 50, 100, 200, 300, 500, 800, 1000, 1500, 2000
    };

    private int _curHpCost;

    private int _curDamageCost;


    private void Start()
    {
        damageBtn.onClick.AddListener(GetDamage);

        hpBtn.onClick.AddListener(GetHp);

        closeBtn.onClick.AddListener(ClosePop);
    }

    private void OnEnable()
    {
        ShowUI();
        UiAnim(windowPop.transform);
    }

    private void UiAnim(Transform UI)
    {
        for (int i = 0; i < UI.childCount; i++)
        {
            Transform Ui = UI.GetChild(i);
            Ui.DOKill();
            Ui.localScale = Vector2.zero;
            Ui.DOScale(Vector2.one, 0.5f).SetDelay(i * .1f);
        }
    }


    private void ShowUI()
    {
        _curHpCost = GetCost(BondSoulEvening.HowGas(AxeConstant.HpLevel));
        _curDamageCost = GetCost(BondSoulEvening.HowGas(AxeConstant.DamageLevel));
        hpCostText.text = _curHpCost + "";
        damageCostText.text = _curDamageCost + "";
        curHpText.text = A_PlayerManager.Instance.GetPlayMaxHp() + "";
        curDamageText.text = A_PlayerManager.Instance.GetPlayDamage() + "";
        hpMask.gameObject.SetActive(!CheckCoin(_curHpCost));
        damageMask.gameObject.SetActive(!CheckCoin(_curDamageCost));
        hpBtn.enabled = CheckCoin(_curHpCost);
        damageBtn.enabled = CheckCoin(_curDamageCost);
    }


    private int GetCost(int level)
    {
        return level > _costList.Count ? _costList[^1] : _costList[level - 1];
    }

    private void GetHp()
    {
        if (!CheckCoin(_curHpCost)) return;
        A_AudioManager.Instance.PlaySound("Up");
        A_PlayerManager.Instance.SubCoin(_curHpCost);
        A_PlayerManager.Instance.AddMaxHp();
        A_BattleAxeManager.Instance.RefreshTopBar();
        ShowUI();
    }

    private void GetDamage()
    {
        if (!CheckCoin(_curDamageCost)) return;
        A_AudioManager.Instance.PlaySound("Up");
        A_PlayerManager.Instance.SubCoin(_curDamageCost);
        A_PlayerManager.Instance.AddDamage();
        A_BattleAxeManager.Instance.RefreshTopBar();
        ShowUI();
    }


    private void ClosePop()
    {
        A_AudioManager.Instance.PlaySound("Click");
        gameObject.SetActive(false);
        A_BattleAxeManager.Instance.BackToHome();
    }

    private bool CheckCoin(int cost)
    {
        return A_PlayerManager.Instance.GetCoin() >= cost;
    }
}