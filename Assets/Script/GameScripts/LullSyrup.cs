using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Lofelt.NiceVibrations;
using DG.Tweening;
using System.Runtime.CompilerServices;


#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Mkey
{
    /// <summary>
    /// 游戏主面板控制类，负责管理游戏主流程、网格、分数、事件等
    /// </summary>
    public class LullSyrup : MonoBehaviour
    {
        #region settings 
        [Space(8)]
        [Header("Game settings")]
[UnityEngine.Serialization.FormerlySerializedAs("showScore")]        public bool DullRoute; // 是否显示分数
[UnityEngine.Serialization.FormerlySerializedAs("enableContinuousMatch")]        public bool EmergePercentageElite= true; // 是否启用连续消除
[UnityEngine.Serialization.FormerlySerializedAs("skipAnimation")]        public bool BardCertainty= false; // 是否跳过动画
        #endregion settings

        [Header("Collect properties")]
[UnityEngine.Serialization.FormerlySerializedAs("speed")]        public float Dough= 6; // 收集动画速度
[UnityEngine.Serialization.FormerlySerializedAs("ease_0")]        public EaseAnim Wick_0;     // outsine
[UnityEngine.Serialization.FormerlySerializedAs("ease_1")]        public EaseAnim Wick_1;      // outbounce
[UnityEngine.Serialization.FormerlySerializedAs("collectSound")]        public AudioClip StylishMedia; // 收集音效

        #region references
        [Header("Main references")]
        [Space(8)]
[UnityEngine.Serialization.FormerlySerializedAs("GridContainer")]        public Transform SodaGrievance; // 网格容器
[UnityEngine.Serialization.FormerlySerializedAs("backGround")]        public SpriteRenderer WashAbsorb; // 背景渲染器
[UnityEngine.Serialization.FormerlySerializedAs("gConstructor")]        public LullUnreachable gUnreachable; // 关卡构造器
        [SerializeField]
        private RouteModerately BiomeModerately; // 分数控制器
        //[SerializeField]
        //private LotIllModerately winPrefab; // 胜利弹窗预制体
        [SerializeField]
        private LotIllModerately AnDialectDismal; // 无可消除弹窗预制体
        [SerializeField]
        private GameObject StylishDismal; // 收集物体预制体
        [SerializeField]
        private GUIArgon BiomeArgonDismal; // 分数飞行动画预制体
        #endregion references

        #region grid
        public EliteSoda BookSoda{ get; private set; } // 主网格对象
[UnityEngine.Serialization.FormerlySerializedAs("GMode")]       
#endregion grid

        #region states
        public static GameMode GSpur= GameMode.Play; // 当前游戏模式：Play或Edit
        #endregion states

        #region properties
        public Sprite LashAbsorb        {
            get { return WashAbsorb.sprite; }
            set { if (WashAbsorb) WashAbsorb.sprite = value; }
        } // 背景图片属性

        private MediaMuscle MMedia{ get { return MediaMuscle.Whatever; } } // 声音管理器单例

        public RatModerately MRat=> RatModerately.Instance; // GUI控制器单例
        #endregion properties

        #region sets
        private LullFreshnessOld GCOld{ get { return LullFreshnessOld.Whatever; } } // 游戏构造配置单例
        private DeltaFreshnessOld LCOld{ get { return GCOld.HowDeltaFreshnessOld(LullDeltaMisery.PrecedeDelta); } } // 当前关卡配置
        private LullCoconutOld GOOld{ get { return GCOld.GOOld; } } // 游戏对象集合
        private LullDeltaMisery MGDelta=> LullDeltaMisery.Whatever; // 关卡进度管理器
[UnityEngine.Serialization.FormerlySerializedAs("WinAction")]        
#endregion sets

        #region events
        public Action FanEndear; // 胜利事件
[UnityEngine.Serialization.FormerlySerializedAs("NoMatchesAction")]        public Action DyDialectEndear; // 无可消除事件
[UnityEngine.Serialization.FormerlySerializedAs("ChangePossibleMatchesAction")]        public Action<int> HaliteDiffusesDialectEndear; // 可消除对数变化事件
[UnityEngine.Serialization.FormerlySerializedAs("BeforeCollectAction")]        public Action<SodaLime, SodaLime, AngularTrim, AngularTrim> PlaintMisleadEndear; // 收集前事件
[UnityEngine.Serialization.FormerlySerializedAs("CollectAction")]        public Action<Sprite, Sprite> MisleadEndear; // 收集事件
[UnityEngine.Serialization.FormerlySerializedAs("EndCollectAnimatioAction")]        public Action VanMisleadRestrainEndear; // 收集动画结束事件
[UnityEngine.Serialization.FormerlySerializedAs("FailedMatchAction")]        public Action InsistEliteEndear; // 匹配失败事件
[UnityEngine.Serialization.FormerlySerializedAs("ShuffleGridEndAction")]        public Action SeminarSodaVanEndear; // 洗牌结束事件
[UnityEngine.Serialization.FormerlySerializedAs("ShuffleGridBeginAction")]        public Action SeminarSodaRoughEndear; // 洗牌开始事件
[UnityEngine.Serialization.FormerlySerializedAs("UndoEndAction")]        public Action UndoVanEndear; // 撤销结束事件
[UnityEngine.Serialization.FormerlySerializedAs("LoadingFinish")]        public static bool ClarifyUnfold= false;
[UnityEngine.Serialization.FormerlySerializedAs("ChangeFreeHiglightModeAction")]        public Action<bool> HaliteBoldMilkweedSpurEndear; // 自由高亮模式变化事件
        #endregion events

        public static LullSyrup Whatever{ get; private set; } // 单例实例

        // 预加载系统相关
        private class PreloadedLevelData
        {
            public EliteSoda Mote;                    // 预创建的网格
            public List<Sprite> AttainUnfavorably;    // 预计算的图片分配
            public int Score;                         // 关卡号
            public bool ItGasoline;                   // 是否完成预加载
        }
        private PreloadedLevelData ConductorSoul;
        private PreloadedLevelData BizarreSoul;        // 专门用于重启的数据
        private bool FinFinnishAngular= false;       // 是否已经点击过麻将
        private Transform AmericaGrievance;            // 预加载容器

        // 防止WinAction重复触发
        private bool FinFanEndearDubious= false;
        private bool SkyHall= false;


        #region regular
        private void Awake()
        {
            if (Whatever) Destroy(gameObject);
            else
            {
                Whatever = this;
            }
#if UNITY_EDITOR
            if (GCOld && GCOld.CoilSpur) LullDeltaMisery.PrecedeDelta = Mathf.Abs(GCOld.CoilDelta);
#endif
            //      RouteMisery.Instance.OldPulse(0);
        }

        private void Start()
        {
            LullHandleMisery.Whatever.OldMoody(0); // 主题选择

            Debug.Log("LullSyrup Start 被调用");
            
            // 初始化预加载容器
            ImmobilizeDevelopGrievance();
            
            // 监听麻将点击事件
            OutdoorLegend.BatTugSolution(CShaman.To_OrAngularThird, OnMahjongClick);
            
            #region game sets 
            if (!GCOld)
            {
                Debug.Log("Game construct set not found!!!");
                return;
            }

            if (!LCOld)
            {
                Debug.Log("Level construct set not found!!! - " + LullDeltaMisery.PrecedeDelta);
                return;
            }

            if (!GOOld)
            {
                Debug.Log("MatcSet not found!!! - " + LullDeltaMisery.PrecedeDelta);
                return;
            }
            #endregion game sets 

            OceaniaSoda();
            LiableLullSyrup();
            LullDeltaMisery.VaultDelta();

            if (GSpur == GameMode.Edit)
            {
#if UNITY_EDITOR
                Debug.Log("start edit mode");
                if (gUnreachable)
                {
                    gUnreachable.gameObject.SetActive(true);
                    gUnreachable.InitStart();
                }
#endif
            }

            else if (GSpur == GameMode.Play)
            {
                Debug.Log("start play mode");
                if (gUnreachable) DestroyImmediate(gUnreachable.gameObject);
                RouteMisery.Whatever.OldUnclearRoute(BiomeModerately.HowStyDeltaRoute(BookSoda.HowCramp().Length / 2));
                Debug.Log("max level score: " + RouteMisery.UnclearRoute);
                #region set board eventhandlers
                UndoVanEndear += () =>
                {
                    BookSoda.MooseReactive();
                    MildlyDiffusesDialect();
                    if (!BrandMaximizePack()) PuddlePack();
                    if (IDHeartbeatBoldSpur)
                    {
                        HighlihtBold(true);
                    }
                };

                SeminarSodaVanEndear += () =>
                {
                    MildlyDiffusesDialect();
                };

                PlaintMisleadEndear += (c1, c2, m1, m2) =>
                {
                    if (AvidTaut != null && AvidTaut.CenterAny(m1, m2)) PuddlePack(); // remove hint
                };

                MisleadEndear += (s1, s2) =>
                {
                    RouteMisery.Bat(BiomeModerately.HowEliteRoute());
                    if (BookSoda.HowCramp().Length == 0)
                    {
                        if (!FinFanEndearDubious)
                        {
                            FinFanEndearDubious = true;
                            FanEndear?.Invoke();
                        }
                        return;
                    }
                    MildlyDiffusesDialect();
                    if (NeedlessDialect.Pulse == 0) DyDialectEndear?.Invoke();
                    LullGuinea.EliteBroadlyAnvil?.Invoke(s1, s2);
                    if (IDHeartbeatBoldSpur)
                    {
                        HighlihtBold(true);
                    }
                    EatLoftMislead(); // 自动收集检测
                };

                DyDialectEndear += () =>
                {
                    if (!ItIDLoftMislead)
                    {
                        UIEvening.HowWhatever().KnotUITruth(nameof(NotGrand));
                    }

                    //   MGui.ShowPopUp(noMatchesPrefab);    // show no matches popup
                };

                FanEndear += () =>
                {
                    Debug.Log("完成关卡");
                    UIEvening.HowWhatever().KnotUITruth(nameof(DeltaGasolineDwarf));
                    //  MGui.ShowPopUp(winPrefab);  // show win message
                    MGDelta.PlusDelta();        // pass level
                    LullGuinea.FanDeltaEndear?.Invoke();
                };

                HaliteBoldMilkweedSpurEndear += (highlight) =>
                {
                    HighlihtBold(highlight);
                };
                HighlihtBold(true);
                #endregion set board eventhandlers
                BookSoda.RateCoconut();

                MildlyDiffusesDialect();

                WideDeveloperSpur();
            }
        }
        #endregion regular

        #region grid construct restart
        public void LiableLullSyrup()
        {
            // 关卡重建时重置自动收集和通关标志
            ItLoftIllustrate = false;
            FinAmericanaLoftMislead = false;
            ItIDLoftMislead = false;
            FinFanEndearDubious = false;
            LimyPartyPulse = 0;
            FinFinnishAngular = false; // 重置点击麻将标志
            // 清理旧关卡的重玩数据
            if (BizarreSoul != null && BizarreSoul.Score != LullDeltaMisery.PrecedeDelta)
            {
                Debug.Log($"关卡切换，清理旧的重玩数据（关卡{BizarreSoul.Score} -> {LullDeltaMisery.PrecedeDelta}）");
                SurgeonSleeperSoul();
            }
            MGDelta.Wide();
            Debug.Log("Create gameboard ");
            Debug.Log("level set: " + LCOld.name);
            Debug.Log("current level: " + LullDeltaMisery.PrecedeDelta);

            // 检查是否有预加载数据可用
            Debug.Log($"=== 检查预加载数据 ===");
            Debug.Log($"preloadedData: {(ConductorSoul != null ? "存在" : "null")}");
            if (ConductorSoul != null)
            {
                Debug.Log($"preloadedData.isComplete: {ConductorSoul.ItGasoline}");
                Debug.Log($"preloadedData.level: {ConductorSoul.Score}");
                Debug.Log($"LullDeltaMisery.CurrentLevel: {LullDeltaMisery.PrecedeDelta}");
                Debug.Log($"preloadedData.spriteAssignments.Count: {ConductorSoul.AttainUnfavorably?.Count ?? 0}");
            }
            
            bool hasPreloadedData = ConductorSoul != null && ConductorSoul.ItGasoline && ConductorSoul.Score == LullDeltaMisery.PrecedeDelta;
            Debug.Log($"hasPreloadedData: {hasPreloadedData}");
            
            if (hasPreloadedData)
            {
                Debug.Log("使用预加载数据快速切换关卡");
                // 1. 先复制预加载数据作为重玩数据
                MildStabilitySoulLieSleeper();

                // 2. 正常重建网格结构
                LashAbsorb = GOOld.HowLashAbsorb(LCOld.LashAbsorb);
                // 先正常重建网格结构
                LashAbsorb = GOOld.HowLashAbsorb(LCOld.LashAbsorb);
                
                if (GSpur == GameMode.Play)
                {
                    Func<DeltaFreshnessOld, Transform, EliteSoda> create = (lC, container) =>
                    {
                        EliteSoda g= new EliteSoda(lC, GOOld, container, GSpur);
                        g.Acorn.ForEach((c) =>
                        {
#if UNITY_EDITOR
                            c.name = c.ToString();
#endif
                        });
                        return g;
                    };

                    BookSoda = create(LCOld, SodaGrievance);
                }
                
                BookSoda.OldFailureJoy(false);
                
                // 然后应用预加载的图片分配
                PreenStabilityCorpseUnfavorably();
                CultImitator();
                
                // 从第三关开始，在图片分配完成后播放入场动画
                if (LullDeltaMisery.PrecedeDelta >= 2)
                {
                    StartCoroutine(DeadDeltaWideCertainty());
                }
                
                // 清理预加载数据
                SurgeonStabilitySoul();
                return; // 使用预加载数据后直接返回，不执行后续的创建逻辑
            }

            // 触发关卡加载事件来更新UI
            MGDelta.WideAnvil?.Invoke(LullDeltaMisery.PrecedeDelta);

            LashAbsorb = GOOld.HowLashAbsorb(LCOld.LashAbsorb);

            if (GSpur == GameMode.Play)
            {
                Func<DeltaFreshnessOld, Transform, EliteSoda> create = (lC, container) =>
                {
                    EliteSoda g = new EliteSoda(lC, GOOld, container, GSpur);
                    g.Acorn.ForEach((c) =>
                    {
#if UNITY_EDITOR
                        c.name = c.ToString();
#endif
                    });
                    return g;
                };

                BookSoda = create(LCOld, SodaGrievance);
            }
            else // edit mode
            {
#if UNITY_EDITOR

                if (BookSoda != null && BookSoda.LcOld == LCOld)
                {
                    BookSoda.Workday(GOOld, GSpur);
                }
                else
                {
                    OceaniaSoda();
                    BookSoda = new EliteSoda(LCOld, GOOld, SodaGrievance, GSpur);
                }

                // set cells delegates for constructor
                for (int i = 0; i < BookSoda.Acorn.Count; i++)
                {
                    BookSoda.Acorn[i].GetComponent<Collider2D>().enabled = true;
                    BookSoda.Acorn[i].GCVisibleMustAnvil = (c) =>
                     {
                         gUnreachable.GetComponent<LullUnreachable>().Cell_Click(c);
                     };
                }
#endif
            }

            BookSoda.OldFailureJoy(false);
            var swSprites = System.Diagnostics.Stopwatch.StartNew();
            StartCoroutine(
                BookSoda.OldAngularBroadlyRigor(() =>
            {
                swSprites.Stop();
                Debug.Log($"[耗时] SetMahjongSprites: {swSprites.ElapsedMilliseconds} ms");
                CultImitator();
            }, 1)); // 使用yieldStep=1，每分配一对麻将牌就暂停一帧，最大平滑度，激进分帧
            var sw = System.Diagnostics.Stopwatch.StartNew();
            sw.Stop();
            Debug.Log($"[耗时] CreateGameBoard: {sw.ElapsedMilliseconds} ms");
        }

        /// <summary>
        /// 使用重玩数据快速重启关卡
        /// </summary>
        private void SleeperDeltaWestSleeperSoul()
        {
            Debug.Log("使用重玩数据快速重启关卡");
            var sw = System.Diagnostics.Stopwatch.StartNew();

            // 重置游戏状态
            ItLoftIllustrate = false;
            FinAmericanaLoftMislead = false;
            ItIDLoftMislead = false;
            FinFanEndearDubious = false;
            LimyPartyPulse = 0;
            FinFinnishAngular = false;

            // 使用MainGrid的Rebuild重建网格结构
            BookSoda.Workday(GOOld, GSpur);

            // 应用重玩数据的图片分配
            PreenSleeperSoulCorpseUnfavorably();

            sw.Stop();
            Debug.Log($"[耗时] RestartLevelWithRestartData: {sw.ElapsedMilliseconds} ms");

            CultImitator();
        }

        /// <summary>
        /// 应用重玩数据的图片分配
        /// </summary>
        private void PreenSleeperSoulCorpseUnfavorably()
        {
            if (BizarreSoul == null || !BizarreSoul.ItGasoline || BizarreSoul.AttainUnfavorably == null)
            {
                Debug.LogWarning("没有有效的重玩数据可以应用");
                return;
            }

            var Exist= BookSoda.HowCramp();
            Debug.Log($"应用重玩数据图片分配: {Exist.Length}个麻将, {BizarreSoul.AttainUnfavorably.Count}个图片");

            // 应用图片分配
            for (int i = 0; i < Exist.Length && i < BizarreSoul.AttainUnfavorably.Count; i++)
            {
                if (BizarreSoul.AttainUnfavorably[i] != null)
                {
                    Exist[i].OldCorpse(BizarreSoul.AttainUnfavorably[i]);
                }
            }

            Debug.Log("重玩数据图片分配应用完成");
        }

        /// <summary>
        /// 原始的硬重启方法
        /// </summary>
        private void SleeperDeltaDecrease()
        {
            Debug.Log("使用原始逻辑重启关卡");
            // 关卡重建时重置自动收集和通关标志
            ItLoftIllustrate = false;
            FinAmericanaLoftMislead = false;
            ItIDLoftMislead = false;
            FinFanEndearDubious = false;
            LimyPartyPulse = 0;
            var sw = System.Diagnostics.Stopwatch.StartNew();
            BookSoda.Workday(GOOld, GSpur);
            sw.Stop();
            Debug.Log($"[耗时] MainGrid.Rebuild: {sw.ElapsedMilliseconds} ms");
            var swSprites = System.Diagnostics.Stopwatch.StartNew();
            StartCoroutine(BookSoda.OldAngularBroadlyRigor(() =>
            {
                swSprites.Stop();
                Debug.Log($"[耗时] SetMahjongSprites: {swSprites.ElapsedMilliseconds} ms");
                CultImitator();
            }, 1)); // 使用yieldStep=1，每分配一对麻将牌就暂停一帧
        }

        public void SleeperDelta()
        {
            // 优先检查是否有重玩数据
            if (BizarreSoul != null && BizarreSoul.Score == LullDeltaMisery.PrecedeDelta && BizarreSoul.ItGasoline && BizarreSoul.AttainUnfavorably != null)
            {
                Debug.Log($"发现重玩数据，关卡: {BizarreSoul.Score}，图片数量: {BizarreSoul.AttainUnfavorably.Count}");
                SleeperDeltaWestSleeperSoul();
            }
            else
            {
                Debug.Log("没有可用的重玩数据，使用原始重启逻辑");
                SleeperDeltaDecrease();
            }
        }

        private static void CultImitator()
        {
            Debug.Log("TestCallback 被调用，准备刷新遮灰");
            if (LullSyrup.Whatever != null)
            {
                if (LullSyrup.Whatever.BookSoda != null)
                {
                    LullSyrup.Whatever.BookSoda.MooseReactive();
                    Debug.Log($"TestCallback: CacheBlockers 已执行，Tiles数量: {LullSyrup.Whatever.BookSoda.HowCramp().Length}");
                    LullSyrup.Whatever.HighlihtBold(true);
                    Debug.Log("TestCallback: HighlihtFree(true) 已执行，遮灰刷新已完成");

                    // 触发关卡加载完成事件
                    LullGuinea.DeltaWideGasolineEndear?.Invoke();
                    ClarifyUnfold = true;
                    Debug.Log("关卡加载完成事件已触发");
                }
                else
                {
                    Debug.LogError("TestCallback: MainGrid 为空！");
                }
            }
            else
            {
                Debug.LogError("TestCallback: LullSyrup.Instance 为空！");
            }
        }

        /// <summary>
        /// destroy default main grid cells
        /// </summary>
        public void OceaniaSoda()
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();
            SodaLime[] gcs = gameObject.GetComponentsInChildren<SodaLime>();
            for (int i = 0; i < gcs.Length; i++)
            {
                DestroyImmediate(gcs[i].gameObject);
            }
            sw.Stop();
            Debug.Log($"[耗时] DestroyGrid: {sw.ElapsedMilliseconds} ms");
        }
        #endregion grid construct restart

        #region states
        public void SeminarSoda(Action completeCallBack)
        {
            if (!BookSoda.OilSeminar())
            {
                SeminarSodaRoughEndear?.Invoke();
                BookSoda.HardSeminar();
                BookSoda.OldFailureJoy(false);
                AvidTaut = null;
                NeedlessDialect = null;
                if (IDHeartbeatBoldSpur)
                {
                    HighlihtBold(true);
                }
                SeminarSodaVanEndear?.Invoke();
                completeCallBack?.Invoke();
                return;
            }
            // standart shuffle action
            OldAnalogyCivility(false, false);
            SeminarSodaRoughEndear?.Invoke();
            ParallelTween pT0 = new ParallelTween();
            ParallelTween pT1 = new ParallelTween();
            AvidTaut = null;
            NeedlessDialect = null;


            WeighEke tweenSeq = new WeighEke();
            List<AngularTrim> mahjongTiles = GetComponentsInChildren<AngularTrim>(true).ToList();

            mahjongTiles.ForEach((mT) => { pT0.Bat((callBack) => { mT.MixDrab(transform.position, callBack); }); });

            mahjongTiles.ForEach((mT) => { pT1.Bat((callBack) => { mT.GentleBedDrab(callBack); }); });

            tweenSeq.Bat((callBack) =>
            {
                pT0.Start(callBack);
            });

            tweenSeq.Bat((callBack) =>
            {
                BookSoda.SeminarSodaBroadly();
                pT1.Start(() =>
                {
                    OldAnalogyCivility(true, true);
                    SeminarSodaVanEndear?.Invoke();
                    completeCallBack?.Invoke();
                    callBack();
                });
            });

            tweenSeq.Start();
        }

        internal void OldAnalogyCivility(bool activityGrid, bool activityMenu)
        {
            TexasEvening.OldTexasCivility(activityGrid);
            //  FutureGUIModerately.Instance.SetControlActivity(activityMenu);
            RecallGUIModerately.Whatever.OldAnalogyCivility(activityMenu);
        }
        #endregion states

        #region collect match
        PossibleMatches NeedlessDialect;
        private int CornGallop= 0;
        private Canvas GoldenSphere;
        private Queue<MatchPair> FlankRoman= new Queue<MatchPair>(); // 连续消除队列
        private bool ItSturdinessElite= false; // 是否正在处理消除
[UnityEngine.Serialization.FormerlySerializedAs("processingTiles")]        public HashSet<AngularTrim> ChondriticCramp= new HashSet<AngularTrim>(); // 正在处理的麻将牌
        public int HowDiffusesDialectPulse()
        {
            return (NeedlessDialect != null) ? NeedlessDialect.Pulse : 0;
        }

        /// <summary>
        /// 检查麻将牌是否正在被处理
        /// </summary>
        public bool IDTrimGourdWoodblock(AngularTrim tile)
        {
            return ChondriticCramp.Contains(tile);
        }

        public void MisleadElite(AngularTrim mahjongTile_1, AngularTrim mahjongTile_2)
        {
            // 严格的空值检查
            if (mahjongTile_1 == null || mahjongTile_2 == null)
            {
                Debug.LogError("AngularTrim is null in CollectMatch");
                return;
            }

            // 检查麻将牌是否仍然有效（没有被销毁）
            if (mahjongTile_1.gameObject == null || mahjongTile_2.gameObject == null)
            {
                Debug.LogError("AngularTrim GameObject is null in CollectMatch");
                return;
            }

            // 检查麻将牌是否正在被处理
            if (ChondriticCramp.Contains(mahjongTile_1) || ChondriticCramp.Contains(mahjongTile_2))
            {
                Debug.LogWarning("AngularTrim is already being processed");
                return;
            }

            // 检查麻将牌是否仍然在网格中
            SodaLime gridCell_1 = mahjongTile_1.GetComponentInParent<SodaLime>();
            SodaLime gridCell_2 = mahjongTile_2.GetComponentInParent<SodaLime>();

            if (gridCell_1 == null || gridCell_2 == null)
            {
                Debug.LogError("SodaLime is null in CollectMatch - tiles may have been destroyed or moved");
                return;
            }

            // 添加到处理中集合
            ChondriticCramp.Add(mahjongTile_1);
            ChondriticCramp.Add(mahjongTile_2);

            if (BardCertainty)
            {
                ThatMislead(mahjongTile_1, mahjongTile_2);
            }
            else
            {
                StartCoroutine(MisleadEliteC(mahjongTile_1, mahjongTile_2));
            }
        }

        private bool FinAmericanaHallGreeceInLoftMislead= false;

        private IEnumerator LoftMisleadJoyIntroduce()
        {
            float originalSpeed = Dough;
            Dough = originalSpeed / 2f; // 动画加快一倍
            FinAmericanaHallGreeceInLoftMislead = false; // 自动收集前重置
            while (BookSoda.HowCramp().Length > 0)
            {
                MildlyDiffusesDialect();
                if (NeedlessDialect.Pulse > 0)
                {
                    // 优先选择层级最高的一对（模拟玩家手动点选）
                    MatchPair topPair = null;
                    int maxLayer = int.MinValue;
                    for (int i = 0; i < NeedlessDialect.Pulse; i++)
                    {
                        var pair = NeedlessDialect.HowEliteTaut(i);
                        if (pair != null && pair.BookletTrim_1 && pair.BookletTrim_2)
                        {
                            int Swamp= Mathf.Max(pair.BookletTrim_1.Layer, pair.BookletTrim_2.Layer);
                            if (Swamp > maxLayer)
                            {
                                maxLayer = Swamp;
                                topPair = pair;
                            }
                        }
                    }
                    if (topPair != null)
                    {
                        MisleadElite(topPair.BookletTrim_1, topPair.BookletTrim_2);
                        yield return new WaitUntil(() => !ItSturdinessElite);
                        yield return new WaitForSeconds(0.05f);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    // 没有可消除对，强制找一对Sprite相同的牌
                    var allTiles = BookSoda.HowCramp();
                    bool found = false;
                    for (int i = 0; i < allTiles.Length; i++)
                    {
                        for (int j = i + 1; j < allTiles.Length; j++)
                        {
                            if (allTiles[i] && allTiles[j] && allTiles[i].CorpseOilEarnerWest(allTiles[j].MCorpse))
                            {
                                MisleadElite(allTiles[i], allTiles[j]);
                                found = true;
                                yield return new WaitUntil(() => !ItSturdinessElite);
                                yield return new WaitForSeconds(0.05f);
                                break;
                            }
                        }
                        if (found) break;
                    }
                    if (!found)
                    {
                        // 真的无解，弹出提示
                        break;
                    }
                }
            }
            Dough = originalSpeed;
            ItLoftIllustrate = false;
            ItIDLoftMislead = false;
        }

        private IEnumerator MisleadEliteC(AngularTrim mahjongTile_1, AngularTrim mahjongTile_2)
        {
            // 空值检查
            if (mahjongTile_1 == null || mahjongTile_2 == null)
            {
                Debug.LogError("AngularTrim is null in CollectMatchC");
                yield break;
            }

            // 只禁用菜单控制，保持网格可交互
            OldAnalogyCivility(true, false);
            SodaLime gridCell_1 = mahjongTile_1.GetComponentInParent<SodaLime>();
            SodaLime gridCell_2 = mahjongTile_2.GetComponentInParent<SodaLime>();

            // 检查GridCell是否为空
            if (gridCell_1 == null || gridCell_2 == null)
            {
                Debug.LogError("SodaLime is null in CollectMatchC");
                OldAnalogyCivility(true, true);
                yield break;
            }

            PlaintMisleadEndear?.Invoke(gridCell_1, gridCell_2, mahjongTile_1, mahjongTile_2);
            Sprite Attain_1= mahjongTile_1.MCorpse;
            Sprite Attain_2= mahjongTile_2.MCorpse;

            // 安全地调用UnLinkObject
            try
            {
                gridCell_1.OrBearScreen(mahjongTile_1.Layer);
                gridCell_2.OrBearScreen(mahjongTile_2.Layer);
            }
            catch (System.Exception e)
            {
                Debug.LogError($"Error in UnLinkObject: {e.Message}");
            }

            yield return MisleadCertaintyC(mahjongTile_1, mahjongTile_2);
            VanMisleadRestrainEndear?.Invoke();

            // 安全地销毁对象
            if (mahjongTile_1 != null && mahjongTile_1.gameObject != null)
                Destroy(mahjongTile_1.gameObject);
            if (mahjongTile_2 != null && mahjongTile_2.gameObject != null)
                Destroy(mahjongTile_2.gameObject);

            yield return new WaitForEndOfFrame();
            MisleadEndear?.Invoke(Attain_1, Attain_2);

            // 从处理中集合移除
            ChondriticCramp.Remove(mahjongTile_1);
            ChondriticCramp.Remove(mahjongTile_2);

            OldAnalogyCivility(true, true);
        }

        private IEnumerator MisleadCertaintyC(AngularTrim mahjongTile_1, AngularTrim mahjongTile_2)
        {
            AngularTrim leftTile = (mahjongTile_1.AttainRefurbish.position.x < mahjongTile_2.AttainRefurbish.position.x) ? mahjongTile_1 : mahjongTile_2;
            AngularTrim rightTile = (leftTile == mahjongTile_1) ? mahjongTile_2 : mahjongTile_1;
            Bounds bounds_1 = leftTile.AirExchange.bounds;
            Vector3 min = bounds_1.min;
            Vector3 max = bounds_1.max;
            Vector2 size = max - min;
            Vector2 size05 = size * 0.5f;
            Vector2 size15 = size * 1.5f;
            Vector2 size01 = size * 0.1f;
            Vector3 wPos_10 = leftTile.AttainRefurbish.position;
            Vector3 wPos_11 = rightTile.AttainRefurbish.position;
            Vector3 wPos_center = (wPos_10 + wPos_11) * 0.5f;
            if (Mathf.Abs(wPos_center.x) > 1.5f * size.x)
            {
                wPos_center = new Vector3(wPos_center.x > 0 ? 1.5f : -1.5f, wPos_center.y, wPos_center.z); // offset to center
            }
            Vector3 wPos_20 = wPos_center - new Vector3(size.x, 0, 0);
            Vector3 wPos_21 = wPos_center + new Vector3(size.x, 0, 0);

            Vector3 wPos_30 = wPos_20 - new Vector3(size15.x, 0, 0);
            Vector3 wPos_31 = wPos_21 + new Vector3(size15.x, 0, 0);

            Vector3 wPos_40 = wPos_center - new Vector3(size05.x + size01.x, 0, 0);
            Vector3 wPos_41 = wPos_center + new Vector3(size05.x + size01.x, 0, 0);
            bool moveComplete = false;
            bool finishanim = true;

            float Fall= (wPos_30 - wPos_10).magnitude / Dough;
            if (Fall < 0.2f) Fall = 0.2f;
            if (Fall > 0.4f) Fall = 0.4f;
            moveComplete = false;
            MelodyWeigh.Fine(leftTile.AttainRefurbish.gameObject, wPos_10, wPos_30, Fall).OldSilt(Wick_0);
            MelodyWeigh.Fine(rightTile.AttainRefurbish.gameObject, wPos_11, wPos_31, Fall).OldSilt(Wick_0).BatGasolineExpoLash(() => {
                moveComplete = true;
                if (leftTile.PriestTrim)
                {
                    leftTile.DeadCorpus(() => { });
                    rightTile.DeadCorpus(() =>
                    {
                       
                    });
                    DOVirtual.DelayedCall(0.3f, () =>  //停顿
                    {
                        finishanim = false;
                        leftTile.gameObject.SetActive(false);
                        rightTile.gameObject.SetActive(false);
                    });
                }
                else
                {
                    leftTile.DeadMental(() => { });
                    rightTile.DeadMental(() =>
                    {
                      
                    });
                    DOVirtual.DelayedCall(0.3f, () =>  //停顿
                    {
                        finishanim = false;
                        leftTile.gameObject.SetActive(false);
                        rightTile.gameObject.SetActive(false);
                    });
                }
            });

            yield return new WaitWhile(() => !moveComplete);

            Fall = (wPos_40 - wPos_30).magnitude / Dough;
            moveComplete = false;
            MelodyWeigh.Fine(leftTile.AttainRefurbish.gameObject, wPos_30, wPos_40, Fall).OldSilt(Wick_1);
            MelodyWeigh.Fine(rightTile.AttainRefurbish.gameObject, wPos_31, wPos_41, Fall).OldSilt(Wick_1).BatGasolineExpoLash(() => {
                moveComplete = true;
            });
            SkyHall = false;
            TweenExt.DustyEndear(rightTile.AttainRefurbish.gameObject, Fall * 0.9f, () =>
            {
                if (LullDeltaMisery.PrecedeDelta >= 2)
                {
                    EatHallGreeceOrParty();
                }
                KeyValuesUpdate keyfly = new KeyValuesUpdate(CShaman.To_OrPartyUpdata, wPos_center);
                OutdoorLegend.HeroOutdoor(CShaman.To_OrPartyUpdata, keyfly);
                double rewardnum = 0;
                if (leftTile.PriestTrim)
                {
                    if (ItIDLoftMislead)
                    {
                        if (!FinAmericanaHallGreeceInLoftMislead)
                        {
                            double Goldreward = GameUtil.GetGoldMatch();
                            UIEvening.HowWhatever().KnotUITruth(nameof(GreeceHotDwarf), Goldreward);
                            FinAmericanaHallGreeceInLoftMislead = true;
                        }
                    }
                    else
                    {
                        SkyHall = true;
                        // 手动消除，每对都弹
                        double Goldreward = GameUtil.GetGoldMatch();
                        DOVirtual.DelayedCall(0.5f, () =>  //停顿
                        {
                            UIEvening.HowWhatever().KnotUITruth(nameof(GreeceHotDwarf), Goldreward);
                        });
                    }
                }
                else
                {
                    rewardnum = GameUtil.GetNormalMatch();
                    if (LullEvening.Instance.m_ItSeabed)
                    {
                        rewardnum = rewardnum * CryBustPeg.instance.LullSoul.combommul;
                    }
                    addScoreData scordData = new addScoreData();
                    scordData.PartyPulse = rewardnum;
                    scordData.Anyway3Our = wPos_center;
                    KeyValuesUpdate addScore = new KeyValuesUpdate(CShaman.To_OrBatRoute, scordData);
                    OutdoorLegend.HeroOutdoor(CShaman.To_OrBatRoute, addScore);
                }

                if (StylishDismal) Instantiate(StylishDismal, wPos_center, Quaternion.identity, transform);
                if (DullRoute) ForgivenessRouteArgon(wPos_center + new Vector3(0, size.y, 0), "+" + BiomeModerately.HowEliteRoute().ToString());

            });
            if (StylishMedia) MMedia.DeadMine(Fall * 0.6f, StylishMedia);
            HapticPatterns.PlayPreset(HapticPatterns.PresetType.HeavyImpact);
            StarkPeg.HowWhatever().DeadEncode(StarkLieu.SceneMusic.Sound_matchmj);
            //等待动画完成
           yield return new WaitWhile(() =>
           finishanim
           );

            //yield return new WaitWhile(() =>
            //   !moveComplete
            //   );
            yield return new WaitForEndOfFrame();
        }

        private void MildlyDiffusesDialect()
        {
            NeedlessDialect = new PossibleMatches(BookSoda.HowBoldDyEliteCramp());
            HaliteDiffusesDialectEndear?.Invoke(NeedlessDialect.Pulse);
            CornGallop = 0;
        }

        private void ForgivenessRouteArgon(Vector3 wPosition, string score)
        {
            if (!BiomeArgonDismal) return;
            if (!GoldenSphere)
            {
                GameObject gC = GameObject.Find("CanvasMain");
                if (gC) GoldenSphere = gC.GetComponent<Canvas>();
                if (!GoldenSphere) GoldenSphere = FindFirstObjectByType<Canvas>();
            }

            GUIArgon flyer = BiomeArgonDismal.LiableArgon(GoldenSphere, score);
            if (flyer)
            {
                flyer.transform.localScale = transform.lossyScale;
                flyer.transform.position = wPosition; //  transform.position;
            }
        }

        public void ThatMislead(AngularTrim mahjongTile_1, AngularTrim mahjongTile_2)
        {
            // 空值检查
            if (mahjongTile_1 == null || mahjongTile_2 == null)
            {
                Debug.LogError("AngularTrim is null in FastCollect");
                return;
            }

            OldAnalogyCivility(false, false);
            SodaLime gridCell_1 = mahjongTile_1.GetComponentInParent<SodaLime>();
            SodaLime gridCell_2 = mahjongTile_2.GetComponentInParent<SodaLime>();

            // 检查GridCell是否为空
            if (gridCell_1 == null || gridCell_2 == null)
            {
                Debug.LogError("SodaLime is null in FastCollect");
                OldAnalogyCivility(true, true);
                return;
            }

            PlaintMisleadEndear?.Invoke(gridCell_1, gridCell_2, mahjongTile_1, mahjongTile_2);
            Sprite Attain_1= mahjongTile_1.MCorpse;
            Sprite Attain_2= mahjongTile_2.MCorpse;

            // 安全地设置父对象为null
            if (mahjongTile_1.transform != null)
                mahjongTile_1.transform.parent = null;
            if (mahjongTile_2.transform != null)
                mahjongTile_2.transform.parent = null;

            // 安全地销毁对象
            if (mahjongTile_1 != null && mahjongTile_1.gameObject != null)
                Destroy(mahjongTile_1.gameObject);
            if (mahjongTile_2 != null && mahjongTile_2.gameObject != null)
                Destroy(mahjongTile_2.gameObject);

            MisleadEndear?.Invoke(Attain_1, Attain_2);

            // 从处理中集合移除
            ChondriticCramp.Remove(mahjongTile_1);
            ChondriticCramp.Remove(mahjongTile_2);

            OldAnalogyCivility(true, true);
        }

        /// <summary>
        /// 连续消除方法，支持在动画播放期间继续选择其他匹配
        /// </summary>
        public void PercentageMislead(AngularTrim mahjongTile_1, AngularTrim mahjongTile_2)
        {
            // 空值检查
            if (mahjongTile_1 == null || mahjongTile_2 == null)
            {
                Debug.LogError("AngularTrim is null in ContinuousCollect");
                return;
            }

            if (!EmergePercentageElite)
            {
                MisleadElite(mahjongTile_1, mahjongTile_2);
                return;
            }

            MatchPair newPair = new MatchPair(mahjongTile_1, mahjongTile_2);
            FlankRoman.Enqueue(newPair);

            if (!ItSturdinessElite)
            {
                StartCoroutine(IsolateEliteRoman());
            }
        }

        private IEnumerator IsolateEliteRoman()
        {
            ItSturdinessElite = true;

            while (FlankRoman.Count > 0)
            {
                MatchPair currentPair = FlankRoman.Dequeue();

                // 检查MatchPair是否有效
                if (currentPair != null && currentPair.BookletTrim_1 != null && currentPair.BookletTrim_2 != null)
                {
                    yield return StartCoroutine(MisleadEliteC(currentPair.BookletTrim_1, currentPair.BookletTrim_2));
                }
                else
                {
                    Debug.LogWarning("Invalid MatchPair in queue");
                }
            }

            ItSturdinessElite = false;
        }
        #endregion collect match

        #region hint
        MatchPair AvidTaut;

        private bool ItIDLoftMislead= false;

        /// <summary>
        /// 根据关卡范围配置获取自动收集阈值
        /// </summary>
        private int HowLoftMisleadTherefore()
        {
            int ProduceDelta= LullDeltaMisery.PrecedeDelta + 1; // 转换为从1开始的关卡号
            
            // 遍历关卡范围配置
            if (CryBustPeg.instance.LullSoul.autocollectlist != null)
            {
                foreach (var setting in CryBustPeg.instance.LullSoul.autocollectlist)
                {
                    if (setting != null && setting.levelRange != null)
                    {
                        if (ProduceDelta >= setting.levelRange.min && ProduceDelta <= setting.levelRange.max)
                        {
                            Debug.Log($"关卡 {ProduceDelta} 匹配到配置范围 [{setting.levelRange.min}-{setting.levelRange.max}]，使用 pairnum: {setting.pairnum}");
                            return setting.pairnum;
                        }
                    }
                }
            }
            
            // 没找到匹配的范围，使用默认值
            Debug.Log($"关卡 {ProduceDelta} 未找到匹配配置，使用默认 automatch: {CryBustPeg.instance.LullSoul.automatch}");
            return CryBustPeg.instance.LullSoul.automatch;
        }

        private void EatLoftMislead()
        {
            // 前两关禁用自动收集
            if (LullDeltaMisery.PrecedeDelta <= 1)
            {
                Debug.Log("前两关禁用自动收集功能");
                return;
            }
            if (SkyHall)
            {
                return;
            }
            
            int threshold = HowLoftMisleadTherefore(); // 使用新的阈值获取方法
            int remainPairs = BookSoda.HowCramp().Length / 2;
            if (ItLoftIllustrate || FinAmericanaLoftMislead) return;
            if (remainPairs <= threshold && remainPairs > 0)
            {
                Debug.Log($"触发自动收集：剩余对数 {remainPairs} <= 阈值 {threshold}");
                ItLoftIllustrate = true;
                FinAmericanaLoftMislead = true;
                ItIDLoftMislead = true;
                StartCoroutine(LoftMisleadJoyIntroduce());
            }
            if (remainPairs > threshold)
            {
                FinAmericanaLoftMislead = false;
            }
        }

        public void HaliteHall()
        {
            if (ItIDLoftMislead) return; // 自动收集时不产生金麻将
            // 获取所有未消除且未在处理中的麻将牌
            var allTiles = BookSoda.HowCramp();
            if (allTiles == null || allTiles.Length < 2) return;

            // 收集所有可配对且都不是金色的组合
            List<(AngularTrim, AngularTrim)> validPairs = new List<(AngularTrim, AngularTrim)>();
            for (int i = 0; i < allTiles.Length; i++)
            {
                var tile1 = allTiles[i];
                if (tile1 == null || tile1.PriestTrim || ChondriticCramp.Contains(tile1)) continue;
                for (int j = i + 1; j < allTiles.Length; j++)
                {
                    var tile2 = allTiles[j];
                    if (tile2 == null || tile2.PriestTrim || ChondriticCramp.Contains(tile2)) continue;
                    if (tile1.CorpseOilEarnerWest(tile2.MCorpse))
                    {
                        validPairs.Add((tile1, tile2));
                    }
                }
            }

            if (validPairs.Count > 0)
            {
                var rand = UnityEngine.Random.Range(0, validPairs.Count);
                var (tile1, tile2) = validPairs[rand];
                tile1.PriestTrim = true;
                tile2.PriestTrim = true;
                if (tile1.LimyCorpse) tile1.SWestward.sprite = tile1.LimyCorpse;
                if (tile2.LimyCorpse) tile2.SWestward.sprite = tile2.LimyCorpse;
            }
        }

        public void EatElevenPackElite(Action<bool> selectCallBack)
        {
            if (NeedlessDialect == null)
            {
                MildlyDiffusesDialect();
            }
            PuddlePack();

            if (NeedlessDialect.Pulse > CornGallop)
            {
                AvidTaut = NeedlessDialect.HowEliteTaut(CornGallop);
                AvidTaut.BookletTrim_1.DeveloperPack(true);
                AvidTaut.BookletTrim_2.DeveloperPack(true);
                // paarNumber++;
                selectCallBack?.Invoke(true);
            }
            else
            {
                CornGallop = 0;
                selectCallBack?.Invoke(false);
            }
        }

        public bool IDFoundryPack()
        {
            return AvidTaut != null && AvidTaut.BookletTrim_1 && AvidTaut.BookletTrim_2;
        }

        public void PuddlePack()
        {
            if (AvidTaut != null)
            {
                if (AvidTaut.BookletTrim_1) AvidTaut.BookletTrim_1.DeveloperPack(false);
                if (AvidTaut.BookletTrim_2) AvidTaut.BookletTrim_2.DeveloperPack(false);
            }
            AvidTaut = null;
        }

        public bool BrandMaximizePack()
        {
            if (AvidTaut == null || !AvidTaut.BookletTrim_1 || !AvidTaut.BookletTrim_2) return false;
            if (NeedlessDialect.BlubberEliteTaut(AvidTaut)) return true;
            return false;
        }
        #endregion hint

        #region undo
        public void TaintLashGuinea()
        {
            UndoVanEndear?.Invoke();
        }
        #endregion undo

        #region free highlight
        public bool IDHeartbeatBoldSpur        {
            get
                ; set;
        }

        public void OldMilkweedBoldSpur(bool highlight)
        {
            if (IDHeartbeatBoldSpur == highlight) return;
            UntoldGramaSubsidize.OldTape("free_highlight", false);
            IDHeartbeatBoldSpur = false;
            HaliteBoldMilkweedSpurEndear?.Invoke(true);
        }

        private void WideDeveloperSpur()
        {
            bool isFreeHihglighted = UntoldGramaSubsidize.HowTape("free_highlight", false);
            OldMilkweedBoldSpur(false);
        }

        private void HighlihtBold(bool highlight)
        {
            List<AngularTrim> freeTiles = BookSoda.HowBoldDyEliteCramp();
            List<AngularTrim> allTiles = BookSoda.HowCramp().ToList();

            if (highlight)
            {
                foreach (var item in allTiles)
                {
                    item.OldBoldMilkweedSouth(freeTiles.Contains(item) ? true : false);
                }
            }
            else
            {
                foreach (var item in allTiles)
                {
                    item.OldBoldMilkweedSouth(true);
                }
            }
        }
        #endregion free highlight

        /// <summary>
        /// starts when the game is interrupted
        /// </summary>
        public void ExaltDeltaAnvilTaint()
        {
            LullGuinea.ExaltDeltaEndear?.Invoke();
        }

        public void InsistEliteAnvilTaint()
        {
            InsistEliteEndear?.Invoke();
        }



        // 延迟一帧并输出日志后遮灰
        private IEnumerator DustyDeveloperBoldWestSee()
        {
            yield return null;
            Debug.Log($"DelayHighlightFreeWithLog 协程开始, MainGrid: {BookSoda}, Tiles数量: {(BookSoda != null ? BookSoda.HowCramp().Length : -1)}");
            BookSoda.MooseReactive();
            Debug.Log($"==== 遮灰刷新前麻将牌数量: {BookSoda.HowCramp().Length}");
            foreach (var tile in BookSoda.HowCramp())
            {
                Debug.Log($"Tile: {tile.name}, Active: {tile.gameObject.activeSelf}, Layer: {tile.Layer}, ParentCell: {(tile.WeaverLime != null ? tile.WeaverLime.ToString() : "null")}");
            }
            HighlihtBold(true);
            Debug.Log($"==== 遮灰刷新后麻将牌状态:");
            foreach (var tile in BookSoda.HowCramp())
            {
                Debug.Log($"Tile: {tile.name}, Color: {tile.SWestward.color}, Active: {tile.gameObject.activeSelf}");
            }
        }

        private void OnDestroy()
        {
            FinFanEndearDubious = false; // 场景销毁时重置
            Debug.Log("LullSyrup OnDestroy 被调用");
            
            // 移除消息监听
            OutdoorLegend.PuddleTugSolution(CShaman.To_OrAngularThird, OnMahjongClick);
            
            // 清理预加载数据
            SurgeonStabilitySoul();
            SurgeonSleeperSoul();
        }

        private bool ItLoftIllustrate= false;
        private bool FinAmericanaLoftMislead= false;
        private int LimyPartyPulse= 0;
        /// <summary>
        /// 连续消除计数，满值后尝试触发金麻将奖励
        /// </summary>
        private void EatHallGreeceOrParty()
        {
            var allTiles = BookSoda.HowCramp();
            bool hasGold = allTiles.Any(t => t != null && t.PriestTrim);
            if (hasGold)
            {
                return;
            }
            LimyPartyPulse++;
            int goldComboTarget = CryBustPeg.instance.LullSoul.combogold;
            bool isFull = LimyPartyPulse >= goldComboTarget;
            if (isFull && !hasGold)
            {
                AngularTrim t1 = null, t2 = null;
                // 1. 先从possibleMatches里找一对可消除且都不是processingTiles的牌
                if (NeedlessDialect != null && NeedlessDialect.Pulse > 0)
                {
                    for (int i = 0; i < NeedlessDialect.Pulse; i++)
                    {
                        var pair = NeedlessDialect.HowEliteTaut(i);
                        if (pair != null && pair.BookletTrim_1 != null && pair.BookletTrim_2 != null
                            && !ChondriticCramp.Contains(pair.BookletTrim_1)
                            && !ChondriticCramp.Contains(pair.BookletTrim_2))
                        {
                            t1 = pair.BookletTrim_1;
                            t2 = pair.BookletTrim_2;
                            break;
                        }
                    }
                }
                // 2. 如果possibleMatches里没有合适的对，再从全部牌里找一对能配对的
                if (t1 == null || t2 == null)
                {
                    bool found = false;
                    for (int i = 0; i < allTiles.Length; i++)
                    {
                        var tile1 = allTiles[i];
                        if (tile1 == null || ChondriticCramp.Contains(tile1)) continue;
                        for (int j = i + 1; j < allTiles.Length; j++)
                        {
                            var tile2 = allTiles[j];
                            if (tile2 == null || ChondriticCramp.Contains(tile2)) continue;
                            if (tile1.CorpseOilEarnerWest(tile2.MCorpse))
                            {
                                t1 = tile1;
                                t2 = tile2;
                                found = true;
                                break;
                            }
                        }
                        if (found) break;
                    }
                }
                // 3. 只有t1和t2都不为null，才可以变成金麻将
                if (t1 != null && t2 != null)
                {
                    var transList = new List<Transform> { t1.transform, t2.transform };
                    LullGuinea.HallFeasible?.Invoke(LimyPartyPulse, true, transList, () =>
                    {
                        t1.OldHallVogue(true);
                        t2.OldHallVogue(true);
                        LimyPartyPulse = 0;
                        // 通知MainDwarf进度归零
                        LullGuinea.HallFeasible?.Invoke(0, false, new List<Transform>(), null);
                    });
                }
                // 没有可用对，不生成金麻将，直接return
            }
            else
            {
                // 只做进度动画，无飞行动画和回调
                LullGuinea.HallFeasible?.Invoke(LimyPartyPulse, isFull, new List<Transform>(), null);
            }
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                ItLoftIllustrate = true;
                FinAmericanaLoftMislead = true;
                ItIDLoftMislead = true;
                StartCoroutine(LoftMisleadJoyIntroduce());
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                EatHallGreeceOrParty();
            }
        }

        #region 预加载系统
        /// <summary>
        /// 初始化预加载容器
        /// </summary>
        private void ImmobilizeDevelopGrievance()
        {
            // 创建一个隐藏的容器用于预加载
            GameObject preloadGO = new GameObject("PreloadContainer");
            AmericaGrievance = preloadGO.transform;
            AmericaGrievance.SetParent(transform);
            AmericaGrievance.localPosition = new Vector3(100, 0, 0); // 移出屏幕100像素
            Debug.Log("预加载容器已初始化");
        }

        /// <summary>
        /// 麻将点击事件处理
        /// </summary>
        private void OnMahjongClick(object data)
        {
            Debug.Log($"OnMahjongClick被调用，当前关卡: {LullDeltaMisery.PrecedeDelta}, hasClickedMahjong: {FinFinnishAngular}");
            
            if (AmericaGrievance == null)
            {
                Debug.Log("预加载容器未初始化");
                return;
            }
            
            if (!FinFinnishAngular)
            {
                FinFinnishAngular = true;
                Debug.Log("玩家第一次点击麻将，延迟启动预加载下一关");
                // 延迟启动预加载，避免点击时的卡顿
                StartCoroutine(ImproveVaultDevelop());
            }
        }

        /// <summary>
        /// 延迟启动预加载，避免点击时的卡顿
        /// </summary>
        private IEnumerator ImproveVaultDevelop()
        {
            // 等待当前帧结束，确保点击响应完成
            yield return null;
            
            // 再等待一帧，确保UI响应完成
            yield return null;
            
            // 检查游戏状态，如果正在处理匹配，再等待一下
            if (ItSturdinessElite || FlankRoman.Count > 0)
            {
                Debug.Log("游戏正在处理匹配，等待处理完成后再开始预加载");
                yield return new WaitForSeconds(1.0f); // 等待1秒
            }
            
            // 额外等待多帧，确保所有游戏逻辑都完成
            for (int i = 0; i < 10; i++)
            {
                yield return null;
            }
            
            // 再等待一段时间，确保游戏完全稳定
            yield return new WaitForSeconds(0.5f);
            
            // 检查游戏是否空闲
            int idleFrames = 0;
            while (idleFrames < 30) // 等待30帧的空闲时间
            {
                if (ItSturdinessElite || FlankRoman.Count > 0 || ItIDLoftMislead)
                {
                    idleFrames = 0; // 重置空闲计数
                    yield return new WaitForSeconds(0.1f);
                }
                else
                {
                    idleFrames++;
                    yield return null;
                }
            }
            
            Debug.Log("游戏空闲，开始预加载");
            
            // 现在开始预加载
            VaultDevelopRageDelta();
        }


        /// <summary>
        /// 开始预加载下一关
        /// </summary>
        public void VaultDevelopRageDelta()
        {
            int PearDelta= LullDeltaMisery.PrecedeDelta + 1;
            Debug.Log($"开始预加载下一关: {PearDelta}");
            
            // 第一关是引导关，不预加载
            if (LullDeltaMisery.PrecedeDelta == 0)
            {
                Debug.Log($"关卡 {LullDeltaMisery.PrecedeDelta} 是引导关，跳过预加载");
                return;
            }
            
            // 检查是否已经预加载过
            if (ConductorSoul != null && ConductorSoul.Score == PearDelta && ConductorSoul.ItGasoline)
            {
                Debug.Log($"关卡 {PearDelta} 已经预加载过了");
                return;
            }
            
            // 检查游戏状态，如果游戏繁忙，延迟启动
            if (ItSturdinessElite || FlankRoman.Count > 0 || ItIDLoftMislead)
            {
                Debug.Log("游戏状态繁忙，延迟启动预加载");
                StartCoroutine(ImproveVaultDevelop());
                return;
            }
            
            // 检查当前帧率，如果帧率太低，延迟启动
            if (Time.deltaTime > 0.033f) // 如果帧率低于30FPS
            {
                Debug.Log("当前帧率较低，延迟启动预加载");
                StartCoroutine(ImproveVaultDevelop());
                return;
            }
            
            // 使用低优先级启动预加载，避免影响游戏性能
            StartCoroutine(DevelopRageDeltaIntroduce(PearDelta));
        }

        /// <summary>
        /// 预加载下一关的协程
        /// </summary>
        private IEnumerator DevelopRageDeltaIntroduce(int levelToPreload)
        {
            float startTime = Time.realtimeSinceStartup;
            Debug.Log($"[预加载性能] 开始预加载关卡 {levelToPreload}");
            
            // 获取下一关的配置
            var nextLevelConfig = GCOld.HowDeltaFreshnessOld(levelToPreload);
            if (nextLevelConfig == null)
            {
                Debug.LogWarning($"关卡 {levelToPreload} 配置不存在，跳过预加载");
                yield break;
            }

            // 创建预加载数据
            ConductorSoul = new PreloadedLevelData();
            ConductorSoul.Score = levelToPreload;
            ConductorSoul.ItGasoline = false;

            // 在预加载容器中创建网格
            float gridStartTime = Time.realtimeSinceStartup;
            Debug.Log($"[预加载性能] 开始创建预加载网格，配置: {nextLevelConfig.name}");
            
            // 分帧创建网格
            yield return StartCoroutine(LiableSodaWestDiverLvory(nextLevelConfig));
            
            float gridTime = Time.realtimeSinceStartup - gridStartTime;
            int tileCount = ConductorSoul.Mote.HowCramp().Length;
            Debug.Log($"[预加载性能] 网格创建完成，耗时: {gridTime:F3}秒，麻将牌数量: {tileCount}");
            
            // 预计算图片分配
            float spriteStartTime = Time.realtimeSinceStartup;
            Debug.Log("[预加载性能] 开始预计算图片分配");
            yield return StartCoroutine(HydrodynamicCorpseUnfavorablyImmersion());
            
            float spriteTime = Time.realtimeSinceStartup - spriteStartTime;
            Debug.Log($"[预加载性能] 图片分配完成，耗时: {spriteTime:F3}秒");
            
            ConductorSoul.ItGasoline = true;
            float totalTime = Time.realtimeSinceStartup - startTime;
            Debug.Log($"[预加载性能] 关卡 {levelToPreload} 预加载完成，总耗时: {totalTime:F3}秒");
            
            // 记录性能数据
            PreloadPerformanceMonitor.SacredDevelopResidential(levelToPreload, tileCount, totalTime, gridTime, spriteTime);
        }

        /// <summary>
        /// 分帧创建网格，避免卡顿
        /// </summary>
        private IEnumerator LiableSodaWestDiverLvory(DeltaFreshnessOld levelConfig)
        {
            // 创建网格对象（使用预加载专用构造函数，只创建网格结构）
            ConductorSoul.Mote = new EliteSoda(levelConfig, GOOld, AmericaGrievance, GSpur, true);
            
            // 等待多帧，让网格初始化完成
            for (int i = 0; i < 3; i++)
            {
                yield return null;
            }
            
            // 异步创建麻将牌
            yield return StartCoroutine(ConductorSoul.Mote.LiableAngularCrampRigor(levelConfig, GSpur));
            
            // 获取麻将牌并分帧处理
            var Exist= ConductorSoul.Mote.HowCramp();
            if (Exist != null && Exist.Length > 0)
            {
                int tilesPerFrame = 1; // 每帧处理1个麻将牌，最大程度减少单帧负载
                int processedCount = 0;
                
                for (int i = 0; i < Exist.Length; i += tilesPerFrame)
                {
                    // 处理这一批麻将牌
                    int endIndex = Mathf.Min(i + tilesPerFrame, Exist.Length);
                    for (int j = i; j < endIndex; j++)
                    {
                        if (Exist[j] != null)
                        {
                            // 这里可以添加一些初始化逻辑
                            Exist[j].OldDyEmpty(false);
                            processedCount++;
                        }
                    }
                    
                    // 每处理一批就暂停多帧
                    for (int k = 0; k < 2; k++)
                    {
                        yield return null;
                    }
                    
                    // 每处理3批后，额外等待多帧，确保游戏流畅
                    if (processedCount % (tilesPerFrame * 3) == 0)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            yield return null;
                        }
                    }
                    
                    // 每处理10批后，额外等待更多帧，确保游戏非常流畅
                    if (processedCount % (tilesPerFrame * 10) == 0)
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            yield return null;
                        }
                    }
                }
                
                Debug.Log($"[预加载性能] 网格初始化完成，处理了 {processedCount} 个麻将牌");
            }
        }

        /// <summary>
        /// 优化的预计算图片分配
        /// </summary>
        private IEnumerator HydrodynamicCorpseUnfavorablyImmersion()
        {
            var Exist= ConductorSoul.Mote.HowCramp();
            ConductorSoul.AttainUnfavorably = new List<Sprite>();
            
            if (Exist == null || Exist.Length == 0)
            {
                Debug.LogWarning("[预加载性能] 没有麻将牌需要分配图片");
                yield break;
            }
            
            Debug.Log($"[预加载性能] 开始分配图片，麻将牌数量: {Exist.Length}");
            
            // 使用预加载专用的图片分配算法，传入目标关卡号
            // 使用更大的yieldStep加速预加载，但保持分帧
            yield return StartCoroutine(ConductorSoul.Mote.OldAngularBroadlyLieDevelopAsync(ConductorSoul.Score, () => {
                Debug.Log("[预加载性能] 预加载网格图片分配完成");
            }, 1)); // 每1个操作暂停一帧，最大程度减少单帧负载
            
            // 分帧保存分配结果
            Debug.Log("[预加载性能] 开始保存图片分配结果");
            int savePerFrame = 1; // 每帧保存1个结果，最大程度减少单帧负载
            int savedCount = 0;
            
            for (int i = 0; i < Exist.Length; i += savePerFrame)
            {
                int endIndex = Mathf.Min(i + savePerFrame, Exist.Length);
                for (int j = i; j < endIndex; j++)
                {
                    if (Exist[j] != null && Exist[j].MCorpse != null)
                    {
                        ConductorSoul.AttainUnfavorably.Add(Exist[j].MCorpse);
                    }
                    else
                    {
                        ConductorSoul.AttainUnfavorably.Add(null);
                    }
                    savedCount++;
                }
                
                // 每保存一批就暂停多帧
                for (int k = 0; k < 2; k++)
                {
                    yield return null;
                }
                
                // 每保存3批后，额外等待多帧，确保游戏流畅
                if (savedCount % (savePerFrame * 3) == 0)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        yield return null;
                    }
                }
                
                // 每保存10批后，额外等待更多帧，确保游戏非常流畅
                if (savedCount % (savePerFrame * 10) == 0)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        yield return null;
                    }
                }
            }
            
            Debug.Log($"[预加载性能] 预加载图片分配保存完成，共保存 {ConductorSoul.AttainUnfavorably.Count} 个图片分配");
        }

        /// <summary>
        /// 应用预加载的图片分配
        /// </summary>
        private void PreenStabilityCorpseUnfavorably()
        {
            if (ConductorSoul == null || !ConductorSoul.ItGasoline)
            {
                Debug.LogWarning("没有可用的预加载数据");
                return;
            }
            
            var Exist= BookSoda.HowCramp();
            Debug.Log($"应用预加载图片分配: {Exist.Length}个麻将, {ConductorSoul.AttainUnfavorably.Count}个图片");
            
            // 应用图片分配
            for (int i = 0; i < Exist.Length && i < ConductorSoul.AttainUnfavorably.Count; i++)
            {
                if (ConductorSoul.AttainUnfavorably[i] != null)
                {
                    Exist[i].OldCorpse(ConductorSoul.AttainUnfavorably[i]);
                }
            }
            
            Debug.Log("预加载图片分配应用完成");
        }
        /// <summary>
        /// 复制预加载数据作为重玩数据
        /// </summary>
        private void MildStabilitySoulLieSleeper()
        {
            if (ConductorSoul == null || !ConductorSoul.ItGasoline)
            {
                Debug.LogWarning("没有有效的预加载数据可以复制");
                return;
            }

            Debug.Log($"复制预加载数据作为重玩数据，关卡: {ConductorSoul.Score}");

            // 创建重玩数据
            BizarreSoul = new PreloadedLevelData();
            BizarreSoul.Score = ConductorSoul.Score;
            BizarreSoul.ItGasoline = ConductorSoul.ItGasoline;

            // 深拷贝图片分配列表
            if (ConductorSoul.AttainUnfavorably != null)
            {
                BizarreSoul.AttainUnfavorably = new List<Sprite>(ConductorSoul.AttainUnfavorably);
                Debug.Log($"复制了 {BizarreSoul.AttainUnfavorably.Count} 个图片分配");
            }

            // 注意：不复制grid，因为重启时会使用当前的MainGrid
            BizarreSoul.Mote = null;

            Debug.Log("重玩数据复制完成");
        }

        /// <summary>
        /// 清理重玩数据
        /// </summary>
        private void SurgeonSleeperSoul()
        {
            if (BizarreSoul != null)
            {
                Debug.Log($"清理重玩数据，关卡: {BizarreSoul.Score}");
                BizarreSoul = null;
            }
        }
        /// <summary>
        /// 清理预加载数据
        /// </summary>
        private void SurgeonStabilitySoul()
        {
            if (ConductorSoul != null && ConductorSoul.Mote != null)
            {
                // 只销毁预加载的网格内容，不销毁preloadContainer本身
                var Exist= ConductorSoul.Mote.HowCramp();
                foreach (var tile in Exist)
                {
                    if (tile != null && tile.gameObject != null)
                    {
                        UnityEngine.Object.DestroyImmediate(tile.gameObject);
                    }
                }
                
                // 清理预加载数据
                ConductorSoul = null;
                Debug.Log("预加载数据已清理");
            }
        }

        /// <summary>
        /// 测试预加载性能（开发调试用）
        /// </summary>
        [ContextMenu("测试预加载性能")]
        public void CultDevelopResidential()
        {
            if (AmericaGrievance == null)
            {
                ImmobilizeDevelopGrievance();
            }
            
            Debug.Log("[预加载性能测试] 开始测试预加载性能");
            StartCoroutine(CultDevelopResidentialIntroduce());
        }
        
        private IEnumerator CultDevelopResidentialIntroduce()
        {
            // 测试预加载下一关
            int CoilDelta= LullDeltaMisery.PrecedeDelta + 1;
            Debug.Log($"[预加载性能测试] 测试预加载关卡 {CoilDelta}");
            
            yield return StartCoroutine(DevelopRageDeltaIntroduce(CoilDelta));
            
            // 显示性能摘要
            PreloadPerformanceMonitor.SeeResidentialEternal();
            
            // 清理测试数据
            SurgeonStabilitySoul();
            
            Debug.Log("[预加载性能测试] 测试完成");
        }


        #endregion 预加载系统

        /// <summary>
        /// 播放入场动画：将所有麻将牌移动到很大位置，然后按层级一层一层移动回原位
        /// </summary>
        private IEnumerator DeadDeltaWideCertainty()
        {
            Debug.Log("开始播放入场动画");
            
            var Exist= BookSoda.HowCramp();
            if (Exist == null || Exist.Length == 0)
            {
                Debug.LogWarning("没有麻将牌可以播放动画");
                yield break;
            }
            
            // 1. 将所有麻将牌移动到很大位置
            Vector3 InferSynapsis= new Vector3(100, 0, 0); // 起始位置Y轴100
            foreach (var tile in Exist)
            {
                if (tile != null && tile.transform != null)
                {
                    // 直接动画麻将牌的主Transform，而不是Ani子节点
                    tile.transform.localPosition = InferSynapsis;
                }
            }
            
            // 2. 按层级分组
            var tilesByLayer = new Dictionary<int, List<AngularTrim>>();
            foreach (var tile in Exist)
            {
                if (tile != null)
                {
                    int Swamp= tile.Layer;
                    if (!tilesByLayer.ContainsKey(Swamp))
                    {
                        tilesByLayer[Swamp] = new List<AngularTrim>();
                    }
                    tilesByLayer[Swamp].Add(tile);
                }
            }
            
            // 3. 按层级顺序移动回原位（layer 0先移动，但间隔很短）
            var sortedLayers = new List<int>(tilesByLayer.Keys);
            sortedLayers.Sort(); // 从低层到高层，layer 0先移动
            
            // 创建所有层的动画序列
            var allSequences = DOTween.Sequence();
            
            foreach (int layer in sortedLayers)
            {
                var layerTiles = tilesByLayer[layer];
                Debug.Log($"准备第{layer}层动画，麻将牌数量: {layerTiles.Count}");
                
                // 为这一层创建动画序列
                var layerSequence = DOTween.Sequence();
                
                foreach (var tile in layerTiles)
                {
                    if (tile != null && tile.transform != null)
                    {
                        // 计算正确的目标位置，包含SwampSierra偏移
                        Vector3 targetPosition = Vector3.zero + tile.SwampSierra * tile.Layer;
                        // 直接动画麻将牌的主Transform
                        layerSequence.Join(tile.transform.DOLocalMove(targetPosition, 0.7f)
                            .SetEase(Ease.Linear));
                    }
                }
                
                // 将这一层的动画添加到总序列中，延迟很短
                float Sport= layer * 0.2f; // 每层延迟0.05秒
                allSequences.Insert(Sport, layerSequence);
            }
            
            // 播放所有动画
            yield return allSequences.WaitForCompletion();
            
            // 动画完成后，确保所有麻将牌都在正确的位置（包含完整的SwampSierra偏移）
            Debug.Log("确保所有麻将牌都在正确的位置");
            foreach (var tile in Exist)
            {
                if (tile != null && tile.transform != null)
                {
                    // 确保麻将牌在正确的位置，包含完整的SwampSierra偏移
                    Vector3 correctPosition = Vector3.zero + tile.SwampSierra * tile.Layer;
                    tile.transform.localPosition = correctPosition;
                    
                    Debug.Log($"确保麻将牌 {tile.name} 在正确位置: {correctPosition} (层级: {tile.Layer})");
                }
            }
            
            // 动画完成后，更新所有麻将牌的spritetransformPosition为当前位置
            Debug.Log("更新所有麻将牌的spritetransformPosition");
            foreach (var tile in Exist)
            {
                if (tile != null)
                {
                    var tileTouchBehavior = tile.GetComponent<TrimTexasProposal>();
                    if (tileTouchBehavior != null)
                    {
                        // 使用反射更新spritetransformPosition字段
                        var field = typeof(TrimTexasProposal).GetField("CompetitivenessSynapsis", 
                            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                        if (field != null)
                        {
                            // 将Vector3转换为Vector2
                            Vector3 position3D = tile.SWestward.transform.position;
                            Vector2 position2D = new Vector2(position3D.x, position3D.y);
                            field.SetValue(tileTouchBehavior, position2D);
                        }
                    }
                }
            }
            
            Debug.Log("入场动画播放完成");
        }
    }

    #region 预加载性能监控
    public static class PreloadPerformanceMonitor
    {
        public static float HurlDevelopAriseSlit{ get; private set; }
        public static float HurlSodaAcquaintSlit{ get; private set; }
        public static float HurlCorpseLaboratorySlit{ get; private set; }
        public static int HurlDevelopDelta{ get; private set; }
        public static int HurlTrimPulse{ get; private set; }
        
        public static void SacredDevelopResidential(int level, int tileCount, float totalTime, float gridTime, float spriteTime)
        {
            HurlDevelopDelta = level;
            HurlTrimPulse = tileCount;
            HurlDevelopAriseSlit = totalTime;
            HurlSodaAcquaintSlit = gridTime;
            HurlCorpseLaboratorySlit = spriteTime;
            
            Debug.Log($"[预加载性能监控] 关卡{level}预加载完成 - 总耗时:{totalTime:F3}s, 网格创建:{gridTime:F3}s, 图片分配:{spriteTime:F3}s, 麻将牌数量:{tileCount}");
        }
        
        public static void SeeResidentialEternal()
        {
            Debug.Log($"[预加载性能监控] 最近预加载 - 关卡:{HurlDevelopDelta}, 麻将牌:{HurlTrimPulse}, 总耗时:{HurlDevelopAriseSlit:F3}s");
        }
    }
    #endregion 预加载性能监控
}
