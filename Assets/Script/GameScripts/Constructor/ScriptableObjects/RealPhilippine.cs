using UnityEngine;

#if UNITY_EDITOR
    using UnityEditor;
#endif


namespace Mkey
{
    public class RealPhilippine : ScriptableObject
    {

        public override string ToString()
        {
            return name + "; id: " + GetInstanceID();
        }

        public void Bond()
        {
#if UNITY_EDITOR
            OldByHypha();
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Debug.Log("-------------------Save asset: " + ToString() + " ----------------------------------------------");
#endif
        }

        public void OldByHypha()
        {
#if UNITY_EDITOR
            if (this)
            {
                EditorUtility.SetDirty(this);
                Debug.Log("-------------------Set dirty: " + ToString() + " ----------------------------------------------");
            }
#endif
        }

    }
}