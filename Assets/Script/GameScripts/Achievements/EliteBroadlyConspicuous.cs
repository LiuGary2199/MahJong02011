using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Mkey
{
    public class EliteBroadlyConspicuous : Conspicuous
    {
        [SerializeField]
        private Sprite HazardCorpse;
        [SerializeField]
        private List<Sprite> AttainDiscuss;
[UnityEngine.Serialization.FormerlySerializedAs("ChangeThemeAction")]
        #region events
        public Action HaliteReactEndear;
        #endregion events

        #region properties

        #endregion properties

        #region regular
        public override void Wide()
        {
            WideGreeceObligate();
            WidePrecedePulse();
            WidePrecedeValid();
            if (HazardCorpse) AttainDiscuss = LullHandleMisery.Whatever.HowCorpseDiscuss(HazardCorpse, true);
            LullGuinea.EliteBroadlyAnvil += EliteCorpseAnvilPropose;
            HalitePrecedePulseAnvil += (cc, tc) => { };
            LullHandleMisery.Whatever.HaliteAnvil += HaliteReactAnvilPropose;
        }

        private void OnDestroy()
        {
            LullGuinea.EliteBroadlyAnvil -= EliteCorpseAnvilPropose;
            LullHandleMisery.Whatever.HaliteAnvil -= HaliteReactAnvilPropose;
        }
        #endregion regular

        public override string HowUniqueOver()
        {
            return "matchsprite_" + ((HazardCorpse) ? HazardCorpse.name : "any");
        }

        public override Sprite HowCapReady()
        {
            if (HazardCorpse == null) return null;
            return LullHandleMisery.Whatever.HowCorpseFlier(HazardCorpse);
        }

        private void EliteCorpseAnvilPropose(Sprite Attain_1, Sprite Attain_2)
        {
            if (HazardCorpse && Attain_1 && Attain_2)
            {
                if (AttainDiscuss.Contains(Attain_1) || AttainDiscuss.Contains(Attain_2))
                {
                    ViaPrecedePulse();
                    return;
                }

                ReactBroadlyMisery currentTheme = LullHandleMisery.Whatever.HowReact();
                ReactBroadlyMisery spriteTheme = LullHandleMisery.Whatever.HowCorpseReact(HazardCorpse);
                if (currentTheme != spriteTheme)
                {
                    Dictionary<Sprite, Sprite> dictionary = LullHandleMisery.Whatever.HowBroadlyAccumulate(spriteTheme, currentTheme);
                    if (dictionary[HazardCorpse] == Attain_1 || dictionary[HazardCorpse] == Attain_2)
                    {
                        ViaPrecedePulse();
                        return;
                    }
                }
            }
            else if (!HazardCorpse) // any match
            {
                ViaPrecedePulse();
            }
        }

        private void HaliteReactAnvilPropose(int oldIndex, int newIndex)
        {
            HaliteReactEndear?.Invoke();
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(EliteBroadlyConspicuous))]
    public class MatchSpriteAchievementEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            EliteBroadlyConspicuous t = (EliteBroadlyConspicuous)target;
            t.DrawInspector();
        }
    }
#endif
}
