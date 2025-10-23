// Project  Repository-BaseA
// FileName  A_GamePop.cs
// Author  AX
// Desc
// CreateAt  2025-09-05 14:09:54 
//


using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class A_GamePop : MonoBehaviour
{
    public GameObject playerObj;

    public GameObject emyArea;

    public List<GameObject> emyList;

    public Button settingBtn;

    public Text coinText;

    public GameObject levelObj;
    
    public Text levelText;

    private GameObject _curEmy;

    private void Start()
    {
        settingBtn.onClick.AddListener(OpenSetPop);

        ShowTopBar();
    }


    private void OpenSetPop()
    {
        A_AudioManager.Instance.PlaySound("Click");
        PausePlayer();
        A_BattleAxeManager.Instance.ShowSetPop(true);
    }


    public void InitEmy()
    {
        BGManager.Instance.PauseScrolling(false);

        GameObject emy = Instantiate(emyList[Random.Range(0, emyList.Count)], emyArea.transform, false);
        emy.transform.localPosition = new Vector3(750f, 0, 0);
        emy.gameObject.SetActive(true);
        emy.transform.DOLocalMoveX(300f, 2f).SetEase(Ease.Linear).SetDelay(2f).OnComplete(() =>
        {
            BGManager.Instance.PauseScrolling(true);
            emy.GetComponent<EnemyCtrl>().ShowUI();
            emy.GetComponent<EnemyCtrl>().StartAttack();
        });
        _curEmy = emy;
    }

    public void ClearEmy()
    {
        for (int i = emyArea.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(emyArea.transform.GetChild(i).gameObject);
        }
    }


    public void InitGame()
    {
        playerObj.GetComponent<PlayerCtrl>().InitPlayer();
        InitEmy();
    }

    public void ReSetGame()
    {
        ClearEmy();
        playerObj.GetComponent<PlayerCtrl>().InitPlayer();
        OpenPlayer();
        InitEmy();
    }


    public void ShowTopBar()
    {
        coinText.text = A_PlayerManager.Instance.GetCoin() + "";
        levelText.text = A_LevelManager.Instance.GetGameLevel() + "";
    }

    public void ClosePlayer()
    {
        playerObj.GetComponent<PlayerCtrl>().ResetPlayer();
        levelObj.gameObject.SetActive(false);
        playerObj.gameObject.SetActive(false);
        // BGManager.Instance.PauseScrolling(true);
        if (_curEmy != null)
        {
            _curEmy.GetComponent<EnemyCtrl>().BeKill();
            _curEmy.gameObject.SetActive(false);
        }
    }

    public void PausePlayer()
    {
        levelObj.gameObject.SetActive(false);
        playerObj.gameObject.SetActive(false);
        DOTween.PauseAll();
        if (_curEmy != null)
        {
            _curEmy.gameObject.SetActive(false);
        }
    }


    public void ReShowPlayHp()
    {
        playerObj.GetComponent<PlayerCtrl>().InitPlayer();
    }

    public void OpenPlayer()
    {
        levelObj.gameObject.SetActive(true);
        playerObj.gameObject.SetActive(true);
        DOTween.RestartAll();
        if (_curEmy != null)
        {
            _curEmy.gameObject.SetActive(true);
        }
    }
}