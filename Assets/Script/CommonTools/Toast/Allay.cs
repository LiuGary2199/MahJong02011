using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Allay : RealUITruth
{
[UnityEngine.Serialization.FormerlySerializedAs("ToastText")]    public Text AllayPity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Display(object SoEddyAdvent)
    {
        base.Display(SoEddyAdvent);

        AllayPity.text = SoEddyAdvent.ToString();
        StartCoroutine(nameof(WearDodgeAllay));
    }

    private IEnumerator WearDodgeAllay()
    {
        yield return new WaitForSeconds(2);
        DodgeUIEddy(GetType().Name);
    }

}
