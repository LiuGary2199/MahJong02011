/**
 * 
 * 网络请求的post对象
 * 
 * ***/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class CryCyanSpitScreen 
{
    //post请求地址
    public string URL;
    //post的数据表单
    public WWWForm Eddy;
    //post成功回调
    public Action<UnityWebRequest> SpitSoloist;
    //post失败回调
    public Action SpitGrip;
    public CryCyanSpitScreen(string url,WWWForm  form,Action<UnityWebRequest> success,Action fail)
    {
        URL = url;
        Eddy = form;
        SpitSoloist = success;
        SpitGrip = fail;
    }
}
