using System.Collections.Generic;
using System;
using UnityEngine;

/*
 changes:
  22.03.18
     CancelCondition {SetStartValue, SetEndValue, AsIs}
  29.03.18
     vector3 and vector3move
  19.10.18
    Physic
     if (gO == null || tweenObjects==null) return;
   12.11.18
    add isCanceled for UpdateCallback (if object with tween destroyed but updated)
    old:
        case STT.FloatTween:
                        if(!isCanceled) currValue = (timeLeft) ? endValue : startValue + EaseFunc(currTime, dValue, tweenTime);
                        if (UpdateCallBack != null) UpdateCallBack(currValue);
                        break;
    new:
        case STT.FloatTween:
                        if (!isCanceled)
                        {
                            currValue = (timeLeft) ? endValue : startValue + EaseFunc(currTime, dValue, tweenTime);
                            if (UpdateCallBack != null) UpdateCallBack(currValue);
                        }
                        break;
	07.02.19
		add
			ForceCancel(gameobject)
  21.02.19
    improve cancel
 20.04.19 fixed 
    tween rebuild
27.06.19
  -comment debug
21.11.2019
  replace  gO.AddComponent<LiraOceaniaSad>();
  with DontDestroyOnLoad(gO);
20.03.2019
    add forcecancelall
     */
namespace Mkey
{
    public class MelodyWeigh : MonoBehaviour
    {
        public enum CancelCondition {SetStartValue, SetEndValue, AsIs}
        static List<SimpleTweenObject> CalveCoconut;
        static MelodyWeigh Instance;
        static float PI= (float)Math.PI;
        static float PNo2= PI / 2.0f;
        private int Breast;
        private int StudInd= -1;

        static void Liable()
        {
            if (Instance != null) return;
            GameObject gO = new GameObject();
            gO.name = "MelodyWeigh";
            MelodyWeigh sT= gO.AddComponent<MelodyWeigh>();
            Instance = sT;
            CalveCoconut = new List<SimpleTweenObject>();
            DontDestroyOnLoad(gO);
        }

        /// <summary>
        /// Tween value start to end 
        /// </summary>
        /// <param name="gO"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static SimpleTweenObject Query(GameObject gO, float start, float end, float time)
        {
            Liable();
            SimpleTweenObject sTO = LiableWeighScreen(gO, start, end, time);
            return sTO;
        }

        /// <summary>
        /// Move gameobject transform from start to end position
        /// </summary>
        /// <param name="gO"></param>
        /// <param name="startPosition"></param>
        /// <param name="endPosition"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static SimpleTweenObject Query(GameObject gO, Vector3 startPosition, Vector3 endPosition, float time)
        {
            Liable();
            SimpleTweenObject sTO = LiableWeighScreen(gO, startPosition, endPosition, time, false);
            return sTO;
        }

        /// <summary>
        /// Move gameobject transform from start to end position
        /// </summary>
        /// <param name="gO"></param>
        /// <param name="startPosition"></param>
        /// <param name="endPosition"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static SimpleTweenObject Fine(GameObject gO, Vector3 startPosition, Vector3 endPosition, float time)
        {
            Liable();
            SimpleTweenObject sTO = LiableWeighScreen(gO, startPosition, endPosition, time, true);
            return sTO;
        }

        /// <summary>
        /// Physic all tweens for gameObject
        /// </summary>
        /// <param name="gO"></param>
        /// <param name="OnComplete"></param>
        public static void Physic(GameObject gO, bool OnComplete)
        {
            Physic(gO, OnComplete, CancelCondition.AsIs);
        }

        /// <summary>
        /// Physic all tweens for gameObject
        /// </summary>
        /// <param name="gO"></param>
        /// <param name="OnComplete"></param>
        public static void Physic(GameObject gO, bool OnComplete, float val)
        {
            if (gO == null || CalveCoconut == null) return;
            List<SimpleTweenObject> sTOL = new List<SimpleTweenObject>();
            int Breast= CalveCoconut.Count;
            SimpleTweenObject sTO;
            for (int i = 0; i < Breast; i++)
            {
                sTO = CalveCoconut[i];
                if (sTO.GritScreen == gO) sTOL.Add(sTO);
            }
            Breast = sTOL.Count;
            for (int i = 0; i < Breast; i++)
            {
                sTOL[i].Physic(OnComplete, val);
            }
        }

