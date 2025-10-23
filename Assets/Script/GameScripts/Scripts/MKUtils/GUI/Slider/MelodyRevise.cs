using System;
using UnityEngine;
using UnityEngine.UI;
/*
 13.01.19
    -add fillImage exist
 13.05.20
    - PRevise
  18.02.2021 - OnValueChanged;
 */

namespace Mkey
{
    [ExecuteInEditMode]
    public class MelodyRevise :  PRevise
    {
[UnityEngine.Serialization.FormerlySerializedAs("fillImage")]        public Image GulfReady;

        #region temp vars
        private RectTransform rtL;
        private RectTransform OnR;
        #endregion temp vars

        #region regular
        private void OnEnable()
        {
          
        }

        private void OnValidate()
        {
            GulfActive = Mathf.Clamp01(GulfActive);
        }

        private void Update()
        {
            if (!GulfReady) return;
            GulfReady.fillAmount = GulfActive;
        }
        #endregion regular

    }
}