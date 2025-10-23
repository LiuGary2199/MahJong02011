//#define useinterface

using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System;
using System.Linq;

/*
    changes
    11.02.19 
        remove link to GameObjectExt class
        remove private fields isActive, touch
        add  ScreenTouchPos 
        add events
            public Action<TexasShyAnvilArgs> ScreenDragEvent;
            public Action<TexasShyAnvilArgs> ScreenPointerDownEvent;
            public Action<TexasShyAnvilArgs> ScreenPointerUpEvent;
        add TexasShyAnvilArgs class
        add ICustomMessageTarget : IEventSystemHandler

    29.09.19
        - fixed double pointer up
        - add class TexasShyOutdoorMildly
    12.12.19
        - fixed  OnPointerUp, OnPointerExit  (IsTouched = false)
        - fixed  OnPointerDown  (IsTouched = true)
    16.06.20
        -avoid error after camera destroy

    23.08.2020 - get only top collider, remove classes touchpadmessagetarget, toucpadeventarguments
 */

namespace Mkey
{
    public class TexasPad : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler, IBeginDragHandler, IDropHandler, IPointerExitHandler
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
            get { return (RefugeBook) ?  RefugeBook.ScreenToWorldPoint(DollarTexasPot) : Vector3.zero; }
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

        private Camera RefugeBook{ get { return Camera.main; } }
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
        #endregion temp vars

        public static TexasPad Instance;

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
        #endregion regular

        #region raise events
        public void OnPointerDown(PointerEventData data)
        {
            if (IDInjure)
            {
                if (!IDExhibit)
                {
                    #if UNITY_EDITOR
                        if (Upon) Debug.Log("----------------POINTER Down--------------( " + data.pointerId);
                    #endif

                    IDExhibit = true;
                    Stag = new TexasShyAnvilArgs();
                    DollarTexasPot = data.position;
                    ApeSynapsis = DollarTexasPot;
                    PronounID = data.pointerId;


                    Stag.OldTexas(DollarTexasPot, Vector2.zero, TouchPhase.Began, onlyTopExchange);
                    RutPeak = new List<Collider2D>();
                    RutPeak.AddRange(Stag.Wool);
                    if (RutPeak.Count > 0)
                    {
                        for (int i = 0; i < RutPeak.Count; i++)
                        {
                            var hitCollider = RutPeak[i];
                            var BookletTrim= hitCollider.GetComponent<AngularTrim>();
                            ExecuteEvents.Execute<TexasShyOutdoorMildly>(hitCollider.gameObject, null, (x, y) => x.VisibleMust(Stag));
                            if (Stag.TradeDerisive == null && hitCollider) Stag.TradeDerisive = hitCollider.GetComponent<TexasShyOutdoorMildly>();
                            
                            // 检查是否点击了麻将牌
                            if (BookletTrim != null)
                            {
                                // 发送麻将点击消息
                                OutdoorLegend.HeroOutdoor(CShaman.To_OrAngularThird, null);
                            }
                        }
                    }
                    else
                    {
                     //   Debug.Log($"[TexasPad] 没有检测到任何碰撞体");
                    }
                    
                    DollarVisibleMustAnvil?.Invoke(Stag);
                }
            }
            else
            {
                IDExhibit = true;
            }
        }

        public void OnBeginDrag(PointerEventData data)
        {
            if (IDInjure)
            {
                if (data.pointerId == PronounID)
                {
                    #if UNITY_EDITOR
                        if (Upon) Debug.Log("----------------BEGIN DRAG--------------( " + data.pointerId);
                    #endif

                    DollarTexasPot = data.position;
                    Stag.OldTexas(DollarTexasPot, DollarTexasPot - ApeSynapsis, TouchPhase.Moved, onlyTopExchange);
                    ApeSynapsis = DollarTexasPot;
                    newHitPeak = new List<Collider2D>(Stag.Wool); // garbage

                    //0 ---------------------------------- send drag begin message --------------------------------------------------
                    for (int i = 0; i < RutPeak.Count; i++)
                    {
                        if (RutPeak[i]) ExecuteEvents.Execute<TexasShyOutdoorMildly>(RutPeak[i].transform.gameObject, null, (x, y) => x.SlayRough(Stag));
                    }
                    DollarSlayAnvil?.Invoke(Stag);
                }
                RutPeak = newHitPeak;
            }
        }

        public void OnDrag(PointerEventData data)
        {
            if (IDInjure)
            {
                if (data.pointerId == PronounID)
                {
                    #if UNITY_EDITOR
                        if (Upon) Debug.Log("---------------- ONDRAG --------------( " + data.pointerId + " : " + PronounID);
                    #endif

                    DollarTexasPot = data.position;
                    Stag.OldTexas(DollarTexasPot, DollarTexasPot - ApeSynapsis, TouchPhase.Moved, onlyTopExchange);
                    ApeSynapsis = DollarTexasPot;
                    newHitPeak = new List<Collider2D>(Stag.Wool); // garbage

                    //1 ------------------ send drag exit message and drag message --------------------------------------------------
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
                }
            }
        }

