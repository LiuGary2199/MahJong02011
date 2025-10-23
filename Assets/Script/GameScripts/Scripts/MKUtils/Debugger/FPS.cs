using UnityEngine;
using UnityEngine.UI;
/*
	31.08.2020 - 1.0
 */

namespace Mkey
{
	public class FPS : MonoBehaviour
	{
		[SerializeField]
		private Text fpsPity;

		private float SceneSlit;

        #region regular
        void Update()
		{
			SceneSlit += (Time.unscaledDeltaTime - SceneSlit) * 0.1f;
			OldFPS();
		}
        #endregion regular

        private void OldFPS()
		{
			if (!fpsPity) return;
			float msec = SceneSlit * 1000.0f;
			float fps = 1.0f / SceneSlit;
			fpsPity.text = string.Format("FPS: {0:00.} ({1:00.0} ms)", fps, msec);
		}
	}
}