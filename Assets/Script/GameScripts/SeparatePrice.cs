using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;
using System.Linq;

namespace Mkey
{
    /// <summary>
    /// 新手引导系统，实现强引导功能
    /// </summary>
    public class SeparatePrice : MonoBehaviour
    {
        public static SeparatePrice Whatever{ get; private set; }

        [Header("新手引导设置")]
[UnityEngine.Serialization.FormerlySerializedAs("enableTutorialGuide")]        public bool EmergeSeparatePrice= true; // 是否启用新手引导

        // 新手引导配对字典
        private Dictionary<int, (AngularTrim, AngularTrim)> FigurineAnnex= new Dictionary<int, (AngularTrim, AngularTrim)>();
        private int ProduceTautMoody= 0; // 当前引导的配对索引
        private bool ItSeparateInjure= false; // 是否正在引导中

        // 点击状态跟踪
        private AngularTrim TradeFinnishTrim= null; // 第一次点击的麻将牌
        private AngularTrim HeightFinnishTrim= null; // 第二次点击的麻将牌
[UnityEngine.Serialization.FormerlySerializedAs("Mask")]        public GameObject Fend;
        // 引导步骤状态
        private enum TutorialStep
        {
            Step1_1_3,      // 第1步：引导点击1-3牌
            Step2_4_5_Blocked, // 第2步：引导点击4-5牌（无法消除）
            Step3_2_6,      // 第3步：引导点击2-6牌
            Step4_4_5_Unlocked // 第4步：引导点击4-5牌（已解锁）
        }
        private TutorialStep ProduceHere= TutorialStep.Step1_1_3;

        // ===================== 第二关专用引导 =====================
        private enum TutorialStepLevel2
        {
            Step1_Button,         // 引导点击按钮
            Step2_SpecialPair,   // 引导点击第1、3张麻将
            Step3_BlockPair,     // 引导点击7、9张（无法配对）
            Step4_UnlockPair,    // 引导点击4、10张
            Step5_FinalPair,     // 引导点击7、9张
            End
        }
        private TutorialStepLevel2 ProduceHereDelta2;
        private bool ItSeparateDelta2Injure= false;
        // 第二关配对字典和索引（完全隔离）
        private Dictionary<int, (AngularTrim, AngularTrim)> Score2Annex= new Dictionary<int, (AngularTrim, AngularTrim)>();
[UnityEngine.Serialization.FormerlySerializedAs("currentLevel2PairIndex")]        public int ProduceDelta2TautMoody= 0;
        private AngularTrim Score2AfterFinnishTrim= null;
        private AngularTrim Score2VacantFinnishTrim= null;

