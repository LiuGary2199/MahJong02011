/*
 * 
 *  管理多个对象池的管理类
 * 
 * **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ScreenClanEvening : AfarDepiction<ScreenClanEvening>
{
    //管理objectpool的字典
    private Dictionary<string, ScreenClan> m_ClanMar;
    private Transform m_JuneRefurbish=null;
    //构造函数
    public ScreenClanEvening()
    {
        m_ClanMar = new Dictionary<string, ScreenClan>();      
    }
    
    //创建一个新的对象池
    public T LiableScreenClan<T>(string poolName) where T : ScreenClan, new()
    {
        if (m_ClanMar.ContainsKey(poolName))
        {
            return m_ClanMar[poolName] as T;
        }
        if (m_JuneRefurbish == null)
        {
            m_JuneRefurbish = this.transform;
        }      
        GameObject obj = new GameObject(poolName);
        obj.transform.SetParent(m_JuneRefurbish);
        T pool = new T();
        pool.Init(poolName, obj.transform);
        m_ClanMar.Add(poolName, pool);
        return pool;
    }
    //取对象
    public GameObject HowLullScreen(string poolName)
    {
        if (m_ClanMar.ContainsKey(poolName))
        {
            return m_ClanMar[poolName].Get();
        }
        return null;
    }
    //回收对象
    public void SuggestLullScreen(string poolName,GameObject go)
    {
        if (m_ClanMar.ContainsKey(poolName))
        {
            m_ClanMar[poolName].Recycle(go);
        }
    }
    //销毁所有的对象池
    public void OnDestroy()
    {
        m_ClanMar.Clear();
        GameObject.Destroy(m_JuneRefurbish);
    }
    /// <summary>
    /// 查询是否有该对象池
    /// </summary>
    /// <param name="poolName"></param>
    /// <returns></returns>
    public bool IndexClan(string poolName)
    {
        return m_ClanMar.ContainsKey(poolName) ? true : false;
    }
}
