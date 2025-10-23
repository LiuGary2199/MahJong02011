using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Mkey;
using Spine;
using Spine.Unity;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClarifyDwarf : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("sliderImage")]    public Image LondonReady;
[UnityEngine.Serialization.FormerlySerializedAs("progressText")]    public Text ConsumerPity;
    AsyncOperation asyncLoad;

    // Start is called before the first frame update
    void Start()
    {
        LondonReady.fillAmount = 0;
        ConsumerPity.text = "0%";
        CashOutManager.HowWhatever().StartTime = System.DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    }

    // Update is called once per frame
    void Update()
    {
        if (LondonReady.fillAmount <= 0.8f || (CryBustPeg.instance.Plate && CashOutManager.HowWhatever().Ready))
        {
            LondonReady.fillAmount += Time.deltaTime / 3f;
            ConsumerPity.text = (int)(LondonReady.fillAmount * 100) + "%";
            if (CryBustPeg.instance.Plate && WinterErie.IDFluke() && asyncLoad == null)
            {
                asyncLoad = SceneManager.LoadSceneAsync(1);
                asyncLoad.allowSceneActivation = false;
            }
            if (LondonReady.fillAmount >= 1)
            {
                WinterErie.IDFluke();
                if ( !WinterErie.IDFluke() && LullSyrup.ClarifyUnfold)
                {
                    Destroy(transform.parent.gameObject);
                    BookEvening.instance.GritWine();
                    CashOutManager.HowWhatever().ReportEvent_LoadingTime();
                    return;
                }
                if (WinterErie.IDFluke())
                {
                    Destroy(transform.parent.gameObject);
                    asyncLoad.allowSceneActivation = true;
                }
              
            }
        }
    }
}
