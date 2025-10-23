// Project  Repository-BaseA
// FileName  A_BattleAxeManager.cs
// Author  AX
// Desc
// CreateAt  2025-09-05 09:09:41 
//


using UnityEngine;

public class A_BattleAxeManager : MonoBehaviour
{
    public static A_BattleAxeManager Instance;

    public GameObject gamePop;

    public GameObject homePop;

    public GameObject settingPop;

    public GameObject losePop;

    public GameObject finishPop;

    public GameObject shopPop;

    public GameObject toastPop;

    public int userCoin;

    private readonly int _initHp = 500;
    private readonly int _initDamage = 100;


    private void Awake()
    {
        Application.targetFrameRate = 60;

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        InitData();
    }


    private void InitData()
    {
        bool isNewPlayer = !PlayerPrefs.HasKey(AxeConstant.IsNewPlayer + "Bool") ||
                           BondSoulEvening.HowTape(AxeConstant.IsNewPlayer);

        if (isNewPlayer)
        {
            BondSoulEvening.OldGas(AxeConstant.CoinKey, 0);
            BondSoulEvening.OldGas(AxeConstant.DamageKey, _initDamage);
            BondSoulEvening.OldGas(AxeConstant.MaxHp, _initHp);
            BondSoulEvening.OldGas(AxeConstant.DamageLevel, 1);
            BondSoulEvening.OldGas(AxeConstant.HpLevel, 1);
            BondSoulEvening.OldGas(AxeConstant.GameLevel, 1);
            BondSoulEvening.OldTape(AxeConstant.IsNewPlayer, false);
        }

        BGManager.Instance.PauseScrolling(true);
        gamePop.SetActive(false);
        homePop.SetActive(true);
    }


    public void ShowGamePop()
    {
        homePop.SetActive(false);
        A_PlayerManager.Instance.InitPlayerData();
        A_LevelManager.Instance.InitLevelData();
        gamePop.SetActive(true);
        gamePop.GetComponent<A_GamePop>().ReSetGame();
        // OpenPlayerCtrl();
        
    }

    public void ShowSetPop(bool isGame)
    {
        settingPop.SetActive(true);
        settingPop.GetComponent<A_SettingPop>().ShowUI(isGame);
    }

    public void ShowShopPop()
    {
        shopPop.SetActive(true);
    }


    public void ReplayGame()
    {
        A_PlayerManager.Instance.InitPlayerData();
        A_LevelManager.Instance.InitLevelData();
        OpenPlayerCtrl();
        gamePop.GetComponent<A_GamePop>().ReSetGame();
    }

    public void ToNextLevel()
    {
        A_LevelManager.Instance.InitLevelData();
        gamePop.SetActive(false);
        homePop.SetActive(true);
        homePop.GetComponent<A_HomePop>().ShowUI();
    }

    public void BackToHome()
    {
        // A_LevelManager.Instance.InitLevelData();
        homePop.SetActive(true);
        homePop.GetComponent<A_HomePop>().ShowUI();
    }


    public void BackGame()
    {
        if (gamePop.activeInHierarchy)
        {
            gamePop.GetComponent<A_GamePop>().OpenPlayer();
        }
        else
        {
            homePop.GetComponent<A_HomePop>().ShowUI();
        }
    }


    public void ShowFinishPop()
    {
        ClosePlayerCtrl();
        finishPop.SetActive(true);
    }

    public void ShowLosePop()
    {
        ClosePlayerCtrl();
        losePop.SetActive(true);
    }

    public void RefreshTopBar()
    {
        if (gamePop.activeInHierarchy)
        {
            
            gamePop.GetComponent<A_GamePop>().ShowTopBar();
        }
        else
        {
            homePop.GetComponent<A_HomePop>().ShowUI();   
        }

    }


    public void KillEmy(int coin)
    {
        A_PlayerManager.Instance.AddCurHp();
        A_PlayerManager.Instance.AddCoin(coin);
        RefreshTopBar();
        gamePop.GetComponent<A_GamePop>().ReShowPlayHp();
        if (A_LevelManager.Instance.KillEmyAndCheckFinish())
        {
            ShowFinishPop();
        }
        else
        {
            gamePop.GetComponent<A_GamePop>().InitEmy();
        }
    }


    public void ShowToastPop(string msg)
    {
        toastPop.SetActive(true);
        toastPop.GetComponent<ToastPop>().ShowToast(msg);
    }


    private void ClosePlayerCtrl()
    {
        gamePop.GetComponent<A_GamePop>().ClosePlayer();
    }

    private void OpenPlayerCtrl()
    {
        gamePop.GetComponent<A_GamePop>().OpenPlayer();
    }
}


public class AxeConstant
{
    public static readonly string AppName = "HitBall";

    public static readonly string IsNewPlayer = "IsNewPlayer";

    public static readonly string CoinKey = AppName + "coin";

    public static readonly string DamageKey = AppName + "damage";
    
    public static readonly string DamageLevel = AppName + "DamageLevel";
    
    public static readonly string MaxHp = AppName + "MaxHp";
    
    public static readonly string HpLevel = AppName + "HpLevel";
    
    public static readonly string GameLevel = AppName + "GameLevel";
    
    public static readonly string SoundKey = AppName + "sound";
    
    
}