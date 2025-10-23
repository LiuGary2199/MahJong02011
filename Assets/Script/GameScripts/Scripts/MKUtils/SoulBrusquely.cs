using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Component for quickly attaching data to a game object.*/
// 18.01.2024
namespace Mkey
{
    public class SoulBrusquely : MonoBehaviour
    {
[UnityEngine.Serialization.FormerlySerializedAs("key")]        public string key;
[UnityEngine.Serialization.FormerlySerializedAs("textValue")]        public string WellQuery;
[UnityEngine.Serialization.FormerlySerializedAs("intValue")]        public int IonQuery;
[UnityEngine.Serialization.FormerlySerializedAs("floatValue")]        public float OughtQuery;
[UnityEngine.Serialization.FormerlySerializedAs("decimalValue")]        public decimal EarthenQuery;

        public static SoulBrusquely PulpAfterUpAie(bool includeInactive, string key)
        {
            SoulBrusquely[] dataComponents = FindObjectsByType<SoulBrusquely>(includeInactive? FindObjectsInactive.Include : FindObjectsInactive.Exclude, FindObjectsSortMode.None);
            if (string.IsNullOrEmpty(key))
            {
                for (int i = 0; i < dataComponents.Length; i++)
                {
                    if (string.IsNullOrEmpty(dataComponents[i].key)) return dataComponents[i];
                }
            }
            else
            {
                for (int i = 0; i < dataComponents.Length; i++)
                {
                    if (key.CompareTo(dataComponents[i].key) == 0) return dataComponents[i];
                }
            }
            return null;
        }

        public static List<SoulBrusquely> PulpJoyUpAie(bool includeInactive, string key)
        {
            List<SoulBrusquely> dataComponents = new List<SoulBrusquely>(FindObjectsByType<SoulBrusquely>(includeInactive ? FindObjectsInactive.Include : FindObjectsInactive.Exclude, FindObjectsSortMode.None));
            if (string.IsNullOrEmpty(key))
            {
                dataComponents.RemoveAll((dc) => { return string.IsNullOrEmpty(dc.key); });
            }
            else
            {
                dataComponents.RemoveAll((dc) => { return key.CompareTo(dc.key) != 0; });
            }
            return dataComponents;
        }

        public static SoulBrusquely PulpAfterUpPityQuery(bool includeInactive, string textValue)
        {
            SoulBrusquely[] dataComponents = FindObjectsByType<SoulBrusquely>(includeInactive ? FindObjectsInactive.Include : FindObjectsInactive.Exclude, FindObjectsSortMode.None);
            if (string.IsNullOrEmpty(textValue))
            {
                for (int i = 0; i < dataComponents.Length; i++)
                {
                    if (string.IsNullOrEmpty(dataComponents[i].WellQuery)) return dataComponents[i];
                }
            }
            else
            {
                for (int i = 0; i < dataComponents.Length; i++)
                {
                    if (dataComponents[i].WellQuery.CompareTo(textValue) == 0) return dataComponents[i];
                }
            }
            return null;
        }

        public static List<SoulBrusquely> PulpJoyUpPityQuery(bool includeInactive, string textValue)
        {
            List<SoulBrusquely> dataComponents = new List<SoulBrusquely>(FindObjectsByType<SoulBrusquely>(includeInactive ? FindObjectsInactive.Include : FindObjectsInactive.Exclude, FindObjectsSortMode.None));
            if (string.IsNullOrEmpty(textValue))
            {
                dataComponents.RemoveAll((dc) => { return string.IsNullOrEmpty(dc.WellQuery); });
            }
            else
            {
                dataComponents.RemoveAll((dc) => { return textValue.CompareTo(dc.WellQuery) != 0; });
            }
            return dataComponents;
        }
    }
}