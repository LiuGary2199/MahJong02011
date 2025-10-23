// Project  Repository-BaseA
// FileName  A_FinishPop.cs
// Author  AX
// Desc
// CreateAt  2025-09-08 16:09:09 
//


using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class A_FinishPop : MonoBehaviour
{
    public Button getNormalBtn;

    public Button getMoreBtn;

    public Text rewardText;

    private readonly int _rewardMulti = 2;

    private readonly int _rewardNum = 200;

    private int _curCoin;

    private void Start()
    {
        getMoreBtn.onClick.AddListener(() =>
        {
            A_AudioManager.Instance.PlaySound("Click");
            A_ADManager.Instance.playRewardVideo((success) =>
            {
                if (success)
                {
                    GetMoreReward();
                }
                else
                {
                    A_BattleAxeManager.Instance.ShowToastPop("Ad Not Ready");
                }
            });
        });

        getNormalBtn.onClick.AddListener(() =>
        {
            A_AudioManager.Instance.PlaySound("Click");
            GetNormalReward();
        });
    }

    private void OnEnable()
    {
        _curCoin = _rewardNum;
        A_AudioManager.Instance.PlaySound("Win");
        ShowUI();
    }

    private void ShowUI()
    {
        rewardText.text = _rewardNum.ToString();
        getMoreBtn.gameObject.SetActive(true);
        getNormalBtn.gameObject.SetActive(true);
    }


    private void ChangeNumber()
    {
        _curCoin *= _rewardMulti;
        rewardText.text = _curCoin.ToString();
    }

    private async void GetMoreReward()
    {
        getMoreBtn.gameObject.SetActive(false);
        getNormalBtn.gameObject.SetActive(false);
        ChangeNumber();
        await UniTask.Delay(500);
        GetRewardAndClose();
    }


    private async void GetNormalReward()
    {
        getMoreBtn.gameObject.SetActive(false);
        getNormalBtn.gameObject.SetActive(false);
        await UniTask.Delay(100);
        GetRewardAndClose();
    }


    private void GetRewardAndClose()
    {
        A_PlayerManager.Instance.AddCoin(_curCoin);
        A_LevelManager.Instance.AddGameLevel();
        A_BattleAxeManager.Instance.RefreshTopBar();
        A_BattleAxeManager.Instance.ToNextLevel();
        gameObject.SetActive(false);
    }
}