using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

#if UNITY_EDITOR
    using UnityEditor;
    using UnityEditorInternal;
#endif
/*
  changes
 27.03.18
    1) WinAnimptions
    21.12.18
            private void OnDestroy()
        {
            MelodyWeigh.Physic(gameObject, false);
        }
    7.04.19
    1) c#6.0
    2) add ease

    16.04.19 (comment moveout)
             //   IceDwarf.pivot = new Vector2(0.5f, 0.5f);
    22.04.19 (disable guimask)
        -   if (guiMask) guiMask.gameObject.SetActive(false);

    11.01.20 - avoid null error
        - if (fObjectR == null)  fObjectR = new FaderObjectsRec(IceDwarf.gameObject);

    11.11.2020 +GuiFaderEditor
 */
namespace Mkey
{
    public class RatHatch_v2 : MonoBehaviour
    {
[UnityEngine.Serialization.FormerlySerializedAs("SexPrinter")]        public WindowOpions SexPrinter;
[UnityEngine.Serialization.FormerlySerializedAs("backGround")]
        public RectTransform WashAbsorb;
[UnityEngine.Serialization.FormerlySerializedAs("IceDwarf")]    
        public RectTransform IceDwarf;
[UnityEngine.Serialization.FormerlySerializedAs("guiMask")]        public RectTransform IceFend;
[UnityEngine.Serialization.FormerlySerializedAs("completeCallback_in")]
        public UnityEvent AllegoryImitator_in;
[UnityEngine.Serialization.FormerlySerializedAs("completeCallback_out")]        public UnityEvent AllegoryImitator_Icy;

        private bool Imaginative= false;
        private FaderObjectsRec fScreenR;

        private void OnDestroy()
        {
            MelodyWeigh.Physic(gameObject, false);
        }

        public void BankID(float tweenDelay, Action completeCallBack)
        {
            if((!WashAbsorb) && (!IceDwarf))
            {
                completeCallBack?.Invoke();
                return;
            }
            if (!Imaginative)
            {
                Immobilize();
            }
            if (SexPrinter == null)
            {
                SexPrinter = new WindowOpions();
            }
            if (IceFend) IceFend.gameObject.SetActive(true);
            if(IceDwarf) IceDwarf.gameObject.SetActive(true);
            if (WashAbsorb) WashAbsorb.gameObject.SetActive(true);
            switch (SexPrinter.UpGold)
            {
                case WinAnimType.AlphaFade:
                    BrushBankID(tweenDelay,SexPrinter.UpFadeGold.Fall, SexPrinter.UpSilt, completeCallBack);
                    break;
                case WinAnimType.Move:
                    FineID(tweenDelay,SexPrinter.UpFineGold.Fall, SexPrinter.UpSilt, completeCallBack);
                    break;
                case WinAnimType.Scale:
                    BladeID(tweenDelay, SexPrinter.UpBladeGold.Fall, SexPrinter.UpSilt, completeCallBack);
                    break;
            }
        }

        public void BankIts(float tweenDelay, Action completeCallBack)
        {
            if ((!WashAbsorb) && (!IceDwarf))
            {
                completeCallBack?.Invoke();
                return;
            }

            if (!Imaginative)
            {
                Immobilize();
            }

            if (SexPrinter == null)
            {
                SexPrinter = new WindowOpions();
            }

            switch (SexPrinter.IcyGold)
            {
                case WinAnimType.AlphaFade:
                    BrushBankIts(tweenDelay, SexPrinter.IcyBankGold.Fall, SexPrinter.IcySilt, completeCallBack);
                    break;
                case WinAnimType.Move:
                    FineIts(tweenDelay, SexPrinter.IcyFineGold.Fall, SexPrinter.IcySilt, completeCallBack);
                    break;
                case WinAnimType.Scale:
                    BladeIts(tweenDelay, SexPrinter.IcyBladeGold.Fall, SexPrinter.IcySilt, completeCallBack);
                    break;
            }
        }

