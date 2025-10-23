using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GreeceHotDwarf : RealUITruth
{
    [Header("按钮")]
[UnityEngine.Serialization.FormerlySerializedAs("ADButton")]    public Button ADSeaman;
[UnityEngine.Serialization.FormerlySerializedAs("RageDeltaSeaman")]    public Button RageDeltaSeaman;
[UnityEngine.Serialization.FormerlySerializedAs("RewardText")]    public Text GreecePity;
[UnityEngine.Serialization.FormerlySerializedAs("rewardTrans")]    public Transform UplandRefer;
    private double UplandQuery;
[UnityEngine.Serialization.FormerlySerializedAs("parObj")]    public GameObject AndSad;
    private bool FinFinnishSoSty;
[UnityEngine.Serialization.FormerlySerializedAs("adobj")]    public GameObject Alive;
[UnityEngine.Serialization.FormerlySerializedAs("adrettrfansform")]    public RectTransform Unsophisticated;
[UnityEngine.Serialization.FormerlySerializedAs("tween")]    public Tween Calve;
    private string SoVogue= "1";

    // Start is called before the first frame update
    void Start()
    {
        ADSeaman.onClick.AddListener(() =>
        {
            ADSeaman.enabled = false;
            RageDeltaSeaman.enabled = false;
            if (ItNssTray())
            {
                BondSoulEvening.OldTape(CShaman.It_AfterHotGreece, false);
                GetGold();
            }
            else
            {
                ADEvening.Whatever.TillGreeceSugar((success) =>
                {
                    if (success)
                    {
                        SoVogue = "1";
                        BondSoulEvening.OldTape(CShaman.It_AfterHotGreece, false);
                        GetGold();
                    }
                    else
                    {
                        ADSeaman.enabled = true;
                        RageDeltaSeaman.enabled = true;
                    }
                }, "1");
            }
        });

        RageDeltaSeaman.onClick.AddListener(() =>
        {
            SoVogue = "0";
            ADSeaman.enabled = false;
            RageDeltaSeaman.enabled = false;
            MainDwarf.Instance.BatFare(UplandQuery, UplandRefer);
            ADEvening.Whatever.DyAnimalBatPulse();
            DodgeUIEddy(GetType().Name);
        });
    }

    public void GetGold()
    {
        CertaintyModerately.HaliteGallop(UplandQuery, UplandQuery * 5, 0, GreecePity, "+", () =>
        {
            UplandQuery = UplandQuery * 5;
            GreecePity.text = "+" + GallopErie.SyntaxDyOat(UplandQuery);
            FinFinnishSoSty = true;
            MainDwarf.Instance.BatFare(UplandQuery, UplandRefer);
            DOVirtual.DelayedCall(0.5f, () =>
            {
                DodgeUIEddy(GetType().Name);
            });
        });
    }

    public override void Display(object SoEddyAdvent)
    {
        base.Display(SoEddyAdvent);
        AndSad.SetActive(false);
        AndSad.SetActive(true);
        ADSeaman.enabled = true;
        RageDeltaSeaman.enabled = true;
        RageDeltaSeaman.gameObject.SetActive(false);
        UplandQuery = GallopErie.GridUnclearDySyntax(SoEddyAdvent);
        GreecePity.text = "+" + GallopErie.ConvertWestLifewayFix(SoEddyAdvent);
        if (ItNssTray())
        {
            Alive.SetActive(false);
            Unsophisticated.anchoredPosition = new Vector2(0, 0);
        }
        else
        {
            Alive.SetActive(true);
            Unsophisticated.anchoredPosition = new Vector2(41.35f, 0);
        }
        Calve?.Kill();
        Calve = DOVirtual.DelayedCall(1f, () =>
        {
            Calve?.Kill();
              if (!ItNssTray())
            {
            RageDeltaSeaman.gameObject.SetActive(true);}
        });
    }

    public override void Hidding()
    {
        base.Hidding();
        SpitAnvilPawnee.HowWhatever().HeroAnvil("1003", SoVogue);
        KnotLastUsDwarf();
    }

    private void KnotLastUsDwarf()
    {
        if (WinterErie.IDFluke())
        {
            return;
        }
        if (BondSoulEvening.HowCoyote(CShaman.It_Warp_Dull_Pest_On) != "done")
        {
            YorkUIEddy(nameof(LastGoDwarf));
            BondSoulEvening.OldCoyote(CShaman.It_Warp_Dull_Pest_On, "done");
        }
    }

    private bool ItNssTray()
    {
        return !PlayerPrefs.HasKey(CShaman.It_AfterHotGreece + "Bool") || BondSoulEvening.HowTape(CShaman.It_AfterHotGreece);
    }
}
