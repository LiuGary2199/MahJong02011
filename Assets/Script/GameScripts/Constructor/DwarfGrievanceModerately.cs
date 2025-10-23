using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Mkey
{
    /// <summary>
    /// 面板容器控制器，负责面板的实例化与切换
    /// </summary>
    public class DwarfGrievanceModerately : MonoBehaviour
    {
[UnityEngine.Serialization.FormerlySerializedAs("OpenCloseButton")]        public Button YorkDodgeSeaman; // 开关按钮
[UnityEngine.Serialization.FormerlySerializedAs("BrushSelectButton")]        public Button TitleElevenSeaman; // 画刷选择按钮
[UnityEngine.Serialization.FormerlySerializedAs("selector")]        public Image Seedling; // 选择器图片
[UnityEngine.Serialization.FormerlySerializedAs("brushImage")]        public Image TableReady; // 画刷图片
[UnityEngine.Serialization.FormerlySerializedAs("BrushName")]        public Text TitleOver; // 画刷名称
[UnityEngine.Serialization.FormerlySerializedAs("capital")]        public string Mixture; // 标题
[UnityEngine.Serialization.FormerlySerializedAs("gridObjects")]        public List<SodaScreen> MoteCoconut; // 对象列表

        [SerializeField]
        private UnseenDwarfModerately UnseenDwarfDismal; // 滚动面板预制体
        [SerializeField]
        private UnseenDwarfModerately UnseenDwarfDismalLaugh; // 小滚动面板预制体
        internal UnseenDwarfModerately UnseenDwarf; // 当前滚动面板

        /// <summary>
        /// 实例化标准滚动面板
        /// </summary>
        public UnseenDwarfModerately ForgivenessUnseenDwarf()
        {
            return ForgivenessUnseenDwarf(UnseenDwarfDismal);
        }

        /// <summary>
        /// 实例化小滚动面板
        /// </summary>
        public UnseenDwarfModerately ForgivenessUnseenDwarfLaugh()
        {
            return ForgivenessUnseenDwarf(UnseenDwarfDismalLaugh);
        }

        /// <summary>
        /// 内部方法：实例化指定滚动面板
        /// </summary>
        private UnseenDwarfModerately ForgivenessUnseenDwarf(UnseenDwarfModerately scrollPanelPrefab)
        {
            if (!scrollPanelPrefab) return null;

            if (UnseenDwarf) DestroyImmediate(UnseenDwarf.gameObject);

            RectTransform panel = Instantiate(scrollPanelPrefab).GetComponent<RectTransform>();
            panel.SetParent(GetComponent<RectTransform>());
            panel.anchoredPosition = new Vector2(0, 0);
            UnseenDwarf = panel.GetComponent<UnseenDwarfModerately>();
            return UnseenDwarf;
        }
    }
}