using UnityEngine;

namespace Mkey
{
	/// <summary>
	/// 麻将牌触摸行为，处理点击、拖拽、匹配等交互
	/// </summary>
	public class TrimTexasProposal : TexasShyOutdoorMildly
	{
[UnityEngine.Serialization.FormerlySerializedAs("mahjongTile")]        public AngularTrim BookletTrim; // 当前关联的麻将牌对象

        #region temp vars
        private TexasEvening TexasM{ get { return TexasEvening.Instance; } } // 触摸管理器单例
        private Transform AttainRefurbish; // 精灵变换组件
        private Vector2 CompetitivenessSynapsis; // 精灵初始位置
        private bool FurOrPastoral= false; // 是否可能取消选中
        private LullSyrup MSyrup{ get { return LullSyrup.Whatever; } } // 游戏主面板单例
        #endregion temp vars

        private void Start()
        {
            if (LullSyrup.GSpur == GameMode.Play)
            {
                VisibleMustAnvil = VisibleMustAnvilPropose;
                VisibleOfAnvil = VisibleOfAnvilPropose;
                SlayAnvil = SlayAnvilPropose;
                BookletTrim = GetComponent<AngularTrim>();
                AttainRefurbish = BookletTrim.SWestward.transform;
                CompetitivenessSynapsis = AttainRefurbish.position;
            }
            else
            {
                VisibleMustAnvil = VisibleMustAnvilPropose;
            }
        }

        #region touchbehavior
        private void VisibleMustAnvilPropose(TexasShyAnvilArgs tpea)
        {
            // 新增：第二关第一步点击限制，只允许字典第0组的两张牌
            if (Mkey.SeparatePrice.Whatever != null && Mkey.SeparatePrice.Whatever.IDSeparateDelta2Injure())
            {
                if (Mkey.SeparatePrice.Whatever.HowPrecedeDelta2TautMoody() == 0)
                {
                    var pair = Mkey.SeparatePrice.Whatever.HowDelta2Taut(0);
                    if (BookletTrim != pair.Item1 && BookletTrim != pair.Item2)
                    {
                        return;
                    }
                }
            }
            if (LullSyrup.GSpur == GameMode.Play)
            {
                // 新增：点击麻将牌时播放音效
                StarkPeg.HowWhatever().DeadEncode(StarkLieu.SceneMusic.Sound_Clickmj);
                Debug.Log("pointer down: " + this);
                Debug.Log($"[配对调试] 当前点击: {BookletTrim}, IsFirstObject: {IDAfterScreen()}, TouchM.FirstObject: {TexasM.AfterScreen}");
                FurOrPastoral = false;
                SetAbreast = false;

                // 新手引导点击检测
                if (Mkey.SeparatePrice.Whatever != null)
                {
                    // 第一关强引导
                    if (Mkey.SeparatePrice.Whatever.IDIDSeparate())
                    {
                        if (!Mkey.SeparatePrice.Whatever.IDFloraSeparateThird(BookletTrim))
                        {
                            Debug.Log("[新手引导] 非当前步骤高亮麻将，点击无效");
                            return;
                        }
                        Mkey.SeparatePrice.Whatever.OnMahjongTileClicked(BookletTrim);
                        // 不return，允许后续配对消除逻辑继续执行
                    }
                    // 第二关强引导
                    else if (Mkey.SeparatePrice.Whatever.IDSeparateDelta2Injure())
                    {
                        if (!Mkey.SeparatePrice.Whatever.IDFloraSeparateThirdDelta2(BookletTrim))
                        {
                            Debug.Log("[新手引导-第二关] 非当前步骤高亮麻将，点击无效");
                            return;
                        }
                        Mkey.SeparatePrice.Whatever.OnMahjongTileClickedLevel2(BookletTrim);
                        // 不return，允许后续配对消除逻辑继续执行
                    }
                }
                if (BookletTrim.IDBoldDyElite())
                {
                    if (IDAfterScreen())
                    {
                        FurOrPastoral = true;
                        TexasM.OilSlay = true;
                        return;
                    }
                    else if (TexasM.AfterScreen && TexasM.AfterScreen != AttainRefurbish) // is probably second object
                    {
                        if (OilEliteWest(TexasM.AfterScreen))
                        {
                            DeveloperDerisive(true);
                            EliteWest(TexasM.AfterScreen);
                            TexasM.OilSlay = false;
                            return;
                        }
                        else
                        {
                            DeveloperTentDerisive(false);
                            OldAsAfterScreen();
                            DeveloperDerisive(true);
                            TexasM.OilSlay = false;
                            MSyrup.InsistEliteAnvilTaint();
                        }
                    }

                    OldAsAfterScreen();
                }
                else // failed match select
                {
                    DeveloperTentDerisive(false);
                    TexasM.OldAfterScreen(null, null);
                    TexasM.OilSlay = false;
                    BookletTrim.Bench(); // 抖动反馈
                    // 新增：引导阶段特殊处理——不可消除麻将抖动后变灰
                    if (Mkey.SeparatePrice.Whatever != null)
                    {
                        // 第一关第二步
                        if (Mkey.SeparatePrice.Whatever.IDIDSeparate() && Mkey.SeparatePrice.Whatever.HowPrecedeTautMoody == 1)
                        {
                            BookletTrim.OldGray(true);
                        }
                        // 第二关麻将部分第二对
                        if (Mkey.SeparatePrice.Whatever.IDSeparateDelta2Injure() && Mkey.SeparatePrice.Whatever.ProduceDelta2TautMoody == 2)
                        {
                            BookletTrim.OldGray(true);
                        }
                    }
                    MSyrup.InsistEliteAnvilTaint();
                }
            }
            else    // edit mode
            {
#if UNITY_EDITOR
                LullUnreachable gameConstructor = FindAnyObjectByType<LullUnreachable>();
                Vector3 tPos =  tpea.KneelPot;
                BoxCollider2D collider2D = BookletTrim.AirExchange;
                Bounds bounds = collider2D.bounds;
                // Vector3 min = bounds.min;
                // Vector3 max = bounds.max;
                int quadrant = HowNegative(bounds, tPos);
                // Debug.Log("collider bound min: " + min + "; max: " + max + "; quadrant: " + quadrant);
                if (quadrant == 1) gameConstructor.Cell_Click(BookletTrim.WeaverLime);
                else if (quadrant == 2) gameConstructor.Cell_Click(BookletTrim.WeaverLime.Practical.Book_2);
                else if (quadrant == 3) gameConstructor.Cell_Click(BookletTrim.WeaverLime.Practical.Book_3);
                else if (quadrant == 4) gameConstructor.Cell_Click(BookletTrim.WeaverLime.Practical.Book_4);
#endif
            }
        }

