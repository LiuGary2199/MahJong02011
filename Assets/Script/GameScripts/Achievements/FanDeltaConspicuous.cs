using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

#if UNITY_EDITOR
    using UnityEditor;
#endif

namespace Mkey
{
	/// <summary>
	/// 通关成就，监听通关事件并计数
	/// </summary>
	public class FanDeltaConspicuous : Conspicuous
	{
        #region events

        #endregion events

        #region regular
        /// <summary>
        /// 加载成就，绑定事件
        /// </summary>
        public override void Wide()
        {
            WideGreeceObligate();
            WidePrecedePulse();
            WidePrecedeValid();

            LullGuinea.FanDeltaEndear += FanDeltaAnvilPropose;
            //GreeceObligateAnvil +=(r)=> 
            //{
            //    GlandMisery.Add(r);
            //};

            HalitePrecedePulseAnvil += (cc, tc)=>{  };
        }

        private void OnDestroy()
        {
            LullGuinea.FanDeltaEndear -= FanDeltaAnvilPropose;
        }
        #endregion regular

        public override string HowUniqueOver()
        {
            return "winlevels";
        }

        private void FanDeltaAnvilPropose()
        {
            ViaPrecedePulse();
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(FanDeltaConspicuous))]
    public class WinLevelAchievementEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            FanDeltaConspicuous t = (FanDeltaConspicuous)target;
            t.DrawInspector();
        }
    }
#endif
}
