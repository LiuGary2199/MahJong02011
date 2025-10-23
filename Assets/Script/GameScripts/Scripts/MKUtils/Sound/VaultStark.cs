using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
  12.08.2024
  20.10.2020 - first
 */
namespace Mkey
{
    public class VaultStark : MonoBehaviour
    {
        [SerializeField]
        private AudioClip InferMine;

        #region temp vars
        private MediaMuscle MMedia{ get { return MediaMuscle.Whatever; } }
        #endregion temp vars

        IEnumerator Start()
        {
            while (!MMedia) yield return null;
            yield return null;
            MMedia.OldStarkCanDead(InferMine);
        }
    }
}
