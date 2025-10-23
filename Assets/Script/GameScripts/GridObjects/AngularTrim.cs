using System;
using System.Collections;
using System.Collections.Generic;
using Lofelt.NiceVibrations;
using Spine.Unity;
using UnityEngine;

namespace Mkey
{
    /// <summary>
    /// 麻将牌对象，继承自GridObject，包含匹配、阻挡、渲染等逻辑
    /// </summary>
    public class AngularTrim : SodaScreen
    {
[UnityEngine.Serialization.FormerlySerializedAs("SwampSierra")]        public Vector3 SwampSierra; // 层偏移量
        public Sprite MCorpse=> SWestward.sprite; // 当前精灵
[UnityEngine.Serialization.FormerlySerializedAs("selectPrefab")]
        public GameObject EmbodyDismal; // 选中高亮预制体
[UnityEngine.Serialization.FormerlySerializedAs("hintPrefab")]        public GameObject AvidDismal; // 提示高亮预制体
[UnityEngine.Serialization.FormerlySerializedAs("leftBorder")]        public SpriteRenderer GushDuring; // 左边框
[UnityEngine.Serialization.FormerlySerializedAs("shadow")]        public SpriteRenderer Nature; // 阴影
[UnityEngine.Serialization.FormerlySerializedAs("constructLineHor")]        public SpriteRenderer SnowdriftWildBow; // 编辑器横线
[UnityEngine.Serialization.FormerlySerializedAs("constructLineVert")]        public SpriteRenderer SnowdriftWildHomo; // 编辑器竖线
[UnityEngine.Serialization.FormerlySerializedAs("constructLayerText")]        public TextMesh SnowdriftAgainPity; // 层数文本
[UnityEngine.Serialization.FormerlySerializedAs("PriestTrim")]        public bool PriestTrim= false; // 是否为金牌

        internal List<SodaLime> AlaBrynReactive; // 上方阻挡格子
        internal List<SodaLime> AlaPackReactive; // 左侧阻挡格子
        internal List<SodaLime> AlaBloomReactive; // 右侧阻挡格子
[UnityEngine.Serialization.FormerlySerializedAs("LimyCorpse")]
        public Sprite LimyCorpse;

        #region temp vars
        private GameObject AvidScreen; // 提示对象
        private GameObject EmbodyScreen; // 选中对象
        private Vector3 AttainRefurbishSynapsis; // 精灵初始位置
        private bool IrregularlyHint= false; // 是否高亮提示
        private bool IrregularlyYew= false; // 是否高亮选中

        // 性能优化：静态缓存集合，避免重复创建
        private static List<SodaLime> RoomReactive= new List<SodaLime>(8); // 静态缓存，预分配容量
        private static SodaScreen RoomSodaScreen; // 静态缓存GridObject，避免重复创建
        #endregion temp vars

        #region properties
        public int NationalKick=> 2; // 占用列数
        public int NationalRite=> 2; // 占用行数
        private TexasEvening TexasM{ get { return TexasEvening.Instance; } } // 触摸管理器
        public Transform AttainRefurbish=> SWestward.transform; // 精灵变换
[UnityEngine.Serialization.FormerlySerializedAs("insGoldTrans")]
        public Transform PulHallRefer;
[UnityEngine.Serialization.FormerlySerializedAs("qian_Skeleton")]        public GameObject Look_Salinity;

        #endregion properties

        #region override
        /// <summary>
        /// 设置渲染顺序，前置/还原
        /// </summary>
        public override void OldDyEmpty(bool toFront)
        {
            SWestward.sortingOrder = HowTypifyEmpty(toFront);
            if (Nature) Nature.sortingOrder = (toFront) ? 20000 - 1 : FloristEmpty.Real + Layer * 2000;
            // set border
            if (toFront)
            {
                GushDuring.enabled = false;
            }
            else
            {
                MormonPackDuring();
            }
        }

