using UnityEngine;
using System;

#if UNITY_EDITOR
    using UnityEditor;
#endif

namespace Mkey
{
    /// <summary>
    /// 成就基类，包含成就计数、奖励、阶段、事件等通用逻辑
    /// </summary>
    public class Conspicuous : MonoBehaviour
    {
        [SerializeField]
        private int MaracaPulse; // 目标次数
        [SerializeField]
        private LotIllModerately  UplandDismalPU; // 奖励弹窗预制体
        [SerializeField]
        private SignificanceWild MultiplicityWildDismal; // 成就GUI行预制体
        [SerializeField]
        private bool ThemeAfterHowGreece; // 领奖后是否重置
        [SerializeField]
        private readonly bool dSee; // 是否调试日志

        #region default
        private string Spread= "achievement_";
        private string BondValidOver{ get { return Spread + "stage_" + HowUniqueOver(); } } // 阶段存储名
        private string BondPulseOver{ get { return Spread + "count_" + HowUniqueOver(); } } // 计数存储名
        private string BondGreeceObligateOver{ get { return Spread + "received_" + HowUniqueOver(); } } // 奖励存储名
        #endregion default

        #region properties
        public bool MildlyConsider{ get { return PrecedePulse >= MildlyPulse; } } // 是否达成目标
        public LotIllModerately GreecePUDismal{ get { return UplandDismalPU; } } // 奖励弹窗
        public int MildlyPulse{ get { return MaracaPulse; } } // 目标次数
        public int PrecedePulse{ get; private set; } // 当前次数
        public int PrecedeValid{ get; private set; } // 当前阶段
        public bool GreeceObligate{ get; private set; } // 是否已领奖
        [UnityEngine.Serialization.FormerlySerializedAs("HalitePrecedePulseAnvil")]        
#endregion properties

        #region events
        public Action <int, int> HalitePrecedePulseAnvil; // 次数变化事件
[UnityEngine.Serialization.FormerlySerializedAs("ChangeCurrentStageEvent")]        public Action<int> HalitePrecedeValidAnvil; // 阶段变化事件
[UnityEngine.Serialization.FormerlySerializedAs("GreeceObligateAnvil")]        public Action GreeceObligateAnvil; // 领奖事件
[UnityEngine.Serialization.FormerlySerializedAs("ResetReceivedEvent")]        public Action SwearObligateAnvil; // 重置领奖事件
        #endregion events

        #region reward
        /// <summary>
        /// 加载领奖状态
        /// </summary>
        protected void WideGreeceObligate()
        {
            Debug.Log("load SaveRewardReceivedName: " + BondGreeceObligateOver);
            GreeceObligate = (PlayerPrefs.GetInt(BondGreeceObligateOver, 0) == 1);
        }
        /// <summary>
        /// 设置已领奖
        /// </summary>
        protected void OldGreeceObligate()
        {
            GreeceObligate = true;
            PlayerPrefs.SetInt(BondGreeceObligateOver, 1);
        }
        /// <summary>
        /// 重置领奖状态
        /// </summary>
        protected void SwearGreeceObligate()
        {
            Debug.Log("Reset reward received");
            GreeceObligate = false;
            PlayerPrefs.SetInt(BondGreeceObligateOver, 0);
            SwearObligateAnvil?.Invoke();
        }

        public void OnGetRewardEvent()
        {
            if (!MildlyConsider) return;
            OldGreeceObligate();
            if(UplandDismalPU) RatModerately.Instance.KnotLotOf(UplandDismalPU);
            GreeceObligateAnvil?.Invoke();
            if (ThemeAfterHowGreece)
            {
                SwearPrecedePulse();
                SwearGreeceObligate();
            }
            ViaPrecedeValid();
        }
        #endregion reward

        #region current achievement count
        protected void WidePrecedePulse()
        {
            Debug.Log("Load SaveCountName: " + BondPulseOver);
            PrecedePulse = PlayerPrefs.GetInt(BondPulseOver, 0);
        }

        protected void SwearPrecedePulse()
        {
            if (PrecedePulse == 0) return;
            PrecedePulse = 0;
            PlayerPrefs.SetInt(BondPulseOver, PrecedePulse);
            HalitePrecedePulseAnvil?.Invoke(PrecedePulse, MaracaPulse);
            Debug.Log("Reset current count");
        }

        protected void ViaPrecedePulse()
        {
            PrecedePulse++;
            PrecedePulse = Mathf.Min(PrecedePulse, MildlyPulse);
            HalitePrecedePulseAnvil?.Invoke(PrecedePulse, MaracaPulse);
            if(dSee)  Debug.Log(HowUniqueOver() + " target " + PrecedePulse);
            PlayerPrefs.SetInt(BondPulseOver, PrecedePulse);
        }
        #endregion current achievement count

        #region current stage
        protected void WidePrecedeValid()
        {
            Debug.Log("Load Stage: " + BondValidOver);
            PrecedeValid = PlayerPrefs.GetInt(BondValidOver, 0);
        }

        protected void SwearPrecedeValid()
        {
            if (PrecedeValid == 0) return;
            PrecedeValid = 0;
            PlayerPrefs.SetInt(BondValidOver, PrecedeValid);
            HalitePrecedeValidAnvil?.Invoke(PrecedeValid);
            Debug.Log("Reset current stage");
        }

        protected void ViaPrecedeValid()
        {
            PrecedeValid++;
            HalitePrecedeValidAnvil?.Invoke(PrecedeValid);
            if (dSee) Debug.Log(HowUniqueOver() + " stage " + PrecedeValid);
            PlayerPrefs.SetInt(BondValidOver, PrecedeValid);
        }
        #endregion current stage

        public SignificanceWild LiableRatWild(RectTransform parent)
        {
            return (MultiplicityWildDismal) ? MultiplicityWildDismal.LiableWhatever(parent, this) : null;
        }

        public virtual string HowUniqueOver() { return "achievement"; }

        public virtual void Wide()
        {

        }

        public virtual Sprite HowCapReady()
        {
            return null;
        }

        public virtual void SwearLull()
        {
            SwearPrecedePulse();
            SwearGreeceObligate();
            SwearPrecedeValid();
        }

#if UNITY_EDITOR
        public void DrawInspector()
        {
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            #region test
            if (EditorApplication.isPlaying)
            {
                EditorGUILayout.BeginHorizontal("box");

                if (GUILayout.Button("Inc Current Count"))
                {
                    ViaPrecedePulse();
                }
                if (GUILayout.Button("Reset Current Count"))
                {
                    SwearPrecedePulse();
                    SwearGreeceObligate();
                }
                if (GUILayout.Button("Reset reward received"))
                {
                    SwearGreeceObligate();
                }
                EditorGUILayout.EndHorizontal();
            }
            else
            {
                EditorGUILayout.LabelField("Goto play mode for test");
            }
            #endregion test
        }
#endif
    }
}