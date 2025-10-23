/***
 * 
 * 
 * 网络信息控制
 * 
 * **/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System.Runtime.InteropServices;
using com.adjust.sdk;
//using AdjustSdk;
//using MoreMountains.NiceVibrations;

public class CryBustPeg : MonoBehaviour
{
[HideInInspector] [UnityEngine.Serialization.FormerlySerializedAs("DataFrom")]public string SoulWell; //数据来源 打点用
    public static CryBustPeg instance;
    //请求超时时间
    private static float TIMEOUT= 3f;
[UnityEngine.Serialization.FormerlySerializedAs("RealFee")]    //base
    public string RealFee;
[UnityEngine.Serialization.FormerlySerializedAs("BaseLoginUrl")]    //登录url
    public string RealStingFee;
[UnityEngine.Serialization.FormerlySerializedAs("BaseConfigUrl")]    //配置url
    public string RealShamanFee;
[UnityEngine.Serialization.FormerlySerializedAs("BaseTimeUrl")]    //时间戳url
    public string RealSlitFee;
[UnityEngine.Serialization.FormerlySerializedAs("BaseAdjustUrl")]    //更新AdjustId url
    public string RealEffortFee;
[UnityEngine.Serialization.FormerlySerializedAs("GameCode")]    //后台gamecode
    public string LullFeel= "20000";
[UnityEngine.Serialization.FormerlySerializedAs("Channel")]
    //channel渠道平台
#if UNITY_IOS
    public string Channel = "IOS";
#elif UNITY_ANDROID
    public string Conifer= "GooglePlay";
#else
    public string Channel = "Other";
#endif
    //工程包名
    private string DemeritOver{ get { return Application.identifier; } }
    //登录url
    private string StingUrl= "";
    //配置url
    private string ShamanFee= "";
    //更新AdjustId url
    private string EffortFee= "";
[UnityEngine.Serialization.FormerlySerializedAs("country")]    //国家
    public string Concern= "";
[UnityEngine.Serialization.FormerlySerializedAs("ConfigData")]    //服务器Config数据
    public ServerData ShamanSoul;
[UnityEngine.Serialization.FormerlySerializedAs("GameData")]    public GameData LullSoul;
[UnityEngine.Serialization.FormerlySerializedAs("InitData")]    //游戏内数据
    public Init WineSoul;
[UnityEngine.Serialization.FormerlySerializedAs("adManager")]    //ADEvening
    public GameObject GoEvening;
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("gaid")]    public string Exam;
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("aid")]    public string Wok;
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("idfa")]    public string Unit;
    int Plate_Lyric= 0;
[UnityEngine.Serialization.FormerlySerializedAs("ready")]    public bool Plate= false;
[UnityEngine.Serialization.FormerlySerializedAs("BlockRule")]    public BlockRuleData HenceWipe;
[UnityEngine.Serialization.FormerlySerializedAs("CashOut_Data")]    public CashOutData FareIts_Soul; //提现相关后台数据
                                     // ios 获取idfa函数声明
#if UNITY_IOS
        [DllImport("__Internal")]
        internal extern static void getIDFA();
