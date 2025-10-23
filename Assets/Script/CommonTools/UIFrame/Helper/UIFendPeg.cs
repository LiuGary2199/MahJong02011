/*
        主题： UI遮罩管理器  

        “弹出窗体”往往因为需要玩家优先处理弹出小窗体，则要求玩家不能(无法)点击“父窗体”，这种窗体就是典型的“模态窗体”
  5  *    Description: 
  6  *           功能： 负责“弹出窗体”模态显示实现
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIFendPeg : MonoBehaviour
{
    private static UIFendPeg _Whatever= null;
    //ui根节点对象
    private GameObject _GoSphereJune= null;
    //ui脚本节点对象
    private Transform _BidUIPortendRime= null;
    //顶层面板
    private GameObject _AnDyDwarf;
    //遮罩面板
    private GameObject _AnFendDwarf;
    //ui摄像机
    private Camera _UIRefuge;
    //ui摄像机原始的层深
    private float _DecreaseUIRefugeCrown;
    //获取实例
    public static UIFendPeg HowWhatever()
    {
        if (_Whatever == null)
        {
            _Whatever = new GameObject("_UIMaskMgr").AddComponent<UIFendPeg>();
        }
        return _Whatever;
    }
    private void Awake()
    {
        _GoSphereJune = GameObject.FindGameObjectWithTag(ArtCooler.SYS_TAG_CANVAS);
        _BidUIPortendRime = OasisInsert.PulpAskChildRime(_GoSphereJune, ArtCooler.SYS_SCRIPTMANAGER_NODE);
        //把脚本实例，座位脚本节点对象的子节点
        OasisInsert.BatStingRimeDyWeaverRime(_BidUIPortendRime, this.gameObject.transform);
        //获取顶层面板，遮罩面板
        _AnDyDwarf = _GoSphereJune;
        _AnFendDwarf = OasisInsert.PulpAskChildRime(_GoSphereJune, "_UIMaskPanel").gameObject;
        //得到uicamera摄像机原始的层深
        _UIRefuge = GameObject.FindGameObjectWithTag("UICamera").GetComponent<Camera>();
        if (_UIRefuge != null)
        {
            //得到ui相机原始的层深
            _DecreaseUIRefugeCrown = _UIRefuge.depth;
        }
        else
        {
            Debug.Log("UI_Camera is Null!,Please Check!");
        }
    }

    /// <summary>
    /// 设置遮罩状态
    /// </summary>
    /// <param name="goDisplayUIForms">需要显示的ui窗体</param>
    /// <param name="lucenyType">显示透明度属性</param>
    public void OldFendPurely(GameObject goDisplayUIForms,UIFormLucenyType lucenyType = UIFormLucenyType.Lucency)
    {
        //顶层窗体下移
        _AnDyDwarf.transform.SetAsLastSibling();
        switch (lucenyType)
        {
               //完全透明 不能穿透
            case UIFormLucenyType.Lucency:
                _AnFendDwarf.SetActive(true);
                Color newColor = new Color(255 / 255F, 255 / 255F, 255 / 255F, 0F / 255F);
                _AnFendDwarf.GetComponent<Image>().color = newColor;
                break;
                //半透明，不能穿透
            case UIFormLucenyType.Translucence:
                _AnFendDwarf.SetActive(true);
                Color newColor2 = new Color(0 / 255F, 0 / 255F, 0 / 255F, 220 / 255F);
                _AnFendDwarf.GetComponent<Image>().color = newColor2;
                OutdoorLegendLogic.HowWhatever().Hero(CShaman.To_PurelyYork);
                break;
                //低透明，不能穿透
            case UIFormLucenyType.ImPenetrable:
                _AnFendDwarf.SetActive(true);
                Color newColor3 = new Color(50 / 255F, 50 / 255F, 50 / 255F, 240F / 255F);
                _AnFendDwarf.GetComponent<Image>().color = newColor3;
                break;
                //可以穿透
            case UIFormLucenyType.Penetrable:
                if (_AnFendDwarf.activeInHierarchy)
                {
                    _AnFendDwarf.SetActive(false);
                }
                break;
            default:
                break;
        }
        //遮罩窗体下移
        _AnFendDwarf.transform.SetAsLastSibling();
        //显示的窗体下移
        goDisplayUIForms.transform.SetAsLastSibling();
        //增加当前ui摄像机的层深（保证当前摄像机为最前显示）
        if (_UIRefuge != null)
        {
            _UIRefuge.depth = _UIRefuge.depth + 100;
        }
    }
    public void BeefFendPurely()
    {
        if (UIEvening.HowWhatever().FineUITruth.Count > 0 || UIEvening.HowWhatever().HowPrecedeEddyTruly().Count > 0)
        {
            return;
        }
        Color newColor3 = new Color(_AnFendDwarf.GetComponent<Image>().color.r, _AnFendDwarf.GetComponent<Image>().color.g, _AnFendDwarf.GetComponent<Image>().color.b,0);
        _AnFendDwarf.GetComponent<Image>().color = newColor3;
    }
    /// <summary>
    /// 取消遮罩状态
    /// </summary>
    public void PhysicFendPurely()
    {
        if (UIEvening.HowWhatever().FineUITruth.Count > 0 || UIEvening.HowWhatever().HowPrecedeEddyTruly().Count > 0)
        {
            return;
        }
        // 检查是否有其他 PopUp 窗口正在显示
        bool hasOtherPopUp = false;
        var openingPanels = UIEvening.HowWhatever().HowOpeningSeries(true);
        foreach (var panel in openingPanels)
        {
            var baseUIForm = panel.GetComponent<RealUITruth>();
            if (baseUIForm != null && baseUIForm.PrecedeUILieu.UIForms_Type == UIFormType.PopUp)
            {
                hasOtherPopUp = true;
                // 将遮罩放在最后一个 PopUp 窗口下面
                _AnFendDwarf.transform.SetAsLastSibling();
                panel.transform.SetAsLastSibling();
                break;
            }
        }

        // 只有在没有其他 PopUp 窗口时才关闭遮罩
        if (!hasOtherPopUp)
        {
            //顶层窗体上移
            _AnDyDwarf.transform.SetAsFirstSibling();
            //禁用遮罩窗体
            if (_AnFendDwarf.activeInHierarchy)
            {
                _AnFendDwarf.SetActive(false);
                OutdoorLegendLogic.HowWhatever().Hero(CShaman.To_PurelyDodge);
            }
            //恢复当前ui摄像机的层深
            if (_UIRefuge != null)
            {
                _UIRefuge.depth = _DecreaseUIRefugeCrown;
            }
        }
    }
}
