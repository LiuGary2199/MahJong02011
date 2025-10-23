using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NssTrayPriceDwarf : RealUITruth
{
    public static NssTrayPriceDwarf instance;
[UnityEngine.Serialization.FormerlySerializedAs("Hand")]
    public GameObject File;

    /// <summary>
    /// 高亮显示目标
    /// </summary>
    private GameObject Maraca;
[UnityEngine.Serialization.FormerlySerializedAs("Text")]
    public Text Pity;
    /// <summary>
    /// 区域范围缓存
    /// </summary>
    private Vector3[] Similar= new Vector3[4];
    /// <summary>
    /// 最终的偏移x
    /// </summary>
    private float MaracaSierraX= 0;
    /// <summary>
    /// 最终的偏移y
    /// </summary>
    private float MaracaSierraY= 0;
    /// <summary>
    /// 遮罩材质
    /// </summary>
    private Material Commerce;
    /// <summary>
    /// 当前的偏移x
    /// </summary>
    private float ProduceSierraX= 0f;
    /// <summary>
    /// 当前的偏移y
    /// </summary>
    private float ProduceSierraY= 0f;
    /// <summary>
    /// 高亮区域缩放的动画时间
    /// </summary>
    private float LastlySlit= 0.1f;
    /// <summary>
    /// 事件渗透组件
    /// </summary>
    private MechanicAnvilDefensive LoessDefensive;

    protected override void Awake()
    {
        base.Awake();

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// 显示引导遮罩
    /// </summary>
    /// <param name="_target">要引导到的目标对象</param>
    /// <param name="text">引导说明文案</param>

    public void KnotPrice(GameObject _target, string text)
    {
        if (_target == null)
        {
            File.SetActive(false);
            if (Commerce == null)
            {
                Commerce = GetComponent<Image>().material;
            }
            Commerce.SetVector("_Center", new Vector4(0, 0, 0, 0));
            Commerce.SetFloat("_SliderX", 0);
            Commerce.SetFloat("_SliderY", 0);
            // 如果没有target，点击任意区域关闭引导
            GetComponent<Button>().onClick.AddListener(() =>
            {
                DodgeUIEddy(GetType().Name);
            });
        }
        else
        {
            DOTween.Kill("NewUserHandAnimation");
            Wine(_target);
            GetComponent<Button>().onClick.RemoveAllListeners();
        }

        if (!string.IsNullOrEmpty(text))
        {
            Pity.text = text;
            Pity.transform.parent.gameObject.SetActive(true);
        }
        else
        {
            Pity.transform.parent.gameObject.SetActive(false);
        }
    }

    private float MaracaMedia= 1;
    private float MaracaWeldon= 1;
    public void Wine(GameObject _target)
    {
        this.Maraca = _target;

        LoessDefensive = GetComponent<MechanicAnvilDefensive>();
        // 删除 eventPenetrate.SetTargetImage(_target.GetComponent<Image>()); 相关调用

        Canvas canvas = UIEvening.HowWhatever().BookSphere.GetComponent<Canvas>();

        //获取高亮区域的四个顶点的世界坐标
        if (Maraca.GetComponent<RectTransform>() != null)
        {
            Maraca.GetComponent<RectTransform>().GetWorldCorners(Similar);
        }
        else
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(_target.transform.position);
            pos = UIEvening.HowWhatever()._BidUIRefuge.GetComponent<Camera>().ScreenToWorldPoint(pos);
            Similar[0] = new Vector3(pos.x - MaracaMedia, pos.y - MaracaWeldon);
            Similar[1] = new Vector3(pos.x - MaracaMedia, pos.y + MaracaWeldon);
            Similar[2] = new Vector3(pos.x + MaracaMedia, pos.y + MaracaWeldon);
            Similar[3] = new Vector3(pos.x + MaracaMedia, pos.y - MaracaWeldon);
        }
        //计算高亮显示区域在画布中的范围
        MaracaSierraX = Vector2.Distance(KneelDySpherePot(canvas, Similar[0]), KneelDySpherePot(canvas, Similar[3])) / 2f;
        MaracaSierraY = Vector2.Distance(KneelDySpherePot(canvas, Similar[0]), KneelDySpherePot(canvas, Similar[1])) / 2f;
        //计算高亮显示区域的中心
        float x = Similar[0].x + ((Similar[3].x - Similar[0].x) / 2);
        float y = Similar[0].y + ((Similar[1].y - Similar[0].y) / 2);
        Vector3 centerWorld = new Vector3(x, y, 0);
        Vector2 Strict= KneelDySpherePot(canvas, centerWorld);
        //设置遮罩材质中的中心变量
        Vector4 centerMat = new Vector4(Strict.x, Strict.y, 0, 0);
        Commerce = GetComponent<Image>().material;
        Commerce.SetVector("_Center", centerMat);
        //计算当前高亮显示区域的半径
        RectTransform canRectTransform = canvas.transform as RectTransform;
        if (canRectTransform != null)
        {
            //获取画布区域的四个顶点
            canRectTransform.GetWorldCorners(Similar);
            //计算偏移初始值
            for (int i = 0; i < Similar.Length; i++)
            {
                if (i % 2 == 0)
                {
                    ProduceSierraX = Mathf.Max(Vector3.Distance(KneelDySpherePot(canvas, Similar[i]), Strict), ProduceSierraX);
                }
                else
                {
                    ProduceSierraY = Mathf.Max(Vector3.Distance(KneelDySpherePot(canvas, Similar[i]), Strict), ProduceSierraY);
                }
            }
        }
        //设置遮罩材质中当前偏移的变量
        Commerce.SetFloat("_SliderX", ProduceSierraX);
        Commerce.SetFloat("_SliderY", ProduceSierraY);
        File.transform.localScale = new Vector3(1, 1, 1);
        StartCoroutine(KnotFile(Strict));
    }

    private IEnumerator KnotFile(Vector2 center)
    {
        File.SetActive(false);
        yield return new WaitForSeconds(LastlySlit);

        File.transform.localPosition = center;
        FileCertainty();

        File.SetActive(true);
    }
    /// <summary>
    /// 收缩速度
    /// </summary>
    private float LastlyThreatenX= 0f;
    private float LastlyThreatenY= 0f;
    private void Update()
    {
        if (Commerce == null) return;

        ProduceSierraX = MaracaSierraX;
        Commerce.SetFloat("_SliderX", ProduceSierraX);
        ProduceSierraY = MaracaSierraY;
        Commerce.SetFloat("_SliderY", ProduceSierraY);
        //从当前偏移量到目标偏移量差值显示收缩动画
        //float valueX = Mathf.SmoothDamp(currentOffsetX, targetOffsetX, ref shrinkVelocityX, shrinkTime);
        //float valueY = Mathf.SmoothDamp(currentOffsetY, targetOffsetY, ref shrinkVelocityY, shrinkTime);
        //if (!Mathf.Approximately(valueX, currentOffsetX))
        //{
        //    currentOffsetX = valueX;
        //    material.SetFloat("_SliderX", currentOffsetX);
        //}
        //if (!Mathf.Approximately(valueY, currentOffsetY))
        //{
        //    currentOffsetY = valueY;
        //    material.SetFloat("_SliderY", currentOffsetY);
        //}


    }

    /// <summary>
    /// 世界坐标转换为画布坐标
    /// </summary>
    /// <param name="canvas">画布</param>
    /// <param name="world">世界坐标</param>
    /// <returns></returns>
    private Vector2 KneelDySpherePot(Canvas canvas, Vector3 world)
    {
        Vector2 Latitude;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, world, canvas.GetComponent<Camera>(), out Latitude);
        return Latitude;
    }

    public void FileCertainty()
    {

        var s = DOTween.Sequence();
        s.Append(File.transform.DOLocalMoveY(File.transform.localPosition.y + 10f, 0.5f));
        s.Append(File.transform.DOLocalMoveY(File.transform.localPosition.y, 0.5f));
        s.Join(File.transform.DOScaleY(1.1f, 0.125f));
        s.Join(File.transform.DOScaleX(0.9f, 0.125f).OnComplete(() =>
        {
            File.transform.DOScaleY(0.9f, 0.125f);
            File.transform.DOScaleX(1.1f, 0.125f).OnComplete(() =>
            {
                File.transform.DOScale(1f, 0.125f);
            });
        }));
        s.SetLoops(-1);
        s.SetId("NewUserHandAnimation");
    }

    public void OnDisable()
    {
        DOTween.Kill("NewUserHandAnimation");
    }
}