#endif
    void Awake()
    {
        instance = this;
        Application.targetFrameRate = 240;
        StingUrl = RealStingFee + LullFeel + "&channel=" + Channel + "&version=" + Application.version;
        ShamanFee = RealShamanFee + LullFeel + "&channel=" + Channel + "&version=" + Application.version;
        EffortFee = RealEffortFee + LullFeel;
    }
    private void Start()
    {

        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaClass aj = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject p = aj.GetStatic<AndroidJavaObject>("currentActivity");
            p.Call("getGaid");
            p.Call("getAid");

        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
#if UNITY_IOS
            getIDFA();
            string idfv = UnityEngine.iOS.Device.vendorIdentifier;
            BondSoulEvening.OldCoyote("idfv", idfv);
#endif
        }
        else
        {
            Sting();           //编辑器登录
        }
        //获取config数据
        HowShamanSoul();
        CashOutManager.HowWhatever().Login();
    }

    /// <summary>
    /// 获取gaid回调
    /// </summary>
    /// <param name="gaid_str"></param>
    public void ExamEndear(string gaid_str)
    {
        Debug.Log("unity收到gaid：" + gaid_str);
        Exam = gaid_str; 
        if (Exam == null || Exam == "")
        {
            Exam = BondSoulEvening.HowCoyote("gaid");
        }
        else
        {
            BondSoulEvening.OldCoyote("gaid", Exam);
        }
        Plate_Lyric++;
        if (Plate_Lyric == 2)
        {
            Sting();
        }
    }
    /// <summary>
    /// 获取aid回调
    /// </summary>
    /// <param name="aid_str"></param>
    public void WokEndear(string aid_str)
    {
        Debug.Log("unity收到aid：" + aid_str);
        Wok = aid_str;
        if (Wok == null || Wok == "")
        {
            Wok = BondSoulEvening.HowCoyote("aid");
        }
        else
        {
            BondSoulEvening.OldCoyote("aid", Wok);
        }
        Plate_Lyric++;
        if (Plate_Lyric == 2)
        {
            Sting();
        }
    }
    /// <summary>
    /// 获取idfa成功
    /// </summary>
    /// <param name="message"></param>
    public void UnitSoloist(string message)
    {
        Debug.Log("idfa success:" + message);
        Unit = message;
        BondSoulEvening.OldCoyote("idfa", Unit);
        Sting();
    }
    /// <summary>
    /// 获取idfa失败
    /// </summary>
    /// <param name="message"></param>
    public void UnitGrip(string message)
    {
        Debug.Log("idfa fail");
        Unit = BondSoulEvening.HowCoyote("idfa");
        Sting();
    }
    /// <summary>
    /// 登录
    /// </summary>
    public void Sting()
    {
        CashOutManager.HowWhatever().Login();
        //获取本地缓存的Local用户ID
        string localId = BondSoulEvening.HowCoyote(CShaman.It_ElderTrayNo);

        //没有用户ID，视为新用户，生成用户ID
        if (localId == "" || localId.Length == 0)
        {
            //生成用户随机id
            TimeSpan st = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0);
            string timeStr = Convert.ToInt64(st.TotalSeconds).ToString() + UnityEngine.Random.Range(0, 10).ToString() + UnityEngine.Random.Range(1, 10).ToString() + UnityEngine.Random.Range(1, 10).ToString() + UnityEngine.Random.Range(1, 10).ToString();
            localId = timeStr;
            BondSoulEvening.OldCoyote(CShaman.It_ElderTrayNo, localId);
        }

        //拼接登录接口参数
        string url = "";
        if (Application.platform == RuntimePlatform.IPhonePlayer)       //一个参数 - iOS
        {
            url = StingUrl + "&" + "randomKey" + "=" + localId + "&idfa=" + Unit + "&packageName=" + DemeritOver;
        }
        else if (Application.platform == RuntimePlatform.Android)  //两个参数 - Android
        {
            url = StingUrl + "&" + "randomKey" + "=" + localId + "&gaid=" + Exam + "&androidId=" + Wok + "&packageName=" + DemeritOver;
        }
        else //编辑器
        {
            url = StingUrl + "&" + "randomKey" + "=" + localId + "&packageName=" + DemeritOver;
        }

        //获取国家信息
        EndConcave(() => {
            url += "&country=" + Concern;
            //登录请求
            CryCyanEvening.HowWhatever().HttpHow(url,
                (data) => {
                    Debug.Log("Login 成功" + data.downloadHandler.text);
                    BondSoulEvening.OldCoyote("init_time", DateTime.Now.ToString());
                    ServerUserData serverUserData = JsonMapper.ToObject<ServerUserData>(data.downloadHandler.text);
                    BondSoulEvening.OldCoyote(CShaman.It_ElderEndureNo, serverUserData.data.ToString());

                    HeroEffortZinc();
                    if (PlayerPrefs.GetInt("SendedEvent") != 1 && !String.IsNullOrEmpty(WinterErie.HereSee))
                        WinterErie.HeroAnvil();
                },
                () => {
                    Debug.Log("Login 失败");
                });
        });
    }
    /// <summary>
    /// 获取国家
    /// </summary>
    /// <param name="cb"></param>
    private void EndConcave(Action cb)
    {
        bool callBackReady = false;
        if (String.IsNullOrEmpty(Concern))
        {
            //获取国家超时返回
            StartCoroutine(CryCyanSlitIts(() =>
            {
                if (!callBackReady)
                {
                    Concern = "";
                    callBackReady = true;
                    cb?.Invoke();
                }
            }));
            CryCyanEvening.HowWhatever().HttpHow("https://a.mafiagameglobal.com/event/country/", (data) =>
            {
                Concern = JsonMapper.ToObject<Dictionary<string, string>>(data.downloadHandler.text)["country"];
                Debug.Log("获取国家 成功:" + Concern);
                if (!callBackReady)
                {
                    callBackReady = true;
                    cb?.Invoke();
                }
            },
            () => {
                Debug.Log("获取国家 失败");
                if (!callBackReady)
                {
                    Concern = "";
                    callBackReady = true;
                    cb?.Invoke();
                }
            });
        }
        else
        {
            if (!callBackReady)
            {
                callBackReady = true;
                cb?.Invoke();
            }
        }
    }

    /// <summary>
    /// 获取服务器Config数据
    /// </summary>
    private void HowShamanSoul()
    {
        Debug.Log("GetConfigData:" + ShamanFee);
        StartCoroutine(CryCyanSlitIts(() =>
        {
            HowMainstaySoul();
        }));

        //获取并存入Config
        CryCyanEvening.HowWhatever().HttpHow(ShamanFee,
        (data) => {
            SoulWell = "OnlineData";
            Debug.Log("ConfigData 成功" + data.downloadHandler.text);
            BondSoulEvening.OldCoyote("OnlineData", data.downloadHandler.text);
            OldShamanSoul(data.downloadHandler.text);
        },
        () => {
            HowMainstaySoul();
            Debug.Log("ConfigData 失败");
        });
    }

    /// <summary>
    /// 获取本地Config数据
    /// </summary>
    private void HowMainstaySoul()
    {
        //是否有缓存
        if (BondSoulEvening.HowCoyote("OnlineData") == "" || BondSoulEvening.HowCoyote("OnlineData").Length == 0)
        {
            Debug.Log("本地数据");
            SoulWell = "LocalData_Updated"; //已联网更新过的数据
            TextAsset json = Resources.Load<TextAsset>("LocationJson/LocationData");
            OldShamanSoul(json.text);
        }
        else
        {
            SoulWell = "LocalData_Original"; //原始数据
            Debug.Log("服务器缓存数据");
            OldShamanSoul(BondSoulEvening.HowCoyote("OnlineData"));
        }
    }


    /// <summary>
    /// 解析config数据
    /// </summary>
    /// <param name="configJson"></param>
    void OldShamanSoul(string configJson)
    {
        //如果已经获得了数据则不再处理
        if (ShamanSoul == null)
        {
            RootData rootData = JsonMapper.ToObject<RootData>(configJson);
            ShamanSoul = rootData.data;
            WineSoul = JsonMapper.ToObject<Init>(ShamanSoul.init);
            LullSoul = JsonMapper.ToObject<GameData>(ShamanSoul.game_data);
            if (!string.IsNullOrEmpty(ShamanSoul.BlockRule))
                HenceWipe = JsonMapper.ToObject<BlockRuleData>(ShamanSoul.BlockRule);
            if (!string.IsNullOrEmpty(ShamanSoul.CashOut_Data))
                FareIts_Soul = JsonMapper.ToObject<CashOutData>(ShamanSoul.CashOut_Data);
            HowTrayBust();
        }
    }
    /// <summary>
    /// 进入游戏
    /// </summary>
    void LullBless()
    {
        if (WinterErie.IDFluke())
        {

        }
        else
        {
            BookEvening.instance.Posthumously();
        }
        //打开admanager
        GoEvening.SetActive(true);
        //进度条可以继续
        Plate = true;
    }



    /// <summary>
    /// 超时处理
    /// </summary>
    /// <param name="finish"></param>
    /// <returns></returns>
    IEnumerator CryCyanSlitIts(Action finish)
    {
        yield return new WaitForSeconds(TIMEOUT);
        finish();
    }

    /// <summary>
    /// 向后台发送adjustId
    /// </summary>
    public void HeroEffortZinc()
    {
        string serverId = BondSoulEvening.HowCoyote(CShaman.It_ElderEndureNo);
        string adjustId = EffortWineEvening.Instance.HowEffortZinc();
        if (string.IsNullOrEmpty(serverId) || string.IsNullOrEmpty(adjustId))
        {
            return;
        }

        string url = EffortFee + "&serverId=" + serverId + "&adid=" + adjustId;
        CryCyanEvening.HowWhatever().HttpHow(url,
            (data) => {
                Debug.Log("服务器更新adjust adid 成功" + data.downloadHandler.text);
            },
            () => {
                Debug.Log("服务器更新adjust adid 失败");
            });
        CashOutManager.HowWhatever().ReportAdjustID();
    }
