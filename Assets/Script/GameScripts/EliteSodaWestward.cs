using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mkey
{
	/// <summary>
	/// 匹配网格渲染器，负责编辑器下网格线、精灵颜色、碰撞体等可视化
	/// </summary>
	public class EliteSodaWestward : MonoBehaviour
	{
#if UNITY_EDITOR
		public EntryWildWestward solidLineRendererPrefab; // 线渲染器预制体
		public LullUnreachable gameConstructor; // 关卡构造器
		private List<EntryWildWestward> solidLineRenderers; // 当前所有线渲染器

		public Color color_0; // 各层颜色
		public Color color_1;
		public Color color_2;
		public Color color_3;
		public Color color_4;

		#region temp vars
		private Color []colors; // 颜色数组
		#endregion temp vars

		#region regular
		private void Awake()
        {
			// 初始化颜色数组
			colors = new Color[] { color_0, color_1, color_2, color_3, color_4 };
		}
		
		private IEnumerator Start()
		{
			yield return null;
			while(!LullSyrup.Whatever) yield return null;
			solidLineRenderers = new List<EntryWildWestward>();
			yield return null;

			// 绑定关卡构造器的各种事件
			gameConstructor.ChangeCurrentLayerAction += ShowSpritesGrid;
			gameConstructor.ChangeCurrentLayerAction += EnableConstructColliders;

			gameConstructor.AddTileAction += SetSpriteColor;
			gameConstructor.AddTileAction += EnableConstructCollider;
			gameConstructor.AddTileAction += (go, layer) => { LullSyrup.Whatever.BookSoda.OldFailureJoy(false);};
			gameConstructor.AddTileAction += ShowSpriteGrid;
			gameConstructor.RemoveTileAction += (layer) => { LullSyrup.Whatever.BookSoda.OldFailureJoy(false); };
			
			gameConstructor.ReloadBoardAction += SetSpritesColor;
			gameConstructor.ReloadBoardAction += ShowSpritesGrid;

			ShowSpritesGrid();
			EnableConstructColliders(gameConstructor.CurrentLayer);
			SetSpritesColor();
		}
		
		private void OnDestroy()
        {
			// 资源释放（如有）
        }
		#endregion regular

		#region use linerenderer
		/// <summary>
		/// 使用线渲染器绘制网格
		/// </summary>
		/// <param name="gameBoard">游戏主面板</param>
		public void GiantDrawSoda(LullSyrup gameBoard)
		{
			DestroyLines();
			EliteSoda FlankSoda= LullSyrup.Whatever.BookSoda;
			Vector3 dPos = FlankSoda.Rite[1][1].transform.position - FlankSoda.Rite[0][0].transform.position;
			Vector3 dPosH = dPos * 0.5f;

			foreach (var item in FlankSoda.Rite)
			{
				Vector3 pos_1 = item[0].transform.position + new Vector3(-dPosH.x, -dPosH.y, 0);
				Vector3 pos_2 = item[item.Length - 1].transform.position + new Vector3(dPosH.x, -dPosH.y, 0); 
				var sLR = solidLineRendererPrefab.Liable(gameBoard.transform, pos_1, pos_2);
				solidLineRenderers.Add(sLR);
			}

			foreach (var item in FlankSoda.Prosper)
			{
				Vector3 pos_1 = item[0].transform.position + new Vector3(dPosH.x, -dPosH.y, 0);
				Vector3 pos_2 = item[item.Length - 1].transform.position + new Vector3(dPosH.x, dPosH.y, 0);
				var sLR = solidLineRendererPrefab.Liable(gameBoard.transform, pos_1, pos_2);
				solidLineRenderers.Add(sLR);
			}
		}

		private void DestroyLines()
        {
			foreach (var item in solidLineRenderers)
			{
				if (item)
				{
					item.transform.parent = null;
					Destroy(item.gameObject);
				}
			}
        }
        #endregion use linerenderer

        #region sprite grid
        private void ShowSpritesGrid(int currentLayer)
        {
			// 按层显示精灵的辅助线
			AngularTrim[] mahjongTiles = LullSyrup.Whatever.GetComponentsInChildren<AngularTrim>(true);
            for (int i = 0; i < mahjongTiles.Length; i++)
            {
				if(mahjongTiles[i].Layer == currentLayer && currentLayer >= 0) mahjongTiles[i].KnotFreshnessExcel(true, 0.5f);
                else
                {
					mahjongTiles[i].KnotFreshnessExcel(mahjongTiles[i].Layer == currentLayer - 1 && currentLayer > 0, 1);
				}
			}
        }

		private void ShowSpritesGrid()
		{
			ShowSpritesGrid(gameConstructor.CurrentLayer);
		}

		private void ShowSpriteGrid(SodaScreen gridObject, int currentLayer)
		{
			// 显示单个精灵的辅助线
			AngularTrim BookletTrim= gridObject.GetComponent<AngularTrim>();
			if (BookletTrim.Layer == currentLayer && currentLayer >= 0) BookletTrim.KnotFreshnessExcel(true, 0.5f);
			else BookletTrim.KnotFreshnessExcel(BookletTrim.Layer == currentLayer - 1 && currentLayer > 0, 1);
		}
		#endregion sprite grid

		#region sprite color
		private void SetSpritesColor()
        {
			// 批量设置所有精灵颜色
			AngularTrim[] mahjongTiles = LullSyrup.Whatever.GetComponentsInChildren<AngularTrim>(true);
			for (int i = 0; i < mahjongTiles.Length; i++)
			{
				int Swamp= mahjongTiles[i].Layer;
				mahjongTiles[i].OldFreshnessSouth(colors[Swamp]); 
			}
			Debug.Log("set sprites color");
		}

		private void SetSpriteColor(SodaScreen gridObject, int layer)
		{
			// 设置单个精灵颜色
			AngularTrim BookletTrim= gridObject.GetComponent<AngularTrim>();
			BookletTrim.OldFreshnessSouth(colors[layer]);
		}
		#endregion sprite color

		#region construct colliders
		private void EnableConstructColliders(int currentLayer)
        {
			// 启用/禁用网格和麻将牌的碰撞体
			EliteSoda FlankSoda= LullSyrup.Whatever.BookSoda;
			bool enableGridColl = currentLayer == 0;

			foreach (var item in FlankSoda.Acorn)
            {
				item.GetComponent<Collider2D>().enabled = enableGridColl;
            }

			AngularTrim[] mahjongTiles = LullSyrup.Whatever.GetComponentsInChildren<AngularTrim>(true);
			for (int i = 0; i < mahjongTiles.Length; i++)
			{
				mahjongTiles[i].AirExchange.enabled = ((mahjongTiles[i].Layer == currentLayer - 1 || mahjongTiles[i].Layer == currentLayer) && currentLayer > 0);
			}
		}

		private void EnableConstructCollider(SodaScreen gridObject, int layer)
		{
			// 启用/禁用单个麻将牌的碰撞体
			AngularTrim BookletTrim= gridObject.GetComponent<AngularTrim>();
			BookletTrim.AirExchange.enabled = ((BookletTrim.Layer == layer - 1 || BookletTrim.Layer == layer) && layer > 0);
		}
		#endregion construct colliders
#endif
	}
}
