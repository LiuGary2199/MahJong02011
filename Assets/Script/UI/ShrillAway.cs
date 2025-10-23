using System;
using DG.Tweening;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;

public class ShrillAway : RealUITruth
{
    public static ShrillAway Instance;
[UnityEngine.Serialization.FormerlySerializedAs("rewardText")]
    public Text UplandPity;

   
    public override void Display(object SoEddyAdvent)
    {
        base.Display(SoEddyAdvent);
    }

    protected override void Awake()
    {
        base.Awake();
        Instance = this;
    }

    private void Start()
    {
    }

    public void WineSoul(double num)
    {
        UplandPity.text = num.ToString();
    }
    public override void Hidding()
    {
        base.Hidding();
    }
}