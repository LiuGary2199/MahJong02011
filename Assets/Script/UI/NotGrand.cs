using System.Collections;
using System.Collections.Generic;
using Mkey;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class NotGrand : RealUITruth
{
[UnityEngine.Serialization.FormerlySerializedAs("AD_Button")]    public Button AD_Seaman;
[UnityEngine.Serialization.FormerlySerializedAs("Restart_Button")]    public Button Sleeper_Seaman;
[UnityEngine.Serialization.FormerlySerializedAs("Use_Button")]    public Button Fee_Seaman;

    [Header("倒计时精灵")]
[UnityEngine.Serialization.FormerlySerializedAs("countdownSprites")]    public Image[] RealisticBroadly; // 5,4,3,2,1 倒计时精灵
[UnityEngine.Serialization.FormerlySerializedAs("countdownInterval")]    public float RealisticTreasury= 1f; // 倒计时间隔时间

    private Coroutine RealisticIntroduce;
[UnityEngine.Serialization.FormerlySerializedAs("AppleAD_Button")]
    public Button FlukeAD_Seaman;
[UnityEngine.Serialization.FormerlySerializedAs("AppleCoin_Button")]    public Button FlukeAiry_Seaman;



    public override void Display(object SoEddyAdvent)
    {
        base.Display(SoEddyAdvent);
        AD_Seaman.gameObject.SetActive(false);
        Fee_Seaman.gameObject.SetActive(false);





        int Stocking= SeminarMisery.Pulse; // 重洗次数
        /* 
        if (shuffles > 0)
         {
             Use_Button.gameObject.SetActive(true);
         }
         else
         {
             AD_Button.gameObject.SetActive(true);
         }
         */
        AD_Seaman.gameObject.SetActive(true);

        if (WinterErie.IDFluke())
        {
            AD_Seaman.gameObject.SetActive(false);
            FlukeAD_Seaman.gameObject.SetActive(true);
            FlukeAiry_Seaman.gameObject.SetActive(true);

        }
        else
        {
            AD_Seaman.gameObject.SetActive(true);
            FlukeAD_Seaman.gameObject.SetActive(false);
            FlukeAiry_Seaman.gameObject.SetActive(false);

        }

        // 开始倒计时
        VaultCountdown();
    }

    // 开始倒计时
    private void VaultCountdown()
    {
        if (RealisticIntroduce != null)
        {
            StopCoroutine(RealisticIntroduce);
        }
        RealisticIntroduce = StartCoroutine(AborigineIntroduce());
    }

    // 倒计时协程
    private IEnumerator AborigineIntroduce()
    {
        // 隐藏所有倒计时精灵
        foreach (var sprite in RealisticBroadly)
        {
            if (sprite != null)
                sprite.gameObject.SetActive(false);
        }

        // 从5开始倒计时
        for (int i = 5; i >= 1; i--)
        {
            // 显示对应的倒计时精灵
            if (RealisticBroadly != null && i - 1 < RealisticBroadly.Length && RealisticBroadly[i - 1] != null)
            {
                RealisticBroadly[i - 1].gameObject.SetActive(true);
                Debug.Log($"显示倒计时精灵: {i}");
            }

            // 等待倒计时间隔
            yield return new WaitForSeconds(RealisticTreasury);

            // 隐藏当前倒计时精灵
            if (RealisticBroadly != null && i - 1 < RealisticBroadly.Length && RealisticBroadly[i - 1] != null)
            {
                RealisticBroadly[i - 1].gameObject.SetActive(false);
            }
        }

        // 倒计时结束，自动选择Restart_Button
        Debug.Log("倒计时结束，自动选择Restart_Button");
        Sleeper_Seaman.onClick.Invoke();
    }

    // 停止倒计时
    private void LingAborigine()
    {
        if (RealisticIntroduce != null)
        {
            StopCoroutine(RealisticIntroduce);
            RealisticIntroduce = null;
        }

        // 隐藏所有倒计时精灵
        foreach (var sprite in RealisticBroadly)
        {
            if (sprite != null)
                sprite.gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        FlukeAD_Seaman.onClick.AddListener(() =>
     {
         LingAborigine(); // 停止倒计时
         ADEvening.Whatever.TillGreeceSugar((success) =>
         {
             if (success)
             {
                 LullSyrup.Whatever.SeminarSoda(null); // 执行重洗网格逻辑
                 DodgeUIEddy(GetType().Name);
             }
         }, "6");
         SpitAnvilPawnee.HowWhatever().HeroAnvil("1007", "1");

     });
        FlukeAiry_Seaman.onClick.AddListener(() =>
    {
        double munber = LullSoulEvening.HowWhatever().EndBreed();
        if (munber >= 200)
        {
            LingAborigine(); // 停止倒计时
            LullSoulEvening.HowWhatever().FewBreed(-200);
             MainDwarf.Instance.BatFare(0, null);
            LullSyrup.Whatever.SeminarSoda(null); // 执行重洗网格逻辑
            DodgeUIEddy(GetType().Name);
        }else{
            	UIEvening.HowWhatever().KnotUITruth(nameof(Allay), "Diamond shortage");
        }
    });

        AD_Seaman.onClick.AddListener(() =>
        {
            LingAborigine(); // 停止倒计时
            ADEvening.Whatever.TillGreeceSugar((success) =>
            {
                if (success)
                {
                    LullSyrup.Whatever.SeminarSoda(null); // 执行重洗网格逻辑
                    DodgeUIEddy(GetType().Name);
                }
            }, "6");
            SpitAnvilPawnee.HowWhatever().HeroAnvil("1007", "1");

        });
        Fee_Seaman.onClick.AddListener(() =>
        {
            LingAborigine(); // 停止倒计时
            // 使用重洗道具的逻辑
            LullSyrup.Whatever.SeminarSoda(null); // 执行重洗网格逻辑
            SeminarMisery.Bat(-1); // 减少一个重洗道具
            LullGuinea.PreenSeminarEndear?.Invoke();
            DodgeUIEddy(GetType().Name);

        });

        Sleeper_Seaman.onClick.AddListener(() =>
        {
            LingAborigine(); // 停止倒计时
            LullEvening.Instance.SleeperLull();
            DOVirtual.DelayedCall(0.5f, () =>  //停顿
            {
                DodgeUIEddy(GetType().Name);
            });
            SpitAnvilPawnee.HowWhatever().HeroAnvil("1007", "0");
        });

    }

    // 当UI关闭时停止倒计时
    public override void Hidding(System.Action finish = null)
    {
        LingAborigine();
        base.Hidding(finish);
    }
}