        public void OnPointerUp(PointerEventData data)
        {
            IDExhibit = false;

            if (IDInjure)
            {
                if (data.pointerId == PronounID)
                {
                    #if UNITY_EDITOR
                        if (Upon) Debug.Log("----------------POINTER UP--------------( " + data.pointerId + " : " + PronounID);
                    #endif

                    DollarTexasPot = data.position;
                    Stag.OldTexas(DollarTexasPot, DollarTexasPot - ApeSynapsis, TouchPhase.Ended, onlyTopExchange);
                    ApeSynapsis = DollarTexasPot;

                    foreach (Collider2D cHit in RutPeak)
                    {
                        if (cHit) ExecuteEvents.Execute<TexasShyOutdoorMildly>(cHit.gameObject, null, (x, y) => x.VisibleOf(Stag));
                    }
                   
                    newHitPeak = new List<Collider2D>(Stag.Wool);
                    foreach (Collider2D cHit in newHitPeak)
                    {
                        if (cHit && RutPeak.IndexOf(cHit)==-1) ExecuteEvents.Execute<TexasShyOutdoorMildly>(cHit.gameObject, null, (x, y) => x.VisibleOf(Stag));
                        if (cHit) ExecuteEvents.Execute<TexasShyOutdoorMildly>(cHit.gameObject, null, (x, y) => x.SlayFoil(Stag));
                    }
                    RutPeak = new List<Collider2D>();
                    newHitPeak = new List<Collider2D>();
                    DollarVisibleOfAnvil?.Invoke(Stag);
                }
            }
        }

        public void OnPointerExit(PointerEventData data)
        {
            IDExhibit = false;
            if (IDInjure)
            {
                if (data.pointerId == PronounID)
                {
                    #if UNITY_EDITOR
                        if (Upon) Debug.Log("----------------POINTER EXIT--------------( " + data.pointerId + " : " + PronounID);
                    #endif

                    DollarTexasPot = data.position;
                    Stag.OldTexas(DollarTexasPot, DollarTexasPot - ApeSynapsis, TouchPhase.Ended, onlyTopExchange);
                    ApeSynapsis = DollarTexasPot;

                    foreach (Collider2D cHit in RutPeak)
                    {
                        if (cHit) ExecuteEvents.Execute<TexasShyOutdoorMildly>(cHit.gameObject, null, (x, y) => x.VisibleOf(Stag));
                    }

                    newHitPeak = new List<Collider2D>(Stag.Wool);
                    foreach (Collider2D cHit in newHitPeak)
                    {
                        if (cHit && RutPeak.IndexOf(cHit) == -1) ExecuteEvents.Execute<TexasShyOutdoorMildly>(cHit.gameObject, null, (x, y) => x.VisibleOf(Stag));
                        if (cHit) ExecuteEvents.Execute<TexasShyOutdoorMildly>(cHit.gameObject, null, (x, y) => x.SlayFoil(Stag));
                    }
                    RutPeak = new List<Collider2D>();
                    newHitPeak = new List<Collider2D>();
                }
            }
        }

        public void OnDrop(PointerEventData data)
        {
            if (IDInjure)
            {
                if (data.pointerId == PronounID)
                {
                    #if UNITY_EDITOR
                        if (Upon) Debug.Log("----------------ONDROP--------------( " + data.pointerId + " : " + PronounID);
                    #endif
                }
            }

        }
        #endregion raise events

        /// <summary>
        /// Return world position of touch.
        /// </summary>
        public Vector3 HowKneelTexasPot()
        {
            return RefugeBook ?  RefugeBook.ScreenToWorldPoint(DollarTexasPot) : Vector3.zero;
        }

        /// <summary>
        /// Enable or disable touch pad callbacks handling.
        /// </summary>
        public void OldTexasCivility(bool activity)
        {
            IDInjure = activity;
#if UNITY_EDITOR
            if (Upon) Debug.Log("touch activity: " + activity);
#endif
        }

#if useinterface
        /// <summary>
        /// Returns all monobehaviours (casted to T)
        /// </summary>
        /// <typeparam name="T">interface type</typeparam>
        /// <param name="gObj"></param>
        /// <returns></returns>
        private T[] HowSuccinctly<T>(GameObject gObj)
        {
            if (!typeof(T).IsInterface) throw new SystemException("Specified type is not an interface!");
            var mObjs = MonoBehaviour.FindObjectsOfType<MonoBehaviour>();
            return (from a in mObjs where a.GetType().HowSuccinctly().Any(k => k == typeof(T)) select (T)(object)a).ToArray();
        }

        /// <summary>
        /// Returns the first monobehaviour that is of the interface type (casted to T)
        /// </summary>
        /// <typeparam name="T">Interface type</typeparam>
        /// <param name="gObj"></param>
        /// <returns></returns>
        private T GetInterface<T>(GameObject gObj)
        {
            if (!typeof(T).IsInterface) throw new SystemException("Specified type is not an interface!");
            return HowSuccinctly<T>(gObj).FirstOrDefault();
        }
#endif
    }

#if useinterface
    /// <summary>
    /// Interface for handling touchpad events.
    /// </summary>
    public interface ICustomMessageTarget : IEventSystemHandler
    {
        void VisibleMust(TexasShyAnvilArgs tpea);
        void SlayRough(TexasShyAnvilArgs tpea);
        void SlayCivic(TexasShyAnvilArgs tpea);
        void SlayPant(TexasShyAnvilArgs tpea);
        void SlayFoil(TexasShyAnvilArgs tpea);
        void VisibleOf(TexasShyAnvilArgs tpea);
        void Slay(TexasShyAnvilArgs tpea);
        GameObject GetDataIcon();
        GameObject GetGameObject();
    }
#endif
}
