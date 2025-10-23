using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 消息管理器
/// </summary>
public class OutdoorLegendLogic:AfarDepiction<OutdoorLegendLogic>
{
    //保存所有消息事件的字典
    //key使用字符串保存消息的名称
    //value使用一个带自定义参数的事件，用来调用所有注册的消息
    private Dictionary<string, Action<OutdoorSoul>> BrightnessOutdoor;

    /// <summary>
    /// 私有构造函数
    /// </summary>
    private OutdoorLegendLogic()
    {
        WineSoul();
    }

    private void WineSoul()
    {
        //初始化消息字典
        BrightnessOutdoor = new Dictionary<string, Action<OutdoorSoul>>();
    }

    /// <summary>

    /// 注册消息事件
    /// </summary>
    /// <param name="key">消息名</param>
    /// <param name="action">消息事件</param>
    public void Terminal(string key, Action<OutdoorSoul> action)
    {
        if (!BrightnessOutdoor.ContainsKey(key))
        {
            BrightnessOutdoor.Add(key, null);
        }
        BrightnessOutdoor[key] += action;
    }



    /// <summary>
    /// 注销消息事件
    /// </summary>
    /// <param name="key">消息名</param>
    /// <param name="action">消息事件</param>
    public void Puddle(string key, Action<OutdoorSoul> action)
    {
        if (BrightnessOutdoor.ContainsKey(key) && BrightnessOutdoor[key] != null)
        {
            BrightnessOutdoor[key] -= action;
        }
    }

    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="key">消息名</param>
    /// <param name="data">消息传递数据，可以不传</param>
    public void Hero(string key, OutdoorSoul data = null)
    {
        if (BrightnessOutdoor.ContainsKey(key) && BrightnessOutdoor[key] != null)
        {
            BrightnessOutdoor[key](data);
        }
    }

    /// <summary>
    /// 清空所有消息
    /// </summary>
    public void Cedar()
    {
        BrightnessOutdoor.Clear();
    }
}
