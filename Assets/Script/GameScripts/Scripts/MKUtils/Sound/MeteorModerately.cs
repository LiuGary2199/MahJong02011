using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 31.03.2020 - first
 17.02.2021 - add volumeTouchSlider, musicVolumeTouchSlider,  PRevise musicSlider
 */
namespace Mkey
{
	public class MeteorModerately : MonoBehaviour
	{
        [SerializeField]
        private PRevise BrowseRevise;
        [SerializeField]
        private PRevise RigorRevise;

        [SerializeField]
        private Slider BrowseTexasRevise;

        [SerializeField]
        private Slider RigorMeteorTexasRevise;

        #region temp vars
        private MediaMuscle MMedia{ get { return MediaMuscle.Whatever; } }
        #endregion temp vars
		
		#region regular
		private IEnumerator Start()
		{
            while (!MMedia) yield return new WaitForEndOfFrame();

            if (BrowseRevise) BrowseRevise.OldBrimActive(MMedia.Meteor);

            if (BrowseTexasRevise) 
            { 
                BrowseTexasRevise.value = MMedia.Meteor; 
            }
            if (RigorMeteorTexasRevise)
            {
                RigorMeteorTexasRevise.value = MMedia.MeteorStark; 
            }
          //  MSound.ChangeVolumeEvent += ChangeVolumeEventHandler;
		}

        private void OnDestroy()
        {
            if(MMedia) MMedia.HaliteMeteorAnvil -= HaliteMeteorAnvilPropose;
        }
        #endregion regular

        public void MeteorPlusSeaman_Third()
        {
            MMedia.OldMeteor(MMedia.Meteor + 0.1f);
        }

        public void MeteorStartSeaman_Third()
        {
            MMedia.OldMeteor(MMedia.Meteor - 0.1f);
        }

        public void OldMeteor(float volume)
        {
            MMedia.OldMeteor(volume);
        }

        public void OldStarkMeteor(float volume)
        {
            MMedia.OldMeteorStark(volume);
        }

        private void HaliteMeteorAnvilPropose(float volume)
        {
            if (BrowseRevise) BrowseRevise.OldBrimActive(volume);
        }
    }
}
