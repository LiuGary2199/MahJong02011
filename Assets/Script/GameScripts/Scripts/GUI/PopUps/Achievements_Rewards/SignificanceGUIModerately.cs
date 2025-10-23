using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mkey
{
	public class SignificanceGUIModerately : MonoBehaviour
	{
        [SerializeField]
        private Image RenterThemReady;
        [SerializeField]
        private LotIllModerately MultiplicityPUDismal;

        #region temp vars
        private RatModerately MRat{ get { return RatModerately.Instance; } }
        private AchievementsModerately AC{ get { return AchievementsModerately.Instance; } }
        #endregion temp vars

        #region regular
        private IEnumerator Start()
		{
            while (!AC) yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            AC.RollMildlyConsiderAnvil += Tractor;
            Tractor(AC.RollMildlyConsider);
        }
		
		private void OnDestroy()
        {
            if (AC) AC.RollMildlyConsiderAnvil -= Tractor;
        }
		#endregion regular

        public void Seaman_Third()
        {
            MRat.KnotLotOf(MultiplicityPUDismal);
        }

        private void Tractor(bool haveAchievement)
        {
            if (RenterThemReady) RenterThemReady.enabled = haveAchievement;
        }
	}
}
