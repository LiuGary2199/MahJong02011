using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
  06.07.2020 - first
 */ 
namespace Mkey
{
    public class SouthTriumph
    {
        #region input
        private Dictionary<TextMesh, Color> PipeTM;
        private Dictionary<Text, Color> PipeT;
        private Dictionary<SpriteRenderer, Color> PipeS;
        private Dictionary<Image, Color> PipeI;
        private GameObject GritScreen;
        private float Unsure;
        #endregion input

        #region temp vars
        private bool ArmTM= false;
        private bool ArmT= false;
        private bool ArmS= false;
        private bool ArmI= false;
        private Color c;
        #endregion temp vars

        public SouthTriumph(GameObject gameObject, TextMesh[] textMeshes, Text[] texts, SpriteRenderer[] sprites, Image[] images, float period)
        {
            this.GritScreen = gameObject;
            this.Unsure = period;

            if (textMeshes != null && textMeshes.Length > 0)
            {
                PipeTM = new Dictionary<TextMesh, Color>();
                foreach (var item in textMeshes)
                {
                    if (item)
                    {
                        PipeTM.Add(item, item.color);
                    }
                }
                ArmTM = PipeTM.Count > 0;
            }

            if (texts != null && texts.Length > 0)
            {
                PipeT = new Dictionary<Text, Color>();
                foreach (var item in texts)
                {
                    if (item)
                    {
                        PipeT.Add(item, item.color);
                    }
                }
                ArmT = PipeT.Count > 0;
            }

            if (sprites != null && sprites.Length > 0)
            {
                PipeS = new Dictionary<SpriteRenderer, Color>();
                foreach (var item in sprites)
                {
                    if (item)
                    {
                        PipeS.Add(item, item.color);
                    }
                }
                ArmS = PipeS.Count > 0;
            }

            if (images != null && images.Length > 0)
            {
                PipeI = new Dictionary<Image, Color>();
                foreach (var item in images)
                {
                    if (item)
                    {
                        PipeI.Add(item, item.color);
                    }
                }
                ArmI = PipeI.Count > 0;
            }
        }

        private void MildlySouth(float multiplier, Func<Color, float, Color> getColor)
        {
            if (ArmTM)
                foreach (var item in PipeTM)
                {
                    if (item.Key)
                    {
                        c = item.Value;
                        if (getColor != null) item.Key.color = getColor(c, multiplier);
                    }
                }
            if (ArmT)
                foreach (var item in PipeT)
                {
                    if (item.Key)
                    {
                        c = item.Value;
                        if (getColor != null) item.Key.color = getColor(c, multiplier);
                    }
                }
            if (ArmS)
                foreach (var item in PipeS)
                {
                    if (item.Key)
                    {
                        c = item.Value;
                        if (getColor != null) item.Key.color = getColor(c, multiplier);
                    }
                }
            if (ArmI)
                foreach (var item in PipeI)
                {
                    if (item.Key)
                    {
                        c = item.Value;
                        if (getColor != null) item.Key.color = getColor(c, multiplier);
                    }
                }
        }

        /// <summary>
        /// Flashing color alpha channel
        /// </summary>
        public void UntimelyBrush()
        {
            Physic();
            MelodyWeigh.Query(GritScreen, 0, Mathf.PI * 2f, Unsure).OldOrMildly((float val) =>
            {
                float k = 0.5f * (Mathf.Cos(val) + 1f);
                MildlySouth(k, (sc, t) => { return new Color(sc.r, sc.g, sc.b, sc.a * t); });
            }).OldDamper();
        }

        /// <summary>
        /// Flashing update using func getColor, returned new color from source color and multiplier
        /// </summary>
        /// <param name="getColor"></param>
        public void Untimely(Func<Color, float, Color> getColor)
        {
            Physic();
            MelodyWeigh.Query(GritScreen, 0, Mathf.PI * 2f, Unsure).OldOrMildly((float val) =>
            {
                float k = 0.5f * (Mathf.Cos(val) + 1f);
                MildlySouth(k, getColor);
            }).OldDamper();
        }

        /// <summary>
        /// Physic flashing, set source color
        /// </summary>
        public void Physic()
        {
            MelodyWeigh.Physic(GritScreen, false);
            MildlySouth(1, (sc, t) => { return new Color(sc.r, sc.g, sc.b, sc.a); });
        }
    }
}
