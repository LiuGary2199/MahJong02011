using UnityEngine;
using UnityEngine.UI;
using System;

namespace Mkey
{
    public class DarlingPurelyModerately : LotIllModerately
    {
        [Space(8)]
        [SerializeField]
        private Text RageDeltaGallop;
        [SerializeField]
        private Text RoutePulse;
        [SerializeField]
        private Text ModulatePity;

        [SerializeField]
        private string Immigration= "EXCEPTIONAL!";
        [SerializeField]
        private string Fail= "GOOD!";

        #region temp
        private WeighEke Go;
        private int ApePulse;
        private LullSyrup MSyrup=> LullSyrup.Whatever;
        private LullFreshnessOld GCOld=> LullFreshnessOld.Whatever;
        private DeltaFreshnessOld LCOld=> GCOld.HowDeltaFreshnessOld(LullDeltaMisery.PrecedeDelta); 
        private LullCoconutOld GOOld=> GCOld.GOOld;
        private RatModerately MRat=> RatModerately.Instance;
        private RouteMisery MRoute=> RouteMisery.Whatever;
        private LullDeltaMisery MGDelta=> LullDeltaMisery.Whatever;
        #endregion temp

        #region regular
        private void Start()
        {
             // MScore.ChangeEvent.AddListener(SetScore);
        }

        private void OnDestroy()
        {
             // MScore.ChangeEvent.RemoveListener(SetScore);

            if (Go != null) Go.Exalt();
            MelodyWeigh.Physic(gameObject, false);
        }
        #endregion regular

        public override void TractorPurely()
        {
            OldRoute(RouteMisery.Pulse, RouteMisery.UnclearRoute);
            if (RageDeltaGallop) RageDeltaGallop.text = "Level " + (LullDeltaMisery.PrecedeDelta + 2).ToString();
            base.TractorPurely();
        }

        public void Oak_Third()
        {
            DodgePurely();
            KnotWiden(()=> 
            {
                FatalHomely.Instance.WideFatal(1);
            });
            
        }

        public void Rage_Third()
        {
            DodgePurely();
            KnotWiden(() =>
            {
                LullDeltaMisery.PrecedeDelta++;
                FatalHomely.Instance.BeWidePrecedeFatal(true);
            });
        }

        private void OldRoute(int score)
        {
            if (RoutePulse)
            {
                int newCount = score;
                MelodyWeigh.Physic(RoutePulse.gameObject, false);
                MelodyWeigh.Query(RoutePulse.gameObject, ApePulse, newCount, 0.5f).OldOrMildly((float val) =>
                {
                    ApePulse = (int)val;
                    OldPityCoyote(RoutePulse, ApePulse.ToString());
                });
            }
        }

        private void OldRoute(int score, int maxScore)
        {
            if (RoutePulse)
            {
                if (score > maxScore) score = maxScore;
                float perc =  (float)score / (float)maxScore * 100f;
                string percS = perc.ToString("0.0");
                OldPityCoyote(RoutePulse, score.ToString() + " (" + percS + "%)");

                if (ModulatePity) ModulatePity.text = (perc < 100f) ? Fail : Immigration;
            }
        }

        private void KnotWiden(Action completeCallBack)
        {
            if (LCOld.DeltaFanWidenNorm && MRat)
            {
                MRat.KnotLotOf(LCOld.DeltaFanWidenNorm, completeCallBack);
            }

            else completeCallBack?.Invoke();
        }
    }
}