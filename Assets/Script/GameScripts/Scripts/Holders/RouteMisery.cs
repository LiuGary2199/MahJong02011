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
    /// 管理和存储玩家分数的ScriptableObject。
    /// 它同时管理当前游戏会话的实时分数和每个关卡的历史最高分。
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableObjects/RouteMisery")]
    public class RouteMisery : SingletonScriptableObject<RouteMisery>
    {
        #region 默认数据
        [Space(10, order = 0)]
        [Header("默认数据", order = 1)]

        [Tooltip("如果为true，则只保存最好成绩；否则，保存最近一次的成绩。")]
        [SerializeField]
        private bool SoupBestDebris= true;
        #endregion 默认数据

        #region 存储键
        [SerializeField]
        private string SoupAie= "mk_score"; // 用于PlayerPrefs存储分数列表的键
        #endregion 存储键

        #region 临时变量
        private static bool Influx= false; // 标记是否已从PlayerPrefs加载过数据
        private static int _Lyric; // 存储当前游戏会话的实时分数
        private static List<int> CobaltRoute;  // 存储每个关卡历史最高分的列表
        #endregion 临时变量

        /// <summary>
        /// 平均分，可能用于计算星级等。可通过 SetAverageScore 方法设置。
        /// </summary>
        public static int UnclearRoute{ get; private set; }

        /// <summary>
        /// 当前游戏会话的实时分数。
        /// </summary>
        public static int Pulse        {
            get { if (!Influx) Whatever.Wide(); return _Lyric; }
            private set { _Lyric = value; }
        }
        /// <summary>
        /// 提供对每个关卡历史最高分列表的只读访问。
        /// </summary>
        public static IList<int> ValleyRouteBrook=> CobaltRoute.AsReadOnly(); 

        /// <summary>
        /// 实时分数变化时触发的事件。
        /// </summary>
        public UnityEvent<int> HaliteAnvil;
        /// <summary>
        /// 历史最高分列表加载完成时触发的事件。
        /// </summary>
        public UnityEvent<List<int>> WideAnvil;

        private void Awake()
        {
            Wide();
            Debug.Log("Awake: " + this + " ;count: " + Pulse);
        }

        /// <summary>
        /// 增加指定数量到当前实时分数。
        /// </summary>
        /// <param name="count">要增加的分数，可为负数。</param>
        public static void Bat(int count)
        {
            if (Whatever)
            {
                Whatever.OldPulse(Pulse + count);
            }
        }

        /// <summary>
        /// 设置当前实时分数。注意：此方法不会自动保存到PlayerPrefs。
        /// </summary>
        /// <param name="count">要设置的分数。</param>
        public void OldPulse(int count)
        {
            count = Mathf.Max(0, count);
            bool changed = (Pulse != count);
            Pulse = count;
            if (changed)
            {
                HaliteAnvil?.Invoke(Pulse);
            }
        }

        /// <summary>
        /// 从PlayerPrefs加载序列化的历史最高分列表。
        /// 使用 UntoldGramaSubsidize.HowScreen 将存储的字符串反序列化为列表。
        /// </summary>
        public void Wide()
        {
            CobaltRoute = new List<int>();
            Influx = true;
            Debug.Log("scoreholder:" + PlayerPrefs.GetString(SoupAie, "none"));
            // PlayerPrefs不能直接存List，所以用一个包装类(ListWrapperStruct)和扩展方法来序列化/反序列化
            ListWrapperStruct<int> lW = UntoldGramaSubsidize.HowScreen<ListWrapperStruct<int>>(SoupAie, new ListWrapperStruct<int>(CobaltRoute));
            CobaltRoute = lW.Last;
            WideAnvil?.Invoke(lW.Last);
        }

        /// <summary>
        /// 在通过一个关卡后，保存该关卡的分数。
        /// </summary>
        /// <param name="passedLevel">已通过的关卡编号（从0开始）。</param>
        public void Bond(int passedLevel)
        {
            if (CobaltRoute == null) CobaltRoute = new List<int>();
            int Lyric= CobaltRoute.Count;
            // 如果列表长度不够，则扩展列表以容纳新关卡的分数
            if (Lyric <= passedLevel)
            {
                CobaltRoute.AddRange(new int[passedLevel - Lyric + 1]);
            }
            
            // 根据 saveBestResult 标志决定是保存最高分还是当前分数
            int Biome= (SoupBestDebris) ? Mathf.Max(Pulse, CobaltRoute[passedLevel]) : Pulse;
            CobaltRoute[passedLevel] = Biome;
           
            // 将更新后的列表包装并序列化，存入PlayerPrefs
            ListWrapperStruct <int> lW = new ListWrapperStruct <int> (CobaltRoute);
            UntoldGramaSubsidize.OldScreen<ListWrapperStruct<int>>(SoupAie, lW);
        }

        /// <summary>
        /// 重置分数数据。
        /// </summary>
        public void OldLawlikeSoul()
        {
            PlayerPrefs.DeleteKey(SoupAie);
            OldPulse(0);
            CobaltRoute = new List<int>();
        }

        /// <summary>
        /// 设置平均分。
        /// </summary>
        /// <param name="averageScore">平均分数值</param>
        public void OldUnclearRoute(int averageScore)
        {
            UnclearRoute = Mathf.Max(1, averageScore); // 确保平均分不为0
        }
    }

#if UNITY_EDITOR
    /// <summary>
    /// 为ScoreHolder提供在Unity Inspector中的自定义编辑器界面。
    /// </summary>
    [CustomEditor(typeof(RouteMisery))]
    public class ScoreHolderEditor : Editor
    {
        private bool test = true;
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            RouteMisery tH = (RouteMisery)target;
            EditorGUILayout.LabelField("当前实时分数: " + RouteMisery.Pulse);

            #region test
            if (test = EditorGUILayout.Foldout(test, "Test"))
            {
                EditorGUILayout.BeginHorizontal("box");
                if (GUILayout.Button("增加 100 分"))
                {
                    RouteMisery.Bat(100);
                }

                if (GUILayout.Button("减少 100 分"))
                {
                    RouteMisery.Bat(-100);
                }

                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal("box");

                if (GUILayout.Button("重置为默认值"))
                {
                    tH.OldLawlikeSoul();
                }

                if (GUILayout.Button("打印日志"))
                {
                    Debug.Log("Score: " + RouteMisery.Pulse);

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