using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Mkey
{
    public class BoardDollarProposal : MonoBehaviour
    {
[UnityEngine.Serialization.FormerlySerializedAs("show")]        public static bool Dull= true;

        [SerializeField]
        private GameObject[] Botany;

        // Start is called before the first frame update
        void Start()
        {
            if (Botany != null)
            {
                foreach (var item in Botany)
                {
                    item.SetActive(Dull);
                }
            }
        }

        public void VaultThird()
        {
            foreach (var item in GetComponentsInChildren<Button>())
            {
                item.interactable = false;
            }
            RatHatch_v2 gF = GetComponent<RatHatch_v2>();
            if (!gF) return;
            gF.BankIts(0, ()=> { Dull = false; });
        }
    }
}