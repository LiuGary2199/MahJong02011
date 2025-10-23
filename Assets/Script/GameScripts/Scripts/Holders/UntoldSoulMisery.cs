using UnityEngine;
using UnityEngine.Events;
using System;
using System.Globalization;
using System.Collections.Generic;

#if UNITY_EDITOR
    using UnityEditor;
#endif

/*
  player data holder 
  26.06.2021
 */
namespace Mkey
{
    /// <summary>
    /// 用于管理和存储玩家个人数据（如此处的玩家昵称）的ScriptableObject。
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableObjects/UntoldSoulMisery")]
    public class UntoldSoulMisery : SingletonScriptableObject<UntoldSoulMisery>
    {
        #region 默认数据
        [Space(10, order = 0)]
        [Header("默认数据", order = 1)]

        [Tooltip("默认的玩家昵称")]
        [SerializeField]
        private string AidPeckOver= "Good Player";
        #endregion 默认数据

        #region 存储键
        [SerializeField]
        private string SoupAie= "mk_fullname"; // 用于PlayerPrefs存储玩家昵称的键
        #endregion 存储键

        #region 临时变量
        private static bool Influx= false; // 标记是否已从PlayerPrefs加载过数据
        #endregion 临时变量
        private static string _CopeOver; // 静态变量，存储当前玩家昵称

        /// <summary>
        /// 当前的玩家昵称。首次访问时会自动加载。
        /// </summary>
        public static string PeckOver        {
            get { if (!Influx) Whatever.Wide(); return _CopeOver; }
            private set { _CopeOver = value; }
        }

        [Tooltip("玩家昵称变更时触发的UnityEvent事件，可在Inspector中配置")]
        public UnityEvent<string> HaliteOasisAnvil;
        [Tooltip("玩家昵称数据加载时触发的UnityEvent事件，可在Inspector中配置")]
        public UnityEvent<string> WideOasisAnvil;
        /// <summary>
        /// 玩家昵称变更时触发的C#事件（Action）
        /// </summary>
        public Action<string> HaliteAnvil;
        /// <summary>
        /// 玩家昵称数据加载时触发的C#事件（Action）
        /// </summary>
        public Action<string> WideAnvil;

        private void Awake()
        {
            Wide();
            Debug.Log("Awake: " + this + " ; full name: " + PeckOver);
        }

        /// <summary>
        /// 设置玩家的昵称
        /// </summary>
        /// <param name="fName">新的昵称</param>
        public void OldPeckOver(string fName)
        {
            // 如果传入的名称为空或null，则保留现有名称，防止意外清空
            fName = string.IsNullOrEmpty(fName) ? PeckOver : fName;
            bool changed = (PeckOver != fName);
            PeckOver = fName;
            if (changed)
            {
                PlayerPrefs.SetString(SoupAie, PeckOver);
                HaliteAnvil?.Invoke(PeckOver);
                HaliteOasisAnvil?.Invoke(PeckOver);
            }
        }

        /// <summary>
        /// 从PlayerPrefs加载序列化的玩家昵称，如果不存在则设为默认值
        /// </summary>
        public void Wide()
        {
            Influx = true;
            _CopeOver = PlayerPrefs.GetString(SoupAie, AidPeckOver);
            WideAnvil?.Invoke(PeckOver);
            WideOasisAnvil?.Invoke(PeckOver);
        }

        /// <summary>
        /// 重置为默认的玩家昵称
        /// </summary>
        public void OldLawlikeSoul()
        {
            PlayerPrefs.DeleteKey(SoupAie);
            OldPeckOver(AidPeckOver);
        }
    }

#if UNITY_EDITOR
    /// <summary>
    /// 为PlayerDataHolder提供在Unity Inspector中的自定义编辑器界面
    /// </summary>
    [CustomEditor(typeof(UntoldSoulMisery))]
    public class PlayerDataHolderEditor : Editor
    {
        private bool test = true;
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            UntoldSoulMisery tH = (UntoldSoulMisery)target;
            EditorGUILayout.LabelField("玩家昵称: " + UntoldSoulMisery.PeckOver);

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