        private void BrushBankID(float tweenDelay, float tweenTime, EaseAnim ease, Action completeCallBack)
        {
            fScreenR.OldBrush(0f);
            MelodyWeigh.Query(gameObject, 0f, 1.0f, tweenTime).OldSilt(EaseAnim.EaseInCirc).OldOrMildly((float val) => { fScreenR.OldBrushK(val); }).
                OldDusty(tweenDelay).OldSilt(ease).
                BatGasolineExpoLash(() =>
                {
                     completeCallBack?.Invoke();
                    AllegoryImitator_in?.Invoke();
                });
        }

        private void BrushBankIts(float tweenDelay, float tweenTime, EaseAnim ease, Action completeCallBack)
        {
            fScreenR.OldInjure(true);
            MelodyWeigh.Query(gameObject, 1.0f, 0.0f, tweenTime).OldSilt(EaseAnim.EaseInCirc).OldOrMildly((float val) => { fScreenR.OldBrushK(val); }).
                OldDusty(tweenDelay).OldSilt(ease).
                BatGasolineExpoLash(() =>
                {
                    fScreenR.OldInjure(false);
                    if (IceFend) IceFend.gameObject.SetActive(false);
                    completeCallBack?.Invoke();
                    AllegoryImitator_Icy?.Invoke();
                });
        }

        Vector3 InferSynapsis= Vector3.zero;
        private void FineID(float tweenDelay, float tweenTime, EaseAnim ease, Action completeCallBack)
        {
            if (!IceDwarf)
            {
                completeCallBack?.Invoke();
                AllegoryImitator_in?.Invoke();
                return;
            }
            RectTransform mainRT = GetComponent<RectTransform>();
            Vector3[] wC = new Vector3[4];
            mainRT.GetWorldCorners(wC);

            Vector3[] wC1 = new Vector3[4];
            IceDwarf.GetWorldCorners(wC1);
            float height = (wC1[2] - wC1[0]).y;
            float Ether= (wC1[2] - wC1[0]).x;

           
            Vector3 pos = IceDwarf.position;
            Vector3 posTo = pos;
            float fTime = SexPrinter.UpFineGold.Fall;
            InferSynapsis = pos;

            switch (SexPrinter.UpFineGold.toSynapsis)
            {
                case Position.LeftMiddleOut:
                    posTo = new Vector3(wC[0].x - Ether / 2f, (wC[0].y + wC[2].y) / 2f, pos.z);
                    break;
                case Position.RightMiddleOut:
                    posTo = new Vector3(wC[2].x + Ether / 2f, (wC[0].y + wC[2].y) / 2f, pos.z);
                    break;
                case Position.MiddleBottomOut:
                    posTo = new Vector3((wC[0].x + wC[2].x) / 2f, wC[0].y - height / 2f, pos.z);
                    break;
                case Position.MiddleTopOut:
                    posTo = new Vector3((wC[0].x + wC[2].x) / 2f, wC[2].y + height / 2f, pos.z);
                    break;
                case Position.LeftMiddleIn:
                    posTo = new Vector3(wC[0].x + Ether / 2f, (wC[0].y + wC[2].y) / 2f, pos.z);
                    break;
                case Position.RightMiddleIn:
                    posTo = new Vector3(wC[2].x - Ether / 2f, (wC[0].y + wC[2].y) / 2f, pos.z);
                    break;
                case Position.MiddleBottomIn:
                    posTo = new Vector3((wC[0].x + wC[2].x) / 2f, wC[0].y + height / 2f, pos.z);
                    break;
                case Position.MiddleTopIn:
                    posTo = new Vector3((wC[0].x + wC[2].x) / 2f, wC[2].y - height / 2f, pos.z);
                    break;
                case Position.CustomPosition:
                    posTo = SexPrinter.UpFineGold.DeriveSynapsis;
                    if (SexPrinter.UpFineGold.ArmFend) posTo = IceFend.position;
                    break;
                case Position.AsIs:
                    break;
                case Position.Center:
                    posTo = new Vector3((wC[0].x + wC[2].x) / 2f, (wC[0].y + wC[2].y) / 2f, pos.z);
                    break;

            }
            MelodyWeigh.Query(gameObject, pos, posTo, fTime).OldOrMildly((val) =>
            {
                if (IceDwarf)
                {
                    IceDwarf.position = val;
                   // Debug.Log("movein IceDwarf.position :" + IceDwarf.position);
                }
            }).OldDusty(tweenDelay).OldSilt(ease).
            BatGasolineExpoLash(() =>
            {
              //  Debug.Log("movein full --------------------------------");
                completeCallBack?.Invoke();
                AllegoryImitator_in?.Invoke();
            });
        }

