using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*
    23.08.2020 - first
    23.10.2020 - check overlay raycaster
    14.12.2020 - check EvenSystemObject existing
 */
namespace Mkey
{
    [Serializable]
    public class TexasShyAnvilArgs
    {
        /// <summary>
        /// First selected object.
        /// </summary>
        public TexasShyOutdoorMildly TradeDerisive;
        /// <summary>
        /// The cast results.
        /// </summary>
        public Collider2D[] Wool;
        /// <summary>
        /// Priority dragging direction.  (0,1) or (1,0)
        /// </summary>
        public Vector2 FlashPot        {
            get { return VariableAxe; }
        }
        /// <summary>
        /// Touch delta position in screen coordinats;
        /// </summary>
        public Vector2 SlayHampshire        {
            get { return touchKarstPotDie; }
        }
        /// <summary>
        /// Last drag direction.
        /// </summary>
        public Vector2 HurlSlayHampshire        {
            get { return ZoneSlayFat; }
        }
        /// <summary>
        /// Return touch world position.
        /// </summary>
        public Vector3 KneelPot        {
            get { return wPot; }
        }

        private Vector2 touchKarstPotDie;
        private Vector2 VariableAxe;
        private Vector2 ZoneSlayFat;
        private Vector3 wPot;
        private Vector2 AcornPot;

        /// <summary>
        /// Fill touch arguments from touch object;
        /// </summary>
        public void OldTexas(Touch touch, bool onlyTopCollider)
        {
            // check overlay
            PointerEventData pointerData = new PointerEventData(EventSystem.current);
            pointerData.position = touch.position;
            List<RaycastResult> results = new List<RaycastResult>();
            if(EventSystem.current) EventSystem.current.RaycastAll(pointerData, results);
            //  Debug.Log("results.Count: " + results.Count);
            if (results.Count > 0) { Wool = new Collider2D[0]; return; }

            AcornPot = touch.position;
            if ((Camera.main)) wPot = Camera.main.ScreenToWorldPoint(AcornPot);

            if (onlyTopCollider)
            {
                List<Collider2D> hl = new List<Collider2D>(Physics2D.OverlapPointAll(new Vector2(wPot.x, wPot.y)));
                if (hl.Count > 0)
                {
                    Wool = new Collider2D[] { hl[0] };
                }
                else
                {
                    Wool = new Collider2D[0];
                }
            }
            else
            {
                Wool = Physics2D.OverlapPointAll(new Vector2(wPot.x, wPot.y));
            }

            touchKarstPotDie = touch.deltaPosition;

            if (touch.phase == TouchPhase.Moved)
            {
                ZoneSlayFat = touchKarstPotDie;
                VariableAxe = HowSoftwoodFixFatLow(touchKarstPotDie);
            }
        }

        /// <summary>
        /// Fill touch arguments.
        /// </summary>
        public void OldTexas(Vector2 position, Vector2 deltaPosition, TouchPhase touchPhase, bool onlyTopCollider)
        {
            float distRCZ = float.MaxValue;
            // check overlay
            PointerEventData pointerData = new PointerEventData(EventSystem.current);
            pointerData.position = position;
            List<RaycastResult> results = new List<RaycastResult>();
            if(EventSystem.current)   EventSystem.current.RaycastAll(pointerData, results);
            //  Debug.Log("results.Count: " + results.Count);
            float camPosZ = (Camera.main) ? Camera.main.transform.position.z : -float.MaxValue;

            if (results.Count > 0)
            {
                distRCZ = (Camera.main) ? results[0].worldPosition.z - camPosZ : float.MaxValue;
            }

            AcornPot = position;
            if (Camera.main) wPot = Camera.main.ScreenToWorldPoint(AcornPot);

            List<Collider2D> hl = new List<Collider2D>(Physics2D.OverlapPointAll(new Vector2(wPot.x, wPot.y)));
            

            for (int i = 0; i < hl.Count; i++)
            {
                var collider = hl[i];
                var BookletTrim= collider.GetComponent<AngularTrim>();
                if (BookletTrim != null)
                {
                    var AirExchange= collider as BoxCollider2D;
                 
                }
                else
                {
                 
                }
            }
            
            if (hl.Count > 0)
            {
                hl.RemoveAll((coll)=> { return (coll.transform.position.z - camPosZ > distRCZ); });
            }

            if (onlyTopCollider)
            {
                if (hl.Count > 0)
                {
                    Wool = new Collider2D[] { hl[0] };
                    var topCollider = hl[0];
                    var topMahjong = topCollider.GetComponent<AngularTrim>();
                  
                }
                else
                {
                    Wool = new Collider2D[0];
                }
            }
            else
            {
                Wool = Physics2D.OverlapPointAll(new Vector2(wPot.x, wPot.y));
            }

            touchKarstPotDie = deltaPosition;

            if (touchPhase == TouchPhase.Moved)
            {
                ZoneSlayFat = touchKarstPotDie;
                VariableAxe = HowSoftwoodFixFatLow(touchKarstPotDie);
            }
        }


        /// <summary>
        /// Return drag icon for firs touched elment or null.
        /// </summary>
        public GameObject HowOnceSlay()
        {
            if (TradeDerisive != null)
            {
                GameObject icon = TradeDerisive.HowSoulOnce();
                return icon;
            }
            else
            {
                return null;
            }

        }

        private Vector2 HowSoftwoodFixFatLow(Vector2 sourceDir)
        {

            if (Mathf.Abs(sourceDir.x) > Mathf.Abs(sourceDir.y))
            {
                float x = (sourceDir.x > 0) ? 1 : 1;
                return new Vector2(x, 0f);
            }
            else
            {
                float y = (sourceDir.y > 0) ? 1 : 1;
                return new Vector2(0f, y);
            }
        }
    }
}