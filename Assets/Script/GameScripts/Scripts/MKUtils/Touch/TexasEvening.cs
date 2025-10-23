using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Collections;

namespace Mkey
{
    /// <summary>
    /// 触摸管理器，负责处理拖拽、点击、跟随、触摸事件等逻辑，支持移动端和PC端
    /// </summary>
    public class TexasEvening : TexasShyOutdoorMildly, IPointerExitHandler
    {
[UnityEngine.Serialization.FormerlySerializedAs("dlog")]        public bool Upon= false; // 是否输出调试日志
        public static TexasEvening Instance; // 单例
[UnityEngine.Serialization.FormerlySerializedAs("PointerUpObject")]        public Transform VisibleOfScreen; // 抬起时的对象
[UnityEngine.Serialization.FormerlySerializedAs("FirstObject")]        public Transform AfterScreen; // 当前可拖拽对象
[UnityEngine.Serialization.FormerlySerializedAs("CanDrag")]        //{
        //    get; private set;
        //}

        public bool OilSlay= false; // 是否允许拖拽
[UnityEngine.Serialization.FormerlySerializedAs("MinDragReached")]        public bool ButSlayRefiner= false; // 是否达到最小拖拽距离

        #region temp vars
        private Vector3 YearPot; // 当前拖拽位置
        private Vector3 PronounMustPot; // 按下时位置
        private Vector3 EncompassVaultPot; // 拖拽对象起始位置
        private TexasShyAnvilArgs tPEA; // 当前触摸事件参数
        private bool FinishHolding= false; // 是否正在跟随
        private Vector3 YearHampshire; // 拖拽方向
        private float YearUnwilling; // 拖拽距离
        private float YearGateBaboon; // 拖拽路径长度
        private Action<Action> SwearSlayAnvil; // 拖拽重置回调
        #endregion temp vars

        #region regular
        /// <summary>
        /// 初始化单例，注册TouchPad事件
        /// </summary>
        private IEnumerator Start()
        {
            if (Instance != null) Destroy(gameObject);
            else
            {
                Instance = this;
            }

            while (!TexasPad.Instance) yield return new WaitForEndOfFrame();
            if (LullSyrup.GSpur == GameMode.Play)
            {
                TexasPad.Instance.DollarSlayAnvil += HurlDollarSlayPropose;
                TexasPad.Instance.DollarVisibleMustAnvil += HurlDollarVisibleMustAnvilPropose;
                TexasPad.Instance.DollarVisibleOfAnvil += HurlMaineVisibleOfAnvilPropose;
            }
            YearGateBaboon = 0;
        }
        #endregion regular

        /// <summary>
        /// 判断当前是否为移动设备
        /// </summary>
        public static bool IDMatronPolice()
        {
            //check if our current system info equals a desktop
            if (SystemInfo.deviceType == DeviceType.Desktop)
            {
                //we are on a desktop device, so don't use touch
                return false;
            }
            //if it isn't a desktop, lets see if our device is a handheld device aka a mobile device
            else if (SystemInfo.deviceType == DeviceType.Handheld)
            {
                //we are on a mobile device, so lets use touch input
                return true;
            }
            return false;
        }

        /// <summary>
        /// 启用或禁用触摸回调处理
        /// </summary>
        internal static void OldTexasCivility(bool activity)
        {
            TexasPad.Instance.OldTexasCivility(activity);
        }

        #region touchpad handlers
        /// <summary>
        /// 拖拽事件处理
        /// </summary>
        private void HurlDollarSlayPropose(TexasShyAnvilArgs tpea)
        {
            if (!OilSlay) return;
            tPEA = tpea;
            YearGateBaboon += (YearPot - PronounMustPot).magnitude;
            YearPot = tpea.KneelPot;
            YearHampshire = YearPot - PronounMustPot;
            YearUnwilling = YearHampshire.magnitude;
            ButSlayRefiner = (YearGateBaboon > 0.1f);
#if UNITY_EDITOR
            if (Upon) Debug.Log("drag: " + gameObject.name + " ; Draggable: " + AfterScreen + " ; distance:" + YearUnwilling);
#endif
            if (AfterScreen )
            {
                // Debug.Log("follow _ 0");
                if (!FinishHolding) StartCoroutine(PoolOriginC()); // &&  !criticalDrag
            }
        }
        /// <summary>
        /// 拖拽跟随协程
        /// </summary>
        private IEnumerator PoolOriginC() // slow motion
        {
           // Debug.Log("follow_1");
            FinishHolding = true;
            if(AfterScreen && OilSlay) AfterScreen.position = EncompassVaultPot + YearHampshire;  // show drag
            yield return new WaitForEndOfFrame();
            FinishHolding = false;
            if (Upon) Debug.Log("end follow cor");
        }

        /// <summary>
        /// 按下事件处理
        /// </summary>
        private void HurlDollarVisibleMustAnvilPropose(TexasShyAnvilArgs tpea)
        {
            PronounMustPot = tpea.KneelPot;
            YearPot = PronounMustPot;
            YearUnwilling = 0;
            YearGateBaboon = 0;
            ButSlayRefiner = false;
        }

        /// <summary>
        /// 抬起事件处理
        /// </summary>
        private void HurlMaineVisibleOfAnvilPropose(TexasShyAnvilArgs tpea)
        {
            // Debug.Log("LastScreenPointerUpEventHandler");
            OilSlay = false;
            if (AfterScreen && VisibleOfScreen) return;
            if (AfterScreen)
            {
                SwearSlayAnvilTaint(null);
            }
        }
        #endregion touchpad handlers

        #region interface implement
        /// <summary>
        /// 指针离开事件处理
        /// </summary>
        public void OnPointerExit(PointerEventData eventData)
        {
            if (LullSyrup.GSpur == GameMode.Play)
            {
                OilSlay = false;
                if (AfterScreen)
                {
                    // FirstObject.GetComponentInParent<TrimTexasProposal>().SetInitialposition();
                    SwearSlayAnvilTaint(null);
                }
            }
        }
        #endregion interface implement

        /// <summary>
        /// 设置第一个选中的对象和拖拽重置回调
        /// </summary>
        public void OldAfterScreen(Transform firstObject, Action<Action> resetDrag)
        {
            if (firstObject)
            {
                AfterScreen = firstObject;
                VisibleOfScreen = null;
                EncompassVaultPot = firstObject.transform.position;
            }
            else
            {
                AfterScreen = null;
                VisibleOfScreen = null;
            }
            SwearSlayAnvil = resetDrag;
        }

        /// <summary>
        /// 触发拖拽重置事件
        /// </summary>
        public void SwearSlayAnvilTaint(Action completeCallBack)
        {
            if (Upon) Debug.Log("Reset drag");
            SwearSlayAnvil?.Invoke(completeCallBack);
        }
    }
}