        bool SetAbreast= false;
        private void SlayAnvilPropose(TexasShyAnvilArgs tpea)
        {
            SetAbreast = TexasM.ButSlayRefiner;
        }

        private void VisibleOfAnvilPropose(TexasShyAnvilArgs tpea)
        {
            // 新增：第二关第一步配对限制
            if (Mkey.SeparatePrice.Whatever != null && Mkey.SeparatePrice.Whatever.IDSeparateDelta2Injure())
            {
                if (Mkey.SeparatePrice.Whatever.HowPrecedeDelta2TautMoody() == 0)
                {
                    var pair = Mkey.SeparatePrice.Whatever.HowDelta2Taut(0);
                    AngularTrim otherTile = null;
                    if (TexasM.AfterScreen)
                        otherTile = TexasM.AfterScreen.GetComponentInParent<AngularTrim>();
                    // 只允许配对字典第0组的两张牌
                    if (!((BookletTrim == pair.Item1 || BookletTrim == pair.Item2) &&
                          (otherTile == pair.Item1 || otherTile == pair.Item2)))
                    {
                        return;
                    }
                }
            }
            if (!TexasM.AfterScreen) return;
            TexasM.VisibleOfScreen = null;
            if (IDAfterScreen()&& !SetAbreast) 
            { 
                if (FurOrPastoral) 
                {
                    TexasM.OldAfterScreen(null, null);
                    DeveloperDerisive(false);
                    return; 
                } 
            }
            else if (IDAfterScreen() && SetAbreast)
            {
                TexasM.SwearSlayAnvilTaint(null);
                return;
            }
           
            // Debug.Log("pointer up: " + this + " ;TouchM.Draggable: " + TouchM.Draggable + ";CanCombine(TouchM.Draggable)" + CanCombine(TouchM.Draggable));
            if (OilEliteWest(TexasM.AfterScreen))
            {
                TexasM.VisibleOfScreen = AttainRefurbish;
                TexasM.OilSlay = false;
                DeveloperDerisive(true);
                EliteWest(TexasM.AfterScreen);
            }
            else
            {
                TexasM.OilSlay = false;
                TexasM.SwearSlayAnvilTaint(null);
                if (!IDAfterScreen())
                {
                    MSyrup.InsistEliteAnvilTaint();
                }
            }
        }
        #endregion touchbehavior

