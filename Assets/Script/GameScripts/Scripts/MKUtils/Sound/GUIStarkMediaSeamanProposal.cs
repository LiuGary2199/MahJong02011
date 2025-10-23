using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/*
    30.06.2020 - first
    04.01.2020 - wait soun master
 */
namespace Mkey
{
    enum SoundMusic {Sound, Music}
	public class GUIStarkMediaSeamanProposal : MonoBehaviour
	{
        [SerializeField]
        private Image WeftOrShe;
        [SerializeField]
        private Text WellOrShe;
        [SerializeField]
        private Sprite MakeupCorpseOr;
        [SerializeField]
        private Sprite MakeupCorpseShe;
        [SerializeField]
        private Sprite WeftCorpseOr;
        [SerializeField]
        private Sprite WeftCorpseShe;
        [SerializeField]
        private string WellOr;
        [SerializeField]
        private string WellShe;

        [SerializeField]
        private SoundMusic BuyerItStark;

        #region temp vars
        private MediaMuscle MMedia=> MediaMuscle.Whatever; 
        #endregion temp vars

        #region regular
        private IEnumerator Start()
		{
            Button b= GetComponent<Button>();
            if (b)
            {
                b.onClick.RemoveListener(Seaman_Third);
                b.onClick.AddListener(Seaman_Third);
            }
            // wait sound master
            while (!MMedia) yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();

            MMedia.HaliteStarkOrAnvil += Tractor;
            MMedia.HaliteMediaOrAnvil += Tractor;
            Tractor();
		}

        private void OnDestroy()
        {
            if (MMedia)
            {
                MMedia.HaliteStarkOrAnvil -= Tractor;
                MMedia.HaliteMediaOrAnvil -= Tractor;
            }
        }
        #endregion regular

        private void Seaman_Third()
        {
            if (!MMedia) return;
            if(BuyerItStark == SoundMusic.Music) MMedia.OldStark(!MMedia.StarkOr);
            else if(BuyerItStark == SoundMusic.Sound) MMedia.OldMedia(!MMedia.MediaOr);
        }

        private void Tractor(bool on)
        {
            if (!MMedia) return;
            Image Issue= GetComponent<Image>();
            
            if (Issue) Issue.sprite = (on) ? MakeupCorpseOr : MakeupCorpseShe;
            if (WeftOrShe) WeftOrShe.sprite = (on) ? WeftCorpseOr : WeftCorpseShe;
            if (WellOrShe) WellOrShe.text = (on) ? WellOr : WellShe;
        }

        private void Tractor()
        {
            if (!MMedia) return;
            Image Issue= GetComponent<Image>();
            bool on = false;
            if (BuyerItStark == SoundMusic.Music)
                on = MMedia.StarkOr;
            else if (BuyerItStark == SoundMusic.Sound)
                on = MMedia.MediaOr;

            if (Issue) Issue.sprite = (on) ? MakeupCorpseOr : MakeupCorpseShe;
            if (WeftOrShe) WeftOrShe.sprite = (on) ? WeftCorpseOr : WeftCorpseShe;
            if (WellOrShe) WellOrShe.text = (on) ? WellOr : WellShe;
        }
    }
}