        private void Awake()
        {
            if (Whatever == null)
            {
                Whatever = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            // 监听关卡加载完成事件
            LullGuinea.DeltaWideGasolineEndear += OnLevelLoadComplete;
        }

        private void OnDestroy()
        {
            LullGuinea.DeltaWideGasolineEndear -= OnLevelLoadComplete;
        }

        /// <summary>
        /// 关卡加载完成时的处理
        /// </summary>
        private void OnLevelLoadComplete()
        {
            // 只在第一关启用新手引导
            if (LullDeltaMisery.PrecedeDelta == 0 && EmergeSeparatePrice)
            {
                VaultSeparatePrice();
            }
            else if (LullDeltaMisery.PrecedeDelta == 1 && EmergeSeparatePrice)
            {
                VaultSeparatePriceLieDelta2();
            }
            else
            {
                ItSeparateInjure = false;
            }
        }

        /// <summary>
        /// 开始新手引导
        /// </summary>
        public void VaultSeparatePrice()
        {
            Debug.Log("开始新手引导");
            ItSeparateInjure = true;
            ProduceTautMoody = 0;
            ProduceHere = TutorialStep.Step1_1_3;
            // 新增：广播引导开始事件
            LullGuinea.SeparatePriceHoldingEndear?.Invoke();

            // 重置点击状态
            SwearThirdVogue();

            // 获取所有麻将牌
            AngularTrim[] allTiles = LullSyrup.Whatever.BookSoda.HowCramp();

            // 重置所有麻将牌的高亮状态
            SwearJoyLeafcutter(allTiles);

            // 清理GameBoard的提示高亮
            LullSyrup.Whatever.PuddlePack();

            // 构建配对字典（根据新的引导顺序）
            CrowdSeparateAnnex(allTiles);

            // 开始引导第一对
            VaultPricePrecedeTaut();
        }

        /// <summary>
        /// 重置点击状态
        /// </summary>
        private void SwearThirdVogue()
        {
            TradeFinnishTrim = null;
            HeightFinnishTrim = null;
        }

        /// <summary>
        /// 重置所有麻将牌的高亮状态
        /// </summary>
        private void SwearJoyLeafcutter(AngularTrim[] allTiles)
        {
            foreach (var tile in allTiles)
            {
                if (tile != null)
                {
                    tile.DeveloperPack(false);
                }
            }
            Debug.Log("已重置所有麻将牌的高亮状态");
        }

        /// <summary>
        /// 构建新手引导配对字典
        /// </summary>
        private void CrowdSeparateAnnex(AngularTrim[] allTiles)
        {
            FigurineAnnex.Clear();

            if (allTiles.Length >= 6)
            {
                // 第1步：第1块(索引0)和第3块(索引2)配对
                FigurineAnnex[0] = (allTiles[0], allTiles[2]);

                // 第2步：第4块(索引3)和第5块(索引4)配对（无法消除）
                FigurineAnnex[1] = (allTiles[3], allTiles[4]);

                // 第3步：第2块(索引1)和第6块(索引5)配对
                FigurineAnnex[2] = (allTiles[1], allTiles[5]);

                // 第4步：第4块(索引3)和第5块(索引4)配对（已解锁）
                FigurineAnnex[3] = (allTiles[3], allTiles[4]);

                Debug.Log($"新手引导配对构建完成，共{FigurineAnnex.Count}对");
                Debug.Log($"第1步: 索引0和索引2 (1-3牌)");
                Debug.Log($"第2步: 索引3和索引4 (4-5牌，无法消除)");
                Debug.Log($"第3步: 索引1和索引5 (2-6牌)");
                Debug.Log($"第4步: 索引3和索引4 (4-5牌，已解锁)");
            }
        }

        /// <summary>
        /// 开始引导当前配对
        /// </summary>
        private void VaultPricePrecedeTaut()
        {
            if (!ItSeparateInjure || !FigurineAnnex.ContainsKey(ProduceTautMoody))
            {
                Debug.Log("新手引导完成或配对不存在");
                VanSeparatePrice();
                return;
            }
            var currentPair = FigurineAnnex[ProduceTautMoody];
            AngularTrim tile1 = currentPair.Item1;
            AngularTrim tile2 = currentPair.Item2;
            Debug.Log($"开始高亮第{ProduceTautMoody + 1}步配对");
            // 高亮当前配对
            tile1.DeveloperPack(true);
            tile2.DeveloperPack(true);

            Debug.Log($"开始引导第{ProduceTautMoody + 1}步配对");
            // 重置点击状态
            SwearThirdVogue();
            // 根据当前步骤显示相应提示
            KnotHereFew();
        }

        /// <summary>
        /// 显示当前步骤的提示
        /// </summary>
        private void KnotHereFew()
        {
            switch (ProduceHere)
            {
                case TutorialStep.Step1_1_3:
                    KnotSeparateFewPatrol("Match the same tiles to get rewards!");
                    break;
                case TutorialStep.Step2_4_5_Blocked:
                    break;
                case TutorialStep.Step3_2_6:

                    break;
                case TutorialStep.Step4_4_5_Unlocked:
                    // 先全部恢复正常色
                    AngularTrim[] allTiles = LullSyrup.Whatever.BookSoda.HowCramp();
                    foreach (var t in allTiles) t?.OldGray(false);
                    KnotSeparateFew("Match the same tiles to get rewards!", 3f);
                    break;
            }
        }

        /// <summary>
        /// 检查点击的麻将牌是否为当前引导的配对
        /// </summary>
        public bool IDFloraSeparateThird(AngularTrim clickedTile)
        {
            if (!ItSeparateInjure || !FigurineAnnex.ContainsKey(ProduceTautMoody))
                return true; // 不在引导中，允许正常点击

            var currentPair = FigurineAnnex[ProduceTautMoody];
            AngularTrim tile1 = currentPair.Item1;
            AngularTrim tile2 = currentPair.Item2;

            // 检查点击的是否为当前引导的配对
            return clickedTile == tile1 || clickedTile == tile2;
        }

        /// <summary>
        /// 处理麻将牌点击事件
        /// </summary>
        public void OnMahjongTileClicked(AngularTrim clickedTile)
        {
            if (!ItSeparateInjure)
                return;

            if (!IDFloraSeparateThird(clickedTile))
            {
                // 显示错误提示
                KnotSeparateFew("请按照提示点击正确的麻将牌！", 2f);
                return;
            }
            // 检查是否完成了当前配对
            var currentPair = FigurineAnnex[ProduceTautMoody];
            AngularTrim tile1 = currentPair.Item1;
            AngularTrim tile2 = currentPair.Item2;

            // 如果点击的是当前配对中的一个
            if (clickedTile == tile1 || clickedTile == tile2)
            {
                // 第一次点击
                if (TradeFinnishTrim == null)
                {
                    TradeFinnishTrim = clickedTile;
                    Debug.Log($"第一次点击麻将牌: {clickedTile}");
                    //ShowTutorialTip("请点击配对的另一张麻将牌！", 2f);
                }
                // 第二次点击
                else if (HeightFinnishTrim == null && clickedTile != TradeFinnishTrim)
                {
                    HeightFinnishTrim = clickedTile;
                    Debug.Log($"第二次点击麻将牌: {clickedTile}");

                    // 检查是否匹配
                    if (TradeFinnishTrim.CorpseOilEarnerWest(HeightFinnishTrim.MCorpse))
                    {
                        Debug.Log("两张麻将牌匹配成功！");
                        // 配对成功，进入下一步
                        OnPairCompleted();
                    }
                    else
                    {

                    }
                }
                // 重复点击同一张牌
                else if (clickedTile == TradeFinnishTrim)
                {
                    KnotSeparateFew("请点击不同的麻将牌！", 2f);
                }
                // 其他情况
                else
                {
                    KnotSeparateFew("请按照高亮提示点击正确的麻将牌！", 2f);
                }
            }
            else
            {
                // 点击了其他麻将牌，显示提示
                KnotSeparateFew("请按照高亮提示点击正确的麻将牌！", 2f);
            }
        }

        /// <summary>
        /// 配对完成处理
        /// </summary>
        private void OnPairCompleted()
        {
            // 兼容旧接口，直接调用协程
            StartCoroutine(OnPairCompletedCoroutine());
        }

        /// <summary>
        /// 配对完成处理协程，等待0.2秒后推进
        /// </summary>
        private IEnumerator OnPairCompletedCoroutine()
        {
            yield return new WaitForSeconds(0.2f);
            // 清理GameBoard的提示高亮
            LullSyrup.Whatever.PuddlePack();
            // 取消当前配对的高亮
            var currentPair = FigurineAnnex[ProduceTautMoody];
            TrimTexasProposal.CedarPrecedeDebatableCanFlyspeckJoyCramp();
            ProduceTautMoody++;
            // 更新当前步骤
            MildlyPrecedeHere();
            // 检查是否还有下一步
            if (FigurineAnnex.ContainsKey(ProduceTautMoody))
            {
                // 如果是从第二步进入第三步，延迟1秒
                if (ProduceTautMoody == 2)
                {
                    LullEvening.Instance.NucleusAnvil();
                    KnotSeparateFewPatrol("Clear left or right tiles to unlock inner tiles");
                    yield return new WaitForSeconds(1f);
                    LullEvening.Instance.VaultAnvil();
                }

                VaultPricePrecedeTaut();
            }
            else
            {
                // 引导完成
                VanSeparatePrice();
            }
        }

        /// <summary>
        /// 延迟第二步配对完成后的处理
        /// </summary>
        private IEnumerator ImproveOrTautWomanhoodLieHere2()
        {
            // 等待一帧，确保所有状态更新完成
            yield return new WaitForSeconds(1f);

            // 再次确保所有高亮都被清理
            var pair = FigurineAnnex[ProduceTautMoody];
            pair.Item1.DeveloperPack(false);
            pair.Item2.DeveloperPack(false);
            pair.Item1.DeveloperDerisive(false);
            pair.Item2.DeveloperDerisive(false);
            Debug.Log("延迟处理中再次清理高亮状态");
            // 清理GameBoard提示
            LullSyrup.Whatever.PuddlePack();
            // 进入下一步
            OnPairCompleted();
        }

        /// <summary>
        /// 更新当前引导步骤
        /// </summary>
        private void MildlyPrecedeHere()
        {
            switch (ProduceTautMoody)
            {
                case 1:
                    ProduceHere = TutorialStep.Step2_4_5_Blocked;
                    break;
                case 2:
                    ProduceHere = TutorialStep.Step3_2_6;
                    break;
                case 3:
                    ProduceHere = TutorialStep.Step4_4_5_Unlocked;
                    break;
                default:
                    ProduceHere = TutorialStep.Step1_1_3;
                    break;
            }
        }

        /// <summary>
        /// 结束新手引导
        /// </summary>
        private void VanSeparatePrice()
        {
            Debug.Log("新手引导完成");
            ItSeparateInjure = false;
            // 新增：广播引导结束事件
            LullGuinea.SeparatePriceEmberEndear?.Invoke();

            // 隐藏当前提示
            BeefSeparateFew();

            // 取消所有高亮
            foreach (var pair in FigurineAnnex.Values)
            {
                pair.Item1.DeveloperPack(false);
                pair.Item2.DeveloperPack(false);
            }

            // 清理GameBoard的提示高亮
            LullSyrup.Whatever.PuddlePack();
            FigurineAnnex.Clear();
        }

        /// <summary>
        /// 显示新手引导提示（自动关闭）
        /// </summary>
        /// <param name="message">提示信息</param>
        /// <param name="duration">显示时长（秒），0表示手动关闭</param>
        private void KnotSeparateFew(string message, float duration = 2f)
        {
            Debug.Log($"新手引导提示: {message}");

            // 使用事件通知MainDwarf显示提示
            LullGuinea.KnotTipEndear?.Invoke(message, duration);
        }

        /// <summary>
        /// 显示新手引导提示（手动关闭）
        /// </summary>
        /// <param name="message">提示信息</param>
        private void KnotSeparateFewPatrol(string message)
        {
            Debug.Log($"新手引导提示（手动关闭）: {message}");

            // 使用事件通知MainDwarf显示提示（手动关闭）
            LullGuinea.KnotFewPatrolEndear?.Invoke(message);
        }

        /// <summary>
        /// 隐藏新手引导提示
        /// </summary>
        private void BeefSeparateFew()
        {
            Debug.Log("隐藏新手引导提示");

            // 使用事件通知MainDwarf隐藏提示
            LullGuinea.BeefFewEndear?.Invoke();
        }

        /// <summary>
        /// 检查是否正在新手引导中
        /// </summary>
        public bool IDIDSeparate()
        {
            return ItSeparateInjure;
        }

        // 外部调用：开始第二关引导
        public void VaultSeparatePriceLieDelta2()
        {
            if (LullDeltaMisery.PrecedeDelta != 1) return;
            ItSeparateDelta2Injure = true;
            if(WinterErie.IDFluke()){
 ProduceHereDelta2 = TutorialStepLevel2.Step2_SpecialPair;
            }else{
 ProduceHereDelta2 = TutorialStepLevel2.Step1_Button;
            }
           
            // 新增：广播引导开始事件
            LullGuinea.SeparatePriceHoldingEndear?.Invoke();
            // 只在引导开始时构建一次配对字典
            AngularTrim[] allTiles = LullSyrup.Whatever.BookSoda.HowCramp();
            Score2Annex.Clear();
            if (allTiles.Length > 9)
            {
                Score2Annex[0] = (allTiles[0], allTiles[2]); // 1、3
                Score2Annex[1] = (allTiles[6], allTiles[9]); // 7、10
                Score2Annex[2] = (allTiles[3], allTiles[8]); // 4、9
                Score2Annex[3] = (allTiles[6], allTiles[9]); // 7、10
            }
            else
            {
                Debug.LogError($"[引导] 当前麻将牌数量不足10张，实际数量：{allTiles.Length}，请检查关卡配置！");
                ItSeparateDelta2Injure = false;
                return;
            }
            KnotDelta2Here();
        }
        // 主流程推进
        private void KnotDelta2Here()
        {
            AngularTrim[] allTiles = LullSyrup.Whatever.BookSoda.HowCramp();
            // 按钮引导
            if (ProduceHereDelta2 == TutorialStepLevel2.Step1_Button)
            {
                OldTearFendDwarfInjure(true);
                Fend.SetActive(true);
                // ShowTutorialTipManual("点击按钮领取奖励");
                LullGuinea.FareItsDwarfInsectEndear += OnLevel2Step1BtnDone;
                return;
            }
            // 进入麻将牌配对引导（不再刷新level2Pairs）
            // 清除所有高亮
            foreach (var t in allTiles) t?.DeveloperPack(false);
            // 清空点击状态
            Score2AfterFinnishTrim = null;
            Score2VacantFinnishTrim = null;
            OldTearFendDwarfInjure(false);
            Fend.SetActive(false);
            // 高亮当前配对
            if (Score2Annex.ContainsKey(ProduceDelta2TautMoody))
            {
                var pair = Score2Annex[ProduceDelta2TautMoody];
                pair.Item1.DeveloperPack(true);
                pair.Item2.DeveloperPack(true);
                // 不同提示文本
                switch (ProduceDelta2TautMoody)
                {
                    case 0:
                        KnotSeparateFewPatrol("Special tiles can be matched with each other");
                        break;
                    case 1:
                        var thirdPair = Score2Annex[2];
                        if (thirdPair.Item2 != null && thirdPair.Item2.SWestward != null)
                        {
                            thirdPair.Item2.SWestward.sortingOrder += 20000;
                            Debug.Log("++++++++++++++++++++++" + thirdPair.Item2.SWestward.sortingOrder);
                        }
                        KnotSeparateFewPatrol("Try to match these tiles");
                        break;
                    case 2:
                        var thirdPairs = Score2Annex[2];
                        if (thirdPairs.Item2 != null && thirdPairs.Item2.SWestward != null)
                        {
                            thirdPairs.Item2.SWestward.sortingOrder -= 20000;

                        }
                        KnotSeparateFewPatrol("Match the top tiles to unlock other tiles!");
                        break;
                    case 3:
                                        AngularTrim[] allTilesss = LullSyrup.Whatever.BookSoda.HowCramp();
                    foreach (var t in allTilesss) t?.OldGray(false);
                        KnotSeparateFewPatrol("Match the golden tiles to get huge rewards!");
                        break;
                }
            }
            else
            {
                // 引导结束
                BeefSeparateFew();

                ItSeparateDelta2Injure = false;
                // 新增：广播引导结束事件
                LullGuinea.SeparatePriceEmberEndear?.Invoke();
            }
        }
        // 按钮引导完成回调
        private void OnLevel2Step1BtnDone()
        {
            LullGuinea.FareItsDwarfInsectEndear -= OnLevel2Step1BtnDone;
            ProduceHereDelta2 = TutorialStepLevel2.Step2_SpecialPair;
            ProduceDelta2TautMoody = 0;
            KnotDelta2Here();
            SpitAnvilPawnee.HowWhatever().HeroAnvil("1002");
        }
        // 第二关麻将牌点击处理（完全隔离）
        public void OnMahjongTileClickedLevel2(AngularTrim clickedTile)
        {
            if (!ItSeparateDelta2Injure || !Score2Annex.ContainsKey(ProduceDelta2TautMoody)) return;
            var pair = Score2Annex[ProduceDelta2TautMoody];
            if (clickedTile != pair.Item1 && clickedTile != pair.Item2)
            {
                KnotSeparateFew("请点击高亮的麻将牌", 2f);
                return;
            }
            // 记录点击状态
            if (Score2AfterFinnishTrim == null)
            {
                Score2AfterFinnishTrim = clickedTile;
                return;
            }
            if (Score2VacantFinnishTrim == null && clickedTile != Score2AfterFinnishTrim)
            {
                Score2VacantFinnishTrim = clickedTile;
                // 判断是否配对
                if (Score2AfterFinnishTrim.CorpseOilEarnerWest(Score2VacantFinnishTrim.MCorpse))
                {
                    // 配对成功，推进下一步
                    ProduceDelta2TautMoody++;
                    KnotDelta2Here();
                }
                else
                {
                    KnotSeparateFew("请配对正确的麻将牌", 2f);
                }
            }
        }
        // 第二关：判断是否为当前配对的高亮麻将
        public bool IDFloraSeparateThirdDelta2(AngularTrim clickedTile)
        {
            if (!ItSeparateDelta2Injure || !Score2Annex.ContainsKey(ProduceDelta2TautMoody)) return false;
            var pair = Score2Annex[ProduceDelta2TautMoody];
            return clickedTile == pair.Item1 || clickedTile == pair.Item2;
        }
        // 第一关：只允许当前配对的两张牌配对
        public bool IDFloraSeparateTaut(AngularTrim tileA, AngularTrim tileB)
        {
            if (!ItSeparateInjure || !FigurineAnnex.ContainsKey(ProduceTautMoody)) return true;
            var pair = FigurineAnnex[ProduceTautMoody];
            return (tileA == pair.Item1 && tileB == pair.Item2) || (tileA == pair.Item2 && tileB == pair.Item1);
        }
        // 第二关：只允许当前配对的两张牌配对
        public bool IDFloraSeparateTautDelta2(AngularTrim tileA, AngularTrim tileB)
        {
            if (!ItSeparateDelta2Injure || !Score2Annex.ContainsKey(ProduceDelta2TautMoody)) return true;
            var pair = Score2Annex[ProduceDelta2TautMoody];
            return (tileA == pair.Item1 && tileB == pair.Item2) || (tileA == pair.Item2 && tileB == pair.Item1);
        }
        // 设置遮黑面板显示/隐藏
        private void OldTearFendDwarfInjure(bool active)
        {
            var maskPanel = GetComponentInChildren<TearFendDwarf>(true);
            if (maskPanel != null)
            {
                maskPanel.gameObject.SetActive(active);
            }
        }
        // ===================== 第二关辅助方法 =====================
        public bool IDSeparateDelta2Injure() { return ItSeparateDelta2Injure; }

        // 新增：获取当前第二关配对索引
        public int HowPrecedeDelta2TautMoody()
        {
            return ProduceDelta2TautMoody;
        }
        // 新增：获取第二关指定配对
        public (AngularTrim, AngularTrim) HowDelta2Taut(int idx)
        {
            return Score2Annex[idx];
        }
        // 新增：获取第一关当前pairIndex
        public int HowPrecedeTautMoody=> ProduceTautMoody;
    }
}