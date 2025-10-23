/*
 * 
 * 多语言
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwellingPeg 
{
    public static DwellingPeg _Statement;
    //语言翻译的缓存集合
    private Dictionary<string, string> _MarDwellingMoose;

    private DwellingPeg()
    {
        _MarDwellingMoose = new Dictionary<string, string>();
        //初始化语言缓存集合
        WineDwellingMoose();
    }

    /// <summary>
    /// 获取实例
    /// </summary>
    /// <returns></returns>
    public static DwellingPeg HowWhatever()
    {
        if (_Statement == null)
        {
            _Statement = new DwellingPeg();
        }
        return _Statement;
    }

    /// <summary>
    /// 得到显示文本信息
    /// </summary>
    /// <param name="lauguageId">语言id</param>
    /// <returns></returns>
    public string KnotPity(string lauguageId)
    {
        string strQueryResult = string.Empty;
        if (string.IsNullOrEmpty(lauguageId)) return null;
        //查询处理
        if(_MarDwellingMoose!=null && _MarDwellingMoose.Count >= 1)
        {
            _MarDwellingMoose.TryGetValue(lauguageId, out strQueryResult);
            if (!string.IsNullOrEmpty(strQueryResult))
            {
                return strQueryResult;
            }
        }
        Debug.Log(GetType() + "/ShowText()/ Query is Null!  Parameter lauguageID: " + lauguageId);
        return null;
    }

    /// <summary>
    /// 初始化语言缓存集合
    /// </summary>
    private void WineDwellingMoose()
    {
        //LauguageJSONConfig_En
        //LauguageJSONConfig
        IShamanEvening config = new ShamanEveningUpMode("LauguageJSONConfig");
        if (config != null)
        {
            _MarDwellingMoose = config.MapAdjunct;
        }
    }
}
