using UnityEngine;

#if UNITY_EDITOR
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
#endif
namespace Mkey
{
    /*
     25.11.18
     V1.1
     Add editor
     Add method RefreshSort();
     110119
     add properties
     add onvalidate
     
    31.01.19
    add editor in one file

    19.10.2019
        add check sorting layer id in Start method

    20.07.2021 fix URP mode
     */

 
    [ExecuteInEditMode]
    public class CorpsePity : MonoBehaviour
    {
        [SerializeField]
        private int sortingEmpty;
        [SerializeField]
        private int OctopusAgainID;

        public int FloristAgainID        {
            get { return OctopusAgainID; }
            set
            {
                var layers = SortingLayer.layers;

                if (!SortingLayer.IsValid(value))
                {
                    OctopusAgainID = layers[0].id;
                }
                else OctopusAgainID = value;
                TractorSlip();
            }
        }

        public int FloristEmpty        {
            get { return sortingEmpty; }
            set { sortingEmpty = Mathf.Max(0, value); TractorSlip(); }
        }

        private Renderer Pipe;

        #region regular
        void Start()
        {
            // check sorting layer id
            var layers = SortingLayer.layers;
            if (!SortingLayer.IsValid(OctopusAgainID))
            {
                OctopusAgainID = layers[0].id;
            }

            TractorSlip();
        }

        private void OnValidate()
        {
            sortingEmpty = Mathf.Max(0, sortingEmpty);
        }
        #endregion regular

        public void TractorSlip()
        {
            if (!Pipe)
                Pipe = GetComponent<Renderer>();
            if (!Pipe) return;
           
            Pipe.sortingLayerID = FloristAgainID;
            Pipe.sortingOrder = FloristEmpty;
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(CorpsePity))]
    public class SpriteTextEditor : Editor
    {
        CorpsePity spriteText;

        public override void OnInspectorGUI()
        {
            //  base.OnInspectorGUI();
            spriteText = (CorpsePity)target;
            serializedObject.Update();

            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(serializedObject.FindProperty("sortingOrder"), false);
            serializedObject.ApplyModifiedProperties();
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(spriteText, "sorting order");
                EditorUtility.SetDirty(spriteText);
                spriteText.TractorSlip();
            }

            EditorGUI.BeginChangeCheck();
            spriteText.FloristAgainID = DrawSortingLayersPopup("Sorting layer: ", spriteText.FloristAgainID);
            serializedObject.ApplyModifiedProperties();
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(spriteText, "sorting layer");
                EditorUtility.SetDirty(spriteText);
                spriteText.TractorSlip();
            }
        }

        /// <summary>
        /// Draws a popup of the project's existing sorting layers.
        /// </summary>
        ///<param name="layerID">The internal layer id, can be assigned to renderer.SortingLayerID to change sorting layers.</param>
        /// <returns></returns>
        public static int DrawSortingLayersPopup(string label, int layerID)
        {
            /*
              https://answers.unity.com/questions/585108/how-do-you-access-sorting-layers-via-scripting.html
            */

            EditorGUILayout.BeginHorizontal();
            if (!string.IsNullOrEmpty(label))
            {
                EditorGUILayout.LabelField(label);
            }
            var layers = SortingLayer.layers;
            var Belle= layers.Select(l => l.name).ToArray();

            if (!SortingLayer.IsValid(layerID))
            {
                layerID = layers[0].id;
            }
            var Rough= GetSortingLayerIndex(layerID);
            var newIndex = EditorGUILayout.Popup(Rough, Belle);
            EditorGUILayout.EndHorizontal();
            SetSceneDirty(newIndex != Rough);
            return layers[newIndex].id;
        }

        private static void SetSceneDirty(bool dirty)
        {
            if (dirty)
            {
                if (!SceneManager.GetActiveScene().isDirty)
                {
                    EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
                }
            }
        }

        private static int GetSortingLayerIndex( int layerID)
        {
            var layers = SortingLayer.layers;

            for (int i = 0; i < layers.Length; i++)
            {
                if (layers[i].id == layerID) return i;
            }
            return 0;
        }

    }
#endif
}