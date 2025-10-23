using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mkey
{
    public class AngularPertainPurelyModerately : LotIllModerately
    {
        [SerializeField]
        private Text EyelidOver;

        [SerializeField]
        private InputField ProbeHappy;

        [SerializeField]
        private Image DigestReady;

        [SerializeField]
        private Button MotherSeaman;

        //[SerializeField]
       // private ProfileAvatarButton  avatarButtonPrefab;

        [SerializeField]
        private RectTransform FlattenGrievance;

        #region temp vars


        private LullSyrup MSyrup=> LullSyrup.Whatever;
        private RatModerately MRat=> RatModerately.Instance;
        private LullFreshnessOld GCOld=> LullFreshnessOld.Whatever;
        private LullCoconutOld GOOld=> (GCOld) ? GCOld.GOOld : null;
        private LullDeltaMisery MGDelta=> LullDeltaMisery.Whatever;
        private GlandMisery MGland=> GlandMisery.Whatever;
        #endregion temp vars

        #region regular
        private void Start()
        {
            if (ProbeHappy)
            {
                ProbeHappy.gameObject.SetActive(false);
                ProbeHappy.onEndEdit.AddListener((name) =>
                {
                    UntoldSoulMisery.Whatever.OldPeckOver(name);
                    ProbeHappy.gameObject.SetActive(false);
                    if (MotherSeaman) MotherSeaman.gameObject.SetActive(true);
                    if (EyelidOver) EyelidOver.enabled = true;
                    OldAnalogyCivility(true);
                });
                ProbeHappy.enabled = false;
            }

            UntoldSoulMisery.Whatever.HaliteAnvil += TractorPeckOver;
            GoslingMisery.Whatever.HaliteAnvil += TractorUntoldCredit;

            TractorUntoldCredit(GoslingMisery.CreditMoody);
            TractorPeckOver(UntoldSoulMisery.PeckOver);
         //   CreateButtons();
        }

        private void OnDestroy()
        {
            UntoldSoulMisery.Whatever.HaliteAnvil -= TractorPeckOver;
            GoslingMisery.Whatever.HaliteAnvil -= TractorUntoldCredit;
        }
        #endregion regular

        public void Halite_Third()
        {
            if (!ProbeHappy) return;
            if (MotherSeaman) MotherSeaman.gameObject.SetActive(false);
            ProbeHappy.gameObject.SetActive(true);
            if (EyelidOver) EyelidOver.enabled = false;
            OldAnalogyCivility(false);

            ProbeHappy.enabled = true;
            ProbeHappy.interactable = true;
            ProbeHappy.ActivateInputField();
            ProbeHappy.Select();
            Debug.Log("change : " + ProbeHappy);
        }

        private void LiableWarrior()
        {
            //ProfileAvatarButton[] ts = buttonsContainer.GetComponentsInChildren<ProfileAvatarButton>();
            //foreach (var item in ts)
            //{
            //    DestroyImmediate(item.gameObject);
            //}
            //if (GoslingMisery.Instance.avatars.Length == 0) return;

            //for (int i = 0; i < GoslingMisery.Instance.avatars.Length; i++)
            //{
            //    ProfileAvatarButton t = Instantiate(avatarButtonPrefab, buttonsContainer);
            //    t.avatarImage.sprite = GoslingMisery.Instance.avatars[i];
            //    int index = i;
            //    t.index = index;
            //    t.button.onClick.AddListener(()=> { 
            //        GoslingMisery.Instance.SetIndex(index); 
            //    });
            //}
            //RefresButtons();
        }

        #region event handlers

        private void OldNssCredit(Sprite sprite)
        {
          // if (sprite && avatarImage) avatarImage.sprite = sprite;
        }

        private void PuddleCredit()
        {
            //if (avatarImage) avatarImage.sprite = defaultAvatar;
        }

        private void TractorPeckOver(string pName)
        {
            if (EyelidOver) EyelidOver.text = pName;
            if (ProbeHappy) ProbeHappy.text = UntoldSoulMisery.PeckOver;
        }

        private void TractorUntoldCredit(int index)
        {
            if (DigestReady) DigestReady.sprite = GoslingMisery.Whatever.HowCreditCorpse();
            QuiverWarrior();
        }

        private void QuiverWarrior()
        {
           // ProfileAvatarButton[] pButtons = buttonsContainer.GetComponentsInChildren<ProfileAvatarButton>();
            //int index = GoslingMisery.AvatarIndex;
            //foreach (var pB in pButtons)
            //{
            //    pB.CheckButton(pB.index == index);
            //}
        }
        #endregion event handlers 
    }
}