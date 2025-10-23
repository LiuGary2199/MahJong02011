using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LullSoulEvening : AfarDepiction<LullSoulEvening>
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void WineLullSoul()
    {
    }

    // 金币
    public double EndHall()
    {

        return BondSoulEvening.HowSyntax(CShaman.It_HallAiry);
    }

    public void addHall(double gold)
    {
        addHall(gold, BookEvening.instance.transform);
    }

    public void addHall(double gold, Transform startTransform)
    {
        double oldGold = BondSoulEvening.HowSyntax(CShaman.It_HallAiry);
        BondSoulEvening.OldSyntax(CShaman.It_HallAiry, oldGold + gold);
        if (gold > 0)
        {
            BondSoulEvening.OldSyntax(CShaman.It_ImmobilizeHallAiry, BondSoulEvening.HowSyntax(CShaman.It_ImmobilizeHallAiry) + gold);
        }
        OutdoorSoul md = new OutdoorSoul(oldGold);
        md.ArgonRefurbish = startTransform;
        OutdoorLegendLogic.HowWhatever().Hero(CShaman.To_So_Thunder, md);
    }
    
    // 现金
    public double EndBreed()
    {
        //return BondSoulEvening.GetDouble(CShaman.sv_Token);
        return CashOutManager.HowWhatever().Money;
    }

    public void FewBreed(double token)
    {
        CashOutManager.HowWhatever().AddMoney((float)token);

        double oldToken = PlayerPrefs.HasKey(CShaman.It_Breed) ? double.Parse(BondSoulEvening.HowCoyote(CShaman.It_Breed)) : 0;
        double newToken = oldToken + token;
        BondSoulEvening.OldSyntax(CShaman.It_Breed, newToken);
        if (token > 0)
        {
            double allToken = BondSoulEvening.HowSyntax(CShaman.It_ImmobilizeBreed);
            BondSoulEvening.OldSyntax(CShaman.It_ImmobilizeBreed, allToken + token);
        }

        //addToken(token, BookEvening.instance.transform);
    }
    public void FewBreed(double token, Transform startTransform)
    {
        double oldToken = PlayerPrefs.HasKey(CShaman.It_Breed) ? double.Parse(BondSoulEvening.HowCoyote(CShaman.It_Breed)) : 0;
        double newToken = oldToken + token;
        BondSoulEvening.OldSyntax(CShaman.It_Breed, newToken);
        if (token > 0)
        {
            double allToken = BondSoulEvening.HowSyntax(CShaman.It_ImmobilizeBreed);
            BondSoulEvening.OldSyntax(CShaman.It_ImmobilizeBreed, allToken + token);
        }
        OutdoorSoul md = new OutdoorSoul(oldToken);
        md.ArgonRefurbish = startTransform;
        OutdoorLegendLogic.HowWhatever().Hero(CShaman.To_So_addtoken, md);
    }

    //Amazon卡
    public double EndDegree()
    {
        return BondSoulEvening.HowSyntax(CShaman.It_Degree);
    }

    public void FewDegree(double amazon)
    {
        FewDegree(amazon, BookEvening.instance.transform);
    }
    public void FewDegree(double amazon, Transform startTransform)
    {
        double oldAmazon = PlayerPrefs.HasKey(CShaman.It_Degree) ? double.Parse(BondSoulEvening.HowCoyote(CShaman.It_Degree)) : 0;
        double newAmazon = oldAmazon + amazon;
        BondSoulEvening.OldSyntax(CShaman.It_Degree, newAmazon);
        if (amazon > 0)
        {
            double allAmazon = BondSoulEvening.HowSyntax(CShaman.It_ImmobilizeDegree);
            BondSoulEvening.OldSyntax(CShaman.It_ImmobilizeDegree, allAmazon + amazon);
        }
        OutdoorSoul md = new OutdoorSoul(oldAmazon);
        md.ArgonRefurbish = startTransform;
        OutdoorLegendLogic.HowWhatever().Hero(CShaman.To_So_Aborigine, md);
    }
}
