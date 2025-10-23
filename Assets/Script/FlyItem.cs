using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class FlyItem : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("FlyButton")]    public Button AxeSeaman;
[UnityEngine.Serialization.FormerlySerializedAs("CashValue")]    public Text FareQuery;

    private Sequence _One1;
    private Sequence _One2;

    private double _LashGet;

    private void Awake()
    {
        AxeSeaman.onClick.AddListener(() => {
            //if (NewbieManager.GetInstance().IsOpenNewbie) { return; }
            //if (BubbleManager.GetInstance().IsWinGame()) { return; }
            AxeEvening.Instance.ItYorkAxe = true;
            AxeEvening.Instance.YorkIEAxe();
            SpitAnvilPawnee.HowWhatever().HeroAnvil("1011");
            HowGreece();

        });
        CupBlueLatest();
    }


    public void AxeDead()
    {
        transform.DOPlay();
        _One1.Play();
        _One2.Play();
    }

    public void AxeEndow()
    {
        transform.DOPause();
        _One1.Pause();
        _One2.Pause();
    }

    public void AxeRing()
    {
        _One1.Kill();
        _One2.Kill();
        transform.DOKill();
    }

    private void HowGreece()
    {
        //RewardPanelData data = new RewardPanelData();
        //data.MiniType = "Fly";
        //data.Dic_Reward.Add(RewardType.cash, _cashNum);
        //RewardManager.GetInstance().OpenLevelCompletePanel(data);
        ADEvening.Whatever.TillGreeceSugar((success) =>
        {
            if (success)
            {
                MainDwarf.Instance.BatFare(_LashGet, this.transform);
                OceaniaAxeHigh();
                 SpitAnvilPawnee.HowWhatever().HeroAnvil("1009");
            }
        }, "5");
    }

    private void CupBlueLatest()
    {
        _LashGet = CryBustPeg.instance.LullSoul.bubbledatalist[0].reward_num * GameUtil.GetCashMulti();
        _LashGet = Mathf.Ceil((float)_LashGet);
        FareQuery.text = "+" + _LashGet;
        _One1 = DOTween.Sequence();
        _One2 = DOTween.Sequence();
        /*int leftOrRight = Random.Range(0, 2);
        if (leftOrRight == 0)
        {*/
            PackAxe();
        /*}
        else
        {
            RigthFly();
        }*/
    }

    private void PackAxe()
    {
        transform.localPosition = new Vector3(-450f, 0, 0);
        _One1 = DOTween.Sequence();
        _One2 = DOTween.Sequence();
        _One1.Append(transform.DOLocalMoveY(-250f - Random.Range(-100f, 100f), 2.5f).SetEase(Ease.InSine));
        _One1.Append(transform.DOLocalMoveY(0, 2.5f).SetEase(Ease.InSine));
        _One1.SetLoops(-1);
        _One1.Play();

        _One2.Append(transform.DOScale(1.1f, 0.5f).SetEase(Ease.Linear));
        _One2.Append(transform.DOScale(1f, 0.5f).SetEase(Ease.Linear));
        _One2.SetLoops(-1);
        _One2.Play();
        transform.DOLocalMoveX(650, 10f).SetEase(Ease.Linear).OnComplete(() =>
        {
            if (AxeEvening.Instance.ItYorkAxe)
            {
                OceaniaAxeHigh();
            }
            else
            {
                AxeRing();
                StartCoroutine(IbexAxe(() => { OnsetAxe(); }));
            }
        });
    }

    private void OnsetAxe()
    {
        transform.localPosition = new Vector3(450, 100, 0);
        _One1 = DOTween.Sequence();
        _One2 = DOTween.Sequence();
        _One1.Append(transform.DOLocalMoveY(0, 2.5f).SetEase(Ease.InSine));
        _One1.Append(transform.DOLocalMoveY(100, 2.5f).SetEase(Ease.InSine));
        _One1.SetLoops(-1);
        _One1.Play();

        _One2.Append(transform.DOScale(1.1f, 0.5f).SetEase(Ease.Linear));
        _One2.Append(transform.DOScale(1f, 0.5f).SetEase(Ease.Linear));
        _One2.SetLoops(-1);
        _One2.Play();
        transform.DOLocalMoveX(-650, 10f).SetEase(Ease.Linear).OnComplete(() =>
        {
            if (AxeEvening.Instance.ItYorkAxe)
            {
                OceaniaAxeHigh();
            }
            else
            {
                AxeRing();
                StartCoroutine(IbexAxe(() => { PackAxe(); }));
            }

        });
    }

    IEnumerator IbexAxe(Action action)
    {
        yield return new WaitForSeconds(5f);
        action?.Invoke();
    }

    public void OceaniaAxeHigh()
    {
        AxeRing();
        GetComponent<RectTransform>().DOKill();
        Destroy(gameObject);
    }

}
