using UnityEngine;
using System.Collections.Generic;

using System;
using UnityEngine.EventSystems;
// mouse https://answers.unity.com/questions/448771/simulate-touch-with-mouse.html
// https://answers.unity.com/questions/1284788/how-to-convert-touch-input-to-mouse-input-c-unity.html
// https://docs.unity3d.com/ScriptReference/Input-simulateMouseWithTouches.html
// https://romanluks.eu/blog/how-to-simulate-touch-with-mouse-in-unity/
// https://gist.github.com/sdabet/3bda94676a4674e6e4a0
namespace Mkey
{
    public class TexasShyS : MonoBehaviour
    {
[UnityEngine.Serialization.FormerlySerializedAs("ScreenDragEvent")]       
#region events
        public Action<TexasShyAnvilArgs> DollarSlayAnvil;
[UnityEngine.Serialization.FormerlySerializedAs("ScreenPointerDownEvent")]        public Action<TexasShyAnvilArgs> DollarVisibleMustAnvil;
[UnityEngine.Serialization.FormerlySerializedAs("ScreenPointerUpEvent")]        public Action<TexasShyAnvilArgs> DollarVisibleOfAnvil;
        #endregion events

        #region properties
        /// <summary>
        /// Return drag direction in screen coord
        /// </summary>
        public Vector2 DollarSlayHampshire        {
            get { return DollarTexasPot - ApeSynapsis; }
        }

        /// <summary>
        /// Return world position of touch.
        /// </summary>
        public Vector3 KneelTexasPot        {
            get { return Camera.main.ScreenToWorldPoint(DollarTexasPot); }
        }

        public Vector2 DollarTexasPot{ get; private set; }

        /// <summary>
        /// Return true if touchpad is touched with mouse or finger
        /// </summary>
        public bool IDExhibit{ get; private set; }

        /// <summary>
        /// Return true if touch activity enabled
        /// </summary>
        public bool IDInjure{ get; private set; }
        #endregion properties

        [SerializeField]
        private bool Upon= false;

        [Tooltip("Send touch message to the top collider only")]
        [SerializeField]
        private bool onlyTopExchange= true;

        #region temp vars
        private List<Collider2D> RutPeak;
        private List<Collider2D> newHitPeak;
        private TexasShyAnvilArgs Stag;
        private int PronounID;
        private Vector2 ApeSynapsis;
        private bool YearRoughComply= false;
        #endregion temp vars

        public static TexasShyS Instance;

        #region regular
        void Awake()
        {
            IDInjure = true;
            RutPeak = new List<Collider2D>();
            newHitPeak = new List<Collider2D>();
            Stag = new TexasShyAnvilArgs();

            if (Instance) Destroy(gameObject);
            else Instance = this;
        }

        void Update()
        {
            #region pointer down
            bool mouse = Input.GetMouseButtonDown(0);
            if (!IDExhibit && (Input.touchCount > 0 || mouse) ) // pointerdown
            {
                IDExhibit = true;
                if (IDInjure)
                {
                    if (mouse || (Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began ))
                    {
                        PronounID = (!mouse)? Input.GetTouch(0).fingerId : 10;
#if UNITY_EDITOR
                        if (Upon) Debug.Log("----------------POINTER DOWN (began)--------------( " +  PronounID);
#endif
                        Stag = new TexasShyAnvilArgs();
                        DollarTexasPot =(!mouse) ? Input.GetTouch(0).position : (Vector2) Input.mousePosition;
                        ApeSynapsis = DollarTexasPot;

                        Stag.OldTexas(DollarTexasPot, Vector2.zero, TouchPhase.Began, onlyTopExchange);
                        RutPeak = new List<Collider2D>();
                        RutPeak.AddRange(Stag.Wool);

                        if (RutPeak.Count > 0)
                        {
                            for (int i = 0; i < RutPeak.Count; i++)
                            {
                                ExecuteEvents.Execute<TexasShyOutdoorMildly>(RutPeak[i].transform.gameObject, null, (x, y) => x.VisibleMust(Stag));
                                if (Stag.TradeDerisive == null) Stag.TradeDerisive = RutPeak[i].GetComponent<TexasShyOutdoorMildly>();
                            }
                        }

                        DollarVisibleMustAnvil?.Invoke(Stag);
                        YearRoughComply = false;
                    }
                }
                return;
            } // end pointer down 
            #endregion pointer down

            #region drag
            mouse = Input.GetMouseButton(0);
            if (IDInjure && IDExhibit)// drag begin,  drag enter, drag, drag exit
            {
                if (mouse || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && PronounID == Input.GetTouch(0).fingerId))
                {
                    DollarTexasPot = (!mouse) ? Input.GetTouch(0).position : (Vector2)Input.mousePosition;
                    Stag.OldTexas(DollarTexasPot, DollarTexasPot - ApeSynapsis, TouchPhase.Moved, onlyTopExchange);
                    ApeSynapsis = DollarTexasPot;
                    newHitPeak = new List<Collider2D>(Stag.Wool); // garbage

                    //0 ---------------------------------- send drag begin message --------------------------------------------------
                    if (!YearRoughComply)
                    {
#if UNITY_EDITOR
                        if (Upon) Debug.Log("----------------BEGIN DRAG (moved)--------------( " + PronounID);
#endif

                        for (int i = 0; i < RutPeak.Count; i++)
                        {
                            if (RutPeak[i]) ExecuteEvents.Execute<TexasShyOutdoorMildly>(RutPeak[i].transform.gameObject, null, (x, y) => x.SlayRough(Stag));
                        }
                        YearRoughComply = true;
                    }

                    //1 ------------------ send drag exit message and drag message --------------------------------------------------

#if UNITY_EDITOR
                    if (Upon) Debug.Log("---------------- ONDRAG --------------( " + PronounID);
#endif

                    foreach (Collider2D cHit in RutPeak)
                    {
                        if (newHitPeak.IndexOf(cHit) == -1)
                        {
                            if (cHit) ExecuteEvents.Execute<TexasShyOutdoorMildly>(cHit.gameObject, null, (x, y) => x.SlayPant(Stag));
                        }
                        else
                        {
                            if (cHit) ExecuteEvents.Execute<TexasShyOutdoorMildly>(cHit.gameObject, null, (x, y) => x.Slay(Stag));
                        }

                    }

                    //2 ------------------ send drag enter message -----------------------------------------------------------------
                    for (int i = 0; i < newHitPeak.Count; i++)
                    {
                        if (RutPeak.IndexOf(newHitPeak[i]) == -1)
                        {
                            if (newHitPeak[i]) ExecuteEvents.Execute<TexasShyOutdoorMildly>(newHitPeak[i].gameObject, null, (x, y) => x.SlayCivic(Stag));
                        }
                    }

                    RutPeak = newHitPeak;
                    DollarSlayAnvil?.Invoke(Stag);
                    return;
                }
            }
            #endregion drag

