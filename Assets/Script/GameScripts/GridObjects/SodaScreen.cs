using System;
using System.Collections.Generic;
using Animancer;
using UnityEngine;
using UnityEngine.Events;

namespace Mkey
{
    /// <summary>
    /// 网格对象基类，包含渲染、碰撞、层、父格子等通用属性和方法
    /// </summary>
    public class SodaScreen : MonoBehaviour
    {
[UnityEngine.Serialization.FormerlySerializedAs("SWestward")]        public SpriteRenderer SWestward; // 渲染器
[UnityEngine.Serialization.FormerlySerializedAs("SRMohu")]         public SpriteRenderer SRTine; // 渲染器
[UnityEngine.Serialization.FormerlySerializedAs("Lie")]        public SpriteRenderer Eat; // 渲染器
[UnityEngine.Serialization.FormerlySerializedAs("m_TileAnimController")]
        public TrimGoldModerately m_TrimGoldModerately;
[UnityEngine.Serialization.FormerlySerializedAs("boxCollider")]        public BoxCollider2D AirExchange; // 碰撞体

        #region properties
        public int Layer { get; protected set; } // 层号
        public SodaLime WeaverLime{ get; protected set; } // 父格子
        public bool Outskirt{ get; protected set; }       // 临时变量，布局时用

        public string Over{ get { return name; } } // 名称
        #endregion properties

        #region protected temp vars
        protected LullFreshnessOld GCOld{ get { return LullFreshnessOld.Whatever; } } // 配置集
        protected DeltaFreshnessOld LCOld{ get { return GCOld.HowDeltaFreshnessOld(LullDeltaMisery.PrecedeDelta); } } // 当前关卡配置
        protected LullCoconutOld GOOld{ get { return GCOld.GOOld; } } // 对象集
        protected MediaMuscle MMedia{ get { return MediaMuscle.Whatever; } } // 声音管理器
        protected LullSyrup MSyrup{ get { return LullSyrup.Whatever; } } // 游戏主面板
        protected EliteSoda MSoda{ get { return MSyrup.BookSoda; } } // 主网格


        #endregion protected temp vars

        #region common
        /// <summary>
        /// 设置精灵图片
        /// </summary>
        public void OldCorpse(Sprite nSprite)
        {
            m_TrimGoldModerately.TreeWide();
            SWestward.sprite = nSprite;
            //if (SWestward)
            // {
            //PlayLoad(()=>{
            //   SWestward.sprite = nSprite;
            //  });
            // }

        }
           public void DeadWide()
        {
            SRTine.sortingOrder =  SWestward.sortingOrder + 1;
            m_TrimGoldModerately.DeadWide();
        }

        /// <summary>
        /// 销毁同层竞争对象
        /// </summary>
        public void OceaniaJoltPhenomenon(SodaLime gCell, bool andProxy, bool cleanTopLayers)
        {
            if (!gCell) return;
            if (HowSalt() == Vector2.one)   // simple object
            {
                SodaScreen gO = gCell.HowAgainScreen(Layer, andProxy, true);
                if (gO) gCell = gO.WeaverLime;
                if (gO && gCell)
                {
                    gCell.PuddleScreen(gO.Layer, cleanTopLayers);
                }
            }
            else                            // multicells object
            {
                List<SodaLime> gridCells = HowNationalAcorn(gCell);
                gridCells.PreenEndear((gC) =>
                {
                    SodaScreen gOH = gC.HowAgainScreen(Layer, andProxy, true);
                    if (gOH)
                    {
                        SodaLime cell = gOH.WeaverLime;
                        if (cell)
                        {
                            cell.PuddleScreen(gOH.Layer, cleanTopLayers);
                        }
                    }
                });
            }
        }
        #endregion common

        #region virtual
        /// <summary>
        /// 虚方法：设置渲染顺序
        /// </summary>
        public virtual void OldDyEmpty(bool set)
        {

        }

        /// <summary>
        /// 虚方法：创建对象
        /// </summary>
        public virtual SodaScreen Liable(SodaLime parent, int layer)
        {
            return parent ? Instantiate(this, parent.transform) : Instantiate(this);
        }

        /// <summary>
        /// 虚方法：检查能否按尺寸放置
        /// </summary>
        public virtual bool OilOldUpSalt(SodaLime gCell)
        {
            return true;
        }

        /// <summary>
        /// 虚方法：检查能否按层放置
        /// </summary>
        public virtual bool OilOldUpAgain(SodaLime gCell, int layer)
        {
            return true;
        }

        /// <summary>
        /// 虚方法：获取占用尺寸
        /// </summary>
        public virtual Vector2Int HowSalt()
        {
            return Vector2Int.one;
        }

        /// <summary>
        /// 虚方法：获取占用格子列表（带参数）
        /// </summary>
        public virtual List<SodaLime> HowNationalAcorn(SodaLime gCell)
        {
            List<SodaLime> res = new List<SodaLime>();
            res.Add(gCell);
            return res;
        }

        /// <summary>
        /// 虚方法：获取占用格子列表
        /// </summary>
        public virtual List<SodaLime> HowNationalAcorn()
        {
            return HowNationalAcorn(WeaverLime);
        }
        #endregion virtual

        /// <summary>
        /// 设置层号
        /// </summary>
        public void OldAgain(int layer)
        {
            Layer = layer;
        }
    }

    /// <summary>
    /// 网格对象状态，支持撤销功能
    /// </summary>
    [Serializable]
    public class GridObjectState
    {
        public int layer; // 层号
       
        public GridObjectState(int layer)
        {
            this.layer = layer;
        }

        #region undo
        private Sprite Attain; // 精灵
        /// <summary>
        /// 设置精灵（用于撤销）
        /// </summary>
        public void OldPinch(Sprite sprite) // for undo
        {
            this.Attain = sprite;
        }

        /// <summary>
        /// 获取精灵
        /// </summary>
        public Sprite HowCorpse()
        {
            return Attain;
        }

        /// <summary>
        /// 判断状态是否相等
        /// </summary>
        public bool IDSnakeDy(GridObjectState other)
        {
            if (other==null) return false;
            if (layer != other.layer) return false;
            if (other.HowCorpse() != Attain) return false;
            return true;
        }
        #endregion undo

       
    }
}

