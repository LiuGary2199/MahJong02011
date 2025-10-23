using System.Collections;
using System.Collections.Generic;
using Mkey;
using UnityEngine;
using UnityEngine.UI;
using Spine;
using Spine.Unity;
using DG.Tweening;

public class DeltaGasolineDwarf : RealUITruth
{
    [Header("按钮")]
[UnityEngine.Serialization.FormerlySerializedAs("ADButton")]    public Button ADSeaman;
[UnityEngine.Serialization.FormerlySerializedAs("RageDeltaSeaman")]    public Button RageDeltaSeaman;
[UnityEngine.Serialization.FormerlySerializedAs("ADText")]    public GameObject ADPity;
    [Header("转盘组")]
[UnityEngine.Serialization.FormerlySerializedAs("SlotBG")]    public PraySharp PrayBG;
[UnityEngine.Serialization.FormerlySerializedAs("RewardCashImage")]
    public GameObject GreeceFareReady;
[UnityEngine.Serialization.FormerlySerializedAs("RewardGoldImage")]    public GameObject GreeceHallReady;
[UnityEngine.Serialization.FormerlySerializedAs("RewardText")]    public Text GreecePity;

    private double UplandQuery;
    private bool FinFinnishSoSty;
[UnityEngine.Serialization.FormerlySerializedAs("grtMoreRect")]    public RectTransform CueRockTear;
[UnityEngine.Serialization.FormerlySerializedAs("m_SkeletonGraphic")]    public SkeletonGraphic m_SalinityTourist;
    // Start is called before the first frame update
    private string ARunway= "1";
[UnityEngine.Serialization.FormerlySerializedAs("tween")]    public Tween Calve;
    void Start()
    {
        // 监听动画结束事件
        m_SalinityTourist.AnimationState.Complete += OnAnimationComplete;
        ADSeaman.onClick.AddListener(() =>
        {
            ADSeaman.enabled = false;
            RageDeltaSeaman.enabled = false;
            if (ItNssTray())
            {
                TillPray();
            }
            else
            {
                ADEvening.Whatever.TillGreeceSugar((success) =>
                {
                        if (success)
                        {
                            TillPray();
                            ARunway = "1";
                        }
                        else
                        {
                            ADSeaman.enabled = true;
                            RageDeltaSeaman.enabled = true;
                        }
                }, "2" );
            }
        });

        RageDeltaSeaman.onClick.AddListener(() =>
        {
            AnRage();
            RageDeltaSeaman.enabled = false;
            MainDwarf.Instance.BatFare(UplandQuery, GreeceFareReady.transform);
            if (!FinFinnishSoSty)
            {
                ADEvening.Whatever.DyAnimalBatPulse();
            }
            DodgeUIEddy(GetType().Name);
            ARunway = "0";
          
        });
    }
    public void AnRage()
    {     RageLull();
        RageDeltaSeaman.enabled = false;
        MainDwarf.Instance.BatFare(UplandQuery, GreeceFareReady.transform);
        if (!FinFinnishSoSty)
        {
            ADEvening.Whatever.DyAnimalBatPulse();
        }
        DodgeUIEddy(GetType().Name);
        SpitAnvilPawnee.HowWhatever().HeroAnvil("1004", ARunway);
    }

    private void OnAnimationComplete(TrackEntry trackEntry)
    {
        if (trackEntry != null)
        {
            if (trackEntry.Animation.Name == "1start")
            {
                m_SalinityTourist.AnimationState.SetAnimation(0, "2idle", true);
            }
        }
    }

    public void RageLull()
    {
        LullEvening.Instance.m_PartyPulse = 0;
        //LullEvening.Instance.NextGame();
        Mkey.LullDeltaMisery.OldPrecedeDeltaCanBond(Mkey.LullDeltaMisery.PrecedeDelta + 1);
        // 先清理旧麻将牌对象
        if (LullSyrup.Whatever != null)
        {
            LullSyrup.Whatever.OceaniaSoda(); // 清理旧麻将
            LullSyrup.Whatever.LiableLullSyrup(); // 用新关卡号重建关卡
        }
        // 触发关卡开始事件，刷新UI（包括GameLevelHelper等）
        Mkey.LullDeltaMisery.VaultDelta();
        // 刷新主界面关卡号显示
    }

