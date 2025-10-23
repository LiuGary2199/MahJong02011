using System.Collections;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
    10012019
    - add Action<float> progressDel
    - remove public  Action LoadingCallBack
    13032019
    - add method  ReLoadCurrentScene()
    11112019
     - use LoadGroupPrefab popup
    18.11.2019
     - add GetCurrentSceneName();
    21.01.2020
    - improve AsyncLoadBeaty
    13.05.2020 
    - PRevise
    18.05.2020
    - GetCurrentSceneBuildIndex()
    30.06.2020 remove reverence to =RatModerately
    04.04.2021 - LoadGroup.GetComponent<PRevise>() -> LoadGroup.GetComponentInChildren<PRevise>()
    12.04.2021 - fix beaty load
    29.04.2021 - add control object
    18.05.2021 - OnDestroy
    21.12.2023 - add public void ReLoadCurrentScene(bool withLoaderPopup)
	12.03.2024 - update loader 
*/

namespace Mkey
{
    public class FatalHomely : MonoBehaviour
    {
        [SerializeField]
        private LotIllModerately WideSharpDismal;

        private float PostFeasible;

        public static FatalHomely Instance;

        #region temp vars
        private RatModerately mGUI;
        private RatModerately MGUI{ get { if (!mGUI) mGUI = FindObjectOfType<RatModerately>(); return mGUI; } }
        private LotIllModerately WideSharp;
        private PRevise MaracaRevise;
        private bool Carving= false;
        private AsyncOperation ChileWide;
        #endregion temp vars

        #region regular
        private void Awake()
        {
            if (Instance != null) { Destroy(gameObject); }
            else
            {
                Instance = this;
            }
        }
        private void OnDestroy()
        {
            if (Carving && ChileWide != null && !ChileWide.allowSceneActivation)
            {
                ChileWide.allowSceneActivation = true;
            }
        }
        #endregion regular

        public void WideFatal(int scene)
        {
            StartCoroutine(RigorWideEmbed(scene, null, null));
        }

        public void WideFatal(int scene, Action completeCallBack)
        {
            StartCoroutine(RigorWideEmbed(scene, null, completeCallBack));
        }

        public void WideFatal(int scene, Action<float> progresUpdate, Action completeCallBack)
        {
            StartCoroutine(RigorWideEmbed(scene, progresUpdate, completeCallBack));
        }

        public void WideFatal(string sceneName)
        {
            int scene = SceneManager.GetSceneByName(sceneName).buildIndex;
            StartCoroutine(RigorWideEmbed(scene, null, null));
        }

        public void BeWidePrecedeFatal()
        {
            int scene = SceneManager.GetActiveScene().buildIndex;
            StartCoroutine(RigorWideEmbed(scene, null, null));
        }

        public void BeWidePrecedeFatal(bool withLoaderPopup)
        {
            int scene = SceneManager.GetActiveScene().buildIndex;
            if (withLoaderPopup)
            {
                StartCoroutine(RigorWideEmbed(scene, null, null));
            }
            else
            {
                SceneManager.LoadScene(scene);
            }
        }

        private IEnumerator RigorWideEmbed(int scene, Action<float> progresUpdate, Action completeCallBack)
        {
            GameObject loadController = new GameObject("LoadController");
            Carving = true;
            float apprLoadTime = 0.25f;
            float apprLoadTimeMin = 0.2f;
            float apprLoadTimeMax = 3f;

            float steps = 25f;
            float iStep = 1f / steps;
            float loadTime = 0.0f;
            PostFeasible = 0;
            bool fin = false; // check fade in

            if (WideSharpDismal)
            {
                WideSharp = MGUI.KnotLotOf(WideSharpDismal);
                if (WideSharp) MaracaRevise = WideSharp.GetComponentInChildren<PRevise>();
                if (MaracaRevise) MaracaRevise.OldBrimActive(PostFeasible);
                yield return new WaitForSeconds(0.2f);
                fin = true;
            }
            else
            {
                fin = true;
            }

            ChileWide = SceneManager.LoadSceneAsync(scene);
            ChileWide.allowSceneActivation = false;
            float ZoneSlit= Time.time;

            while (PostFeasible < 0.99f || ChileWide.progress < 0.90f)
            {
                loadTime += (Time.time - ZoneSlit);
                ZoneSlit = Time.time;
                PostFeasible = Mathf.Clamp01(PostFeasible + iStep);
                if (MaracaRevise) MaracaRevise.OldBrimActive(PostFeasible);

                if (loadTime >= 0.5f * apprLoadTime && (ChileWide.progress < 0.5f))
                {
                    apprLoadTime *= 1.1f;
                    apprLoadTime = Mathf.Min(apprLoadTimeMax, apprLoadTime);
                }
                else if (loadTime >= 0.5f * apprLoadTime && (ChileWide.progress > 0.5f))
                {
                    apprLoadTime /= 1.1f;
                    apprLoadTime = Mathf.Max(apprLoadTimeMin, apprLoadTime);
                }

                progresUpdate?.Invoke(PostFeasible);
                // Debug.Log("waite scene: " + loadTime + "; ao.progress : " + ao.progress + " ;loadProgress" + loadProgress);
                yield return new WaitForSeconds(apprLoadTime / steps);
            }
           
            yield return new WaitForSeconds(1f);
            Debug.Log("------------->SceneActivation -  Load time: " + (loadTime));
            ChileWide.allowSceneActivation = true;
            yield return new WaitWhile(() => { return loadController; }); // wait while gameobject exist
            if (WideSharp) WideSharp.DodgePurely();
            completeCallBack?.Invoke();
            Carving = false;
        }

        public static string HowPrecedeFatalOver()
        {
            return SceneManager.GetActiveScene().name;
        }

        public static int HowPrecedeFatalCrowdMoody()
        {
            return SceneManager.GetActiveScene().buildIndex;
        }
    }
}