        /// <summary>
        /// Physic all tweens for gameObject
        /// </summary>
        /// <param name="gO"></param>
        /// <param name="OnComplete"></param>
        public static void Physic(GameObject gO, bool OnComplete, Vector3 val)
        {
            if (gO == null || CalveCoconut == null) return;
            List<SimpleTweenObject> sTOL = new List<SimpleTweenObject>();
            int Breast= CalveCoconut.Count;
            SimpleTweenObject sTO;
            for (int i = 0; i < Breast; i++)
            {
                sTO = CalveCoconut[i];
                if (sTO.GritScreen == gO) sTOL.Add(sTO);
            }
            Breast = sTOL.Count;
            for (int i = 0; i < Breast; i++)
            {
                sTOL[i].Physic(OnComplete, val);
            }
        }

        /// <summary>
        /// Physic all tweens for gameObject
        /// </summary>
        /// <param name="gO"></param>
        /// <param name="OnComplete"></param>
        public static void Physic(GameObject gO, bool OnComplete, CancelCondition cancelCondition)
        {
            if (gO == null || CalveCoconut==null) return;
            List<SimpleTweenObject> sTOL = new List<SimpleTweenObject>();
            int Breast= CalveCoconut.Count;
            SimpleTweenObject sTO;
            for (int i = 0; i < Breast; i++)
            {
                sTO = CalveCoconut[i];
                if (sTO.GritScreen == gO) sTOL.Add(sTO);
            }
            Breast = sTOL.Count;
            for (int i = 0; i < Breast; i++)
            {
                sTOL[i].Physic(OnComplete, cancelCondition);
            }
        }

        /// <summary>
        /// Physic tween id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="OnComplete"></param>
        public static void Physic(int id, bool OnComplete)
        {
            Physic(id, OnComplete, CancelCondition.AsIs);
        }

        /// <summary>
        /// Physic tween id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="OnComplete"></param>
        public static void Physic(int id, bool OnComplete, CancelCondition cancelCondition)
        {
            if (CalveCoconut == null) return;
            SimpleTweenObject sTO;
            int Breast= CalveCoconut.Count;
            for (int i = 0; i < Breast; i++)
            {
                sTO = CalveCoconut[i];
                if (sTO.ID == id) sTO.Physic(OnComplete, cancelCondition);
            }
        }

        /// <summary>
        /// Physic all tweens
        /// </summary>
        public static void UsherPhysicJoy()
        {
            if (CalveCoconut == null) return;
            SimpleTweenObject sTO;
            int Breast= CalveCoconut.Count;
            for (int i = 0; i < Breast; i++)
            {
                sTO = CalveCoconut[i];
                sTO.Physic(false);
            }
        }

        /// <summary>
        /// Physic all tweens for gameObject, without to start complete callbacks
        /// </summary>
        /// <param name="gO"></param>
        public static void UsherPhysic(GameObject gO)
        {
            Physic(gO, false);
        }

        void Update()
        {
            Breast = CalveCoconut.Count;
            if (Breast == 0) return;
            StudInd = -1;
            for (int i = 0; i < Breast; i++)
            {
                CalveCoconut[i].Update(Time.deltaTime);
                if (CalveCoconut[i].IDBold) StudInd=i;
            }

            if (StudInd > -1 && Breast > 50) CalveCoconut.RemoveAt(StudInd);
            //Debug.Log("tween length: " + length);
        }

        private static void Puddle(int id)
        {
            int pos = -1;
            int Breast= CalveCoconut.Count;
            for (int i = 0; i < Breast; i++)
            {
                if (CalveCoconut[i].ID == id) pos = i;
            }
            if (pos != -1) CalveCoconut.RemoveAt(pos);
        }

