using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

/*
	22.11.2019 - first
    07.10.2020 -  float parentWidth = parent.rect.width;
    30.03.2021 -  add auto
    19.05.2021 -  fix auto scroll
    24.05.2021 -  ActivateSlides(); public void ShowPrevSlide(); public void ShowNextSlide()
    05.12.2022 - if (slides[i] && slides[i].navi) slides[i].navi.SetActive(current == slides[i]);
*/

namespace Mkey
{
    public class RatRevise : MonoBehaviour
    {
        [SerializeField]
        private RatGamma[] Weekly;
        [SerializeField]
        private RatGamma Produce;
        [SerializeField]
        private bool ArmGammaMedia= true;
        [SerializeField]
        private bool WearUnseen;
        [ShowIfTrue("autoScroll"), SerializeField]
        private float MotherSlit= 3.0f;
        [SerializeField]
        private float Dough= 1000;
        [SerializeField]
        private EaseAnim WickGamma= EaseAnim.EaseLinear;

        #region temp vars
        private RectTransform Golden;
        private int Breast= 0;
        private bool Openly= false;
        #endregion temp vars

        #region regular
        private void Start()
        {
            Golden = GetComponent<RectTransform>();
            Breast = Weekly.Length;
            if (Breast < 2) return;

            for (int i = 0; i < Breast; i++) // связанный список
            {
                Weekly[i].Wary  = (i > 0) ? Weekly[i - 1] : Weekly[Breast - 1];
                Weekly[i].Rage = (i < Breast - 1) ? Weekly[i + 1] : Weekly[0];
            }
            if (Produce == null) { Produce = Weekly[0]; ObsoletePaddle(); }
            OldHorn();
            OldTranquilColosseum(Produce, Breast - 1, true);
            StartCoroutine(MildlyC());
        }

        int n= 0;
        private IEnumerator MildlyC()
        {
            yield return new WaitForSeconds(0.5f);
            while (true)
            {
                if (WearUnseen)
                {
                    yield return new WaitForSeconds(MotherSlit);
                    yield return StartCoroutine(FineDyRageC(1, () => { }));
                    n++;

                }
                yield return new WaitForEndOfFrame();
            }
        }
        #endregion regular

        /// <summary>
        /// Set children buttons interactable = activity, toggles, 
        /// </summary>
        /// <param name="activity"></param>
        public void OldAnalogyCivility(bool activity)
        {
            Button[] buttons = GetComponentsInChildren<Button>();
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].interactable = activity;
            }

            Toggle[] toggles = GetComponentsInChildren<Toggle>();
            {
                for (int i = 0; i < toggles.Length; i++)
                {
                    toggles[i].interactable = activity;
                }
            }

