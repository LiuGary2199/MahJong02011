using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 事件渗透
/// </summary>
public class MechanicAnvilDefensive : MonoBehaviour, ICanvasRaycastFilter
{
    private RectTransform MaracaTear;
[UnityEngine.Serialization.FormerlySerializedAs("isclick")]    public bool Deviate= false;

    public void OldMildlyTear(RectTransform rect)
    {
        MaracaTear = rect;
        Deviate = false;
    }
    public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
    {
        if (MaracaTear == null)
        {
            Debug.Log("[Penetrate] targetRect is null, return false");
            return false;
        }
        bool inHole = RectTransformUtility.RectangleContainsScreenPoint(MaracaTear, sp, eventCamera);
        
        //Debug.Log($"[Penetrate] sp={sp}, eventCamera={eventCamera}, targetRect={targetRect}, inHole={inHole}");
        return inHole;
    }
}