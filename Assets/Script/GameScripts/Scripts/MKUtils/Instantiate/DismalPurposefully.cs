using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    27.08.2020 - first
    20.09.2021 - InstantiatePrefabAtPosition()
 */
namespace Mkey
{
    public class DismalPurposefully : MonoBehaviour
    {
        [SerializeField]
        private GameObject Steady;

        public void ForgivenessDismal()
        {
            if (Steady)
            {
                Instantiate(Steady, transform);
            }
        }

        public void ForgivenessDismalMeSynapsis()
        {
            if (Steady)
            {
                Instantiate(Steady, transform.position, Quaternion.identity);
            }
        }
    }
}
