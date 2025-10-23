using UnityEngine;
using UnityEngine.Events;

namespace Mkey
{
	/// <summary>
	/// 处理"重排"道具（Seminar）相关逻辑的帮助类
	/// 它连接了ShuffleHolder（数据层）和游戏UI/逻辑层
	/// </summary>
	public class SeminarInsert : MonoBehaviour
	{
		[Tooltip("当玩家没有重排道具时，点击按钮弹出的'免费获取'窗口")]
[UnityEngine.Serialization.FormerlySerializedAs("getFreePU")]		public LotIllModerately EndBoldPU;
		private SeminarMisery MUsefully=> SeminarMisery.Whatever;
		private RatModerately MRat=> RatModerately.Instance;

		#region 事件
		[Header("Events")]
		[Tooltip("当成功使用重排道具时触发")]
[UnityEngine.Serialization.FormerlySerializedAs("ApplyShuffleEvent")]		public UnityEvent PreenSeminarAnvil;
		[Tooltip("当重排道具数量发生任何变化时触发，参数为当前总数")]
[UnityEngine.Serialization.FormerlySerializedAs("ChangeEvent")]		public UnityEvent<int> HaliteAnvil;
		[Tooltip("当获得新的重排道具时触发，参数为获得的数量")]
[UnityEngine.Serialization.FormerlySerializedAs("GetShufflesEvent")]		public UnityEvent<int> HowUsefullyAnvil;
		[Tooltip("当消耗重排道具时触发，参数为消耗的数量")]
[UnityEngine.Serialization.FormerlySerializedAs("ConsumptionShufflesEvent")]		public UnityEvent<int> IndependentUsefullyAnvil;
		[Tooltip("当加载重排道具数据时触发，参数为加载后的总数")]
[UnityEngine.Serialization.FormerlySerializedAs("LoadEvent")]		public UnityEvent<int> WideAnvil;
		[Tooltip("在Start方法开始时触发")]
[UnityEngine.Serialization.FormerlySerializedAs("BeginStartEvent")]		public UnityEvent RoughVaultAnvil;
		[Tooltip("在Start方法结束时触发")]
[UnityEngine.Serialization.FormerlySerializedAs("EndStartEvent")]		public UnityEvent VanVaultAnvil;
[UnityEngine.Serialization.FormerlySerializedAs("SeminarMisery")]		public SeminarMisery SeminarMisery;
		#endregion 事件

		#region 临时变量
		private int Stocking; // 用于缓存当前的重排道具数量，以检测变化
		#endregion 临时变量

		#region Unity生命周期方法
		private void Start()
		{
			RoughVaultAnvil?.Invoke();
			// 监听 SeminarMisery 中的事件
			MUsefully.HaliteAnvil.AddListener(HaliteAnvilPropose);
			MUsefully.WideAnvil.AddListener(WideAnvilPropose);
			// 手动调用一次Load，以初始化显示
			WideAnvilPropose(SeminarMisery.Pulse);
			VanVaultAnvil?.Invoke();
		}

		private void OnDestroy()
		{
			// 移除事件监听，防止内存泄漏
			MUsefully.HaliteAnvil.RemoveListener(HaliteAnvilPropose);
			MUsefully.WideAnvil.RemoveListener(WideAnvilPropose);
		}
		#endregion Unity生命周期方法

		/// <summary>
		/// 处理来自 SeminarMisery 的数量变化事件
		/// </summary>
		/// <param name="count">变化后的新数量</param>
		private void HaliteAnvilPropose(int count)
		{
			HaliteAnvil?.Invoke(count);

			if (Stocking < SeminarMisery.Pulse)
			{
				// 数量增加，触发"获得"事件
				HowUsefullyAnvil?.Invoke(SeminarMisery.Pulse - Stocking);
			}
			else if (Stocking > SeminarMisery.Pulse)
			{
				// 数量减少，触发"消耗"事件
				IndependentUsefullyAnvil?.Invoke(Stocking - SeminarMisery.Pulse);
			}
			Stocking = SeminarMisery.Pulse; // 更新缓存的数量
		}

		/// <summary>
		/// 处理来自 SeminarMisery 的数据加载事件
		/// </summary>
		/// <param name="count">加载后的数量</param>
		private void WideAnvilPropose(int count)
		{
			WideAnvil?.Invoke(count);
			Stocking = SeminarMisery.Pulse; // 更新缓存的数量
		}

		/// <summary>
		/// 当玩家点击"重排"按钮时调用此方法
		/// </summary>
		public void Seminar_Stuff()
		{/*
            if (shuffles > 0)
			{
				// 如果还有重排道具
				LullSyrup.Instance.ShuffleGrid(null); // 执行棋盘重排逻辑
				SeminarMisery.Add(-1); // 减少一个重排道具
				ApplyShuffleEvent?.Invoke(); // 触发"成功使用"事件
				LullGuinea.ApplyShuffleAction?.Invoke();
			}
            else
            {
				ADEvening.Instance.playRewardVideo((success) =>
				{
					if (success)
					 {
						SeminarMisery.Add(1);
                    }
                }, "101");
				
				// 如果没有重排道具，显示"免费获取"弹窗
				//if (getFreePU) MGui.ShowPopUp(getFreePU);
			}
			*/
			ADEvening.Whatever.TillGreeceSugar((success) =>
				{
					if (success)
					{
						SpitAnvilPawnee.HowWhatever().HeroAnvil("1006");
						LullSyrup.Whatever.SeminarSoda(null); // 执行棋盘重排逻辑
						PreenSeminarAnvil?.Invoke(); // 触发"成功使用"事件
						LullGuinea.PreenSeminarEndear?.Invoke();
					}
				}, "3");
		}
	}
}
