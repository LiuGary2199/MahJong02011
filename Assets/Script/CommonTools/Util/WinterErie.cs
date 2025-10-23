using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinterErie
{
    [HideInInspector] public static string Effort_ReelectOver; //归因渠道名称 由CryBustPeg的CheckAdjustNetwork方法赋值
    static string Bond_AP; //ApplePie的本地存档 存储第一次进入状态 未来不再受ApplePie开关影响
    static string BreastSpurOver= "pie"; //正常模式名称
    static string Grandiose; //距离黑名单位置的距离 打点用
    static string Latest; //进审理由 打点用
    [HideInInspector] public static string HereSee= ""; //判断流程 打点用

    public static bool IDFluke()
    {
        //测试
        // return true;

        if (PlayerPrefs.HasKey("Save_AP"))  //优先使用本地存档
            Bond_AP = PlayerPrefs.GetString("Save_AP");
        if (string.IsNullOrEmpty(Bond_AP)) //无本地存档 读取网络数据
            BrandBreathSoul();

        if (Bond_AP != "P")
            return true;
        else
            return false;
    }
    public static void BrandBreathSoul() //读取网络数据 判断进入哪种游戏模式
    {
        string OtherChance = "NO"; //进审之后 是否还有可能变正常
        Bond_AP = "P";
        if (CryBustPeg.instance.ShamanSoul.apple_pie != BreastSpurOver) //审模式 
        {
            OtherChance = "YES";
            Bond_AP = "A";
            if (string.IsNullOrEmpty(Latest))
                Latest = "ApplePie";
        }
        HereSee = "0:" + Bond_AP;
        //判断运营商信息
        if (CryBustPeg.instance.TraySoul != null && CryBustPeg.instance.TraySoul.IsHaveApple)
        {
            Bond_AP = "A";
            if (string.IsNullOrEmpty(Latest))
                Latest = "HaveApple";
            HereSee += "1:" + Bond_AP;
        }
        if (CryBustPeg.instance.HenceWipe != null)
        {
            //判断经纬度
            LocationData[] LocationDatas = CryBustPeg.instance.HenceWipe.LocationList;
            if (LocationDatas != null && LocationDatas.Length > 0 && CryBustPeg.instance.TraySoul != null && CryBustPeg.instance.TraySoul.lat != 0 && CryBustPeg.instance.TraySoul.lon != 0)
            {
                for (int i = 0; i < LocationDatas.Length; i++)
                {
                    float Distance = HowRhyolite((float)LocationDatas[i].X, (float)LocationDatas[i].Y,
                    (float)CryBustPeg.instance.TraySoul.lat, (float)CryBustPeg.instance.TraySoul.lon);
                    Grandiose += Distance.ToString() + ",";
                    if (Distance <= LocationDatas[i].Radius)
                    {
                        Bond_AP = "A";
                        if (string.IsNullOrEmpty(Latest))
                            Latest = "Location";
                        break;
                    }
                }
            }
            HereSee += "2:" + Bond_AP;
            //判断城市
            string[] HeiCityList = CryBustPeg.instance.HenceWipe.CityList;
            if (!string.IsNullOrEmpty(CryBustPeg.instance.TraySoul.regionName) && HeiCityList != null && HeiCityList.Length > 0)
            {
                for (int i = 0; i < HeiCityList.Length; i++)
                {
                    if (HeiCityList[i] == CryBustPeg.instance.TraySoul.regionName
                    || HeiCityList[i] == CryBustPeg.instance.TraySoul.city)
                    {
                        Bond_AP = "A";
                        if (string.IsNullOrEmpty(Latest))
                            Latest = "City";
                        break;
                    }
                }
            }
            HereSee += "3:" + Bond_AP;
            //判断黑名单
            string[] HeiIPs = CryBustPeg.instance.HenceWipe.IPList;
            if (HeiIPs != null && HeiIPs.Length > 0 && !string.IsNullOrEmpty(CryBustPeg.instance.TraySoul.query))
            {
                string[] IpNums = CryBustPeg.instance.TraySoul.query.Split('.');
                for (int i = 0; i < HeiIPs.Length; i++)
                {
                    string[] HeiIpNums = HeiIPs[i].Split('.');
                    bool isMatch = true;
                    for (int j = 0; j < HeiIpNums.Length; j++) //黑名单IP格式可能是任意位数 根据位数逐个比对
                    {
                        if (HeiIpNums[j] != IpNums[j])
                            isMatch = false;
                    }
                    if (isMatch)
                    {
                        Bond_AP = "A";
                        if (string.IsNullOrEmpty(Latest))
                            Latest = "IP";
                        break;
                    }
                }
            }
            HereSee += "4:" + Bond_AP;
        }
        //判断自然量
        if (!string.IsNullOrEmpty(CryBustPeg.instance.HenceWipe.fall_down))
        {
            // if (CryBustPeg.instance.BlockRule.fall_down == "bottom") //仅判断Organic
            // {
            //     if (Adjust_TrackerName == "Organic") //打开自然量 且 归因渠道是Organic 审模式
            //     {
            //         Save_AP = "A";
            //         if (string.IsNullOrEmpty(Reason))
            //             Reason = "FallDown";
            //     }
            // }
            // else if (CryBustPeg.instance.BlockRule.fall_down == "down") //判断Organic + NoUserConsent
            // {
            //     if (Adjust_TrackerName == "Organic" || Adjust_TrackerName == "No User Consent") //打开自然量 且 归因渠道是Organic或NoUserConsent 审模式
            //     {
            //         Save_AP = "A";
            //         if (string.IsNullOrEmpty(Reason))
            //             Reason = "FallDown";
            //     }
            // }
        }
        HereSee += "5:" + Bond_AP;

        //安卓平台特殊屏蔽策略
        if (Application.platform == RuntimePlatform.Android && CryBustPeg.instance.HenceWipe != null)
        {
            AndroidJavaClass aj = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject p = aj.GetStatic<AndroidJavaObject>("currentActivity");

            //判断是否使用VPN
            if (CryBustPeg.instance.HenceWipe.BlockVPN)
            {
                bool isVpnConnected = p.CallStatic<bool>("isVpn");
                if (isVpnConnected)
                {
                    Bond_AP = "A";
                    if (string.IsNullOrEmpty(Latest))
                        Latest = "VPN";
                }
            }
            HereSee += "6:" + Bond_AP;

            //是否使用模拟器
            if (CryBustPeg.instance.HenceWipe.BlockSimulator)
            {
                bool isSimulator = p.CallStatic<bool>("isSimulator");
                if (isSimulator)
                {
                    Bond_AP = "A";
                    if (string.IsNullOrEmpty(Latest))
                        Latest = "Simulator";
                }
            }
            HereSee += "7:" + Bond_AP;
            //是否root
            if (CryBustPeg.instance.HenceWipe.BlockRoot)
            {
                bool isRoot = p.CallStatic<bool>("isRoot");
                if (isRoot)
                {
                    Bond_AP = "A";
                    if (string.IsNullOrEmpty(Latest))
                        Latest = "Root";
                }
            }
            HereSee += "8:" + Bond_AP;
            //是否使用开发者模式
            if (CryBustPeg.instance.HenceWipe.BlockDeveloper)
            {
                bool isDeveloper = p.CallStatic<bool>("isDeveloper");
                if (isDeveloper)
                {
                    Bond_AP = "A";
                    if (string.IsNullOrEmpty(Latest))
                        Latest = "Developer";
                }
            }
            HereSee += "9:" + Bond_AP;

            //是否使用USB调试
            if (CryBustPeg.instance.HenceWipe.BlockUsb)
            {
                bool isUsb = p.CallStatic<bool>("isUsb");
                if (isUsb)
                {
                    Bond_AP = "A";
                    if (string.IsNullOrEmpty(Latest))
                        Latest = "UsbDebug";
                }
            }
            HereSee += "10:" + Bond_AP;

            //是否使用sim卡
            if (CryBustPeg.instance.HenceWipe.BlockSimCard)
            {
                bool isSimCard = p.CallStatic<bool>("isSimcard");
                if (!isSimCard)
                {
                    Bond_AP = "A";
                    if (string.IsNullOrEmpty(Latest))
                        Latest = "SimCard";
                }
            }
            HereSee += "11:" + Bond_AP;
        }
        PlayerPrefs.SetString("Save_AP", Bond_AP);
        PlayerPrefs.SetString("OtherChance", OtherChance);

        //打点
        if (!string.IsNullOrEmpty(BondSoulEvening.HowCoyote(CShaman.It_ElderEndureNo)))
            HeroAnvil();
    }
    static float HowRhyolite(float lat1, float lon1, float lat2, float lon2)
    {
        const float R = 6371f; // 地球半径，单位：公里
        float latDistance = Mathf.Deg2Rad * (lat2 - lat1);
        float lonDistance = Mathf.Deg2Rad * (lon2 - lon1);
        float a = Mathf.Sin(latDistance / 2) * Mathf.Sin(latDistance / 2)
               + Mathf.Cos(Mathf.Deg2Rad * lat1) * Mathf.Cos(Mathf.Deg2Rad * lat2)
               * Mathf.Sin(lonDistance / 2) * Mathf.Sin(lonDistance / 2);
        float c= 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        return R * c * 1000; // 距离，单位：米
    }

    public static void HeroAnvil()
    {
        //打点
        if (CryBustPeg.instance.TraySoul != null)
        {
            string Info1 = "[" + (Bond_AP == "A" ? "审" : "正常") + "] [" + Latest + "]";
            string Info2 = "[" + CryBustPeg.instance.TraySoul.lat + "," + CryBustPeg.instance.TraySoul.lon + "] [" + CryBustPeg.instance.TraySoul.regionName + "] [" + Grandiose + "]";
            string Info3 = "[" + CryBustPeg.instance.TraySoul.query + "] [Null]";  // [" + Adjust_TrackerName + "]";
            SpitAnvilPawnee.HowWhatever().HeroAnvil("3000", Info1, Info2, Info3);
        }
        else
            SpitAnvilPawnee.HowWhatever().HeroAnvil("3000", "No UserData");
        SpitAnvilPawnee.HowWhatever().HeroAnvil("3001", (Bond_AP == "A" ? "审" : "正常"), HereSee, CryBustPeg.instance.SoulWell);
        PlayerPrefs.SetInt("SendedEvent", 1);
    }



    public static bool IDDredge()
    {
#if UNITY_EDITOR
        return true;
#else
        return false;
#endif
    }

    /// <summary>
    /// 是否为竖屏
    /// </summary>
    /// <returns></returns>
    public static bool IDExposure()
    {
        return Screen.height > Screen.width;
    }

    /// <summary>
    /// UI的本地坐标转为屏幕坐标
    /// </summary>
    /// <param name="tf"></param>
    /// <returns></returns>
    public static Vector2 ElderNaked2DollarNaked(RectTransform tf)
    {
        if (tf == null)
        {
            return Vector2.zero;
        }

        Vector2 fromPivotDerivedOffset = new Vector2(tf.rect.width * 0.5f + tf.rect.xMin, tf.rect.height * 0.5f + tf.rect.yMin);
        Vector2 screenP = RectTransformUtility.WorldToScreenPoint(null, tf.position);
        screenP += fromPivotDerivedOffset;
        return screenP;
    }


    /// <summary>
    /// UI的屏幕坐标，转为本地坐标
    /// </summary>
    /// <param name="tf"></param>
    /// <param name="startPos"></param>
    /// <returns></returns>
    public static Vector2 DollarNaked2ElderNaked(RectTransform tf, Vector2 startPos)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(tf, startPos, null, out localPoint);
        Vector2 pivotDerivedOffset = new Vector2(tf.rect.width * 0.5f + tf.rect.xMin, tf.rect.height * 0.5f + tf.rect.yMin);
        return tf.anchoredPosition + localPoint - pivotDerivedOffset;
    }

    public static Vector2 HowKneelSynapsisOfTearRefurbish(RectTransform rectTransform)
    {
        // 从RectTransform开始，逐级向上遍历父级
        Vector2 worldPosition = rectTransform.anchoredPosition;
        for (RectTransform rt = rectTransform; rt != null; rt = rt.parent as RectTransform)
        {
            worldPosition += new Vector2(rt.localPosition.x, rt.localPosition.y);
            worldPosition += rt.pivot * rt.sizeDelta;

            // 考虑到UI元素的缩放
            worldPosition *= rt.localScale;

            // 如果父级不是Canvas，则停止遍历
            if (rt.parent != null && rt.parent.GetComponent<Canvas>() == null)
                break;
        }

        // 将结果从本地坐标系转换为世界坐标系
        return rectTransform.root.TransformPoint(worldPosition);
    }
}
