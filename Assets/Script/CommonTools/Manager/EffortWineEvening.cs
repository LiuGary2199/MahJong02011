using System;
using System.Collections;
using com.adjust.sdk;
using LitJson;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class EffortWineEvening : MonoBehaviour
{
    public static EffortWineEvening Instance;
[UnityEngine.Serialization.FormerlySerializedAs("adjustID")]
    public string FourthID;     // 由遇总的打包工具统一修改，无需手动配置

    //用户adjust 状态KEY
    private string sv_ADPileWineLieu= "sv_ADJustInitType";

    //adjust 时间戳
    private string It_ADPileSlit= "sv_ADJustTime";

    //adjust行为计数器
    public int _ProducePulse{ get; private set; }

    public double _ProduceReality{ get; private set; }

    double FourthWineSoReality= 0;


    private void Awake()
    {
        Instance = this;
        BondSoulEvening.OldCoyote(It_ADPileSlit, TautErie.Precede().ToString());

#if UNITY_IOS
        BondSoulEvening.OldCoyote(sv_ADPileWineLieu, AdjustStatus.OpenAsAct.ToString());
        EffortWine();
#endif
    }

    private void Start()
    {
        _ProducePulse = 0;
    }


    void EffortWine()
    {
#if UNITY_EDITOR
        return;
#endif
        AdjustConfig adjustConfig = new AdjustConfig(FourthID, AdjustEnvironment.Production, false);
        adjustConfig.setLogLevel(AdjustLogLevel.Verbose);
        adjustConfig.setSendInBackground(false);
        adjustConfig.setEventBufferingEnabled(false);//SDK v5 中已删除该设置。
        adjustConfig.setLaunchDeferredDeeplink(true);
        Adjust.start(adjustConfig);
        //adjustConfig.LogLevel = AdjustLogLevel.Verbose;
        //adjustConfig.IsSendingInBackgroundEnabled = adjustConfig.IsSendingInBackgroundEnabled = true;
        //adjustConfig.IsDeferredDeeplinkOpeningEnabled = true;
        //Adjust.InitSdk(adjustConfig);
        StartCoroutine(BondEffortZinc());
    }

    private IEnumerator BondEffortZinc()
    {
        while (true)
        {
            string adjustAdid = Adjust.getAdid();
           // string adjustAdid = "";
            if (string.IsNullOrEmpty(adjustAdid))
            {
                //Adjust.GetAdid((adid) =>
                //{
                //    adjustAdid = adid;
                //});
                yield return new WaitForSeconds(5);
            }
            else
            {
                BondSoulEvening.OldCoyote(CShaman.It_EffortZinc, adjustAdid);
                CryBustPeg.instance.HeroEffortZinc();
                yield break;
            }
        }
    }

    public string HowEffortZinc()
    {
        return BondSoulEvening.HowCoyote(CShaman.It_EffortZinc);
    }

    /// <summary>
    /// 获取adjust初始化状态
    /// </summary>
    /// <returns></returns>
    public string HowEffortOffend()
    {
        return BondSoulEvening.HowCoyote(sv_ADPileWineLieu);
    }

    /*
     *  API
     *  Adjust 初始化
     */
    public void WineEffortSoul(bool isOldUser = false)
    {
#if UNITY_IOS
        return;
#endif
        if (BondSoulEvening.HowCoyote(sv_ADPileWineLieu) == "" && isOldUser)
        {
            YewTrayOld();
        }
        // 如果后台配置的adjust_init_act_position <= 0，直接初始化
        if (string.IsNullOrEmpty(CryBustPeg.instance.ShamanSoul.adjust_init_act_position) || int.Parse(CryBustPeg.instance.ShamanSoul.adjust_init_act_position) <= 0)
        {
            BondSoulEvening.OldCoyote(sv_ADPileWineLieu, AdjustStatus.OpenAsAct.ToString());
        }
        print(" user init adjust by status :" + BondSoulEvening.HowCoyote(sv_ADPileWineLieu));
        //用户二次登录 根据标签初始化
        if (BondSoulEvening.HowCoyote(sv_ADPileWineLieu) == AdjustStatus.OldUser.ToString() || BondSoulEvening.HowCoyote(sv_ADPileWineLieu) == AdjustStatus.OpenAsAct.ToString())
        {
            print("second login  and  init adjust");
            EffortWine();
        }
    }

    /*
    *  API
    *  标记老用户
    */
    public void YewTrayOld()
    {
        print("old user add adjust status");
        BondSoulEvening.OldCoyote(sv_ADPileWineLieu, AdjustStatus.OldUser.ToString());
        SpitAnvilPawnee.HowWhatever().HeroAnvil("1093", HowEffortSlit());
    }

    /*
     * API
     *  记录行为累计次数
     *  @param2 打点参数
     */
    public void BatFluPulse(string param2 = "")
    {
#if UNITY_IOS
        return;
#endif
        if (BondSoulEvening.HowCoyote(sv_ADPileWineLieu) != "") return;
        _ProducePulse++;
        print(" add up to :" + _ProducePulse);
        if (string.IsNullOrEmpty(CryBustPeg.instance.ShamanSoul.adjust_init_act_position) || _ProducePulse == int.Parse(CryBustPeg.instance.ShamanSoul.adjust_init_act_position))
        {
            WideEffortOrFlu(param2);
        }
    }

    /// <summary>
    /// 记录广告行为累计次数，带广告收入
    /// </summary>
    /// <param name="countryCode"></param>
    /// <param name="revenue"></param>
    public void BatSoPulse(string countryCode, double revenue)
    {
#if UNITY_IOS
        return;
#endif
        //if (BondSoulEvening.GetString(sv_ADJustInitType) != "") return;

        _ProducePulse++;
        _ProduceReality += revenue;
        print(" Ads count: " + _ProducePulse + ", Revenue sum: " + _ProduceReality);

        //如果后台有adjust_init_adrevenue数据 且 能找到匹配的countryCode，初始化adjustInitAdRevenue
        if (!string.IsNullOrEmpty(CryBustPeg.instance.ShamanSoul.adjust_init_adrevenue))
        {
            JsonData jd = JsonMapper.ToObject(CryBustPeg.instance.ShamanSoul.adjust_init_adrevenue);
            if (jd.ContainsKey(countryCode))
            {
                FourthWineSoReality = double.Parse(jd[countryCode].ToString(), new System.Globalization.CultureInfo("en-US"));
            }
        }

        if (
            string.IsNullOrEmpty(CryBustPeg.instance.ShamanSoul.adjust_init_act_position)                   //后台没有配置限制条件，直接走LoadAdjust
            || (_ProducePulse == int.Parse(CryBustPeg.instance.ShamanSoul.adjust_init_act_position)         //累计广告次数满足adjust_init_act_position条件，且累计广告收入满足adjust_init_adrevenue条件，走LoadAdjust
                && _ProduceReality >= FourthWineSoReality)
        )
        {
            WideEffortOrFlu();
        }
    }

    /*
     * API
     * 根据行为 初始化 adjust
     *  @param2 打点参数 
     */
    public void WideEffortOrFlu(string param2 = "")
    {
        if (BondSoulEvening.HowCoyote(sv_ADPileWineLieu) != "") return;

        // 根据比例分流   adjust_init_rate_act  行为比例
        if (string.IsNullOrEmpty(CryBustPeg.instance.ShamanSoul.adjust_init_rate_act) || int.Parse(CryBustPeg.instance.ShamanSoul.adjust_init_rate_act) > Random.Range(0, 100))
        {
            print("user finish  act  and  init adjust");
            BondSoulEvening.OldCoyote(sv_ADPileWineLieu, AdjustStatus.OpenAsAct.ToString());
            EffortWine();

            // 上报点位 新用户达成 且 初始化
            SpitAnvilPawnee.HowWhatever().HeroAnvil("1091", HowEffortSlit(), param2);
        }
        else
        {
            print("user finish  act  and  not init adjust");
            BondSoulEvening.OldCoyote(sv_ADPileWineLieu, AdjustStatus.CloseAsAct.ToString());
            // 上报点位 新用户达成 且  不初始化
            SpitAnvilPawnee.HowWhatever().HeroAnvil("1092", HowEffortSlit(), param2);
        }
    }


    /*
     * API
     *  重置当前次数
     */
    public void SwearFluPulse()
    {
        print("clear current ");
        _ProducePulse = 0;
    }


    // 获取启动时间
    private string HowEffortSlit()
    {
        return TautErie.Precede() - long.Parse(BondSoulEvening.HowCoyote(It_ADPileSlit)) + "";
    }
}


/*
 *@param
 *  OldUser     老用户
 *  OpenAsAct   行为触发且初始化
 *  CloseAsAct  行为触发不初始化
 */
public enum AdjustStatus
{
    OldUser,
    OpenAsAct,
    CloseAsAct
}