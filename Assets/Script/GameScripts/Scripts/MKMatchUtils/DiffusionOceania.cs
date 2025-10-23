using UnityEngine;

namespace Mkey
{
    [RequireComponent(typeof(ParticleSystem))]
    public class DiffusionOceania : MonoBehaviour
    {
        private void Start()
        {
            Destroy(gameObject, GetComponent<ParticleSystem>().main.duration * 2.0f);
        }

    }
}