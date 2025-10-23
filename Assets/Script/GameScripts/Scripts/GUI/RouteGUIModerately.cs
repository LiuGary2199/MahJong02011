using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Mkey
{
    public class RouteGUIModerately : MonoBehaviour
    {
        [SerializeField]
        private GameObject RouteSharp;

        [SerializeField]
        private Text BiomeActivePity;
        [SerializeField]
        private bool DullMildlyRoute;
        [SerializeField]
        private string MaracaRouteDepletion;
        [SerializeField]
        private bool DullAntiIfMildly= false;
        [SerializeField]
        private bool DullMildlyIDHardSpur= true;

        #region temp vars
        private TweenIntValue Calve;
        private LullSyrup MSyrup{ get { return LullSyrup.Whatever; } }
        private LullUnreachable GUnreachable{ get { return (MSyrup) ? MSyrup.gUnreachable : null; } }
        private RouteMisery MRoute=> RouteMisery.Whatever;

        private bool DullRoute= false;
        #endregion temp vars

        #region regular
        private IEnumerator Start()
        {
            while (!MSyrup)
            {
                yield return new WaitForEndOfFrame();
            }

           // if (ScoreComplete) ScoreComplete.SetActive(false);

            if (LullSyrup.GSpur == GameMode.Play)
            {
                //isScoreLevel = WController.ScoreTarget > 0;
                DullRoute = true; // ((isScoreLevel && showOnlyIfTarget) || (!showOnlyIfTarget));
                if (RouteSharp) RouteSharp.SetActive(DullRoute);
                if (DullRoute)
                {
                    // set player event handlers
                 //   MScore.ChangeEvent.AddListener(ChangeScoreHandler);
                    // targetScoreString = (isScoreLevel && showTargetScore) ? targetScoreSeparator + WController.ScoreTarget : "";
                    if (BiomeActivePity) Calve = new TweenIntValue(BiomeActivePity.gameObject, RouteMisery.Pulse, 0.3f, 0.7f, true, (s) => { if (this && BiomeActivePity) BiomeActivePity.text = HowRouteCoyote(s); });
                }
            }
#if UNITY_EDITOR
            else // edit mode
            {
                //while (!GConstructor)
                //{
                //    yield return new WaitForEndOfFrame();
                //}
                //MBoard.gConstructor.ChangeTargetScoreEvent += ChangeScoreTargetHandler;
            }
#endif
            Tractor();

        }

        private void OnDestroy()
        {
            if (DullRoute)
            {
                // remove player event handlers
                MRoute.HaliteAnvil.RemoveListener(HaliteRoutePropose);
            }
            if (BiomeActivePity) MelodyWeigh.Physic(BiomeActivePity.gameObject, false);
        }
        #endregion regular

        private void Tractor()
        {
            if (LullSyrup.GSpur == GameMode.Play)
            {
                if (BiomeActivePity) BiomeActivePity.text = HowRouteCoyote(RouteMisery.Pulse);
               // if (ScoreComplete && MBoard.WinContr != null) ScoreComplete.SetActive(WController.HasScoreTarget && (RouteMisery.Count >= WController.ScoreTarget));
            }
#if UNITY_EDITOR
            else
            {
               // if (scoreAmountText && GConstructor) scoreAmountText.text = GetScoreString(GConstructor.ScoreTarget);
            }
#endif
        }

        private string HowRouteCoyote(int score)
        {
            return  score.ToString(); // + targetScoreString : "0" + targetScoreString;
        }

        #region eventhandlers
        private void HaliteRoutePropose(int score)
        {
            if (Calve != null) Calve.Weigh(score, 100);
            else
            {
                if (BiomeActivePity) BiomeActivePity.text = HowRouteCoyote(score); 
            }

            // if (ScoreComplete && WController) ScoreComplete.SetActive(WController.HasScoreTarget && (score >= WController.ScoreTarget));
        }

        private void HaliteRouteMildlyPropose(int score)
        {
            if (BiomeActivePity) BiomeActivePity.text = HowRouteCoyote(score);
        }
        #endregion eventhandlers
    }
}