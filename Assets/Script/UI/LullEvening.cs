using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using Mkey;
public class LullEvening : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("gameBoard")]    public LullSyrup GritSyrup;
    static public LullEvening Instance;
    private Tween SlitMust;
    private float Starfish= 15;
[UnityEngine.Serialization.FormerlySerializedAs("m_isCommbo")]    public bool m_ItSeabed;
[UnityEngine.Serialization.FormerlySerializedAs("m_ComboCount")]    public int m_PartyPulse= 0;
[UnityEngine.Serialization.FormerlySerializedAs("eventSystem")]    public EventSystem LoessDefine;

    public void NucleusAnvil()
    {
        LoessDefine.enabled = false;
    }
    public void VaultAnvil()
    {
        LoessDefine.enabled = true;
    }

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        OutdoorLegend.BatTugSolution(CShaman.To_OrPartyUpdata, OnComboUpdate);
    }

    public void SleeperLull()
    {
        GritSyrup.SleeperDelta();
        m_PartyPulse = 0;
    }
    public void RageLull()
    {
        // 不再调用CompleteAndLoadNextLevel，因为逻辑已经融合到CreateGameBoard中
        m_PartyPulse = 0;
    }
    private void OnComboUpdate(KeyValuesUpdate kv)
    {
        m_PartyPulse += 1;
        SlitMust?.Kill();
        SlitMust = DOVirtual.DelayedCall(Starfish, () =>
        {
            m_PartyPulse = 0;
            m_ItSeabed = false;
        });
        if (m_PartyPulse>=3)
        {
            m_ItSeabed = true;
            HeroSoul sendData = new HeroSoul();
            sendData.PartyPulse = m_PartyPulse;
            sendData.Anyway3Our = (Vector3) kv.Stable;
            KeyValuesUpdate keyfly = new KeyValuesUpdate(CShaman.To_OrPartyKnot, sendData);
            OutdoorLegend.HeroOutdoor(CShaman.To_OrPartyKnot, keyfly);
        }
       /* int goldMul = CryBustPeg.instance.GameData.combogold;
        if (m_ComboCount > 0 && m_ComboCount % goldMul == 0 && m_ComboCount != goldMul)
        {
            gameBoard.ChangeGold();
        }

        if (m_ComboCount >= goldMul)
        {

        }*/
    }
}
