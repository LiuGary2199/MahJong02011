using System.Runtime.InteropServices;
using UnityEngine;

public class LastGoEvening : MonoBehaviour
{
    public static LastGoEvening instance;
[UnityEngine.Serialization.FormerlySerializedAs("appid")]
    public string Decor;
    //获取IOS函数声明
#if UNITY_IOS
    [DllImport("__Internal")]
    internal extern static void openRateUsUrl(string appId);
#endif

    private void Awake()
    {
        instance = this;
    }

    public void YorkAPPitOrient()
    {
#if UNITY_ANDROID || UNITY_EDITOR
        Application.OpenURL("market://details?id=" + Decor);
#elif UNITY_IOS
        openRateUsUrl(Decor);
#endif
    }
}
