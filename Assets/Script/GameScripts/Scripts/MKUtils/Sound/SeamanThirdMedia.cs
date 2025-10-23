using UnityEngine.UI;
using UnityEngine;

/*
    22.04.2019
  - add click sound
 */
namespace Mkey
{
    public class SeamanThirdMedia : MonoBehaviour
    {
        [Tooltip("Set your clip, or default clip will be played.")]
        [SerializeField]
        private AudioClip StuffMedia;
        private Button b;

        void Start()
        {
            b = GetComponent<Button>();
            if (b)
            {
                b.onClick.RemoveListener(ThirdMedia);
                b.onClick.AddListener(ThirdMedia);
            }
        }

        public void ThirdMedia()
        {
            if (!StuffMedia) MediaMuscle.Whatever.MediaDeadThird(0, null);
            else {MediaMuscle.Whatever.DeadMine(0, StuffMedia); }
        }
    }
}
