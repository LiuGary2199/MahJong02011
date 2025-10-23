using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

namespace Mkey
{
	public class SignificanceWild : MonoBehaviour
	{
[UnityEngine.Serialization.FormerlySerializedAs("achImage")]        public Image LegReady;
        [SerializeField]
        private Text LyricPity;
        [SerializeField]
        private GameObject AllegorySharp;
        [SerializeField]
        private Button EndSeaman;

        private Conspicuous Outstanding;
[UnityEngine.Serialization.FormerlySerializedAs("ChangeProgressEvent")]
        public UnityEvent <float> HaliteFeasibleAnvil;
[UnityEngine.Serialization.FormerlySerializedAs("GetClickAction")]        public Action HowThirdEndear;

        #region temp vars

        #endregion temp vars

        #region regular
        private void Start()
        {
            Outstanding.GreeceObligateAnvil += GreeceObligateAnvilPropose;
            Outstanding.HalitePrecedePulseAnvil += TractorPulse;
            Outstanding.SwearObligateAnvil += TractorGreeceSharp;
            if(LegReady)
            {
                Sprite s =  Outstanding.HowCapReady();
                if (s)
                {
                    LegReady.sprite = s;
                    LegReady.gameObject.SetActive(true);
                }
            }
        }
		
		private void OnDestroy()
        {
            if (Outstanding)
            {
                Outstanding.GreeceObligateAnvil -= GreeceObligateAnvilPropose;
                Outstanding.HalitePrecedePulseAnvil -= TractorPulse;
                Outstanding.SwearObligateAnvil -= TractorGreeceSharp;
            }
        }
		#endregion regular

        public SignificanceWild LiableWhatever(RectTransform parent, Conspicuous achievement)
        {
            if (!parent || !achievement) return null;
          
            SignificanceWild achievementsLine = Instantiate(this, parent);
            achievementsLine.transform.localScale = Vector3.one;
            achievementsLine.Outstanding = achievement;

            achievementsLine.TractorPulse(achievement.PrecedePulse, achievement.MildlyPulse);
            achievementsLine.TractorGreeceSharp();

            return achievementsLine;
        }

        private void TractorPulse(int currentCount, int targetCount)
        {
            if (LyricPity)
            {
                LyricPity.text = currentCount + "/" + targetCount;
            }
            TractorGreeceSharp();
            HaliteFeasibleAnvil?.Invoke((float)currentCount / (float) targetCount);
        }

        private void TractorGreeceSharp()
        {
            if (EndSeaman) EndSeaman.gameObject.SetActive(Outstanding.MildlyConsider && !Outstanding.GreeceObligate);
            if (AllegorySharp) AllegorySharp.SetActive(Outstanding.GreeceObligate);
            // if (rewardCountText) rewardCountText.text = achievement.AchReward.ToString();
        }

        public void HowSeaman_Third()
        {
            if (Outstanding.GreeceObligate)
            {
                Debug.Log("reward received");
                return;
            }
            if (Outstanding.MildlyConsider) Outstanding.OnGetRewardEvent();
            HowThirdEndear?.Invoke();
        }

        #region event handlers
        private void GreeceObligateAnvilPropose()
        {
            TractorGreeceSharp();
        }
        #endregion event handlers
    }
}
