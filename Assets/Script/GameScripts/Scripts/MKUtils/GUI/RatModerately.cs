using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using System.Collections;
using System.Collections.Generic;
/*
100219
	fixed  private void PopUpCloseH(LotIllModerately pUP)
	old  Destroy(pUP);
	new  Destroy(pUP.gameObject);
	
	fixed  internal bool HasNoPopUp
			old   get { return PopupsList.Count > 0; }
			new   get { return PopupsList.Count == 0; }
 200219
    base RatModerately
 25.06.2019
   -add styled message show
     public void ShowMessageWithYesNoCloseButton(AirflowEdgeModerately prefab, string caption, string message, Action yesCallBack, Action cancelCallBack, Action noCallBack)
        {
            AirflowEdgeModerately wMC = CreateMessage(prefab, caption, message, yesCallBack, cancelCallBack, noCallBack);
        }
  30.07.2019 - fixed     SetControlActivity (activity)
    inputFields[i].interactable = activity;

    add   public bool IsActive { get; private set; }
  08.04.2020
    -update messages
  
  03.12.2020 
    -IEnumerator CloseMessageC
  03.02.2021 - show by Information
  21.11.2021 - add window to list directly after creation

*/
namespace Mkey
{
    [RequireComponent(typeof(Canvas))]
    public class RatModerately : MonoBehaviour
    {
        [SerializeField]
        private List<LotIllModerately> SkyOfSmuggle;

        [SerializeField]
        private LotIllModerately OutdoorPurelyDismal;

        protected List<LotIllModerately> EntityPeak;

        #region properties
        public bool StyDyLotOf        {
            get { return (EntityPeak==null) ? true : (EntityPeak.Count == 0); }
        }

        public bool IDInjure{ get; private set; }
        #endregion properties

        public static RatModerately Instance;

        #region regular
        void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            EntityPeak = new List<LotIllModerately>();
            //Application.targetFrameRate = 35;
        }

        protected virtual void Start()
        {

        }
        #endregion regular

        #region protected
        protected LotIllModerately KnotLotOf(LotIllModerately popup_prefab,  Transform parent, Action openCallBack, Action closeCallBack)
        {
            if (!popup_prefab) return null;
            LotIllModerately pUp = LiablePurely(popup_prefab, parent);
            if (pUp)
            {
                pUp.LotOfWine(
                    (g) =>
                    {
                        LotOfYorkAnvilPropose(g); openCallBack?.Invoke();
                    }, (g) =>
                    {
                        LotOfDodgeAnvilPropose(g);
                        closeCallBack?.Invoke();
                    });
                pUp.KnotPurely();
            }
            return pUp;
        }

        protected LotIllModerately KnotLotOf(LotIllModerately popup_prefab, Transform parent, Vector3 position, Action openCallBack, Action closeCallBack)
        {
            if (!popup_prefab) return null;
            LotIllModerately pUp = LiablePurely(popup_prefab, parent, position);
            if (pUp)
            {
                pUp.LotOfWine(
                    (g) =>
                    {
                        LotOfYorkAnvilPropose(g);
                        openCallBack?.Invoke();
                    }, (g) =>
                    {
                        LotOfDodgeAnvilPropose(g);
                        closeCallBack?.Invoke();
                    });
                pUp.KnotPurely();
            }
            return pUp;
        }
        #endregion protected
        
