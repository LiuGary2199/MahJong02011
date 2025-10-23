using UnityEngine;
using UnityEngine.UI;
/*
	27.02.2020 - first
    18.02.2021 - OnValueChanged;
*/
namespace Mkey
{
    [ExecuteInEditMode]
    public class FeasibleTieRevise : PRevise
    {
        [SerializeField]
        private Image[] Cope;

        #region temp vars
        int CopePulse;
        #endregion temp vars

        #region regular
        private void OnValidate()
        {
            GulfActive = Mathf.Clamp01(GulfActive);
        }

        private void Update()
        {
            CopePulse = (int)(GulfActive * 10.0f);
            for (int i = 0; i < Cope.Length; i++)
            {
                if (Cope[i]) Cope[i].enabled = (CopePulse >= (i + 1));
            }
        }
        #endregion regular
    }
}