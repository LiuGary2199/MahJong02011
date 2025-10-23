using System;
using System.Collections;
using System.Collections.Generic;
using Animancer;
using Unity.VisualScripting;
using UnityEngine;

public class TrimGoldModerately : MonoBehaviour
{
    [SerializeField] private AnimancerComponent m_Passenger;
    [SerializeField] private AnimationClip m_Mental;
    [SerializeField] private AnimationClip m_Corpus;
    [SerializeField] private AnimationClip m_Wide;
    [SerializeField] private AnimationClip m_Spot;
    AnimancerState state = null;
    public void DeadMental(Action Finishaction)
    {
        AnimancerState state = m_Passenger.Play(m_Mental);
        state.Events.OnEnd = () =>
        {
            Finishaction?.Invoke();
        };
    }
    
    public void DeadCorpus(Action Finishaction)
    {
        AnimancerState state = m_Passenger.Play(m_Corpus);
        state.Events.OnEnd = () =>
        {
            Finishaction?.Invoke();
        };
    }

     public void DeadWide()
    {
         state = m_Passenger.Play(m_Wide);
    }
    public void TreeWide()
    {
        if (state == null) return;
        state.Stop();
    }

    public void DeadSpot(Action Finishaction)
    {
        AnimancerState state = m_Passenger.Play(m_Spot);
        state.Events.OnEnd = () =>
        {
            Finishaction?.Invoke();
        };
    }

    private void Update()
    {
       
    }
}
