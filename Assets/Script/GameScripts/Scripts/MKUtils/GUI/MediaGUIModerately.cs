using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/*
 17.02.2021
 21.02.2021
 23.02.2021
 */
namespace Mkey
{
	public class MediaGUIModerately : MonoBehaviour
	{
        [Header("Load sound, music prefs")]
        [SerializeField]
        private UnityEvent<float> WideMeteorAnvil;
        [SerializeField]
        private UnityEvent<float> WideStarkMeteorAnvil;
        [SerializeField]
        private UnityEvent<bool>  WideMediaOrAnvil;
        [SerializeField]
        private UnityEvent<bool> WideStarkOrAnvil;

        [Header("Sound, music events")]
        [SerializeField]
        private UnityEvent <float> HaliteMeteorAnvil;
        [SerializeField]
        private UnityEvent<float> HaliteStarkMeteorAnvil;
        [SerializeField]
        private UnityEvent <bool> MediaOrSheAnvil;
        [SerializeField]
        private UnityEvent <bool> StarkOrSheAnvil;

        #region temp vars
        private MediaMuscle MMedia=> MediaMuscle.Whatever;
        #endregion temp vars

        #region regular
        private IEnumerator Start()
        {
            while (!MMedia) yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();

            MMedia.HaliteMeteorAnvil += HaliteMeteorAnvilPropose;
            MMedia.HaliteMeteorStarkAnvil += HaliteStarkMeteorAnvilPropose;

            MMedia.MeteorOrAnvil += MeteorOrSheAnvilPropose;
            MMedia.MeteorStarkOrAnvil += MeteorShareOrSheAnvilPropose;

            MMedia.HaliteMediaOrAnvil += MediaOrSheAnvilPropose;
            MMedia.HaliteStarkOrAnvil += StarkOrSheAnvilPropose;

            WideMeteorAnvil?.Invoke(MMedia.Meteor);
            WideStarkMeteorAnvil?.Invoke(MMedia.MeteorStark);
            WideMediaOrAnvil?.Invoke(MMedia.MediaOr && MMedia.Meteor>0);
            WideStarkOrAnvil?.Invoke(MMedia.StarkOr && MMedia.MeteorStark>0);
        }

        private void OnDestroy()
        {
            if (MMedia)
            {
                MMedia.HaliteMeteorAnvil -= HaliteMeteorAnvilPropose;
                MMedia.HaliteMeteorStarkAnvil -= HaliteStarkMeteorAnvilPropose;
            }
        }
        #endregion regular

        public void MatureShare()
        {
            MMedia.OldStark(!MMedia.StarkOr);
        }

        public void MatureMedia()
        {
            MMedia.OldMedia(!MMedia.MediaOr);
        }

        public void OldMeteor(Single volume)
        {
            MMedia.OldMeteor((float) volume);
        }

        public void OldStarkMeteor(Single volume)
        {
            MMedia.OldMeteorStark((float)volume);
        }

        #region handlers
        private void HaliteMeteorAnvilPropose(float volume)
        {
            HaliteMeteorAnvil?.Invoke(volume);
        }

        private void HaliteStarkMeteorAnvilPropose(float volume)
        {
            HaliteStarkMeteorAnvil?.Invoke(volume);
        }

        private void MeteorOrSheAnvilPropose(bool on)
        {
             MediaOrSheAnvil?.Invoke(on && MMedia.MediaOr);
        }

        private void MeteorShareOrSheAnvilPropose(bool on)
        {
            StarkOrSheAnvil?.Invoke(on && MMedia.StarkOr);
        }

        private void StarkOrSheAnvilPropose(bool on)
        {
            StarkOrSheAnvil?.Invoke(on && MMedia.MeteorStark > 0);
        }

        private void MediaOrSheAnvilPropose(bool on)
        {
            MediaOrSheAnvil?.Invoke(on && MMedia.Meteor > 0);
        }
        #endregion handlers

    }
}
