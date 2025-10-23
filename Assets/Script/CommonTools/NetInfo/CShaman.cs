/**
 * 
 * 常量配置
 * 
 * 
 * **/
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CShaman
{
    #region 常量字段
    //登录url
    public const string StingUrl= "/api/client/user/getId?gameCode=";
    //配置url
    public const string ShamanFee= "/api/client/config?gameCode=";
    //时间戳url
    public const string SlitFee= "/api/client/common/current_timestamp?gameCode=";
    //更新AdjustId url
    public const string EffortFee= "/api/client/user/setAdjustId?gameCode=";
    #endregion

    #region 本地存储的字符串
    /// <summary>
    /// 本地用户id (string)
    /// </summary>
    public const string It_ElderTrayNo= "sv_LocalUserId";
    /// <summary>
    /// 本地服务器id (string)
    /// </summary>
    public const string It_ElderEndureNo= "sv_LocalServerId";
    /// <summary>
    /// 是否是新用户玩家 (bool)
    /// </summary>
    public const string It_IDNssUntold= "sv_IsNewPlayer";
    public const string It_Warp_Dull_Pest_On= "sv_user_show_rate_us";


    /// <summary>
    /// 签到次数 (int)
    /// </summary>
    public const string It_BelleSlideHowPulse= "sv_DailyBounsGetCount";
    /// <summary>
    /// 签到最后日期 (int)
    /// </summary>
    public const string It_BelleSlideDate= "sv_DailyBounsDate";
    /// <summary>
    /// 新手引导完成的步数
    /// </summary>
    public const string It_NssTrayHere= "sv_NewUserStep";
    /// <summary>
    /// 金币余额
    /// </summary>
    public const string It_HallAiry= "sv_GoldCoin";
    /// <summary>
    /// 累计金币总数
    /// </summary>
    public const string It_ImmobilizeHallAiry= "sv_CumulativeGoldCoin";
    /// <summary>
    /// 钻石/现金余额
    /// </summary>
    public const string It_Breed= "sv_Token";
    /// <summary>
    /// 累计钻石/现金总数
    /// </summary>
    public const string It_ImmobilizeBreed= "sv_CumulativeToken";
    /// <summary>
    /// 打点当前现金
    /// </summary>
    public const string It_NakedFareBreed= "sv_PointCashToken";
    /// <summary>
    /// 钻石Amazon
    /// </summary>
    public const string It_Degree= "sv_Amazon";
    /// <summary>
    /// 累计Amazon总数
    /// </summary>
    public const string It_ImmobilizeDegree= "sv_CumulativeAmazon";
    /// <summary>
    /// 游戏总时长
    /// </summary>
    public const string It_AriseLullSlit= "sv_TotalGameTime";
    /// <summary>
    /// 第一次获得钻石奖励
    /// </summary>
    public const string It_AfterHowBreed= "sv_FirstGetToken";
    /// <summary>
    /// 是否已显示评级弹框
    /// </summary>
    public const string It_HasKnotLastDwarf= "sv_HasShowRatePanel";
    /// <summary>
    /// 累计Roblox奖券总数
    /// </summary>
    public const string It_ImmobilizeHarmony= "sv_CumulativeLottery";
    /// <summary>
    /// 已经通过一次的关卡(int array)
    /// </summary>
    public const string It_FoundryPlusValley= "sv_AlreadyPassLevels";
    /// <summary>
    /// 新手引导
    /// </summary>
    public const string It_NssTrayHereUnfold= "sv_NewUserStepFinish";
    public const string It_Lobe_Score_Lyric= "sv_task_level_count";
    // 是否第一次使用过slot
    public const string It_AfterPray= "sv_FirstSlot";

        public const string It_AfterHotGreece= "sv_FirstLowReward";
    /// <summary>
    /// adjust adid
    /// </summary>
    public const string It_EffortZinc= "sv_AdjustAdid";

    /// <summary>
    /// 广告相关 - trial_num
    /// </summary>
    public const string It_Go_Hotel_Bed= "sv_ad_trial_num";
    /// <summary>
    /// 看广告总次数
    /// </summary>
    public const string It_Scour_Go_Bed= "sv_total_ad_num";

    /// <summary>
    /// 存储天
    /// </summary>
    public static string It_HurlBrandTautAie= "sv_LastCheckDateKey";
    /// <summary>
    /// 天奖励
    /// </summary>
    public static string It_BelleGreece= "sv_DailyReward";

    #endregion

    #region 监听发送的消息

    /// <summary>
    /// 有窗口打开
    /// </summary>
    public static string To_PurelyYork= "mg_WindowOpen";
    /// <summary>
    /// 窗口关闭
    /// </summary>
    public static string To_PurelyDodge= "mg_WindowClose";
    /// <summary>
    /// 关卡结算时传值
    /// </summary>
    public static string To_ui_Daguerreotype= "mg_ui_levelcomplete";
    /// <summary>
    /// 增加金币
    /// </summary>
    public static string To_So_Thunder= "mg_ui_addgold";
    /// <summary>
    /// 增加钻石/现金
    /// </summary>
    public static string To_So_addtoken= "mg_ui_addtoken";
    /// <summary>
    /// 增加amazon
    /// </summary>
    public static string To_So_Aborigine= "mg_ui_addamazon";

    /// <summary>
    /// 游戏暂停/继续
    /// </summary>
    public static string To_LullComfort= "mg_GameSuspend";

    /// <summary>
    /// 游戏资源数量变化
    /// </summary>
    public static string To_HighHalite_= "mg_ItemChange_";

    /// <summary>
    /// 活动状态变更
    /// </summary>
    public static string To_CivilityVogueHalite_= "mg_ActivityStateChange_";

    /// <summary>
    /// 关卡最大等级变更
    /// </summary>
    public static string To_DeltaStyDeltaHalite= "mg_LevelMaxLevelChange";

    /// <summary>
    /// combo
    /// </summary>
    public static string To_OrPartyUpdata= "mg_OnComboUpdatas";
    /// <summary>
    /// combo show
    /// </summary>
    public static string To_OrPartyKnot= "mg_OnComboShow";
    /// <summary>
    /// combo show
    /// </summary>
    public static string To_OrBatRoute= "mg_OnAddScore";
    /// <summary>
    /// combo show
    /// </summary>
    public static string To_SpringEyeGreece= "mg_UpdataDayReward";

    public static string To_OrAngularThird= "mg_OnMahjongClick";

    #endregion

    #region 动态加载资源的路径

    // 金币图片
    public static string Live_HallAiry_Corpse= "Art/Tex/UI/jiangli1";
    // 钻石图片
    public static string Live_Breed_Corpse_Author= "Art/Tex/UI/jiangli4";

    #endregion
}

