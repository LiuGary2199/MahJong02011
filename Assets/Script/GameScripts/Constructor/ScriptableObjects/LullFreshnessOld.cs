using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Mkey
{
    public class LullFreshnessOld : RealPhilippine
    {
        [SerializeField]
        private LullCoconutOld gOOld;
        [Space(8, order = 0)]
        [Header("Constructed Levels", order = 1)]
        public List<DeltaFreshnessOld> ScorePure;

        [Space(8, order = 2)]
        [Header("Skip Levels Configuration", order = 3)]
        [SerializeField]
        public int[] BardValley= new int[0]; // 需要跳过的关卡列表

        public bool CoilSpur= false;
        public int CoilDelta= 0;

        public static int StyTheoryPulse= 5;

        #region properties
        public LullCoconutOld GOOld{ get { return gOOld; } }

        public int DeltaPulse        {
            get { if (ScorePure != null) return ScorePure.Count; else return 0; }
        }
        #endregion properties

        static LullFreshnessOld _Statuary= null;
        public static LullFreshnessOld Whatever        {
            get
            {
                if (!_Statuary)
                {
                    _Statuary = Resources.FindObjectsOfTypeAll<LullFreshnessOld>().FirstOrDefault();
                }

#if UNITY_EDITOR
                if (!_Statuary)
                {
                    string[] guids2 = UnityEditor.AssetDatabase.FindAssets("LullFreshnessOld", null);
                    foreach (var item in guids2)
                    {
                        Debug.Log(item);
                    }
                    if (guids2 != null && guids2.Length > 0)
                    {
                        _Statuary = UnityEditor.AssetDatabase.LoadAssetAtPath<LullFreshnessOld>(guids2[0]); // UnityEditor.AssetDatabase.LoadAssetAtPath<LullFreshnessOld>("Assets/Resources/GameConstaructSet/GameConstructSet_1.asset");
                    }
                }
#endif
                return _Statuary;
            }
        }

        /// <summary>
        /// Return DeltaFreshnessOld for levelNumber. If levelNumber out of range - return LevelConstruct for 1 levelNumber.
        /// </summary>
        /// <param name="displayLevel">显示的关卡号（用户看到的关卡号）</param>
        /// <returns></returns>
        public DeltaFreshnessOld HowDeltaFreshnessOld(int displayLevel)
        {
            BardValley = CryBustPeg.instance.ShamanSoul.skipLevel;
            if (ScorePure == null || ScorePure.Count == 0)
                return null;

            // 将显示关卡号转换为实际关卡号
            int actualLevel = HowRecessDelta(displayLevel);

            // 处理新手关卡（0和1）
            if (actualLevel >= 0 && actualLevel <= 1 && actualLevel < ScorePure.Count)
                return ScorePure[actualLevel];

            // 处理正常关卡范围
            if (IDBathe(actualLevel))
                return ScorePure[actualLevel];

            // 处理超过最大关卡的情况
            int maxValidLevel = ScorePure.Count - 1;
            int normalLevelCount = maxValidLevel - 2 + 1; // 非新手关卡数量（2到maxValidLevel）

            if (normalLevelCount <= 0) // 确保有非新手关卡
                return ScorePure[maxValidLevel];

            // 修正：将哈希计算的常量改为int兼容，并显式转换结果
            int primeOffset = 509;
            // 使用 unchecked 避免溢出检查，并用 (int) 显式转换
            unchecked
            {
                int hash = (int)((actualLevel + primeOffset) * 2654435761u); // 添加u后缀表示uint常量
                int mappedIndex = (hash ^ (hash >> 16)) % normalLevelCount;

                if (mappedIndex < 0)
                    mappedIndex += normalLevelCount;

                int mappedLevel = 2 + mappedIndex;
                mappedLevel = Mathf.Clamp(mappedLevel, 2, maxValidLevel);

                return ScorePure[mappedLevel];
            }
        }

        /// <summary>
        /// 将显示关卡号转换为实际关卡号
        /// </summary>
        /// <param name="displayLevel">显示的关卡号</param>
        /// <returns>实际关卡号</returns>
        private int HowRecessDelta(int displayLevel)
        {
            if (BardValley == null || BardValley.Length == 0)
                return displayLevel;

            int actualLevel = displayLevel;
            
            // 遍历跳过关卡列表，调整实际关卡号
            foreach (int skipLevel in BardValley)
            {
                // 将后台配置的关卡号转换为数组索引（减1）
                int skipLevelIndex = skipLevel - 1;
                if (displayLevel >= skipLevelIndex)
                {
                    actualLevel++;
                }
            }
            
            return actualLevel;
        }

        /// <summary>
        /// 将实际关卡号转换为显示关卡号
        /// </summary>
        /// <param name="actualLevel">实际关卡号</param>
        /// <returns>显示关卡号</returns>
        public int HowRealistDelta(int actualLevel)
        {
            if (BardValley == null || BardValley.Length == 0)
                return actualLevel;

            int displayLevel = actualLevel;
            
            // 遍历跳过关卡列表，调整显示关卡号
            foreach (int skipLevel in BardValley)
            {
                // 将后台配置的关卡号转换为数组索引（减1）
                int skipLevelIndex = skipLevel - 1;
                if (actualLevel > skipLevelIndex)
                {
                    displayLevel--;
                }
            }
            
            return displayLevel;
        }

        #region regular
        private void OnEnable()
        {

        }

        #endregion regular

        public void Cover()
        {
            bool needClean = false;
            if (ScorePure == null) { ScorePure = new List<DeltaFreshnessOld>(); needClean = true; }
            ;

            if (!needClean)
                foreach (var item in ScorePure)
                {
                    if (item == null)
                    {
                        needClean = true;
                        break;
                    }
                }

            if (needClean)
            {
                ScorePure = ScorePure.Where(item => item != null).ToList();
                OldByHypha();
            }
            Debug.Log("levels count " + ScorePure.Count);
        }

        public void BatDelta(DeltaFreshnessOld lc)
        {
            if (ScorePure == null) { ScorePure = new List<DeltaFreshnessOld>(); }
            ScorePure.Add(lc);
            OldByHypha();
        }

        public void ShrillPlaintDelta(int levelIndex, DeltaFreshnessOld lcs)
        {
            if (!IDBathe(levelIndex)) return;
            ScorePure.Insert(levelIndex, lcs);
            OldByHypha();
        }

        public void ShrillDiverDelta(int levelIndex, DeltaFreshnessOld lcs)
        {
            Debug.Log("insert level after: " + levelIndex);
            if (!IDBathe(levelIndex)) return;
            if (levelIndex + 1 == ScorePure.Count)
            {
                ScorePure.Add(lcs);
                Debug.Log("add after : " + levelIndex);
            }
            else
            {
                ScorePure.Insert(levelIndex + 1, lcs);
                Debug.Log("insert after : " + levelIndex);
            }
            OldByHypha();
        }

        public void PuddleDelta(int levelIndex)
        {
            if (!IDBathe(levelIndex)) return;
#if UNITY_EDITOR
            PhilippineScreenHimself.DeleteResourceAsset(ScorePure[levelIndex]);
#endif
            ScorePure.RemoveAt(levelIndex);
            OldByHypha();
        }

        private bool IDBathe(int level)
        {
            return (ScorePure != null && ScorePure.Count > level && level >= 0);
        }

        #region Skip Levels Management
        /// <summary>
        /// 添加跳过关卡
        /// </summary>
        /// <param name="level">要跳过的关卡号</param>
        public void BatNeonDelta(int level)
        {
            if (BardValley == null)
                BardValley = new int[0];
            
            if (!BardValley.Contains(level))
            {
                BardValley = BardValley.Concat(new[] { level }).ToArray();
                BardValley = BardValley.OrderBy(l => l).ToArray(); // 保持有序
                OldByHypha();
            }
        }

        /// <summary>
        /// 移除跳过关卡
        /// </summary>
        /// <param name="level">要移除的跳过关卡号</param>
        public void PuddleNeonDelta(int level)
        {
            if (BardValley != null && BardValley.Contains(level))
            {
                BardValley = BardValley.Where(l => l != level).ToArray();
                OldByHypha();
            }
        }

        /// <summary>
        /// 清空所有跳过关卡
        /// </summary>
        public void CedarNeonValley()
        {
            if (BardValley != null)
            {
                BardValley = new int[0];
                OldByHypha();
            }
        }

        /// <summary>
        /// 检查关卡是否被跳过
        /// </summary>
        /// <param name="level">关卡号</param>
        /// <returns>是否被跳过</returns>
        public bool IDDeltaAtheist(int level)
        {
            if (BardValley == null || BardValley.Length == 0)
                return false;
            
            // 将关卡号转换为数组索引（减1）
            int levelIndex = level - 1;
            return BardValley.Contains(levelIndex);
        }

        /// <summary>
        /// 获取跳过关卡列表
        /// </summary>
        /// <returns>跳过关卡列表</returns>
        public int[] HowNeonValley()
        {
            return BardValley != null ? (int[])BardValley.Clone() : new int[0];
        }
        #endregion
    }
}

