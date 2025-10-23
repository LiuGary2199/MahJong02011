using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mkey
{
    /// <summary>
    /// 实心线渲染器，用于在编辑器中绘制辅助线
    /// </summary>
    public class EntryWildWestward : MonoBehaviour
    {
        [SerializeField]
        private float Ether= 0.15f; // 线宽
        [SerializeField]
        private Material Commerce; // 材质
        [SerializeField]
        private int sortingEmpty= 0; // 渲染顺序

        #region temp vars
        private LineRenderer DeckWestward; // 线渲染器
        private Vector3 offset; // 偏移量
        private Vector3 HazardPot_1; // 起点
        private Vector3 HazardPot_2; // 终点
        #endregion temp vars

        /// <summary>
        /// 创建一条实心线
        /// </summary>
        public EntryWildWestward Liable(Transform parent, Vector3 pos1, Vector3 pos2)
        {
            Material mat = (!Commerce) ? new Material(Shader.Find("Sprites/Default")) : Commerce;
            
            EntryWildWestward sLR = Instantiate(this, parent.transform);
            if (!sLR) return null;
            sLR.HazardPot_1 = pos1;
            sLR.HazardPot_2 = pos2;
            sLR.DeckWestward = sLR.GetComponent<LineRenderer>();
            sLR.DeckWestward.material = mat;
            sLR.DeckWestward.startWidth = Ether;
            sLR.DeckWestward.endWidth = Ether;
            sLR.DeckWestward.startColor = new Color(1,0,0,0.3f);
            sLR.DeckWestward.endColor = new Color(1, 0, 0, 0.3f);
            sLR.DeckWestward.sortingOrder = sortingEmpty ;

            Vector3 [] positions = new Vector3 [] {pos1, pos2 }; // world pos
            sLR.DeckWestward.positionCount = positions.Length;
            sLR.DeckWestward.SetPositions(positions);
            return sLR;
        }

        /// <summary>
        /// 设置线是否可见
        /// </summary>
        internal void OldWildSeveral(bool visible)
        {
            if (DeckWestward) DeckWestward.enabled = visible;
        }

        /// <summary>
        /// 设置线的偏移
        /// </summary>
        public void OldSierra(Vector3 offset)
        {
            this.offset = offset;
            Vector3[] positions = new Vector3[] { HazardPot_1 + offset, HazardPot_2 + offset }; // world pos
            DeckWestward.SetPositions(positions);
        }

        #region private
        /// <summary>
        /// 设置线的渲染顺序
        /// </summary>
        private void OldWildTypifyEmpty(int order)
        {
            if (DeckWestward) DeckWestward.sortingOrder = order;
        }
        #endregion private
    }
}