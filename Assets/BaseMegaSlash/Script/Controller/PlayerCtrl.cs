// Project  Repository-BaseA
// FileName  PlayerCtrl.cs
// Author  AX
// Desc
// CreateAt  2025-09-08 15:09:57 
//


using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    public Image hpImg;

    public Text hpText;

    public Text damageText;

    public AxeCtrl axeCtrl;
    
    private int curHp;

    public void InitPlayer()
    {
        // hpImg.fillAmount = 1f;
        ShowUI();
    }

    public void ResetPlayer()
    {
        ShowUI();
        axeCtrl.Reset();
    }

    public void ShowUI()
    {
        curHp = A_PlayerManager.Instance.GetPlayHp();
        hpImg.fillAmount = curHp * 1f / A_PlayerManager.Instance.GetPlayMaxHp();
        // damageText.text = A_PlayerManager.Instance.GetPlayDamage() + "";
        hpText.text = curHp + "/" + A_PlayerManager.Instance.GetPlayMaxHp();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.name.Contains("Bullet")) return;
        int damage = other.transform.parent.transform.parent.GetComponent<EnemyCtrl>().emyAttack;
        BeAttack(damage);
        DOTween.Kill(other.gameObject.transform);
        Destroy(other.gameObject,0.1f);
    }

    private void BeAttack(int damage)
    {
        A_PlayerManager.Instance.BeAttacked(damage);
        ShowUI();
        if (curHp <= 0)
        {
            A_BattleAxeManager.Instance.ShowLosePop();
        }
    }
}