        private bool OilEliteWest(Transform other)
        {
            // 新手引导强制配对限制
            if (Mkey.SeparatePrice.Whatever != null)
            {
                if (Mkey.SeparatePrice.Whatever.IDSeparateDelta2Injure())
                {
                    // 只在第二关第一步做特殊限制
                    if (Mkey.SeparatePrice.Whatever.HowPrecedeDelta2TautMoody() == 0)
                    {
                        var pair = Mkey.SeparatePrice.Whatever.HowDelta2Taut(0);
                        AngularTrim otherTile = other.GetComponentInParent<AngularTrim>();
                        if (BookletTrim == pair.Item1 || BookletTrim == pair.Item2 ||
                            otherTile == pair.Item1 || otherTile == pair.Item2)
                        {
                            // 允许配对
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            // 原有逻辑
            if (other == AttainRefurbish || other == null) return false;
            if (!BookletTrim.IDBoldDyElite()) return false;
            AngularTrim otherTile2 = other.GetComponentInParent<AngularTrim>();
            if (!otherTile2) return false;
            if (MSyrup.IDTrimGourdWoodblock(BookletTrim) || MSyrup.IDTrimGourdWoodblock(otherTile2))
            {
                return false;
            }
            bool canMatch = BookletTrim.CorpseOilEarnerWest(otherTile2.MCorpse);
            Debug.Log($"[配对调试] {BookletTrim} 和 {otherTile2} CorpseOilEarnerWest结果: {canMatch}");
            return canMatch;
        }

        private void EliteWest(Transform draggable)
        {
            AngularTrim currentTile = GetComponent<AngularTrim>();
            AngularTrim other = draggable.GetComponentInParent<AngularTrim>();
            Debug.Log($"[配对调试] 执行配对: {currentTile} 和 {other}");
            
            // 检查两个麻将牌是否都有效
            if (currentTile == null || other == null)
            {
                Debug.LogError("One or both MahjongTiles are null in MatchWith");
                return;
            }
            
            // 检查麻将牌是否仍然在网格中
            if (currentTile.GetComponentInParent<SodaLime>() == null || other.GetComponentInParent<SodaLime>() == null)
            {
                Debug.LogError("One or both MahjongTiles are not in SodaLime in MatchWith");
                return;
            }
            
            MSyrup.MisleadElite(currentTile, other);
        }

        private void DeveloperDerisive(bool highlight) 
        {
            if (BookletTrim) 
            {
                BookletTrim.OldDyEmpty(highlight);
                BookletTrim.DeveloperDerisive(highlight);
                Debug.Log("系统正常高亮");
            }
        }

        private void DeveloperTentDerisive(bool highlight)
        {
            DeveloperDerisive(highlight);
            if (TexasM.AfterScreen)
            {
                AngularTrim mTile = TexasM.AfterScreen.GetComponentInParent<AngularTrim>();
                if (mTile)
                {
                    mTile.DeveloperDerisive(highlight);
                    mTile.OldDyEmpty(highlight);
                }
            }
        }

        private void OldFamiliarization()
        {
            if(AttainRefurbish) AttainRefurbish.position = CompetitivenessSynapsis;
        }

        public bool IDAfterScreen()
        {
            return TexasM.AfterScreen && TexasM.AfterScreen == AttainRefurbish;
        }

        public void OldAsAfterScreen()
        {
            TexasM.OldAfterScreen(AttainRefurbish, (cBack) =>
            {
                OldFamiliarization();
                TexasM.OilSlay = false;
                // Debug.Log("reset drag");
            });
            DeveloperDerisive(true);
            TexasM.OilSlay = true;
        }

        #region constructor
        // 2 3
        // 1 4
        private int HowNegative(Bounds bounds, Vector3 touchPos)
        {
            Vector3 min = bounds.min;
            Vector3 max = bounds.max;
            Vector2 size = max - min;
            Vector2 sizeH = size * 0.5f;

            if (touchPos.x < min.x + sizeH.x && touchPos.y < min.y + sizeH.y) return 1;
            else if (touchPos.x < min.x + sizeH.x) return 2;
            else if (touchPos.y < min.y + sizeH.y) return 4;
            else return 3;
        }
        #endregion constructor

        /// <summary>
        /// 取消当前选择并恢复所有麻将未选中状态
        /// </summary>
        public static void CedarPrecedeDebatableCanFlyspeckJoyCramp()
        {
            // 1. 清除TouchManager的当前选择
            if (TexasEvening.Instance != null)
            {
                TexasEvening.Instance.OldAfterScreen(null, null);
            }
            // 2. 恢复所有麻将未选中
            if (LullSyrup.Whatever != null && LullSyrup.Whatever.BookSoda != null)
            {
                var allTiles = LullSyrup.Whatever.BookSoda.HowCramp();
                if (allTiles != null)
                {
                    foreach (var tile in allTiles)
                    {
                        if (tile != null)
                        {
                            tile.DeveloperPack(false);
                            tile.DeveloperDerisive(false);
                            tile.OldDyEmpty(false);
                        }
                    }
                }
            }
        }
    }
}
