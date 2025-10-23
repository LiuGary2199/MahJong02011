using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using Random = UnityEngine.Random;
public class GameUtil
{
    /// <summary>
    /// 获取multi系数
    /// </summary>
    /// <returns></returns>
    private static double GetMulti(RewardType type, double cumulative, MultiGroup[] multiGroup)
    {
        foreach (MultiGroup item in multiGroup)
        {
            if (item.max > cumulative)
            {
                if (type == RewardType.Cash)
                {
                    float random = Random.Range((float)CryBustPeg.instance.WineSoul.cash_random[0], (float)CryBustPeg.instance.WineSoul.cash_random[1]);
                  //  return item.multi * (1 + random)
                         return item.multi;
                }
                else
                {
                    return item.multi;
                }
            }
        }
        return 1;
    }

    public static double GetGoldMulti()
    {
        return GetMulti(RewardType.Gold, BondSoulEvening.HowSyntax(CShaman.It_ImmobilizeHallAiry), CryBustPeg.instance.WineSoul.gold_group);
    }

    public static double GetCashMulti()
    {
        return GetMulti(RewardType.Cash, BondSoulEvening.HowSyntax(CShaman.It_ImmobilizeBreed), CryBustPeg.instance.WineSoul.cash_group);
    }
    public static double GetAmazonMulti()
    {
        return GetMulti(RewardType.Amazon, BondSoulEvening.HowSyntax(CShaman.It_ImmobilizeDegree), CryBustPeg.instance.WineSoul.amazon_group);
    }
    public static double GetInterstitialData()
    {
        double num = 0;
        RewardData interstitialData = CryBustPeg.instance.LullSoul.addatalist[0];
        double cashReward = interstitialData.reward_num * GetCashMulti();
        num = Math.Round(cashReward, 2);
        return num;
    }

    public static double GetNormalMatch()
    {
        double num = 0;
        RewardData interstitialData = CryBustPeg.instance.LullSoul.matchdatalist[0];
        double cashReward = interstitialData.reward_num * GetCashMulti();
        num = Math.Round(cashReward, 2);
        return num;
    }

    public static double GetGoldMatch()
    {
        double num = 0;
        RewardData interstitialData = CryBustPeg.instance.LullSoul.mahjongdatalist[0];
        double cashReward = interstitialData.reward_num * GetCashMulti();
        num = Math.Round(cashReward, 2);
        return num;
    }

    public static void IsSameDayAsLastCheck()
    {
        DateTime currentTime = DateTime.Now;
        long lastTimestamp = PlayerPrefs.GetInt(CShaman.It_HurlBrandTautAie, 0);
        DateTime lastDateTime = TimestampToDateTime(lastTimestamp);
        bool  IsNewDay = !IsSameDay(currentTime, lastDateTime);
        if (IsNewDay)
        {
            long currentTimestamp = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
            PlayerPrefs.SetInt(CShaman.It_HurlBrandTautAie, (int)currentTimestamp);

            string[] datas =new string[4];
            for (int i = 0; i < CryBustPeg.instance.LullSoul.timeDataList.Count; i++)
            {
                TimeRewardData oldData = CryBustPeg.instance.LullSoul.timeDataList[i];
                DayRewardData data = new DayRewardData();
                data.type = oldData.type;
                data.dataIndex = i;
                data.reward_num = oldData.reward_num * (int) GetCashMulti();
                data.look_time = oldData.look_time * 60 + (int)currentTimestamp;
                data.ad_num = oldData.ad_num;
                data.look_num = 0;
                data.getState = 0;
                string jsondata =  JsonMapper.ToJson(data);
                datas[i] = jsondata;
            }
            BondSoulEvening.OldCoyoteBelle(CShaman.It_BelleGreece, datas);
        }
    }
    // <summary>
    /// 时间戳转DateTime
    /// </summary>
    private static DateTime TimestampToDateTime(long timestamp)
    {
        if (timestamp == 0) return DateTime.MinValue;
        return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            .AddSeconds(timestamp)
            .ToLocalTime();
    }
    /// <summary>
    /// 判断两个时间是否为同一天
    /// </summary>
    private static bool IsSameDay(DateTime time1, DateTime time2)
    {
        return time1.Date == time2.Date;
    }

    public static long GetNowTime()
    {
        long currentTimestamp = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        return currentTimestamp;
    }
}


/// <summary>
/// 奖励类型
/// </summary>
public enum RewardType { Gold, Cash, Amazon }