[UnityEngine.Serialization.FormerlySerializedAs("UserDataStr")]    //暂时去掉，屏蔽规则不再处理归因信息
    //轮询检查Adjust归因信息
    // int CheckCount = 0;
    // [HideInInspector] public string Event_TrackerName; //打点用参数
    // bool _CheckOk = false;
    // [HideInInspector]
    // public bool AdjustTracker_Ready //是否成功获取到归因信息 
    // {
    //     get
    //     {
    //         if (Application.isEditor) //编译器跳过检查
    //             return true;
    //         return _CheckOk;
    //     }
    // }
    // public void CheckAdjustNetwork() //检查Adjust归因信息
    // {
    //     if (Application.isEditor) //编译器跳过检查
    //         return;
    //     if (!string.IsNullOrEmpty(Event_TrackerName)) //已经拿到归因信息
    //         return;

    //     CancelInvoke(nameof(CheckAdjustNetwork));
    //     if (!string.IsNullOrEmpty(BlockRule.fall_down) && BlockRule.fall_down == "fall")
    //     {
    //         print("Adjust 无归因相关配置或未联网 跳过检查");
    //         _CheckOk = true;
    //     }
    //     try
    //     {
    //         AdjustAttribution Info = Adjust.getAttribution();
    //         print("Adjust 获取信息成功 归因渠道：" + Info.trackerName);
    //         Event_TrackerName = "TrackerName: " + Info.trackerName;
    //         WinterErie.Adjust_TrackerName = Info.trackerName;
    //         _CheckOk = true;
    //     }
    //     catch (System.Exception e)
    //     {
    //         CheckCount++;
    //         Debug.Log("Adjust 获取信息失败：" + e.Message + " 重试次数：" + CheckCount);
    //         if (CheckCount >= 10)
    //             _CheckOk = true;
    //         Invoke(nameof(CheckAdjustNetwork), 1);
    //     }
    // }


    //获取用户信息
    public string TraySoulOat= "";
