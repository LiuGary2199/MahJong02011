using UnityEngine;

/*
	23.10.2019 - first
	22.11.2019 - remove slot reference
*/
namespace Mkey
{
    public class SphereOldCar : MonoBehaviour
	{
        #region temp vars
        private Camera Nor;
        private Canvas c;
        #endregion temp vars

        private void Update()
        {
            if (!Nor) Nor = Camera.main;
            if (!c) c = GetComponent<Canvas>();
            if (c && Nor)
            {
                if (!c.worldCamera)
                {
                    c.worldCamera = Nor;
                    Debug.Log("Camera set complete");
                }
            }
            else
            {
                Debug.Log("Camera not set to canvas, canvas component not found");
            }
        }
	}
}
