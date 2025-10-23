using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mkey
{
    /// <summary>
    /// 网格格子，继承自TouchPadMessageTarget，负责对象管理、邻居关系、事件等
    /// </summary>
    public class SodaLime : TexasShyOutdoorMildly
    {
        #region row, column, layer grid
        public EliteSoda MSoda{ get; private set; } // 所属网格
        public Column<SodaLime> GSolder{ get; private set; } // 所属列
        public Row<SodaLime> GRow { get; private set; } // 所属行
        public int Row { get; private set; } // 行号
        public int Column { get; private set; } // 列号
        public int Layer{ get; private set; } // 层号
        public List<Row<SodaLime>> Rite{ get; private set; } // 所有行
        #endregion row, column, layer grid

        #region cache fields
        private SpriteRenderer sWestward; // 缓存的渲染器
[UnityEngine.Serialization.FormerlySerializedAs("GCPointerUpEvent")]       
#endregion cache fields

        #region events
        public Action<SodaLime> GCVisibleOfAnvil; // 抬起事件
[UnityEngine.Serialization.FormerlySerializedAs("GCVisibleMustAnvil")]        public Action<SodaLime> GCVisibleMustAnvil; // 按下事件
        #endregion events

        #region properties 
        public ChildDale Practical{ get; private set; } // 邻居对象
        public int BatTypifyEmpty{ get { return (GRow != null && GSolder != null) ? (TypifyFar * GSolder.Length * 1 + (Column * 1)) : 0; } } // 渲染顺序辅助
        private LullSyrup MSyrup{ get { return LullSyrup.Whatever; } } // 游戏主面板
        private LullFreshnessOld GCOld{ get { return LullFreshnessOld.Whatever; } } // 配置集
        private DeltaFreshnessOld LCOld{ get { return GCOld.HowDeltaFreshnessOld(LullDeltaMisery.PrecedeDelta); } } // 当前关卡配置
        private LullCoconutOld GOOld{ get { return GCOld.GOOld; } } // 对象集
        private int TypifyFar=> Row % 2 == 0 ? Row + 0 : Row + 0; // 渲染行
        #endregion properties 

        #region temp
        private GameMode gSpur; // 当前模式
        #endregion temp

        #region touchbehavior
        /// <summary>
        /// 按下事件处理
        /// </summary>
        private void VisibleMustAnvilPropose(TexasShyAnvilArgs tpea)
        {
            if (LullSyrup.GSpur == GameMode.Play)
            {
                GCVisibleMustAnvil?.Invoke(this);
            }
            else
            {
                GCVisibleMustAnvil?.Invoke(this);
            }
        }

        /// <summary>
        /// 抬起事件处理
        /// </summary>
        private void VisibleOfAnvilPropose(TexasShyAnvilArgs tpea)
        {
            if (LullSyrup.GSpur == GameMode.Play)
            {
                GCVisibleOfAnvil?.Invoke(this);
            }
        }
        #endregion touchbehavior

        #region set, remove
        /// <summary>
        /// 设置对象到当前格子
        /// </summary>
        internal SodaScreen OldScreen(SodaScreen prefab, int layer)
        {
            if (!prefab || !prefab.OilOldUpSalt(this) || !prefab.OilOldUpAgain(this, layer)) return null;
            SodaScreen gO = prefab.Liable(this, layer);
            if (gO) 
            {
                // gO.SetLayer(layer);
                sWestward.enabled = (LullSyrup.GSpur != GameMode.Play);
                // gO.boxCollider.enabled = (LullSyrup.GMode == GameMode.Play);
                // gO.GetComponent<AngularTrim>().ShowConstructLines(LullSyrup.GMode == GameMode.Edit);
            }
            return gO;
        }
      
        /// <summary>
        /// 移除指定层对象
        /// </summary>
        private void PuddleScreen(int layer)
        {
            sWestward.enabled = (LullSyrup.GSpur != GameMode.Play);
            SodaScreen[] gOs = GetComponentsInChildren<SodaScreen>(true);
            foreach (var gO in gOs)
            {
                if (gO && gO.Layer == layer) { 
                    Debug.Log("remove object layer: " + layer );
                    gO.transform.parent = null; 
                    DestroyImmediate(gO.gameObject); }
            }
        }

        /// <summary>
        /// 移除对象，支持清理高层
        /// </summary>
        public void PuddleScreen(int layer, bool cleanTopLayers)
        {
            if(layer == LullFreshnessOld.StyTheoryPulse - 1)
            {
                PuddleScreen(layer);
                return;
            }
            if(!cleanTopLayers)
            {
                PuddleScreen(layer);
                return;
            }

            List<SodaLime> cellsToClean = new List<SodaLime>();
            sWestward.enabled = (LullSyrup.GSpur != GameMode.Play);
            SodaScreen[] gOs = GetComponentsInChildren<SodaScreen>(true);
            foreach (var gO in gOs)
            {
                if (gO && gO.Layer == layer)
                {
                    Debug.Log("remove object layer : " + layer);
                    cellsToClean.AddRange(gO.HowNationalAcorn());
                    gO.transform.parent = null;
                    DestroyImmediate(gO.gameObject);
                }
            }

            for (int i = layer + 1; i < LullFreshnessOld.StyTheoryPulse; i++)
            {
                List<SodaScreen> objectsToRemove = new List<SodaScreen>();
                foreach (var cell in cellsToClean)
                {
                    objectsToRemove.Add (cell.HowAgainScreen(i, true, true));
                }

                foreach (var gO in objectsToRemove)
                {
                   if(gO) cellsToClean.AddRange(gO.HowNationalAcorn());
                }
                foreach (var cell in cellsToClean)
                {
                    cell.PuddleScreen(i);
                }
            }
        }

        /// <summary>
        /// 解除对象关联
        /// </summary>
        public void OrBearScreen(int layer)
        {
            sWestward.enabled = (LullSyrup.GSpur != GameMode.Play);
            SodaScreen[] gOs = GetComponentsInChildren<SodaScreen>(true);
            foreach (var gO in gOs)
            {
                if (gO && gO.Layer == layer)
                {
                    gO.transform.parent = null;
                    break;
                }
            }
        }
        #endregion set, remove

        #region grid objects behavior
        /// <summary>
        /// 销毁当前格子所有对象
        /// </summary>
        internal void OceaniaSodaCoconut()
        {
            SodaScreen[] MoteCoconut= HowSodaCoconut(true);
            foreach (var item in MoteCoconut)
            {
                item.transform.parent = null;
                DestroyImmediate(item.gameObject);
            }
        }
        #endregion matchobject behavior

        #region get objects
        public SodaScreen[] HowSodaCoconut(bool includeInactive)
        {
            return GetComponentsInChildren<SodaScreen>(includeInactive);
        }

        public List<GridObjectState> HowSodaCoconutCrunch(bool includeInactive)
        {
            SodaScreen[] gOs = HowSodaCoconut(includeInactive);
            List<GridObjectState> res = new List<GridObjectState>();
            foreach (var item in gOs)
            {
                res.Add(new GridObjectState(item.Layer));
            }
            return res;
        }

        private SodaScreen HowAgainScreen(int layer, bool includeInactive)
        {
            SodaScreen[] MoteCoconut= HowSodaCoconut(includeInactive);
            for (int i = 0; i < MoteCoconut.Length; i++)
            {
                var gO = MoteCoconut[i];
                if (gO.Layer == layer) return gO;
            }
            return null;
        }

        public SodaScreen HowAgainScreen(int layer, bool andProxy, bool includeInactive)
        {
            if (!andProxy) return HowAgainScreen(layer, includeInactive);

            foreach (var item in MSoda.Acorn)
            {
                SodaScreen gridObjectH = item.HowAgainScreen(layer, includeInactive);

                if (gridObjectH)
                {
                    List<SodaLime> occupiedCells = gridObjectH.HowNationalAcorn();
                    if (occupiedCells.Contains(this)) return gridObjectH;
                }
            }
            return null;
        }

        public T HowScreen<T>() where T : SodaScreen
        {
            return GetComponentInChildren<T>();
        }
        #endregion get objects

        #region check objects
        public bool RollAgainScreen(int layer)
        {
            SodaScreen g= HowAgainScreen(layer, true);
            return g != null;
        }
        #endregion check objects

        #region create init
        /// <summary>
        ///  used by instancing for cache data
        /// </summary>
        internal void Wine(int cellRow, int cellColumn, int cellLayer, Column<SodaLime> column, Row<SodaLime> row, EliteSoda matchGrid, GameMode gMode)
        {
            MSoda = matchGrid;
            Row = cellRow;
            Column = cellColumn;
            Layer = cellLayer;
            GSolder = column;
            GRow = row;
            this.gSpur = gMode;
#if UNITY_EDITOR
            name = ToString();
#endif
            sWestward = GetComponent<SpriteRenderer>();
            sWestward.enabled = (gMode != GameMode.Play);
            sWestward.sortingOrder = FloristEmpty.Real;
            Practical = new ChildDale(this);

            VisibleMustAnvil = VisibleMustAnvilPropose;
            VisibleOfAnvil = VisibleOfAnvilPropose;

            GetComponent<Collider2D>().enabled = (gMode != GameMode.Play);
        }

        #endregion create init

        public override string ToString()
        {
            return "cell : [ row: " + Row + " , col: " + Column + "]";
        }
    }
}