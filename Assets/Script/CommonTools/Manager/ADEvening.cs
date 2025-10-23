using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using com.adjust.sdk;
using LitJson;
using DG.Tweening;

public class ADEvening : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("MAX_SDK_KEY")]    public string MAX_SDK_KEY= "";
[UnityEngine.Serialization.FormerlySerializedAs("MAX_REWARD_ID")]    public string MAX_REWARD_ID= "";
[UnityEngine.Serialization.FormerlySerializedAs("MAX_INTER_ID")]    public string MAX_INTER_ID= "";
[UnityEngine.Serialization.FormerlySerializedAs("isTest")]
    public bool ItCult= false;
    public static ADEvening Whatever{ get; private set; }

    private int DitchMagnify;   // 广告加载失败后，重新加载广告次数
    private bool ItRainbowSo;     // 是否正在播放广告，用于判断切换前后台时是否增加计数

    public int ZoneDeadSlitDecease{ get; private set; }   // 距离上次广告的时间间隔
    public int Stencil101{ get; private set; }     // 定时插屏(101)计数器
    public int Stencil102{ get; private set; }     // NoThanks插屏(102)计数器
    public int Stencil103{ get; private set; }     // 后台回前台插屏(103)计数器

    private string UplandArtworkOver;
    private Action<bool> UplandExpoBackEndear;    // 激励视频回调
    private bool UplandSoloist;     // 激励视频是否成功收到奖励
    private string UplandMoody;     // 激励视频的打点

    private string EthnographicArtworkOver;
    private int EthnographicLieu;      // 当前播放的插屏类型，101/102/103
    private string EthnographicMoody;     // 插屏广告的的打点
    public bool AwardSlitIncreasingly{ get; private set; } // 定时插屏暂停播放

    private List<Action<ADType>> GoOctopusPetroleum;    // 广告播放完成回调列表，用于其他系统广告计数（例如商店看广告任务）

    private long PatriarchalEndowMagnetism;     // 切后台时的时间戳
    private Ad_CustomData GreeceSoEditorSoul; //激励视频自定义数据
    private Ad_CustomData IncreasinglySoEditorSoul; //插屏自定义数据
    private double IncreasinglyCourtship= 0;
    private void Awake()
    {
        Whatever = this;
    }

    private void OnEnable()
    {
        AwardSlitIncreasingly = false;
        ItRainbowSo = false;
        ZoneDeadSlitDecease = 999;  // 初始时设置一个较大的值，不阻塞插屏广告
        UplandSoloist = false;

        // Android平台将Adjust的adid传给Max；iOS将randomKey传给Max
#if UNITY_ANDROID
        MaxSdk.SetSdkKey(HowDefineSoul.AbilityDES(MAX_SDK_KEY));
        // 将adjust id 传给Max
        string adjustId = BondSoulEvening.HowCoyote(CShaman.It_EffortZinc);
        if (string.IsNullOrEmpty(adjustId))
        {
            adjustId = Adjust.getAdid();
        }
        if (!string.IsNullOrEmpty(adjustId))
        {
            MaxSdk.SetUserId(adjustId);
            MaxSdk.InitializeSdk();
            BondSoulEvening.OldCoyote(CShaman.It_EffortZinc, adjustId);
        }
        else
        {
            StartCoroutine(BowEffortZinc());
        }
#else
        MaxSdk.SetSdkKey(HowDefineSoul.AbilityDES(MAX_SDK_KEY));
        MaxSdk.SetUserId(BondSoulEvening.HowCoyote(CShaman.It_ElderTrayNo));
        MaxSdk.InitializeSdk();
#endif

        MaxSdkCallbacks.OnSdkInitializedEvent += (MaxSdkBase.SdkConfiguration sdkConfiguration) =>
        {
            // 打开调试模式
            //MaxSdk.ShowMediationDebugger();

            ImmobilizeForcefulAds();
            MaxSdk.SetCreativeDebuggerEnabled(true);

            // 每秒执行一次计数
            InvokeRepeating(nameof(ExpertStarve), 1, 1);
        };
    }

    IEnumerator BowEffortZinc()
    {
        int i = 0;
        while (i < 5)
        {
            yield return new WaitForSeconds(1);
            if (WinterErie.IDDredge())
            {
                MaxSdk.SetUserId(BondSoulEvening.HowCoyote(CShaman.It_ElderTrayNo));
                MaxSdk.InitializeSdk();
                yield break;
            }
            else
            {
                string adjustId = Adjust.getAdid();
                if (!string.IsNullOrEmpty(adjustId))
                {
                    MaxSdk.SetUserId(adjustId);
                    MaxSdk.InitializeSdk();
                    BondSoulEvening.OldCoyote(CShaman.It_EffortZinc, adjustId);
                    yield break;
                }
            }
            i++;
        }
        if (i == 5)
        {
            MaxSdk.SetUserId(BondSoulEvening.HowCoyote(CShaman.It_ElderTrayNo));
            MaxSdk.InitializeSdk();
        }
    }

    public void ImmobilizeForcefulAds()
    {
        // Attach callback
        MaxSdkCallbacks.Rewarded.OnAdLoadedEvent += OnRewardedAdLoadedEvent;
        MaxSdkCallbacks.Rewarded.OnAdLoadFailedEvent += OnRewardedAdLoadFailedEvent;
        MaxSdkCallbacks.Rewarded.OnAdDisplayedEvent += OnRewardedAdDisplayedEvent;
        MaxSdkCallbacks.Rewarded.OnAdClickedEvent += OnRewardedAdClickedEvent;
        MaxSdkCallbacks.Rewarded.OnAdRevenuePaidEvent += OnRewardedAdRevenuePaidEvent;
        MaxSdkCallbacks.Rewarded.OnAdHiddenEvent += OnRewardedAdHiddenEvent;
        MaxSdkCallbacks.Rewarded.OnAdDisplayFailedEvent += OnRewardedAdFailedToDisplayEvent;
        MaxSdkCallbacks.Rewarded.OnAdReceivedRewardEvent += OnRewardedAdReceivedRewardEvent;

        MaxSdkCallbacks.Interstitial.OnAdLoadedEvent += OnInterstitialLoadedEvent;
        MaxSdkCallbacks.Interstitial.OnAdLoadFailedEvent += OnInterstitialLoadFailedEvent;
        MaxSdkCallbacks.Interstitial.OnAdDisplayedEvent += OnInterstitialDisplayedEvent;
        MaxSdkCallbacks.Interstitial.OnAdClickedEvent += OnInterstitialClickedEvent;
        MaxSdkCallbacks.Interstitial.OnAdRevenuePaidEvent += OnInterstitialRevenuePaidEvent;
        MaxSdkCallbacks.Interstitial.OnAdHiddenEvent += OnInterstitialHiddenEvent;
        MaxSdkCallbacks.Interstitial.OnAdDisplayFailedEvent += OnInterstitialAdFailedToDisplayEvent;

        // Load the first rewarded ad
        WideForcefulSo();

        // Load the first interstitial
        WideIncreasingly();
    }

    private void WideForcefulSo()
    {
        MaxSdk.LoadRewardedAd(MAX_REWARD_ID);
    }

    private void WideIncreasingly()
    {
        MaxSdk.LoadInterstitial(MAX_INTER_ID);
    }

    private void OnRewardedAdLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Rewarded ad is ready for you to show. MaxSdk.IsRewardedAdReady(adUnitId) now returns 'true'.

        // Reset retry attempt
        DitchMagnify = 0;
        UplandArtworkOver = adInfo.NetworkName;

        GreeceSoEditorSoul = new Ad_CustomData();
        GreeceSoEditorSoul.user_id = CashOutManager.HowWhatever().Data.UserID;
        GreeceSoEditorSoul.version = Application.version;
        GreeceSoEditorSoul.request_id = CashOutManager.HowWhatever().EcpmRequestID();
        GreeceSoEditorSoul.vendor = adInfo.NetworkName;
    }

    private void OnRewardedAdLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    {
        // Rewarded ad failed to load 
        // AppLovin recommends that you retry with exponentially higher delays, up to a maximum delay (in this case 64 seconds).

        DitchMagnify++;
        double retryDelay = Math.Pow(2, Math.Min(6, DitchMagnify));

        Invoke(nameof(WideForcefulSo), (float)retryDelay);
    }

    private void OnRewardedAdDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
