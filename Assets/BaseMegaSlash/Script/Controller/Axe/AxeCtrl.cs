// Project  RopeUp
// FileName  RopeLoopItem.cs
// Author  AX
// Desc
// CreateAt   2025-09-05 09:09:41 
//


using DG.Tweening;
using UnityEngine;

public class AxeCtrl : MonoBehaviour
{
    private Vector3 _startPos;

    public bool isPlaying;

    private float _swingTime;

    private Rigidbody2D rb; // 刚体组件

    private Camera mainCamera; // 主摄像机

    private bool _isCharging;

    private void Awake()
    {
        isPlaying = false;
        _startPos = transform.localPosition;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // circleCollider = GetComponent<CircleCollider2D>();
        mainCamera = Camera.main;
        _isCharging = false;

        // 设置刚体属性
        // if (rb != null)
        // {
        //     rb.gravityScale = 0f; // 不受重力影响
        //     rb.drag = 0.2f; // 设置阻力
        // }
    }


    private void Update()
    {
        HandleInput();
    }


    private void HandleInput()
    {
        // 检测触摸输入
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    BeginTouch(touch);
                    break;
                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    StayTouch(touch);
                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    EndTouch(touch);
                    break;
            }
        }

        // int ide
        if (Input.GetMouseButtonDown(0))
        {
            BeginGrowHandle();
        }
        else if (Input.GetMouseButton(0))
        {
            GrowHandle();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            DoAttack();
        }
    }


    private void BeginTouch(Touch touch)
    {
        BeginGrowHandle();
    }


    private void BeginGrowHandle()
    {
        if (Input.mousePosition.y > Screen.height * 0.7) return;
        _isCharging = true;
        GrowHandle();
    }


    private void StayTouch(Touch touch)
    {
        GrowHandle();
    }

    private void GrowHandle()
    {
        if (!_isCharging) return;

        if (transform.localPosition.y > 800) return;
        transform.Translate(Vector3.up * 1f * Time.deltaTime);
    }


    private void EndTouch(Touch touch)
    {
        DoAttack();
    }


    private void DoAttack()
    {
        if(!_isCharging) return;
        A_AudioManager.Instance.PlaySound("Act");
        _isCharging = false;
        transform.parent.transform.DOLocalRotate(new Vector3(0f, 0f, -90f), 0.2f).SetEase(Ease.OutBack).OnComplete(() =>
        {
            Reset();
        });
    }

    public void Reset()
    {
        transform.localPosition = _startPos;
        transform.parent.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
    }
}