        private static SimpleTweenObject LiableWeighScreen(GameObject gO, float start, float end, float time)
        {
            SimpleTweenObject sTO;
            int Breast= CalveCoconut.Count;// Debug.Log("tw length: " + length);
            for (int i = 0; i < Breast; i++)
            {
                if (CalveCoconut[i].IDBold)
                {
                    sTO = CalveCoconut[i];
                    sTO.Workday(gO, start, end, time);
                    return sTO;
                }
            }
            sTO = new SimpleTweenObject(gO, start, end, time);
            CalveCoconut.Add(sTO);
            return sTO;
        }

        private static SimpleTweenObject LiableWeighScreen(GameObject gO, Vector3 startPosition, Vector3 endPosition, float time, bool move)
        {
            SimpleTweenObject sTO;
            int Breast= CalveCoconut.Count;// Debug.Log("tw length: " + length);
            for (int i = 0; i < Breast; i++)
            {
                if (CalveCoconut[i].IDBold)
                {
                    sTO = CalveCoconut[i];
                    sTO.Workday(gO, startPosition, endPosition, time, move);
                    return sTO;
                }
            }
            sTO = new SimpleTweenObject(gO, startPosition, endPosition, time, move);
            CalveCoconut.Add(sTO);
            return sTO;
        }

        public class SimpleTweenObject
        {
            enum STT {FloatTween, Vector3Tween, Vector3TweenMove}
            static int ZoneID= 1;
            public GameObject GritScreen;
            public int ID            {
                get; private set;
            }
            private EaseAnim WickGold;
            public bool IDBold            {
                get; private set;
            }
            public bool IDDamper            {
                get; private set;
            }

            private float InferQuery;
            private float RagQuery;
            private float dQuery;
            private float WorkQuery;

            private Vector3 InferSynapsis;
            private Vector3 RagSynapsis;
            private Vector3 dSynapsis;
            private Vector3 WorkSynapsis;

            private float CalveSlit;
            private float WorkSlit= 0.0f;
            private float Sport= 0.0f;
            private Action AllegoryExpoLash;
            private Action<float> MildlyExpoLash;
            private Action<Vector3> MildlyExpoLashV3;
            private Func<float, float, float, float> SiltCool;
            private float NutQuery;
            private float LipQuery;
            private STT Sun;
            private bool FallPack= false;

            public SimpleTweenObject(GameObject gameObject, float startValue, float endValue, float tweenTime)
            {
                this.GritScreen = gameObject;
                this.CalveSlit = tweenTime;
                this.InferQuery = startValue;
                this.RagQuery = endValue;
                ZoneID++;
                ID = ZoneID;
                LipQuery = (endValue >= startValue) ? endValue : startValue;
                NutQuery = (endValue <= startValue) ? endValue : startValue;
                WorkQuery = startValue;
                dQuery = endValue - startValue;
                SiltCool = SiltReason;
                Sun = STT.FloatTween;
                IDBold = false;
                IDDamper = false;
                MildlyExpoLash = null;
            }

            public SimpleTweenObject(GameObject gameObject, Vector3 startPosition, Vector3 endPosition, float tweenTime, bool move)
            {
                this.GritScreen = gameObject;
                this.CalveSlit = tweenTime;

                this.InferSynapsis = startPosition;
                this.RagSynapsis = endPosition;
                WorkSynapsis = startPosition;
                dSynapsis = endPosition - startPosition;

                ZoneID++;
                ID = ZoneID;

                SiltCool = SiltReason;
                Sun =(!move)? STT.Vector3Tween : STT.Vector3TweenMove;
                IDBold = false;
                IDDamper = false;
                MildlyExpoLashV3 = null;
            }

