using System;
using UnityEngine;
using UnityEngine.Events;
/*
    01.04.2021
    19.05.2021 add OnDestroy()
    24.05.2021 - SetCurrentEvent;
 */

namespace Mkey
{
    public class RatGamma : MonoBehaviour
    {
[UnityEngine.Serialization.FormerlySerializedAs("navi")]        public GameObject Wing;
        public RectTransform GammaRT=> (!Valve) ? Valve = GetComponent<RectTransform>() : Valve;
        public RatGamma Wary{ get; set; }
        public RatGamma Rage{ get; set; }
[UnityEngine.Serialization.FormerlySerializedAs("SetCurrentEvent")]
        public UnityEvent <bool> OldPrecedeAnvil;
        #region temp vars
        private RectTransform Valve;
        #endregion temp vars


        private void OnDestroy()
        {
            if (gameObject) MelodyWeigh.Physic(GammaRT.gameObject, false) ;
        }

        public float Media=> (GammaRT) ? GammaRT.rect.width : 0;

        public Vector2 TranquilSynapsis=> (GammaRT) ? GammaRT.anchoredPosition : Vector2.zero;

        public void Fine(Vector2 dPosition, float time, float delay, EaseAnim ease, Action completeCallBack)
        {
            if (!GammaRT)
            {
                completeCallBack?.Invoke();
                return;
            }

            Vector2 cPos = GammaRT.anchoredPosition;
            MelodyWeigh.Query(GammaRT.gameObject, cPos, cPos + dPosition, time).OldOrMildly((pos) =>
            {
                if (GammaRT) GammaRT.anchoredPosition = pos;
            })
                .OldDusty(delay)
                .OldSilt(ease)
                .BatGasolineExpoLash(completeCallBack);
        }

        public float HowComaDyRage()
        {
            return (GammaRT && Rage != null) ? (Media + Rage.Media) / 2f : 0;
        }

        public float HowComaDyWary()
        {
            return (GammaRT && Wary != null) ? (Media + Wary.Media) / 2f : 0;
        }

        public void OldTranquilSynapsis(Vector2 aPosition)
        {
            if (GammaRT) GammaRT.anchoredPosition = aPosition;
        }
    }
}