using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FendAnalogy : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("mask")]    public RectTransform Dose;
[UnityEngine.Serialization.FormerlySerializedAs("mypageview")]    public NormMeet Excavation;
    private void Awake()
    {
        Excavation.OrNormHalite = Immobility;
    }

    void Immobility(int index)
    {
        if (index >= this.transform.childCount) return;
        Vector3 pos= this.transform.GetChild(index).GetComponent<RectTransform>().position;
        Dose.GetComponent<RectTransform>().position = pos;
    }
}
