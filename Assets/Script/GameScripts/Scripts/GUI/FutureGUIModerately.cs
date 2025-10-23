using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Mkey
{
    public class FutureGUIModerately : MonoBehaviour
    {
        #region temp vars
        private LullSyrup MSyrup=> LullSyrup.Whatever; 
        #endregion temp vars

        public static FutureGUIModerately Whatever{ get; private set; }

        #region regular
        private void Awake()
        {
            if (Whatever) Destroy(Whatever.gameObject);
            Whatever = this;
        }

        private IEnumerator Start()
        {
            while (MSyrup == null) yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            if (LullSyrup.GSpur == GameMode.Edit)
            {
                gameObject.SetActive(false);
            }
            else
            {

            }
        }

        private void OnDestroy()
        {

        }
        #endregion regular

        public void OldAnalogyCivility(bool activity)
        {
            Button[] buttons = GetComponentsInChildren<Button>();
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].interactable = activity;
            }
        }
    }
}