#if UNITY_IOS
        StarkPeg.HowWhatever().UpStarkElicit = !StarkPeg.HowWhatever().UpStarkElicit;
        Time.timeScale = 0;
#endif
    }

    private void OnRewardedAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
    {
        // Rewarded ad failed to display. AppLovin recommends that you load the next ad.
        WideForcefulSo();
        ItRainbowSo = false;
    }

    private void OnRewardedAdClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {

    }

    private void OnRewardedAdHiddenEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Rewarded ad is hidden. Pre-load the next ad
#if UNITY_IOS
        Time.timeScale = 1;
        StarkPeg.HowWhatever().UpStarkElicit = !StarkPeg.HowWhatever().UpStarkElicit;
#endif

        ItRainbowSo = false;
        WideForcefulSo();
        if (UplandSoloist)
        {
            UplandSoloist = false;
            UplandExpoBackEndear?.Invoke(true);

            DiverSoDeadSoloist(ADType.Rewarded);
            SpitAnvilPawnee.HowWhatever().HeroAnvil("9007", UplandMoody);
        }
        else
        {
            UplandExpoBackEndear?.Invoke(false);
        }

        // 上报ecpm
        CashOutManager.HowWhatever().ReportEcpm(adInfo, GreeceSoEditorSoul.request_id, "REWARD");
    }

    private void OnRewardedAdReceivedRewardEvent(string adUnitId, MaxSdk.Reward reward, MaxSdkBase.AdInfo adInfo)
    {
        // The rewarded ad displayed and the user should receive the reward.
        UplandSoloist = true;
    }

    private void OnRewardedAdRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo info)
    {
        // Ad revenue paid. Use this callback to track user revenue.
        //从MAX获取收入数据
        var adRevenue = new AdjustAdRevenue(AdjustConfig.AdjustAdRevenueSourceAppLovinMAX);
        adRevenue.setRevenue(info.Revenue, "USD");
        adRevenue.setAdRevenueNetwork(info.NetworkName);
        adRevenue.setAdRevenueUnit(info.AdUnitIdentifier);
        adRevenue.setAdRevenuePlacement(info.Placement);

        //发回收入数据给自己后台
        string countryCodeByMAX = MaxSdk.GetSdkConfiguration().CountryCode; // "US" for the United States, etc - Note: Do not confuse this with currency code which is "USD"
        SpitAnvilPawnee.HowWhatever().HeroAnvil("9008", info.Revenue.ToString(), countryCodeByMAX);

        //带广告收入的漏传策略
        //EffortWineEvening.Instance.AddAdCount(countryCodeByMAX, info.Revenue);

        string adjustAdid = EffortWineEvening.Instance.HowEffortZinc();
        //发回收入数据给Adjust
        if (!string.IsNullOrEmpty(adjustAdid))
        {
            Adjust.trackAdRevenue(adRevenue);
            UnityEngine.Debug.Log("Max to Adjust (rewarded), adUnitId:" + adUnitId + ", revenue:" + info.Revenue + ", network:" + info.NetworkName + ", unit:" + info.AdUnitIdentifier + ", placement:" + info.Placement);
        }

        // 发回收入数据给Mintegral
        if (!string.IsNullOrEmpty(adjustAdid))
        {
#if UNITY_ANDROID || UNITY_IOS
            MBridgeRevenueParamsEntity mBridgeRevenueParamsEntity = new MBridgeRevenueParamsEntity(MBridgeRevenueParamsEntity.ATTRIBUTION_PLATFORM_ADJUST, adjustAdid);
            ///MaxSdkBase.AdInfo类型的adInfo
            mBridgeRevenueParamsEntity.SetMaxAdInfo(info);
            MBridgeRevenueManager.Track(mBridgeRevenueParamsEntity);
            UnityEngine.Debug.Log(nameof(MBridgeRevenueManager) + "~Rewarded revenue:" + info.Revenue);
#endif
        }
    }

    private void OnInterstitialLoadedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad is ready for you to show. MaxSdk.IsInterstitialReady(adUnitId) now returns 'true'

        // Reset retry attempt
        DitchMagnify = 0;
        EthnographicArtworkOver = adInfo.NetworkName;

        IncreasinglySoEditorSoul = new Ad_CustomData();
        IncreasinglySoEditorSoul.user_id = CashOutManager.HowWhatever().Data.UserID;
        IncreasinglySoEditorSoul.version = Application.version;
        IncreasinglySoEditorSoul.request_id = CashOutManager.HowWhatever().EcpmRequestID();
        IncreasinglySoEditorSoul.vendor = adInfo.NetworkName;
    }

    private void OnInterstitialLoadFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    {
        // Interstitial ad failed to load 
        // AppLovin recommends that you retry with exponentially higher delays, up to a maximum delay (in this case 64 seconds)

        DitchMagnify++;
        double retryDelay = Math.Pow(2, Math.Min(6, DitchMagnify));

        Invoke(nameof(WideIncreasingly), (float)retryDelay);
    }

    private void OnInterstitialDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