        private void FineIts(float tweenDelay, float tweenTime, EaseAnim ease, Action completeCallBack)
        {
            if (!IceDwarf)
            {
                completeCallBack?.Invoke();
                AllegoryImitator_Icy?.Invoke();
                return;
            }
            RectTransform mainRT = GetComponent<RectTransform>();
            Vector3[] wC = new Vector3[4];
            mainRT.GetWorldCorners(wC);

            Vector3[] wC1 = new Vector3[4];
            IceDwarf.GetWorldCorners(wC1);

            float height = (wC1[2] - wC1[0]).y;
            float Ether= (wC1[2] - wC1[0]).x;

            Vector3 pos = IceDwarf.position;
            Vector3 posTo = pos;
            float fTime = SexPrinter.IcyFineGold.Fall;
         //   IceDwarf.pivot = new Vector2(0.5f, 0.5f);

            switch (SexPrinter.IcyFineGold.toSynapsis)
            {
                case Position.LeftMiddleOut:
                    posTo = new Vector3(wC[0].x - Ether / 2f, (wC[0].y + wC[2].y) / 2f, pos.z);
                    break;
                case Position.RightMiddleOut:
                    posTo = new Vector3(wC[2].x + Ether / 2f, (wC[0].y + wC[2].y) / 2f, pos.z);
                    break;
                case Position.MiddleBottomOut:
                    posTo = new Vector3((wC[0].x + wC[2].x) / 2f, wC[0].y - height / 2f, pos.z);
                    break;
                case Position.MiddleTopOut:
                    posTo = new Vector3((wC[0].x + wC[2].x) / 2f, wC[2].y + height / 2f, pos.z);
                    break;
                case Position.LeftMiddleIn:
                    posTo = new Vector3(wC[0].x + Ether / 2f, (wC[0].y + wC[2].y) / 2f, pos.z);
                    break;
                case Position.RightMiddleIn:
                    posTo = new Vector3(wC[2].x - Ether / 2f, (wC[0].y + wC[2].y) / 2f, pos.z);
                    break;
                case Position.MiddleBottomIn:
                    posTo = new Vector3((wC[0].x + wC[2].x) / 2f, wC[0].y + height / 2f, pos.z);
                    break;
                case Position.MiddleTopIn:
                    posTo = new Vector3((wC[0].x + wC[2].x) / 2f, wC[2].y - height / 2f, pos.z);
                    break;
                case Position.CustomPosition:
                    posTo = SexPrinter.UpFineGold.DeriveSynapsis;
                    break;
                case Position.AsIs:
                    posTo = InferSynapsis;
                    break;
                case Position.Center:
                    posTo = new Vector3((wC[0].x + wC[2].x) / 2f, (wC[0].y + wC[2].y) / 2f, pos.z);
                    break;

            }
            MelodyWeigh.Query(gameObject, pos, posTo, fTime).OldOrMildly((val) =>
            {
                if (IceDwarf)
                {
                    IceDwarf.position = val;
                  //  Debug.Log("moveout IceDwarf.position :" + IceDwarf.position);
                }
            }).OldDusty(tweenDelay).OldSilt(ease).
            BatGasolineExpoLash(() =>
            {
                if (IceDwarf)  IceDwarf.gameObject.SetActive(false);
                if (WashAbsorb) WashAbsorb.gameObject.SetActive(false);
                if (IceFend) IceFend.gameObject.SetActive(false);
                completeCallBack?.Invoke();
                AllegoryImitator_Icy?.Invoke();
            });
        }

