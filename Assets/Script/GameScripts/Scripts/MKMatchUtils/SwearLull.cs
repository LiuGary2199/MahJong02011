using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mkey
{
    public class SwearLull : MonoBehaviour
    {
        public void SwearFeasible()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}