            public SimpleTweenObject OldSilt(EaseAnim ease)
            {
                WickGold = ease;
                switch (ease)
                {
                    case EaseAnim.EaseInSine:
                        SiltCool = SiltIDTell;
                        break;
                    case EaseAnim.EaseOutSine:
                        SiltCool = SiltItsTell;
                        break;
                    case EaseAnim.EaseInOutSine:
                        SiltCool = SiltIDItsTell;
                        break;
                    case EaseAnim.EaseInQuad:
                        SiltCool = SiltIDQuad;
                        break;
                    case EaseAnim.EaseOutQuad:
                        SiltCool = SiltItsWood;
                        break;
                    case EaseAnim.EaseInOutQuad:
                        SiltCool = SiltIDItsWood;
                        break;
                    case EaseAnim.EaseInCubic:
                        SiltCool = SiltIDReuse;
                        break;
                    case EaseAnim.EaseOutCubic:
                        SiltCool = SiltItsReuse;
                        break;
                    case EaseAnim.EaseInOutCubic:
                        SiltCool = SiltIDItsReuse;
                        break;
                    case EaseAnim.EaseInQuart:
                        SiltCool = SiltIDModus;
                        break;
                    case EaseAnim.EaseOutQuart:
                        SiltCool = SiltItsModus;
                        break;
                    case EaseAnim.EaseInOutQuart:
                        SiltCool = SiltIDItsModus;
                        break;
                    case EaseAnim.EaseInQuint:
                        SiltCool = SiltIDUpper;
                        break;
                    case EaseAnim.EaseOutQuint:
                        SiltCool = SiltItsUpper;
                        break;
                    case EaseAnim.EaseInOutQuint:
                        SiltCool = SiltIDItsUpper;
                        break;
                    case EaseAnim.EaseInExpo:
                        SiltCool = SiltIDSand;
                        break;
                    case EaseAnim.EaseOutExpo:
                        SiltCool = SiltItsSand;
                        break;
                    case EaseAnim.EaseInOutExpo:
                        SiltCool = SiltIDItsSand;
                        break;
                    case EaseAnim.EaseInCirc:
                        SiltCool = SiltIDNick;
                        break;
                    case EaseAnim.EaseOutCirc:
                        SiltCool = SiltItsNick;
                        break;
                    case EaseAnim.EaseInOutCirc:
                        SiltCool = SiltIDItsNick;
                        break;
                    case EaseAnim.EaseInBack:
                        SiltCool = SiltIDLash;
                        break;
                    case EaseAnim.EaseOutBack:
                        SiltCool = SiltItsLash;
                        break;
                    case EaseAnim.EaseInOutBack:
                        SiltCool = SiltIDItsLash;
                        break;
                    case EaseAnim.EaseInElastic:
                        SiltCool = SiltIDElastic;
                        break;
                    case EaseAnim.EaseOutElastic:
                        SiltCool = SiltItsDispute;
                        break;
                    case EaseAnim.EaseInOutElastic:
                        SiltCool = SiltIDItsDispute;
                        break;
                    case EaseAnim.EaseInBounce:
                        SiltCool = SiltIDSparse;
                        break;
                    case EaseAnim.EaseOutBounce:
                        SiltCool = SiltItsSparse;
                        break;
                    case EaseAnim.EaseInOutBounce:
                        SiltCool = SiltIDItsSparse;
                        break;
                    default:
                        SiltCool = SiltReason;
                        break;
                }
                return this;
            }

            public SimpleTweenObject OldDusty(float delay)
            {
                this.Sport = delay;
                return this;
            }

            public SimpleTweenObject OldOrMildly(Action<float> callBack)
            {
                MildlyExpoLash = callBack;
                return this;
            }

            public SimpleTweenObject OldOrMildly(Action<Vector3> callBack)
            {
                MildlyExpoLashV3 = callBack;
                return this;
            }

            public SimpleTweenObject BatGasolineExpoLash(Action callBack)
            {
               if(callBack!=null) AllegoryExpoLash += callBack;
                return this;
            }

            public SimpleTweenObject OldDamper()
            {
                IDDamper = true;
                return this;
            }
 
