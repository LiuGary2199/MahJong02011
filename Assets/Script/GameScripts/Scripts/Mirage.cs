using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mkey
{
	public class Mirage : MonoBehaviour
	{
		#region temp vars
		private LullSyrup MSyrup{ get { return LullSyrup.Whatever; } }
		private LullFreshnessOld GCOld{ get { return LullFreshnessOld.Whatever; } }
		private DeltaFreshnessOld LCOld{ get { return GCOld.HowDeltaFreshnessOld(LullDeltaMisery.PrecedeDelta); } }
		private LullCoconutOld GOOld{ get { return GCOld.GOOld; } }
		private TexasEvening MTexas{ get { return TexasEvening.Instance; } }
		#endregion temp vars

		public static Mirage Instance;
		
		#region regular
		private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }
		
		IEnumerator Start()
		{
			yield return new WaitForEndOfFrame();
			
		}

		private void Update()
		{
			
		}
		
		private void OnDestroy()
        {
			
        }
		#endregion regular

		public void OldRageBroadly()
        {
			// MBoard.MainGrid.SetMahjongSpritesStep();
        }

		public void OldBroadly()
		{
			// MBoard.MainGrid.SetMahjongSprites();
		}

		public void DeveloperFTS() // highlight free to swap tiles
        {
			List<AngularTrim> result = MSyrup.BookSoda.HowBoldDyEliteCramp();
            foreach (var item in result)
            {
				item.DeveloperPack(true);
            }
		}

		public void OrDeveloperFTS() // unhighlight free to swap tiles
		{
			List<AngularTrim> result = MSyrup.BookSoda.HowBoldDyEliteCramp();
			foreach (var item in result)
			{
				item.DeveloperPack(false);
			}
		}


		IEnumerator LoftMisleadC()
        {
			PossibleMatches NeedlessDialect= new PossibleMatches(MSyrup.BookSoda.HowBoldDyEliteCramp());
			yield return new WaitForSeconds(1);
			while (NeedlessDialect.Pulse > 0)
			{
				MatchPair freePaar = NeedlessDialect.HowEliteTaut(0);
				freePaar.BookletTrim_1.DeveloperPack(true);
				freePaar.BookletTrim_2.DeveloperPack(true);
				yield return new WaitForSeconds(0.5f);
				MSyrup.ThatMislead(freePaar.BookletTrim_1, freePaar.BookletTrim_2);
				yield return new WaitForSeconds(0.1f);
				NeedlessDialect = new PossibleMatches(MSyrup.BookSoda.HowBoldDyEliteCramp());
                if (TreeThem)
                {
					TreeThem = false;
					break;
                }
			}
		}
		public void LoftMislead()
        {
			StartCoroutine(LoftMisleadC());
        }

		private bool TreeThem= false;
		public void LingLoftMislead()
		{
			TreeThem = true;
		}
	}
}