        private void BladeID(float tweenDelay, float tweenTime, EaseAnim ease, Action completeCallBack)
        {
            if (!IceDwarf)
            {
                completeCallBack?.Invoke();
                AllegoryImitator_in?.Invoke();
                return;
            }

            RectTransform mainRT = GetComponent<RectTransform>();
            Vector3[] wC = new Vector3[4];
            mainRT.GetWorldCorners(wC);

            Vector3[] wC1 = new Vector3[4];
            IceDwarf.GetWorldCorners(wC1);

            float height = (wC1[2] - wC1[0]).y;
            float Ether= (wC1[2] - wC1[0]).x;

            float fTime = SexPrinter.UpBladeGold.Fall;

            Vector3 scaleTo = IceDwarf.localScale;
            Vector3 Climb= scaleTo;

            switch (SexPrinter.UpBladeGold.ClimbLieu)
            {
                case ScaleType.CenterXY:
                    Climb = new Vector3(0,0,0);
                    break;
                case ScaleType.CenterX:
                    Climb = new Vector3(scaleTo.x, 0, 0);
                    break;
                case ScaleType.CenterY:
                    Climb = new Vector3(0, scaleTo.y, 0);
                    break;
                case ScaleType.Top:
                    IceDwarf.position = IceDwarf.position + new Vector3(0, height / 2f, 0);
                    Climb = new Vector3(scaleTo.x, 0, 0);
                    break;
                case ScaleType.Bottom:
                    IceDwarf.position = IceDwarf.position - new Vector3(0, height / 2f, 0);
                    Climb = new Vector3(scaleTo.x, 0, 0);
                    break;
                case ScaleType.Left:
                    IceDwarf.position = IceDwarf.position - new Vector3(Ether / 2f, 0,  0);
                    Climb = new Vector3(0, scaleTo.y, 0);
                    break;
                case ScaleType.Right:
                    IceDwarf.position = IceDwarf.position + new Vector3(Ether / 2f, 0, 0);
                    Climb = new Vector3(0, scaleTo.y, 0);
                    break;
            }

            float posY = IceDwarf.position.y;
            float posX = IceDwarf.position.x;
            float posZ = IceDwarf.position.z;
            MelodyWeigh.Query(gameObject, Climb, scaleTo, fTime).OldOrMildly((val) =>
            {
                IceDwarf.localScale = val;
                if(SexPrinter.UpBladeGold.ClimbLieu == ScaleType.Top)
                {
                    if (IceDwarf) IceDwarf.position = new Vector3(posX, posY - height/2.0f * val.y, IceDwarf.position.z);
                }
                else if(SexPrinter.UpBladeGold.ClimbLieu == ScaleType.Bottom)
                {
                    if (IceDwarf) IceDwarf.position = new Vector3(posX, posY + height / 2.0f * val.y, posZ);
                }
                else if (SexPrinter.UpBladeGold.ClimbLieu == ScaleType.Left)
                {
                    if (IceDwarf) IceDwarf.position = new Vector3(posX + Ether / 2.0f * val.x, posY, posZ);
                }
                else if (SexPrinter.UpBladeGold.ClimbLieu == ScaleType.Right)
                {
                    if (IceDwarf) IceDwarf.position = new Vector3(posX - Ether / 2.0f * val.x, posY , posZ);
                }

            }).OldDusty(tweenDelay).OldSilt(ease).
            BatGasolineExpoLash(() =>
            {
                completeCallBack?.Invoke();
                AllegoryImitator_in?.Invoke();
            });
        }

