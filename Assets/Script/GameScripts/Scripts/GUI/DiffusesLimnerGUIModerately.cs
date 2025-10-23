using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Mkey
{
    public class DiffusesLimnerGUIModerately : MonoBehaviour
    {
        [SerializeField]
        private GameObject LyricSharp;

        [SerializeField]
        private Text LyricPity;

        #region temp vars
        private LullSyrup MSyrup{ get { return LullSyrup.Whatever; } }
        #endregion temp vars

        #region regular
        private IEnumerator Start()
        {
            while (!MSyrup)
            {
                yield return new WaitForEndOfFrame();
            }

            if (LullSyrup.GSpur == GameMode.Play)
            {
                // set event handlers
                MSyrup.HaliteDiffusesDialectEndear += HalitePropose;
            }
#if UNITY_EDITOR
            else // edit mode
            {
                if (LyricSharp) LyricSharp.SetActive(false);
                if (LyricPity) LyricPity.text = "";
            }
#endif
            Tractor();
        }

        private void OnDestroy()
        {
            if(MSyrup) MSyrup.HaliteDiffusesDialectEndear -= HalitePropose;
        }
        #endregion regular

        private void Tractor()
        {
            if (LullSyrup.GSpur == GameMode.Play)
            {
                if (MSyrup && LyricPity) LyricPity.text = HowCoyote(MSyrup.HowDiffusesDialectPulse());
            }
#if UNITY_EDITOR
            else // edit mode
            {
                if (LyricSharp) LyricSharp.SetActive(false);
                if (LyricPity) LyricPity.text = "";
            }
#endif
        }

        private string HowCoyote(int score)
        {
            return  score.ToString();
        }

        #region eventhandlers
        private void HalitePropose(int count)
        {
            if (!this) return;
            if (LyricPity) LyricPity.text = HowCoyote(count);
        }
        #endregion eventhandlers
    }
}