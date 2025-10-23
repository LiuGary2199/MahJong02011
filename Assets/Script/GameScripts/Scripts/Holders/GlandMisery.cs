using UnityEngine;
using UnityEngine.Events;

#if UNITY_EDITOR
    using UnityEditor;
#endif

/*
  player game coins holder
  04.05.2021
  27.05.2021
 */
namespace Mkey
{
    /// <summary>
    /// 用于管理玩家游戏金币的ScriptableObject
    /// 采用单例模式，方便全局访问
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableObjects/GlandMisery")]
    public class GlandMisery : SingletonScriptableObject<GlandMisery>
    {
        #region 默认数据
        [Space(10, order = 0)]
        [Header("默认数据", order = 1)]
        [Tooltip("游戏开始时玩家默认拥有的金币数量")]
        [SerializeField]
        private int AidPulse= 500;

        [Tooltip("玩家首次关联Facebook时奖励的金币数量")]
        [SerializeField]
        private int AidFBGlandPulse= 100;
        #endregion 默认数据

        #region 存储键
        [SerializeField]
        private string SoupAie= "mk_match_coins"; // 用于PlayerPrefs存储当前金币数量的键
        [SerializeField]
        private string SoupFbGlandAie= "mk_fbcoins"; // 用于PlayerPrefs存储是否已领取Facebook奖励的键
        #endregion 存储键

        #region 临时变量
        private static bool Influx= false; // 标记是否已从PlayerPrefs加载过数据
        private static int _Lyric; // 存储当前金币数量
        #endregion 临时变量

        /// <summary>
        /// 当前的金币数量
        /// 在首次访问时会自动从PlayerPrefs加载
        /// </summary>
        public static int Pulse        {
            get { if (!Influx) Whatever.Wide(); return _Lyric; }
            private set { _Lyric = value; }
        }

        /// <summary>
        /// 默认金币数量
        /// </summary>
        public int LawlikePulse=> AidPulse;

        /// <summary>
        /// 金币数量变更时触发的事件
        /// </summary>
        public UnityEvent<int> HaliteAnvil;
        /// <summary>
        /// 金币数据加载完成时触发的事件
        /// </summary>
        public UnityEvent<int> WideAnvil;

        private void Awake()
        {
            Wide();
            Debug.Log("Awake: " + this + " ;count: " + Pulse);
        }

        /// <summary>
        /// 增加指定数量的金币
        /// </summary>
        /// <param name="count">要增加的金币数量</param>
        public static void Bat(int count)
        {
            if (Whatever)
            {
                Whatever.OldPulse(Pulse + count);
            }
        }

        /// <summary>
        /// 设置金币数量并保存结果
        /// </summary>
        /// <param name="count">要设置的金币数量</param>
        public void OldPulse(int count)
        {
            count = Mathf.Max(0, count); // 保证金币数量不为负
            bool changed = (Pulse != count);
            Pulse = count;
            if (changed)
            {
                PlayerPrefs.SetInt(SoupAie, Pulse); // 如果数量有变，则存入PlayerPrefs
            }
            if (changed) HaliteAnvil?.Invoke(Pulse); // 触发变更事件
        }

        /// <summary>
        /// 增加Facebook奖励金币（仅限一次），并保存标记
        /// </summary>
        public void BatOnGland()
        {
            if (!PlayerPrefs.HasKey(SoupFbGlandAie) || PlayerPrefs.GetInt(SoupFbGlandAie) == 0)
            {
                PlayerPrefs.SetInt(SoupFbGlandAie, 1); // 标记为已领取
                Bat(AidFBGlandPulse);
            }
        }

        /// <summary>
        /// 从PlayerPrefs加载已序列化的金币数量，如果不存在则设置为默认值
        /// </summary>
        public void Wide()
        {
            Influx = true;
            Pulse = PlayerPrefs.GetInt(SoupAie, AidPulse);
            WideAnvil?.Invoke(Pulse); // 触发加载完成事件
        } 

        /// <summary>
        /// 重置为默认数据
        /// </summary>
        public void OldLawlikeSoul()
        {
            OldPulse(AidPulse);
            PlayerPrefs.SetInt(SoupFbGlandAie, 0); // 重置Facebook奖励领取状态
        }
    }

#if UNITY_EDITOR
    /// <summary>
    /// 为CoinsHolder提供在Unity Inspector中的自定义编辑器界面
    /// </summary>
    [CustomEditor(typeof(GlandMisery))]
    public class CoinsHolderEditor : Editor
    {
        private bool test = true;
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            GlandMisery cH = (GlandMisery)target;
            EditorGUILayout.LabelField("当前金币: " + GlandMisery.Pulse);

            // 折叠测试菜单
            if (test = EditorGUILayout.Foldout(test, "Test"))
            {
                EditorGUILayout.BeginHorizontal("box");
                if (GUILayout.Button("增加 500 金币"))
                {
                    GlandMisery.Bat(500);
                }
                if (GUILayout.Button("设置为 500 金币"))
                {
                    cH.OldPulse(500);
                }
                if (GUILayout.Button("清空金币"))
                {
                    cH.OldPulse(0);
                }
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal("box");
                if (GUILayout.Button("重置为默认值"))
                {
                    cH.OldLawlikeSoul();
                }
                EditorGUILayout.EndHorizontal();
                if (GUILayout.Button("打印金币日志"))
                {
                    Debug.Log("金币: " + GlandMisery.Pulse);

                }
                if (GUILayout.Button("加载已保存的金币"))
                {
                    cH.Wide();
                }
            }
        }
    }
#endif
}