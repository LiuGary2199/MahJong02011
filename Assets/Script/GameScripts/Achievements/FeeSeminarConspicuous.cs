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
	/// 使用洗牌成就，监听洗牌事件并计数
	/// </summary>
	public class FeeSeminarConspicuous : Conspicuous
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

            LullGuinea.PreenSeminarEndear += FeeSeminarAnvilPropose;
            HalitePrecedePulseAnvil += (cc, tc)=>{  };
        }

        private void OnDestroy()
        {
            LullGuinea.PreenSeminarEndear -= FeeSeminarAnvilPropose;
        }
        #endregion regular

        /// <summary>
        /// 获取唯一成就名
        /// </summary>
        public override string HowUniqueOver()
        {
            return "useshuffle";
        }

        private void FeeSeminarAnvilPropose()
        {
            ViaPrecedePulse();
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(FeeSeminarConspicuous))]
    public class UseShuffleAchievementEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            FeeSeminarConspicuous t = (FeeSeminarConspicuous)target;
            t.DrawInspector();
        }
    }
#endif
}