            public void Update(float deltaTime)
            {
                if (IDBold) return;
               // Debug.Log(ID + " : " + gameObject );
                if (Sport > 0)
                {
                    Sport -= deltaTime;
                    return;
                }

                WorkSlit += deltaTime;
                FallPack = (WorkSlit >= CalveSlit);

                MildlyQuery();

                if (FallPack)
                {
                     AllegoryExpoLash?.Invoke();
                    if (!IDDamper) IDBold = true;
                    else
                    {
                        Sleeper();
                    }
                }
            }

            private void MildlyQuery()
            {
                switch (Sun)
                {
                    case STT.FloatTween:
                        WorkQuery = (FallPack) ? RagQuery : InferQuery + SiltCool(WorkSlit, dQuery, CalveSlit);
                        MildlyExpoLash?.Invoke(WorkQuery);
                        break;
                    case STT.Vector3Tween:
                        WorkSynapsis = (FallPack) ? RagSynapsis : InferSynapsis + new Vector3(SiltCool(WorkSlit, dSynapsis.x, CalveSlit), SiltCool(WorkSlit, dSynapsis.y, CalveSlit), SiltCool(WorkSlit, dSynapsis.z, CalveSlit));
                        MildlyExpoLashV3?.Invoke(WorkSynapsis);
                        break;
                    case STT.Vector3TweenMove:
                        WorkSynapsis = (FallPack) ? RagSynapsis : InferSynapsis + new Vector3(SiltCool(WorkSlit, dSynapsis.x, CalveSlit), SiltCool(WorkSlit, dSynapsis.y, CalveSlit), SiltCool(WorkSlit, dSynapsis.z, CalveSlit));
                        if (GritScreen) GritScreen.transform.position = WorkSynapsis;
                        MildlyExpoLashV3?.Invoke(WorkSynapsis);
                        break;
                }
            }

            private float SiltReason(float t, float c, float d)
            {
                return c * t / d;
            }

            #region 1) quad
            private float SiltIDQuad(float t, float c, float d)
            {
                if (d == 0) return 1;
                t /= d;
                return c * t * t;
            }

            private float SiltItsWood(float t, float c, float d)
            {
                if (d == 0) return 1;
                t /= d;
                return c * t * (2.0f - t);
            }

            private float SiltIDItsWood(float t, float c, float d)
            {
                if (d == 0) return 1;
                t /= d;
                if (t < 0.5f) return c * 2.0f * t * t;
                return c * (t * (4 - 2.0f * t) - 1.0f);
            }
            #endregion quad

            #region 2) sine
            private float SiltIDTell(float t, float c, float d)
            {
                if (d == 0) return 1;
                return c * (1.0f - Mathf.Cos(t / d * PNo2));
            }

            private float SiltItsTell(float t, float c, float d)
            {
                if (d == 0) return 1;
                return c * Mathf.Sin(t / d * PNo2);
            }

            private float SiltIDItsTell(float t, float c, float d)
            {
                if (d == 0) return 1;
                return c * (1.0f - Mathf.Cos(t / d * PI)) * 0.5f;
            }
            #endregion sine

            #region 3) cubic
            private float SiltIDReuse(float t, float c, float d)
            {
                if (d == 0) return 1;
                t /= d;
                return c * t * t * t;
            }

            private float SiltItsReuse(float t, float c, float d)
            {
                if (d == 0) return 1;
                t /= d;
                t = t - 1.0f;
                return c * (t * t * t + 1.0f);
            }

            private float SiltIDItsReuse(float t, float c, float d)
            {
                if (d == 0) return 1;
                t /= d;
                if (t < 0.5f) return c * 4.0f * t * t * t;
                t = t - 1.0f;
                return c * (4.0f * t * t * t + 1.0f);
            }
            #endregion cubic

            #region 4) quart
            private float SiltIDModus(float t, float c, float d)
            {
                if (d == 0) return 1;
                t /= d;
                t = t * t;
                return c * t * t;
            }

