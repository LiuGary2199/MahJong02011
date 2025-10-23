using UnityEngine;
using UnityEngine.Events;

namespace Mkey
{
	/// <summary>
	/// 处理"提示"道具（Hint）相关逻辑的帮助类。
	/// 它连接了HintHolder（数据层）和游戏UI/逻辑层。
	/// </summary>
	public class PackInsert : MonoBehaviour
	{
		[Tooltip("当玩家没有提示道具时，点击按钮弹出的'免费获取'窗口")]
[UnityEngine.Serialization.FormerlySerializedAs("getFreePU")]		public LotIllModerately EndBoldPU;

		private PackMisery MElect=> PackMisery.Whatever;
		private RatModerately MRat=> RatModerately.Instance;

		#region 事件
		[Header("Events")]
		[Tooltip("当成功使用提示道具时触发")]
[UnityEngine.Serialization.FormerlySerializedAs("ApplyHintEvent")]		public UnityEvent PreenPackAnvil;
		[Tooltip("当提示道具数量发生任何变化时触发，参数为当前总数")]
[UnityEngine.Serialization.FormerlySerializedAs("ChangeEvent")]		public UnityEvent<int> HaliteAnvil;
		[Tooltip("当获得新的提示道具时触发，参数为获得的数量")]
[UnityEngine.Serialization.FormerlySerializedAs("GetHintsEvent")]		public UnityEvent<int> HowElectAnvil;
		[Tooltip("当消耗提示道具时触发，参数为消耗的数量")]
[UnityEngine.Serialization.FormerlySerializedAs("ConsumptionHintsEvent")]		public UnityEvent<int> IndependentElectAnvil;
		[Tooltip("当加载提示道具数据时触发，参数为加载后的总数")]
[UnityEngine.Serialization.FormerlySerializedAs("LoadEvent")]		public UnityEvent<int> WideAnvil;
		[Tooltip("在Start方法开始时触发")]
[UnityEngine.Serialization.FormerlySerializedAs("BeginStartEvent")]		public UnityEvent RoughVaultAnvil;
		[Tooltip("在Start方法结束时触发")]
[UnityEngine.Serialization.FormerlySerializedAs("EndStartEvent")]		public UnityEvent VanVaultAnvil;
[UnityEngine.Serialization.FormerlySerializedAs("PackMisery")]

		public PackMisery PackMisery;
		#endregion 事件

		#region 临时变量
		private int Scent; // 用于缓存当前的提示道具数量，以检测变化
		#endregion 临时变量

		#region Unity生命周期方法
		private void Start()
		{
			RoughVaultAnvil?.Invoke();
			// 监听 PackMisery 中的事件
			MElect.HaliteAnvil.AddListener(HaliteAnvilPropose);
			MElect.WideAnvil.AddListener(WideAnvilPropose);
			// 手动调用一次Load，以初始化显示
			WideAnvilPropose(PackMisery.Pulse);
			VanVaultAnvil?.Invoke();
		}

		private void OnDestroy()
		{
			// 移除事件监听，防止内存泄漏
			MElect.HaliteAnvil.RemoveListener(HaliteAnvilPropose);
			MElect.WideAnvil.RemoveListener(WideAnvilPropose);
		}
		#endregion Unity生命周期方法

		/// <summary>
		/// 处理来自 PackMisery 的数量变化事件
		/// </summary>
		/// <param name="count">变化后的新数量</param>
		private void HaliteAnvilPropose(int count)
		{
			HaliteAnvil?.Invoke(count);

			if (Scent < PackMisery.Pulse)
			{
				// 数量增加，触发"获得"事件
				HowElectAnvil?.Invoke(PackMisery.Pulse - Scent);
			}
			else if (Scent > PackMisery.Pulse)
			{
				// 数量减少，触发"消耗"事件
				IndependentElectAnvil?.Invoke(Scent - PackMisery.Pulse);
			}
			Scent = PackMisery.Pulse; // 更新缓存的数量
		}

		/// <summary>
		/// 处理来自 PackMisery 的数据加载事件
		/// </summary>
		/// <param name="count">加载后的数量</param>
		private void WideAnvilPropose(int count)
		{
			WideAnvil?.Invoke(count);
			Scent = PackMisery.Pulse; // 更新缓存的数量
		}

		/// <summary>
		/// 当玩家点击"提示"按钮时调用此方法
		/// </summary>
		public void Eleven_Pack()
		{
			// 检查棋盘上是否已经显示了提示
			if (LullSyrup.Whatever.IDFoundryPack())
			{
				UIEvening.HowWhatever().KnotUITruth(nameof(Allay), "already been selected");
				//RatModerately.Instance.ShowMessage("", "已经有匹配的牌被选中了", 2, null);
				return;
			}
			ADEvening.Whatever.TillGreeceSugar((success) =>
			{
				if (success)
				{
					LullSyrup.Whatever.EatElevenPackElite((good) =>
					{
						//if (good) PackMisery.Add(-1);
					});
					SpitAnvilPawnee.HowWhatever().HeroAnvil("1005");
					PreenPackAnvil?.Invoke(); // 触发"成功使用"事件
					LullGuinea.PreenPackEndear?.Invoke();
				}
			}, "4");

			/*
			if (hints > 0)
			{
				// 尝试在棋盘上选择并高亮一对可消除的牌
				// 只有在成功找到并显示提示后（回调函数中的good为true），才消耗一个提示道具
				LullSyrup.Instance.TrySelectHintMatch((good) => { if (good) PackMisery.Add(-1); });
				ApplyHintEvent?.Invoke(); // 触发"成功使用"事件
				LullGuinea.ApplyHintAction?.Invoke();
			}
			else
			{
				ADEvening.Instance.playRewardVideo((success) =>
				{
					if (success)
					{
						PackMisery.Add(1);
					}
				}, "101");
				// 如果没有提示道具，显示"免费获取"弹窗 新逻辑  直接加

				//if (getFreePU) MGui.ShowPopUp(getFreePU);
			}*/
		}
	}
}
