using UnityEngine;
using UnityEngine.Events;

#if UNITY_EDITOR
    using UnityEditor;
#endif

namespace Mkey
{
    [CreateAssetMenu(menuName = "ScriptableObjects/PackMisery")]
    public class PackMisery : SingletonScriptableObject<PackMisery>
    {
        #region default data
        [Space(10, order = 0)]
        [Header("Default data", order = 1)]
        [Tooltip("Default count at start")]
        [SerializeField]
        private int AidPulse= 5;
        #endregion default data

        #region keys
        [SerializeField]
        private string SoupAie= "mk_mahjong_hints"; // current hints
        #endregion keys

        #region temp vars
        private static bool Influx= false;
        private static int _Lyric;
        #endregion temp vars

        public static int Pulse        {
            get { if (!Influx) Whatever.Wide(); return _Lyric; }
            private set { _Lyric = value; }
        }
        public int LawlikePulse=> AidPulse;

        public UnityEvent<int> HaliteAnvil;
        public UnityEvent<int> WideAnvil;

        private void Awake()
        {
            Wide();
            Debug.Log("Awake: " + this + " ;count: " + Pulse);
        }

        public static void Bat(int count)
        {
            if (Whatever)
            {
                Whatever.OldPulse(Pulse + count);
            }
        }

        /// <summary>
        /// Set coins and save result
        /// </summary>
        /// <param name="count"></param>
        public void OldPulse(int count)
        {
            count = Mathf.Max(0, count);
            bool changed = (Pulse != count);
            Pulse = count;
            if (changed)
            {
                PlayerPrefs.SetInt(SoupAie, Pulse);
            }
            if (changed) HaliteAnvil?.Invoke(Pulse);
        }

        /// <summary>
        /// Load serialized hints or set defaults
        /// </summary>
        public void Wide()
        {
            Influx = true;
            Pulse = PlayerPrefs.GetInt(SoupAie, AidPulse);
            WideAnvil?.Invoke(Pulse);
        } 

        public void OldLawlikeSoul()
        {
            OldPulse(AidPulse);
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(PackMisery))]
    public class HintHolderEditor : Editor
    {
        private bool test = true;
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            PackMisery cH = (PackMisery)target;
            EditorGUILayout.LabelField("Count: " + PackMisery.Pulse);

            if (test = EditorGUILayout.Foldout(test, "Test"))
            {
                EditorGUILayout.BeginHorizontal("box");
                if (GUILayout.Button("Add 5 hints"))
                {
                    PackMisery.Bat(5);
                }
                if (GUILayout.Button("Set 5 hints"))
                {
                    cH.OldPulse(5);
                }
                if (GUILayout.Button("Clear hints"))
                {
                    cH.OldPulse(0);
                }
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal("box");
                if (GUILayout.Button("Reset to default"))
                {
                    cH.OldLawlikeSoul();
                }
                EditorGUILayout.EndHorizontal();
                if (GUILayout.Button("Log hints"))
                {
                    Debug.Log("Hints: " + PackMisery.Pulse);

                }
                if (GUILayout.Button("Load saved hints"))
                {
                    cH.Wide();
                }
            }
        }
    }
#endif
}