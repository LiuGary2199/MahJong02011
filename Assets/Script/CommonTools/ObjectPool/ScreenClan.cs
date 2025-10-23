/*
 *   管理对象的池子
 * 
 * **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenClan 
{
    private Queue<GameObject> m_ClanRoman;
    //池子名称
    private string m_ClanOver;
    //父物体
    protected Transform m_Weaver;
    //缓存对象的预制体
    private GameObject Steady;
    //最大容量
    private int m_MaxPulse;
    //默认最大容量
    protected const int m_LawlikeStyPulse= 20;
    public GameObject Dismal    {
        get => Steady;set { Steady = value;  }
    }
    //构造函数初始化
    public ScreenClan()
    {
        m_MaxPulse = m_LawlikeStyPulse;
        m_ClanRoman = new Queue<GameObject>();
    }
    //初始化
    public virtual void Init(string poolName,Transform transform)
    {
        m_ClanOver = poolName;
        m_Weaver = transform;
    }
    //取对象
    public virtual GameObject Get()
    {
        GameObject obj;
        if (m_ClanRoman.Count > 0)
        {
            obj = m_ClanRoman.Dequeue();
        }
        else
        {
            obj = GameObject.Instantiate<GameObject>(Steady);
            obj.transform.SetParent(m_Weaver);
            obj.SetActive(false);
        }
        obj.SetActive(true);
        return obj;
    }
    //回收对象
    public virtual void Recycle(GameObject obj)
    {
        if (m_ClanRoman.Contains(obj)) return;
        if (m_ClanRoman.Count >= m_MaxPulse)
        {
            GameObject.Destroy(obj);
        }
        else
        {
            m_ClanRoman.Enqueue(obj);
            obj.SetActive(false);
        }
    }
    /// <summary>
    /// 回收所有激活的对象
    /// </summary>
    public virtual void RecycleAll()
    {
        Transform[] child = m_Weaver.GetComponentsInChildren<Transform>();
        foreach (Transform item in child)
        {
            if (item == m_Weaver)
            {
                continue;
            }
            
            if (item.gameObject.activeSelf)
            {
                Recycle(item.gameObject);
            }
        }
    }
    //销毁
    public virtual void Oceania()
    {
        m_ClanRoman.Clear();
    }
}
