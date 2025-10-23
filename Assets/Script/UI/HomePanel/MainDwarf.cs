using DG.Tweening;
using LitJson;
using Mkey;
using Spine;
using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class MainDwarf : RealUITruth
{
    public static MainDwarf Instance;
[UnityEngine.Serialization.FormerlySerializedAs("GoldBar")]
    public GameObject HallTie;
[UnityEngine.Serialization.FormerlySerializedAs("BackBtn")]
    public Button LashSty;
[UnityEngine.Serialization.FormerlySerializedAs("SettingBtn")]    public Button AdjunctSty;
[UnityEngine.Serialization.FormerlySerializedAs("SelectBtn")]    public Button ElevenSty;
[UnityEngine.Serialization.FormerlySerializedAs("SelectText")]    public Text ElevenPity;
[UnityEngine.Serialization.FormerlySerializedAs("SelectLevelObj")]    public GameObject ElevenDeltaSad;
[UnityEngine.Serialization.FormerlySerializedAs("cashImg")]
    public Image LashRag;
[UnityEngine.Serialization.FormerlySerializedAs("cashNumText")]    public Text LashGetPity;
[UnityEngine.Serialization.FormerlySerializedAs("LevelText")]    public Text DeltaPity;
[UnityEngine.Serialization.FormerlySerializedAs("instrans")]    public Transform Abrasion;

    // 提示相关UI组件
    [Header("提示面板")]
[UnityEngine.Serialization.FormerlySerializedAs("tipPanel")]    public GameObject MawDwarf; // 提示面板
[UnityEngine.Serialization.FormerlySerializedAs("tipText")]    public Text MawPity; // 提示文本
[UnityEngine.Serialization.FormerlySerializedAs("tipBackground")]    public Image MawUnoccupied; // 提示背景
[UnityEngine.Serialization.FormerlySerializedAs("tipCloseButton")]    public Button MawDodgeSeaman; // 提示关闭按钮
[UnityEngine.Serialization.FormerlySerializedAs("ComboanimPB")]
    public Technical TechnicalPB;
[UnityEngine.Serialization.FormerlySerializedAs("ComboParent")]    public Transform PartyWeaver;
[UnityEngine.Serialization.FormerlySerializedAs("DayTimeBtn")]    public Button EyeSlitSty;
[UnityEngine.Serialization.FormerlySerializedAs("DayTimeRedPoint")]    public GameObject EyeSlitMowNaked;
[UnityEngine.Serialization.FormerlySerializedAs("CashoutBtn")]    public RectTransform KinfolkSty;
[UnityEngine.Serialization.FormerlySerializedAs("TimeDown")]    public int SlitMust= 0;

    // 保存CashoutBtn的原始位置
    private Vector2 FidelityKinfolkStySynapsis;
[UnityEngine.Serialization.FormerlySerializedAs("m_SkBG")]
    public SkeletonGraphic m_BeBG;
[UnityEngine.Serialization.FormerlySerializedAs("m_SkSetting")]    public SkeletonGraphic m_BeAdjunct;
[UnityEngine.Serialization.FormerlySerializedAs("m_Bottomobj")]    public GameObject m_Regulator;
[UnityEngine.Serialization.FormerlySerializedAs("GoldImg")]    public Image HallRag;
[UnityEngine.Serialization.FormerlySerializedAs("GoldFly")]    public GameObject HallAxe;
[UnityEngine.Serialization.FormerlySerializedAs("Logo")]    public GameObject Form;
[UnityEngine.Serialization.FormerlySerializedAs("settingbtn1")]
    public Button Schoolroom1; //
[UnityEngine.Serialization.FormerlySerializedAs("Coin")]
    public GameObject Airy;
[UnityEngine.Serialization.FormerlySerializedAs("Coinimage")]    public Image Diversity;
[UnityEngine.Serialization.FormerlySerializedAs("CoinStr")]    public Text AiryOat;


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        if (WinterErie.IDFluke())
        {
            Airy.SetActive(true);
            KinfolkSty.gameObject.SetActive(false);

        }
        else
        {
            Airy.SetActive(false);
            KinfolkSty.gameObject.SetActive(true);

        }

        // 监听动画结束事件
        m_BeBG.AnimationState.Complete += OnBGComplete;
        m_BeAdjunct.AnimationState.Complete += OnSetComplete;
        LullGuinea.DeltaWideGasolineEndear += OnLevelComplete;
        LullGuinea.HallFeasible += HallFeasible;


        // 监听提示事件
        LullGuinea.KnotTipEndear += OnShowTip;
        LullGuinea.KnotFewPatrolEndear += OnShowTipManual;
        LullGuinea.BeefFewEndear += OnHideTip;

        LashSty.onClick.AddListener(() =>
        {
            FidelityKinfolkStySynapsis = new Vector2(0, -146);
            ElevenDeltaSad.gameObject.SetActive(true);
            m_BeBG.AnimationState.ClearTracks();
            m_BeBG.AnimationState.SetAnimation(0, "3close", false);
            m_BeAdjunct.AnimationState.ClearTracks();
            m_BeAdjunct.AnimationState.SetAnimation(0, "1open", false);
            PlagueTractorDeltaPity();
            SlaveryKinfolkStyMelody();
        });
        EyeSlitSty.onClick.AddListener(() =>
        {
            YorkUIEddy(nameof(SlitGreece));
        });

        ElevenSty.onClick.AddListener(() =>
        {
            FidelityKinfolkStySynapsis = new Vector2(0, -277);
            ElevenSty.gameObject.SetActive(false);
            m_BeBG.AnimationState.ClearTracks();
            m_BeBG.AnimationState.SetAnimation(0, "1open", false);
            m_BeAdjunct.AnimationState.ClearTracks();
            m_BeAdjunct.AnimationState.SetAnimation(0, "3close", false);
            Form.SetActive(false);
            SlaveryKinfolkStyMelody();

            // 新增：点击SelectBtn时让新手引导开始检测
            if (Mkey.SeparatePrice.Whatever != null)
            {
                if (Mkey.LullDeltaMisery.PrecedeDelta == 0)
                {
                    Mkey.SeparatePrice.Whatever.VaultSeparatePrice();
                }
                else if (Mkey.LullDeltaMisery.PrecedeDelta == 1)
                {
                    Mkey.SeparatePrice.Whatever.VaultSeparatePriceLieDelta2();
                }
            }
        });
        Schoolroom1.onClick.AddListener(() =>
        {
            YorkUIEddy(nameof(AdjunctDwarf));
        });
        AdjunctSty.onClick.AddListener(() =>
        {
            YorkUIEddy(nameof(AdjunctDwarf));
        });
        OutdoorLegend.BatTugSolution(CShaman.To_OrPartyKnot, OnComboUpdate);
        OutdoorLegend.BatTugSolution(CShaman.To_OrBatRoute, OnCashUpdate);
        OutdoorLegend.BatTugSolution(CShaman.To_SpringEyeGreece, OnUpdateDayReward);

        BelleGreeceVault();
        TractorDeltaPity(); // 初始化时刷新关卡文本

        // 保存CashoutBtn的原始位置

        OldFacadeVogue();

        // 初始化提示面板
        WineFewDwarf();

        // 新增：监听新手引导开始/结束事件，控制按钮可用性
        LullGuinea.SeparatePriceHoldingEndear += OnTutorialGuideStarted;
        LullGuinea.SeparatePriceEmberEndear += OnTutorialGuideEnded;

        m_BeAdjunct.AnimationState.SetAnimation(0, "1open", false);
        KinfolkSty.anchoredPosition = new Vector2(0, -146);
    }

    /// <summary>
    /// 初始化提示面板
    /// </summary>
    private void WineFewDwarf()
    {
        if (MawDwarf != null)
        {
            // 初始时隐藏
            MawDwarf.SetActive(false);

            // 设置关闭按钮事件
            if (MawDodgeSeaman != null)
            {
                MawDodgeSeaman.onClick.AddListener(OnHideTip);
            }
        }
    }

    /// <summary>
    /// 显示提示事件处理
    /// </summary>
    private void OnShowTip(string message, float duration)
    {
        KnotFew(message, duration);
    }

    /// <summary>
    /// 显示提示（手动关闭）事件处理
    /// </summary>
    private void OnShowTipManual(string message)
    {
        KnotFew(message, 0f); // 传入0表示不自动关闭
    }

    /// <summary>
    /// 隐藏提示事件处理
    /// </summary>
    private void OnHideTip()
    {
        BeefFew();
    }

    /// <summary>
    /// 显示提示
    /// </summary>
    /// <param name="message">提示信息</param>
    /// <param name="duration">显示时长（秒），0表示不自动隐藏，需要手动调用HideTip()关闭</param>
    public void KnotFew(string message, float duration = 0f)
    {
        if (MawPity != null)
        {
            MawPity.text = message;
        }

        if (MawDwarf != null)
        {
            MawDwarf.SetActive(true);

            // 淡入动画
            CanvasGroup canvasGroup = MawDwarf.GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = MawDwarf.AddComponent<CanvasGroup>();
            }

            canvasGroup.alpha = 0f;
            canvasGroup.DOFade(1f, 0.3f);

            // 如果设置了自动隐藏时间（大于0）
            if (duration > 0)
            {
                DOVirtual.DelayedCall(duration, () =>
                {
                    BeefFew();
                });
            }
        }
    }

    /// <summary>
    /// 隐藏提示
    /// </summary>
    public void BeefFew()
    {
        if (MawDwarf != null)
        {
            CanvasGroup canvasGroup = MawDwarf.GetComponent<CanvasGroup>();
            if (canvasGroup != null)
            {
                canvasGroup.DOFade(0f, 0.3f).OnComplete(() =>
                {
                    MawDwarf.SetActive(false);
                });
            }
            else
            {
                MawDwarf.SetActive(false);
            }
        }
    }

    /// <summary>
    /// 静态方法，供外部调用显示提示（自动关闭）
    /// </summary>
    /// <param name="message">提示信息</param>
    /// <param name="duration">显示时长（秒），0表示不自动隐藏</param>
    public static void KnotFewOutdoor(string message, float duration = 3f)
    {
        if (Instance != null)
        {
            Instance.KnotFew(message, duration);
        }
    }

    /// <summary>
    /// 静态方法，供外部调用显示提示（手动关闭）
    /// </summary>
    /// <param name="message">提示信息</param>
    public static void KnotFewOutdoorPatrol(string message)
    {
        if (Instance != null)
        {
            Instance.KnotFew(message, 0f); // 传入0表示不自动关闭
        }
    }

    /// <summary>
    /// 静态方法，供外部调用隐藏提示
    /// </summary>
    public static void BeefFewOutdoor()
    {
        if (Instance != null)
        {
            Instance.BeefFew();
        }
    }

    private void OnLevelComplete()
    {
        Debug.Log("MainDwarf 监听到过关事件");
        OldFacadeVogue();
        // 进度条归零
        if (HallRag != null && HallRag.gameObject.activeInHierarchy)
        {
            DG.Tweening.DOTween.Kill(HallRag, "GoldFill");
            DG.Tweening.DOTween.To(() => HallRag.fillAmount, x => HallRag.fillAmount = x, 0f, 0.3f)
                .SetId("GoldFill");
        }
    }
    // goldMul是总进度，count是当前进度，GoldImg是进度图片，GoldFly是金币预制体
    // posTrans为目标位置列表，callBack为飞行完成回调
    public void HallFeasible(int count, bool flystate, List<Transform> posTrans, Action callBack)
    {
        int goldMul = CryBustPeg.instance.LullSoul.combogold;
        float targetFill = Mathf.Clamp01((float)count / goldMul);
        // DOTween动画进度条
        if (HallRag != null && HallRag.gameObject.activeInHierarchy)
        {
            if (!Mathf.Approximately(HallRag.fillAmount, targetFill))
            {
                DG.Tweening.DOTween.Kill(HallRag, "GoldFill");
                DG.Tweening.DOTween.To(() => HallRag.fillAmount, x => HallRag.fillAmount = x, targetFill, 0.3f)
                    .SetId("GoldFill");
            }
        }
        // 满了且需要飞行
        if (count >= goldMul && flystate && posTrans != null && posTrans.Count >= 2)
        {
            // 生成两个金币飞行
            for (int i = 0; i < 2; i++)
            {
                GameObject fly = Instantiate(HallAxe, HallRag.transform.position, Quaternion.identity, HallRag.transform.parent);
                Vector3 targetPos = posTrans[i].position;
                fly.transform.SetAsLastSibling();
                fly.transform.DOMove(targetPos, 0.6f).SetEase(DG.Tweening.Ease.InQuad).OnComplete(() =>
                {
                    Destroy(fly);
                    // 两个都完成后回调
                    LimyAxeUnfoldPulse++;
                    if (LimyAxeUnfoldPulse == 2)
                    {
                        LimyAxeUnfoldPulse = 0;
                        callBack?.Invoke();
                    }
                });
            }
        }
    }
    private int LimyAxeUnfoldPulse= 0;

    private void OldFacadeVogue()
    {
        if (Mkey.LullDeltaMisery.PrecedeDelta <= 1)
        {
            m_Regulator.SetActive(false);
        }
        else
        {
            m_Regulator.SetActive(true);
        }
    }

    private void OnBGComplete(TrackEntry trackEntry)
    {
        if (trackEntry != null)
        {
            if (trackEntry.Animation.Name == "1open")
            {
                ElevenDeltaSad.gameObject.SetActive(false);
            }

            if (trackEntry.Animation.Name == "3close")
            {
                ElevenSty.gameObject.SetActive(true);
                Form.SetActive(true);
                m_BeBG.AnimationState.ClearTracks();
                m_BeBG.AnimationState.SetAnimation(0, "2idle", true);
            }
        }

    }
    private void OnSetComplete(TrackEntry trackEntry)
    {
        if (trackEntry != null)
        {
            if (trackEntry.Animation.Name == "1open" || trackEntry.Animation.Name == "3close")
            {
                m_BeAdjunct.AnimationState.ClearTracks();
                m_BeAdjunct.AnimationState.SetAnimation(0, "2idle", true);
            }
        }
    }
    private void OnUpdateDayReward(KeyValuesUpdate kv)
    {
        BelleGreeceVault();
    }

    private void OnCashUpdate(KeyValuesUpdate kv)
    {
        addScoreData sendData = (addScoreData)kv.Stable;
        Abrasion.position = sendData.Anyway3Our;
        BatFare(sendData.PartyPulse, Abrasion);
    }

    private void OnComboUpdate(KeyValuesUpdate kv)
    {
        HeroSoul sendData = (HeroSoul)kv.Stable;
        //Canvas canvas = UIEvening.GetInstance().MainCanvas.GetComponent<Canvas>();
        //Vector2  pos = WorldToCanvasPos(canvas, sendData.Vector3pos);
        //Technical combo =  Instantiate(ComboanimPB, ComboParent);
        //RectTransform rect = combo.GetComponent<RectTransform>();
        //rect.anchoredPosition = pos;
        TechnicalPB.DeadGold(sendData.PartyPulse);


        //Debug.Log(kv.Key);
    }
   


    /// <summary>
    /// 世界坐标转换为画布坐标
    /// </summary>
    /// <param name="canvas">画布</param>
    /// <param name="world">世界坐标</param>
    /// <returns></returns>
    private Vector2 KneelDySpherePot(Canvas canvas, Vector3 world)
    {
        Vector2 Latitude;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, world, canvas.GetComponent<Camera>(), out Latitude);
        return Latitude;
    }
    public void BatFare(double cash, Transform objTrans = null)
    {
        LullSoulEvening.HowWhatever().FewBreed(cash);
        FareBatCertainty(objTrans, 5);
    }
    private void FareBatCertainty(Transform startTransform, double num)
    {
      
            if(WinterErie.IDFluke())
            {
  BatCertainty(startTransform, Diversity.transform, Diversity.gameObject, AiryOat,
            LullSoulEvening.HowWhatever().EndBreed(), num);
            }
            else{
  BatCertainty(startTransform, LashRag.transform, LashRag.gameObject, LashGetPity,
            LullSoulEvening.HowWhatever().EndBreed(), num);
            }
    }
    private void BatCertainty(Transform startTransform, Transform endTransform, GameObject icon, Text text,
       double textValue, double num)
    {
        if (startTransform != null)
        {
            CertaintyModerately.HallFinePeak(icon, Mathf.Max((int)num, 1), startTransform, endTransform,
                () =>
                {
                    ///StarkPeg.GetInstance().PlayEffect(StarkLieu.SceneMusic.sound_getcoin);
                    CertaintyModerately.HaliteGallop(double.Parse(text.text), textValue, 0.1f, text,
                        () => { text.text = GallopErie.SyntaxDyOat(textValue); });
                });
        }
        else
        {
            CertaintyModerately.HaliteGallop(double.Parse(text.text), textValue, 0.1f, text,
                () => { text.text = GallopErie.SyntaxDyOat(textValue); });
        }
    }

    private void BelleGreeceVault()
    {
        List<DayRewardData> GemGreeceFlask= new List<DayRewardData>();
        string[] datas = new string[4];
        datas = BondSoulEvening.HowCoyoteBelle(CShaman.It_BelleGreece);
        long nowtime = GameUtil.GetNowTime();
        bool redState = false;
        for (int i = 0; i < datas.Length; i++)
        {
            string data = datas[i];
            DayRewardData dayData = JsonMapper.ToObject<DayRewardData>(data);
            GemGreeceFlask.Add(dayData);
            DayRewardData deforRewardData = GemGreeceFlask.Find(x => x.dataIndex == (i - 1));
            bool beforGet = true;
            if (deforRewardData != null)
            {
                beforGet = deforRewardData.getState == 1;
            }
            if (nowtime > dayData.look_time)
            {
                if (dayData.getState == 0)
                {
                    redState = true;
                    break;
                }
            }
            else
            {
                if (beforGet == true)
                {
                    if (SlitMust != 0)
                    {
                        RainyEvening.Whatever.LingRainy(SlitMust);
                    }
                    SlitMust = RainyEvening.Whatever.VaultRainy(1, () => //启动计时器
                    {
                        int times = dayData.look_time - (int)GameUtil.GetNowTime();
                        if (times <= 0)
                        {
                            Debug.Log("计时完成");
                            RainyEvening.Whatever.LingRainy(SlitMust);
                            EyeSlitMowNaked.SetActive(true);
                        }
                    }, true);
                    break;
                }
            }
        }
        EyeSlitMowNaked.SetActive(redState);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            UIEvening.HowWhatever().KnotUITruth(nameof(NotGrand));
        }
        // 测试用：按下B键切换到下一关
        if (Input.GetKeyDown(KeyCode.B))
        {
            // 关卡号自增并保存
            Mkey.LullDeltaMisery.OldPrecedeDeltaCanBond(Mkey.LullDeltaMisery.PrecedeDelta + 1);
            // 先清理旧麻将牌对象
            if (LullSyrup.Whatever != null)
            {
                LullSyrup.Whatever.OceaniaSoda(); // 清理旧麻将
                LullSyrup.Whatever.LiableLullSyrup(); // 用新关卡号重建关卡
            }
            // 触发关卡开始事件，刷新UI（包括GameLevelHelper等）
            Mkey.LullDeltaMisery.VaultDelta();
            // 刷新主界面关卡号显示

        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            UIEvening.HowWhatever().KnotUITruth(nameof(DeltaGasolineDwarf));
        }

    }

    /// <summary>
    /// 刷新关卡文本，显示当前关卡号
    /// </summary>
    public void TractorDeltaPity()
    {
        if (DeltaPity != null)
        {
            int Score= Mkey.LullDeltaMisery.PrecedeDelta; // 获取当前关卡号
            DeltaPity.text = $"LEVEL {Score + 1}"; // 设置关卡文本
        }
    }

    /// <summary>
    /// 静态方法，供外部调用刷新关卡文本
    /// </summary>
    public static void PlagueTractorDeltaPity()
    {
        if (Instance != null)
        {
            Instance.TractorDeltaPity();
        }
    }

    /// <summary>
    /// 让CashoutBtn移出屏幕显示范围，然后等待指定时间后移回原位置
    /// </summary>
    /// <param name="waitTime">等待时间（秒）</param>
    /// <param name="moveOutDuration">移出动画时长（秒）</param>
    /// <param name="moveInDuration">移入动画时长（秒）</param>
    /// <param name="onComplete">动画完成回调</param>
    public void SlaveryKinfolkSty(float waitTime = 2f, float moveOutDuration = 0.7f, float moveInDuration = 0.5f, Action onComplete = null)
    {
        if (KinfolkSty == null)
        {
            Debug.LogError("CashoutBtn is null!");
            onComplete?.Invoke();
            return;
        }

        // 停止之前的动画
        KinfolkSty.DOKill();

        // 第一步：移出屏幕（Y轴移动到300）
        Vector2 moveOutPosition = new Vector2(KinfolkSty.anchoredPosition.x, 300f);

        KinfolkSty.DOAnchorPos(moveOutPosition, moveOutDuration)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                // 第二步：等待指定时间
                DOVirtual.DelayedCall(waitTime, () =>
                {
                    // 第三步：移回原位置
                    KinfolkSty.DOAnchorPos(FidelityKinfolkStySynapsis, moveInDuration)
                        .SetEase(Ease.InOutQuad)
                        .OnComplete(() =>
                        {
                            onComplete?.Invoke();
                        });
                });
            });
    }

    /// <summary>
    /// 让CashoutBtn移出屏幕显示范围，然后等待指定时间后移回原位置（简化版本）
    /// </summary>
    /// <param name="waitTime">等待时间（秒）</param>
    /// <param name="onComplete">动画完成回调</param>
    public void SlaveryKinfolkStyMelody(float waitTime = 0.1f, Action onComplete = null)
    {
        SlaveryKinfolkSty(waitTime, 0.5f, 0.5f, onComplete);
    }
    private void OnDestroy()
    {
        // 记得移除监听，避免内存泄漏
        LullGuinea.FanDeltaEndear -= OnLevelComplete;
        LullGuinea.KnotTipEndear -= OnShowTip;
        LullGuinea.KnotFewPatrolEndear -= OnShowTipManual;
        LullGuinea.BeefFewEndear -= OnHideTip;
        // 新增：移除新手引导事件监听
        LullGuinea.SeparatePriceHoldingEndear -= OnTutorialGuideStarted;
        LullGuinea.SeparatePriceEmberEndear -= OnTutorialGuideEnded;
    }

    // 新增：新手引导开始时禁用按钮
    private void OnTutorialGuideStarted()
    {
        if (LashSty != null) LashSty.interactable = false;
        if (AdjunctSty != null) AdjunctSty.interactable = false;
    }
    // 新增：新手引导结束时恢复按钮
    private void OnTutorialGuideEnded()
    {
        if (LashSty != null) LashSty.interactable = true;
        if (AdjunctSty != null) AdjunctSty.interactable = true;
    }
}
