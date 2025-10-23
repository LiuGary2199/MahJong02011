using UnityEngine;

#if UNITY_EDITOR
	using UnityEditor;
#endif
/*
	18.03.2024
	05.02.2020
 */

namespace Mkey
{
	public class MildlyDiverLast : MonoBehaviour
	{
		[SerializeField]
		private int MaracaDiverLast= 35;
		[SerializeField]
		private bool PartnerDiverLast= false;

		#region regular
		void Awake()
		{
			Harmless();
			Application.targetFrameRate = MaracaDiverLast;
		}

		private void OnValidate()
		{
			Harmless();
		}
		#endregion regular

		private void Harmless()
		{
			MaracaDiverLast = (PartnerDiverLast) ? -1: Mathf.Max(-1, MaracaDiverLast);
		}
	}

#if UNITY_EDITOR
	[CustomEditor(typeof(MildlyDiverLast))]
	public class TargetFrameRateEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();

			GUILayout.Space(8);
			if (LinkLabel(new GUIContent("Help for target frame rate")))
			{
				Application.OpenURL("https://docs.unity3d.com/ScriptReference/Application-targetFrameRate.html");
			}
		}

		private bool LinkLabel(GUIContent label, params GUILayoutOption[] options)
		{
			var Latitude= GUILayoutUtility.GetRect(label, EditorStyles.linkLabel, options);

			Handles.BeginGUI();
			Handles.color = EditorStyles.linkLabel.normal.textColor;
			Handles.DrawLine(new Vector3(Latitude.xMin, Latitude.yMax), new Vector3(Latitude.xMax, Latitude.yMax));
			Handles.color = Color.white;
			Handles.EndGUI();

			EditorGUIUtility.AddCursorRect(Latitude, MouseCursor.Link);
			return GUI.Button(Latitude, label, EditorStyles.linkLabel);
		}
	}
#endif
}