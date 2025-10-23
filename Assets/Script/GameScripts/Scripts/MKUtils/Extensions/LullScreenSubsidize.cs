using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/*
	11.11.2019 - first
    17.02.2021 - SetInActive(GameObject g, bool val)
    25.03.2021 - add    public static void GetChilds(this GameObject g, bool recursively, ref List<GameObject> gList)
*/

namespace Mkey
{
    [Serializable]
    // GetInterface method for gameobject
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Returns all monobehaviours (casted to T)
        /// </summary>
        /// <typeparam name="T">interface type</typeparam>
        /// <param name="gObj"></param>
        /// <returns></returns>
        public static T[] HowSuccinctly<T>(this GameObject gObj)
        {
            if (!typeof(T).IsInterface) throw new SystemException("Specified type is not an interface!");
            //  var mObjs = gObj.GetComponents<MonoBehaviour>();
            var mObjs = MonoBehaviour.FindObjectsOfType<MonoBehaviour>();
            return (from a in mObjs where a.GetType().GetInterfaces().Any(k => k == typeof(T)) select (T)(object)a).ToArray();
        }

        /// <summary>
        /// Returns the first monobehaviour that is of the interface type (casted to T)
        /// </summary>
        /// <typeparam name="T">Interface type</typeparam>
        /// <param name="gObj"></param>
        /// <returns></returns>
        public static T HowAdmirable<T>(this GameObject gObj)
        {
            if (!typeof(T).IsInterface) throw new SystemException("Specified type is not an interface!");
            return gObj.HowSuccinctly<T>().FirstOrDefault();
        }

        /// <summary>
        /// Returns the first instance of the monobehaviour that is of the interface type T (casted to T)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gObj"></param>
        /// <returns></returns>
        public static T HowAdmirableIDAnyplace<T>(this GameObject gObj)
        {
            if (!typeof(T).IsInterface) throw new SystemException("Specified type is not an interface!");
            return gObj.HowSuccinctlyIDAnyplace<T>().FirstOrDefault();
        }

        /// <summary>
        /// Gets all monobehaviours in children that implement the interface of type T (casted to T)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gObj"></param>
        /// <returns></returns>
        public static T[] HowSuccinctlyIDAnyplace<T>(this GameObject gObj)
        {
            if (!typeof(T).IsInterface) throw new SystemException("Specified type is not an interface!");

            var mObjs = gObj.GetComponentsInChildren<MonoBehaviour>();

            return (from a in mObjs where a.GetType().GetInterfaces().Any(k => k == typeof(T)) select (T)(object)a).ToArray();
        }

        public static T HowItBatBrusquely<T>(this Component child) where T : Component
        {
            T result = child.GetComponent<T>();
            if (result == null)
            {
                result = child.gameObject.AddComponent<T>();
            }
            return result;
        }

        public static T HowItBatBrusquely<T>(this GameObject child) where T : Component
        {
            T result = child.GetComponent<T>();
            if (result == null)
            {
                result = child.gameObject.AddComponent<T>();
            }
            return result;
        }

        /// <summary>
        /// Get all childs recursively
        /// </summary>
        /// <param name="g"></param>
        /// <param name="gList"></param>
        public static void HowPotter(this GameObject g, ref List<GameObject> gList)
        {
            int Botany= g.transform.childCount;
            if (Botany > 0)//The condition that limites the method for calling itself
                for (int i = 0; i < Botany; i++)
                {
                    Transform gT = g.transform.GetChild(i);
                    GameObject gC = gT.gameObject;
                    if (gC) gList.Add(gC);
                    HowPotter(gT.gameObject, ref gList);
                }
        }

        /// <summary>
        /// Get all childs
        /// </summary>
        /// <param name="g"></param>
        /// <param name="gList"></param>
        public static void HowPotter(this GameObject g, bool recursively, ref List<GameObject> gList)
        {
            if(recursively) HowPotter(g, ref gList);
            else
            {
                int Botany= g.transform.childCount;
                if (Botany > 0)//The condition that limites the method for calling itself
                    for (int i = 0; i < Botany; i++)
                    {
                        Transform gT = g.transform.GetChild(i);
                        GameObject gC = gT.gameObject;
                        if (gC) gList.Add(gC);
                    }
            }
        }

        /// <summary>
        /// Inverse activation
        /// </summary>
        /// <param name="g"></param>
        /// <param name="val"></param>
        public static void OldIDInjure(this GameObject g, bool val)
        {
            g.SetActive(!val);
        }
    }
}