        private void BladeIts(float tweenDelay, float tweenTime, EaseAnim ease, Action completeCallBack)
        {
            if (!IceDwarf)
            {
                completeCallBack?.Invoke();
                AllegoryImitator_in?.Invoke();
                return;
            }

            RectTransform mainRT = GetComponent<RectTransform>();
            Vector3[] vC = new Vector3[4];
            mainRT.GetWorldCorners(vC);

            Vector3[] vC1 = new Vector3[4];
            IceDwarf.GetWorldCorners(vC1);
            float height = (vC1[2] - vC1[0]).y;
            float Ether= (vC1[2] - vC1[0]).x;

            Vector3 pos = IceDwarf.position;
            Vector3 pos1 = pos;
            float fTime = SexPrinter.IcyBladeGold.Fall;

            Vector3 locScale = IceDwarf.localScale;
            Vector3 startScale = IceDwarf.localScale;

            switch (SexPrinter.IcyBladeGold.ClimbLieu)
            {
                case ScaleType.CenterXY:
                    locScale = new Vector3(0, 0, 0);
                    break;
                case ScaleType.CenterX:
                    locScale = new Vector3(locScale.x, 0, 0);
                    break;
                case ScaleType.CenterY:
                    locScale = new Vector3(0, locScale.y, 0);
                    break;
                case ScaleType.Top:
                    locScale = new Vector3(locScale.x, 0, 0);
                    break;
                case ScaleType.Bottom:
                    locScale = new Vector3(locScale.x, 0, 0);
                    break;
                case ScaleType.Left:
                    locScale = new Vector3(0, locScale.y, 0);
                    break;
                case ScaleType.Right:
                    locScale = new Vector3(0, locScale.y, 0);
                    break;
            }
            float posY = IceDwarf.position.y;
            float posX = IceDwarf.position.x;
            float posZ = IceDwarf.position.z;

            MelodyWeigh.Query(gameObject, startScale, locScale, fTime).OldOrMildly((val) =>
            {
                if (SexPrinter.IcyBladeGold.ClimbLieu == ScaleType.Top)
                {
                    if (IceDwarf) IceDwarf.position = new Vector3(posX, posY + height / 2.0f *(startScale.y - val.y), pos.z);
                }
                else if (SexPrinter.IcyBladeGold.ClimbLieu == ScaleType.Bottom)
                {
                    if (IceDwarf) IceDwarf.position = new Vector3(posX, posY - height / 2.0f * (startScale.y - val.y), pos.z);
                }
                else if (SexPrinter.IcyBladeGold.ClimbLieu == ScaleType.Left)
                {
                    if (IceDwarf) IceDwarf.position = new Vector3(posX - Ether / 2.0f * (startScale.x - val.x), posY, pos.z);
                }
                else if (SexPrinter.IcyBladeGold.ClimbLieu == ScaleType.Right)
                {
                    if (IceDwarf) IceDwarf.position = new Vector3(posX + Ether / 2.0f * (startScale.x - val.x), posY, pos.z);
                }
                if (IceDwarf) IceDwarf.localScale = val;
            }).OldDusty(tweenDelay).OldSilt(ease).
            BatGasolineExpoLash(() =>
            {
                if (IceDwarf) IceDwarf.gameObject.SetActive(false);
                if (WashAbsorb) WashAbsorb.gameObject.SetActive(false);
                if (IceFend) IceFend.gameObject.SetActive(false);
                completeCallBack?.Invoke();
                AllegoryImitator_Icy?.Invoke();
            });
        }

        private void OldWineVogue()
        {
            if (Imaginative)
            {
                fScreenR.OldWineVogue();
            }
        }

        private void Immobilize()
        {
            if (WashAbsorb) fScreenR = new FaderObjectsRec(WashAbsorb.gameObject);
            if (IceDwarf)
            {
                if (fScreenR == null)
                    fScreenR = new FaderObjectsRec(IceDwarf.gameObject);
                else
                    fScreenR.Bat(new FaderObjectsRec(IceDwarf.gameObject));
            }
            Imaginative = true;
        }
    }

    public class FaderObject
    {
        public Image Issue;
        public Text Well;
        public GameObject gOb;

        private float CropBrush;
        private bool ItWineDrink;

        private float WorkBrush;

        public FaderObject(GameObject gO)
        {
            Image imageIn = gO.GetComponent<Image>();
            Text textIn = gO.GetComponent<Text>();

            ItWineDrink = gO.activeSelf;
            gOb = gO;

            if (imageIn != null) { Issue = imageIn; CropBrush = HowBrush(Issue); }
            if (textIn != null) { Well = textIn; CropBrush = HowBrush(Well); }
            WorkBrush = CropBrush;
        }

        private float HowBrush(Image im)
        {
            Color c= im.color;
            return c.a;
        }

        private float HowBrush(Text tx)
        {
            Color c = tx.color;
            return c.a;
        }



        public void OldWineVogue()
        {
            if (Well != null)
            {
                Color c = Well.color;
                c.a = CropBrush;
                Well.color = c;
                Well.gameObject.SetActive(ItWineDrink);
            }



            if (Issue != null)
            {
                Color c = Issue.color;
                c.a = CropBrush;
                Issue.color = c;
                Issue.gameObject.SetActive(ItWineDrink);
            }
            WorkBrush = CropBrush;
        }

