using UnityEngine;
using System.Collections.Generic;

/*
    01.02.2021 
 */

namespace Mkey
{
	public class KnotUnusedRatLotOf : MonoBehaviour
	{
        [SerializeField]
        private List<LotIllModerately> SkyIll;

        #region temp vars
        protected static RatModerately mRat;
        #endregion temp vars

        public void KnotUnusedLotOf()
        {
            if (mRat == null) mRat = FindObjectOfType<RatModerately>();
            if (mRat && SkyIll != null && SkyIll.Count > 0)
            {
                LotIllModerately rP = SkyIll.HowUnusedPot();
                if(rP) mRat.KnotLotOf(rP);
            }
        }
    }
}
