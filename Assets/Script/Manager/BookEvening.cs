using System.Collections;
using System.Collections.Generic;
using Mkey;
using UnityEngine;

public class BookEvening : MonoBehaviour
{
    public static BookEvening instance;

    private bool Plate= false;
[UnityEngine.Serialization.FormerlySerializedAs("GameView")]    public GameObject LullMeet;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Posthumously(){
        LullMeet.SetActive(true);
    }
    public void ClosePosthumously()
    {
        LullMeet.SetActive(true);
    }

    public void GritWine()
    {
        bool isNewPlayer = !PlayerPrefs.HasKey(CShaman.It_IDNssUntold + "Bool") || BondSoulEvening.HowTape(CShaman.It_IDNssUntold);
        EffortWineEvening.Instance.WineEffortSoul(isNewPlayer);
        //if (!WinterErie.IsApple())
        //    EffortWineEvening.Instance.AdjustInit();
        if (isNewPlayer)
        {
            // 新用户
            BondSoulEvening.OldTape(CShaman.It_IDNssUntold, false);
        }


        GameUtil.IsSameDayAsLastCheck();//每日奖励检测

        //StarkPeg.GetInstance().PlayBg(StarkLieu.SceneMusic.Sound_BGM);
        SpitAnvilPawnee.HowWhatever().HeroAnvil("1001");
        UIEvening.HowWhatever().KnotUITruth(nameof(MainDwarf));

        LullSoulEvening.HowWhatever().WineLullSoul();

        Plate = true;

        //ActivityAutoOpenManager.Instance.OpenPanel(1);
    }

}
