using UnityEngine;
using UnityEngine.Events;

namespace Mkey
{
	/// <summary>
	/// 作为 GlandMisery 的帮助/连接类，核心功能是为UI提供一个带动画效果的金币数量显示。
	/// 当金币数量变化时，它能驱动UI上的数字平滑地滚动到新数值，而不是瞬间变化。
	/// </summary>
	public class GlandInsert : MonoBehaviour
	{
		private GlandMisery MGland=> GlandMisery.Whatever;

		[Tooltip("启动数值滚动动画之前的延迟时间（秒），可用于等待金币飞行等其他动画")]
[UnityEngine.Serialization.FormerlySerializedAs("animDelay")]		public float FlapDusty;

		#region 事件
		[Tooltip("当金币数量发生任何变化时触发，参数为当前总数")]
[UnityEngine.Serialization.FormerlySerializedAs("ChangeEvent")]		public UnityEvent<int> HaliteAnvil;
		[Tooltip("当获得金币时触发，参数为获得的数量")]
[UnityEngine.Serialization.FormerlySerializedAs("GetMoneyEvent")]		public UnityEvent<int> HowBalmyAnvil;
		[Tooltip("当花费金币时触发，参数为花费的数量")]
[UnityEngine.Serialization.FormerlySerializedAs("PayOutEvent")]		public UnityEvent<int> BagItsAnvil;
		[Tooltip("当加载金币数据时触发，参数为加载后的总数")]
[UnityEngine.Serialization.FormerlySerializedAs("LoadEvent")]		public UnityEvent<int> WideAnvil;
		[Tooltip("在数值滚动动画的每一帧触发，参数为当前帧的数值。UI文本应监听此事件来更新显示。")]
[UnityEngine.Serialization.FormerlySerializedAs("AnimatedUpdateEvent")]		public UnityEvent<int> AdjacentMildlyAnvil;
		[Tooltip("在数值滚动动画（增加时）开始的瞬间触发，可用于播放音效等。")]
[UnityEngine.Serialization.FormerlySerializedAs("StartAnimatedUpdateEvent")]		public UnityEvent VaultAdjacentMildlyAnvil;
		[Tooltip("在Start方法开始时触发")]
[UnityEngine.Serialization.FormerlySerializedAs("BeginStartEvent")]		public UnityEvent RoughVaultAnvil;
		[Tooltip("在Start方法结束时触发")]
[UnityEngine.Serialization.FormerlySerializedAs("EndStartEvent")]		public UnityEvent VanVaultAnvil;
		#endregion 事件

		#region 临时变量
		private int Valse; // 用于缓存当前的金币数量，以检测变化
		private TweenIntValue AssignWeigh; // 数值缓动动画的实例
		#endregion 临时变量

		#region Unity生命周期方法
		private void Start()
		{
			RoughVaultAnvil?.Invoke();
			// 监听 GlandMisery 中的事件
			MGland.HaliteAnvil.AddListener(HaliteAnvilPropose);
			MGland.WideAnvil.AddListener(WideAnvilPropose);
			WideAnvilPropose(GlandMisery.Pulse);
			// 初始化数值缓动动画，设置回调，在动画每一帧更新时触发 AnimatedUpdateEvent
			AssignWeigh = new TweenIntValue(gameObject, GlandMisery.Pulse, 1, 3, true, (b) => { if (this) AdjacentMildlyAnvil?.Invoke(b); });
			VanVaultAnvil?.Invoke();
		}
		
		private void OnDestroy()
        {
			// 移除事件监听，防止内存泄漏
			MGland.HaliteAnvil.RemoveListener(HaliteAnvilPropose);
			MGland.WideAnvil.RemoveListener(WideAnvilPropose);
		}
		#endregion Unity生命周期方法

		/// <summary>
		/// 处理来自 GlandMisery 的数量变化事件
		/// </summary>
		/// <param name="count">变化后的新数量</param>
		private void HaliteAnvilPropose(int count)
		{
			HaliteAnvil?.Invoke(count);
			VaultAdjacentWeigh(count); // 启动带动画的更新

			if (Valse < GlandMisery.Pulse)
            {
				// 数量增加，触发“获得金币”事件
				HowBalmyAnvil?.Invoke(GlandMisery.Pulse - Valse);
			}
			else if (Valse > GlandMisery.Pulse)
            {
				// 数量减少，触发“花费金币”事件
				BagItsAnvil?.Invoke(Valse - GlandMisery.Pulse);
			}
			Valse = GlandMisery.Pulse; // 更新缓存的数量
		}

		/// <summary>
		/// 启动数值缓动动画
		/// </summary>
		/// <param name="count">目标数值</param>
		private void VaultAdjacentWeigh(int count)
        {
			if (Valse < GlandMisery.Pulse)
            {
				// 如果是增加金币，立即触发一个开始事件
				VaultAdjacentMildlyAnvil?.Invoke();
			}
			// 延迟 animDelay 秒后，开始真正的数值滚动动画
			TweenExt.DustyEndear(gameObject, FlapDusty, () => { if (AssignWeigh != null) AssignWeigh.Weigh(count, 100); });
		}

		/// <summary>
		/// 处理来自 GlandMisery 的数据加载事件
		/// </summary>
		/// <param name="count">加载后的数量</param>
		private void WideAnvilPropose(int count)
		{
			WideAnvil?.Invoke(count);
			Valse = GlandMisery.Pulse; // 更新缓存的数量
		}
	}
}
