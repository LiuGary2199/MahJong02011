using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastGoDwarf : RealUITruth
{
[UnityEngine.Serialization.FormerlySerializedAs("Stars")]    public Button[] Heave;
[UnityEngine.Serialization.FormerlySerializedAs("star1Sprite")]    public Sprite Deny1Corpse;
[UnityEngine.Serialization.FormerlySerializedAs("star2Sprite")]    public Sprite Deny2Corpse;
[UnityEngine.Serialization.FormerlySerializedAs("CLoseBtn")]    public Button CBentSty;


    // Start is called before the first frame update
    void Start()
    {
        foreach (Button star in Heave)
        {
            star.onClick.AddListener(() =>
            {
                string indexStr = System.Text.RegularExpressions.Regex.Replace(star.gameObject.name, @"[^0-9]+", "");
                int Rough= indexStr == "" ? 0 : int.Parse(indexStr);
                QuinaVault(Rough);
                SpitAnvilPawnee.HowWhatever().HeroAnvil("1010", (Rough + 1).ToString());

            });
        }
        CBentSty.onClick.AddListener(() =>
        {
            DodgeUIEddy(GetType().Name);
        });
    }

    public override void Display(object SoEddyAdvent)
    {
        base.Display(SoEddyAdvent);
        for (int i = 0; i < 5; i++)
        {
            Heave[i].gameObject.GetComponent<Image>().sprite = Deny2Corpse;
        }
    }


    private void QuinaVault(int index)
    {
        for (int i = 0; i < 5; i++)
        {
            Heave[i].gameObject.GetComponent<Image>().sprite = i <= index ? Deny1Corpse : Deny2Corpse;
        }
        SpitAnvilPawnee.HowWhatever().HeroAnvil("1301", (index + 1).ToString());
        if (index < 3)
        {
            StartCoroutine(ClingDwarf());
        }
        else
        {
            // 跳转到应用商店
            LastGoEvening.instance.YorkAPPitOrient();
            StartCoroutine(ClingDwarf());
        }

        // 打点
        //SpitAnvilPawnee.GetInstance().SendEvent("1210", (index + 1).ToString());
    }

    IEnumerator ClingDwarf(float waitTime = 0.5f)
    {
        yield return new WaitForSeconds(waitTime);
        DodgeUIEddy(GetType().Name);
    }
}