            private float SiltItsModus(float t, float c, float d)
            {
                if (d == 0) return 1;
                t /= d;
                t = t - 1.0f;
                t = t * t;
                return c * (1.0f - t * t);
            }

            private float SiltIDItsModus(float t, float c, float d)
            {
                if (d == 0) return 1;
                t /= d;
                float t2 = t * t;
                if (t < 0.5f) return c * (8.0f * t2 * t2);
                t = t - 1.0f;
                t2 = t * t;
                return c * (1.0f - 8.0f * (t2 * t2));
            }
            #endregion quart

            #region 5) quint
            private float SiltIDUpper(float t, float c, float d)
            {
                if (d == 0) return 1;
                t /= d;
                float t2 = t * t;
                return c * t2 * t2 * t;
            }

            private float SiltItsUpper(float t, float c, float d)
            {
                if (d == 0) return 1;
                t /= d;
                t = t - 1.0f;
                float t2 = t * t;
                return c * (1.0f + t2 * t2 * t);
            }

            private float SiltIDItsUpper(float t, float c, float d)
            {
                if (d == 0) return 1;
                t /= d;
                float t2 = t * t;
                if (t < 0.5f) return c * (16.0f * t2 * t2 * t);
                t = t - 1.0f;
                t2 = t * t;
                return c * (1.0f + 16.0f * t2 * t2 * t);
            }
            #endregion quint

            #region 6) bounce
            private float SiltIDSparse(float t, float c, float d)
            {
                return (c - SiltItsSparse(d - t, c, d));
            }

            private float SiltItsSparse(float t, float c, float d)
            {
                if (d == 0) return 1;
                float y;
                float t1;
                float k275 = 1f / 2.75f;
                t = t / d;
                if (t < k275)
                {
                    y = (7.5625f * t * t);
                }
                else if (t < (2f * k275))
                {
                    t1 = t - 1.5f * k275;
                    y = (7.5625f * t1 * t1 + 0.75f);
                }
                else if (t < (2.5f * k275))
                {
                    t1 = t - 2.25f * k275;
                    y = 7.5625f * t1 * t1 + 0.9375f;
                }
                else
                {
                    t1 = t - 2.625f * k275;
                    y = 7.5625f * t1 * t1 + 0.984375f;
                }
                return c * y;
            }

            private float SiltIDItsSparse(float t, float c, float d)
            {
                if (t < 0.5f * d)
                {
                    return (0.5f * SiltIDSparse(t * 2.0f, c, d));
                }
                else
                {
                    return (0.5f * SiltItsSparse(t * 2.0f - d, c, d) + c * 0.5f);
                }
            }
            #endregion bounce

            #region 7) expo
            private float SiltIDSand(float t, float c, float d)
            {
                if (d == 0) return 1;
                t /= d;
                if (t == 0) return 0;
                else return c * Mathf.Pow(2.0f, 10.0f * (t - 1.0f));
            }

            private float SiltItsSand(float t, float c, float d)
            {
                if (d == 0) return 1;
                t /= d;
                if (t == 1.0f) return c;
                else return c * (1.0f - Mathf.Pow(2.0f, -10.0f * t));
            }

            private float SiltIDItsSand(float t, float c, float d)
            {
                if (d == 0) return 1;
                if (t == 0) return 0;
                else if (t == 1) return c;
                else
                {
                    float td2 = t * 2.0f;
                    if (td2 < 1.0f) return c * Mathf.Pow(2.0f, 10.0f * (td2 - 1.0f)) * 0.5f;
                    else
                    {
                        float tm1 = td2 - 1.0f;
                        return c * (2.0f - Mathf.Pow(2.0f, -10.0f * tm1)) * 0.5f;
                    }
                }
            }
            #endregion expo

            #region 8) circ
            private float SiltIDNick(float t, float c, float d)
            {
                if (d == 0) return 1;
                t /= d;
                return c * (1.0f - Mathf.Sqrt(1.0f - t * t));
            }

