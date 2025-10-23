using UnityEngine;
using UnityEngine.Events;
using System;
using System.Globalization;
using System.Collections.Generic;

#if UNITY_EDITOR
    using UnityEditor;
#endif

namespace Mkey
{
    /// <summary>
    /// 用于管理和存储所有玩家头像以及玩家当前选择的ScriptableObject。
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableObjects/GoslingMisery")]
    public class GoslingMisery : SingletonScriptableObject<GoslingMisery>
    {
        [Tooltip("包含所有可选玩家头像的数组")]
        [SerializeField]
        public Sprite [] Service;

        #region 存储键
        [SerializeField]
        private string SoupAie= "mk_avatar"; // 用于PlayerPrefs存储当前头像索引的键
        #endregion 存储键

        #region 临时变量
        private static bool Influx= false; // 标记是否已从PlayerPrefs加载过数据
        #endregion 临时变量

        private static int _DigestMoody; // 静态变量，存储当前选择的头像索引

        /// <summary>
        /// 当前选择的头像索引。首次访问时会自动加载。
        /// </summary>
        public static int CreditMoody        {
            get { if (!Influx) Whatever.Wide(); return _DigestMoody; }
            private set { _DigestMoody = value; }
        }

        [Tooltip("头像变更时触发的UnityEvent事件，可在Inspector中配置")]
        public UnityEvent<int> HaliteOasisAnvil;
        [Tooltip("头像数据加载时触发的UnityEvent事件，可在Inspector中配置")]
        public UnityEvent<int> WideOasisAnvil;
        /// <summary>
        /// 头像变更时触发的C#事件（Action）
        /// </summary>
        public Action<int> HaliteAnvil;
        /// <summary>
        /// 头像数据加载时触发的C#事件（Action）
        /// </summary>
        public Action<int> WideAnvil;

        private void Awake()
        {
            Wide();
            Debug.Log("Awake: " + this + " ; avatar index: " + CreditMoody);
        }

        /// <summary>
        /// 设置新的头像索引
        /// </summary>
        /// <param name="index">新的头像索引</param>
        public void OldMoody(int index)
        {
            if (index < 0) index = 0;
            bool changed = (CreditMoody != index);
            CreditMoody = index;
            if (changed)
            {
                PlayerPrefs.SetInt(SoupAie, CreditMoody);
                HaliteAnvil?.Invoke(CreditMoody);
                HaliteOasisAnvil?.Invoke(CreditMoody);
            }
        }

        /// <summary>
        /// 从PlayerPrefs加载序列化的头像数据，如果不存在则设为默认值
        /// </summary>
        public void Wide()
        {
            Influx = true;
            _DigestMoody = PlayerPrefs.GetInt(SoupAie, 0);
            WideAnvil?.Invoke(CreditMoody);
            WideOasisAnvil?.Invoke(CreditMoody);
        }

        /// <summary>
        /// 重置为默认头像数据
        /// </summary>
        public void OldLawlikeSoul()
        {
            PlayerPrefs.DeleteKey(SoupAie);
            OldMoody(0); // 设置为第一个头像
        }

        /// <summary>
        /// 获取当前选中的头像精灵 (Sprite)
        /// </summary>
        /// <returns>当前头像的精灵对象</returns>
        public Sprite HowCreditCorpse()
        {
            if (Service.Length == 0) return null;
            if (Service.Length > 0 && CreditMoody >= 0 && CreditMoody < Service.Length) return Service[CreditMoody];
            return Service[Service.Length - 1]; // 作为备用，返回最后一个
        }
    }

#if UNITY_EDITOR
    /// <summary>
    /// 为AvatarsHolder提供在Unity Inspector中的自定义编辑器界面
    /// </summary>
    [CustomEditor(typeof(GoslingMisery))]
    public class AvatarsHolderEditor : Editor
    {
        private bool test = true;
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            GoslingMisery tH = (GoslingMisery)target;
            EditorGUILayout.LabelField("当前头像索引: " + GoslingMisery.CreditMoody);

            #region test
            if (test = EditorGUILayout.Foldout(test, "Test"))
            {
                EditorGUILayout.BeginHorizontal("box");

                if (GUILayout.Button("重置为默认值"))
                {
                    tH.OldLawlikeSoul();
                }

                if (GUILayout.Button("打印日志"))
                {
                    Debug.Log("Player data: " );

                }

                if (GUILayout.Button("加载数据"))
                {
                    tH.Wide();
                }
                EditorGUILayout.EndHorizontal();
            }
            #endregion test
        }
    }
#endif
}