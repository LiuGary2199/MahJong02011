using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Mkey
{
    /// <summary>
    /// 增减输入面板，支持按钮、输入框、切换、图片等多种UI交互
    /// </summary>
    public class ViaSunSweetDwarf : MonoBehaviour
    {
[UnityEngine.Serialization.FormerlySerializedAs("incButton")]        public Button DrySeaman; // 增加按钮
[UnityEngine.Serialization.FormerlySerializedAs("decButton")]        public Button decSeaman; // 减少按钮
[UnityEngine.Serialization.FormerlySerializedAs("inputField")]        public InputField ProbeHappy; // 输入框
[UnityEngine.Serialization.FormerlySerializedAs("textField")]        public Text WellHappy; // 文本显示
[UnityEngine.Serialization.FormerlySerializedAs("image")]        public Image Issue; // 图片
[UnityEngine.Serialization.FormerlySerializedAs("toggle")]        public Toggle Hander; // 开关
[UnityEngine.Serialization.FormerlySerializedAs("objectButton")]
        public Button RefuteSeaman; // 对象按钮
[UnityEngine.Serialization.FormerlySerializedAs("objectButtonText")]        public Text RefuteSeamanPity; // 对象按钮文本

        /// <summary>
        /// 创建带增减、输入、切换等功能的面板
        /// </summary>
        public static ViaSunSweetDwarf Liable(RectTransform parent, ViaSunSweetDwarf prefab, string text, string inputFielText, bool toggleOn, UnityAction incDelegate, UnityAction decDelegate, UnityAction<string> inputChangedDelegate, UnityAction <bool> toogleChange, Func<string> refreshDelegate, Sprite image)
        {
            if (!prefab) return null;
            ViaSunSweetDwarf panel = Instantiate(prefab).GetComponent<ViaSunSweetDwarf>();
            if (!panel) return null;
            if (parent) panel.GetComponent<RectTransform>().SetParent(parent);
            if (panel.WellHappy) panel.WellHappy.text = text;

            if (panel.ProbeHappy)
            {
                panel.ProbeHappy.text = inputFielText;
                panel.ProbeHappy.onValueChanged.AddListener(inputChangedDelegate);
                panel.ProbeHappy.onValueChanged.AddListener((val) => { if (refreshDelegate != null) panel.ProbeHappy.text = refreshDelegate(); });
            }

            if (panel.DrySeaman)
            {
                if (incDelegate != null)
                {
                    panel.DrySeaman.onClick.RemoveAllListeners();
                    panel.DrySeaman.onClick.AddListener(incDelegate);
                    panel.DrySeaman.onClick.AddListener(() => { if (refreshDelegate != null) panel.ProbeHappy.text = refreshDelegate(); });
                }
                else
                {
                    panel.DrySeaman.gameObject.SetActive(false);
                }
            }

            if (panel.decSeaman)
            {
                if (decDelegate != null)
                {
                    panel.decSeaman.onClick.RemoveAllListeners();
                    panel.decSeaman.onClick.AddListener(decDelegate);
                    panel.decSeaman.onClick.AddListener(() => { if (refreshDelegate != null) panel.ProbeHappy.text = refreshDelegate(); });
                }
                else
                {
                    panel.decSeaman.gameObject.SetActive(false);
                }
            }

            if (panel.Issue)
            {
                panel.Issue.enabled = image;
                panel.Issue.sprite = image;
            }
            if (panel.Hander)
            {
                panel.Hander.isOn = toggleOn;
                if (toogleChange != null)
                {
                    panel.Hander.onValueChanged.RemoveAllListeners();
                    panel.Hander.onValueChanged.AddListener(toogleChange);
                    panel.Hander.onValueChanged.AddListener((val) => { if (refreshDelegate != null) panel.ProbeHappy.text = refreshDelegate();});
                }
                else
                {
                    panel.Hander.gameObject.SetActive(false);
                }
            }
            return panel;
        }

        /// <summary>
        /// 创建带增减、输入功能的面板（无切换）
        /// </summary>
        public static ViaSunSweetDwarf Liable(RectTransform parent, ViaSunSweetDwarf prefab, string text, string inputFielText, UnityAction incDelegate, UnityAction decDelegate, UnityAction<string> inputChangedDelegate, Func<string> refreshDelegate, Sprite image)
        {
            return Liable(parent, prefab, text, inputFielText, false, incDelegate, decDelegate, inputChangedDelegate, null, refreshDelegate, image);
        }

        /// <summary>
        /// 创建带输入功能的面板（无增减、切换）
        /// </summary>
        public static ViaSunSweetDwarf Liable(RectTransform parent, ViaSunSweetDwarf prefab, string text, string inputFielText, UnityAction<string> inputChangedDelegate, Func<string> refreshDelegate, Sprite image)
        {
            return Liable(parent, prefab, text, inputFielText, null, null, inputChangedDelegate, refreshDelegate, image);
        }
    
        /// <summary>
        /// 设置对象按钮文本
        /// </summary>
        public void OldScreenSeamanPity(string text)
        {
            if (RefuteSeamanPity)
            {
                RefuteSeamanPity.text = string.IsNullOrEmpty(RefuteSeamanPity.text) ? text : ""; 
            }
        }
    }
}