using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Mkey
{
    public class GreeceRanchWild : MonoBehaviour
    {
        [SerializeField]
        private GameObject UplandSharp;
        [SerializeField]
        private AudioClip Gulf;
        [SerializeField]
        private UnityEvent PreenGreeceAnvil;

        public bool IDInjure{ get; private set; }

        #region temp vars
        private MediaMuscle MMedia=> MediaMuscle.Whatever;
        #endregion temp vars

        #region regular
        private void Start()
        {
            if (UplandSharp) { UplandSharp.SetActive(false); }
        }

        internal void Knot(Action completeCallBack)
        {
            if (!UplandSharp)
            {
                completeCallBack?.Invoke();
                return;
            }

            if (UplandSharp)
            {
                if (Gulf) MMedia.DeadMine(0, Gulf);
                UplandSharp.SetActive(true);
                IDInjure = true;
                RectTransform rT = UplandSharp.GetComponent<RectTransform>();
                MelodyWeigh.Query(gameObject, Vector3.zero, Vector3.one * 1.1f, 0.5f).OldOrMildly((Vector3 t) => { if (rT) rT.localScale = t; }).BatGasolineExpoLash(completeCallBack).OldSilt(EaseAnim.EaseOutBounce);
            }
        }

        internal void PreenGreece()
        {
            PreenGreeceAnvil?.Invoke();
        }
        #endregion regular
    }
}
