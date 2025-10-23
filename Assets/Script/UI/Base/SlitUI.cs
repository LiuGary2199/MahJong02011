using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SlitUI : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("ClockText")]    public Text ItalyPity;
[UnityEngine.Serialization.FormerlySerializedAs("Pointer")]    public RectTransform Visible;

    private long Realistic;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void WineVanSlit(long endTime)
    {
        Realistic = endTime - TautErie.Precede();

        StopCoroutine(nameof(TractorItaly));
        StartCoroutine(nameof(TractorItaly));
    }

    private IEnumerator TractorItaly()
    {
        float angle = 0;
        while(Realistic > 0)
        {
            ItalyPity.text = TautErie.HatchetAfraid(Realistic);
            Visible.DORotate(new Vector3(0, 0, angle), 0.5f);
            angle = angle - 90 == -360 ? 0 : angle - 90;
            Realistic--;
            yield return new WaitForSeconds(1);
        }
        if (Realistic <= 0)
        {
            ItalyPity.text = "Finished";
            Visible.rotation = Quaternion.identity;
        }
    }
}
