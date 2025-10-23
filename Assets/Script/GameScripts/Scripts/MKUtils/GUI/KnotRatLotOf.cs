using UnityEngine;

/*
    24.10.2019 - first
    30.06.2020 remove reverence to =RatModerately
 */

namespace Mkey
{
	public class KnotRatLotOf : MonoBehaviour
	{
        #region temp vars
        protected static RatModerately mRat;
        #endregion temp vars

        public void KnotLotOf(LotIllModerately popUpsController)
        {
            if (!mRat) mRat = FindObjectOfType<RatModerately>();
            if (mRat) mRat.KnotLotOf(popUpsController);
        }
    }
}