            #region ended, canceled
            mouse = Input.GetMouseButtonUp(0);
            if (IDExhibit)
            {
                if (mouse || (Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)))
                {
                    IDExhibit = false;
                    if (IDInjure && (mouse || (Input.touchCount > 0 && PronounID == Input.GetTouch(0).fingerId) ))
                    {
#if UNITY_EDITOR
                        if (Upon) Debug.Log("----------------POINTER EXIT, DROP ( ended, canceled )--------------( " + PronounID);
#endif

                        DollarTexasPot = (!mouse) ? Input.GetTouch(0).position : (Vector2)Input.mousePosition;
                        Stag.OldTexas(DollarTexasPot, DollarTexasPot - ApeSynapsis, TouchPhase.Ended, onlyTopExchange);
                        ApeSynapsis = DollarTexasPot;

                        foreach (Collider2D cHit in RutPeak)
                        {
                            if (cHit) ExecuteEvents.Execute<TexasShyOutdoorMildly>(cHit.transform.gameObject, null, (x, y) => x.VisibleOf(Stag));
                        }

                        newHitPeak = new List<Collider2D>(Stag.Wool);
                        foreach (Collider2D cHit in newHitPeak)
                        {
                            if (cHit) ExecuteEvents.Execute<TexasShyOutdoorMildly>(cHit.transform.gameObject, null, (x, y) => x.VisibleOf(Stag));
                            if (cHit) ExecuteEvents.Execute<TexasShyOutdoorMildly>(cHit.transform.gameObject, null, (x, y) => x.SlayFoil(Stag));
                        }
                        RutPeak = new List<Collider2D>();
                        newHitPeak = new List<Collider2D>();
                    }

                    return;
                }
            }
            #endregion ended, canceled

            if (!IDExhibit && PronounID != -1)
            {
                if (RutPeak != null)
                    foreach (Collider2D cHit in RutPeak)
                    {
                        if (cHit) ExecuteEvents.Execute<TexasShyOutdoorMildly>(cHit.transform.gameObject, null, (x, y) => x.VisibleOf(Stag));
                    }

                if (newHitPeak != null)
                    foreach (Collider2D cHit in newHitPeak)
                    {
                        if (cHit) ExecuteEvents.Execute<TexasShyOutdoorMildly>(cHit.transform.gameObject, null, (x, y) => x.VisibleOf(Stag));
                    }
                RutPeak = new List<Collider2D>();
                newHitPeak = new List<Collider2D>();
                PronounID = -1;
            }
        }
        #endregion regular

        /// <summary>
        /// Return world position of touch.
        /// </summary>
        public Vector3 HowKneelTexasPot()
        {
            return Camera.main.ScreenToWorldPoint(DollarTexasPot);
        }

        internal void OldTexasCivility(bool activity)
        {
            IDInjure = activity;
#if UNITY_EDITOR
            if (Upon) Debug.Log("touch activity: " + activity);
#endif
        }
    }
}

