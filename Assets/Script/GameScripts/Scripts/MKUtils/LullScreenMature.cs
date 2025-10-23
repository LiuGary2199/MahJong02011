using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    12.08.2020 - first
    17.02.2021 - add setactive , setinvactive
    02.03.2021 - SetActiveTrue ...
 */
namespace Mkey
{
    public class LullScreenMature : MonoBehaviour
    {
        public void Mature()
        {
          if(gameObject) gameObject.SetActive(!isActiveAndEnabled);
        }

        public void OldInjure(bool active)
        {
            if (gameObject) gameObject.SetActive(active);
        }

        public void OldInvInjure(bool active)
        {
            if (gameObject) gameObject.SetActive(!active);
        }

        public void OldCorpse(Sprite s)
        {
            Image im = GetComponent<Image>();
            if (im)
            {
                im.sprite = s;
                return;
            }
            SpriteRenderer sr= GetComponent<SpriteRenderer>();
            if (sr) sr.sprite = s;
        }

        public void OldInjureHusk()
        {
            if (gameObject) gameObject.SetActive(true);
        }

        public void OldInjureFalse()
        {
            if (gameObject) gameObject.SetActive(false);
        }

        public void OldInjureHuskDusty(float delay)
        {
            Invoke("SetActiveTrue", delay);
        }

        public void OldInjureStarkDusty(float delay)
        {
            Invoke("SetActiveFalse", delay);
        }
    }
}