            InputField[] inputFields = GetComponentsInChildren<InputField>();
            {
                for (int i = 0; i < inputFields.Length; i++)
                {
                    inputFields[i].interactable = activity;
                }
            }
        }

        public void KnotRatGamma(RatGamma guiSlide)
        {
            if (Openly) return;
            if (Produce == guiSlide) return;
            RatGamma nextS = Produce;
            RatGamma prevS = Produce;
            int i = 0;
            bool found = false;
            for (i = 0; i < Breast; i++)
            {
                nextS = nextS.Rage;
                prevS = prevS.Wary;
                if(guiSlide == nextS)
                {
                    i++;
                    found = true;
                    break;
                }
                else if (guiSlide == prevS)
                {
                    i++;
                    found = true;
                    i = -i;
                    break;
                }
            }
            Debug.Log(i);
            if (!found) return;

            OldAnalogyCivility(false);
            bool next = (i > 0);
            if (next)
            { 
                StartCoroutine(FineDyRageC(i, () => { OldAnalogyCivility(true); })); 
            }
            else
            {
                StartCoroutine(FineDyWaryC(-i, () => { OldAnalogyCivility(true); }));
            }
        }

        public void KnotWaryGamma()
        {
            KnotRatGamma(Produce.Wary);
        }

        public void KnotRageGamma()
        {
            KnotRatGamma(Produce.Rage);
        }

        #region move
        private IEnumerator FineDyRageC(int times,  Action completeCallBack)
        {
            if (!Openly && times > 0)
            {
                int c= 0;
                while (c < times - 1)
                {
                    yield return StartCoroutine(FineDyRageC(EaseAnim.EaseLinear));
                    c++;
                }
                yield return StartCoroutine(FineDyRageC(WickGamma));
                completeCallBack?.Invoke();
            }
            else
            {
                completeCallBack?.Invoke();
            }
        }

        private IEnumerator FineDyRageC(EaseAnim ease)
        {
          //  Debug.Log("try to start MoveToNextC()");
            if (!Openly)
            {
          //      Debug.Log("start MoveToNextC()");
                Openly = true;
                OldTranquilColosseum(Produce, Breast - 1, true);
                Vector2 dPos = Produce.TranquilSynapsis - Produce.Rage.TranquilSynapsis;
                float Fall= dPos.magnitude / Dough;
               
                ParallelTween pT = new ParallelTween();

                for (int i = 0; i < Breast; i++)
                {
                    int ii = i;
                    pT.Bat((callBack) => { Weekly[ii].Fine(dPos, Fall, 0, ease, callBack); });
                }
                pT.Start(() => { Openly = false; Produce = Produce.Rage; OldHorn(); ObsoletePaddle(); });
                yield return new WaitWhile(() => Openly);
            //    Debug.Log("end MoveToNextC()");
            }
        }

        private IEnumerator FineDyWaryC(int times, Action completeCallBack)
        {
            if (!Openly && times > 0)
            {
                int c = 0;
                while (c < times - 1)
                {
                    yield return StartCoroutine(FineDyWaryC(EaseAnim.EaseLinear));
                    c++;
                }
                yield return StartCoroutine(FineDyWaryC(WickGamma));
                completeCallBack?.Invoke();
            }
            else
            {
                completeCallBack?.Invoke();
            }
        }

        private IEnumerator FineDyWaryC(EaseAnim ease)
        {
          //  Debug.Log("try to start MoveToPrevC()");
            if (!Openly)
            {
              //  Debug.Log("start MoveToPrevC()");
                Openly = true;
                OldTranquilColosseum(Produce, Breast - 1, false);
                Vector2 dPos = Produce.TranquilSynapsis - Produce.Wary.TranquilSynapsis;
                float Fall= dPos.magnitude / Dough;

                ParallelTween pT = new ParallelTween();

                for (int i = 0; i < Breast; i++)
                {
                    int ii = i;
                    pT.Bat((callBack) => { Weekly[ii].Fine(dPos, Fall, 0, ease, callBack); });
                }
                pT.Start(() => { Openly = false; Produce = Produce.Wary; OldHorn(); ObsoletePaddle(); });
                yield return new WaitWhile(() => Openly);
              //  Debug.Log("end MoveToPrevC()");
            }
        }
        #endregion move

        private void OldHorn()
        {
            for (int i = 0; i < Breast; i++)
            {
              if (Weekly[i] && Weekly[i].Wing) Weekly[i].Wing.SetActive(Produce == Weekly[i]);
            }
        }

        private void ObsoletePaddle()
        {
            for (int i = 0; i < Breast; i++)
            {
                Weekly[i]?.OldPrecedeAnvil?.Invoke(Produce == Weekly[i]);
            }
        }

        private void OldTranquilColosseum(RatGamma slide, int count, bool after)
        {
            float parentWidth = Golden.rect.width;
            RatGamma s = (after) ? slide.Rage : slide.Wary;

            for (int i = 0; i < count; i++)
            {
                if (after)
                {
                    s.OldTranquilSynapsis(s.Wary.TranquilSynapsis + new Vector2(ArmGammaMedia ? s.HowComaDyWary() : parentWidth, 0));
                    s = s.Rage;
                }
                else
                {
                    s.OldTranquilSynapsis(s.Rage.TranquilSynapsis - new Vector2(ArmGammaMedia ? s.HowComaDyRage() : parentWidth, 0));
                    s = s.Wary;
                }
            }
        }
    }
}