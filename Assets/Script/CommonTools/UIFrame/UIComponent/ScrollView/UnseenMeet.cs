/**
 * 
 * 支持上下滑动的scroll view
 * 
 * **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnseenMeet : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("itemCell")]    //预支单体
    public ScrollViewItem SeepLime;
[UnityEngine.Serialization.FormerlySerializedAs("scrollRect")]    //scrollview
    public ScrollRect ShelveTear;
[UnityEngine.Serialization.FormerlySerializedAs("content")]
    //content
    public RectTransform Bluntly;
[UnityEngine.Serialization.FormerlySerializedAs("spacing")]    //间隔
    public float Figural= 10;
[UnityEngine.Serialization.FormerlySerializedAs("totalWidth")]    //总的宽
    public float ScourMedia;
[UnityEngine.Serialization.FormerlySerializedAs("totalHeight")]    //总的高
    public float ScourWeldon;
[UnityEngine.Serialization.FormerlySerializedAs("visibleCount")]    //可见的数量
    public int RecruitPulse;
[UnityEngine.Serialization.FormerlySerializedAs("isClac")]    //初始数据完成是否检测计算
    public bool ItNail= false;
[UnityEngine.Serialization.FormerlySerializedAs("startIndex")]    //开始的索引
    public int InferMoody;
[UnityEngine.Serialization.FormerlySerializedAs("lastIndex")]    //结尾的索引
    public int ZoneMoody;
[UnityEngine.Serialization.FormerlySerializedAs("itemHeight")]    //item的高
    public float SeepWeldon= 50;
[UnityEngine.Serialization.FormerlySerializedAs("itemList")]
    //缓存的itemlist
    public List<ScrollViewItem> SeepPeak;
[UnityEngine.Serialization.FormerlySerializedAs("visibleList")]    //可见的itemList
    public List<ScrollViewItem> RecruitPeak;
[UnityEngine.Serialization.FormerlySerializedAs("allList")]    //总共的dataList
    public List<int> CowPeak;

    void Start()
    {
        ScourWeldon = this.GetComponent<RectTransform>().sizeDelta.y;
        ScourMedia = this.GetComponent<RectTransform>().sizeDelta.x;
        Bluntly = ShelveTear.content;
        WineSoul();

    }
    //初始化
    public void WineSoul()
    {
        RecruitPulse = Mathf.CeilToInt(ScourWeldon / WildWeldon) + 1;
        for (int i = 0; i < RecruitPulse; i++)
        {
            this.BatHigh();
        }
        InferMoody = 0;
        ZoneMoody = 0;
        List<int> numberList = new List<int>();
        //数据长度
        int dataLength = 20;
        for (int i = 0; i < dataLength; i++)
        {
            numberList.Add(i);
        }
        OldSoul(numberList);
    }
    //设置数据
    void OldSoul(List<int> list)
    {
        CowPeak = list;
        InferMoody = 0;
        if (SoulPulse <= RecruitPulse)
        {
            ZoneMoody = SoulPulse;
        }
        else
        {
            ZoneMoody = RecruitPulse - 1;
        }
        //Debug.Log("ooooooooo"+lastIndex);
        for (int i = InferMoody; i < ZoneMoody; i++)
        {
            ScrollViewItem obj = LotHigh();
            if (obj == null)
            {
                Debug.Log("获取item为空");
            }
            else
            {
                obj.gameObject.name = i.ToString();

                obj.gameObject.SetActive(true);
                obj.transform.localPosition = new Vector3(0, -i * WildWeldon, 0);
                RecruitPeak.Add(obj);
                MildlyHigh(i, obj);
            }

        }
        Bluntly.sizeDelta = new Vector2(ScourMedia, SoulPulse * WildWeldon - Figural);
        ItNail = true;
    }
    //更新item
    public void MildlyHigh(int index, ScrollViewItem obj)
    {
        int d = CowPeak[index];
        string str = d.ToString();
        obj.name = str;
        //更新数据 todo
    }
    //从itemlist中取出item
    public ScrollViewItem LotHigh()
    {
        ScrollViewItem obj = null;
        if (SeepPeak.Count > 0)
        {
            obj = SeepPeak[0];
            obj.gameObject.SetActive(true);
            SeepPeak.RemoveAt(0);
        }
        else
        {
            Debug.Log("从缓存中取出的是空");
        }
        return obj;
    }
    //item进入itemlist
    public void WiseHigh(ScrollViewItem obj)
    {
        SeepPeak.Add(obj);
        obj.gameObject.SetActive(false);
    }
    public int SoulPulse    {
        get
        {
            return CowPeak.Count;
        }
    }
    //每一行的高
    public float WildWeldon    {
        get
        {
            return SeepWeldon + Figural;
        }
    }
    //添加item到缓存列表中
    public void BatHigh()
    {
        GameObject obj = Instantiate(SeepLime.gameObject);
        obj.transform.SetParent(Bluntly);
        RectTransform Berg= obj.GetComponent<RectTransform>();
        Berg.anchorMin = new Vector2(0.5f, 1);
        Berg.anchorMax = new Vector2(0.5f, 1);
        Berg.pivot = new Vector2(0.5f, 1);
        obj.SetActive(false);
        obj.transform.localScale = Vector3.one;
        ScrollViewItem o = obj.GetComponent<ScrollViewItem>();
        SeepPeak.Add(o);
    }



    void Update()
    {
        if (ItNail)
        {
            Unseen();
        }
    }
    /// <summary>
    /// 计算滑动支持上下滑动
    /// </summary>
    void Unseen()
    {
        float vy = Bluntly.anchoredPosition.y;
        float rollUpTop = (InferMoody + 1) * WildWeldon;
        float rollUnderTop = InferMoody * WildWeldon;

        if (vy > rollUpTop && ZoneMoody < SoulPulse)
        {
            //上边界移除
            if (RecruitPeak.Count > 0)
            {
                ScrollViewItem obj = RecruitPeak[0];
                RecruitPeak.RemoveAt(0);
                WiseHigh(obj);
            }
            InferMoody++;
        }
        float rollUpBottom = (ZoneMoody - 1) * WildWeldon - Figural;
        if (vy < rollUpBottom - ScourWeldon && InferMoody > 0)
        {
            //下边界减少
            ZoneMoody--;
            if (RecruitPeak.Count > 0)
            {
                ScrollViewItem obj = RecruitPeak[RecruitPeak.Count - 1];
                RecruitPeak.RemoveAt(RecruitPeak.Count - 1);
                WiseHigh(obj);
            }

        }
        float rollUnderBottom = ZoneMoody * WildWeldon - Figural;
        if (vy > rollUnderBottom - ScourWeldon && ZoneMoody < SoulPulse)
        {
            //Debug.Log("下边界增加"+vy);
            //下边界增加
            ScrollViewItem go = LotHigh();
            RecruitPeak.Add(go);
            go.transform.localPosition = new Vector3(0, -ZoneMoody * WildWeldon);
            MildlyHigh(ZoneMoody, go);
            ZoneMoody++;
        }


        if (vy < rollUnderTop && InferMoody > 0)
        {
            //Debug.Log("上边界增加"+vy);
            //上边界增加
            InferMoody--;
            ScrollViewItem go = LotHigh();
            RecruitPeak.Insert(0, go);
            MildlyHigh(InferMoody, go);
            go.transform.localPosition = new Vector3(0, -InferMoody * WildWeldon);
        }

    }
}