#if UNITY_IOS
        StarkPeg.HowWhatever().UpStarkElicit = !StarkPeg.HowWhatever().UpStarkElicit;
        Time.timeScale = 0;
#endif
    }

    private void OnInterstitialAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad failed to display. AppLovin recommends that you load the next ad.
        WideIncreasingly();
        ItRainbowSo = false;
    }

    private void OnInterstitialClickedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo) { }

    private void OnInterstitialRevenuePaidEvent(string adUnitId, MaxSdkBase.AdInfo info)
    {
        //从MAX获取收入数据
        var adRevenue = new AdjustAdRevenue(AdjustConfig.AdjustAdRevenueSourceAppLovinMAX);
        adRevenue.setRevenue(info.Revenue, "USD");
        adRevenue.setAdRevenueNetwork(info.NetworkName);
        adRevenue.setAdRevenueUnit(info.AdUnitIdentifier);
        adRevenue.setAdRevenuePlacement(info.Placement);

        //发回收入数据给自己后台
        string countryCodeByMAX = MaxSdk.GetSdkConfiguration().CountryCode; // "US" for the United States, etc - Note: Do not confuse this with currency code which is "USD"
        SpitAnvilPawnee.HowWhatever().HeroAnvil("9108", info.Revenue.ToString(), countryCodeByMAX);

        //带广告收入的漏传策略
        //EffortWineEvening.Instance.AddAdCount(countryCodeByMAX, info.Revenue);

        //发回收入数据给Adjust
        if (!string.IsNullOrEmpty(EffortWineEvening.Instance.HowEffortZinc()))
        {
            Adjust.trackAdRevenue(adRevenue);
            UnityEngine.Debug.Log("Max to Adjust (interstitial), adUnitId:" + adUnitId + ", revenue:" + info.Revenue + ", network:" + info.NetworkName + ", unit:" + info.AdUnitIdentifier + ", placement:" + info.Placement);
        }

        // 发回收入数据给Mintegral
        string adjustAdid = EffortWineEvening.Instance.HowEffortZinc();
        if (!string.IsNullOrEmpty(adjustAdid))
        {
#if UNITY_ANDROID || UNITY_IOS
            MBridgeRevenueParamsEntity mBridgeRevenueParamsEntity = new MBridgeRevenueParamsEntity(MBridgeRevenueParamsEntity.ATTRIBUTION_PLATFORM_ADJUST, adjustAdid);
            ///MaxSdkBase.AdInfo类型的adInfo
            mBridgeRevenueParamsEntity.SetMaxAdInfo(info);
            MBridgeRevenueManager.Track(mBridgeRevenueParamsEntity);
            UnityEngine.Debug.Log(nameof(MBridgeRevenueManager) + "~Interstitial revenue:" + info.Revenue);
#endif
        }
    }

    private void OnInterstitialHiddenEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
        // Interstitial ad is hidden. Pre-load the next ad.
