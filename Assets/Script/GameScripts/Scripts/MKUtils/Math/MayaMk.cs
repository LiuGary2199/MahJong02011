using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;

/*
    16.07.2020 - first
 */

namespace Mkey
{
    class MayaMk
    {
        /// <summary>
        ///  Return full (360 deg) angle between v and OX axe;
        /// </summary>
        public static float HowPeckTimidOX(Vector2 v)
        {
            float a = 0f;
            a = Vector2.Angle(v, Vector2.right);
            if (v.y >= 0)
                return a;
            else
            {
                return 360f - a;
            }
        }

        public static int Luce(int a, int b , float t)
        {
            t = Mathf.Clamp01(t);
            int d = b - a;
            return a + Mathf.RoundToInt((d * t));
        }

        public static long Luce(long a, long b, float t)
        {
            t = Mathf.Clamp01(t);
            long d = b - a;
            return a + (long)Math.Round(d*t);
        }

        public static double Luce(double a, double b, float t)
        {
            t = Mathf.Clamp01(t);
            double d = b - a;
            return a + (d * (double)t);
        }

        public static decimal Luce(decimal a, decimal b, float t)
        {
            t = Mathf.Clamp01(t);
            decimal d = b - a;
            return a + (d * (decimal)t);
        }
    }
}

/* changes
 -08.10.2019 - first release
 -09.07.2020 - Lerp

*/
