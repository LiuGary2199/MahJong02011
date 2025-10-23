/**
 * 
 * 左右滑动的页面视图
 * 
 * ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class NormMeet : MonoBehaviour,IBeginDragHandler,IEndDragHandler
{
[UnityEngine.Serialization.FormerlySerializedAs("rect")]    //scrollview
    public ScrollRect Berg;
    //求出每页的临界角，页索引从0开始
    List<float> OurPeak= new List<float>();
[UnityEngine.Serialization.FormerlySerializedAs("isDrag")]    //是否拖拽结束
    public bool ItSlay= false;
    bool TreeMove= true;
    //滑动的起始坐标  
    float MaracaReportedly= 0;
    float InferSlayReportedly;
    float startTime = 0f;
[UnityEngine.Serialization.FormerlySerializedAs("smooting")]    //滑动速度  
    public float Wildlife= 1f;
[UnityEngine.Serialization.FormerlySerializedAs("sensitivity")]    public float Acquisition= 0.3f;
[UnityEngine.Serialization.FormerlySerializedAs("OnPageChange")]    //页面改变
    public Action<int> OrNormHalite;
    //当前页面下标
    int ProduceNormMoody= -1;
    void Start()
    {
        Berg = this.GetComponent<ScrollRect>();
        float horizontalLength = Berg.content.rect.width - this.GetComponent<RectTransform>().rect.width;
        OurPeak.Add(0);
        for(int i = 1; i < Berg.content.childCount - 1; i++)
        {
            OurPeak.Add(GetComponent<RectTransform>().rect.width * i / horizontalLength);
        }
        OurPeak.Add(1);
    }

    
    void Update()
    {
        if(!ItSlay && !TreeMove)
        {
            startTime += Time.deltaTime;
            float t = startTime * Wildlife;
            Berg.horizontalNormalizedPosition = Mathf.Lerp(Berg.horizontalNormalizedPosition, MaracaReportedly, t);
            if (t >= 1)
            {
                TreeMove = true;
            }
        }
        
    }
    /// <summary>
    /// 设置页面的index下标
    /// </summary>
    /// <param name="index"></param>
    void OldNormMoody(int index)
    {
        if (ProduceNormMoody != index)
        {
            ProduceNormMoody = index;
            if (OrNormHalite != null)
            {
                OrNormHalite(index);
            }
        }
    }
    /// <summary>
    /// 开始拖拽
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        ItSlay = true;
        InferSlayReportedly = Berg.horizontalNormalizedPosition;
    }
    /// <summary>
    /// 拖拽结束
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        float posX = Berg.horizontalNormalizedPosition;
        posX += ((posX - InferSlayReportedly) * Acquisition);
        posX = posX < 1 ? posX : 1;
        posX = posX > 0 ? posX : 0;
        int Rough= 0;
        float offset = Mathf.Abs(OurPeak[Rough] - posX);
        for(int i = 0; i < OurPeak.Count; i++)
        {
            float temp = Mathf.Abs(OurPeak[i] - posX);
            if (temp < offset)
            {
                Rough = i;
                offset = temp;
            }
        }
        OldNormMoody(Rough);
        MaracaReportedly = OurPeak[Rough];
        ItSlay = false;
        startTime = 0f;
        TreeMove = false;
    }
}