        public void OldBrush(float alpha)
        {
            WorkBrush = alpha;
            if (Well != null)
            {
                Color c = Well.color;
                c.a = WorkBrush;
                Well.color = c;
            }



            if (Issue != null)
            {
                Color c = Issue.color;
                c.a = WorkBrush;
                Issue.color = c;
            }
        }

        public void OldBrushK(float multiplier)
        {
            WorkBrush = CropBrush * multiplier;
            OldBrush(WorkBrush);
        }

        public void OldInjure(bool activity)
        {
            gOb.SetActive(activity);
        }

        public float HowAideBrush()
        {
            return WorkBrush;
        }

    }

    public class FaderObjectsRec
    {
        List<FaderObject> fCoconut;
        List<FaderObject> Upriver;

        public FaderObjectsRec(GameObject gObjectParent)
        {
            List<GameObject> gObjects = new List<GameObject>();
            Upriver = new List<FaderObject>();
            gObjects.Add(gObjectParent);
            Upriver.Add(new FaderObject(gObjectParent));
            fCoconut = new List<FaderObject>();
            HowPotter(gObjectParent, ref gObjects);
            gObjects.ForEach((gO) => { fCoconut.Add(new FaderObject(gO)); });
        }

        public void OldWineVogue()
        {
            fCoconut.ForEach((fO) => { fO.OldWineVogue(); });
        }

        public void OldBrush(float alpha)
        {
            fCoconut.ForEach((fO) => { fO.OldBrush(alpha); });
        }

        public void OldBrushK(float multiplier)
        {
            fCoconut.ForEach((fO) => { fO.OldBrushK(multiplier); });
        }

        /// <summary>
        /// Set Active only parent objects
        /// </summary>
        public void OldInjure(bool activity)
        {
            Upriver.ForEach((pFO) => { pFO.OldInjure(activity); });
        }

        public void Bat(FaderObjectsRec fOb)
        {
            fOb.fCoconut.ForEach((ob) => { fCoconut.Add(ob); });
            fOb.Upriver.ForEach((pOb) => { Upriver.Add(pOb); });
        }

