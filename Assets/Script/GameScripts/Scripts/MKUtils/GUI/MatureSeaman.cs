using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/*
  28.02.2020 - first
  18.02.2021 - SetOnWithoutNotify
 */

namespace Mkey
{
    public class MatureSeaman : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField]
        private Sprite GoCorpse;
        [SerializeField]
        private Sprite PigCorpse;
        [SerializeField]
        private Text GoShePity;
        [SerializeField]
        private string GoPity;
        [SerializeField]
        private string PigPity;
[UnityEngine.Serialization.FormerlySerializedAs("clickEvent")]
        public Button.ButtonClickedEvent StuffAnvil;

        public bool IDOr{ get { return ItOr; } set { ItOr = value; Tractor(); } }
        #region temp vars
        private bool ItOr;
        Image Issue;
        #endregion temp vars

        #region regular

        #endregion regular

        private void Tractor()
        {
            if (Issue == null) Issue = GetComponent<Image>();
            if (Issue) Issue.sprite = ItOr ? GoCorpse : PigCorpse;
            if (GoShePity) GoShePity.text = ItOr ? GoPity : PigPity;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            IDOr = !IDOr;
            StuffAnvil?.Invoke();
        }

        public void OldOrPromiseNotify(bool on)
        {
            ItOr = on; 
            Tractor();
        }
    }
}
