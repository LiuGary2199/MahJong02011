using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mkey
{
	public class ReactSeaman : MonoBehaviour
	{
[UnityEngine.Serialization.FormerlySerializedAs("buttonImage")]		public Image MakeupReady;
[UnityEngine.Serialization.FormerlySerializedAs("button")]		public Button Makeup;
[UnityEngine.Serialization.FormerlySerializedAs("checkedSprite")]		public Sprite DrasticCorpse;
[UnityEngine.Serialization.FormerlySerializedAs("themeName")]		public Text NeedyOver;
[UnityEngine.Serialization.FormerlySerializedAs("iconsParent")]		public RectTransform StageWeaver;
[UnityEngine.Serialization.FormerlySerializedAs("iconPrefab")]		public Image WeftDismal;
[UnityEngine.Serialization.FormerlySerializedAs("index")]		public int Rough= 0;
[UnityEngine.Serialization.FormerlySerializedAs("iconsCount")]		public int StagePulse= 5;


		#region temp vars
		private Sprite PartnerCorpse;
		#endregion temp vars

		#region regular
		private void Start()
		{
			
		}

		private void OnDestroy()
        {
			
        }
		#endregion regular

		public void LiableReactSloth(ReactBroadlyMisery theme)
        {
			Image[] images = StageWeaver.GetComponentsInChildren<Image>();
			foreach (var item in images)
			{
				item.rectTransform.parent = null;
				DestroyImmediate(item.gameObject);
			}

			List<Sprite> sprites = theme.HowInstigateBroadly();

			for (int i = 0; i < StagePulse; i++)
			{
				Image im = Instantiate(WeftDismal, StageWeaver);
				im.sprite = sprites[i];
			}
			if(NeedyOver) NeedyOver.text = theme.NeedyOver;
		}

		public void BrandSeaman(bool check)
		{
			if (PartnerCorpse == null) PartnerCorpse = MakeupReady.sprite;
			MakeupReady.sprite = (check) ? DrasticCorpse : PartnerCorpse;
		}
	}
}
