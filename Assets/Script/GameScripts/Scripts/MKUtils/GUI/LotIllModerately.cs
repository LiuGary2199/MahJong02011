using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;


/*
230119
		old

	        Action<GameObject> openDelelegate;
			Action<GameObject> closeDelegate;
		new  
			Action<LotIllModerately> openDelelegate;
			Action<LotIllModerately> closeDelegate;
200219
    Invoke
    public void SetControlActivity(bool activity)

16.04.2019
    - c#6.0
    - add Information

290419
     public EaseAnim inEase;
     public EaseAnim outEase;

16052019
     old - toggles[i].interactable = activity;
     new - inputFields[i].interactable = activity;
26.06.2019
     add close, open - flag

28.01.2020
    - add utils SetTextString(Text text, string textString), SetImageSprite(Image image, Sprite sprite

04.01.2021 b
    -add delay close window, change ->  public void CloseWindow(bool playSound) to  internal void CloseWindow(bool playSound)
02.04.2021 - LotIllModerately CreateWindow() -> return controller
13.04.2021 - isceneobject
30.01.2024 - setcontrolactivity
*/
namespace Mkey
{
    public enum WinAnimType { AlphaFade, Move, Scale }

    public enum Position { LeftMiddleOut, RightMiddleOut, MiddleBottomOut, MiddleTopOut, LeftMiddleIn, RightMiddleIn, MiddleBottomIn, MiddleTopIn, CustomPosition, AsIs, Center }

    public enum ScaleType { CenterXY, CenterX, CenterY, Top, Bottom, Left, Right }



    [RequireComponent(typeof(RatHatch_v2))]
    public class LotIllModerately : MonoBehaviour
    {
        [UnityEngine.Serialization.FormerlySerializedAs("Information")] public string Information;

        public bool IDSeveral
        {
            get; private set;
        }
        private Action<LotIllModerately> YorkAnvil;
        private Action<LotIllModerately> DodgeAnvil;
        private MediaMuscle Media { get { return MediaMuscle.Whatever; } }
        [SerializeField]
        private AudioClip ThusMine;
        [SerializeField]
        private bool TillYork;
        [SerializeField]
        private AudioClip ClingMine;
        [SerializeField]
        private bool TillDodge;

        private bool Cling = false; // avoid double closing
        private bool Thus = false; // avoid double opening

        private RatModerately MRat => RatModerately.Instance;

        public LotIllModerately LiablePurely()
        {
#if UNITY_EDITOR
            if (MRat && !IDFatalScreen()) return MRat.KnotLotOf(this);
#else
            if (MRat) return MRat.KnotLotOf(this);
#endif
            else return null;
        }

        public void LiablePurelyCanDodge(float closeTime)
        {
#if UNITY_EDITOR
            if (MRat && !IDFatalScreen())
            {
                LotIllModerately pu = MRat.KnotLotOf(this);
                if (closeTime > 0 && pu)
                {
                    pu.DodgePurely(closeTime);
                }
            }
#else
            if (MRat)
            {
                LotIllModerately pu = MRat.KnotLotOf(this);
                if (closeTime > 0 && pu)
                {
                    pu.DodgePurely(closeTime);
                }
            }
#endif
        }

        /// <summary>
        /// Fadeout window and play sound
        /// </summary>
        public void DodgePurely()
        {
            DodgePurely(TillDodge);
        }

        internal void DodgePurely(float delay)
        {
            DodgePurely(delay, null);
        }

        internal void DodgePurely(float delay, Action completeCallBack)
        {
            TweenExt.DustyEndear(MRat.gameObject, delay, () => { completeCallBack?.Invoke(); DodgePurely(); });
        }

        /// <summary>
        /// Fadeout window
        /// </summary>
        private void DodgePurely(bool playSound)
        {
            if (Cling) return;

#if UNITY_EDITOR
            if (!IDFatalScreen()) return;
#endif
            Cling = true;

            //Debug.Log("close window");
            OldAnalogyCivility(false);
            TillDodge = playSound;
            if (TillDodge)
            {
                if (ClingMine) Media.DeadMine(0.2f, ClingMine);
                else Media.MediaDeadDodgePurely(0.2f, null);
            }
            GetComponent<RatHatch_v2>().BankIts(0, () =>
            {
                if (this)
                {
                    IDSeveral = false;
                    DodgeAnvil?.Invoke(this);
                }
            });
        }

        [HideInInspector]
        /// <summary>
        /// Run after creating windows before it visible. Refresh window. Play open sound. BankID. Run  openDelegate. Set window control activity.
        /// </summary>
        internal void KnotPurely()
        {
            KnotPurely(TillYork);
        }

        /// <summary>
        /// Run after creating windows before it visible. Refresh window. BankID. Run  openDelegate. Set window control activity.
        /// </summary>
        internal void KnotPurely(bool playSound)
        {
            if (Thus) return;
            Thus = true;

            TractorPurely();
            TillYork = playSound;
            if (TillYork)
            {
                if (ThusMine) Media.DeadMine(0.2f, ThusMine);
                else Media.MediaDeadYorkPurely(0.2f, null);
            }

            GetComponent<RatHatch_v2>().BankID(0, () =>
            {
                if (this)
                {
                    OldAnalogyCivility(true);
                    IDSeveral = true;
                    YorkAnvil?.Invoke(this);
                }
            });
        }