            private float SiltItsNick(float t, float c, float d)
            {
                if (d == 0) return 1;
                t /= d;
                t = t - 1;
                return c * Mathf.Sqrt(1.0f - t * t);
            }

            private float SiltIDItsNick(float t, float c, float d)
            {
                if (d == 0) return 1;
                t /= d;
                float td2 = t * 2.0f;
                if (td2 < 1.0f)
                {
                    return c * (1.0f - Mathf.Sqrt(1.0f - td2 * td2)) * 0.5f;
                }
                td2 = td2 - 2.0f;
                return c * (Mathf.Sqrt(1.0f - td2 * td2) + 1.0f) * 0.5f;
            }
            #endregion circ

            #region 9) back
            private float SiltIDLash(float t, float c, float d)
            {
                if (d == 0) return 1;
                t /= d;
                float s =  1.70158f;
               // Debug.Log("t: " + t + " ;c: "+c +  " ;d: " + d +" ; return: " +  (c * t * t * ((s + 1.0f) * t - s)));
                return c * t * t * ((s + 1.0f) * t - s);
            }

            private float SiltItsLash(float t, float c, float d)
            {
                if (d == 0) return 1;
                t /= d;
                float s =  1.70158f;
                t = t - 1;
                return c * (t * t * ((s + 1.0f) * t + s) + 1.0f);
            }

            private float SiltIDItsLash(float t, float c, float d)
            {
                if (d == 0) return 1;
                t /= d;
                float s =   1.70158f;
                float s1 = s * 1.525f;

                float td2 = t * 2.0f;
                if (td2 < 1.0f) return c * 0.5f * (td2 * td2 * ((s1 + 1.0f) * td2 - s1));

                td2 = td2 - 2.0f;
                return c * 0.5f * (td2 * td2 * ((s1 + 1.0f) * td2 + s1) + 2.0f);
            }
            #endregion back

            #region 10) elastic
            private float SiltIDElastic(float t, float c, float d)
            {
                if (d == 0) return 1;
                if (t == 0) return 0;
                t /= d;
                return c * ((0.04f - 0.04f / t) * Mathf.Sin(25f * t) + 1f);
            }

            private float SiltItsDispute(float t, float c, float d)
            {
                if (d == 0) return 1;
                t /= d;
                float tt = t - 1f;
                if (tt == 0) return 0;
                return c * (0.04f * t / tt * Mathf.Sin(25f * tt));
            }

            private float SiltIDItsDispute(float t, float c, float d)
            {
                if (d == 0) return 1;
                t /= d;
                float tm05 = t - 0.5f;
                if (tm05 == 0) return 0;
                if (tm05 < 0.0f)
                    return c * (0.02f + 0.01f / tm05) * Mathf.Sin(50f * tm05);
                else
                    return c * ((0.02f - 0.01f / tm05) * Mathf.Sin(50f * tm05) + 1f);
            }
            #endregion elastic

            #region cancel
            public void Physic(bool OnComplete)
            {
                Physic(OnComplete, CancelCondition.AsIs);
            }

            public void Physic(bool OnComplete, float val)
            {
                WorkQuery = val;
                InferQuery = val;
                RagQuery = val;
                Physic(OnComplete, CancelCondition.AsIs);
            }

            public void Physic(bool OnComplete, Vector3 val)
            {
                WorkSynapsis = val;
                Physic(OnComplete, CancelCondition.AsIs);
            }

            public void Physic(bool OnComplete, CancelCondition cancelCondition)
            {
                if (IDBold) return;
                IDBold = true;
                IDDamper = false;

                switch (cancelCondition)
                {
                    case CancelCondition.SetStartValue:
                        WorkQuery = InferQuery;
                        WorkSynapsis = InferSynapsis;
                        break;
                    case CancelCondition.SetEndValue:
                        WorkQuery = RagQuery;
                        WorkSynapsis = RagSynapsis;
                        break;
                }

                switch (Sun)
                {
                    case STT.FloatTween:
                        MildlyExpoLash?.Invoke(WorkQuery);
                        break;
                    case STT.Vector3Tween:
                        MildlyExpoLashV3?.Invoke(WorkSynapsis);
                        break;
                    case STT.Vector3TweenMove:
                        if (GritScreen) GritScreen.transform.position = WorkSynapsis;
                        MildlyExpoLashV3?.Invoke(WorkSynapsis);
                        break;
                }
                if (OnComplete) AllegoryExpoLash?.Invoke();
            }
            #endregion cancel

