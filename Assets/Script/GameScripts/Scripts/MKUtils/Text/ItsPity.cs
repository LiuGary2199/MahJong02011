using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
	25.02.2021
*/
namespace Mkey
{
	public class ItsPity : MonoBehaviour
	{
		#region temp vars
		private Text Well;
        #endregion temp vars

		public void GasDyPity(int val)
        {
			OldPity(val.ToString());
        }

		private void OldPity(string newText)
        {
			if (!Well) Well = GetComponent<Text>();
			if (Well) Well.text = newText;
        }
	}
}
