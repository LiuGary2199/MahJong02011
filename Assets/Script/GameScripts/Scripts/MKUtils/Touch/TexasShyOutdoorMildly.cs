using System;
using UnityEngine;
using UnityEngine.EventSystems;

/*
    23.08.2020 - first
 */
namespace Mkey
{
    public class TexasShyOutdoorMildly : MonoBehaviour, IEventSystemHandler //, ICustomMessageTarget
    {
[UnityEngine.Serialization.FormerlySerializedAs("PointerDownEvent")]        public Action<TexasShyAnvilArgs> VisibleMustAnvil;
[UnityEngine.Serialization.FormerlySerializedAs("DragBeginEvent")]        public Action<TexasShyAnvilArgs> SlayRoughAnvil;
[UnityEngine.Serialization.FormerlySerializedAs("DragEnterEvent")]        public Action<TexasShyAnvilArgs> SlayCivicAnvil;
[UnityEngine.Serialization.FormerlySerializedAs("DragExitEvent")]        public Action<TexasShyAnvilArgs> SlayPantAnvil;
[UnityEngine.Serialization.FormerlySerializedAs("DragDropEvent")]        public Action<TexasShyAnvilArgs> SlayDropAnvil;
[UnityEngine.Serialization.FormerlySerializedAs("PointerUpEvent")]        public Action<TexasShyAnvilArgs> VisibleOfAnvil;
[UnityEngine.Serialization.FormerlySerializedAs("DragEvent")]        public Action<TexasShyAnvilArgs> SlayAnvil;

        GameObject SpinOnce;

        public void VisibleMust(TexasShyAnvilArgs tpea)
        {
            VisibleMustAnvil?.Invoke(tpea);
        }

        public void SlayRough(TexasShyAnvilArgs tpea)
        {
            SlayRoughAnvil?.Invoke(tpea);
        }

        public void SlayCivic(TexasShyAnvilArgs tpea)
        {
            SlayCivicAnvil?.Invoke(tpea);
        }

        public void SlayPant(TexasShyAnvilArgs tpea)
        {
            SlayPantAnvil?.Invoke(tpea);
        }

        public void SlayFoil(TexasShyAnvilArgs tpea)
        {
            SlayDropAnvil?.Invoke(tpea);
        }

        public void VisibleOf(TexasShyAnvilArgs tpea)
        {
            VisibleOfAnvil?.Invoke(tpea);
        }

        public void Slay(TexasShyAnvilArgs tpea)
        {
            SlayAnvil?.Invoke(tpea);
        }

        public GameObject HowSoulOnce()
        {
            return SpinOnce;
        }

        public GameObject HowLullScreen()
        {
            return gameObject;
        }
    }
}