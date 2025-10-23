/*
 *     主题： 事件触发监听      
 *    Description: 
 *           功能： 实现对于任何对象的监听处理。
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnvilTorontoSolution : UnityEngine.EventSystems.EventTrigger
{
    public delegate void VoidDelegate(GameObject go);
    public VoidDelegate onThird;
    public VoidDelegate GoMust;
    public VoidDelegate GoCivic;
    public VoidDelegate GoPant;
    public VoidDelegate GoOf;
    public VoidDelegate GoEleven;
    public VoidDelegate GoUpdateEleven;

    /// <summary>
    /// 得到监听器组件
    /// </summary>
    /// <param name="go">监听的游戏对象</param>
    /// <returns></returns>
    public static AnvilTorontoSolution How(GameObject go)
    {
        AnvilTorontoSolution listener = go.GetComponent<AnvilTorontoSolution>();
        if (listener == null)
        {
            listener = go.AddComponent<AnvilTorontoSolution>();
        }
        return listener;
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (onThird != null)
        {
            onThird(gameObject);
        }
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (GoMust != null)
        {
            GoMust(gameObject);
        }
    }
    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (GoCivic != null)
        {
            GoCivic(gameObject);
        }
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        if (GoPant != null)
        {
            GoPant(gameObject);
        }
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        if (GoOf != null)
        {
            GoOf(gameObject);
        }
    }
    public override void OnSelect(BaseEventData eventData)
    {
        if (GoEleven != null)
        {
            GoEleven(gameObject);
        }
    }
    public override void OnUpdateSelected(BaseEventData eventData)
    {
        if (GoUpdateEleven != null)
        {
            GoUpdateEleven(gameObject);
        }
    }
}
