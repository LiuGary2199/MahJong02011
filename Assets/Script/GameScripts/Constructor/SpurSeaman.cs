using UnityEngine;
using UnityEngine.UI;

namespace Mkey
{
	/// <summary>
	/// 模式切换按钮，支持编辑/游戏模式切换及关卡切换
	/// </summary>
	public class SpurSeaman : MonoBehaviour
	{
        [SerializeField]
        private Button GustSeaman; // 模式切换按钮
        [SerializeField]
        private Text GustPity; // 模式文本
        #region temp vars

        #endregion temp vars
        private LullFreshnessOld GCOld{ get { return LullFreshnessOld.Whatever; } } // 配置集

        #region regular
        /// <summary>
        /// 初始化模式按钮，绑定切换事件
        /// </summary>
        private void Start()
		{
#if UNITY_EDITOR
            if (GustSeaman)
            {
                GustSeaman.gameObject.SetActive(true);
                if(GustPity)  GustPity.text = (LullSyrup.GSpur == GameMode.Edit) ? "To Play Mode" : "To Edit Mode";
                GustSeaman.onClick.AddListener(() =>
                {
                    if (LullSyrup.GSpur == GameMode.Edit)
                    {
                        LullSyrup.GSpur = GameMode.Play;
                        if (GustPity) GustPity.text = "To Edit Mode";
                    }
                    else
                    {
                        MelodyWeigh.UsherPhysicJoy();
                        LullSyrup.GSpur = GameMode.Edit;
                        if (GustPity) GustPity.text = "To Play Mode";
                    }
                    FatalHomely.Instance.BeWidePrecedeFatal(false);
                });
            }
#else
           if (modeButton) modeButton.gameObject.SetActive(false); 
#endif
        // modeButton.gameObject.SetActive(false);
        }

        /// <summary>
        /// 切换到下一关
        /// </summary>
        public void RageDelta()
        {
            if (!GCOld) return;
            int levelCount = GCOld.DeltaPulse;
            if (LullDeltaMisery.PrecedeDelta < levelCount - 1)
            {
                LullDeltaMisery.PrecedeDelta++;
                FatalHomely.Instance.BeWidePrecedeFatal(false);
            }
        }

        /// <summary>
        /// 切换到上一关
        /// </summary>
        public void WaryDelta()
        {
            if (!GCOld) return;
            if (LullDeltaMisery.PrecedeDelta > 0)
            {
                LullDeltaMisery.PrecedeDelta--;
                FatalHomely.Instance.BeWidePrecedeFatal(false);
            }
        }
        #endregion regular
    }
}
