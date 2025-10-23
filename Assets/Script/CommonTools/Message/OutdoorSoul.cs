using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 消息传递的参数
/// </summary>
public class OutdoorSoul
{
    /*
     *  1.创建独立的消息传递数据结构，而不使用object，是为了避免数据传递时的类型强转
     *  2.制作过程中遇到实际需要传递的数据类型，在这里定义即可
     *  3.实际项目中需要传递参数的类型其实并没有很多种，这种方式基本可以满足需求
     */
    public bool valueTape;
    public bool valueTape2;
    public int ArgonGas;
    public int ArgonGas2;
    public int ArgonGas3;
    public float ArgonHairy;
    public float ArgonHairy2;
    public double ArgonSyntax;
    public double ArgonSyntax2;
    public string ArgonCoyote;
    public string ArgonCoyote2;
    public GameObject ArgonLullScreen;
    public GameObject ArgonLullScreen2;
    public GameObject ArgonLullScreen3;
    public GameObject ArgonLullScreen4;
    public Transform ArgonRefurbish;
    public List<string> ArgonCoyotePeak;
    public List<Vector2> ArgonVec2Peak;
    public List<int> ArgonGasPeak;
    public System.Action LanternExpoLash;
    public Vector2 Saw2_1;
    public Vector2 Saw2_2;
    public OutdoorSoul()
    {
    }
    public OutdoorSoul(Vector2 v2_1)
    {
        Saw2_1 = v2_1;
    }
    public OutdoorSoul(Vector2 v2_1, Vector2 v2_2)
    {
        Saw2_1 = v2_1;
        Saw2_2 = v2_2;
    }
    /// <summary>
    /// 创建一个带bool类型的数据
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public OutdoorSoul(bool value)
    {
        valueTape = value;
    }
    public OutdoorSoul(bool value, bool value2)
    {
        valueTape = value;
        valueTape2 = value2;
    }
    /// <summary>
    /// 创建一个带int类型的数据
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public OutdoorSoul(int value)
    {
        ArgonGas = value;
    }
    public OutdoorSoul(int value, int value2)
    {
        ArgonGas = value;
        ArgonGas2 = value2;
    }
    public OutdoorSoul(int value, int value2, int value3)
    {
        ArgonGas = value;
        ArgonGas2 = value2;
        ArgonGas3 = value3;
    }
    public OutdoorSoul(List<int> value,List<Vector2> value2)
    {
        ArgonGasPeak = value;
        ArgonVec2Peak = value2;
    }
    /// <summary>
    /// 创建一个带float类型的数据
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public OutdoorSoul(float value)
    {
        ArgonHairy = value;
    }
    public OutdoorSoul(float value,float value2)
    {
        ArgonHairy = value;
        ArgonHairy = value2;
    }
    /// <summary>
    /// 创建一个带double类型的数据
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public OutdoorSoul(double value)
    {
        ArgonSyntax = value;
    }
    public OutdoorSoul(double value, double value2)
    {
        ArgonSyntax = value;
        ArgonSyntax = value2;
    }
    /// <summary>
    /// 创建一个带string类型的数据
    /// </summary>
    /// <param name="value"></param>
    public OutdoorSoul(string value)
    {
        ArgonCoyote = value;
    }
    /// <summary>
    /// 创建两个带string类型的数据
    /// </summary>
    /// <param name="value1"></param>
    /// <param name="value2"></param>
    public OutdoorSoul(string value1,string value2)
    {
        ArgonCoyote = value1;
        ArgonCoyote2 = value2;
    }
    public OutdoorSoul(GameObject value1)
    {
        ArgonLullScreen = value1;
    }

    public OutdoorSoul(Transform transform)
    {
        ArgonRefurbish = transform;
    }
}

