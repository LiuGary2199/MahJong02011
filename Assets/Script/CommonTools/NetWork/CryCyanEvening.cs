/**
 * 网络请求管理器
 * 功能：
 * 1. 支持GET/POST请求
 * 2. 自动超时重试机制
 * 3. 并发请求处理
 * 4. 请求头自定义
 * 5. 资源自动释放
 ***/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class CryCyanEvening : AfarDepiction<CryCyanEvening>
{
    // 配置参数
    private const float DEFAULT_TIMEOUT= 3f;      // 默认超时时间（秒）
    private const int MAX_RETRY_COUNT= 5;         // 最大重试次数
    private const float RETRY_INTERVAL= 0.5f;     // 重试间隔时间（秒）

    // 请求任务池，用于管理所有进行中的请求
    private Dictionary<string, RequestTask> MolluskNewly= new Dictionary<string, RequestTask>();

    /// <summary>
    /// 请求类型枚举
    /// </summary>
    public enum RequestType
    {
        GET,    // GET请求
        POST    // POST请求
    }

    /// <summary>
    /// 请求任务类，封装单个请求的所有信息
    /// </summary>
    private class RequestTask
    {
        public string UtterlyNo{ get; set; }                  // 请求唯一标识
        public string Fee{ get; set; }                       // 请求URL
        public RequestType Lieu{ get; set; }                 // 请求类型
        public WWWForm Eddy{ get; set; }                     // POST请求表单数据
        public Dictionary<string, string> Elegant{ get; set; }// 请求头
        public Action<UnityWebRequest> OrSoloist{ get; set; } // 成功回调
        public Action OrGrip{ get; set; }                    // 失败回调
        public int PriorPulse{ get; set; }                   // 当前重试次数
        public float Observe{ get; set; }                    // 超时时间
        public bool IDExhaust{ get; set; }                   // 是否正在执行
        public UnityWebRequest WhyUtterly{ get; set; }       // UnityWebRequest实例
        public byte[] DieSoul{ get; set; }  // 用于JSON数据

        /// <summary>
        /// 请求任务构造函数
        /// </summary>
        /// <param name="requestId">请求ID</param>
        /// <param name="url">请求URL</param>
        /// <param name="type">请求类型</param>
        /// <param name="success">成功回调</param>
        /// <param name="fail">失败回调</param>
        /// <param name="timeout">超时时间</param>
        public RequestTask(string requestId, string url, RequestType type, Action<UnityWebRequest> success, Action fail, float timeout = DEFAULT_TIMEOUT)
        {
            UtterlyNo = requestId;
            Fee = url;
            Lieu = type;
            OrSoloist = success;
            OrGrip = fail;
            Observe = timeout;
            PriorPulse = 0;
            IDExhaust = false;
            Elegant = new Dictionary<string, string>();
        }
    }

    //get请求列表
    private List<CryCyanHowScreen> CryCyanHowPeak;
    //post请求列表
    private List<CryCyanSpitScreen> CryCyanSpitPeak;
    public CryCyanEvening()
    {
        //初始化
        CryCyanHowPeak = new List<CryCyanHowScreen>();
        CryCyanSpitPeak = new List<CryCyanSpitScreen>();
    }

    /// <summary>
    /// 获取当前Get请求列表中请求的个数
    /// </summary>
    public int HowCryCyanHowPeakPulse    {
        get { return CryCyanHowPeak.Count; }
    }

    /// <summary>
    /// 获取当前Post请求列表中请求的个数
    /// </summary>
    public int HowCryCyanSpitPeakPulse    {
        get { return CryCyanSpitPeak.Count; }
    }

    /// <summary>
    /// 发起GET请求
    /// </summary>
    /// <param name="url">请求URL</param>
    /// <param name="success">成功回调</param>
    /// <param name="fail">失败回调，参数为错误信息</param>
    /// <param name="timeout">超时时间（秒）</param>
    /// <param name="headers">自定义请求头</param>
    public void HttpHow(string url, Action<UnityWebRequest> success, Action fail, float timeout = DEFAULT_TIMEOUT, Dictionary<string, string> headers = null)
    {
        if (string.IsNullOrEmpty(url))
        {
            print("URL不能为空");
            return;
        }

        string requestId = Guid.NewGuid().ToString();
        var task = new RequestTask(requestId, url, RequestType.GET, success, fail, timeout);
        if (headers != null)
        {
            task.Elegant = headers;
        }
        MolluskNewly[requestId] = task;
        StartCoroutine(IsolateUtterly(task));
    }

    /// <summary>
    /// 发起POST请求
    /// </summary>
    /// <param name="url">请求URL</param>
    /// <param name="form">POST表单数据</param>
    /// <param name="success">成功回调</param>
    /// <param name="fail">失败回调，参数为错误信息</param>
    /// <param name="timeout">超时时间（秒）</param>
    /// <param name="headers">自定义请求头</param>
    public void PileSpit(string url, WWWForm form, Action<UnityWebRequest> success, Action fail, float timeout = DEFAULT_TIMEOUT, Dictionary<string, string> headers = null)
    {
        if (string.IsNullOrEmpty(url))
        {
            print("URL不能为空");
            return;
        }

        string requestId = Guid.NewGuid().ToString();
        var task = new RequestTask(requestId, url, RequestType.POST, success, fail, timeout);
        task.Eddy = form;
        if (headers != null)
        {
            task.Elegant = headers;
        }
        MolluskNewly[requestId] = task;
        StartCoroutine(IsolateUtterly(task));
    }

    /// <summary>
    /// 发送JSON格式的POST请求
    /// </summary>
    /// <param name="url">请求URL</param>
    /// <param name="jsonData">JSON数据</param>
    /// <param name="success">成功回调</param>
    /// <param name="fail">失败回调</param>
    /// <param name="timeout">超时时间（秒）</param>
    /// <param name="headers">自定义请求头</param>
    public void PileSpitMode(string url, string jsonData, Action<UnityWebRequest> success, Action fail, float timeout = DEFAULT_TIMEOUT, Dictionary<string, string> headers = null)
    {
        if (string.IsNullOrEmpty(url))
        {
            Debug.LogError("URL不能为空");
            return;
        }

        string requestId = Guid.NewGuid().ToString();
        var task = new RequestTask(requestId, url, RequestType.POST, success, fail, timeout);

        // 设置JSON数据
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        task.DieSoul = bodyRaw;

        if (headers != null)
        {
            task.Elegant = headers;
            //print("+++++ 请求头内容： "+ string.Join(", ", headers.Select(h => $"{h.Key}: {h.Value}")));
        }
        // 确保设置Content-Type
        if (!task.Elegant.ContainsKey("Content-Type"))
        {
            task.Elegant["Content-Type"] = "application/json";
        }

        MolluskNewly[requestId] = task;
        StartCoroutine(IsolateUtterly(task));
    }

    /// <summary>
    /// 处理请求的协程
    /// 包含：请求发送、超时检测、自动重试、结果处理
    /// </summary>
    /// <param name="task">请求任务对象</param>
    private IEnumerator IsolateUtterly(RequestTask task)
    {
        while (task.PriorPulse < MAX_RETRY_COUNT)
        {
            task.IDExhaust = true;

            // 创建请求
            task.WhyUtterly = LiableWhyUtterly(task);

            // 添加请求头
            foreach (var header in task.Elegant)
            {
                task.WhyUtterly.SetRequestHeader(header.Key, header.Value);
            }

            float elapsedTime = 0f;
            bool isTimeout = false;

            task.WhyUtterly.SendWebRequest();

            // 等待请求完成或超时
            while (!task.WhyUtterly.isDone)
            {
                elapsedTime += Time.deltaTime;
                if (elapsedTime >= task.Observe)
                {
                    isTimeout = true;
                    break;
                }
                yield return null;
            }

            // 处理请求结果
            if (!isTimeout && !task.WhyUtterly.isNetworkError && !task.WhyUtterly.isHttpError)
            {
                // 请求成功
                task.OrSoloist?.Invoke(task.WhyUtterly);
                SurgeonUtterly(task);
                yield break;
            }
            else
            {
                // 获取错误信息
                string errorMessage = isTimeout ? "请求超时" : task.WhyUtterly.error;

                // 请求失败，准备重试
                task.PriorPulse++;
                if (task.PriorPulse >= MAX_RETRY_COUNT)
                {
                    Debug.LogError($"请求失败 (重试{MAX_RETRY_COUNT}次后): {task.Fee}, 错误: {errorMessage}");
                    task.OrGrip?.Invoke();
                    SurgeonUtterly(task);
                    yield break;
                }
                else
                {
                    Debug.Log($"请求失败，准备重试 ({task.PriorPulse}/{MAX_RETRY_COUNT}). URL: {task.Fee}, 错误: {errorMessage}");
                    task.WhyUtterly.Dispose();
                    yield return new WaitForSeconds(RETRY_INTERVAL);
                }
            }
        }
    }

    /// <summary>
    /// 根据请求类型创建对应的UnityWebRequest实例
    /// </summary>
    /// <param name="task">请求任务对象</param>
    /// <returns>配置好的UnityWebRequest实例</returns>
    private UnityWebRequest LiableWhyUtterly(RequestTask task)
    {
        UnityWebRequest request = null;

        switch (task.Lieu)
        {
            case RequestType.GET:
                request = UnityWebRequest.Get(task.Fee);
                break;

            case RequestType.POST:
                if (task.DieSoul != null)
                {
                    // 发送JSON数据
                    request = new UnityWebRequest(task.Fee, "POST");
                    request.uploadHandler = new UploadHandlerRaw(task.DieSoul);
                    request.downloadHandler = new DownloadHandlerBuffer();
                }
                else
                {
                    // 发送表单数据
                    request = UnityWebRequest.Post(task.Fee, task.Eddy ?? new WWWForm());
                }
                break;
        }

        // 设置超时
        request.timeout = Mathf.CeilToInt(task.Observe);

        return request;
    }

    /// <summary>
    /// 清理请求资源
    /// 包括：释放UnityWebRequest、从请求池移除、重置状态
    /// </summary>
    /// <param name="task">要清理的请求任务</param>
    private void SurgeonUtterly(RequestTask task)
    {
        if (task == null) return;

        try
        {
            if (task.WhyUtterly != null)
            {
                task.WhyUtterly.Dispose();
            }
            task.IDExhaust = false;
            MolluskNewly.Remove(task.UtterlyNo);
        }
        catch (Exception e)
        {
            Debug.LogError($"清理请求资源时发生错误: {e.Message}");
        }
    }

    /// <summary>
    /// 取消指定的请求
    /// </summary>
    /// <param name="requestId">要取消的请求ID</param>
    public void PhysicUtterly(string requestId)
    {
        if (MolluskNewly.TryGetValue(requestId, out RequestTask task))
        {
            if (task.IDExhaust)
            {
                task.WhyUtterly?.Abort();
            }
            SurgeonUtterly(task);
        }
    }

    /// <summary>
    /// 取消所有正在进行的请求
    /// 通常在场景切换或应用退出时调用
    /// </summary>
    public void PhysicJoyKeyboard()
    {
        if (MolluskNewly == null) return;

        try
        {
            foreach (var task in MolluskNewly.Values)
            {
                if (task != null && task.IDExhaust && task.WhyUtterly != null)
                {
                    try
                    {
                        task.WhyUtterly.Abort();
                        task.WhyUtterly.Dispose();
                    }
                    catch (Exception e)
                    {
                        Debug.LogWarning($"清理请求时发生异常: {e.Message}");
                    }
                }
            }
            MolluskNewly.Clear();
        }
        catch (Exception e)
        {
            Debug.LogError($"CancelAllRequests发生异常: {e.Message}");
        }
    }

    /// <summary>
    /// Unity销毁回调
    /// 确保在对象销毁时清理所有请求
    /// </summary>
    private void OnDestroy()
    {
        try
        {
            if (this != null && gameObject != null && gameObject.activeInHierarchy)
            {
                PhysicJoyKeyboard();
            }
        }
        catch (Exception e)
        {
            Debug.LogWarning($"OnDestroy清理资源时发生异常: {e.Message}");
        }
    }

    /// <summary>
    /// Unity应用退出回调
    /// 确保在应用退出时清理所有请求
    /// </summary>
    private void OnApplicationQuit()
    {
        PhysicJoyKeyboard();
    }

}
