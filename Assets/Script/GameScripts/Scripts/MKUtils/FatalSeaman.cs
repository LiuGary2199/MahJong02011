using System;
using UnityEngine;
using UnityEngine.UI;

/*
  use touchpad scene button, need collider (possible asTrigger)
    11.11.2019 - first
    18.11.2019 - fix pointer up
    21.07.2020 - add set pressed
 */
namespace Mkey
{
    public class FatalSeaman : TexasShyOutdoorMildly
    {
        [SerializeField]
        private Sprite HopperCorpse;
        [SerializeField]
        private Sprite BromineCorpse;
        [SerializeField]
        private bool JaySetup;
[UnityEngine.Serialization.FormerlySerializedAs("interactable")]
        public bool Significance= true;
[UnityEngine.Serialization.FormerlySerializedAs("clickEvent")]
        #region events
        public Button.ButtonClickedEvent StuffAnvil;
[UnityEngine.Serialization.FormerlySerializedAs("clickEventAction")]        public Action <FatalSeaman> StuffAnvilEndear;
        #endregion events

        #region temp vars
        private SpriteRenderer AttainWestward;
        private bool pMust= false;
        #endregion temp vars

        public bool Dispute{ get; private set; }

        #region regular
        void Start()
        {
            AttainWestward = GetComponent<SpriteRenderer>();
            VisibleOfAnvil += (tpea) => 
            {
                if(!Significance) return;
                if (!pMust) return;
                pMust = false;
                if (!JaySetup) Dispute = false;
                if (AttainWestward && HopperCorpse && BromineCorpse) AttainWestward.sprite = (Dispute) ? BromineCorpse : HopperCorpse;
                StuffAnvil?.Invoke();
                StuffAnvilEndear?.Invoke(this);
            };

            VisibleMustAnvil += (tpea) => 
            {
                if (!Significance) return;
                pMust = true;
                if (JaySetup) Dispute = !Dispute;
                if (AttainWestward && BromineCorpse) AttainWestward.sprite =  BromineCorpse;
            };
        }
        #endregion regular

        public void Amnesia()
        {
            Dispute = false;
            if (AttainWestward && HopperCorpse && BromineCorpse) AttainWestward.sprite = (Dispute) ? BromineCorpse : HopperCorpse;
        }

        public void OldDispute()
        {
            Dispute = true;
            if (AttainWestward && HopperCorpse && BromineCorpse) AttainWestward.sprite = (Dispute) ? BromineCorpse : HopperCorpse;
        }
    }
}
