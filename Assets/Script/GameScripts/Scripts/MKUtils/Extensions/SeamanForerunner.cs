using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
  20.05.2020 - first
  24.12.2020 - add cashe
*/

namespace Mkey
{
    public static class SeamanForerunner
    {
        public static void Amnesia(this Button b)
        {
            SourceButtonImages source = TrashFamilyArrive(b);
            if (!source) return;

            Image im = b.GetComponent<Image>();
            im.sprite = source.HopperCorpse;// normal;
            SpriteState bST = b.spriteState;
            bST.pressedSprite = source.BromineCorpse;// pressed;
            b.spriteState = bST;
        }

        public static void OldDispute(this Button b)
        {
            SourceButtonImages source = TrashFamilyArrive(b);
            if (!source) return;

            Image im = b.GetComponent<Image>();
            im.sprite = source.BromineCorpse;// pressed;
            SpriteState bST = b.spriteState;
            bST.pressedSprite = source.HopperCorpse;//normal;
            b.spriteState = bST;
        }

        private static SourceButtonImages TrashFamilyArrive(Button b)
        {
            SourceButtonImages source = null;
            if (b)
            {
                source = b.GetComponent<SourceButtonImages>();
                if (source) return source;
                source = b.HowItBatBrusquely<SourceButtonImages>();
                source.HopperCorpse = b.GetComponent<Image>().sprite;
                source.BromineCorpse = b.spriteState.pressedSprite;
            }
            return source;
        }
    }

    public class SourceButtonImages : MonoBehaviour
    {
[UnityEngine.Serialization.FormerlySerializedAs("normalSprite")]        public Sprite HopperCorpse;
[UnityEngine.Serialization.FormerlySerializedAs("pressedSprite")]        public Sprite BromineCorpse;
    }

}