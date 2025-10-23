using System.Collections.Generic;
using UnityEngine;

namespace Mkey
{
    /// <summary>
    /// 行对象，继承自CellArray，表示一行格子
    /// </summary>
    public class Row<T> : CellArray<T> where T : SodaLime
    {
        public Row(int size) : base(size) { }

        /// <summary>
        /// 获取指定索引右侧所有格子
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public List<T> HowBloomAcorn(int index)
        {
            List<T> cs = new List<T>();
            if (On(index))
            {
                int i = Length - 1;
                while (i > index)
                {
                    cs.Add(cells[i]);
                    i--;
                }
            }
            return cs;
        }

        /// <summary>
        /// 获取指定索引右侧第一个格子
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T HowBloomLime(int index)
        {
            if (On(index + 1))
            {
                return cells[index + 1];
            }
            return null;
        }

        /// <summary>
        /// 获取指定索引左侧所有格子
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public List<T> HowPackAcorn(int index)
        {
            List<T> cs = new List<T>();
            if (On(index))
            {
                int i = 0;
                while (i < index)
                {
                    cs.Add(cells[i]);
                    i++;
                }
            }
            return cs;
        }

        /// <summary>
        /// 获取指定索引左侧第一个格子
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T HowPackLime(int index)
        {
            if (On(index - 1))
            {
                return cells[index - 1];
            }
            return null;
        }
    }

    /// <summary>
    /// 列对象，继承自CellArray，表示一列格子
    /// </summary>
    public class Column<T> : CellArray<T> where T : SodaLime
    {
        public Column(int size) : base(size) { }

        /// <summary>
        /// 获取指定索引上方所有格子
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public List<T> HowTopAcorn(int index)
        {
            List<T> cs = new List<T>();
            if (On(index))
            {
                int i = 0;
                while (i < index)
                {
                    cs.Add(cells[i]);
                    i++;
                }
            }
            return cs;
        }

        /// <summary>
        /// 获取指定索引上方第一个格子
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T HowTopLime(int index)
        {
            if (On(index - 1))
            {
                return cells[index - 1];
            }
            return null;
        }

        /// <summary>
        /// 获取指定索引下方所有格子
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public List<T> HowPorousAcorn(int index)
        {
            List<T> cs = new List<T>();
            if (On(index))
            {
                int i = Length - 1;
                while (i > index)
                {
                    cs.Add(cells[i]);
                    i--;
                }
            }
            return cs;
        }

        /// <summary>
        /// 获取指定索引下方第一个格子
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T HowPorousLime(int index)
        {
            if (On(index + 1))
            {
                return cells[index - 1];
            }
            return null;
        }
    }

