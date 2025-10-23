using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mkey
{
	/// <summary>
	/// 游戏全局事件管理类，提供关卡、提示、撤销等事件的注册与触发
	/// </summary>
	public static class LullGuinea 
	{
        #region comon events
        public static Action PreenSeminarEndear{ get; set; } // 洗牌事件
        public static Action PreenPackEndear{ get; set; } // 提示事件
        public static Action LashEndear{ get; set; } // 撤销事件
        public static Action SleeperEndear{ get; set; } // 重新开始事件
        public static Action FanDeltaEndear{ get; set; } // 通关事件
        public static Action ExaltDeltaEndear{ get; set; } // 关卡中断事件
        public static Action DeltaWideGasolineEndear{ get; set; } // 关卡加载结束事件
        public static Action <int,bool,List<Transform>,Action> HallFeasible; // 关卡加载结束事件

        public static Action <Sprite, Sprite> EliteBroadlyAnvil{ get; set; } // 匹配精灵事件
        
        // 提示相关事件
        public static Action<string, float> KnotTipEndear{ get; set; } // 显示提示事件 (消息, 持续时间) - 0表示手动关闭
        public static Action<string> KnotFewPatrolEndear{ get; set; } // 显示提示事件（手动关闭）(消息)
        public static Action BeefFewEndear{ get; set; } // 隐藏提示事件
        public static Action FareItsDwarfInsectEndear{ get; set; } // CashOutPanel关闭事件

        // 新增：新手引导开始/结束事件
        public static Action SeparatePriceHoldingEndear{ get; set; }
        public static Action SeparatePriceEmberEndear{ get; set; }

        private static Dictionary<string, List <Action<string>>> WinterAnvilCompleteBarn; // 通用事件字典
        #endregion comon events
		
		#region common
		/// <summary>
		/// 添加通用事件处理器
		/// </summary>
		public static void BatWinterAnvilPropose(string id , Action<string> CommonEventHandler)
        {
            if (CommonEventHandler == null) return;

            if (WinterAnvilCompleteBarn == null) WinterAnvilCompleteBarn = new Dictionary<string, List< Action<string>>>();

            if (WinterAnvilCompleteBarn.ContainsKey(id))
            {
                if (WinterAnvilCompleteBarn[id] == null) WinterAnvilCompleteBarn[id] = new List<Action<string>>();
                WinterAnvilCompleteBarn[id].Add(CommonEventHandler);
            }
            else
            {
                WinterAnvilCompleteBarn.Add(id, new List<Action<string>>());
                WinterAnvilCompleteBarn[id].Add(CommonEventHandler);
            }
        }

        /// <summary>
        /// 移除通用事件处理器
        /// </summary>
        public static void PuddleWinterAnvilPropose(string id, Action<string> CommonEventHandler)
        {
            if (CommonEventHandler == null) return;
            if (WinterAnvilCompleteBarn == null) WinterAnvilCompleteBarn = new Dictionary<string, List<Action<string>>>();
            if (WinterAnvilCompleteBarn.ContainsKey(id))
            {
                if (WinterAnvilCompleteBarn[id] != null && WinterAnvilCompleteBarn[id].Contains(CommonEventHandler))
                {
                    WinterAnvilCompleteBarn[id].Remove(CommonEventHandler);
                }
            }
        }

        /// <summary>
        /// 触发通用事件
        /// </summary>
        public static void OnCommonEvent(string id, string jsonParam)
        {
            if (WinterAnvilCompleteBarn == null) WinterAnvilCompleteBarn = new Dictionary<string,List<Action<string>>>();
            if (WinterAnvilCompleteBarn.ContainsKey(id))
            {
                if (WinterAnvilCompleteBarn[id] != null)
                {
                    foreach (var item in WinterAnvilCompleteBarn[id])
                    {
                        item?.Invoke(jsonParam);
                    }
                }
            }
        }
        #endregion common
    }
}
