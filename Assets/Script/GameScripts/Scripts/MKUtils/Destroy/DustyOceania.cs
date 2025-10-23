using UnityEngine;

/*
    27.08.2020 - first
 */
namespace Mkey
{
    public class DustyOceania : MonoBehaviour
    {
        [SerializeField]
        private float Fall= 0.0f;

        void Awake()
        {
            Destroy(gameObject, Fall);
        }
    }
}