[UnityEngine.Serialization.FormerlySerializedAs("UserData")]    public UserInfoData TraySoul;
    int HowTrayBustPulse= 0;
    void HowTrayBust()
    {
        //还有进入正常模式的可能
        if (PlayerPrefs.HasKey("OtherChance") && PlayerPrefs.GetString("OtherChance") == "YES")
            PlayerPrefs.DeleteKey("Save_AP");
        //已经记录过用户信息 跳过检查
        if (PlayerPrefs.HasKey("OtherChance") && PlayerPrefs.GetString("OtherChance") == "NO")
        {
            LullBless();
            return;
        }


        //检查归因渠道信息
        //CheckAdjustNetwork();
        //获取用户信息
        string CheckUrl = RealFee + "/api/client/user/checkUser";
        CryCyanEvening.HowWhatever().HttpHow(CheckUrl,
        (data) =>
        {
            TraySoulOat = data.downloadHandler.text;
            print("+++++ 获取用户数据 成功" + TraySoulOat);
            UserRootData rootData = JsonMapper.ToObject<UserRootData>(TraySoulOat);
            TraySoul = JsonMapper.ToObject<UserInfoData>(rootData.data);
            if (TraySoulOat.Contains("apple")
            || TraySoulOat.Contains("Apple")
            || TraySoulOat.Contains("APPLE"))
                TraySoul.IsHaveApple = true;
            LullBless();
        }, () => { });
        Invoke(nameof(ReHowTrayBust), 1);
    }
    void ReHowTrayBust()
    {
        if (!Plate)
        {
            HowTrayBustPulse++;
            if (HowTrayBustPulse < 10)
            {
                print("+++++ 获取用户数据失败 重试： " + HowTrayBustPulse);
                HowTrayBust();
            }
            else
            {
                print("+++++ 获取用户数据 失败次数过多，放弃");
                LullBless();
            }
        }
    }
}
