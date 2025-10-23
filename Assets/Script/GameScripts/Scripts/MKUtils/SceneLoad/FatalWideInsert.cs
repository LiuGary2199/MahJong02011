using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
    21.08.2024 - LoadNextScene(), LoadPrevScene()
    04.04.2021 - add autoload
    26.01.2021
 */
namespace Mkey
{
    public class FatalWideInsert : MonoBehaviour
    {
        private FatalHomely SL=> FatalHomely.Instance;
[UnityEngine.Serialization.FormerlySerializedAs("autoLoad")]
        public bool WearWide= false;
        [ShowIfTrue("autoLoad")]
[UnityEngine.Serialization.FormerlySerializedAs("autoLoadDelay")]        public float WearWideDusty= 0f;
        [ShowIfTrue("autoLoad")]
[UnityEngine.Serialization.FormerlySerializedAs("autoLoadSceneIndex")]        public int WearWideFatalMoody= 0;

        private IEnumerator Start()
        {
            if (WearWide) 
            {
                yield return new WaitForSeconds(WearWideDusty);
                WideFatalUpMoody(WearWideFatalMoody);
            }
        }

        /// <summary>
        /// Load scene by build index
        /// </summary>
        /// <param name="scene"></param>
        public void WideFatalUpMoody(int scene)
        {
            if (SL) SL.WideFatal(scene);
        }

        public void WideRageFatal()
        {
            int currIndex = FatalHomely.HowPrecedeFatalCrowdMoody();
            int next = currIndex + 1;
            if (next < SceneManager.sceneCountInBuildSettings) WideFatalUpMoody(next);
            else WideFatalUpMoody(0);
        }

        public void WideWaryFatal()
        {
            int currIndex = FatalHomely.HowPrecedeFatalCrowdMoody();
            int next = currIndex - 1;
            if (next < 0) WideFatalUpMoody(SceneManager.sceneCountInBuildSettings - 1);
            else WideFatalUpMoody(next);
        }
    }
}