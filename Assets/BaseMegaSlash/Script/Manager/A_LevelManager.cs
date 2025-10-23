// Project  Repository-BaseA
// FileName  A_LevelManager.cs
// Author  AX
// Desc
// CreateAt  2025-09-05 14:09:41 
//


using UnityEngine;

public class A_LevelManager : MonoBehaviour
{
    public static A_LevelManager Instance;


    public int curLeftEmy;


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


    private int GetEmyCount()
    {
        int level = GetGameLevel();
        switch (level)
        {
            case < 5:
                return 2;
            case < 11:
                return 3;
            default:
                return 4;
        }
    }


    public void InitLevelData()
    {
        curLeftEmy = GetEmyCount();
    }

    public float GetLeftPro()
    {
        return 1f - curLeftEmy * 1f / GetEmyCount();
    }


    public int GetGameLevel()
    {
        return BondSoulEvening.HowGas(AxeConstant.GameLevel);
    }

    public void AddGameLevel()
    {
        BondSoulEvening.OldGas(AxeConstant.GameLevel, GetGameLevel() + 1);
    }

    public bool KillEmyAndCheckFinish()
    {
        curLeftEmy--;
        return curLeftEmy <= 0;
    }
}