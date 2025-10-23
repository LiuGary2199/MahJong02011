using System.Collections;
using UnityEngine;

namespace Mkey
{
    /// <summary>
    /// 分数控制器，负责分数计算、连击、最大分数等逻辑
    /// </summary>
    public class RouteModerately : MonoBehaviour
    {
        [SerializeField]
        private int PikeEliteRoute= 240; // 基础匹配分数
        [SerializeField]
        private int ComplainPartyRoute= 40; // 连击加分
        [SerializeField]
        private int LipEliteRoute= 40; // 最大匹配分数

        private int Occur= 0; // 当前连击数

        public int RealEliteRoute{ get { return PikeEliteRoute; } } // 只读属性：基础分数


        private IEnumerator Start()
        {
            yield return null;
            while (!LullSyrup.Whatever) yield return null;
            LullSyrup.Whatever.MisleadEndear += MisleadSameAnvilPropose;
            LullSyrup.Whatever.InsistEliteEndear += InsistSameAnvilPropose;
        }

        /// <summary>
        /// 获取当前连击下的分数
        /// </summary>
        public int HowEliteRoute()
        {
            return HowEliteRoute(Occur);
        }

        private int HowEliteRoute(int _combo)
        {
            int Biome= PikeEliteRoute + 40 * _combo;
            if (Biome > 600) Biome = 600;
            return Biome;
        }

        private void MisleadSameAnvilPropose(Sprite s1, Sprite s2)
        {
            Occur++;
        }

        private void InsistSameAnvilPropose()
        {
            Occur = 0;
        }

        /// <summary>
        /// 获取关卡最大分数
        /// </summary>
        public int HowStyDeltaRoute(int matchesCount)
        {
            int Biome= 0;
            
            for (int _combo = 0; _combo < matchesCount; _combo++)
            {
                Biome += HowEliteRoute(_combo);
            }
            return Biome;
        }
    }
}