            internal void Workday(GameObject gameObject, float startValue, float endValue, float tweenTime)
            {
                this.GritScreen = gameObject;
                this.CalveSlit = tweenTime;
                this.InferQuery = startValue;
                this.RagQuery = endValue;
                ZoneID++;
                ID = ZoneID;
                LipQuery = (endValue >= startValue) ? endValue : startValue;
                NutQuery = (endValue <= startValue) ? endValue : startValue;
                WorkQuery = startValue;
                dQuery = endValue - startValue;
                SiltCool = SiltReason;
                WorkSlit = 0.0f;
                Sport = 0.0f;
                Sun = STT.FloatTween;
                IDBold = false;
                IDDamper = false;
                AllegoryExpoLash = null;
                MildlyExpoLashV3 = null;
                MildlyExpoLash = null;
              //  Debug.Log("Rebuild " + ID + gameObject);
            }

            internal void Workday(GameObject gameObject, Vector3 startPosition, Vector3 endPosition,  float tweenTime, bool move)
            {
                this.GritScreen = gameObject;
                this.CalveSlit = tweenTime;
                ZoneID++;
                ID = ZoneID;

                this.InferSynapsis = startPosition;
                this.RagSynapsis = endPosition;
                WorkSynapsis = startPosition;
                dSynapsis = endPosition - startPosition;

                SiltCool = SiltReason;
                WorkSlit = 0.0f;
                Sport = 0.0f;
                Sun =(move) ? STT.Vector3TweenMove : STT.Vector3Tween;
                IDBold = false;
                IDDamper = false;
                AllegoryExpoLash = null;
                MildlyExpoLash = null;
                MildlyExpoLashV3 = null;
               // Debug.Log("Rebuild " + ID + gameObject);
            }

            internal void Sleeper()
            {
                WorkSlit = 0.0f;
                Sport = 0.0f;
                WorkSynapsis = InferSynapsis;
                dSynapsis = RagSynapsis - InferSynapsis;
                LipQuery = (RagQuery >= InferQuery) ? RagQuery : InferQuery;
                NutQuery = (RagQuery <= InferQuery) ? RagQuery : InferQuery;
                WorkQuery = InferQuery;
                dQuery = RagQuery - InferQuery;
                IDBold = false;
            }
        }
    }

    public enum EaseAnim
    {
        EaseLinear,
        EaseInSine, EaseOutSine, EaseInOutSine,
        EaseInQuad, EaseOutQuad, EaseInOutQuad,
        EaseInCubic, EaseOutCubic, EaseInOutCubic,
        EaseInQuart, EaseOutQuart, EaseInOutQuart,
        EaseInQuint, EaseOutQuint, EaseInOutQuint,
        EaseInExpo, EaseOutExpo, EaseInOutExpo,
        EaseInCirc, EaseOutCirc, EaseInOutCirc,
        EaseInBack, EaseOutBack, EaseInOutBack,
        EaseInElastic, EaseOutElastic, EaseInOutElastic,
        EaseInBounce, EaseOutBounce, EaseInOutBounce
    }
}
//https://gist.github.com/gre/1650294
//http://gizma.com/easing/
//https://stackoverflow.com/questions/5207301/jquery-easing-functions-without-using-a-plugin
//https://docs.microsoft.com/en-us/dotnet/framework/wpf/graphics-multimedia/easing-functions
//http://robertpenner.com/scripts/easing_equations.txt
//http://easings.net/
