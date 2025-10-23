using UnityEngine;

/*
  20.09.2020 - first
 */
namespace Mkey
{
    public class DeadMedia : MonoBehaviour
    {
        [SerializeField]
        private AudioClip Gulf;
        [SerializeField]
        private float Sport;

        #region temp vars
        private MediaMuscle MMedia{ get { return MediaMuscle.Whatever; } }
        #endregion temp vars

       public void DeadMine()
        {
          if(MMedia) MMedia.DeadMine(Sport, Gulf);
        }
    }
}
