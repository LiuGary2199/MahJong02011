using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreeceHighUI : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("Icon")]    public Image Once;
[UnityEngine.Serialization.FormerlySerializedAs("NumText")]    public Text GetPity;

    public void Typify(Sprite icon, int num = 0)
    {
        Once.sprite = icon;
        if (num == 0) {
            GetPity.gameObject.SetActive(false);
        }
        else
        {
            GetPity.text = "+" + num.ToString();
            GetPity.gameObject.SetActive(true);
        }
    }
}
