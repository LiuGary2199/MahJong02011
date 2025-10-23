using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using UnityEngine.UI;

public class SlitGreece : RealUITruth
{
[UnityEngine.Serialization.FormerlySerializedAs("CloseButton")]    public Button DodgeSeaman;
[UnityEngine.Serialization.FormerlySerializedAs("timeRewardItems")]    public List<SlitGreeceTopic> FallGreeceTopic;
    List<DayRewardData> GemGreeceFlask= new List<DayRewardData>();

    // Start is called before the first frame update
    void Start()
    {
        DodgeSeaman.onClick.AddListener(() =>
        {
            DodgeUIEddy(GetType().Name);
        });
    }

    public override void Display(object SoEddyAdvent)
    {
        base.Display(SoEddyAdvent);
        for (int i = 0; i < FallGreeceTopic.Count; i++)
        {
            SlitGreeceTopic rewardItem = FallGreeceTopic[i];
            rewardItem.Wine();
        }
        WitSlitGreece();
    }

    public void HowGreece(int rewardIndex)
    {
        double reward = GemGreeceFlask[rewardIndex].reward_num;
        MainDwarf.Instance.BatFare(reward);
    }
    public void LaySoul()
    {
        string[] datas = new string[4];
        for (int i = 0; i < GemGreeceFlask.Count; i++)
        {
            DayRewardData oldData = GemGreeceFlask[i];
            string jsondata = JsonMapper.ToJson(oldData);
            datas[i] = jsondata;
        }
        BondSoulEvening.OldCoyoteBelle(CShaman.It_BelleGreece, datas);
        OutdoorLegend.HeroOutdoor(CShaman.To_SpringEyeGreece, null);
    }

    public void WitSlitGreece()
    {
        GemGreeceFlask.Clear();
        string[] datas = new string[4];
        datas = BondSoulEvening.HowCoyoteBelle(CShaman.It_BelleGreece);
        long nowtime = GameUtil.GetNowTime();
        bool redState = false;
        for (int i = 0; i < datas.Length; i++)
        {
            string data = datas[i];
            SlitGreeceTopic rewardItem = FallGreeceTopic[i];
            DayRewardData dayData = JsonMapper.ToObject<DayRewardData>(data);
            GemGreeceFlask.Add(dayData);
            rewardItem.OrHowUnfold = null;
            rewardItem.OrHowUnfold = (ItemIndex) =>
            {
                SpitAnvilPawnee.HowWhatever().HeroAnvil("1008", (ItemIndex + 1).ToString());
                GemGreeceFlask[ItemIndex].getState = 1;
                HowGreece(ItemIndex);
                LaySoul();
                WitSlitGreece();
            };

            rewardItem.OrSoUnfold = null;
            rewardItem.OrSoUnfold = (ItemIndex) =>
            {
                GemGreeceFlask[ItemIndex].look_num += 1;
                LaySoul();
                WitSlitGreece();
            };
            DayRewardData deforRewardData = GemGreeceFlask.Find(x => x.dataIndex == (i - 1));
            bool beforGet = true;
            if (deforRewardData != null)
            {
                beforGet = deforRewardData.getState == 1;
            }
            rewardItem.WitHigh(dayData, beforGet);
            if (dayData.look_time > nowtime && beforGet)
            {

            }
        }
    }
}
