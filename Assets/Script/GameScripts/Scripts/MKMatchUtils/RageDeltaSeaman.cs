using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Mkey
{
    public class RageDeltaSeaman : MonoBehaviour
    {
        [SerializeField]
        private int ShadeGallop= 1;
        [SerializeField]
        private Text ScoreGallop;
        [SerializeField]
        private string Spread= "Level ";

        #region temp vars
        private RatModerately MRat{ get { return RatModerately.Instance; } }
        private LullFreshnessOld GCOld{ get { return LullFreshnessOld.Whatever; } }
        private DeltaFreshnessOld LCOld{ get { return GCOld.HowDeltaFreshnessOld(LullDeltaMisery.PrecedeDelta); } }
        private LullCoconutOld GOOld{ get { return GCOld.GOOld; } }
        private int PearDelta= 0;
        #endregion temp vars

        #region regular
        private void Start()
        {
            int topPassedLevel = LullDeltaMisery.TopTalbotDelta;
            PearDelta = topPassedLevel + 1;
            if (ScoreGallop) ScoreGallop.text = Spread + (PearDelta+1).ToString();
        }
        #endregion regular

        public void Third()
        {
            LullDeltaMisery.PrecedeDelta  = PearDelta;
           // if (LifesHolder.Count <= 0 && !GCSet.UnLimited) { MGui.ShowMessage("Sorry!", "You have no lifes.", 1.5f, () => { MGui.ShowPopUpByDescription("lifeshop"); }); return; }
            Debug.Log("load scene : " + ShadeGallop+ " ;CurrentLevel: " + LullDeltaMisery.PrecedeDelta);
            // LullSyrup.showMission = true;
            if (FatalHomely.Instance) FatalHomely.Instance.WideFatal(ShadeGallop);
        }
    }
}