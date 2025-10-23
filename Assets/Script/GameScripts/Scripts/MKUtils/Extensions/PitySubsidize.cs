using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
  10.06.2020 - first
   20.06.2020 - add text mesh
*/

namespace Mkey
{
    public static class PitySubsidize
    {
        public static void OldPity(Text text, string textString)
        {
            if (text) text.text = textString;
        }

        public static void OldPity(TextMesh text, string textString)
        {
            if (text) text.text = textString;
        }
    }
}