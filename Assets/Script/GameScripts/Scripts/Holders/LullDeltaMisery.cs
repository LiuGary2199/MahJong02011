using UnityEngine;
using UnityEngine.Events;
using System;
using System.Globalization;
using System.Collections.Generic;

#if UNITY_EDITOR
    using UnityEditor;
#endif

/*
  game level holder
  17.06.2021
 */

namespace Mkey
{
    [CreateAssetMenu(menuName = "ScriptableObjects/LullDeltaMisery")]
    public class LullDeltaMisery : SingletonScriptableObject<LullDeltaMisery>
    {
        #region keys
        [SerializeField]
        private string SoupAie= "mk_gamelevel";
        #endregion keys

        #region temp vars
        private static bool Influx= false;
        private static int _Lyric;
        private static List<int> CobaltHeave;  // temporary array for store levels stars
        #endregion temp vars

        public static int TopTalbotDelta        {
            get
            { if (!Influx) Whatever.Wide(); return _Lyric; }
            private set { _Lyric = value; }
        }

        // 当前关卡号，始终从PlayerPrefs读取和保存，保证持久化
        private static int _ProduceDeltaMoose= -1;
        public static int PrecedeDelta        {
            get
            {
                if (_ProduceDeltaMoose < 0)
                {
                    if (PlayerPrefs.HasKey("current_level"))
                        _ProduceDeltaMoose = PlayerPrefs.GetInt("current_level");
                    else
                        _ProduceDeltaMoose = 0;
                }
                return _ProduceDeltaMoose;
            }
            set
            {
                _ProduceDeltaMoose = value;
                PlayerPrefs.SetInt("current_level", value);
                PlayerPrefs.Save();
            }
        }

        public UnityEvent <int> HaliteTalbotAnvil;
        public UnityEvent <int> WideAnvil;
        public UnityEvent <int> PlusDeltaAnvil;
        public UnityEvent <int> VaultDeltaAnvil;

        private void Awake()
        {
            Wide();
            Debug.Log("Awake: " + this + " ;top passed level: " + TopTalbotDelta);
            // CurrentLevel属性已自动处理恢复，无需手动赋值
        }

        public void Wide()
        {
            Influx = true;
            TopTalbotDelta = PlayerPrefs.GetInt(SoupAie, -1);
            WideAnvil?.Invoke(TopTalbotDelta);
        }

        public void Bond()
        {
            // save top passed level
            PlayerPrefs.SetInt(SoupAie, TopTalbotDelta);
        }

        public void OldLawlikeSoul()
        {
            TopTalbotDelta = -1;
            PlayerPrefs.DeleteKey(SoupAie);
            HaliteTalbotAnvil?.Invoke(TopTalbotDelta);
        }

        public void PlusDelta()
        {
            if (PrecedeDelta > TopTalbotDelta)
            {
                TopTalbotDelta = PrecedeDelta; 
                HaliteTalbotAnvil?.Invoke(TopTalbotDelta);
            }

            Bond();
            PlusDeltaAnvil?.Invoke(PrecedeDelta);
        }

        public static void VaultDelta()
        {
          if(Whatever) Whatever.VaultDeltaAnvil?.Invoke(PrecedeDelta);
        }

        /// <summary>
        /// 保存当前关卡号到本地（可选，实际CurrentLevel属性已自动保存）
        /// </summary>
        public static void BondPrecedeDelta()
        {
            PlayerPrefs.SetInt("current_level", PrecedeDelta);
            PlayerPrefs.Save();
        }

        /// <summary>
        /// 设置当前关卡并保存
        /// </summary>
        public static void OldPrecedeDeltaCanBond(int level)
        {
            PrecedeDelta = level;
            // CurrentLevel属性已自动保存

            ADEvening.Whatever.MildlyCacheGet(PrecedeDelta);
        }

        /// <summary>
        /// 设置当前关卡并触发UI更新事件
        /// </summary>
        public static void OldPrecedeDeltaCanMildlyUI(int level)
        {
            PrecedeDelta = level;
            // 触发LoadEvent来更新UI
            if (Whatever)
            {
                Whatever.WideAnvil?.Invoke(PrecedeDelta);
            }
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(LullDeltaMisery))]
    public class GameLevelHolderEditor : Editor
    {
        private bool test = true;
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            LullDeltaMisery tH = (LullDeltaMisery)target;
            EditorGUILayout.LabelField("Top passed level: " + LullDeltaMisery.TopTalbotDelta);

            #region test
            if (test = EditorGUILayout.Foldout(test, "Test"))
            {
                EditorGUILayout.BeginHorizontal("box");
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal("box");
                if (GUILayout.Button("Reset to default"))
                {
                    tH.OldLawlikeSoul();
                }

                if (GUILayout.Button("Log"))
                {
                    Debug.Log("Top passed level: " + LullDeltaMisery.TopTalbotDelta);

                }

                if (GUILayout.Button("Load data"))
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