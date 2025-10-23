/*
*
*   功能：整个UI框架的核心，用户程序通过调用本类，来调用本框架的大多数功能。  
*           功能1：关于入“栈”与出“栈”的UI窗体4个状态的定义逻辑
*                 入栈状态：
*                     Freeze();   （上一个UI窗体）冻结
*                     Display();  （本UI窗体）显示
*                 出栈状态： 
*                     Hiding();    (本UI窗体) 隐藏
*                     Redisplay(); (上一个UI窗体) 重新显示
*          功能2：增加“非栈”缓存集合。 
* 
* 
* ***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
/// <summary>
/// UI窗体管理器脚本（框架核心脚本）
/// 主要负责UI窗体的加载、缓存、以及对于“UI窗体基类”的各种生命周期的操作（显示、隐藏、重新显示、冻结）。
/// </summary>
public class UIEvening : MonoBehaviour
{
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("MainCanvas")]    public Canvas BookSphere;
    private static UIEvening _Whatever= null;
    //ui窗体预设路径（参数1，窗体预设名称，2，表示窗体预设路径）
    private Dictionary<string, string> _MarTruthLucky;
    //缓存所有的ui窗体
    private Dictionary<string, RealUITruth> _MarALLUITruth;
    //栈结构标识当前ui窗体的集合
    private Stack<RealUITruth> _StaPrecedeUITruth;
    //当前显示的ui窗体
    private Dictionary<string, RealUITruth> _MarPrecedeKnotUITruth;
    //临时关闭窗口
    private List<UIFormParams> _FineUITruth;
    //ui根节点
    private Transform _BidSphereTransfrom= null;
    //全屏幕显示的节点
    private Transform _BidBreast= null;
    //固定显示的节点
    private Transform _BidSetup= null;
    //弹出节点
    private Transform _BidLotOf= null;
    //ui特效节点
    private Transform _Top= null;
    //ui管理脚本的节点
    private Transform _BidUIPortend= null;
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("_TraUICamera")]    public Transform _BidUIRefuge= null;
    public Camera UIRefuge{ get; private set; }
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("PanelName")]    public string DwarfOver;
    List<string> DwarfOverPeak;
    public List<UIFormParams> FineUITruth    {
        get
        {
            return _FineUITruth;
        }
    }
    //得到实例
    public static UIEvening HowWhatever()
    {
        if (_Whatever == null)
        {
            _Whatever = new GameObject("_UIManager").AddComponent<UIEvening>();
            
        }
        return _Whatever;
    }
    //初始化核心数据，加载ui窗体路径到集合中
    public void Awake()
    {
        DwarfOverPeak = new List<string>();
        //字段初始化
        _MarALLUITruth = new Dictionary<string, RealUITruth>();
        _MarPrecedeKnotUITruth = new Dictionary<string, RealUITruth>();
        _FineUITruth = new List<UIFormParams>();
        _MarTruthLucky = new Dictionary<string, string>();
        _StaPrecedeUITruth = new Stack<RealUITruth>();
        //初始化加载（根ui窗体）canvas预设
        WineJuneSphereClarify();
        //得到UI根节点，全屏节点，固定节点，弹出节点
        //Debug.Log("this.gameobject" + this.gameObject.name);
        _BidSphereTransfrom = GameObject.FindGameObjectWithTag(ArtCooler.SYS_TAG_CANVAS).transform;
        _BidBreast = OasisInsert.PulpAskChildRime(_BidSphereTransfrom.gameObject,ArtCooler.SYS_NORMAL_NODE);
        _BidSetup = OasisInsert.PulpAskChildRime(_BidSphereTransfrom.gameObject, ArtCooler.SYS_FIXED_NODE);
        _BidLotOf = OasisInsert.PulpAskChildRime(_BidSphereTransfrom.gameObject,ArtCooler.SYS_POPUP_NODE);
        _Top = OasisInsert.PulpAskChildRime(_BidSphereTransfrom.gameObject, ArtCooler.SYS_TOP_NODE);
        _BidUIPortend = OasisInsert.PulpAskChildRime(_BidSphereTransfrom.gameObject,ArtCooler.SYS_SCRIPTMANAGER_NODE);
        _BidUIRefuge = OasisInsert.PulpAskChildRime(_BidSphereTransfrom.gameObject, ArtCooler.SYS_UICAMERA_NODE);
        //把本脚本作为“根ui窗体”的子节点
        OasisInsert.BatStingRimeDyWeaverRime(_BidUIPortend, this.gameObject.transform);
        //根UI窗体在场景转换的时候，不允许销毁
        DontDestroyOnLoad(_BidSphereTransfrom);
        //初始化ui窗体预设路径数据
        WineUITruthLuckySoul();
        //初始化UI相机参数，主要是解决URP管线下UI相机的问题
        WineRefuge();
    }
    private void BatDwarf(string name)
    {
        if (!DwarfOverPeak.Contains(name))
        {
            DwarfOverPeak.Add(name);
            DwarfOver = name;
        }
    }
    private void SeaDwarf(string name)
    {
        if (DwarfOverPeak.Contains(name))
        {
            DwarfOverPeak.Remove(name);
        }
        if (DwarfOverPeak.Count == 0)
        {
            DwarfOver = "";
        }
        else
        {
            DwarfOver = DwarfOverPeak[0];
        }
    }
    //初始化加载（根ui窗体）canvas预设
    private void WineJuneSphereClarify()
    {
        BookSphere = DandelionPeg.HowWhatever().WideIncur(ArtCooler.SYS_PATH_CANVAS, false).GetComponent<Canvas>();
    }
    /// <summary>
    /// 显示ui窗体
    /// 功能：1根据ui窗体的名称，加载到所有ui窗体缓存集合中
    /// 2,根据不同的ui窗体的显示模式，分别做不同的加载处理
    /// </summary>
    /// <param name="SoEddyOver">ui窗体预设的名称</param>
    public GameObject KnotUITruth(string SoEddyOver, object SoEddyAdvent = null)
    {
        //参数的检查
        if (string.IsNullOrEmpty(SoEddyOver)) return null;
        //根据ui窗体的名称，把加载到所有ui窗体缓存集合中
        //ui窗体的基类
        RealUITruth baseUIForms = WideTruthDyALLUITruthMilky(SoEddyOver);
        if (baseUIForms == null) return null;

        BatDwarf(SoEddyOver);
        
        //判断是否清空“栈”结构体集合
        if (baseUIForms.PrecedeUILieu.IDCedarEarningHalite)
        {
            CedarStackBelle();
        }
        //根据不同的ui窗体的显示模式，分别做不同的加载处理
        switch (baseUIForms.PrecedeUILieu.UIForm_ShowMode)
        {
            case UIFormShowMode.Normal:
                CivicUITruthMoose(SoEddyOver, SoEddyAdvent);
                break;
            case UIFormShowMode.ReverseChange:
                WiseUITruth(SoEddyOver, SoEddyAdvent);
                break;
            case UIFormShowMode.HideOther:
                CivicUIGeyserDyMooseBeefGreek(SoEddyOver, SoEddyAdvent);
                break;
            case UIFormShowMode.Wait:
                CivicUITruthMooseFineDodge(SoEddyOver, SoEddyAdvent);
                break;
            default:
                break;
        }
        return baseUIForms.gameObject;
    }

    /// <summary>
    /// 关闭或返回上一个ui窗体（关闭当前ui窗体）
    /// </summary>
    /// <param name="strUIFormsName"></param>
    public void DodgeItInjectUITruth(string strUIFormsName)
    {
        SeaDwarf(strUIFormsName);
        //Debug.Log("关闭窗体的名字是" + strUIFormsName);
        //ui窗体的基类
        RealUITruth baseUIForms = null;
        if (string.IsNullOrEmpty(strUIFormsName)) return;
        _MarALLUITruth.TryGetValue(strUIFormsName,out baseUIForms);
        //所有窗体缓存中没有记录，则直接返回
        if (baseUIForms == null) return;
        //判断不同的窗体显示模式，分别处理
        switch (baseUIForms.PrecedeUILieu.UIForm_ShowMode)
        {
            case UIFormShowMode.Normal:
                PantUITruthMoose(strUIFormsName);
                break;
            
            case UIFormShowMode.ReverseChange:
                LotUITruth();
                break;
            case UIFormShowMode.HideOther:
                PantUITruthWellMooseCanKnotGreek(strUIFormsName);
                break;
            case UIFormShowMode.Wait:
                PantUITruthMoose(strUIFormsName);
                break;
            default:
                break;
        }
        
    }
    /// <summary>
    /// 显示下一个弹窗如果有的话
    /// </summary>
    public void KnotRageLotOf()
    {
        if (_FineUITruth.Count > 0)
        {
            KnotUITruth(_FineUITruth[0].SoEddyOver, _FineUITruth[0].SoEddyAdvent);
            _FineUITruth.RemoveAt(0);
        }
    }

    /// <summary>
    /// 清空当前等待中的UI
    /// </summary>
    public void CedarFineUITruth()
    {
        if (_FineUITruth.Count > 0)
        {
            _FineUITruth = new List<UIFormParams>();
        }
    }
     /// <summary>
     /// 根据UI窗体的名称，加载到“所有UI窗体”缓存集合中
      /// 功能： 检查“所有UI窗体”集合中，是否已经加载过，否则才加载。
      /// </summary>
      /// <param name="uiFormsName">UI窗体（预设）的名称</param>
      /// <returns></returns>
    private RealUITruth WideTruthDyALLUITruthMilky(string SoEddyOver)
    {
        //加载的返回ui窗体基类
        RealUITruth baseUIResult = null;
        _MarALLUITruth.TryGetValue(SoEddyOver, out baseUIResult);
        if (baseUIResult == null)
        {
            //加载指定名称ui窗体
            baseUIResult = WideUIEddy(SoEddyOver);

        }
        return baseUIResult;
    }
    /// <summary>
    /// 加载指定名称的“UI窗体”
    /// 功能：
    ///    1：根据“UI窗体名称”，加载预设克隆体。
    ///    2：根据不同预设克隆体中带的脚本中不同的“位置信息”，加载到“根窗体”下不同的节点。
    ///    3：隐藏刚创建的UI克隆体。
    ///    4：把克隆体，加入到“所有UI窗体”（缓存）集合中。
    /// 
    /// </summary>
    /// <param name="SoEddyOver">UI窗体名称</param>
    private RealUITruth WideUIEddy(string SoEddyOver)
    {
        string strUIFormPaths = null;
        GameObject goCloneUIPrefabs = null;
        RealUITruth baseUIForm = null;
        //根据ui窗体名称，得到对应的加载路径
        _MarTruthLucky.TryGetValue(SoEddyOver, out strUIFormPaths);
        if (!string.IsNullOrEmpty(strUIFormPaths))
        {
            //加载预制体
           goCloneUIPrefabs= DandelionPeg.HowWhatever().WideIncur(strUIFormPaths, false);
        }
        //设置ui克隆体的父节点（根据克隆体中带的脚本中不同的信息位置信息）
        if(_BidSphereTransfrom!=null && goCloneUIPrefabs != null)
        {
            baseUIForm = goCloneUIPrefabs.GetComponent<RealUITruth>();
            if (baseUIForm == null)
            {
                Debug.Log("baseUiForm==null! ,请先确认窗体预设对象上是否加载了baseUIForm的子类脚本！ 参数 SoEddyOver="+SoEddyOver);
                return null;
            }
            switch (baseUIForm.PrecedeUILieu.UIForms_Type)
            {
                case UIFormType.Normal:
                    goCloneUIPrefabs.transform.SetParent(_BidBreast, false);
                    break;
                case UIFormType.Fixed:
                    goCloneUIPrefabs.transform.SetParent(_BidSetup, false);
                    break;
                case UIFormType.PopUp:
                    goCloneUIPrefabs.transform.SetParent(_BidLotOf, false);
                    break;
                case UIFormType.Top:
                    goCloneUIPrefabs.transform.SetParent(_Top, false);
                    break;
                default:
                    break;
            }
            //设置隐藏
            goCloneUIPrefabs.SetActive(false);
            //把克隆体，加入到所有ui窗体缓存集合中
            _MarALLUITruth.Add(SoEddyOver, baseUIForm);
            return baseUIForm;
        }
        else
        {
            Debug.Log("_TraCanvasTransfrom==null Or goCloneUIPrefabs==null!! ,Plese Check!, 参数SoEddyOver=" + SoEddyOver);
        }
        Debug.Log("出现不可以预估的错误，请检查，参数 SoEddyOver=" + SoEddyOver);
        return null;
    }
    /// <summary>
    /// 把当前窗体加载到当前窗体集合中
    /// </summary>
    /// <param name="SoEddyOver">窗体预设的名字</param>
    private void CivicUITruthMoose(string SoEddyOver, object SoEddyAdvent)
    {
        //ui窗体基类
        RealUITruth baseUIForm;
        //从所有窗体集合中得到的窗体
        RealUITruth baseUIFormFromAllCache;
        //如果正在显示的集合中存在该窗体，直接返回
        _MarPrecedeKnotUITruth.TryGetValue(SoEddyOver, out baseUIForm);
        if (baseUIForm != null) return;
        //把当前窗体，加载到正在显示集合中
        _MarALLUITruth.TryGetValue(SoEddyOver, out baseUIFormFromAllCache);
        if (baseUIFormFromAllCache != null)
        {
            _MarPrecedeKnotUITruth.Add(SoEddyOver, baseUIFormFromAllCache);
            //显示当前窗体
            baseUIFormFromAllCache.Display(SoEddyAdvent);
            
        }
    }

    /// <summary>
    /// 卸载ui窗体从当前显示的集合缓存中
    /// </summary>
    /// <param name="strUIFormsName"></param>
    private void PantUITruthMoose(string strUIFormsName)
    {
        //ui窗体基类
        RealUITruth baseUIForms;
        //正在显示ui窗体缓存集合没有记录，则直接返回
        _MarPrecedeKnotUITruth.TryGetValue(strUIFormsName, out baseUIForms);
        if (baseUIForms == null) return;
        //指定ui窗体，运行隐藏，且从正在显示ui窗体缓存集合中移除
        baseUIForms.Hidding();
        _MarPrecedeKnotUITruth.Remove(strUIFormsName);
    }

    /// <summary>
    /// 加载ui窗体到当前显示窗体集合，且，隐藏其他正在显示的页面
    /// </summary>
    /// <param name="strUIFormsName"></param>
    private void CivicUIGeyserDyMooseBeefGreek(string strUIFormsName, object SoEddyAdvent)
    {
        //窗体基类
        RealUITruth baseUIForms;
        //所有窗体集合中的窗体基类
        RealUITruth baseUIFormsFromAllCache;
        _MarPrecedeKnotUITruth.TryGetValue(strUIFormsName, out baseUIForms);
        //正在显示ui窗体缓存集合里有记录，直接返回
        if (baseUIForms != null) return;
        Debug.Log("关闭其他窗体");
        //正在显示ui窗体缓存 与栈缓存集合里所有的窗体进行隐藏处理
        List<RealUITruth> ShowUIFormsList = new List<RealUITruth>(_MarPrecedeKnotUITruth.Values);
        foreach (RealUITruth baseUIFormsItem in ShowUIFormsList)
        {
            //Debug.Log("_DicCurrentShowUIForms---------" + baseUIFormsItem.transform.name);
            if (baseUIFormsItem.PrecedeUILieu.UIForms_Type == UIFormType.PopUp)
            {
                //baseUIFormsItem.Hidding();
                PantUITruthWellMooseCanKnotGreek(baseUIFormsItem.GetType().Name);
            }
        }
        List<RealUITruth> CurrentUIFormsList = new List<RealUITruth>(_StaPrecedeUITruth);
        foreach (RealUITruth baseUIFormsItem in CurrentUIFormsList)
        {
            //Debug.Log("_StaCurrentUIForms---------"+baseUIFormsItem.transform.name);
            //baseUIFormsItem.Hidding();
            PantUITruthWellMooseCanKnotGreek(baseUIFormsItem.GetType().Name);
        }
        //把当前窗体，加载到正在显示ui窗体缓存集合中 
        _MarALLUITruth.TryGetValue(strUIFormsName, out baseUIFormsFromAllCache);
        if (baseUIFormsFromAllCache != null)
        {
            _MarPrecedeKnotUITruth.Add(strUIFormsName, baseUIFormsFromAllCache);
            baseUIFormsFromAllCache.Display(SoEddyAdvent);
        }
    }
    /// <summary>
    /// 把当前窗体加载到当前窗体集合中
    /// </summary>
    /// <param name="SoEddyOver">窗体预设的名字</param>
    private void CivicUITruthMooseFineDodge(string SoEddyOver, object SoEddyAdvent)
    {
        //ui窗体基类
        RealUITruth baseUIForm;
        //从所有窗体集合中得到的窗体
        RealUITruth baseUIFormFromAllCache;
        //如果正在显示的集合中存在该窗体，直接返回
        _MarPrecedeKnotUITruth.TryGetValue(SoEddyOver, out baseUIForm);
        if (baseUIForm != null) return;
        bool havePopUp = false;
        foreach (RealUITruth uiforms in _MarPrecedeKnotUITruth.Values)
        {
            if (uiforms.PrecedeUILieu.UIForms_Type == UIFormType.PopUp)
            {
                havePopUp = true;
                break;
            }
        }
        if (!havePopUp)
        {
            //把当前窗体，加载到正在显示集合中
            _MarALLUITruth.TryGetValue(SoEddyOver, out baseUIFormFromAllCache);
            if (baseUIFormFromAllCache != null)
            {
                _MarPrecedeKnotUITruth.Add(SoEddyOver, baseUIFormFromAllCache);
                //显示当前窗体
                baseUIFormFromAllCache.Display(SoEddyAdvent);

            }
        }
        else
        {
            _FineUITruth.Add(new UIFormParams() { SoEddyOver = SoEddyOver, SoEddyAdvent = SoEddyAdvent });
        }
        
    }
    /// <summary>
    /// 卸载ui窗体从当前显示窗体集合缓存中，且显示其他原本需要显示的页面
    /// </summary>
    /// <param name="strUIFormsName"></param>
    private void PantUITruthWellMooseCanKnotGreek(string strUIFormsName)
    {
        //ui窗体基类
        RealUITruth baseUIForms;
        _MarPrecedeKnotUITruth.TryGetValue(strUIFormsName, out baseUIForms);
        if (baseUIForms == null) return;
        //指定ui窗体 ，运行隐藏状态，且从正在显示ui窗体缓存集合中删除
        baseUIForms.Hidding();
        _MarPrecedeKnotUITruth.Remove(strUIFormsName);
        //正在显示ui窗体缓存与栈缓存集合里素有窗体进行再次显示
        //foreach (RealUITruth baseUIFormsItem in _DicCurrentShowUIForms.Values)
        //{
        //    baseUIFormsItem.Redisplay();
        //}
        //foreach (RealUITruth baseUIFormsItem in _StaCurrentUIForms)
        //{
        //    baseUIFormsItem.Redisplay();
        //}
    }
    /// <summary>
    /// ui窗体入栈
    /// 功能：1判断栈里是否已经有窗体，有则冻结
    ///   2先判断ui预设缓存集合是否有指定的ui窗体，有则处理
    ///   3指定ui窗体入栈
    /// </summary>
    /// <param name="strUIFormsName"></param>
    private void WiseUITruth(string strUIFormsName, object SoEddyAdvent)
    {
        //ui预设窗体
        RealUITruth baseUI;
        //判断栈里是否已经有窗体,有则冻结
        if (_StaPrecedeUITruth.Count > 0)
        {
            RealUITruth topUIForms = _StaPrecedeUITruth.Peek();
            topUIForms.Ravine();
            //Debug.Log("topUIForms是" + topUIForms.name);
        }
        //先判断ui预设缓存集合是否有指定ui窗体，有则处理
        _MarALLUITruth.TryGetValue(strUIFormsName, out baseUI);
        if (baseUI != null)
        {
            baseUI.Display(SoEddyAdvent);
        }
        else
        {
            Debug.Log(string.Format("/PushUIForms()/ baseUI==null! 核心错误，请检查 strUIFormsName={0} ", strUIFormsName));
        }
        //指定ui窗体入栈
        _StaPrecedeUITruth.Push(baseUI);
       
    }

    /// <summary>
    /// ui窗体出栈逻辑
    /// </summary>
    private void LotUITruth()
    {

        if (_StaPrecedeUITruth.Count >= 2)
        {
            //出栈逻辑
            RealUITruth topUIForms = _StaPrecedeUITruth.Pop();
            //出栈的窗体进行隐藏
            topUIForms.Hidding(() => {
                //出栈窗体的下一个窗体逻辑
                RealUITruth nextUIForms = _StaPrecedeUITruth.Peek();
                //下一个窗体重新显示处理
                nextUIForms.Redisplay();
            });
        }
        else if (_StaPrecedeUITruth.Count == 1)
        {
            RealUITruth topUIForms = _StaPrecedeUITruth.Pop();
            //出栈的窗体进行隐藏处理
            topUIForms.Hidding();
        }
    }


    /// <summary>
    /// 初始化ui窗体预设路径数据
    /// </summary>
    private void WineUITruthLuckySoul()
    {
        IShamanEvening configMgr = new ShamanEveningUpMode(ArtCooler.SYS_PATH_UIFORMS_CONFIG_INFO);
        if (_MarTruthLucky != null)
        {
            _MarTruthLucky = configMgr.MapAdjunct;
        }
    }

    /// <summary>
    /// 初始化UI相机参数
    /// </summary>
    private void WineRefuge()
    {
        //当渲染管线为URP时，将UI相机的渲染方式改为Overlay，并加入主相机堆栈
        RenderPipelineAsset currentPipeline = GraphicsSettings.renderPipelineAsset;
        if (currentPipeline != null && currentPipeline.name == "UniversalRenderPipelineAsset")
        {
            UIRefuge = _BidUIRefuge.GetComponent<Camera>();
            UIRefuge.GetUniversalAdditionalCameraData().renderType = CameraRenderType.Overlay;
            Camera.main.GetUniversalAdditionalCameraData().cameraStack.Add(_BidUIRefuge.GetComponent<Camera>());
        }
    }

    /// <summary>
    /// 清空栈结构体集合
    /// </summary>
    /// <returns></returns>
    private bool CedarStackBelle()
    {
        if(_StaPrecedeUITruth!=null && _StaPrecedeUITruth.Count >= 1)
        {
            _StaPrecedeUITruth.Clear();
            return true;
        }
        return false;
    }
    /// <summary>
    /// 获取当前弹框ui的栈
    /// </summary>
    /// <returns></returns>
    public Stack<RealUITruth> HowPrecedeEddyTruly()
    {
        return _StaPrecedeUITruth;
    }


    /// <summary>
    /// 根据panel名称获取panel gameObject
    /// </summary>
    /// <param name="SoEddyOver"></param>
    /// <returns></returns>
    public GameObject HowDwarfUpOver(string SoEddyOver)
    {
        //ui窗体基类
        RealUITruth baseUIForm;
        //如果正在显示的集合中存在该窗体，直接返回
        _MarALLUITruth.TryGetValue(SoEddyOver, out baseUIForm);
        return baseUIForm?.gameObject;
    }

    /// <summary>
    /// 获取所有打开的panel（不包括Normal）
    /// </summary>
    /// <returns></returns>
    public List<GameObject> HowOpeningSeries(bool containNormal = false)
    {
        List<GameObject> openingPanels = new List<GameObject>();
        List<RealUITruth> allUIFormsList = new List<RealUITruth>(_MarALLUITruth.Values);
        foreach(RealUITruth panel in allUIFormsList)
        {
            if (panel.gameObject.activeInHierarchy)
            {
                if (containNormal || panel._PrecedeUILieu.UIForms_Type != UIFormType.Normal)
                {
                    openingPanels.Add(panel.gameObject);
                }
            }
        }

        return openingPanels;
    }
}

public class UIFormParams
{
    public string SoEddyOver;   // 窗体名称
    public object SoEddyAdvent; // 窗体参数
}
