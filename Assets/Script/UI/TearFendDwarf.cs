using UnityEngine;
using UnityEngine.UI;

public class TearFendDwarf : MonoBehaviour
{
    [Header("目标设置")]
[UnityEngine.Serialization.FormerlySerializedAs("targetObj")]    public GameObject MaracaSad;
[UnityEngine.Serialization.FormerlySerializedAs("padding")]    public float Replant= 10f; // 目标周围的边距

    [Header("动画设置")]
[UnityEngine.Serialization.FormerlySerializedAs("shrinkTime")]    public float LastlySlit= 0.3f;
[UnityEngine.Serialization.FormerlySerializedAs("targetOffsetX")]    public float MaracaSierraX;
[UnityEngine.Serialization.FormerlySerializedAs("targetOffsetY")]    public float MaracaSierraY;

    private Material Commerce;
    private RectTransform MaracaTear;
    private Canvas MaracaSphere;
    private RectTransform DoseTear;
[UnityEngine.Serialization.FormerlySerializedAs("currentOffsetX")]
    public float ProduceSierraX;
[UnityEngine.Serialization.FormerlySerializedAs("currentOffsetY")]    public float ProduceSierraY;
[UnityEngine.Serialization.FormerlySerializedAs("targetPosX")]    public float MaracaPotX;
[UnityEngine.Serialization.FormerlySerializedAs("targetPosY")]    public float MaracaPotY;

    private float LastlyThreatenX= 0f;
    private float LastlyThreatenY= 0f;
    private MechanicAnvilDefensive LoessDefensive;
    private bool ArmMildlySad= false;

    private void Start()
    {
        DoseTear = GetComponent<RectTransform>();
        Commerce = GetComponent<Image>().material;
        LoessDefensive = GetComponent<MechanicAnvilDefensive>();

        // 检查是否有目标对象
        if (MaracaSad != null)
        {
            MaracaTear = MaracaSad.GetComponent<RectTransform>();
            if (MaracaTear != null)
            {
                MaracaSphere = MaracaSad.GetComponentInParent<Canvas>();
                if (MaracaSphere != null)
                {
                    ArmMildlySad = true;
                    MildlyMildlyVolatility();
                }
            }
        }

        if (!ArmMildlySad)
        {
            // 原逻辑：使用Inspector中设置的参数
            Vector4 centerMat = new Vector4(MaracaPotX, MaracaPotY, 0, 0);
            Commerce.SetVector("_Center", centerMat);
        }

        if (LoessDefensive != null && ArmMildlySad)
        {
            LoessDefensive.OldMildlyTear(MaracaTear);
        }
    }

    private void Update()
    {
        if (ArmMildlySad)
        {
            MildlyMildlyVolatility();
        }

        // 原逻辑：平滑动画
        float valueX = Mathf.SmoothDamp(ProduceSierraX, MaracaSierraX, ref LastlyThreatenX, LastlySlit);
        float valueY = Mathf.SmoothDamp(ProduceSierraY, MaracaSierraY, ref LastlyThreatenY, LastlySlit);

        if (!Mathf.Approximately(valueX, ProduceSierraX))
        {
            ProduceSierraX = valueX;
            Commerce.SetFloat("_SliderX", ProduceSierraX);
        }

        if (!Mathf.Approximately(valueY, ProduceSierraY))
        {
            ProduceSierraY = valueY;
            Commerce.SetFloat("_SliderY", ProduceSierraY);
        }
    }

    private void MildlyMildlyVolatility()
    {
        // 获取目标在世界空间的中心点
        Vector3 worldCenter = MaracaTear.TransformPoint(MaracaTear.rect.center);
        // 转换为屏幕空间坐标
        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(MaracaSphere.worldCamera, worldCenter);

        // 转换为遮罩面板的本地坐标
        Vector2 localPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(DoseTear, screenPos, MaracaSphere.worldCamera, out localPos);

        // Debug输出详细信息
      //  Debug.Log($"[MaskPanel] 挖孔世界中心 worldCenter={worldCenter}, screenPos={screenPos}, localPos={localPos}, targetCanvas={targetCanvas}, worldCamera={targetCanvas.worldCamera}");
       // Debug.Log($"[MaskPanel] targetRect.position={targetRect.position}, sizeDelta={targetRect.sizeDelta}, rect={targetRect.rect}");

        // 设置遮罩中心为目标中心
        MaracaPotX = localPos.x;
        MaracaPotY = localPos.y;
        Commerce.SetVector("_Center", new Vector4(MaracaPotX, MaracaPotY, 0, 0));

        // 设置遮罩大小为目标大小加上边距
        MaracaSierraX = (MaracaTear.rect.width / 2) + Replant;
        MaracaSierraY = (MaracaTear.rect.height / 2) + Replant;
    }

    // 外部调用：设置新的目标对象
    public void OldMildly(GameObject newTarget)
    {
        MaracaSad = newTarget;

        if (MaracaSad != null)
        {
            MaracaTear = MaracaSad.GetComponent<RectTransform>();
            if (MaracaTear != null)
            {
                MaracaSphere = MaracaSad.GetComponentInParent<Canvas>();
                if (MaracaSphere != null)
                {
                    ArmMildlySad = true;
                    MildlyMildlyVolatility();

                    if (LoessDefensive != null)
                    {
                        LoessDefensive.OldMildlyTear(MaracaTear);
                    }
                }
            }
        }
        else
        {
            ArmMildlySad = false;
        }
    }
}