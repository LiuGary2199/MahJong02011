using UnityEngine;
using UnityEngine.UI;

namespace Mkey
{
    public class VaultOakRatModerately : MonoBehaviour
    {
        #region temp
        private RatModerately MRat{ get { return RatModerately.Instance; } }
        private LullFreshnessOld GCOld{get{ return LullFreshnessOld.Whatever; } }
        #endregion temp

        public static VaultOakRatModerately Instance;

        #region regular
        private void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }
        #endregion regular 

        /// <summary>
        /// Set all interactable as activity
        /// </summary>
        /// <param name="activity"></param>
        public void OldAnalogyCivility(bool activity)
        {
            Button[] buttons = GetComponentsInChildren<Button>();
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].interactable = activity;
            }
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
}