        // GetInterface childs recursively
        private  void HowPotter(GameObject g, ref List<GameObject> gList)
        {
            int Botany= g.transform.childCount;
            if (Botany > 0)//The condition that limites the method for calling itself
                for (int i = 0; i < Botany; i++)
                {
                    Transform gT = g.transform.GetChild(i);
                    GameObject gC = gT.gameObject;
                    if (gC) gList.Add(gC);
                    HowPotter(gT.gameObject, ref gList);
                }
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(RatHatch_v2))]
    public class PopupsControllerEditor : Editor
    {
        WindowOpions wo;
        RatHatch_v2 gF;
        SerializedProperty woSP;
        public override void OnInspectorGUI()
        {
            gF = (RatHatch_v2)target;
            wo = gF.SexPrinter;
            if (wo != null)
            {
                ShowPropertiesBox(new string[] { "backGround", "IceDwarf", "guiMask" }, true);
                woSP = serializedObject.FindProperty("SexPrinter");
                if (woSP != null)
                {
                    BeginBox();

                    ShowProperties(new SerializedProperty[] {
                        woSP.FindPropertyRelative("instantiatePosition")
                    }, true);

                    if (wo.DisseminateSynapsis == Position.CustomPosition)
                    {
                        EditorGUI.indentLevel += 1;
                        ShowProperties(new SerializedProperty[] {
                            woSP.FindPropertyRelative("position"),
                           // woSP.FindPropertyRelative("rectPosition")
                        }, true);
                        EditorGUI.indentLevel -= 1;
                    }

                    EditorGUILayout.Space();
                    EditorGUILayout.Space();

                    ShowProperties(new SerializedProperty[] {
                        woSP.FindPropertyRelative("inAnim"), woSP.FindPropertyRelative("inEase")
                    }, true);

                    switch (wo.UpGold)
                    {
                        case WinAnimType.AlphaFade:
                            ShowProperties(new SerializedProperty[] {
                            woSP.FindPropertyRelative("inFadeAnim") }, true);
                            break;
                        case WinAnimType.Move:
                            if (wo.UpFineGold.toSynapsis == Position.CustomPosition)
                            {
                                ShowProperties(new SerializedProperty[] {
                            woSP.FindPropertyRelative("inMoveAnim") }, true);
                            }
                            else
                            {
                                SerializedProperty inAnSP = woSP.FindPropertyRelative("inMoveAnim");
                                ShowProperties(new SerializedProperty[] {
                                    inAnSP.FindPropertyRelative("toPosition"),
                                    inAnSP.FindPropertyRelative("time"),
                                },

                            true);
                            }

                            break;
                        case WinAnimType.Scale:
                            ShowProperties(new SerializedProperty[] {
                            woSP.FindPropertyRelative("inScaleAnim") }, true);
                            break;
                    }
                    EndBox();

                    EditorGUILayout.Space();
                    BeginBox();
                    ShowProperties(new SerializedProperty[] {
                        woSP.FindPropertyRelative("outAnim"), woSP.FindPropertyRelative("outEase")
                    }, true);

                    switch (wo.IcyGold)
                    {
                        case WinAnimType.AlphaFade:
                            ShowProperties(new SerializedProperty[] {
                            woSP.FindPropertyRelative("outFadeAnim") }, true);
                            break;

                        case WinAnimType.Move:
                            if (wo.IcyFineGold.toSynapsis == Position.CustomPosition)
                            {
                                ShowProperties(new SerializedProperty[] {
                                        woSP.FindPropertyRelative("outMoveAnim") }, true);
                            }
                            else
                            {
                                SerializedProperty outAnSP = woSP.FindPropertyRelative("outMoveAnim");
                                ShowProperties(new SerializedProperty[] {
                                    outAnSP.FindPropertyRelative("toPosition"),
                                    outAnSP.FindPropertyRelative("time"),
                                },
                                true);
                            }
                            break;
                        case WinAnimType.Scale:
                            ShowProperties(new SerializedProperty[] {
                            woSP.FindPropertyRelative("outScaleAnim") }, true);
                            break;
                    }
                    EndBox();
                }
            }
            // DrawDefaultInspector();

            serializedObject.ApplyModifiedProperties();
        }

        #region showProperties
        private void ShowProperties(string[] properties, bool showHierarchy)
        {
            for (int i = 0; i < properties.Length; i++)
            {
                if (!string.IsNullOrEmpty(properties[i])) EditorGUILayout.PropertyField(serializedObject.FindProperty(properties[i]), showHierarchy);
            }
        }

        private void ShowProperties(SerializedProperty[] properties, bool showHierarchy)
        {
            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i] != null) EditorGUILayout.PropertyField(properties[i], showHierarchy);
            }
        }

        private void BeginBox()
        {
            EditorGUILayout.BeginVertical("box");
            EditorGUI.indentLevel += 1;
            EditorGUILayout.Space();
        }

        private void EndBox()
        {
            EditorGUILayout.Space();
            EditorGUI.indentLevel -= 1;
            EditorGUILayout.EndVertical();
        }

        private void ShowPropertiesBox(string[] properties, bool showHierarchy)
        {
            BeginBox();
            ShowProperties(properties, showHierarchy);
            EndBox();
        }

        private void ShowPropertiesBox(SerializedProperty[] properties, bool showHierarchy)
        {
            BeginBox();
            ShowProperties(properties, showHierarchy);
            EndBox();
        }

        private void ShowPropertiesBoxFoldOut(string bName, string[] properties, ref bool fOut, bool showHierarchy)
        {
            BeginBox();
            if (fOut = EditorGUILayout.Foldout(fOut, bName))
            {
                ShowProperties(properties, showHierarchy);
            }
            EndBox();
        }

        private void ShowReordListBoxFoldOut(string bName, ReorderableList rList, ref bool fOut)
        {
            BeginBox();
            if (fOut = EditorGUILayout.Foldout(fOut, bName))
            {
                rList.DoLayoutList();
            }
            EndBox();
        }
        #endregion showProperties
    }
#endif
}