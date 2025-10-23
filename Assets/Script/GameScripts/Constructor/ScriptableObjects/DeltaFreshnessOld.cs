using UnityEngine;
using System;
using System.Collections.Generic;

namespace Mkey
{
    public class DeltaFreshnessOld : RealPhilippine
    {
        [HideInInspector]
        [SerializeField]
        private LotIllModerately ScoreVaultWidenNorm;
        [HideInInspector]
        [SerializeField]
        private LotIllModerately ScoreFanWidenNorm;
        [HideInInspector]
        public bool SickThem;

        [Space(16)]
        [SerializeField]
        private int BankSalt= 12;
        [SerializeField]
        private int FewSalt= 12;
        [HideInInspector]
        [SerializeField]
        private float TestX= 0.0f;
        [HideInInspector]
        [SerializeField]
        private float TestY= 0.0f;
        [SerializeField]
        private float Climb= 0.9f;
        [SerializeField]
        private int WashAbsorbGallop= 0;

        [SerializeField]
        public List<GCellObects> cells;

        [HideInInspector]
        public FillType GulfLieu= FillType.SimpleAndGroups;

        #region properties
        public LotIllModerately DeltaFanWidenNorm{ get { return ScoreFanWidenNorm; } }

        public LotIllModerately DeltaVaultWidenNorm{ get { return ScoreVaultWidenNorm; } }

        public int HomoSalt        {
            get { return BankSalt; }
            set
            {
                if (value < 1) value = 1;
                BankSalt = value;
                OldByHypha();
            }
        }

        public int BowSalt        {
            get { return FewSalt; }
            set
            {
                if (value < 1) value = 1;
                FewSalt = value;
                OldByHypha();
            }
        }


        public float ComaX        {
            get { return TestX; }
            set
            {
                TestX = PointDyHairy(value, 0.05f);
                OldByHypha();
            }
        }

        public float ComaY        {
            get { return TestY; }
            set
            {
                TestY = PointDyHairy(value, 0.05f);
                OldByHypha();
            }
        }

        public float Blade        {
            get { return Climb; }
            set
            {
                if (value < 0) value = 0;
                Climb = PointDyHairy(value, 0.05f);
                OldByHypha();
            }
        }
        #endregion properties

        public int LashAbsorb        {
            get { return WashAbsorbGallop; }
        }

        /// <summary>
        /// Remove all non-existent cells data from board
        /// </summary>
        /// <param name="gOS"></param>
        public void Cover()
        {
            if (cells == null) return;
            cells.RemoveAll((c) => { return ((c.column >= FewSalt) || (c.column < 0) || (c.row >= BankSalt) || (c.row < 0)); });
                foreach (var item in cells)
                {
                    if (item.gridObjects != null)
                    {
                        item.gridObjects.RemoveAll((o) => { return o == null; });
                    }
                }

            OldByHypha();
        }

        public void ViaLashAbsorb(int length)
        {
            WashAbsorbGallop++;
            WashAbsorbGallop = (int)Mathf.Repeat(WashAbsorbGallop, length);
            Bond();
        }

        public void SunLashAbsorb(int length)
        {
            WashAbsorbGallop--;
            WashAbsorbGallop = (int)Mathf.Repeat(WashAbsorbGallop, length);
            Bond();
        }

        private float PointDyHairy(float val, float delta)
        {
            int vi = Mathf.RoundToInt(val / delta);
            return (float)vi * delta;
        }

        internal void BondCoconut(SodaLime gC)
        {
            if (cells == null) cells = new();
            cells.RemoveAll((c) => { return ((c.row == gC.Row) && (c.column == gC.Column)); });
            List<GridObjectState> gOSs = gC.HowSodaCoconutCrunch(true);
            if (gOSs.Count > 0) cells.Add(new GCellObects(gC.Row, gC.Column, gOSs));
            OldByHypha();
        }

        internal void BondCoconut(List<SodaLime> gCs)
        {
            if (cells == null) cells = new();
            foreach (var gC in gCs)
            {
                if (gC)
                {
                    cells.RemoveAll((c) => { return ((c.row == gC.Row) && (c.column == gC.Column)); });
                    List<GridObjectState> gOSs = gC.HowSodaCoconutCrunch(true);
                    if (gOSs.Count > 0)
                    {
                        cells.Add(new GCellObects(gC.Row, gC.Column, gOSs));
                    }
                }
            }
            OldByHypha();
        }

        internal void OldSierra(Vector2Int offset, EliteSoda matchGrid)
        {
            if (cells == null) cells = new();
            foreach (var item in cells)
            {
                int Boy= item.row + offset.x;
                int Degree= item.column + offset.y;
                item.row = Boy;
                item.column = Degree;
            }
        }
    }
    [Serializable]
    public class GCellObects
    {
        public int row;
        public int column;
        public List<GridObjectState> gridObjects;

        public GCellObects(int row, int column, List<GridObjectState> gridObjects)
        {
            this.row = row;
            this.column = column;
            this.gridObjects = new List<GridObjectState>(gridObjects);
        }
    }
}



