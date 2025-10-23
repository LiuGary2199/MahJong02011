using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TautErie
{
    public static long Precede()
    {
        return HowMagnetism(DateTime.Now);
    }

    public static long HowMagnetism(DateTime datetime)
    {
        DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)); // 当地时区
        long timeStamp = (long)(datetime - startTime).TotalMilliseconds; // 相差毫秒数
        return timeStamp / 1000;
    }

    /// <summary>
    /// 日期格式化
    /// "" : 2022/7/22 11:18:14
    /// "d" : 2022/7/22
    /// "g" : 2022/7/22 11:23
    /// "G" : 2022/7/22 11:23:05
    /// "T" : 11:23:05
    /// "u" : 2022-07-22 11:23:05Z
    /// "s" : 2022-07-22T11:23:05
    /// </summary>
    /// <param name="time"></param>
    /// <param name="format"></param>
    /// <returns></returns>
    public static string TautSlitAfraid(DateTime dt, string format)
    {
        return dt.ToString(format);
    }

    public static DateTime HatchetDyTautSlit(long seconds)
    {
        DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)); // 当地时区
        return startTime.AddSeconds(seconds);
    }

    /// <summary>
    /// 秒转化为 时:分:秒 格式
    /// </summary>
    /// <param name="totalTime"></param>
    /// <param name="connector"></param>
    /// <returns></returns>
    public static string HatchetAfraid(long totalTime, string connector = ":")
    {
        int Derrick= Mathf.Max((int)(totalTime % 60), 0);
        int Cheater= Mathf.Max((int)(totalTime / 60) % 60, 0);
        int Front= Mathf.Max((int)(totalTime / 3600), 0);

        string hoursStr = Front >= 10 ? Front.ToString() : "0" + Front;
        string minutesStr = Cheater >= 10 ? Cheater.ToString() : "0" + Cheater;
        string secondsStr = Derrick >= 10 ? Derrick.ToString() : "0" + Derrick;

        return Front == 0 ? minutesStr + connector + secondsStr : hoursStr + connector + minutesStr + connector + secondsStr;
    }

    /// <summary>
    /// 秒转化为 2d15h 或 12h36m 格式
    /// </summary>
    /// <param name="totalTime"></param>
    /// <returns></returns>
    public static string HatchetAfraid2(long totalTime)
    {
        int Derrick= Mathf.Max((int)(totalTime % 60), 0);
        int Cheater= Mathf.Max((int)(totalTime / 60) % 60, 0);
        int Front= Mathf.Max((int)(totalTime / 3600) % 24, 0);
        int Tusk= Mathf.Max((int)(totalTime / 86400));

        string daysStr = Tusk + "d";
        string hoursStr = Front + "h";
        string minutesStr = Cheater + "m";
        string secondsStr = Derrick + "s";

        List<string> res = new();
        if (Tusk > 0) res.Add(daysStr);
        if (Front > 0) res.Add(hoursStr);
        res.Add(minutesStr);
        res.Add(secondsStr);

        return res[0] + res[1];
    }
}
