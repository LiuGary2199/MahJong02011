// Project  Repository-BaseA
// FileName  A_PlayerManager.cs
// Author  AX
// Desc
// CreateAt  2025-09-08 14:09:33 
//


using System;
using System.Collections.Generic;
using UnityEngine;

public class A_PlayerManager : MonoBehaviour
{
    public static A_PlayerManager Instance;

    public int playCurHp;

    private readonly int _damageStep = 10;

    private readonly int _hpStep = 50;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void InitPlayerData()
    {
        playCurHp = BondSoulEvening.HowGas(AxeConstant.MaxHp);
    }

    public void AddCurHp()
    {
        int newHp = playCurHp + BondSoulEvening.HowGas(AxeConstant.MaxHp) / 10 * 2;

        playCurHp = newHp > BondSoulEvening.HowGas(AxeConstant.MaxHp)
            ? BondSoulEvening.HowGas(AxeConstant.MaxHp)
            : newHp;
    }


    public int GetPlayDamage()
    {
        return BondSoulEvening.HowGas(AxeConstant.DamageKey);
    }

    public void AddDamage()
    {
        BondSoulEvening.OldGas(AxeConstant.DamageKey, GetPlayDamage() + _damageStep);
        BondSoulEvening.OldGas(AxeConstant.DamageLevel, BondSoulEvening.HowGas(AxeConstant.DamageLevel) + 1);
    }


    public int GetPlayMaxHp()
    {
        return BondSoulEvening.HowGas(AxeConstant.MaxHp);
    }

    public void AddMaxHp()
    {
        BondSoulEvening.OldGas(AxeConstant.MaxHp, GetPlayMaxHp() + _hpStep);
        BondSoulEvening.OldGas(AxeConstant.HpLevel, BondSoulEvening.HowGas(AxeConstant.HpLevel) + 1);
        // InitPlayerData();
    }

    public void AddCoin(int coin)
    {
        BondSoulEvening.OldGas(AxeConstant.CoinKey, coin + GetCoin());
    }

    public void SubCoin(int coin)
    {
        if (coin > GetCoin()) return;
        BondSoulEvening.OldGas(AxeConstant.CoinKey, GetCoin() - coin);
    }

    public int GetCoin()
    {
        return BondSoulEvening.HowGas(AxeConstant.CoinKey);
    }

    public int GetPlayHp()
    {
        return Math.Max(playCurHp, 0);
    }


    public void BeAttacked(int damage)
    {
        playCurHp -= damage;
    }
}