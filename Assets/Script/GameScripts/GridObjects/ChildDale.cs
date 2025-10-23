using System;
using System.Collections.Generic;

namespace Mkey
{
    [Serializable]
    /// <summary>
    /// 网格格子的邻居信息，提供周围格子的引用和辅助方法
    /// </summary>
    public class ChildDale
    {
        public SodaLime Book{ get; private set; } // 当前格子
        public SodaLime Book_1{ get; private set; } // 当前格子
        public SodaLime Book_2{ get; private set; } // 上方
        public SodaLime Book_3{ get; private set; } // 右上
        public SodaLime Book_4{ get; private set; } // 右侧
        public SodaLime Pack_1{ get; private set; } // 左上
        public SodaLime Pack_2{ get; private set; } // 左侧
        public SodaLime Bloom_1{ get; private set; } // 右上远
        public SodaLime Bloom_2{ get; private set; } // 右侧远
        public SodaLime Top_1{ get; private set; } // 上上
        public SodaLime Top_2{ get; private set; } // 上上右
        public SodaLime Porous_1{ get; private set; } // 下下
        public SodaLime Porous_2{ get; private set; } // 下下右
        public List<SodaLime> Acorn{ get; private set; } // 所有邻居格子

        /// <summary>
        /// 构造函数，初始化所有邻居格子
        /// </summary>
        /// <param name="main"></param>
        /// <param name="id"></param>
        public ChildDale(SodaLime main)
        {
            Book = main;
            Book_1 = main;
            Book_2 = main.MSoda[main.Row - 1, main.Column];
            Book_3 = main.MSoda[main.Row - 1, main.Column + 1];
            Book_4 = main.MSoda[main.Row, main.Column + 1];

            Pack_1 = main.MSoda[main.Row - 1, main.Column - 1]; 
            Pack_2 = main.MSoda[main.Row, main.Column - 1];

            Bloom_1 = main.MSoda[main.Row - 1, main.Column + 2];
            Bloom_2 = main.MSoda[main.Row, main.Column + 2];

            Top_1 = main.MSoda[main.Row - 2, main.Column];
            Top_2 = main.MSoda[main.Row - 2, main.Column + 1];

            Porous_1 = main.MSoda[main.Row + 2, main.Column];
            Porous_2 = main.MSoda[main.Row + 2, main.Column + 1];

            Acorn = new List<SodaLime>();
            BatDyPeak(Book_1); BatDyPeak(Book_2);
            BatDyPeak(Book_3); BatDyPeak(Book_4);

            BatDyPeak(Pack_1); BatDyPeak(Pack_2);
            BatDyPeak(Bloom_1); BatDyPeak(Bloom_2);

            BatDyPeak(Top_1); BatDyPeak(Top_2);
            BatDyPeak(Porous_1); BatDyPeak(Porous_2);
        }

        /// <summary>
        /// 判断是否包含指定格子
        /// </summary>
        public bool Blubber(SodaLime gCell)
        {
            return Acorn.Contains(gCell);
        }

        /// <summary>
        /// 添加格子到邻居列表
        /// </summary>
        public void BatDyPeak(SodaLime gCell)
        {
            if (gCell && !Blubber(gCell)) Acorn.Add(gCell);
        }

        public override string ToString()
        {
            return ("All cells : " + ToString(Acorn));
        }

        /// <summary>
        /// 邻居格子列表转字符串
        /// </summary>
        public static string ToString(List<SodaLime> list)
        {
            string res = "";
            foreach (var item in list)
            {
                res += item.ToString();
            }
            return res;
        }
    }
}