using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using UnityEngine.UI;
using System.Text;
using DG.Tweening;
using Spine;


public class Technical : MonoBehaviour
{
    [SerializeField] private SkeletonGraphic m_SalinityTourist;
[UnityEngine.Serialization.FormerlySerializedAs("textsObj")]    public GameObject RepaySad;
[UnityEngine.Serialization.FormerlySerializedAs("numberText")]    public Text AnswerPity;

    [Header("Ч������")]
    private Vector3 FidelityBlade;
    private Tween ProduceWeigh;
    [SerializeField] private float OvercrowdBlade= 1.3f;   // ��������ֵ
    [SerializeField] private float Reaction= 0.6f;         // ������ʱ��
    [SerializeField] private Ease WickID= Ease.OutQuad;    // ��0��overshoot�Ļ�������
    [SerializeField] private Ease WickIts= Ease.InQuad;    // ��overshoot��1�Ļ�������
    public void DeadGold(int number)
    {
        // 防止对象被隐藏或销毁时操作Tween
        if (!gameObject.activeInHierarchy || RepaySad == null || m_SalinityTourist == null) return;

        // Kill旧Tween（更健壮）
        if (ProduceWeigh != null && ProduceWeigh.IsActive())
            ProduceWeigh.Kill();
        DG.Tweening.DOTween.Kill(this);

        m_SalinityTourist.gameObject.SetActive(false);
        m_SalinityTourist.gameObject.SetActive(true);
        m_SalinityTourist.AnimationState.ClearTracks();
        m_SalinityTourist.AnimationState.SetAnimation(0, "animation", false);
        FidelityBlade = Vector3.one;
        RepaySad.gameObject.SetActive(true);
        RepaySad.transform.localScale = Vector3.zero;
        StringBuilder stringBuilder = new StringBuilder(); 
        stringBuilder.Append("x");
        stringBuilder.Append(number);
        AnswerPity.text = stringBuilder.ToString();
        Sequence sequence = DOTween.Sequence().SetId(this);
        sequence.Append(RepaySad.transform.DOScale(FidelityBlade * OvercrowdBlade, Reaction * 0.35f)
            .SetEase(WickID));
        sequence.Append(RepaySad.transform.DOScale(FidelityBlade, 0.1f)
            .SetEase(WickIts));
        sequence.Insert(0.8f, DOVirtual.DelayedCall(0.1f, () => { }));
        sequence.OnComplete(() =>
        {
            if (RepaySad != null)
                RepaySad.transform.localScale = Vector3.zero;
        });
        ProduceWeigh = sequence;
    }
    public void Update() 
    {
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            DeadGold(1);
        }
    }

    private void OnDestroy()
    {
        if (ProduceWeigh != null && ProduceWeigh.IsActive())
            ProduceWeigh.Kill();
        DG.Tweening.DOTween.Kill(this);
    }
}
