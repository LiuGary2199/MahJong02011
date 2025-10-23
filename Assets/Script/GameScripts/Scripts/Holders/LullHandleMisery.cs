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
    /// 定义麻将牌的填充方式（该枚举在此脚本中未被使用，可能由其他脚本使用）
    /// </summary>
    public enum FillType {OnlySimple, GroupsAndSimple, SimpleAndGroups, RandomGroupAndSimple}

    /// <summary>
    /// 管理游戏中所有视觉主题（皮肤）的ScriptableObject。
    /// 它持有所有主题的引用，并负责处理玩家的主题选择、数据持久化以及不同主题间精灵的映射。
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableObjects/LullHandleMisery")]
    public class LullHandleMisery : SingletonScriptableObject<LullHandleMisery>
    {
        [Tooltip("包含游戏中所有主题的数组")]
        [SerializeField]
        public ReactBroadlyMisery [] Adjoin;

        #region 存储键
        [SerializeField]
        private string SoupAie= "mk_theme"; // 用于PlayerPrefs存储当前主题索引的键
        #endregion 存储键

        #region 临时变量
        private static bool Influx= false; // 标记是否已从PlayerPrefs加载过数据
        #endregion 临时变量

        private static int _NeedyMoody; // 静态变量，存储当前选择的主题索引

        /// <summary>
        /// 当前选择的主题索引。首次访问时会自动加载。
        /// </summary>
        public static int ReactMoody        {
            get { if (!Influx) Whatever.Wide(); return _NeedyMoody; }
            private set { _NeedyMoody = value; }
        }

        [Tooltip("主题变更时触发的UnityEvent事件，可在Inspector中配置")]
        public UnityEvent<int> HaliteOasisAnvil;
        [Tooltip("主题数据加载时触发的UnityEvent事件，可在Inspector中配置")]
        public UnityEvent<int> WideOasisAnvil;
        
        /// <summary>
        /// 主题变更时触发的C#事件（Action），参数为 (旧索引, 新索引)
        /// </summary>
        public Action<int, int> HaliteAnvil;
        /// <summary>
        /// 主题数据加载时触发的C#事件（Action）
        /// </summary>
        public Action<int> WideAnvil;

        private void Awake()
        {
            Wide();
            Debug.Log("Awake: " + this + " ; theme index: " + ReactMoody);
        }

        /// <summary>
        /// 设置新的主题索引
        /// </summary>
        /// <param name="index">新的主题索引</param>
        public void OldMoody(int index)
        {
            int oldIndex = ReactMoody;
            if (index < 0) index = 0;
            bool changed = (ReactMoody != index);
            ReactMoody = index;
            if (changed)
            {
                PlayerPrefs.SetInt(SoupAie, ReactMoody);
                HaliteAnvil?.Invoke(oldIndex, ReactMoody); // 触发C#事件
                HaliteOasisAnvil?.Invoke(ReactMoody); // 触发UnityEvent事件
            }
        }

        /// <summary>
        /// 从PlayerPrefs加载序列化的主题数据，如果不存在则设为默认值
        /// </summary>
        public void Wide()
        {
            Influx = true;
            _NeedyMoody = PlayerPrefs.GetInt(SoupAie, 0);
            WideAnvil?.Invoke(ReactMoody);
            WideOasisAnvil?.Invoke(ReactMoody);
        }

        /// <summary>
        /// 重置为默认主题数据
        /// </summary>
        public void OldLawlikeSoul()
        {
            PlayerPrefs.DeleteKey(SoupAie);
            OldMoody(0); // 设置为第一个主题
        }

        /// <summary>
        /// 获取当前选中的主题对象 (ReactBroadlyMisery)
        /// </summary>
        /// <returns>当前的主题对象</returns>
        public ReactBroadlyMisery HowReact()
        {
            if (Adjoin.Length == 0) return null;
            if (Adjoin.Length > 0 && ReactMoody >= 0 && ReactMoody < Adjoin.Length) return Adjoin[ReactMoody];
            return Adjoin[Adjoin.Length - 1]; // 作为备用，返回最后一个
        }
        
        /// <summary>
        /// 创建两个主题之间精灵的映射字典。
        /// 对于主题切换等功能非常有用。
        /// </summary>
        /// <param name="theme_1">主题1</param>
        /// <param name="theme_2">主题2</param>
        /// <returns>一个从主题1的精灵映射到主题2精灵的字典</returns>
        public Dictionary <Sprite, Sprite> HowBroadlyAccumulate(ReactBroadlyMisery theme_1, ReactBroadlyMisery theme_2)
        {
            Dictionary<Sprite, Sprite> res = new Dictionary<Sprite, Sprite>();
            List<Sprite> sprites_1 = theme_1.HowInstigateBroadly();
            List<Sprite> sprites_2 = theme_2.HowInstigateBroadly();
            if (sprites_1.Count != sprites_2.Count) return null; // 如果两个主题的精灵数量不一致，则无法映射

            for (int i = 0; i < sprites_1.Count; i++)
            {
                res.Add(sprites_1[i], sprites_2 [i]);
            }
            return res;
        }

        /// <summary>
        /// 根据给定的精灵，查找它属于哪个主题
        /// </summary>
        /// <param name="sprite">要查找的精灵</param>
        /// <returns>包含该精灵的主题对象</returns>
        public ReactBroadlyMisery HowCorpseReact(Sprite sprite)
        {
            foreach (var item in Adjoin)
            {
                if (item.BlubberTroop(sprite)) return item;
            }
            return null;
        }

        /// <summary>
        /// 获取一个精灵在所有其他主题中的"等效"精灵列表。
        /// 例如，获取A主题的"一万"，此方法会返回B、C、D等主题中的"一万"精灵。
        /// </summary>
        /// <param name="sourceSprite">源精灵</param>
        /// <param name="includeSourceSprite">结果中是否包含源精灵自己</param>
        /// <returns>等效精灵的列表</returns>
        public List<Sprite> HowCorpseDiscuss(Sprite sourceSprite, bool includeSourceSprite)
        {
            if (sourceSprite == null) return null;
            List<Sprite> result = new List<Sprite>();
            ReactBroadlyMisery tH_0 = HowCorpseReact(sourceSprite); // 找到源精灵所在的主题
            int Rough= tH_0.HowInstigateBroadly().IndexOf(sourceSprite); // 找到源精灵在其主题序列中的索引

            // 遍历所有主题，根据索引找到对应的精灵
            foreach (var item in Adjoin)
            {
                if (item == tH_0 && !includeSourceSprite) continue; // 根据参数决定是否跳过源主题
                result.Add(item.HowInstigateBroadly()[Rough]);
            }
            return result;
        }

        /// <summary>
        /// 获取一个精灵在当前选定主题中的"等效"精灵。
        /// </summary>
        /// <param name="sourceSprite">源精灵</param>
        /// <returns>在当前主题中对应的精灵</returns>
        public Sprite HowCorpseFlier(Sprite sourceSprite)
        {
            if (sourceSprite == null) return null;
            ReactBroadlyMisery th_current = HowReact(); // 获取当前主题
            ReactBroadlyMisery th_s = HowCorpseReact(sourceSprite); // 获取源精灵所在的主题
            if (th_s == th_current) return sourceSprite; // 如果源精灵就在当前主题中，直接返回
            int Rough= th_s.HowInstigateBroadly().IndexOf(sourceSprite); // 找到源精灵在其主题中的索引
            return th_current.HowInstigateBroadly()[Rough]; // 返回当前主题中相同索引位置的精灵
        }
    }


/*
    // 一个被注释掉的类，可能用于更复杂的精灵ID系统
    [Serializable]
    public class MahjongSpriteID
    {
        public int indexInCollection;
        public int groupIndex;
        public int themeIndex;
    }
*/

#if UNITY_EDITOR
    /// <summary>
    /// 为GameThemesHolder提供在Unity Inspector中的自定义编辑器界面
    /// </summary>
    [CustomEditor(typeof(LullHandleMisery))]
    public class GameThemesHolderEditor : Editor
    {
        private bool test = true;
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            LullHandleMisery tH = (LullHandleMisery)target;
            EditorGUILayout.LabelField("当前主题索引: " + LullHandleMisery.ReactMoody);

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