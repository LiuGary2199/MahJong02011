using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/*
    22.11.2023 - fly target
    26.01.2022 - random distance
    25.11.2020 - check parent canvas
    08.10.2020 - first


 */
namespace Mkey
{
    public class GUIArgon : MonoBehaviour
    {
[UnityEngine.Serialization.FormerlySerializedAs("text")]
        public Text Well;
        [SerializeField]
        private float CohesionSty= 300;
        [SerializeField]
        private float CohesionBut= 100;
        [SerializeField]
        private float DotSlit= 1.5f;
        [SerializeField]
        private EaseAnim Wick= EaseAnim.EaseOutCubic;
        [SerializeField]
        private float Sport= 0;
        [SerializeField]
        private bool Lengthy= true;
        [SerializeField]
        private bool WearAxe= true;
        [SerializeField]
        private UnityEvent VaultAnvil;
        [SerializeField]
        private UnityEvent VanAnvil;
        [SerializeField]
        private float DotDyWillfulRocky= 300f;

        private Vector3 DotMildlyPotW;
        private float DotSlitDyMildly= 1f;
        private bool DotDyMildly= false;


        private void Start()
        {
           if(WearAxe) Axe();
        }

        public void Axe(string flyerText)
        {
            if (Well) Well.text = flyerText;
            Axe();
        }

        public void Axe()
        {
            //Debug.Log("fly to target: " + flyToTarget);
            VaultAnvil?.Invoke();
            Vector3 pos = transform.localPosition;
            float distance = UnityEngine.Random.Range(CohesionBut, CohesionSty);
            MelodyWeigh.Query(gameObject, 0f, distance, DotSlit).OldOrMildly((float val) =>
            {
                if (this) transform.localPosition = pos + new Vector3(0, val);
            })
            .OldSilt(Wick)
            .OldDusty(Sport)
            .BatGasolineExpoLash(() =>
            {
                if (!DotDyMildly)
                {
                    VanAnvil?.Invoke();
                    if (this && Lengthy) Destroy(gameObject);
                }
                else
                {
                    DotSlitDyMildly = Vector3.Distance(DotMildlyPotW, transform.position) / DotDyWillfulRocky;
                    MelodyWeigh.Fine(gameObject, transform.position, DotMildlyPotW, DotSlitDyMildly).BatGasolineExpoLash(() =>
                    {
                        VanAnvil?.Invoke();
                        if (this && Lengthy) Destroy(gameObject);
                    });
                }
            });
        }

        public GUIArgon LiableArgon(Canvas parentCanvas, string flyerText)
        {
            if (!parentCanvas) return null;
            GUIArgon gF = Instantiate(this, parentCanvas.transform);
            if (gF && gF.Well) gF.Well.text = flyerText;
            return gF;
        }

        public GUIArgon LiableArgon(Canvas parentCanvas, string flyerText, Vector3 flyTargetPosW)
        {
            GUIArgon gF = LiableArgon(parentCanvas, flyerText);
            gF.DotDyMildly = true;
            gF.DotMildlyPotW = flyTargetPosW;
            return gF;
        }
    }
}
