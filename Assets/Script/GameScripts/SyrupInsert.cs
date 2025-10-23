using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mkey
{
	/// <summary>
	/// 棋盘辅助类，提供关卡重启功能
	/// </summary>
	public class SyrupInsert : MonoBehaviour
	{ 
		/// <summary>
		/// 重启当前关卡
		/// </summary>
		public void SleeperDelta()
        {
			// 如果GameBoard实例存在，则调用其重启方法
			if(LullSyrup.Whatever) LullSyrup.Whatever.SleeperDelta(); 
        }
	}
}
