using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mkey
{
	public class SignificancePU : LotIllModerately
	{
        [SerializeField]
        private RectTransform ExcelWeaver;
        [SerializeField]
        private GameObject ShelveThem;
        private List<SignificanceWild> MultiplicityExcel;

        #region temp vars

        #endregion temp vars


        #region regular
        public override void TractorPurely()
        {
            LiableLatterCud();
            base.TractorPurely();
        }

        private void LiableLatterCud()
        {
            SignificanceWild[] sT= ExcelWeaver.GetComponentsInChildren<SignificanceWild>();
            foreach (var item in sT)
            {
                DestroyImmediate(item.gameObject);
            }

            AchievementsModerately p = AchievementsModerately.Instance;
            if (p == null) return;

            List<Conspicuous> products = p.Multiplicity;

            MultiplicityExcel = new List<SignificanceWild>();
            foreach (var item in products)
            {
                if (item)
                {
                    SignificanceWild aL = item.LiableRatWild(ExcelWeaver);
                    if (aL) { MultiplicityExcel.Add(aL);  aL.HowThirdEndear += DodgePurely; }
                };
            }

            if (ShelveThem) ShelveThem.SetActive(MultiplicityExcel.Count > 5);
        }
        #endregion regular
    }
}