    public override void Display(object SoEddyAdvent)
    {
        base.Display(SoEddyAdvent);
        RageDeltaSeaman.gameObject.SetActive(false);
        m_SalinityTourist.AnimationState.ClearTracks();
        m_SalinityTourist.AnimationState.SetAnimation(0, "1start", false);
        ADSeaman.enabled = true;
        RageDeltaSeaman.enabled = true;
        if (ItNssTray())
        {
            ADPity.SetActive(false);
            CueRockTear.anchoredPosition = new Vector2(0, 0);
            RageDeltaSeaman.gameObject.SetActive(false);
        }
        else
        {
            ADPity.SetActive(true);
            CueRockTear.anchoredPosition = new Vector2(41.35f, 0);
        }
        FinFinnishSoSty = false;

        // 根据实际项目计算奖励
        //rewardValue = WinterErie.IsApple() ? CryBustPeg.instance.InitData.box_gold_price * GameUtil.GetGoldMulti() : CryBustPeg.instance.InitData.passlevel_cash_price * GameUtil.GetCashMulti();
        UplandQuery = CryBustPeg.instance.LullSoul.leveldatalist[0].reward_num * GameUtil.GetCashMulti();
        //rewardValue = 1 * GameUtil.GetCashMulti();
        GreecePity.text = "+" + GallopErie.SyntaxDyOat(UplandQuery);

        PrayBG.CropPitch();
        Calve = DOVirtual.DelayedCall(2f, () =>
       {
           Calve?.Kill();
           if (!ItNssTray())
           {
               RageDeltaSeaman.gameObject.SetActive(true);
           }

       });
        //DOVirtual.DelayedCall(1f, () =>
        //{
           // NextGame();
       // });

    }

    private bool ItNssTray()
    {
        return !PlayerPrefs.HasKey(CShaman.It_AfterPray + "Bool") || BondSoulEvening.HowTape(CShaman.It_AfterPray);
    }
    // 计算本次slot应该获得的奖励
    private int EndPrayPitchMoody()
    {
        // 新用户，第一次固定翻5倍
        if (ItNssTray())
        {
            int Rough= 0;
            foreach (SlotItem wg in CryBustPeg.instance.WineSoul.slot_group)
            {
                if (wg.multi == 5)
                {
                    return Rough;
                }
                Rough++;
            }
        }
        else
        {
            int sumWeight = 0;
            foreach (SlotItem wg in CryBustPeg.instance.WineSoul.slot_group)
            {
                sumWeight += wg.weight;
            }
            int r = Random.Range(0, sumWeight);
            int nowWeight = 0;
            int Rough= 0;
            foreach (SlotItem wg in CryBustPeg.instance.WineSoul.slot_group)
            {
                nowWeight += wg.weight;
                if (nowWeight > r)
                {
                    return Rough;
                }
                Rough++;
            }

        }
        return 0;
    }
    public override void Hidding()
    {
        base.Hidding();
        m_SalinityTourist.AnimationState.SetAnimation(1, "3end", false);
    }

    private void TillPray()
    {
        RageDeltaSeaman.enabled = false;
        ADSeaman.enabled = false;
        int Rough= EndPrayPitchMoody();
        PrayBG.East(Rough, (multi) =>
        {
            // slot结束后的回调
            CertaintyModerately.HaliteGallop(UplandQuery, UplandQuery * multi, 0, GreecePity, "+", () =>
            {
                UplandQuery = UplandQuery * multi;
                GreecePity.text = "+" + GallopErie.SyntaxDyOat(UplandQuery);
                FinFinnishSoSty = true;
           
                DOVirtual.DelayedCall(0.5f, () =>
              {
                  AnRage();
              });
            });
        });

        BondSoulEvening.OldTape(CShaman.It_AfterPray, false);
    }
}