        #region private
        private LotIllModerately LiablePurely(LotIllModerately prefab, Transform parent)
        {
            GameObject gP = (GameObject)Instantiate(prefab.gameObject, parent);
            RectTransform mainRT = gP.GetComponent<RectTransform>();
            mainRT.SetParent(parent);
            WindowOpions SexPrinter= gP.GetComponent<RatHatch_v2>().SexPrinter;
            Vector3[] vC = new Vector3[4];
            mainRT.GetWorldCorners(vC);

            RectTransform rt = gP.GetComponent<RatHatch_v2>().IceDwarf;
            Vector3[] vC1 = new Vector3[4];
            rt.GetWorldCorners(vC1);
            float height = (vC1[2] - vC1[0]).y;
            float Ether= (vC1[2] - vC1[0]).x;

            switch (SexPrinter.DisseminateSynapsis)
            {
                case Position.LeftMiddleOut:
                    rt.position = new Vector3(vC[0].x - Ether / 2f, (vC[0].y + vC[2].y) / 2f, rt.position.z);
                    break;
                case Position.RightMiddleOut:
                    rt.position = new Vector3(vC[2].x + Ether / 2f, (vC[0].y + vC[2].y) / 2f, rt.position.z);
                    break;
                case Position.MiddleBottomOut:
                    rt.position = new Vector3((vC[0].x + vC[2].x) / 2f, vC[0].y - height / 2f, rt.position.z);
                    break;
                case Position.MiddleTopOut:
                    rt.position = new Vector3((vC[0].x + vC[2].x) / 2f, vC[2].y + height / 2f, rt.position.z);
                    break;
                case Position.LeftMiddleIn:
                    rt.position = new Vector3(vC[0].x + Ether / 2f, (vC[0].y + vC[2].y) / 2f, rt.position.z);
                    break;
                case Position.RightMiddleIn:
                    rt.position = new Vector3(vC[2].x - Ether / 2f, (vC[0].y + vC[2].y) / 2f, rt.position.z);
                    break;
                case Position.MiddleBottomIn:
                    rt.position = new Vector3((vC[0].x + vC[2].x) / 2f, vC[0].y + height / 2f, rt.position.z);
                    break;
                case Position.MiddleTopIn:
                    rt.position = new Vector3((vC[0].x + vC[2].x) / 2f, vC[2].y - height / 2f, rt.position.z);
                    break;
                case Position.CustomPosition:
                    rt.position = SexPrinter.Latitude;
                    break;
                case Position.AsIs:
                    break;
                case Position.Center:
                    rt.position = new Vector3((vC[0].x + vC[2].x) / 2f, (vC[0].y + vC[2].y) / 2f, rt.position.z);
                    break;
            }
            LotIllModerately pUp = gP.GetComponent<LotIllModerately>();
            if (pUp)
            {
                pUp.OldAnalogyCivility(false);
                if (EntityPeak == null) EntityPeak = new List<LotIllModerately>();
                EntityPeak.Add(pUp);
            }
            return pUp;
        }

        private LotIllModerately LiablePurely(LotIllModerately prefab, Transform parent, Vector3 position)
        {
            GameObject gP = (GameObject)Instantiate(prefab.gameObject, parent);
            RectTransform mainRT = gP.GetComponent<RectTransform>();
            mainRT.SetParent(parent);
            WindowOpions SexPrinter= gP.GetComponent<RatHatch_v2>().SexPrinter;

            Vector3[] vC = new Vector3[4];
            mainRT.GetWorldCorners(vC);

            RectTransform rt = gP.GetComponent<RatHatch_v2>().IceDwarf;
            Vector3[] vC1 = new Vector3[4];
            rt.GetWorldCorners(vC1);
            float height = (vC1[2]-vC1[0]).y;
            float Ether= (vC1[2] - vC1[0]).x;
            if (SexPrinter == null) SexPrinter = new WindowOpions();
            SexPrinter.Latitude =  position;

            switch (SexPrinter.DisseminateSynapsis)
            {
                case Position.LeftMiddleOut:
                    rt.position = new Vector3(vC[0].x - Ether / 2f, (vC[0].y + vC[2].y) / 2f, rt.position.z);
                    break;
                case Position.RightMiddleOut:
                    rt.position = new Vector3(vC[2].x + Ether / 2f, (vC[0].y + vC[2].y) / 2f, rt.position.z);
                    break;
                case Position.MiddleBottomOut:
                    rt.position = new Vector3((vC[0].x + vC[2].x) / 2f, vC[0].y - height / 2f, rt.position.z);
                    break;
                case Position.MiddleTopOut:
                    rt.position = new Vector3((vC[0].x + vC[2].x)/2f,  vC[2].y + height / 2f, rt.position.z);
                    break;
                case Position.LeftMiddleIn:
                    rt.position = new Vector3(vC[0].x + Ether / 2f, (vC[0].y + vC[2].y) / 2f, rt.position.z);
                    break;
                case Position.RightMiddleIn:
                    rt.position = new Vector3(vC[2].x - Ether / 2f, (vC[0].y + vC[2].y)/ 2f, rt.position.z);
                    break;
                case Position.MiddleBottomIn:
                    rt.position = new Vector3((vC[0].x + vC[2].x) / 2f, vC[0].y + height / 2f, rt.position.z);
                    break;
                case Position.MiddleTopIn:
                    rt.position = new Vector3((vC[0].x + vC[2].x) / 2f, vC[2].y - height / 2f, rt.position.z);
                    break;
                case Position.CustomPosition:
                    rt.position = SexPrinter.Latitude;
                    break;
                case Position.AsIs:
                    break;
                case Position.Center:
                    rt.position = new Vector3((vC[0].x + vC[2].x) / 2f, (vC[0].y + vC[2].y) / 2f, rt.position.z);
                    break;
            }
            LotIllModerately pUp = gP.GetComponent<LotIllModerately>();
            if (pUp)
            {
                pUp.OldAnalogyCivility(false);
                if(EntityPeak == null) EntityPeak = new List<LotIllModerately>();
                EntityPeak.Add(pUp);
            }
            return pUp;
        }
        #endregion private

