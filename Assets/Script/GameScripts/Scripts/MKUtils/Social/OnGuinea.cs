using System.Collections;
using UnityEngine.Events;
using UnityEngine;

/*
  24.01.2022
 */

namespace Mkey
{
    public class OnGuinea : MonoBehaviour
    {
[UnityEngine.Serialization.FormerlySerializedAs("LoadFullNameEvent")]        public UnityEvent <string> WidePeckOverAnvil;
[UnityEngine.Serialization.FormerlySerializedAs("LoadFirstNameEvent")]        public UnityEvent<string> WideAfterOverAnvil;
[UnityEngine.Serialization.FormerlySerializedAs("LoadLastNameEvent")]        public UnityEvent<string> WideHurlOverAnvil;
[UnityEngine.Serialization.FormerlySerializedAs("GoodLoginEvent")]        public UnityEvent GoodStingAnvil;
[UnityEngine.Serialization.FormerlySerializedAs("FailedLoginEvent")]        public UnityEvent <string> InsistStingAnvil; // <result>
[UnityEngine.Serialization.FormerlySerializedAs("LogoutEvent")]        public UnityEvent AsleepAnvil;

        #region regular
        void Start()
        {
            FFreshly.AsleepAnvil += AsleepAnvilPropose;
            FFreshly.StingAnvil += StingAnvilPropose;
            FFreshly.WidePityAnvil += WidePityAnvilPropose; 
        }

        void OnDestroy()
        {
            FFreshly.AsleepAnvil -= AsleepAnvilPropose;
            FFreshly.StingAnvil -= StingAnvilPropose;
            FFreshly.WidePityAnvil -= WidePityAnvilPropose;
        }
        #endregion regular

        private void StingAnvilPropose(bool logined, string result)
        {
            if (logined)
            {
                GoodStingAnvil?.Invoke();
            }
            else
            {
                InsistStingAnvil?.Invoke(result);
            }
        }

        private void AsleepAnvilPropose()
        {
            AsleepAnvil?.Invoke();
        }

        private void WidePityAnvilPropose(bool logined, string firstName, string lastName)
        {
            if (logined)
            {
                WideAfterOverAnvil?.Invoke(firstName);
                WideHurlOverAnvil?.Invoke(lastName);
                WidePeckOverAnvil?.Invoke(firstName +" "+ lastName);
            }
        }
    }
}