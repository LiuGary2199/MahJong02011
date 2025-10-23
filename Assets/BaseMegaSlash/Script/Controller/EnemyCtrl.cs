// Project  Repository-BaseA
// FileName  EnemyCtrl.cs
// Author  AX
// Desc
// CreateAt  2025-09-05 11:09:03 
//


using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCtrl : MonoBehaviour
{
    public GameObject baseBullet;

    public int emyCurHp;

    public int emyAttack;

    public GameObject hpBar;

    public Image hpImg;

    public Text hpText;

    public Text damageText;

    private readonly int _emyBaseHp = 200;

    private readonly int _emyBaseDamage = 50;

    private readonly int _emyHpStep = 40;

    private readonly int _emyDamStep = 10;

    private int _emyMaxHp;

    private int _baseCoin;

    private bool _isEnable;

    private void Awake()
    {
        hpImg.fillAmount = 1f;
        hpBar.SetActive(false);
        _emyMaxHp = _emyBaseHp + (A_LevelManager.Instance.GetGameLevel() - 1) * _emyHpStep;
        emyCurHp = _emyMaxHp;
        emyAttack = _emyBaseDamage + (A_LevelManager.Instance.GetGameLevel() - 1) * _emyDamStep;
        _baseCoin = 5;
        _isEnable = false;
        damageText.text = "" + emyAttack;
        hpText.text = emyCurHp + "/" + _emyMaxHp;
    }


    public void StartAttack()
    {
        InvokeRepeating(nameof(EmyShoot), 1f, 3f);
    }

    public void EmyShoot()
    {
        if (!_isEnable) return;
        GameObject bullet = Instantiate(baseBullet, baseBullet.transform.parent, false);
        bullet.gameObject.SetActive(true);
        A_AudioManager.Instance.PlaySound("Fly");
        bullet.transform.DOLocalMoveX(-1200, 1.5f).OnComplete(() => Destroy(bullet));
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_isEnable) return;
        if (!other.gameObject.name.Contains("SwordTip")) return;
        BeAttacked();
    }


    public void ShowUI()
    {
        hpBar.SetActive(true);
        _isEnable = true;
    }


    public void BeKill()
    {
        _isEnable = false;
        CancelInvoke(nameof(EmyShoot));
        Destroy(gameObject, 0.1f);
    }

    private void OnDestroy()
    {
        CancelInvoke(nameof(EmyShoot));
    }

    private void BeAttacked()
    {
        emyCurHp -= A_PlayerManager.Instance.GetPlayDamage();
        emyCurHp = Mathf.Clamp(emyCurHp, 0, _emyMaxHp);
        hpImg.fillAmount = emyCurHp * 1f / _emyMaxHp;
        hpText.text = emyCurHp + "/" + _emyMaxHp;
        if (emyCurHp <= 0)
        {
            A_BattleAxeManager.Instance.KillEmy(_baseCoin);
            BeKill();
        }
    }
}