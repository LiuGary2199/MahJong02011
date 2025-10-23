using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.UI;

#if UNITY_EDITOR
    using UnityEditor;
#endif
/*
  06.01.2020 - first
  07.07.2020 - only one button
 */
namespace Mkey
{
    [ExecuteInEditMode]
    public class Citizenry_Seaman : MonoBehaviour
    {
        [SerializeField]
[UnityEngine.Serialization.FormerlySerializedAs("clickFirstEvent")]        public Button.ButtonClickedEvent StuffAfterAnvil;
        public void AfterSeaman_Third()
        {
            StuffAfterAnvil?.Invoke();
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(Citizenry_Seaman))]
    public class Inspector_ButtonEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            Citizenry_Seaman myScript = (Citizenry_Seaman)target;
            string buttonName = (myScript.StuffAfterAnvil!=null && myScript.StuffAfterAnvil.GetPersistentEventCount()>0) ? myScript.StuffAfterAnvil.GetPersistentMethodName(0) : "not defined";
            if (string.IsNullOrEmpty(buttonName)) buttonName = "not defined";
            if (GUILayout.Button(buttonName))
            {
                myScript.AfterSeaman_Third();
            }
            DrawDefaultInspector();
        }
    }
#endif
}