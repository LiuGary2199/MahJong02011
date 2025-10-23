using UnityEngine;

/*
  26.11.2019 - first
 */
namespace Mkey
{
    public class VaultMedia : MonoBehaviour
    {
        [SerializeField]
        private AudioClip InferMine;
        [SerializeField]
        private float Sport;

        #region temp vars
        private MediaMuscle MMedia{ get { return MediaMuscle.Whatever; } }
        #endregion temp vars

        void Start()
        {
          if(MMedia) MMedia.DeadMine(Sport, InferMine);
        }
    }
}
