using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Mkey
{
	/// <summary>
	/// 作为 LullDeltaMisery 的帮助/连接类。
	/// 它监听来自 LullDeltaMisery 的C#事件，并将其转发为可在Unity编辑器中配置的 UnityEvents。
	/// 这使得UI元素等其他MonoBehaviour可以方便地响应关卡数据的变化，而无需直接与GameLevelHolder耦合。
	/// </summary>
	public class LullDeltaInsert : MonoBehaviour
	{
		private LullDeltaMisery MGDelta=> LullDeltaMisery.Whatever;

		#region 事件
		[Header("Events")]
		[Tooltip("当最高通关关卡数发生变化时触发，参数为新的最高关卡数")]
[UnityEngine.Serialization.FormerlySerializedAs("ChangePassedEvent")]		public UnityEvent<int> HaliteTalbotAnvil;
		[Tooltip("当关卡数据加载时触发，参数为加载的关卡数")]
[UnityEngine.Serialization.FormerlySerializedAs("LoadEvent")]		public UnityEvent<int> WideAnvil;
		[Tooltip("当成功通关时触发，参数为通过的关卡数")]
[UnityEngine.Serialization.FormerlySerializedAs("PassLevelEvent")]		public UnityEvent<int> PlusDeltaAnvil;
		[Tooltip("当开始一个新关卡时触发，参数为开始的关卡数")]
[UnityEngine.Serialization.FormerlySerializedAs("StartLevelEvent")]		public UnityEvent<int> VaultDeltaAnvil;

		[Tooltip("在Start方法开始时触发")]
[UnityEngine.Serialization.FormerlySerializedAs("BeginStartEvent")]		public UnityEvent RoughVaultAnvil;
		[Tooltip("在Start方法结束时触发")]
[UnityEngine.Serialization.FormerlySerializedAs("EndStartEvent")]		public UnityEvent VanVaultAnvil;

		[Tooltip("当需要更新界面显示的关卡编号时触发。参数通常是 number + 1，因为关卡编号在代码中从0开始，在UI中从1开始。")]
[UnityEngine.Serialization.FormerlySerializedAs("UpdateGuiLevelNumberEvent")]		public UnityEvent<int> MildlyRatDeltaGallopAnvil;


		public Text levelText;
        #endregion 事件

        #region 临时变量
        private int ProduceDelta; // 用于缓存当前关卡编号（当前代码中仅赋值，未被读取）
		#endregion 临时变量

		#region Unity生命周期方法
		private void Start()
		{
			RoughVaultAnvil?.Invoke();

			// 监听来自GameLevelHolder的事件
			MGDelta.HaliteTalbotAnvil.AddListener(HaliteTalbotAnvilPropose);
			MGDelta.WideAnvil.AddListener(WideAnvilPropose);
			MGDelta.VaultDeltaAnvil.AddListener(VaultDeltaPropose);
			MGDelta.PlusDeltaAnvil.AddListener(PlusDeltaPropose);

			// 手动调用一次LoadEventHandler来初始化UI
			WideAnvilPropose(LullDeltaMisery.PrecedeDelta);
			VanVaultAnvil?.Invoke();
		}
		
		private void OnDestroy()
        {
			// 移除事件监听，防止内存泄漏
			MGDelta.HaliteTalbotAnvil.RemoveListener(HaliteTalbotAnvilPropose);
			MGDelta.WideAnvil.RemoveListener(WideAnvilPropose);
			MGDelta.VaultDeltaAnvil.RemoveListener(VaultDeltaPropose);
			MGDelta.PlusDeltaAnvil.RemoveListener(PlusDeltaPropose);
		}
		#endregion Unity生命周期方法

		/// <summary>
		/// 处理"最高通关关卡变化"事件，并转发
		/// </summary>
		private void HaliteTalbotAnvilPropose(int number)
		{
			HaliteTalbotAnvil?.Invoke(number);
		}

		/// <summary>
		/// 处理"数据加载"事件，并转发
		/// </summary>
		private void WideAnvilPropose(int number)
		{
			WideAnvil?.Invoke(number);
			// 触发UI更新事件，通常用于显示 "关卡 X"
			MildlyRatDeltaGallopAnvil?.Invoke(LullDeltaMisery.PrecedeDelta + 1);
            levelText.text = (LullDeltaMisery.PrecedeDelta + 1).ToString();
            ProduceDelta = LullDeltaMisery.PrecedeDelta;
		}

		/// <summary>
		/// 处理"开始关卡"事件，并转发
		/// </summary>
		private void VaultDeltaPropose(int number)
		{
			VaultDeltaAnvil?.Invoke(number);
		}

		/// <summary>
		/// 处理"通关"事件，并转发
		/// </summary>
		private void PlusDeltaPropose(int number)
		{
			PlusDeltaAnvil?.Invoke(number);
		}
	}
}
