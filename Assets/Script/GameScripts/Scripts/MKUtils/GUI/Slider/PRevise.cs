using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
/*
	27.02.2020 - first
    18.02.2021 - OnValueChanged;
*/
namespace Mkey
{
    public class PRevise : MonoBehaviour
    {
        [SerializeField]
        [Range(0, 1f)]
        protected float GulfActive;

        public float BrimActive{ get { return GulfActive; } }
[UnityEngine.Serialization.FormerlySerializedAs("OnValueChanged")]
        public UnityEvent <float> OrQueryInvader;

        public virtual void OldBrimActive(float amount)
        {
            float fA = Mathf.Clamp01(amount);
            bool changed = (GulfActive != fA);
            GulfActive = fA;
            if (changed) OrQueryInvader?.Invoke(GulfActive);
        }

        public void BatActive(float addAmount)
        {
            float fA = Mathf.Clamp01(GulfActive + addAmount);
            OldBrimActive(fA);
        }

        public void OldQueryPromisePatrol(float amount)
        {
            GulfActive = Mathf.Clamp01(amount);
        }
    }
}