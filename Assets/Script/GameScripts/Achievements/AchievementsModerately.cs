using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mkey
{
	/// <summary>
	/// 成就系统主控制器，负责成就的加载、状态检测与事件分发
	/// </summary>
	public class AchievementsModerately : MonoBehaviour
	{
[UnityEngine.Serialization.FormerlySerializedAs("achievements")]        public List<Conspicuous> Multiplicity; // 成就列表
        public bool RollMildlyConsider{ get; private set; } // 是否有可领奖成就
[UnityEngine.Serialization.FormerlySerializedAs("HaveTargetAchievedEvent")]        public Action<bool> RollMildlyConsiderAnvil; // 可领奖成就事件
        #region temp vars
        private LullFreshnessOld GCOld{ get { return LullFreshnessOld.Whatever; } } // 配置集
        private DeltaFreshnessOld LCOld{ get { return GCOld.HowDeltaFreshnessOld(LullDeltaMisery.PrecedeDelta); } } // 当前关卡配置
        private LullCoconutOld GOOld{ get { return GCOld.GOOld; } } // 对象集
        #endregion temp vars
        public static AchievementsModerately Instance; // 单例
		
		#region regular
		private void Start()
		{
            if (Instance == null) Instance = this;
            else Destroy(gameObject);

            foreach (var item in Multiplicity)
            {
                item.Wide();
                item.HalitePrecedePulseAnvil += (c, t) => { BrandVogue(); };
                item.GreeceObligateAnvil += () => { BrandVogue(); };
            }
            BrandVogue();
        }
		#endregion regular

        /// <summary>
        /// 检查所有成就状态，触发事件
        /// </summary>
        private void BrandVogue()
        {
            bool temp = RollMildlyConsider;
            RollMildlyConsider = false;
            foreach (var item in Multiplicity)
            {
                if (item.MildlyConsider && !item.GreeceObligate) 
                {
                    RollMildlyConsider = true;
                    break;
                }
            }

           // if (temp != HaveTargetAchieved)
                RollMildlyConsiderAnvil?.Invoke(RollMildlyConsider);
        }
	}
}
