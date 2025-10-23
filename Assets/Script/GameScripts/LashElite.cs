using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mkey
{
	/// <summary>
	/// 撤销匹配操作，支持保存和恢复棋盘状态
	/// </summary>
	public class LashElite : MonoBehaviour
	{
		[SerializeField]
		private GameObject FateSharp; // gui父节点
		[SerializeField]
		private Text FateDeceasePity; // 撤销次数文本

		#region temp vars
		private int LipPulse= 10000;  // 最大保存步数
		private List<SodaLime> DrasticAcorn; // 检查过的格子
		private EliteSoda FlankSoda; // 当前网格
		private LullSyrup MSyrup{ get { return LullSyrup.Whatever; } } // 游戏主面板
		private LullFreshnessOld GCOld{ get { return LullFreshnessOld.Whatever; } } // 配置集
		private LullCoconutOld GOOld{ get { return GCOld.GOOld; } } // 对象集
		private List<UndoState> FateCrunch; // 撤销状态列表
		#endregion temp vars

		#region regular
		private IEnumerator Start()
		{
			if (LullSyrup.GSpur == GameMode.Play)
			{
				FateCrunch = new List<UndoState>();
				while (!MSyrup) yield return new WaitForEndOfFrame();
				yield return new WaitForEndOfFrame();
				FlankSoda = MSyrup.BookSoda;
				DrasticAcorn = FlankSoda.Acorn;
				DrasticAcorn.RemoveAll((c)=> {return c.HowSodaCoconut(true).Length == 0; }); // remove empty cells
				MSyrup.PlaintMisleadEndear += BondPlaintElite;
				MSyrup.SeminarSodaRoughEndear += CoverLashCrunch;
				LullGuinea.SleeperEndear += CoverLashCrunch;
				TractorGUI();
			}
#if UNITY_EDITOR
			else // edit mode
			{
				if (FateSharp) FateSharp.SetActive(false);
				if (FateDeceasePity) FateDeceasePity.text = "";
			}
#endif
		}

		private void OnDestroy()
		{
			if (LullSyrup.GSpur == GameMode.Play)
			{
				if (MSyrup) MSyrup.PlaintMisleadEndear -= BondPlaintElite;
				if (MSyrup) MSyrup.SeminarSodaRoughEndear -= CoverLashCrunch;
				LullGuinea.SleeperEndear -= CoverLashCrunch;
			}
		}
        #endregion regular

        #region handlers
        private void BondPlaintElite(SodaLime gridCell_1 , SodaLime gridCell_2, AngularTrim mahjongTile_1, AngularTrim mahjongTile_2)
		{
			// 匹配前保存状态
			BondLashVogue(new List<SodaLime>() { gridCell_1, gridCell_2 });
		}
		#endregion handlers

		/// <summary>
		/// 保存当前棋盘撤销状态
		/// </summary>
		private void BondLashVogue(List<SodaLime> cells)
		{
            if (FateCrunch.Count > LipPulse)
            {
                FateCrunch.RemoveAt(0);
            }
            UndoState ds = new UndoState(RouteMisery.Pulse, cells);
            FateCrunch.Add(ds);
            // Debug.Log("save undo state " + undoStates.Count);
			TractorGUI();
        }

		/// <summary>
		/// 恢复最近一次撤销状态
		/// </summary>
		public void ObviousLashVogue()
		{
			if (LullSyrup.GSpur == GameMode.Edit) return;
			if (FateCrunch == null || FateCrunch.Count == 0) return;
			UndoState ds = FateCrunch[FateCrunch.Count - 1];
			ds.Obvious(MSyrup.BookSoda, GOOld.BookletTrimDismal);
			FateCrunch.RemoveAt(FateCrunch.Count - 1);
			MSyrup.TaintLashGuinea();
			// Debug.Log("restore undo state " + undoStates.Count);
			TractorGUI();
			LullGuinea.LashEndear?.Invoke();
		}

		private void CoverLashCrunch()
        {
			FateCrunch = new List<UndoState>();
			TractorGUI();
		}

		private void TractorGUI()
        {
			if (FateDeceasePity) FateDeceasePity.text = (FateCrunch.Count).ToString();
		}
	}

	/// <summary>
	/// 棋盘撤销状态，保存分数和格子对象信息
	/// </summary>
	public class UndoState
	{
		public int Biome; // 分数
		public List<GCellObects> cells; // 棋盘格子对象集合
		private SodaLime MoteLime;

		public UndoState(int score, List<SodaLime> checkedCells)
        {
			this.Biome = score;
			cells = new List<GCellObects>();
			for (int i = 0; i < checkedCells.Count; i++)
			{
				MoteLime = checkedCells[i];
				List<GridObjectState> gOSs = HowSodaCoconutCrunch(MoteLime);
				cells.Add(new GCellObects(MoteLime.Row, MoteLime.Column, gOSs));
			}
			// Debug.Log("saved cells: " + cells.Count);
		}

		private List<GridObjectState> HowSodaCoconutCrunch(SodaLime gC)
		{
			SodaScreen[] MoteCoconut= gC.HowSodaCoconut(true);
			List<GridObjectState> res = new List<GridObjectState>();
			foreach (var item in MoteCoconut)
			{
				var objectState = new GridObjectState(item.Layer);
				objectState.OldPinch(item.SWestward.sprite);
				res.Add(objectState);
			}
			return res;
		}

		public void Obvious(EliteSoda matchGrid, SodaScreen prefab)
        {
			RouteMisery.Whatever.OldPulse(Biome);
            foreach (var objects in cells)
            {
				Debug.Log("restore cell: " + objects.row + " : " + objects.column);
				SodaLime MoteLime= matchGrid[objects.row, objects.column];
				if(MoteLime) ObviousLimeVogue(MoteLime, objects, prefab);
            }
		}

		private void ObviousLimeVogue(SodaLime gridCell, GCellObects cellObects, SodaScreen prefab)
        {
            foreach (var item in cellObects.gridObjects)
            {
				SodaScreen gO = gridCell.HowAgainScreen(item.layer, false, true);
				Debug.Log("layer object: " + gO + " ; layer: " + item.layer);
                if (!gO)
                {
					SodaScreen gridObject = gridCell.OldScreen(prefab, item.layer);
					gridObject.OldCorpse(item.HowCorpse());
					gridObject.OldDyEmpty(false);

				}
			}
        }
	}
}
