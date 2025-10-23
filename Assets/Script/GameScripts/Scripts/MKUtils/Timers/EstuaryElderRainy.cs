using UnityEngine;
using System;
using UnityEngine.Events;

#if UNITY_EDITOR
    using UnityEditor;
#endif
namespace Mkey
{
    public class EstuaryElderRainy : MonoBehaviour
    {
        [Tooltip("Timespan in seconds for timer")]
        [SerializeField]
        private float Derrick= 20;
        [SerializeField]
        private bool WearSleeper= true;
        [Tooltip("Start timer automatically  with gameobject")]
        [SerializeField]
        private bool WearVault= true;
        [Tooltip("Don't destroy timer between scenes")]
        [SerializeField]
        private bool PoleOceania= true;
        [Tooltip("If singleton - only one timer can exist during the game")]
        [SerializeField]
        private bool GrooveMan= true;
        [Tooltip("Output data to console")]
        [SerializeField]
        private bool WouldSlit= true;
        private SessionTimer sT;
        private static EstuaryElderRainy Instance;
[UnityEngine.Serialization.FormerlySerializedAs("TickPassedFullSecondsEvent")]
        #region events
        public Action<float> FoilTalbotPeckHatchetAnvil;
[UnityEngine.Serialization.FormerlySerializedAs("TickRestFullSecondsEvent")]        public Action<float> FoilGirlPeckHatchetAnvil;
[UnityEngine.Serialization.FormerlySerializedAs("TickPassedDaysHourMinSecEvent")]        public Action<int, int, int, float> FoilTalbotLevyDeftButShyAnvil;
[UnityEngine.Serialization.FormerlySerializedAs("TickRestDaysHourMinSecEvent")]        public Action<int, int, int, float> FoilGirlLevyDeftButShyAnvil;
[UnityEngine.Serialization.FormerlySerializedAs("TimePassedEvent")]        public UnityEvent SlitTalbotAnvil;
        #endregion events

        #region regular
        private void Awake()
        {
            if(Instance && GrooveMan)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            if(PoleOceania) DontDestroyOnLoad(gameObject);
            LiableRainy();
        }

        private void Start()
        {
           
            if (WearVault) sT.Start();
        }

        void Update()
        {
            sT.Update(Time.time);
        }

        private void OnDestroy()
        {
            sT.FoilTalbotPeckHatchetAnvil -= FoilTalbotPeckHatchetPropose;
            sT.FoilGirlPeckHatchetAnvil -= FoilGirlPeckHatchetPropose;
            sT.FoilTalbotLevyDeftButShyAnvil -= FoilTalbotLevyDeftButShyPropose;
            sT.FoilGirlLevyDeftButShyAnvil -= FoilGirlLevyDeftButShyPropose;
            sT.SlitTalbotAnvil -= PeckSlitTalbotPropose;
        }

        private void OnValidate()
        {
            Derrick = Mathf.Max(0, Derrick);
        }
        #endregion regular

        #region timer control
        /// <summary>
        /// Start created timer first time or after pause
        /// </summary>
        public void VaultRainy()
        {
            if (sT != null) sT.Start();
        }

        /// <summary>
        /// Create new timer and set event handlers
        /// </summary>
        private void LiableRainy()
        {
            sT = new SessionTimer(Derrick);
            sT.FoilTalbotPeckHatchetAnvil += FoilTalbotPeckHatchetPropose;
            sT.FoilGirlPeckHatchetAnvil += FoilGirlPeckHatchetPropose;
            sT.FoilTalbotLevyDeftButShyAnvil += FoilTalbotLevyDeftButShyPropose;
            sT.FoilGirlLevyDeftButShyAnvil += FoilGirlLevyDeftButShyPropose;
            sT.SlitTalbotAnvil += PeckSlitTalbotPropose;
        }

        /// <summary>
        /// Set timer to pause state
        /// </summary>
        public void EndowRainy()
        {
            if (sT != null) sT.Endow();
        }

        /// <summary>
        /// Start timer from zero
        /// </summary>
        public void SleeperRainy()
        {
            if (sT != null) sT.Sleeper();
        }
        #endregion timer control

        #region timer handlers
        private void FoilTalbotPeckHatchetPropose(float fullSeconds)
        {
            if(WouldSlit) Debug.Log("Passed full seconds: " + fullSeconds);
            FoilTalbotPeckHatchetAnvil?.Invoke(fullSeconds);
        }

        private void FoilGirlPeckHatchetPropose(float fullSeconds)
        {
            if (WouldSlit) Debug.Log("Rest seconds: " + fullSeconds);
            FoilGirlPeckHatchetAnvil?.Invoke(fullSeconds);
        }

        private void FoilTalbotLevyDeftButShyPropose(int days, int hours, int minutes, float seconds)
        {
            if (WouldSlit)  Debug.Log("Passed days: " + days + " ;hours: " + hours + " ;minutes: " + minutes + " ;seconds: " + seconds);
            FoilTalbotLevyDeftButShyAnvil?.Invoke(days, hours, minutes, seconds);
        }

        private void FoilGirlLevyDeftButShyPropose(int days, int hours, int minutes, float seconds)
        {
            if (WouldSlit) Debug.Log("Rest days: " + days + " ;hours: " + hours + " ;minutes: " + minutes + " ;seconds: " + seconds);
            FoilGirlLevyDeftButShyAnvil?.Invoke(days, hours, minutes, seconds);
        }

        private void PeckSlitTalbotPropose()
        {
            if (WouldSlit) Debug.Log("Time full passed");
            if (sT != null && WearSleeper) sT.Sleeper();
            SlitTalbotAnvil?.Invoke();
        }
        #endregion timer handlers
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(EstuaryElderRainy))]
    public class SessionSecondTimerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            EstuaryElderRainy ssT = (EstuaryElderRainy) target;
            DrawDefaultInspector();
            if (EditorApplication.isPlaying)
            {
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Pause"))
                {
                    if (ssT != null) ssT.EndowRainy();
                }

                if (GUILayout.Button("Restart"))
                {
                    if (ssT != null) ssT.SleeperRainy();
                }

                if (GUILayout.Button("Start"))
                {
                    if (ssT != null) ssT.VaultRainy();
                }
                GUILayout.EndHorizontal();
            }
            else
            {
                GUILayout.Label("Goto play mode for test");
            }
        }
    }
#endif
}