        public override string ToString()
        {
            return "AngularTrim: " + Layer;
        }

        public override SodaScreen Liable(SodaLime parent, int layer)
        {
            if (!parent) return null;
            Layer = layer;
            OceaniaJoltPhenomenon(parent, true, true);

            AngularTrim gridObject = Instantiate(this, parent.transform);
            if (!gridObject) return null;
            gridObject.OldAgain(layer);
            gridObject.transform.localScale = Vector3.one;
            gridObject.transform.localPosition = Vector3.zero + SwampSierra * layer;
            gridObject.WeaverLime = parent;
#if UNITY_EDITOR
            gridObject.name = "AngularTrim " + parent.ToString();
#endif
            // Debug.Log("create gameobject: " + parent + "; " + gridObject);

            return gridObject;
        }

        /// <summary>
        /// 关联到指定格子
        /// </summary>
        public void BearDyLime(SodaLime gridCell, bool setPosition)
        {
            transform.parent = gridCell.transform;
            if (setPosition) transform.localPosition = Vector3.zero + SwampSierra * Layer;
            WeaverLime = gridCell;
#if UNITY_EDITOR
            name = "AngularTrim " + WeaverLime.ToString();
#endif
        }

        public override bool OilOldUpSalt(SodaLime gCell)
        {
            List<SodaLime> cells= HowNationalAcorn(gCell);
            return (cells.Count == NationalKick * NationalRite);
        }

