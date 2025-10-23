using UnityEngine;
using System.Collections;

/*
    30.10.2020 - first
    01.02.2021 - add  public void ShowSelfClosingMesssage()
 */

namespace Mkey
{
    [CreateAssetMenu]
    public class KnotTideOrderlyOutdoor : ScriptableObject
	{
        [SerializeField]
        private AirflowEdgeModerately LanternDismal;
        [SerializeField]
        private string Collect= "Succesfull!!!";
        [SerializeField]
        private string Lantern= "Product received successfull.";
        [SerializeField]
        private float DullSlit= 3f;

        #region temp vars
        protected static RatModerately mRat;
        #endregion temp vars

        /// <summary>
        /// Show message with close button
        /// </summary>
        public void KnotTerylene()
        {
            if (!mRat) mRat = FindObjectOfType<RatModerately>();
            if (mRat && LanternDismal)
            {
                mRat.KnotOutdoorWestWitDyDodgeSeaman(LanternDismal, Collect, Lantern, () => { }, null, null);
            }
            else if (mRat)
            {
                mRat.KnotOutdoorWestWitDyDodgeSeaman(Collect, Lantern, () => { }, null, null);
            }
        }

        /// <summary>
        /// Show message without close button
        /// </summary>
        public void KnotTideOrderlyTerylene()
        {
            if (!mRat) mRat = FindObjectOfType<RatModerately>();
            if (mRat && LanternDismal)
            {
                AirflowEdgeModerately wMC = mRat.KnotOutdoorWestWitDyDodgeSeaman(LanternDismal, Collect, Lantern, null, null, null);
                if (wMC) TweenExt.DustyEndear(wMC.gameObject, DullSlit, ()=> { if(wMC) wMC.DodgePurely(); });
            }
            else if (mRat)
            {
                mRat.KnotOutdoorWestWitDyDodgeSeaman(Collect, Lantern, () => { }, null, null);
            }
        }
    }
}