        #region public
        public LotIllModerately KnotLotOf(LotIllModerately popup_prefab)
        {
            LotIllModerately pUp = KnotLotOf(popup_prefab, null, null);
            return pUp;
        }

        public LotIllModerately KnotLotOfUpDescription(string Information)
        {
            LotIllModerately popup_prefab = HowLotOfDismalUpOutstanding(Information);
            LotIllModerately pUp = KnotLotOf(popup_prefab, null, null);
            return pUp;
        }

        public IList<LotIllModerately> HowJoyLotIll()
        {
            return EntityPeak.AsReadOnly();
        }

        public LotIllModerately KnotLotOf(LotIllModerately prefab, Action closeCallBack)
        {
            return KnotLotOf(prefab, null, closeCallBack);
        }

        public LotIllModerately KnotLotOf(LotIllModerately popup_prefab, Action openCallBack, Action closeCallBack)
        {
            return KnotLotOf(popup_prefab, transform, openCallBack, closeCallBack);
        }

        /// <summary>
        /// Set children buttons interactable = activity, toggles, 
        /// </summary>
        /// <param name="activity"></param>
        public void OldAnalogyCivility(bool activity)
        {
            IDInjure = activity;
            Button[] buttons = GetComponentsInChildren<Button>();
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].interactable = activity;
            }

            Toggle [] toggles = GetComponentsInChildren<Toggle>();
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

        public LotIllModerately HowLotOfDismalUpOutstanding(string Information)
        {
            LotIllModerately pUP = null;
            if (string.IsNullOrEmpty(Information)) return pUP;

            foreach (var item in SkyOfSmuggle)
            {
                if (item)
                {
                    if (string.CompareOrdinal(Information, item.Information) == 0)
                    {
                        return item;
                    }
                }
            }

            Debug.Log("Prefab not found : " + Information);

            return pUP;
        }

        public LotIllModerately HowLotOfPurelyUpOutstanding(string Information)
        {
            LotIllModerately pUP = null;
            if (string.IsNullOrEmpty(Information)) return pUP;

            foreach (var item in EntityPeak)
            {
                if (item)
                {
                    if (string.CompareOrdinal(Information, item.Information) == 0)
                    {
                        return item;
                    }
                }
            }

            Debug.Log("Window not found : " + Information);

            return pUP;
        }
        #endregion public 

        #region messages - simple popup with yes, no, close buttons, caption and message text field 
        public AirflowEdgeModerately KnotOutdoorWestDodgeSeaman(string caption, string message, Action cancelCallBack)
        {
            return KnotOutdoorWestWitDyDodgeSeaman(caption, message, null, cancelCallBack, null);
        }

        public AirflowEdgeModerately KnotOutdoorWestYesDodgeSeaman(string caption, string message, Action yesCallBack, Action cancelCallBack)
        {
            return KnotOutdoorWestWitDyDodgeSeaman(caption, message, yesCallBack, cancelCallBack, null);
        }

        public AirflowEdgeModerately KnotOutdoorWestWitDySeaman(string caption, string message, Action yesCallBack, Action noCallBack)
        {
            return KnotOutdoorWestWitDyDodgeSeaman(caption, message, yesCallBack, null, noCallBack);
        }

        public AirflowEdgeModerately KnotOutdoorWestWitDyDodgeSeaman(string caption, string message, Action yesCallBack, Action cancelCallBack, Action noCallBack)
        {
            return LiableOutdoor(OutdoorPurelyDismal, caption, message, yesCallBack, cancelCallBack, noCallBack);
        }

        public AirflowEdgeModerately KnotOutdoorWestWitDyDodgeSeaman(AirflowEdgeModerately prefab, string caption, string message, Action yesCallBack, Action cancelCallBack, Action noCallBack)
        {
            return LiableOutdoor(prefab, caption, message, yesCallBack, cancelCallBack, noCallBack);
        }

        /// <summary>
        /// Show message without buttons, auto closing 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="message"></param>
        /// <param name="showTime"></param>
        /// <param name="completeCallBack"></param>
        public AirflowEdgeModerately KnotOutdoor(string caption, string message, float showTime, Action completeCallBack)
        {
            AirflowEdgeModerately pUp = LiableOutdoor(OutdoorPurelyDismal, caption, message, null, null, null);
            if (pUp) pUp.DodgePurely(showTime, completeCallBack);
            return pUp;
        }

        /// <summary>
        /// Show message without buttons, auto closing 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="message"></param>
        /// <param name="showTime"></param>
        /// <param name="completeCallBack"></param>
        public AirflowEdgeModerately KnotOutdoor(AirflowEdgeModerately prefab, string caption, string message, float showTime, Action completeCallBack)
        {
            AirflowEdgeModerately pUp = LiableOutdoor(prefab, caption, message, null, null, null);
            if (pUp) pUp.DodgePurely(showTime, completeCallBack);
            return pUp;
        }

        private AirflowEdgeModerately LiableOutdoor(LotIllModerately prefab, string caption, string message, Action yesCallBack, Action cancelCallBack, Action noCallBack)
        {
            LotIllModerately p = LiablePurely(prefab, transform);
            AirflowEdgeModerately pUp = p.GetComponent<AirflowEdgeModerately>();

            pUp.OldAnalogyCivility(false);
            pUp.LotOfWine(new Action<LotIllModerately>(LotOfYorkAnvilPropose), (g) =>
            {
                LotOfDodgeAnvilPropose(g);
                switch (pUp.Syntax)
                {
                    case MessageAnswer.Yes:
                        yesCallBack?.Invoke();
                        break;
                    case MessageAnswer.Physic:
                        cancelCallBack?.Invoke();
                        break;
                    case MessageAnswer.No:
                        noCallBack?.Invoke();
                        break;
                }
            });
            pUp.OldOutdoor(caption, message, yesCallBack != null, cancelCallBack != null, noCallBack != null);
            p.KnotPurely();
            return pUp;
        }
        #endregion messages

        #region handlers
        /// <summary>
        /// Add to popuplist
        /// </summary>
        /// <param name="pUP"></param>
        private void LotOfYorkAnvilPropose(LotIllModerately pUP)
        {
            if (EntityPeak.IndexOf(pUP) == -1)
            {
              //  PopupsList.Add(pUP);
            }
        }

        /// <summary>
        /// Remove from list and destroy
        /// </summary>
        /// <param name="pUP"></param>
        private void LotOfDodgeAnvilPropose(LotIllModerately pUP)
        {
            if (EntityPeak.IndexOf(pUP) != -1)
            {
                EntityPeak.Remove(pUP);
                Destroy(pUP.gameObject);
            }
        }
        #endregion handlers
    }
}

 