        /// <summary>
        /// 检查该对象能否按层放置在格子上（优化版本，避免重复创建集合）
        /// </summary>
        /// <param name="gCell"></param>
        /// <returns></returns>
        public override bool OilOldUpAgain(SodaLime gCell, int layer)
        {
            if (layer == 0) return true;
            if (layer > 0)
            {
                int underLayer = layer - 1;
                List<SodaLime> cells= HowNationalAcorn(gCell);

                // 性能优化：使用for循环替代foreach，减少隐式迭代器分配
                for (int i = 0; i < cells.Count; i++)
                {
                    var item = cells[i];
                    if (item != null)
                    {
                        SodaScreen gO = item.HowAgainScreen(underLayer, true, true);
                        if (!gO) return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 获取占用尺寸（行，列）
        /// </summary>
        /// <returns></returns>
        public override Vector2Int HowSalt()
        {
            return new Vector2Int(NationalRite, NationalKick);
        }

        // 性能优化：复用集合，避免重复创建
        private static List<SodaLime> RoomNationalAcorn= new List<SodaLime>(4); // 预分配容量

        public override List<SodaLime> HowNationalAcorn(SodaLime gCell)
        {
            // 性能优化：复用集合，避免重复创建
            RoomNationalAcorn.Clear();

            int cRow = gCell.Row;
            int cCol = gCell.Column;
            EliteSoda mGrid = gCell.MSoda;
            SodaLime _gCell;

            for (int r = cRow; r > cRow - NationalRite; r--)
            {
                for (int c= cCol; c < cCol + NationalKick; c++)
                {
                    _gCell = mGrid[r, c];
                    if (_gCell) RoomNationalAcorn.Add(_gCell);
                }
            }

            // 返回新列表副本，避免外部修改影响缓存
            return new List<SodaLime>(RoomNationalAcorn);
        }
        #endregion override

        /// <summary>
        /// 判断该格子是否可被填充（优化版本，使用缓存阻挡信息）
        /// </summary>
        public bool IDBoldDyBrim()
        {
            // 性能优化：使用缓存的阻挡信息，避免重复调用HowAgainScreen
            if (AlaBrynReactive != null && AlaBrynReactive.Count > 0)
            {
                // 检查上方阻挡
                foreach (var gCell in AlaBrynReactive)
                {
                    if (gCell != null)
                    {
                        // 性能优化：复用静态缓存GridObject
                        RoomSodaScreen = gCell.HowAgainScreen(Layer + 1, false, true);
                        if (RoomSodaScreen != null && !RoomSodaScreen.Outskirt)
                        {
                            return false; // 上方被阻挡
                        }
                    }
                }
            }

            // 检查左侧阻挡
            bool leftBlocked = false;
            if (AlaPackReactive != null && AlaPackReactive.Count > 0)
            {
                foreach (var gCell in AlaPackReactive)
                {
                    if (gCell != null)
                    {
                        RoomSodaScreen = gCell.HowAgainScreen(Layer, false, true);
                        if (RoomSodaScreen != null && !RoomSodaScreen.Outskirt)
                        {
                            leftBlocked = true;
                            break;
                        }
                    }
                }
            }
            if (!leftBlocked) return true; // 左侧有空间

            // 检查右侧阻挡
            bool rightBlocked = false;
            if (AlaBloomReactive != null && AlaBloomReactive.Count > 0)
            {
                foreach (var gCell in AlaBloomReactive)
                {
                    if (gCell != null)
                    {
                        RoomSodaScreen = gCell.HowAgainScreen(Layer, false, true);
                        if (RoomSodaScreen != null && !RoomSodaScreen.Outskirt)
                        {
                            rightBlocked = true;
                            break;
                        }
                    }
                }
            }
            if (!rightBlocked) return true; // 右侧有空间

            // 如果左右都被阻挡，则不可填充
            return false;
        }

        /// <summary>
        /// 判断该格子是否可被匹配（旧逻辑）
        /// </summary>
        public bool IDBApeDyElite_Ape()
        {
            ChildDale neighBors = base.WeaverLime.Practical;
            // over
            SodaScreen o1 = (neighBors.Book_1) ? neighBors.Book_1.HowAgainScreen(Layer + 1, true, true) : null;
            SodaScreen o2 = (neighBors.Book_2) ? neighBors.Book_2.HowAgainScreen(Layer + 1, true, true) : null;
            SodaScreen o3 = (neighBors.Book_3) ? neighBors.Book_3.HowAgainScreen(Layer + 1, true, true) : null;
            SodaScreen o4 = (neighBors.Book_4) ? neighBors.Book_4.HowAgainScreen(Layer + 1, true, true) : null;
            bool overBlocked1 = (o1 != null);
            bool overBlocked2 = (o2 != null);
            bool overBlocked3 = (o3 != null);
            bool overBlocked4 = (o4 != null);
            bool overBlocked = (overBlocked1 || overBlocked2 || overBlocked3 || overBlocked4);
            if (overBlocked) return false;

            // left
            SodaScreen l1 = (neighBors.Pack_1) ? neighBors.Pack_1.HowAgainScreen(Layer, true, true) : null;
            SodaScreen l2 = (neighBors.Pack_2) ? neighBors.Pack_2.HowAgainScreen(Layer, true, true) : null;
            bool leftBlocked1 = (l1 != null);
            bool leftBlocked2 = (l2 != null);
            bool leftBlocked = leftBlocked1 || leftBlocked2;
            if (!leftBlocked) return true;

            // right
            SodaScreen r1 = (neighBors.Bloom_1) ? neighBors.Bloom_1.HowAgainScreen(Layer, true, true) : null;
            SodaScreen r2 = (neighBors.Bloom_2) ? neighBors.Bloom_2.HowAgainScreen(Layer, true, true) : null;
            bool rightBlocked1 = (r1 != null);
            bool rightBlocked2 = (r2 != null);
            bool rightBlocked = rightBlocked1 || rightBlocked2;
            if (!rightBlocked) return true;

            return false;
        }

        /// <summary>
        /// 判断该格子是否可被匹配（新逻辑，使用缓存阻挡）
        /// </summary>
        public bool IDBoldDyElite()
        {
            // use cached raw blockers
            SodaScreen bl = null;
            //check over blocked
            foreach (var gCell in AlaBrynReactive)
            {
                bl = gCell.HowAgainScreen(Layer + 1, false, true);
                if (bl) return false;
            }

            // check left blocked
            bl = null;
            foreach (var gCell in AlaPackReactive)
            {
                bl = gCell.HowAgainScreen(Layer, false, true);
                if (bl) break;
            }
            if (!bl) return true;

            // check right blocked
            SodaScreen blr = null;
            foreach (var gCell in AlaBloomReactive)
            {
                blr = gCell.HowAgainScreen(Layer, false, true);
                if (blr) break;
            }
            if (!blr) return true;

            return false;
        }

        #region cache raw blockers
        /// <summary>
        /// 获取上方阻挡格子列表
        /// </summary>
        private List<SodaLime> HowBrynReactive()
        {
            ChildDale neighBors = WeaverLime.Practical;

            // 性能优化：复用静态缓存集合，避免重复创建
            RoomReactive.Clear();

            // 性能优化：复用静态缓存GridObject，避免重复创建
            RoomSodaScreen = (neighBors.Book_1) ? neighBors.Book_1.HowAgainScreen(Layer + 1, true, true) : null;
            if (RoomSodaScreen) RoomReactive.Add(RoomSodaScreen.WeaverLime);

            RoomSodaScreen = (neighBors.Book_2) ? neighBors.Book_2.HowAgainScreen(Layer + 1, true, true) : null;
            if (RoomSodaScreen) RoomReactive.Add(RoomSodaScreen.WeaverLime);

            RoomSodaScreen = (neighBors.Book_3) ? neighBors.Book_3.HowAgainScreen(Layer + 1, true, true) : null;
            if (RoomSodaScreen) RoomReactive.Add(RoomSodaScreen.WeaverLime);

            RoomSodaScreen = (neighBors.Book_4) ? neighBors.Book_4.HowAgainScreen(Layer + 1, true, true) : null;
            if (RoomSodaScreen) RoomReactive.Add(RoomSodaScreen.WeaverLime);

            // 返回新列表副本，避免外部修改影响缓存
            return new List<SodaLime>(RoomReactive);
        }

        /// <summary>
        /// 获取左侧阻挡格子列表
        /// </summary>
        private List<SodaLime> HowPackReactive()
        {
            ChildDale neighBors = WeaverLime.Practical;

            // 性能优化：复用静态缓存集合，避免重复创建
            RoomReactive.Clear();

            // 性能优化：复用静态缓存GridObject，避免重复创建
            RoomSodaScreen = (neighBors.Pack_1) ? neighBors.Pack_1.HowAgainScreen(Layer, true, true) : null;
            if (RoomSodaScreen) RoomReactive.Add(RoomSodaScreen.WeaverLime);

            RoomSodaScreen = (neighBors.Pack_2) ? neighBors.Pack_2.HowAgainScreen(Layer, true, true) : null;
            if (RoomSodaScreen) RoomReactive.Add(RoomSodaScreen.WeaverLime);

            // 返回新列表副本，避免外部修改影响缓存
            return new List<SodaLime>(RoomReactive);
        }

        /// <summary>
        /// 获取右侧阻挡格子列表
        /// </summary>
        private List<SodaLime> HowBloomReactive()
        {
            ChildDale neighBors = WeaverLime.Practical;

            // 性能优化：复用静态缓存集合，避免重复创建
            RoomReactive.Clear();

            // 性能优化：复用静态缓存GridObject，避免重复创建
            RoomSodaScreen = (neighBors.Bloom_1) ? neighBors.Bloom_1.HowAgainScreen(Layer, true, true) : null;
            if (RoomSodaScreen) RoomReactive.Add(RoomSodaScreen.WeaverLime);

            RoomSodaScreen = (neighBors.Bloom_2) ? neighBors.Bloom_2.HowAgainScreen(Layer, true, true) : null;
            if (RoomSodaScreen) RoomReactive.Add(RoomSodaScreen.WeaverLime);

            // 返回新列表副本，避免外部修改影响缓存
            return new List<SodaLime>(RoomReactive);
        }

        /// <summary>
        /// 缓存阻挡格子
        /// </summary>
        public void MooseDieReactive()
        {
            AlaBrynReactive = HowBrynReactive();
            AlaPackReactive = HowPackReactive();
            AlaBloomReactive = HowBloomReactive();
        }
        #endregion cache raw blockers

        /// <summary>
        /// 获取左下角阻挡的麻将牌
        /// </summary>
        public AngularTrim HowPorousPackBlocker()
        {
            ChildDale neighBors = WeaverLime.Practical;
            SodaScreen l1 = (neighBors.Pack_1) ? neighBors.Pack_1.HowAgainScreen(Layer, true, true) : null;
            SodaScreen l2 = (neighBors.Pack_2) ? neighBors.Pack_2.HowAgainScreen(Layer, true, true) : null;
            if (l2 && (l1 != l2)) return l2.GetComponent<AngularTrim>();
            return null;
        }

        // 性能优化：静态缓存，避免重复调用GetComponentsInChildren
        private static AngularTrim[] CrayonCramp= null;
        private static int ZoneMooseDiver= -1;

        /// <summary>
        /// 获取指定格子上占用的麻将牌（优化版本，缓存GetComponentsInChildren结果）
        /// </summary>
        /// <param name="matchGrid"></param>
        /// <param name="gridCell"></param>
        /// <returns></returns>
        public static AngularTrim HowNational(EliteSoda matchGrid, SodaLime gridCell)
        {
            // 性能优化：缓存GetComponentsInChildren结果，避免每帧重复调用
            int currentFrame = Time.frameCount;
            if (CrayonCramp == null || currentFrame != ZoneMooseDiver)
            {
                CrayonCramp = matchGrid.Weaver.GetComponentsInChildren<AngularTrim>();
                ZoneMooseDiver = currentFrame;
            }

            // 性能优化：使用for循环替代foreach，减少隐式迭代器分配
            for (int i = 0; i < CrayonCramp.Length; i++)
            {
                var item = CrayonCramp[i];
                if (item != null)
                {
                    List<SodaLime> occupiedCells = item.HowNationalAcorn();
                    if (occupiedCells.Contains(gridCell)) return item;
                }
            }
            return null;
        }

        /// <summary>
        /// 设置排除状态
        /// </summary>
        /// <param name="exclude"></param>
        public void OldOutskirt(bool exclude)
        {
            if (exclude != Outskirt)
            {
                Outskirt = exclude;
            }
        }

        /// <summary>
        /// 高亮提示
        /// </summary>
        public void DeveloperPack(bool highlight)
        {
            if (IrregularlyHint == highlight) return;
            bool useColor = (AvidDismal == null);
            if (useColor)
            {
                if (highlight)
                {
                    //  SWestward.color = new Color(1f, 0.856f, 0.504f);
                    // leftBorder.color = new Color(1f, 0.856f, 0.504f);
                    SWestward.color = new Color(1f, 1f, 1f);
                    GushDuring.color = new Color(1f, 1f, 1f);
                }
                else
                {
                    SWestward.color = new Color(1f, 1f, 1f);
                    GushDuring.color = new Color(1f, 1f, 1f);
                }
            }
            else // use prefab
            {
                if (highlight)
                {
                    if (!AvidScreen)
                    {
                        AvidScreen = Instantiate(AvidDismal, SWestward.transform);
                        AvidScreen.GetComponent<SpriteRenderer>().sortingOrder = HowTypifyEmpty(true) + 2;
                    }
                }
                else
                {
                    GameObject old = AvidScreen;
                    if (old) Destroy(old);
                }
            }
            IrregularlyHint = highlight;
        }

        /// <summary>
        /// 高亮选中
        /// </summary>
        public void DeveloperDerisive(bool highlight)
        {
            if (IrregularlyYew == highlight) return;
            if (!SWestward) return;
            bool useColor = (AvidDismal == null);
            if (useColor)
            {
                if (highlight)
                {
                    //SWestward.color = new Color(1f, 0.856f, 0.504f);
                    //  leftBorder.color = new Color(1f, 0.856f, 0.504f);


                    SWestward.color = new Color(1f, 1f, 1f);
                    GushDuring.color = new Color(1f, 1f, 1f);
                }
                else
                {
                    SWestward.color = new Color(1f, 1f, 1f);
                    GushDuring.color = new Color(1f, 1f, 1f);
                }
            }
            else // use prefab
            {
                if (highlight)
                {
                    if (!EmbodyScreen)
                    {
                        EmbodyScreen = Instantiate(EmbodyDismal, SWestward.transform);
                        HapticPatterns.PlayPreset(HapticPatterns.PresetType.HeavyImpact);
                        EmbodyScreen.GetComponent<SpriteRenderer>().sortingOrder = HowTypifyEmpty(true) + 1;
                    }
                }
                else
                {
                    GameObject old = EmbodyScreen;
                    if (old) Destroy(old);
                }
            }
            IrregularlyYew = highlight;
        }

        /// <summary>
        /// 设置自由高亮颜色
        /// </summary>
        internal void OldBoldMilkweedSouth(bool highLight)
        {
            //SWestward.color = highLight ? Color.white : new Color(0.88f, 0.88f, 0.88f, 1);
            //if (leftBorder) leftBorder.color = highLight ? Color.white : new Color(0.88f, 0.88f, 0.88f, 1);

            SWestward.color = highLight ? Color.white : Color.white;
            if (GushDuring) GushDuring.color = highLight ? Color.white : Color.white;
        }
        // #endregion highlight

        /// <summary>
        /// 判断精灵是否可匹配
        /// </summary>
        public bool CorpseOilEarnerWest(Sprite other)
        {
            return MCorpse == other || GOOld.IDFixSharp(MCorpse, other);
        }

        /// <summary>
        /// 获取渲染顺序
        /// </summary>
        private int HowTypifyEmpty(bool onFront)
        {
            int layerOrder = (onFront) ? 20000 : Layer * 2000;

            int addOrder = (WeaverLime) ? WeaverLime.BatTypifyEmpty : 0;

            if (onFront)
                return FloristEmpty.AngularTrimDyFront + addOrder + layerOrder;
            else
                return FloristEmpty.AngularTrim + addOrder + layerOrder;
        }

        /// <summary>
        /// 启用左边框
        /// </summary>
        private void MormonPackDuring()
        {
            AngularTrim bL = HowPorousPackBlocker();
            if (bL)
            {
                int rO = bL.HowTypifyEmpty(false);
                GushDuring.sortingOrder = rO + 1;
                GushDuring.enabled = true;
            }
            else
            {
                GushDuring.enabled = false;
            }
        }

        /// <summary>
        /// 混合跳跃动画
        /// </summary>
        internal void MixDrab(Vector3 toPosition, Action completeCallBack)
        {
            if (AvidScreen) DeveloperPack(false);
            if (EmbodyScreen) DeveloperDerisive(false);
            AttainRefurbishSynapsis = AttainRefurbish.position;
            MelodyWeigh.Fine(SWestward.gameObject, SWestward.transform.position, toPosition, 0.5f).BatGasolineExpoLash(() =>
            {
                completeCallBack?.Invoke();
            }).OldSilt(EaseAnim.EaseInSine);
        }

        /// <summary>
        /// 反向混合跳跃动画
        /// </summary>
        internal void GentleBedDrab(Action completeCallBack)
        {
            MelodyWeigh.Fine(SWestward.gameObject, SWestward.transform.position, AttainRefurbishSynapsis, 0.5f).BatGasolineExpoLash(() =>
            {
                completeCallBack?.Invoke();
            }).OldSilt(EaseAnim.EaseInSine);
        }

        /// <summary>
        /// 显示编辑器辅助线
        /// </summary>
        public void KnotFreshnessExcel(bool show, float alpha)
        {
            int renderOrder = HowTypifyEmpty(false);
            int renderOrder_L = GushDuring.enabled ? GushDuring.sortingOrder : renderOrder;
            renderOrder = (renderOrder_L > renderOrder) ? renderOrder_L + 2 : renderOrder + 2;

            if (SnowdriftWildBow)
            {
                SnowdriftWildBow.gameObject.SetActive(show);
                SnowdriftWildBow.sortingOrder = renderOrder;
                SnowdriftWildBow.color = new Color(SnowdriftWildBow.color.r, SnowdriftWildBow.color.g, SnowdriftWildBow.color.b, alpha);
            }
            if (SnowdriftWildHomo)
            {
                SnowdriftWildHomo.gameObject.SetActive(show);
                SnowdriftWildHomo.sortingOrder = renderOrder;
                SnowdriftWildHomo.color = new Color(SnowdriftWildBow.color.r, SnowdriftWildBow.color.g, SnowdriftWildBow.color.b, alpha);
            }

            if (SnowdriftAgainPity)
            {
                SnowdriftAgainPity.gameObject.SetActive(show);
                SnowdriftAgainPity.text = (Layer + 1).ToString();
                SnowdriftAgainPity.color = new Color(SnowdriftAgainPity.color.r, SnowdriftAgainPity.color.g, SnowdriftAgainPity.color.b, alpha);
                CorpsePity Pipe= SnowdriftAgainPity.GetComponent<CorpsePity>();
                if (Pipe)
                {
                    Pipe.FloristEmpty = renderOrder;
                }
            }
        }

        /// <summary>
        /// 设置编辑器辅助线颜色
        /// </summary>
        public void OldFreshnessSouth(Color color)
        {
            SWestward.color = color;
            GushDuring.color = color;
        }

        /// <summary>
        /// 抖动动画反馈（先快后慢，幅度逐渐减小，更自然）
        /// </summary>
        public void Bench(float duration = 0.5f, float strength = 0.16f, int vibrato = 10)
        {
            // 第一次Shake时记录原点
            if (CrossMyxomaPot == Vector3.zero)
                CrossMyxomaPot = AttainRefurbish.localPosition;
            // 每次抖动前都归位
            AttainRefurbish.localPosition = CrossMyxomaPot;
            Vector3 originalPos = CrossMyxomaPot;
            int totalSteps = vibrato;
            float totalTime = duration;
            float timePassed = 0f;
            float[] stepTimes = new float[totalSteps];
            float[] stepStrengths = new float[totalSteps];
            float baseTime = totalTime * 0.5f / totalSteps; // 前半段快
            float slowTime = totalTime * 0.5f / totalSteps; // 后半段慢
            float baseStrength = strength;

            // 生成每步的时间和幅度（前快后慢，幅度递减）
            for (int i = 0; i < totalSteps; i++)
            {
                if (i < totalSteps / 2)
                {
                    stepTimes[i] = baseTime;
                    stepStrengths[i] = baseStrength;
                }
                else
                {
                    stepTimes[i] = slowTime * (1.2f + (i - totalSteps / 2) * 0.2f); // 越来越慢
                    stepStrengths[i] = baseStrength * (1f - 0.7f * (i - totalSteps / 2) / (totalSteps / 2)); // 幅度递减
                }
            }
            HapticPatterns.PlayPreset(HapticPatterns.PresetType.HeavyImpact);
            // 启动协程实现分步抖动
            StartCoroutine(BenchIntroduce(AttainRefurbish, originalPos, stepTimes, stepStrengths));
        }

        private IEnumerator BenchIntroduce(Transform target, Vector3 originalPos, float[] stepTimes, float[] stepStrengths)
        {
            for (int i = 0; i < stepTimes.Length; i++)
            {
                float offset = (i % 2 == 0 ? 1 : -1) * stepStrengths[i];
                float t = 0f;
                Vector3 start = CrossMyxomaPot;
                Vector3 end = CrossMyxomaPot + new Vector3(offset, 0, 0);
                while (t < stepTimes[i])
                {
                    t += Time.deltaTime;
                    float lerp = Mathf.Clamp01(t / stepTimes[i]);
                    target.localPosition = Vector3.Lerp(start, end, lerp);
                    yield return null;
                }
                // 回到原位
                target.localPosition = CrossMyxomaPot;
            }
        }

        /// <summary>
        /// 设置金麻将状态，并切换图片，关闭leftBorder
        /// </summary>
        public void OldHallVogue(bool isGold)
        {
            PriestTrim = isGold;
            if (isGold)
            {
                if (LimyCorpse) SWestward.sprite = LimyCorpse;
                if (GushDuring) GushDuring.enabled = false;
                Look_Salinity.gameObject.SetActive(true);
                //GameObject hou_Skeleton = Instantiate(qian_Skeleton, insGoldTrans);
                SkeletonAnimation skeletonAnimation = Look_Salinity.GetComponent<SkeletonAnimation>();

                skeletonAnimation.gameObject.transform.localPosition = new Vector3(-0.3f, -1.68f, 0);
                skeletonAnimation.gameObject.transform.localScale = new Vector3(1f, 0.85f, 0);
                MeshRenderer m_Mr = skeletonAnimation.GetComponent<MeshRenderer>();
                m_Mr.sortingOrder = SWestward.sortingOrder + 1;

                //SkeletonAnimation skeletonAnimation1 = hou_Skeleton.GetComponent<SkeletonAnimation>();
                //skeletonAnimation1.gameObject.transform.localPosition = new Vector3(0, -1.73f, 0);
                //skeletonAnimation1.gameObject.transform.localScale = new Vector3(0.8f, 0.75f, 0);
                //skeletonAnimation1.state.SetAnimation(0, "2", true);
                //MeshRenderer m_Mr1 = skeletonAnimation1.GetComponent<MeshRenderer>();
                //m_Mr1.sortingOrder = SWestward.sortingOrder - 1;
            }
            // 如需恢复普通麻将，可在此处加else逻辑
        }

        /// <summary>
        /// 设置麻将牌变灰或恢复
        /// </summary>
        public void OldGray(bool isGray)
        {
            Color gray = new Color(0.6f, 0.6f, 0.6f, 1f);
            if (isGray)
            {
                if (SWestward) SWestward.color = gray;
                if (GushDuring) GushDuring.color = gray;
            }
            else
            {
                if (SWestward) SWestward.color = Color.white;
                if (GushDuring) GushDuring.color = Color.white;
            }
        }

        // 记录抖动原点，防止多次Shake累计偏移
        private Vector3 CrossMyxomaPot= Vector3.zero;
        public void DeadMental(Action finish)
        {
            Eat.sortingOrder = SWestward.sortingOrder + 1;
            if (AvidScreen)
            {
                Destroy(AvidScreen);
            } // 提示对象
            if (EmbodyScreen)
            {
                Destroy(EmbodyScreen);
            }
            m_TrimGoldModerately.DeadMental(() =>
            {
                finish?.Invoke();
            });
        }

        public void DeadCorpus(Action finish)
        {
            Eat.sortingOrder = SWestward.sortingOrder + 1;
            if (AvidScreen)
            {
                Destroy(AvidScreen);
            } // 提示对象
            if (EmbodyScreen)
            {
                Destroy(EmbodyScreen);
            }
            m_TrimGoldModerately.DeadMental(() =>
            {
                finish?.Invoke();
            });
        }
        public void DeadSpot(Action finish)
        {
            m_TrimGoldModerately.DeadSpot(() =>
            {
                finish?.Invoke();
            });
        }
    }
}