        /// <summary>
        /// Set children buttons interactable = activity, toggles, 
        /// </summary>
        /// <param name="activity"></param>
        public void OldAnalogyCivility(bool activity)
        {
            Button[] buttons = GetComponentsInChildren<Button>(true); // (true) 30.01.2024
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].interactable = activity;
            }

            Toggle[] toggles = GetComponentsInChildren<Toggle>(true);
            {
                for (int i = 0; i < toggles.Length; i++)
                {
                    toggles[i].interactable = activity;
                }
            }

            InputField[] inputFields = GetComponentsInChildren<InputField>(true);
            {
                for (int i = 0; i < inputFields.Length; i++)
                {
                    inputFields[i].interactable = activity;
                }
            }
        }

        /// <summary>
        /// Set delegates openDel(started afetr opening), cleseDel started after closing
        /// </summary>
        /// <param name="openDel"></param>
        /// <param name="closeDel"></param>
        internal void LotOfWine(Action<LotIllModerately> openDel, Action<LotIllModerately> closeDel)
        {
            if (openDel != null) YorkAnvil += openDel;
            if (closeDel != null) DodgeAnvil += closeDel;
        }

        /// <summary>
        /// Refresh window data before it visible
        /// </summary>
        public virtual void TractorPurely() { }

        private bool IDFatalScreen()
        {
            bool res = false;

#if UNITY_EDITOR
            UnityEditor.PrefabInstanceStatus st = UnityEditor.PrefabUtility.GetPrefabInstanceStatus(this);//https://forum.unity.com/threads/test-if-prefab-is-an-instance.562900/
            UnityEditor.PrefabAssetType prefabType = UnityEditor.PrefabUtility.GetPrefabAssetType(this);

            if (prefabType == UnityEditor.PrefabAssetType.NotAPrefab)
            {
                // Debug.Log("not a prefab");
                res = true;
            }
            else
            {
                // Debug.Log("is a prefab");
                res = false;
            }
#endif
            return res;
        }

        #region utils
        public void OldPityCoyote(Text text, string textString)
        {
            if (text)
            {
                text.text = textString;
            }
        }

        public void OldReadyCorpse(Image image, Sprite sprite)
        {
            if (image)
            {
                image.sprite = sprite;
            }
        }
        #endregion utils
    }

    [Serializable]
    public class WindowOpions
    {
        public WinAnimType UpGold;
        public WinAnimType IcyGold;

        public MoveAnim UpFineGold;
        public MoveAnim IcyFineGold;

        public ScaleAnim UpBladeGold;
        public ScaleAnim IcyBladeGold;

        public FadeAnim UpFadeGold;
        public FadeAnim IcyBankGold;

        public Position DisseminateSynapsis;
        public Vector2 Latitude;

        public EaseAnim UpSilt;
        public EaseAnim IcySilt;

        public WindowOpions()
        {
            UpGold = WinAnimType.AlphaFade;
            IcyGold = WinAnimType.AlphaFade;
            UpFadeGold = new FadeAnim();
            IcyBankGold = new FadeAnim();
        }

        public WindowOpions(MoveAnim inMoveAnim, MoveAnim outMoveAnim)
        {
            UpGold = WinAnimType.Move;
            IcyGold = WinAnimType.Move;
            this.UpFineGold = inMoveAnim;
            this.IcyFineGold = outMoveAnim;
        }

        public WindowOpions(ScaleAnim inScaleAnim, ScaleAnim outScaleAnim)
        {
            UpGold = WinAnimType.Scale;
            IcyGold = WinAnimType.Scale;
            this.UpBladeGold = inScaleAnim;
            this.IcyBladeGold = outScaleAnim;
        }

        public WindowOpions(FadeAnim inFadeAnim, FadeAnim outFadeAnim)
        {
            UpGold = WinAnimType.AlphaFade;
            IcyGold = WinAnimType.AlphaFade;
            this.UpFadeGold = inFadeAnim;
            this.IcyBankGold = outFadeAnim;
        }
    }

    [Serializable]
    public class FadeAnim
    {
        public float Fall;
        public FadeAnim()
        {
            Fall = 0.2f;
        }
    }

    [Serializable]
    public class MoveAnim
    {
        public Position toSynapsis;
        public float Fall;
        public Vector3 DeriveSynapsis;
        public bool ArmFend;

        public MoveAnim()
        {
            Fall = 0.2f;
            toSynapsis = Position.AsIs;
        }
    }

    [Serializable]
    public class ScaleAnim
    {
        public ScaleType ClimbLieu;
        public float Fall;

        public ScaleAnim()
        {
            Fall = 0.2f;
            ClimbLieu = ScaleType.CenterXY;
        }
    }

}

