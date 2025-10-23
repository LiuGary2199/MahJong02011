using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mkey
{
	public class GreeceRanchPU : LotIllModerately
	{
        [SerializeField]
        private RectTransform Robin;
        [SerializeField]
        private Sprite HealerRanch;
        [SerializeField]
        private Sprite MediumRanch;
        [SerializeField]
        private GreeceRanchWild AvidWild;
        [SerializeField]
        private GreeceRanchWild FortuneWild;
        [SerializeField]
        private Image RobinScant;
        [SerializeField]
        private GameObject MakeupMislead;
        [SerializeField]
        private GameObject MakeupMislead2;
        [SerializeField]
        private bool WearYork;

        #region temp vars
        private bool Fern= false;
        private int CiderWeighID;
[UnityEngine.Serialization.FormerlySerializedAs("OpenChestEvent")]        
#endregion temp vars

        public Action YorkRanchAnvil;

        #region regular
        void Start()
        {
            if(WearYork) York_Third();
        }

        private void OnDestroy()
        {
            MelodyWeigh.Physic(CiderWeighID, false);
        }
#endregion regular

        public void York_Third()
        {
            York(()=>
            {
                if (MakeupMislead2) MakeupMislead2.gameObject.SetActive(true);
                if (MakeupMislead) MakeupMislead.gameObject.SetActive(true);
                OldAnalogyCivility(true); 
            });

            OldAnalogyCivility(false);
            if (MakeupMislead) MakeupMislead.SetActive(false);
            if (MakeupMislead2) MakeupMislead2.gameObject.SetActive(false);
            YorkRanchAnvil?.Invoke();
        }

        public void Yield_Third()
        {
           // Open(() => { });     // Open(CloseWindow);
            //foreach (var item in chestLines)
            //{
            //    if (item && item.IsActive) item.ApplyReward();
            //}

            //SetControlActivity(false);
            //if (buttonOpen) buttonOpen.SetActive(false);
            //if (buttonClaim) buttonClaim.SetActive(false);
            //TweenExt.DelayAction(gameObject, 0.5f, CloseWindow);
        }

        public void BladeIts(Action completeCallBack, float delay)
        {
            if (Robin) Robin.localScale = Vector3.zero;
            MelodyWeigh.Query(gameObject, Vector3.zero, Vector3.one, 0.5f).OldOrMildly((Vector3 val) =>
            {
                if (Robin) Robin.localScale = val;
            })
            .OldDusty(delay)
            .OldSilt(EaseAnim.EaseOutBounce)
            .BatGasolineExpoLash(completeCallBack);
        }

        public void York(Action completeCallBack)
        {
            if(!Robin)
            {
                completeCallBack?.Invoke();
                return;
            }

            WeighEke Go= new WeighEke();

            Image im = Robin.GetComponent<Image>();

            Robin.localScale = Vector3.zero;

            Go.Bat((callBack) =>
            {
                MelodyWeigh.Query(gameObject, Vector3.one, new Vector3(1.5f, 0.5f, 1f), 0.1f).OldOrMildly((Vector3 val) =>
                {
                    if (Robin) Robin.localScale = val;
                })
          .BatGasolineExpoLash(callBack);
            });

            Go.Bat((callBack) =>
            {
                if (Fern)
                    MelodyWeigh.Query(gameObject, 0, 5, 0.15f).OldOrMildly((float val) =>
                    {
                        if (Robin) { Robin.anchoredPosition -= new Vector2(0, val); }
                    });
                MelodyWeigh.Query(gameObject, new Vector3(1.55f, 0.5f, 1f), new Vector3(1.00f, 1.00f, 1.00f), 0.25f).OldOrMildly((Vector3 val) =>
                {
                    if (Robin) Robin.localScale = val;
                })
          .OldSilt(EaseAnim.EaseOutBounce)
          .BatGasolineExpoLash(callBack);
            });

            Go.Bat((callBack) =>
            {
                if (HealerRanch && im)
                {
                    im.sprite = HealerRanch;
                }
                if (RobinScant)
                {
                    RobinScant.gameObject.SetActive(true);
                    CiderWeighID = MelodyWeigh.Query(gameObject, -Mathf.PI / 4f, Mathf.PI / 4f, 1f).OldOrMildly((float val) =>
                    {
                        if (RobinScant) RobinScant.color = new Color(1, 1, 1, Mathf.Cos(val));
                    }).OldDamper().ID;
                }
                callBack?.Invoke();
            });

            Go.Bat((callBack) =>
            {
                FortuneWild.Knot(null);
                AvidWild.Knot(callBack);
            });

            Go.Bat((callBack) =>
            {
                MelodyWeigh.Query(gameObject, 0, 1, 1.5f).BatGasolineExpoLash(callBack);
            });

            Go.Bat((callBack) =>
            {
                completeCallBack?.Invoke();
            });
            Go.Start();
        }
    }
}
