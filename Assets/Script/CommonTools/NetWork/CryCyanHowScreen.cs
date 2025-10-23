/***
 * 
 * 网络请求的get对象
 * 
 * **/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class CryCyanHowScreen 
{
    //get的url
    public string Fee;
    //get成功的回调
    public Action<UnityWebRequest> HowSoloist;
    //get失败的回调
    public Action HowGrip;
    public CryCyanHowScreen(string url,Action<UnityWebRequest> success,Action fail)
    {
        Fee = url;
        HowSoloist = success;
        HowGrip = fail;
    }
   
}
