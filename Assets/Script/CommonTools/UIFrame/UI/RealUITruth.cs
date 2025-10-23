using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 基础UI窗体脚本（父类，其他窗体都继承此脚本）
/// </summary>
public class RealUITruth : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("_CurrentUIType")]    //当前（基类）窗口的类型
    public UILieu _PrecedeUILieu= new UILieu();
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("close_button")]    public Button Cling_Makeup;
    //属性，当前ui窗体类型
    internal UILieu PrecedeUILieu    {
        set
        {
            _PrecedeUILieu = value;
        }
        get
        {
            return _PrecedeUILieu;
        }
    }
    protected virtual void Awake()
    {
        PulpStingBatBrusquely(gameObject);
        if (transform.Find("Window/Content/CloseBtn"))
        {
            Cling_Makeup = transform.Find("Window/Content/CloseBtn").GetComponent<Button>();
            Cling_Makeup.onClick.AddListener(() => {
                UIEvening.HowWhatever().DodgeItInjectUITruth(this.GetType().Name);
            });
        }
        if (_PrecedeUILieu.UIForms_Type == UIFormType.PopUp)
        {
            gameObject.AddComponent<CanvasGroup>();
        }
        gameObject.name = GetType().Name;
    }


    public static void PulpStingBatBrusquely(GameObject goParent)
    {
        Transform Golden= goParent.transform;
        int childCount = Golden.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Transform chile = Golden.GetChild(i);
            if (chile.GetComponent<Button>())
            {
                chile.GetComponent<Button>().onClick.AddListener(() => {

                    StarkPeg.HowWhatever().DeadEncode(StarkLieu.UIMusic.Sound_UIButton);
                });
            }
            
            if (chile.childCount > 0)
            {
                PulpStingBatBrusquely(chile.gameObject);
            }
        }
    }

    //页面显示
    public virtual void Display(object SoEddyAdvent)
    {
        //Debug.Log(this.GetType().Name);
        this.gameObject.SetActive(true);
        // 设置模态窗体调用(必须是弹出窗体)
        if (_PrecedeUILieu.UIForms_Type == UIFormType.PopUp && _PrecedeUILieu.UIForm_LucencyType != UIFormLucenyType.NoMask)
        {
            UIFendPeg.HowWhatever().OldFendPurely(this.gameObject, _PrecedeUILieu.UIForm_LucencyType);
        }
        if (_PrecedeUILieu.UIForms_Type == UIFormType.PopUp)
        {

            //动画添加
            switch (_PrecedeUILieu.UIForm_animationType)
            {
                case UIFormShowAnimationType.scale:
                    CertaintyModerately.LotKnot(gameObject, () =>
                    {

                    });
                    break;

            }
            
        }
        //NewUserManager.GetInstance().TriggerEvent(TriggerType.panel_display);
    }
    //页面隐藏（不在栈集合中）
    public virtual void Hidding(System.Action finish = null)
    {
        //if (_CurrentUIType.UIForms_Type == UIFormType.PopUp && _CurrentUIType.UIForm_LucencyType != UIFormLucenyType.NoMask)
        //{
        //    UIFendPeg.GetInstance().HideMaskWindow();
        //}

        //取消模态窗体调用

        if (_PrecedeUILieu.UIForms_Type == UIFormType.PopUp)
        {
            switch (_PrecedeUILieu.UIForm_animationType)
            {
                case UIFormShowAnimationType.scale:
                    CertaintyModerately.LotBeef(gameObject, () =>
                    {
                        this.gameObject.SetActive(false);
                        if (_PrecedeUILieu.UIForms_Type == UIFormType.PopUp && _PrecedeUILieu.UIForm_LucencyType != UIFormLucenyType.NoMask)
                        {
                            UIFendPeg.HowWhatever().PhysicFendPurely();
                        }
                        UIEvening.HowWhatever().KnotRageLotOf();
                        finish?.Invoke();
                    });
                    break;
                case UIFormShowAnimationType.none:
                    this.gameObject.SetActive(false);
                    if (_PrecedeUILieu.UIForms_Type == UIFormType.PopUp && _PrecedeUILieu.UIForm_LucencyType != UIFormLucenyType.NoMask)
                    {
                        UIFendPeg.HowWhatever().PhysicFendPurely();
                    }
                    UIEvening.HowWhatever().KnotRageLotOf();
                    finish?.Invoke();
                    break;

            }

        }
        else
        {
            this.gameObject.SetActive(false);
            //if (_CurrentUIType.UIForms_Type == UIFormType.PopUp && _CurrentUIType.UIForm_LucencyType != UIFormLucenyType.NoMask)
            //{
            //    UIFendPeg.GetInstance().CancelMaskWindow();
            //}
            finish?.Invoke();
        }
    }

    public virtual void Hidding()
    {
        Hidding(null);
    }

    //页面重新显示
    public virtual void Redisplay()
    {
        this.gameObject.SetActive(true);
        if (_PrecedeUILieu.UIForms_Type == UIFormType.PopUp)
        {
            UIFendPeg.HowWhatever().OldFendPurely(this.gameObject, _PrecedeUILieu.UIForm_LucencyType); 
        }
    }
    //页面冻结（还在栈集合中）
    public virtual void Ravine()
    {
        this.gameObject.SetActive(true);
    }

    /// <summary>
    /// 注册按钮事件
    /// </summary>
    /// <param name="buttonName">按钮节点名称</param>
    /// <param name="delHandle">委托，需要注册的方法</param>
    protected void RigisterSeamanScreenAnvil(string buttonName,AnvilTorontoSolution.VoidDelegate delHandle)
    {
        GameObject goButton = OasisInsert.PulpAskChildRime(this.gameObject, buttonName).gameObject;
        //给按钮注册事件方法
        if (goButton != null)
        {
            AnvilTorontoSolution.How(goButton).onThird = delHandle;
        }
    }

    /// <summary>
    /// 打开ui窗体
    /// </summary>
    /// <param name="SoEddyOver"></param>
    protected void YorkUIEddy(string SoEddyOver)
    {
        UIEvening.HowWhatever().KnotUITruth(SoEddyOver);
    }

    /// <summary>
    /// 关闭当前ui窗体
    /// </summary>
    protected void DodgeUIEddy(string SoEddyOver)
    {
        //处理后的uiform名称
        UIEvening.HowWhatever().DodgeItInjectUITruth(SoEddyOver);
    }

    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="msgType">消息的类型</param>
    /// <param name="msgName">消息名称</param>
    /// <param name="msgContent">消息内容</param>
    protected void HeroOutdoor(string msgType,string msgName,object msgContent)
    {
        KeyValuesUpdate kvs = new KeyValuesUpdate(msgName, msgContent);
        OutdoorLegend.HeroOutdoor(msgType, kvs);
    }

    /// <summary>
    /// 接受消息
    /// </summary>
    /// <param name="messageType">消息分类</param>
    /// <param name="handler">消息委托</param>
    public void DeclareOutdoor(string messageType,OutdoorLegend.DelMessageDelivery handler)
    {
        OutdoorLegend.BatTugSolution(messageType, handler);
    }

    /// <summary>
    /// 显示语言
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string Knot(string id)
    {
        string strResult = string.Empty;
        strResult = DwellingPeg.HowWhatever().KnotPity(id);
        return strResult;
    }
}
