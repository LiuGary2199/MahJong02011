using Mkey;
using UnityEngine;

/// <summary>
/// 随机设置一张1080x2340尺寸的精灵为背景，并根据屏幕尺寸自动等比例铺满。
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class UnusedUnoccupiedInsult : MonoBehaviour
{
    [Header("1080x2340尺寸的背景图集合")]
[UnityEngine.Serialization.FormerlySerializedAs("backgroundSprites")]    public Sprite[] InadequateBroadly;

    private SpriteRenderer AttainWestward;

    void Awake()
    {
        AttainWestward = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        UnusedOldUnoccupied();
    }

    /// <summary>
    /// 随机选择一张背景图并设置到SpriteRenderer上，然后自动铺满屏幕
    /// </summary>
    public void UnusedOldUnoccupied()
    {
        if (InadequateBroadly == null || InadequateBroadly.Length == 0)
        {
            Debug.LogWarning("未设置背景图片数组");
            return;
        }
        if (LullDeltaMisery.PrecedeDelta <= 50)
        {
            // 随机选择一张图片
            Sprite selected = InadequateBroadly[0];
            AttainWestward.sprite = selected;
        }
        else
        {
            Sprite selected = InadequateBroadly[1];
            AttainWestward.sprite = selected;
            // 随机选择一张图片
            // Sprite selected = backgroundSprites[Random.Range(0, backgroundSprites.Length)];
            //  spriteRenderer.sprite = selected;
        }

        DogDyDollar();
    }

    /// <summary>
    /// 根据当前屏幕尺寸自动等比例缩放并铺满屏幕
    /// </summary>
    private void DogDyDollar()
    {
        if (AttainWestward.sprite == null) return;

        // 获取图片原始像素尺寸
        float spriteWidth = AttainWestward.sprite.rect.width;
        float spriteHeight = AttainWestward.sprite.rect.height;

        // 获取图片的像素到单位的比例（Pixels Per Unit）
        float ppu = AttainWestward.sprite.pixelsPerUnit;
        float worldSpriteWidth = spriteWidth / ppu;
        float worldSpriteHeight = spriteHeight / ppu;

        // 获取摄像机
        Camera Nor= Camera.main;
        if (Nor == null)
        {
            Debug.LogWarning("找不到主摄像机");
            return;
        }

        // 计算屏幕在世界坐标下的宽高
        float worldScreenHeight = Nor.orthographicSize * 2f;
        float worldScreenWidth = worldScreenHeight * Nor.aspect;

        // 计算缩放比例，取较大值保证铺满（可能有部分被裁切）
        float scaleX = worldScreenWidth / worldSpriteWidth;
        float scaleY = worldScreenHeight / worldSpriteHeight;
        float Climb= Mathf.Max(scaleX, scaleY);

        // 应用缩放
        transform.localScale = new Vector3(Climb, Climb, 1);
    }
} 