#if UNITY_IOS
        Time.timeScale = 1;
        StarkPeg.HowWhatever().UpStarkElicit = !StarkPeg.HowWhatever().UpStarkElicit;
#endif
        WideIncreasingly();

        DiverSoDeadSoloist(ADType.Interstitial);
        SpitAnvilPawnee.HowWhatever().HeroAnvil("9107", EthnographicMoody);
        // 上报ecpm
        CashOutManager.HowWhatever().ReportEcpm(adInfo, IncreasinglySoEditorSoul.request_id, "INTER");
    }


    /// <summary>
    /// 播放激励视频广告
    /// </summary>
    /// <param name="callBack"></param>
    /// <param name="index"></param>
    public void TillGreeceSugar(Action<bool> callBack, string index)
    {
        if (ItCult)
        {
            callBack(true);
            DiverSoDeadSoloist(ADType.Rewarded);
            return;
        }

        bool rewardVideoReady = MaxSdk.IsRewardedAdReady(MAX_REWARD_ID);
        UplandExpoBackEndear = callBack;
        if (rewardVideoReady)
        {
            // 打点
            UplandMoody = index;
            SpitAnvilPawnee.HowWhatever().HeroAnvil("9002", index);
            ItRainbowSo = true;
            UplandSoloist = false;
            string placement = index + "_" + UplandArtworkOver;
            GreeceSoEditorSoul.placement_id = placement;
            MaxSdk.ShowRewardedAd(MAX_REWARD_ID, placement, JsonMapper.ToJson(GreeceSoEditorSoul));
        }
        else
        {
            AllayEvening.HowWhatever().KnotAllay("No ads right now, please try it later.");
            UplandExpoBackEndear(false);
        }
    }

    /// <summary>
    /// 播放插屏广告
    /// </summary>
    /// <param name="index"></param>
    public void TillIncreasinglySo(int index)
    {
        if (index == 101 || index == 102 || index == 103)
        {
            UnityEngine.Debug.LogError("广告点位不允许为101、102、103");
            return;
        }

        TillIncreasingly(index);
    }

    /// <summary>
    /// 播放插屏广告
    /// </summary>
    /// <param name="index">101/102/103</param>
    /// <param name="customIndex">用户自定义点位</param>
    private void TillIncreasingly(int index, int customIndex = 0)
    {
        EthnographicLieu = index;

        if (ItRainbowSo)
        {
            return;
        }

        //这个参数很少有游戏会用 需要的时候自己再打开
         //当用户过关数 < trial_MaxNum时，不弹插屏广告
         int sv_trialNum = BondSoulEvening.HowGas(CShaman.It_Go_Hotel_Bed);
        int trial_MaxNum = int.Parse(CryBustPeg.instance.ShamanSoul.trial_MaxNum);
        if (sv_trialNum < trial_MaxNum)
        {
            return;
        }

        // 时间间隔低于阈值，不播放广告
        if (ZoneDeadSlitDecease < int.Parse(CryBustPeg.instance.ShamanSoul.inter_freq))
        {
            return;
        }

        if (ItCult)
        {
            DiverSoDeadSoloist(ADType.Interstitial);
            return;
        }

        bool interstitialVideoReady = MaxSdk.IsInterstitialReady(MAX_INTER_ID);
        if (interstitialVideoReady)
        {
            if (EthnographicLieu == 101)
            {
                ItRainbowSo = true;
                DOVirtual.DelayedCall(0.1f, () => //停顿
                {
                    UIEvening.HowWhatever().DodgeItInjectUITruth(nameof(ShrillAway));
                    string point = index.ToString();
                    if (customIndex > 0)
                    {
                        point += customIndex.ToString().PadLeft(2, '0');
                    }
                    EthnographicMoody = point;
                    SpitAnvilPawnee.HowWhatever().HeroAnvil("9102", point);
                    string placement = point + "_" + EthnographicArtworkOver;
                    IncreasinglySoEditorSoul.placement_id = placement;
                    MaxSdk.ShowInterstitial(MAX_INTER_ID, placement, JsonMapper.ToJson(IncreasinglySoEditorSoul));
                });
            }
            else
            {
                ItRainbowSo = true;
                // 打点
                string point = index.ToString();
                if (customIndex > 0)
                {
                    point += customIndex.ToString().PadLeft(2, '0');
                }
                EthnographicMoody = point;
                SpitAnvilPawnee.HowWhatever().HeroAnvil("9102", point);
                string placement = point + "_" + EthnographicArtworkOver;
                IncreasinglySoEditorSoul.placement_id = placement;
                MaxSdk.ShowInterstitial(MAX_INTER_ID, placement, JsonMapper.ToJson(IncreasinglySoEditorSoul));
            }
        }
    }

    /// <summary>
    /// 每秒更新一次计数器 - 101计数器 和 时间间隔计数器
    /// </summary>
    private void ExpertStarve()
    {
        ZoneDeadSlitDecease++;

        int relax_interval = int.Parse(CryBustPeg.instance.ShamanSoul.relax_interval);
        // 计时器阈值设置为0或负数时，关闭广告101；
        // 播放广告期间不计数；
        if (relax_interval <= 0 || ItRainbowSo)
        {
            return;
        }
        else
        {
            Stencil101++;
            if (Stencil101 >= relax_interval && !AwardSlitIncreasingly)
            {
                TillIncreasingly(101);
            }
            if (Stencil101 + 2 >= relax_interval && !AwardSlitIncreasingly)
            {
                if (ItRainbowSo)
                {
                    return;
                }
                int sv_trialNum = BondSoulEvening.HowGas(CShaman.It_Go_Hotel_Bed);
                int trial_MaxNum = int.Parse(CryBustPeg.instance.ShamanSoul.trial_MaxNum);
                if (sv_trialNum < trial_MaxNum)
                {
                    return;
                }
                if (ZoneDeadSlitDecease < int.Parse(CryBustPeg.instance.ShamanSoul.inter_freq))
                {
                    return;
                }
                if (ItCult)
                {
                    DiverSoDeadSoloist(ADType.Interstitial);
                    return;
                }
                bool interstitialVideoReady = MaxSdk.IsInterstitialReady(MAX_INTER_ID);
                if (interstitialVideoReady)
                {
                    IncreasinglyCourtship = GameUtil.GetInterstitialData();
                    UIEvening.HowWhatever().KnotUITruth(nameof(ShrillAway));
                    ShrillAway.Instance.WineSoul(IncreasinglyCourtship);
                }
            }
        }
    }

    /// <summary>
    /// NoThanks插屏 - 102
    /// </summary>
    public void DyAnimalBatPulse(int customIndex = 0)
    {
        // 用户行为累计次数计数器阈值设置为0或负数时，关闭广告102
        int nextlevel_interval = int.Parse(CryBustPeg.instance.ShamanSoul.nextlevel_interval);
        if (nextlevel_interval <= 0)
        {
            return;
        }
        else
        {
            Stencil102 = BondSoulEvening.HowGas("NoThanksCount") + 1;
            BondSoulEvening.OldGas("NoThanksCount", Stencil102);
            if (Stencil102 >= nextlevel_interval)
            {
                TillIncreasingly(102, customIndex);
            }
        }
    }

    /// <summary>
    /// 前后台切换计数器 - 103
    /// </summary>
    /// <param name="pause"></param>
    private void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            // 切回前台
            if (!ItRainbowSo)
            {
                // 前后台切换时，播放间隔计数器需要累加切到后台的时间
                if (PatriarchalEndowMagnetism > 0)
                {
                    ZoneDeadSlitDecease += (int)(TautErie.Precede() - PatriarchalEndowMagnetism);
                    PatriarchalEndowMagnetism = 0;
                }
                // 后台切回前台累计次数，后台配置为0或负数，关闭该广告
                int inter_b2f_count = int.Parse(CryBustPeg.instance.ShamanSoul.inter_b2f_count);
                if (inter_b2f_count <= 0)
                {
                    return;
                }
                else
                {
                    Stencil103++;
                    if (Stencil103 >= inter_b2f_count)
                    {
                        TillIncreasingly(103);
                    }
                }
            }
        }
        else
        {
            // 切到后台
            PatriarchalEndowMagnetism = TautErie.Precede();
        }
    }

    /// <summary>
    /// 暂停定时插屏播放 - 101
    /// </summary>
    public void EndowSlitIncreasingly()
    {
        AwardSlitIncreasingly = true;
    }

    /// <summary>
    /// 恢复定时插屏播放 - 101
    /// </summary>
    public void FatherSlitIncreasingly()
    {
        AwardSlitIncreasingly = false;
    }

    /// <summary>
    /// 更新游戏的TrialNum
    /// </summary>
    /// <param name="num"></param>
    public void MildlyCacheGet(int num)
    {
        BondSoulEvening.OldGas(CShaman.It_Go_Hotel_Bed, num);
    }

    /// <summary>
    /// 注册看广告的回调事件
    /// </summary>
    /// <param name="callback"></param>
    public void TerminalDeadImitator(Action<ADType> callback)
    {
        if (GoOctopusPetroleum == null)
        {
            GoOctopusPetroleum = new List<Action<ADType>>();
        }

        if (!GoOctopusPetroleum.Contains(callback))
        {
            GoOctopusPetroleum.Add(callback);
        }
    }

    /// <summary>
    /// 广告播放成功后，执行看广告回调事件
    /// </summary>
    private void DiverSoDeadSoloist(ADType adType)
    {
        ItRainbowSo = false;
        // 播放间隔计数器清零
        ZoneDeadSlitDecease = 0;
        // 插屏计数器清零
        if (adType == ADType.Interstitial)
        {
            // 计数器清零
            if (EthnographicLieu == 101)
            {
                MainDwarf.Instance.BatFare(IncreasinglyCourtship);
                Stencil101 = 0;
            }
            else if (EthnographicLieu == 102)
            {
                Stencil102 = 0;
                BondSoulEvening.OldGas("NoThanksCount", 0);
            }
            else if (EthnographicLieu == 103)
            {
                Stencil103 = 0;
            }
        }

        // 看广告总数+1
        BondSoulEvening.OldGas(CShaman.It_Scour_Go_Bed + adType.ToString(), BondSoulEvening.HowGas(CShaman.It_Scour_Go_Bed + adType.ToString()) + 1);
        // 真提现任务 
        if (adType == ADType.Rewarded)
            CashOutManager.HowWhatever().AddTaskValue("Ad",1);

        // 回调
        if (GoOctopusPetroleum != null && GoOctopusPetroleum.Count > 0)
        {
            foreach (Action<ADType> callback in GoOctopusPetroleum)
            {
                callback?.Invoke(adType);
            }
        }
    }

    /// <summary>
    /// 获取总的看广告次数
    /// </summary>
    /// <returns></returns>
    public int HowAriseSoGet(ADType adType)
    {
        return BondSoulEvening.HowGas(CShaman.It_Scour_Go_Bed + adType.ToString());
    }
}

public enum ADType { Interstitial, Rewarded }

[System.Serializable]
public class Ad_CustomData //广告自定义数据
{
    public string user_id; //用户id
    public string version; //版本号
    public string request_id; //请求id
    public string vendor; //渠道
    public string placement_id; //广告位id
}