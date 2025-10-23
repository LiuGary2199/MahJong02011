using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PraySharp : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("InitGroup")]    public GameObject WineSharp;

    private GameObject ScavengePitchScreen;
    private float SeepWidth= 120f; // 两个item的position.x之差

    // Start is called before the first frame update
    void Start()
    {
        ScavengePitchScreen = WineSharp.transform.Find("SlotCard_1").gameObject;
        float x = SeepWidth * 3;
        int multiCount = CryBustPeg.instance.WineSoul.slot_group.Count;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < multiCount; j++)
            {
                GameObject fangkuai = Instantiate(ScavengePitchScreen, WineSharp.transform);
                fangkuai.transform.localPosition = new Vector3(x + SeepWidth * multiCount * i + SeepWidth * j, ScavengePitchScreen.transform.localPosition.y, 0);
                fangkuai.transform.Find("Text").GetComponent<Text>().text = "×" + CryBustPeg.instance.WineSoul.slot_group[j].multi;
            }
        }
    }

    public void CropPitch()
    {
        WineSharp.GetComponent<RectTransform>().localPosition = new Vector3(0, -10, 0);
    }

    public void East(int index, Action<int> finish)
    {
        StarkPeg.HowWhatever().DeadEncode(StarkLieu.UIMusic.Sound_OneArmBandit);
        CertaintyModerately.ReportedlyUnseen(WineSharp, -(SeepWidth * 2 + SeepWidth * CryBustPeg.instance.WineSoul.slot_group.Count * 3 + SeepWidth * (index + 1)), () =>
        {
            finish?.Invoke(CryBustPeg.instance.WineSoul.slot_group[index].multi);
        });
    }
}
