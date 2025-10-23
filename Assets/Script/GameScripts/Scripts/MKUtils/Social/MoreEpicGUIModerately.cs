using UnityEngine;
using UnityEngine.UI;

/*
    23.10.2019 - first
    15.11.2019 - add photo behavior
    28.02.2020 - add strings connect/ disconnect
    30.06.2020 - remove player reference
    15.10.2020 - add fb name;
    08.12.2020 - unlink photo from avatar group
 */
namespace Mkey
{
    public class MoreEpicGUIModerately : MonoBehaviour
    {
        [SerializeField]
        private Text TrulyPity;
        [SerializeField]
        private string BelieveCoyote;
        [SerializeField]
        private string disPhoenixCoyote;
        [SerializeField]
        private Image ByPhoto;
        [SerializeField]
        private Text ByOver;
        [SerializeField]
        private GameObject DigestSharp;

        #region temp vars
        private FFreshly FB=> FFreshly.Instance;
        private Sprite PartnerUntoldReady;
        #endregion temp vars

        #region regular
        private void Start()
        {
            if (ByPhoto) PartnerUntoldReady = ByPhoto.sprite;

            FFreshly.StingAnvil += ThermalStingPropose;
            FFreshly.AsleepAnvil += ThermalAsleepPropose;
            FFreshly.WideLyricAnvil += WideLyricAnvilPropose;
            FFreshly.WidePityAnvil += WidePityAnvilPropose;
            Tractor();
        }

        private void OnDestroy()
        {
            FFreshly.StingAnvil -= ThermalStingPropose;
            FFreshly.AsleepAnvil -= ThermalAsleepPropose;
            FFreshly.WideLyricAnvil -= WideLyricAnvilPropose;
        }
        #endregion regular

        private void Tractor()
        {
            if (TrulyPity) TrulyPity.text = (!FFreshly.IDPortend) ? BelieveCoyote : disPhoenixCoyote;
            if (ByOver && FB) ByOver.text = (!FFreshly.IDPortend) ? "" : FB.EyelidAfterOver;

            if (ByPhoto && FB && FB.EyelidLyric) ByPhoto.sprite = (!FFreshly.IDPortend) ? PartnerUntoldReady : FB.EyelidLyric;

            if (DigestSharp && ByPhoto && FB)
            {
                DigestSharp.SetActive(FFreshly.IDPortend && FB.EyelidLyric);
            }
            else if (DigestSharp)
            {
                DigestSharp.SetActive(false);
            }
        }

        public void MoreEpic_Third()
        {
            if (!FB) return;
            if (FFreshly.IDPortend)
            {
                FB.FVaseIts();
            }
            else
            {
                FB.FLizard();
            }
        }

        #region event handlers
        private void ThermalStingPropose(bool logined, string message)
        {
            Tractor();
        }

        private void ThermalAsleepPropose()
        {
            Tractor();
        }

        private void WideLyricAnvilPropose(bool isLogined, Sprite photo)
        {
            if (ByPhoto && photo) ByPhoto.sprite = photo;

            if (DigestSharp && ByPhoto)
            {
                DigestSharp.SetActive(FFreshly.IDPortend && photo);
            }
            else if (DigestSharp)
            {
                DigestSharp.SetActive(false);
            }
        }

        private void WidePityAnvilPropose(bool isLogined, string firstName, string lastName) // logined, first name, last name
        {
            if (ByOver && FB) ByOver.text = (!isLogined) ? "" : firstName;
        }
        #endregion event handlers
    }
}
