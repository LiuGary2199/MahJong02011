using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class SlitGreeceTopic : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("m_ItemIndex")]    public int m_HighMoody;
[UnityEngine.Serialization.FormerlySerializedAs("m_RewardText")]    public Text m_GreecePity;
[UnityEngine.Serialization.FormerlySerializedAs("m_AdCountText")]    public Text m_SoPulsePity;
[UnityEngine.Serialization.FormerlySerializedAs("m_AdWatchBtn")]
    public Button m_SoScentSty;
[UnityEngine.Serialization.FormerlySerializedAs("m_RewarededBtn")]    public GameObject m_GuncottonSty;
[UnityEngine.Serialization.FormerlySerializedAs("m_TimeBtn")]    public GameObject m_SlitSty;
[UnityEngine.Serialization.FormerlySerializedAs("m_GetBtn")]    public Button m_HowSty;
[UnityEngine.Serialization.FormerlySerializedAs("OnAdFinish")]    public Action<int> OrSoUnfold;
[UnityEngine.Serialization.FormerlySerializedAs("OnGetFinish")]    public Action<int> OrHowUnfold;

    private DayRewardData m_EyeGreeceSoul;
    public void Wine()
    {
        m_SoScentSty.onClick.RemoveAllListeners();
        m_HowSty.onClick.RemoveAllListeners();
        m_SoScentSty.onClick.AddListener(() =>
        {
            m_SoScentSty.enabled = false;
            ADEvening.Whatever.TillGreeceSugar((success) =>
            {
                if (success)
                {
                    OrSoUnfold?.Invoke(m_HighMoody);
                }
                else
                {
                    m_SoScentSty.enabled = true;

                }
            }, "7");
        });
        m_HowSty.onClick.AddListener(() =>
        {
            MainDwarf.Instance.BatFare(m_EyeGreeceSoul.reward_num);
            OrHowUnfold?.Invoke(m_HighMoody);
        });
    }
    public void WitHigh(DayRewardData dayRewardData,bool beforget)
    {
        m_EyeGreeceSoul = dayRewardData;
        
        m_SoScentSty.gameObject.SetActive(false);
        m_HowSty.gameObject.SetActive(false);
        m_GuncottonSty.SetActive(false);
        m_SlitSty.SetActive(false);
        long nowtime = GameUtil.GetNowTime();
        if (nowtime >= m_EyeGreeceSoul.look_time && beforget)//������ȡʱ��
        {
            if (m_EyeGreeceSoul.look_num >= m_EyeGreeceSoul.ad_num)
            {
                if (m_EyeGreeceSoul.getState == 0)
                {
                    m_HowSty.gameObject.SetActive(true);
                }
                else
                {
                    m_HowSty.gameObject.SetActive(false);
                    m_GuncottonSty.SetActive(true);
                }
            }
            else
            {
                m_SoScentSty.gameObject.SetActive(true);
            }
        }
        else
        {
            m_SlitSty.SetActive(true);
        }
        StringBuilder sb = new StringBuilder();
        string formatted = string.Format("({0}/{1})", m_EyeGreeceSoul.look_num, m_EyeGreeceSoul.ad_num);
        sb.Append(formatted);
        m_SoPulsePity.text = sb.ToString();
        m_GreecePity.text = m_EyeGreeceSoul.reward_num.ToString();
    }
}