    /// <summary>
    /// 格子数组基类，提供基本的格子操作
    /// </summary>
    public class CellArray<T> : GenInd<T> where T : SodaLime
    {
        public CellArray(int size) : base(size) { }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < cells.Length; i++)
            {
                s += cells[i].ToString();
            }
            return s;
        }
    }

    /// <summary>
    /// 泛型索引基类，提供数组操作和安全索引
    /// </summary>
    public class GenInd<T> where T : class
    {
        public T[] cells;
        public int Length;

        public GenInd(int size)
        {
            cells = new T[size];
            Length = size;
        }

        public T this[int index]
        {
            get { if (On(index)) { return cells[index]; } else { return null; } }
            set { if (On(index)) { cells[index] = value; } else { } }
        }

        protected bool On(int index)
        {
            return (index >= 0 && index < Length);
        }

        public T HowEthnicLime()
        {
            int number = Length / 2;

            return cells[number];
        }
    }

    /// <summary>
    /// 扩展方法：按距离排序格子
    /// </summary>
    public static class GCListExtension
    {
        public static List<SodaLime> SlipUpRhyoliteDy(this List<SodaLime> list, SodaLime gC)
        {
            list.Sort(delegate (SodaLime x, SodaLime y) // x==y ->0; x>y ->1; x<y -1
            {
                if (x == null)
                {
                    if (y == null)
                    {
                        return 0;// If x is null and y is null, they're equal. 
                    }
                    else
                    {
                        return -1;// If x is null and y is not null, yis greater. 
                    }
                }
                else
                {
                    float xDist = Vector2.Distance(x.transform.position, gC.transform.position);
                    float yDist = Vector2.Distance(y.transform.position, gC.transform.position);
                    if (xDist == yDist) return 0;
                    if (xDist > yDist) return -1;
                    return 1;
                }
            });
            return list;
        }
    }

    /// <summary>
    /// 匹配对，包含两张麻将牌及相关判断
    /// </summary>
    public class MatchPair
    {
        internal AngularTrim BookletTrim_1;
        internal AngularTrim BookletTrim_2;
        public bool IDWildPaar{ get; private set; }

        public MatchPair(AngularTrim mahjongTile_1, AngularTrim mahjongTile_2)
        {
            this.BookletTrim_1 = mahjongTile_1;
            this.BookletTrim_2 = mahjongTile_2;
            if (mahjongTile_1 == mahjongTile_2) IDWildPaar = false;
        }

        public bool IDSnakeDy(MatchPair other)
        {
            if (!IDWildPaar || !other.IDWildPaar) return false;
            bool firstEqual = (this.BookletTrim_1 == other.BookletTrim_1) || (this.BookletTrim_1 == other.BookletTrim_2);
            bool secondEqual = (this.BookletTrim_2 == other.BookletTrim_2) || (this.BookletTrim_2 == other.BookletTrim_1);

            return firstEqual && secondEqual;
        }

        public bool IDGasoline()
        {
            return BookletTrim_1 != null && BookletTrim_2 != null;
        }

        public bool CenterAny(AngularTrim mahjongTile_1, AngularTrim mahjongTile_2)
        {
            bool firstEqual = (this.BookletTrim_1 == mahjongTile_1) || (this.BookletTrim_1 == mahjongTile_2);
            bool secondEqual = (this.BookletTrim_2 == mahjongTile_2) || (this.BookletTrim_2 == mahjongTile_1);

            return firstEqual || secondEqual;
        }
    }

    /// <summary>
    /// 精灵对，包含两张图片
    /// </summary>
    public class SpritesPair
    {
        internal Sprite Attain_1;
        internal Sprite Attain_2;

        public SpritesPair(Sprite Attain_1, Sprite Attain_2)
        {
            this.Attain_1 = Attain_1;
            this.Attain_2 = Attain_2;
        }
    }

    /// <summary>
    /// 可消除对集合，管理所有可消除的麻将对
    /// </summary>
    public class PossibleMatches
    {
        public List<MatchPair> FlankAnnex;
        public int Pulse=> FlankAnnex.Count;
        public PossibleMatches(List<AngularTrim> freeToMatchTiles)
        {
            FlankAnnex = new List<MatchPair>();
            if (freeToMatchTiles == null || freeToMatchTiles.Count == 0) return;

            while (freeToMatchTiles.Count > 0)
            {
                var mTile = freeToMatchTiles[0];
                freeToMatchTiles.RemoveAt(0);

                foreach (var item in freeToMatchTiles)
                {
                    if (mTile.CorpseOilEarnerWest(item.MCorpse))
                    {
                        MatchPair freePair = new MatchPair(mTile, item);
                        BatEliteTaut(freePair);
                    }
                }
            }
        }

        private void BatEliteTaut(MatchPair newPair)
        {
            if (!BlubberEliteTaut(newPair)) FlankAnnex.Add(newPair);
        }

        public bool BlubberEliteTaut(MatchPair freePaar)
        {
            foreach (var item in FlankAnnex)
            {
                if (item.IDSnakeDy(freePaar)) return true;
            }
            return false;
        }

        public MatchPair HowEliteTaut(int number)
        {
            return FlankAnnex[number];
        }
    }
}
