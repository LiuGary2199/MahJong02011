using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class AdjunctDwarf : RealUITruth
{
[UnityEngine.Serialization.FormerlySerializedAs("Sound_Button")]    public Button Media_Seaman;
[UnityEngine.Serialization.FormerlySerializedAs("Music_Button")]    public Button Stark_Seaman;
[UnityEngine.Serialization.FormerlySerializedAs("SoundIcon")]    public Image MediaOnce;
[UnityEngine.Serialization.FormerlySerializedAs("MusicIcon")]    public Image StarkOnce;
[UnityEngine.Serialization.FormerlySerializedAs("Continue_Button")]    public Button Workable_Seaman;
[UnityEngine.Serialization.FormerlySerializedAs("CLose_Button")]    public Button CBent_Seaman;
[UnityEngine.Serialization.FormerlySerializedAs("Restart_Button")]
    public Button Sleeper_Seaman;
[UnityEngine.Serialization.FormerlySerializedAs("MusicCloseSprite")]    public Sprite StarkDodgeCorpse;
[UnityEngine.Serialization.FormerlySerializedAs("MusicOpenSprite")]    public Sprite StarkYorkCorpse;
[UnityEngine.Serialization.FormerlySerializedAs("SoundCloseSprite")]    public Sprite MediaDodgeCorpse;
[UnityEngine.Serialization.FormerlySerializedAs("SoundOpenSprite")]    public Sprite MediaYorkCorpse;

    public override void Display(object SoEddyAdvent)
    {
        base.Display(SoEddyAdvent);
        StarkOnce.sprite = StarkPeg.HowWhatever().UpStarkElicit ? StarkYorkCorpse : StarkDodgeCorpse;
        MediaOnce.sprite = StarkPeg.HowWhatever().EncodeStarkElicit ? MediaYorkCorpse : MediaDodgeCorpse;
    }
    // Start is called before the first frame update
    void Start()
    {
        CBent_Seaman.onClick.AddListener(() => {
            DodgeUIEddy(GetType().Name);
        });
        Workable_Seaman.onClick.AddListener(() => {
            DodgeUIEddy(GetType().Name);
        });
        Sleeper_Seaman.onClick.AddListener(() => {
            LullEvening.Instance.SleeperLull();
            DOVirtual.DelayedCall(0.5f, () =>  //停顿
            {
                DodgeUIEddy(GetType().Name);
            });
        });
        
        Stark_Seaman.onClick.AddListener(() =>
        {

            StarkPeg.HowWhatever().UpStarkElicit = !StarkPeg.HowWhatever().UpStarkElicit;
            StarkOnce.sprite = StarkPeg.HowWhatever().UpStarkElicit ? StarkYorkCorpse : StarkDodgeCorpse;
        });
        Media_Seaman.onClick.AddListener(() =>
        {

            StarkPeg.HowWhatever().EncodeStarkElicit = !StarkPeg.HowWhatever().EncodeStarkElicit;
            MediaOnce.sprite = StarkPeg.HowWhatever().EncodeStarkElicit ? MediaYorkCorpse : MediaDodgeCorpse;
        });
    }

}
