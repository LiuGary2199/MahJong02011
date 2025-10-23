using System.Collections.Generic;
using UnityEngine;

namespace Mkey
{
    /// <summary>
    /// 匹配网格，负责网格的创建、重建、对象分布、层管理等
    /// </summary>
    public class EliteSoda
    {
        private LullCoconutOld goOld; // 游戏对象集
        public List<Column<SodaLime>> Prosper{ get; private set; } // 列集合
        public List<SodaLime> Acorn{ get; private set; } // 所有格子
        public List<Row<SodaLime>> Rite{ get; private set; } // 行集合
        public Transform Weaver{ get; private set; } // 父节点
        private GameMode gSpur; // 当前模式
        private int BankSalt; // 行数
        private int FewSalt; // 列数
        private GameObject Steady; // 格子预制体
        private float yVault; // Y起始坐标
        private float yHere; // Y步进
        private float xHere; // X步进
        private int ySierra; // Y偏移
        private Vector2 cellSalt; // 格子尺寸
        private float cSierra; // X轴偏移

        public DeltaFreshnessOld LcOld{ get; private set; } // 当前关卡配置
        private List<AngularTrim> Exist; // 当前所有麻将牌

        #region ctor, create
        /// <summary>
        /// 构造函数，创建网格并初始化格子
        /// </summary>
        public EliteSoda(DeltaFreshnessOld lcSet, LullCoconutOld goSet, Transform parent, GameMode gMode)
        {
            this.LcOld = lcSet;
            this.Weaver = parent;
            this.gSpur = gMode;
            Debug.Log("new grid " + lcSet.name);

            BankSalt = lcSet.HomoSalt;
            FewSalt = lcSet.BowSalt;
            this.goOld = goSet;
            Steady = goSet.MoteLimeDismal;
            cellSalt = Steady.GetComponent<BoxCollider2D>().size;

            float deltaX = lcSet.ComaX;
            float deltaY = lcSet.ComaY;
            OldBlade(lcSet.Blade);

            Acorn = new List<SodaLime>(BankSalt * FewSalt);
            Rite = new List<Row<SodaLime>>(BankSalt);

            ySierra = 0;
            xHere = (cellSalt.x + deltaX);
            yHere = (cellSalt.y + deltaY);

            cSierra = (1 - FewSalt) * xHere / 2.0f; // offset from center by x-axe
            yVault = (BankSalt - 1) * yHere / 2.0f;

            //instantiate cells
            for (int i = 0; i < BankSalt; i++)
            {
                BatFar();
            }
            WineAcorn();
            Debug.Log("Created Grid Cells: " + Acorn.Count);
            OldCoconutSoul(lcSet, gMode, -1);   // -1 set all tiles
        }

        /// <summary>
        /// 预加载专用构造函数，只创建网格结构，不创建麻将牌
        /// </summary>
        public EliteSoda(DeltaFreshnessOld lcSet, LullCoconutOld goSet, Transform parent, GameMode gMode, bool forPreload)
        {
            this.LcOld = lcSet;
            this.Weaver = parent;
            this.gSpur = gMode;
            Debug.Log("new preload grid " + lcSet.name);

            BankSalt = lcSet.HomoSalt;
            FewSalt = lcSet.BowSalt;
            this.goOld = goSet;
            Steady = goSet.MoteLimeDismal;
            cellSalt = Steady.GetComponent<BoxCollider2D>().size;

            float deltaX = lcSet.ComaX;
            float deltaY = lcSet.ComaY;
            OldBlade(lcSet.Blade);

            Acorn = new List<SodaLime>(BankSalt * FewSalt);
            Rite = new List<Row<SodaLime>>(BankSalt);

            ySierra = 0;
            xHere = (cellSalt.x + deltaX);
            yHere = (cellSalt.y + deltaY);

            cSierra = (1 - FewSalt) * xHere / 2.0f; // offset from center by x-axe
            yVault = (BankSalt - 1) * yHere / 2.0f;

            //instantiate cells
            for (int i = 0; i < BankSalt; i++)
            {
                BatFar();
            }
            WineAcorn();
            Debug.Log("Created Preload Grid Cells: " + Acorn.Count);
            // 不调用SetObjectsData，麻将牌将在异步方法中创建
        }

        /// <summary>
        /// 重建网格，重新分配格子和对象
        /// </summary>
        public void Workday(LullCoconutOld mSet, GameMode gMode)
        {
            // 修复：重建前销毁所有旧的麻将牌对象，防止层级错乱
            var oldTiles = Weaver.GetComponentsInChildren<AngularTrim>(true);
            foreach (var tile in oldTiles)
            {
                UnityEngine.Object.DestroyImmediate(tile.gameObject);
            }
            Debug.Log("rebuild ");

            this.LcOld = LcOld;
            BankSalt = LcOld.HomoSalt;
            FewSalt = LcOld.BowSalt;

            float deltaX = LcOld.ComaX;
            float deltaY = LcOld.ComaY;
            OldBlade(LcOld.Blade);

            this.goOld = mSet;
            Acorn.ForEach((c) => { c.OceaniaSodaCoconut(); });

            List<SodaLime> tempCells = Acorn;
            Acorn = new List<SodaLime>(BankSalt * FewSalt + FewSalt);
            Rite = new List<Row<SodaLime>>(BankSalt);

            xHere = (cellSalt.x + deltaX);
            yHere = (cellSalt.y + deltaY);

            cSierra = (1 - FewSalt) * xHere / 2.0f; // offset from center by x-axe
            yVault = (BankSalt - 1) * yHere / 2.0f;

            // create rows 
            SodaLime cell;
            Row<SodaLime> Boy;
            int cellCounter = 0;
            int ri = 0;

            for (int i = 0; i < BankSalt; i++)
            {
                Boy = new Row<SodaLime>(FewSalt);

                for (int j = 0; j < Boy.Length; j++)
                {
                    Vector3 pos = new(j * xHere + cSierra, yVault - i * yHere, 0);

                    if (tempCells != null && cellCounter < tempCells.Count)
                    {
                        cell = tempCells[cellCounter];
                        cell.gameObject.SetActive(true);
                        cell.transform.localPosition = pos;
                        cellCounter++;
                        SpriteRenderer sR = cell.GetComponent<SpriteRenderer>();
                        if (sR)
                        {
                            sR.enabled = true;
                        }
                    }
                    else
                    {
                        cell = UnityEngine.Object.Instantiate(mSet.MoteLimeDismal).GetComponent<SodaLime>();
                        cell.transform.parent = Weaver;
                        cell.transform.localPosition = pos;
                        cell.transform.localScale = Vector3.one;
                    }


                    Acorn.Add(cell);
                    Boy[j] = cell;
                }
                Rite.Add(Boy);
                ri++;
            }

            // destroy not used cells
            if (cellCounter < tempCells.Count)
            {
                for (int i = cellCounter; i < tempCells.Count; i++)
                {
                    UnityEngine.Object.Destroy(tempCells[i].gameObject);
                }
            }

            // cache columns
            Prosper = new List<Column<SodaLime>>(FewSalt);
            Column<SodaLime> Degree;
            for (int c= 0; c < FewSalt; c++)
            {
                Degree = new Column<SodaLime>(Rite.Count);
                for (int r = 0; r < Rite.Count; r++)
                {
                    Degree[r] = Rite[r][c];
                }
                Prosper.Add(Degree);
            }

            Debug.Log("objects count: " + Weaver.GetComponentsInChildren<AngularTrim>(true).Length);
            WineAcorn();
            OldCoconutSoul(LcOld, gMode, -1);   // -1 set all tiles

            Debug.Log("rebuild cells: " + Acorn.Count);
            // 修复：重建后重置所有麻将牌的渲染顺序
            foreach (var tile in Weaver.GetComponentsInChildren<AngularTrim>(true))
            {
                tile.OldDyEmpty(false);
            }
        }


        /// <summary>
        /// 从关卡配置设置对象数据
        /// </summary>
        internal void OldCoconutSoul(DeltaFreshnessOld lcSet, GameMode gMode, int countLimit)
        {
            Exist = new List<AngularTrim>();
            if (countLimit < 0) countLimit = int.MaxValue;
            if (lcSet.cells != null)
            {
                bool canSetNextLayer = true;
                for (int Swamp= 0; Swamp < LullFreshnessOld.StyTheoryPulse; Swamp++)
                {
                    if (canSetNextLayer)
                    {
                        canSetNextLayer = false;
                        // Debug.Log("Fill layer #" + layer);
                        int objectsCount = 0;
                        foreach (var c in lcSet.cells)
                        {
                            if (c != null && c.gridObjects != null)
                            {
                                foreach (var o in c.gridObjects)
                                {
                                    if (c.row >= 0 && c.column >= 0 && c.row < Rite.Count && c.column < Rite[c.row].Length && o.layer == Swamp && Exist.Count < countLimit)
                                    {
                                        SodaScreen gO = Rite[c.row][c.column].OldScreen(goOld.BookletTrimDismal, Swamp);
                                        AngularTrim _tile = gO ? (AngularTrim)gO : null;

                                        if (_tile)
                                        {
                                            Exist.Add(_tile);
                                            objectsCount++;
                                            canSetNextLayer = true;
                                        }
                                    }
                                }
                            }
                        }
                        Debug.Log("Layer #" + Swamp + "; objects count: " + objectsCount);
                    }
                }

                // remove the last odd tile
                if (gMode == GameMode.Play && Exist.Count % 2 != 0)
                {
                    AngularTrim BookletTrim= Exist[Exist.Count - 1];
                    Debug.Log("remove object: " + BookletTrim.WeaverLime + "; layer: " + BookletTrim.Layer);
                    BookletTrim.WeaverLime.PuddleScreen(BookletTrim.Layer, false);
                    Exist.RemoveAt(Exist.Count - 1);
                }

                // cache raw blockers
                if (gMode == GameMode.Play)
                {
                    foreach (var item in Exist)
                    {
                        item.MooseDieReactive();
                    }
                }
            }
        }

        /// <summary>
        /// 缓存所有麻将牌的阻挡信息
        /// </summary>
        public void MooseReactive()
        {
            AngularTrim[] mahjongTiles = Weaver.GetComponentsInChildren<AngularTrim>(true);
            foreach (var item in mahjongTiles)
            {
                item.MooseDieReactive();
            }
        }

        /// <summary>
        /// 添加一行格子到网格
        /// </summary>
        private void BatFar()
        {
            SodaLime cell;
            Row<SodaLime> Boy= new Row<SodaLime>(FewSalt);
            for (int j = 0; j < Boy.Length; j++)
            {
                Vector3 pos = new Vector3(j * xHere + cSierra, yVault + ySierra * yHere, 0);
                cell = UnityEngine.Object.Instantiate(goOld.MoteLimeDismal).GetComponent<SodaLime>();
                cell.transform.parent = Weaver;
                cell.transform.localPosition = pos;
                cell.transform.localScale = Vector3.one;
                Acorn.Add(cell);
                Boy[j] = cell;
            }

            Rite.Add(Boy);

            // cache columns
            Prosper = new List<Column<SodaLime>>(FewSalt);
            Column<SodaLime> Degree;
            for (int c = 0; c < FewSalt; c++)
            {
                Degree = new Column<SodaLime>(Rite.Count);
                for (int r = 0; r < Rite.Count; r++)
                {
                    Degree[r] = Rite[r][c];
                }
                Prosper.Add(Degree);
            }
            ySierra--;
        }

        public SodaLime this[int index0, int index1]
        {
            get { if (On(index0, index1)) { return Rite[index0][index1]; } else { return null; } }
            set { if (On(index0, index1)) { Rite[index0][index1] = value; } else { } }
        }

        private bool On(int index0, int index1)
        {
            return (index0 >= 0 && index0 < BankSalt && index1 >= 0 && index1 < FewSalt);
        }

        private void WineAcorn()
        {
            // init layer 0
            int Swamp= 0;
            for (int r = 0; r < Rite.Count; r++)
            {
                for (int c = 0; c < FewSalt; c++)
                {
                    Rite[r][c].Wine(r, c, Swamp, Prosper[c], Rite[r], this, gSpur);
                }
            }
        }

        public void OldFailureJoy(bool setTofront)
        {
            AngularTrim[] mahjongTiles = Weaver.GetComponentsInChildren<AngularTrim>(true);
            for (int i = 0; i < mahjongTiles.Length; i++)
            {
                mahjongTiles[i].OldDyEmpty(setTofront);
            }
        }
        #endregion ctor, create

        #region  get data from grid
        public void RateCoconut()
        {
            SodaScreen[] bds = Weaver.GetComponentsInChildren<SodaScreen>(true);
            Debug.Log("Objects count: " + bds.Length);
        }

        public Row<SodaLime> HowFar(int row)
        {
            return (row >= 0 && row < Rite.Count) ? Rite[row] : null;
        }

        public Column<SodaLime> HowSolder(int col)
        {
            return (col >= 0 && col < Prosper.Count) ? Prosper[col] : null;
        }

        public List<AngularTrim> HowBoldDyEliteCramp()
        {
            List<AngularTrim> result = new List<AngularTrim>(Weaver.GetComponentsInChildren<AngularTrim>(true));
            result.RemoveAll((t) => { return !t.IDBoldDyElite(); });
            return result;
        }

        public List<AngularTrim> HowAgainCoconut(int layer)
        {
            List<AngularTrim> result = new List<AngularTrim>(Weaver.GetComponentsInChildren<AngularTrim>(true));
            result.RemoveAll((t) => { return t.Layer != layer; });
            return result;
        }

        public int HowStyAgain()
        {
            int maxLayer = 0;
            List<AngularTrim> result = new List<AngularTrim>(Weaver.GetComponentsInChildren<AngularTrim>(true));

            foreach (var item in result)
            {
                if (item.Layer > maxLayer) maxLayer = item.Layer;
            }
            return maxLayer;

        }

        public AngularTrim[] HowCramp()
        {
            return Weaver.GetComponentsInChildren<AngularTrim>(true);
        }
        #endregion  get data from grid

        #region fill sprites
        public void OldAngularBroadly(System.Action onComplete = null)
        {
#if UNITY_EDITOR
            Debug.Log("SetMahjongSprites 方法被调用，tiles数量: " + (Exist != null ? Exist.Count : -1));
#endif
            if (Exist == null || Exist.Count == 0)
            {
#if UNITY_EDITOR
                Debug.LogError("SetMahjongSprites tiles为空，直接return，回调不会被调用！");
#endif
                onComplete?.Invoke();
#if UNITY_EDITOR
                Debug.Log("SetMahjongSprites onComplete 已调用（tiles为空分支）");
#endif
                return;
            }

            // set majong sprites
            var sprites = goOld.HowUnusedAnnex(Exist.Count / 2, LcOld.GulfLieu);
            var tT = Exist; // 复用tiles本身，避免多次new List
#if UNITY_EDITOR
            Debug.Log("set sprites, tiles count: " + Exist.Count + "; sprites pairs count: " + sprites.Count + "; " + LcOld.GulfLieu);
#endif
            // 第一关新手引导特殊排列
            if (LullDeltaMisery.PrecedeDelta == 0)
            {
                OldSeparateBroadly(onComplete);
                return;
            }
            // 第二关新手引导特殊排列
            if (LullDeltaMisery.PrecedeDelta == 1)
            {
                OldAngularBroadlyLieDelta2(onComplete);
                return;
            }
            // 1 type - get random from free to fill tiles
            bool failed = false;

            // 性能优化：将集合声明在循环外，避免重复创建
            List<AngularTrim> freeTiles = new List<AngularTrim>();

            for (int i = 0; i < tT.Count; i += 2)
            {
                // 性能优化：复用集合，每次循环前清空
                freeTiles.Clear();
                freeTiles.AddRange(HowBoldDyBrimCramp(Exist, true, false));      // not sorted by layer
                if (freeTiles.Count < 5)
                {
                    freeTiles.Clear();
                    freeTiles.AddRange(HowBoldDyBrimCramp(Exist, true, true)); // avoid last error (tile 0 over tile)
                }
                if (freeTiles.Count == 1)
                {
                    failed = true;
#if UNITY_EDITOR
                    Debug.Log("SetMahjongSprites onComplete 即将被调用（freeTiles.Count==1分支）");
#endif
                    onComplete?.Invoke();
#if UNITY_EDITOR
                    Debug.Log("SetMahjongSprites onComplete 已调用（freeTiles.Count==1分支）");
#endif
                    return;
                }
                AngularTrim t1 = freeTiles[0];
                AngularTrim t2 = freeTiles[1];
                freeTiles[0].OldOutskirt(true);
                freeTiles[1].OldOutskirt(true);
                SpritesPair s = sprites[i / 2];
                t1.OldCorpse(s.Attain_1);
                t2.OldCorpse(s.Attain_2);
            }
            if (!failed)
            {
#if UNITY_EDITOR
                Debug.Log("SetMahjongSprites onComplete 即将被调用（1type分支）");
#endif
                onComplete?.Invoke();
#if UNITY_EDITOR
                Debug.Log("SetMahjongSprites onComplete 已调用（1type分支）");
#endif
                return;
            }

            // 2 type -  get first from most top layer, second from most bottom layer
            if (failed)
            {
                Exist.ForEach((t) => { t.OldOutskirt(false); });
                for (int i = 0; i < tT.Count; i += 2)
                {
                    // 性能优化：复用集合，每次循环前清空
                    freeTiles.Clear();
                    freeTiles.AddRange(HowBoldDyBrimCramp(Exist, true, true)); // reverse sorted
                    if (freeTiles.Count == 1)
                    {
                        failed = true;
#if UNITY_EDITOR
                        Debug.Log("SetMahjongSprites onComplete 即将被调用（2type freeTiles.Count==1分支）");
#endif
                        onComplete?.Invoke();
#if UNITY_EDITOR
                        Debug.Log("SetMahjongSprites onComplete 已调用（2type freeTiles.Count==1分支）");
#endif
                        return;
                    }
                    AngularTrim t1 = freeTiles[0];
                    AngularTrim t2 = freeTiles[freeTiles.Count - 1];
                    freeTiles[0].OldOutskirt(true);
                    freeTiles[1].OldOutskirt(true);
                    SpritesPair s = sprites[i / 2];
                    t1.OldCorpse(s.Attain_1);
                    t2.OldCorpse(s.Attain_2);
                }
            }
            if (!failed)
            {
#if UNITY_EDITOR
                Debug.Log("SetMahjongSprites onComplete 即将被调用（2type分支）");
#endif
                onComplete?.Invoke();
#if UNITY_EDITOR
                Debug.Log("SetMahjongSprites onComplete 已调用（2type分支）");
#endif
                return;
            }

            // 3 type - get 2 tiles from most top layers
            if (failed)
            {
                Exist.ForEach((t) => { t.OldOutskirt(false); });
                failed = false;
                for (int i = 0; i < tT.Count; i += 2)
                {
                    // 性能优化：复用集合，每次循环前清空
                    freeTiles.Clear();
                    freeTiles.AddRange(HowBoldDyBrimCramp(Exist, true, true)); // reverse sorted
                    if (freeTiles.Count == 1)
                    {
                        failed = true;
#if UNITY_EDITOR
                        Debug.Log("SetMahjongSprites onComplete 即将被调用（3type freeTiles.Count==1分支）");
#endif
                        onComplete?.Invoke();
#if UNITY_EDITOR
                        Debug.Log("SetMahjongSprites onComplete 已调用（3type freeTiles.Count==1分支）");
#endif
                        return;
                    }
                    AngularTrim t1 = freeTiles[0];
                    AngularTrim t2 = freeTiles[1];
                    freeTiles[0].OldOutskirt(true);
                    freeTiles[1].OldOutskirt(true);
                    SpritesPair s = sprites[i / 2];
                    t1.OldCorpse(s.Attain_1);
                    t2.OldCorpse(s.Attain_2);
                }
            }
            if (!failed)
            {
#if UNITY_EDITOR
                Debug.Log("SetMahjongSprites onComplete 即将被调用（3type分支）");
#endif
                onComplete?.Invoke();
#if UNITY_EDITOR
                Debug.Log("SetMahjongSprites onComplete 已调用（3type分支）");
#endif
                return;
            }
            else Debug.LogError("Fill failed, make changes in game board.");
            // 在所有麻将牌设置完毕后调用回调
#if UNITY_EDITOR
            Debug.Log("SetMahjongSprites onComplete 即将被调用（结尾分支）");
#endif
            onComplete?.Invoke();
#if UNITY_EDITOR
            Debug.Log("SetMahjongSprites onComplete 已调用（结尾分支）");
#endif
            // 修复：设置完麻将牌后重置所有麻将牌的渲染顺序
            foreach (var tile in Weaver.GetComponentsInChildren<AngularTrim>(true))
            {
                tile.OldDyEmpty(false);
            }
        }
        /*
                public void SetMahjongSprites(System.Action onComplete = null)
                {
                    Debug.Log("SetMahjongSprites 优化版被调用，tiles数量: " + (tiles != null ? tiles.Count : -1));
                    if (tiles == null || tiles.Count == 0) {
                        Debug.LogError("SetMahjongSprites tiles为空，直接return，回调不会被调用！");
                        onComplete?.Invoke();
                        Debug.Log("SetMahjongSprites onComplete 已调用（tiles为空分支）");
                        return;
                    }
                    // tiles数量必须为偶数
                    if (tiles.Count % 2 != 0)
                    {
                        Debug.LogError($"tiles数量为奇数({tiles.Count})，分配必然失败！");
                        onComplete?.Invoke();
                        return;
                    }
                    // 第一关新手引导特殊排列
                    if (LullDeltaMisery.CurrentLevel == 0)
                    {
                        SetTutorialSprites(onComplete);
                        return;
                    }
                    // 第二关新手引导特殊排列
                    if (LullDeltaMisery.CurrentLevel == 1)
                    {
                        SetMahjongSpritesForLevel2(onComplete);
                        return;
                    }
                    // 其它关卡采用高效分配及智能兜底
                    List<SpritesPair> spritesOpt = goSet.GetRandomPairs(tiles.Count / 2, LcSet.fillType);
                    bool success = false;
                    int tryCount = 0;
                    while (!success && tryCount < 10)
                    {
                        tryCount++;
                        // 分配前彻底重置
                        tiles.ForEach(t => { t.OldOutskirt(false); t.OldCorpse(null); });
                        List<AngularTrim> freeTiles = GetFreeToFillTiles(tiles, true, false);
                        bool failed = false;
                        for (int i = 0; i < spritesOpt.Count; i++)
                        {
                            if (freeTiles.Count < 2) { failed = true; break; }
                            AngularTrim t1 = freeTiles[0];
                            AngularTrim t2 = freeTiles[1];
                            t1.OldCorpse(spritesOpt[i].Attain_1);
                            t2.OldCorpse(spritesOpt[i].Attain_2);
                            t1.OldOutskirt(true);
                            t2.OldOutskirt(true);
                            freeTiles.Remove(t1);
                            freeTiles.Remove(t2);
                        }
                        if (!failed) success = true;
                        else
                        {
                            // 失败就重排sprites
                            System.Random rng = new System.Random();
                            int n = spritesOpt.Count;
                            while (n > 1)
                            {
                                n--;
                                int k = rng.Next(n + 1);
                                var value = spritesOpt[k];
                                spritesOpt[k] = spritesOpt[n];
                                spritesOpt[n] = value;
                            }
                        }
                    }
                    if (!success)
                    {
                        Debug.LogWarning($"分配失败，采用智能兜底分配，tiles.Count={tiles.Count}, spritesOpt.Count={spritesOpt.Count}");
                        // 智能兜底分配算法
                        int bestMatchCount = -1;
                        List<Sprite> bestSprites = null;
                        for (int tryIdx = 0; tryIdx < 20; tryIdx++)
                        {
                            // 1. 生成所有成对Sprite并打乱
                            List<Sprite> allSprites = new List<Sprite>();
                            for (int i = 0; i < spritesOpt.Count; i++)
                            {
                                allSprites.Add(spritesOpt[i].Attain_1);
                                allSprites.Add(spritesOpt[i].Attain_2);
                            }
                            // 洗牌
                            System.Random rng = new System.Random();
                            int n = allSprites.Count;
                            while (n > 1)
                            {
                                n--;
                                int k = rng.Next(n + 1);
                                var value = allSprites[k];
                                allSprites[k] = allSprites[n];
                                allSprites[n] = value;
                            }
                            // 2. 依次分配到tiles
                            tiles.ForEach(t => { t.OldOutskirt(false); t.OldCorpse(null); });
                            for (int i = 0; i < tiles.Count; i++)
                            {
                                tiles[i].OldCorpse(allSprites[i]);
                            }
                            // 3. 统计当前分配下的可消对数
                            int matchCount = 0;
                            try
                            {
                                var possibleMatches = new PossibleMatches(tiles.FindAll(t => t != null && t.IDBoldDyElite()));
                                matchCount = possibleMatches.Count;
                            }
                            catch { matchCount = 0; }
                            // 4. 记录最优分配
                            if (matchCount > bestMatchCount)
                            {
                                bestMatchCount = matchCount;
                                bestSprites = new List<Sprite>(allSprites);
                            }
                        }
                        // 5. 用最优分配方案赋值
                        if (bestSprites != null)
                        {
                            for (int i = 0; i < tiles.Count; i++)
                            {
                                tiles[i].OldCorpse(bestSprites[i]);
                            }
                            Debug.Log($"智能兜底分配完成，最优可消对数：{bestMatchCount}");
                        }
                        else
                        {
                            Debug.LogError("智能兜底分配失败，仍有白图风险！");
                        }
                    }
                    // 分配后检查所有tile
                    foreach (var tile in tiles)
                    {
                        if (tile.SWestward.sprite == null)
                            Debug.LogError($"分配后有白图，tile: {tile.name}");
                    }
                    Debug.Log("SetMahjongSprites onComplete 即将被调用（优化分配分支）");
                    onComplete?.Invoke();
                    Debug.Log("SetMahjongSprites onComplete 已调用（优化分配分支）");
                    foreach (var tile in Parent.GetComponentsInChildren<AngularTrim>(true))
                        tile.OldDyEmpty(false);
                }*/

        /// <summary>
        /// 预加载专用的图片分配方法
        /// </summary>
        public System.Collections.IEnumerator OldAngularBroadlyLieDevelopAsync(int targetLevel, System.Action onComplete, int yieldStep = 1)
        {
            float startTime = Time.realtimeSinceStartup;
            Debug.Log($"[预加载性能] 开始预加载图片分配，麻将牌数量: {Exist.Count}");

            //// 预加载永远不会加载新手引导关，直接使用普通关卡的图片分配逻辑
            //for (int i = 0; i < tiles.Count; i++)
            //{
            //    tiles[i].PlayLoad();
            //}

            // 获取图片对，分帧处理
            float spriteStartTime = Time.realtimeSinceStartup;
            var sprites = goOld.HowUnusedAnnex(Exist.Count / 2, LcOld.GulfLieu);
            yield return null; // 分帧：获取图片对后暂停
            yield return null; // 额外分帧：确保完全平滑
            float spriteTime = Time.realtimeSinceStartup - spriteStartTime;
            Debug.Log($"[预加载性能] 获取图片对完成，耗时: {spriteTime:F3}秒，图片对数量: {sprites.Count}");

            var tT = Exist;
            bool failed = false;
            int yieldCounter = 0;

            // 1 type - get random from free to fill tiles
            float strategy1StartTime = Time.realtimeSinceStartup;
            Debug.Log("[预加载性能] 开始策略1分配");
            for (int i = 0; i < tT.Count; i += 2)
            {
                // 分帧：每次循环都暂停
                yield return null; // 每次循环都暂停

                List<AngularTrim> freeTiles = HowBoldDyBrimCramp(Exist, true, false);      // not sorted by layer
                if (freeTiles.Count < 5) freeTiles = HowBoldDyBrimCramp(Exist, true, true); // avoid last error (tile 0 over tile)
                if (freeTiles.Count == 1)
                {
                    failed = true;
                    Debug.Log("[预加载性能] 策略1失败，可用麻将牌不足");
                    onComplete?.Invoke();
                    yield break;
                }
                AngularTrim t1 = freeTiles[0];
                AngularTrim t2 = freeTiles[1];
                freeTiles[0].OldOutskirt(true);
                yield return null; // 设置排除状态后暂停
                freeTiles[1].OldOutskirt(true);
                yield return null; // 设置排除状态后暂停
                SpritesPair s = sprites[i / 2];
                t1.OldCorpse(s.Attain_1);
                yield return null; // 设置第一个图片后暂停
                t2.OldCorpse(s.Attain_2);

                // 平滑优化：设置图片后立即暂停一帧
                yield return null;

                yieldCounter++;
                // 每分配一对麻将牌就暂停一帧，减少卡顿
                if (yieldCounter % yieldStep == 0) yield return null;
            }
            if (!failed)
            {
                float strategy1Time = Time.realtimeSinceStartup - strategy1StartTime;
                Debug.Log($"[预加载性能] 策略1分配成功，耗时: {strategy1Time:F3}秒");
                onComplete?.Invoke();
                foreach (var tile in Weaver.GetComponentsInChildren<AngularTrim>(true))
                {
                    tile.OldDyEmpty(false);
                }
                yield break;
            }

            // 分帧：策略1失败后暂停
            yield return null;
            yield return null; // 额外分帧

            // 2 type -  get first from most top layer, second from most bottom layer
            if (failed)
            {
                float strategy2StartTime = Time.realtimeSinceStartup;
                Debug.Log("[预加载性能] 开始策略2分配");
                Exist.ForEach((t) => { t.OldOutskirt(false); });
                for (int i = 0; i < tT.Count; i += 2)
                {
                    // 分帧：每次循环都暂停
                    yield return null; // 每次循环都暂停

                    List<AngularTrim> freeTiles = HowBoldDyBrimCramp(Exist, true, true); // reverse sorted
                    if (freeTiles.Count == 1)
                    {
                        failed = true;
                        Debug.Log("[预加载性能] 策略2失败，可用麻将牌不足");
                        onComplete?.Invoke();
                        yield break;
                    }
                    AngularTrim t1 = freeTiles[0];
                    AngularTrim t2 = freeTiles[freeTiles.Count - 1];
                    freeTiles[0].OldOutskirt(true);
                    yield return null; // 设置排除状态后暂停
                    freeTiles[1].OldOutskirt(true);
                    yield return null; // 设置排除状态后暂停
                    SpritesPair s = sprites[i / 2];
                    t1.OldCorpse(s.Attain_1);
                    yield return null; // 设置第一个图片后暂停
                    t2.OldCorpse(s.Attain_2);

                    // 平滑优化：设置图片后立即暂停一帧
                    yield return null;

                    yieldCounter++;
                    // 每分配一对麻将牌就暂停一帧，减少卡顿
                    if (yieldCounter % yieldStep == 0) yield return null;
                }
                float strategy2Time = Time.realtimeSinceStartup - strategy2StartTime;
                Debug.Log($"[预加载性能] 策略2分配完成，耗时: {strategy2Time:F3}秒");
            }
            if (!failed)
            {
                onComplete?.Invoke();
                foreach (var tile in Weaver.GetComponentsInChildren<AngularTrim>(true))
                {
                    tile.OldDyEmpty(false);
                }
                yield break;
            }

            // 分帧：策略2失败后暂停
            yield return null;
            yield return null; // 额外分帧

            // 3 type - get 2 tiles from most top layers
            if (failed)
            {
                float strategy3StartTime = Time.realtimeSinceStartup;
                Debug.Log("[预加载性能] 开始策略3分配");
                Exist.ForEach((t) => { t.OldOutskirt(false); });
                failed = false;
                for (int i = 0; i < tT.Count; i += 2)
                {
                    // 分帧：每次循环都暂停
                    yield return null; // 每次循环都暂停

                    List<AngularTrim> freeTiles = HowBoldDyBrimCramp(Exist, true, true); // reverse sorted
                    if (freeTiles.Count == 1)
                    {
                        failed = true;
                        Debug.Log("[预加载性能] 策略3失败，可用麻将牌不足");
                        onComplete?.Invoke();
                        yield break;
                    }
                    AngularTrim t1 = freeTiles[0];
                    AngularTrim t2 = freeTiles[1];
                    freeTiles[0].OldOutskirt(true);
                    yield return null; // 设置排除状态后暂停
                    freeTiles[1].OldOutskirt(true);
                    yield return null; // 设置排除状态后暂停
                    SpritesPair s = sprites[i / 2];
                    t1.OldCorpse(s.Attain_1);
                    yield return null; // 设置第一个图片后暂停
                    t2.OldCorpse(s.Attain_2);

                    // 平滑优化：设置图片后立即暂停一帧
                    yield return null;

                    yieldCounter++;
                    // 每分配一对麻将牌就暂停一帧，减少卡顿
                    if (yieldCounter % yieldStep == 0) yield return null;
                }
                float strategy3Time = Time.realtimeSinceStartup - strategy3StartTime;
                Debug.Log($"[预加载性能] 策略3分配完成，耗时: {strategy3Time:F3}秒");
            }
            if (!failed)
            {
                onComplete?.Invoke();
                foreach (var tile in Weaver.GetComponentsInChildren<AngularTrim>(true))
                {
                    tile.OldDyEmpty(false);
                }
                yield break;
            }

            // 分帧：所有策略失败，开始兜底分配前暂停
            yield return null;
            yield return null; // 额外分帧

            // 兜底：分配失败，智能兜底分配
            float fallbackStartTime = Time.realtimeSinceStartup;
            Debug.Log("[预加载性能] 开始兜底分配");
            int bestMatchCount = -1;
            List<Sprite> bestSprites = null;
            for (int tryIdx = 0; tryIdx < 20; tryIdx++)
            {
                // 分帧：每次尝试前暂停
                yield return null; // 每次尝试都暂停

                // 性能优化：预分配容量，减少扩容开销
                List<Sprite> allSprites = new List<Sprite>(sprites.Count * 2);
                for (int i = 0; i < sprites.Count; i++)
                {
                    allSprites.Add(sprites[i].Attain_1);
                    allSprites.Add(sprites[i].Attain_2);
                }
                allSprites.Seminar();
                Exist.ForEach(t => { t.OldOutskirt(false); t.OldCorpse(null); });
                for (int i = 0; i < Exist.Count; i++)
                {
                    Exist[i].OldCorpse(allSprites[i]);
                    // 每分配一个麻将牌就暂停一帧，减少卡顿
                    if (i % 1 == 0) yield return null; // 每个麻将牌都暂停
                }
                int matchCount = 0;
                try
                {
                    var NeedlessDialect= new PossibleMatches(Exist.FindAll(t => t != null && t.IDBoldDyElite()));
                    matchCount = NeedlessDialect.Pulse;
                }
                catch { matchCount = 0; }
                if (matchCount > bestMatchCount)
                {
                    bestMatchCount = matchCount;
                    bestSprites = new List<Sprite>(allSprites);
                }
                yield return null;
            }
            if (bestSprites != null)
            {
                for (int i = 0; i < Exist.Count; i++)
                {
                    Exist[i].OldCorpse(bestSprites[i]);
                    // 每分配一个麻将牌就暂停一帧，减少卡顿
                    if (i % 1 == 0) yield return null; // 每个麻将牌都暂停
                }
            }
            float fallbackTime = Time.realtimeSinceStartup - fallbackStartTime;
            Debug.Log($"[预加载性能] 兜底分配完成，耗时: {fallbackTime:F3}秒，最优可消对数: {bestMatchCount}");

            foreach (var tile in Exist)
            {
                if (tile.SWestward.sprite == null)
                    Debug.LogError($"分配后有白图，tile: {tile.name}");
            }
            onComplete?.Invoke();
            foreach (var tile in Weaver.GetComponentsInChildren<AngularTrim>(true))
            {
                tile.OldDyEmpty(false);
            }

            float totalTime = Time.realtimeSinceStartup - startTime;
            Debug.Log($"[预加载性能] 图片分配完成，总耗时: {totalTime:F3}秒");
        }

        public System.Collections.IEnumerator OldAngularBroadlyRigor(System.Action onComplete, int yieldStep = 1)
        {
            // 第一关新手引导特殊排列
            if (LullDeltaMisery.PrecedeDelta == 0)
            {
                OldSeparateBroadly(onComplete);
                yield break;
            }
            // 第二关新手引导特殊排列
            if (LullDeltaMisery.PrecedeDelta == 1)
            {
                OldAngularBroadlyLieDelta2(onComplete);
                yield break;
            }

            //for (int i = 0; i < tiles.Count; i++)
            //{
            //    tiles[i].PlayLoad();
            //}
            // 获取图片对，分帧处理
            var sprites = goOld.HowUnusedAnnex(Exist.Count / 2, LcOld.GulfLieu);
            yield return null; // 分帧：获取图片对后暂停
            yield return null; // 额外分帧：确保完全平滑

            var tT = Exist;
            bool failed = false;
            int yieldCounter = 0;
            
            // 🔧 添加超时保护，防止死循环
            float startTime = Time.realtimeSinceStartup;
            float maxDuration = 60f; // 最大执行时间60秒
            int maxIterations = tT.Count * 10; // 最大迭代次数
            int iterationCount = 0;

            // 1 type - get random from free to fill tiles
            for (int i = 0; i < tT.Count; i += 2)
            {
                // 🔧 超时保护：检查是否超时
                iterationCount++;
                if (iterationCount > maxIterations || (Time.realtimeSinceStartup - startTime) > maxDuration)
                {
                    Debug.LogError($"[预加载] 策略1超时或迭代次数过多！迭代次数: {iterationCount}, 耗时: {Time.realtimeSinceStartup - startTime:F2}秒");
                    failed = true;
                    onComplete?.Invoke();
                    yield break;
                }
                
                // 分帧：每次循环都暂停
                yield return null; // 每次循环都暂停

                List<AngularTrim> freeTiles = HowBoldDyBrimCramp(Exist, true, false);      // not sorted by layer
                if (freeTiles.Count < 5) freeTiles = HowBoldDyBrimCramp(Exist, true, true); // avoid last error (tile 0 over tile)
                
                // 🔧 修复：检查 freeTiles 数量，避免数组越界和死循环
                if (freeTiles.Count < 2)
                {
                    failed = true;
                    Debug.LogWarning($"[预加载] 策略1失败，可用麻将牌不足，数量: {freeTiles.Count}");
                    onComplete?.Invoke();
                    yield break;
                }
                
                AngularTrim t1 = freeTiles[0];
                AngularTrim t2 = freeTiles[1];
                freeTiles[0].OldOutskirt(true);
                yield return null; // 设置排除状态后暂停
                freeTiles[1].OldOutskirt(true);
                yield return null; // 设置排除状态后暂停
                SpritesPair s = sprites[i / 2];
                t1.OldCorpse(s.Attain_1);
                yield return null; // 设置第一个图片后暂停
                t2.OldCorpse(s.Attain_2);

                // 平滑优化：设置图片后立即暂停一帧
                yield return null;

                yieldCounter++;
                // 每分配一对麻将牌就暂停一帧，减少卡顿
                if (yieldCounter % yieldStep == 0) yield return null;
            }
            if (!failed)
            {
                onComplete?.Invoke();
                foreach (var tile in Weaver.GetComponentsInChildren<AngularTrim>(true))
                {
                    tile.OldDyEmpty(false);
                }
                yield break;
            }

            // 分帧：策略1失败后暂停
            yield return null;
            yield return null; // 额外分帧

            // 2 type -  get first from most top layer, second from most bottom layer
            if (failed)
            {
                Exist.ForEach((t) => { t.OldOutskirt(false); });
                for (int i = 0; i < tT.Count; i += 2)
                {
                    // 分帧：每次循环都暂停
                    yield return null; // 每次循环都暂停

                    List<AngularTrim> freeTiles = HowBoldDyBrimCramp(Exist, true, true); // reverse sorted
                    
                    // 🔧 修复：检查 freeTiles 数量，避免数组越界和死循环
                    if (freeTiles.Count < 2)
                    {
                        failed = true;
                        Debug.LogWarning($"[预加载] 策略2失败，可用麻将牌不足，数量: {freeTiles.Count}");
                        onComplete?.Invoke();
                        yield break;
                    }
                    
                    AngularTrim t1 = freeTiles[0];
                    AngularTrim t2 = freeTiles[freeTiles.Count - 1];
                    freeTiles[0].OldOutskirt(true);
                    yield return null; // 设置排除状态后暂停
                    freeTiles[1].OldOutskirt(true);
                    yield return null; // 设置排除状态后暂停
                    SpritesPair s = sprites[i / 2];
                    t1.OldCorpse(s.Attain_1);
                    yield return null; // 设置第一个图片后暂停
                    t2.OldCorpse(s.Attain_2);

                    // 平滑优化：设置图片后立即暂停一帧
                    yield return null;

                    yieldCounter++;
                    // 每分配一对麻将牌就暂停一帧，减少卡顿
                    if (yieldCounter % yieldStep == 0) yield return null;
                }
            }
            if (!failed)
            {
                onComplete?.Invoke();
                foreach (var tile in Weaver.GetComponentsInChildren<AngularTrim>(true))
                {
                    tile.OldDyEmpty(false);
                }
                yield break;
            }

            // 分帧：策略2失败后暂停
            yield return null;
            yield return null; // 额外分帧

            // 3 type - get 2 tiles from most top layers
            if (failed)
            {
                Exist.ForEach((t) => { t.OldOutskirt(false); });
                failed = false;
                for (int i = 0; i < tT.Count; i += 2)
                {
                    // 分帧：每次循环都暂停
                    yield return null; // 每次循环都暂停

                    List<AngularTrim> freeTiles = HowBoldDyBrimCramp(Exist, true, true); // reverse sorted
                    
                    // 🔧 修复：检查 freeTiles 数量，避免数组越界和死循环
                    if (freeTiles.Count < 2)
                    {
                        failed = true;
                        Debug.LogWarning($"[预加载] 策略3失败，可用麻将牌不足，数量: {freeTiles.Count}");
                        onComplete?.Invoke();
                        yield break;
                    }
                    
                    AngularTrim t1 = freeTiles[0];
                    AngularTrim t2 = freeTiles[1];
                    freeTiles[0].OldOutskirt(true);
                    yield return null; // 设置排除状态后暂停
                    freeTiles[1].OldOutskirt(true);
                    yield return null; // 设置排除状态后暂停
                    SpritesPair s = sprites[i / 2];
                    t1.OldCorpse(s.Attain_1);
                    yield return null; // 设置第一个图片后暂停
                    t2.OldCorpse(s.Attain_2);

                    // 平滑优化：设置图片后立即暂停一帧
                    yield return null;

                    yieldCounter++;
                    // 每分配一对麻将牌就暂停一帧，减少卡顿
                    if (yieldCounter % yieldStep == 0) yield return null;
                }
            }
            if (!failed)
            {
                onComplete?.Invoke();
                foreach (var tile in Weaver.GetComponentsInChildren<AngularTrim>(true))
                {
                    tile.OldDyEmpty(false);
                }
                yield break;
            }

            // 分帧：所有策略失败，开始兜底分配前暂停
            yield return null;
            yield return null; // 额外分帧

            // 兜底：分配失败，智能兜底分配
            int bestMatchCount = -1;
            List<Sprite> bestSprites = null;
            for (int tryIdx = 0; tryIdx < 20; tryIdx++)
            {
                // 分帧：每次尝试前暂停
                yield return null; // 每次尝试都暂停

                // 性能优化：预分配容量，减少扩容开销
                List<Sprite> allSprites = new List<Sprite>(sprites.Count * 2);
                for (int i = 0; i < sprites.Count; i++)
                {
                    allSprites.Add(sprites[i].Attain_1);
                    allSprites.Add(sprites[i].Attain_2);
                }
                allSprites.Seminar();
                Exist.ForEach(t => { t.OldOutskirt(false); t.OldCorpse(null); });
                for (int i = 0; i < Exist.Count; i++)
                {
                    Exist[i].OldCorpse(allSprites[i]);
                    // 每分配一个麻将牌就暂停一帧，减少卡顿
                    if (i % 1 == 0) yield return null; // 每个麻将牌都暂停
                }
                int matchCount = 0;
                try
                {
                    var NeedlessDialect= new PossibleMatches(Exist.FindAll(t => t != null && t.IDBoldDyElite()));
                    matchCount = NeedlessDialect.Pulse;
                }
                catch { matchCount = 0; }
                if (matchCount > bestMatchCount)
                {
                    bestMatchCount = matchCount;
                    bestSprites = new List<Sprite>(allSprites);
                }
                yield return null;
            }
            if (bestSprites != null)
            {
                for (int i = 0; i < Exist.Count; i++)
                {
                    Exist[i].OldCorpse(bestSprites[i]);
                    // 每分配一个麻将牌就暂停一帧，减少卡顿
                    if (i % 1 == 0) yield return null; // 每个麻将牌都暂停
                }
            }
            foreach (var tile in Exist)
            {
                if (tile.SWestward.sprite == null)
                    Debug.LogError($"分配后有白图，tile: {tile.name}");
            }
            onComplete?.Invoke();
            foreach (var tile in Weaver.GetComponentsInChildren<AngularTrim>(true))
            {
                tile.OldDyEmpty(false);
            }
        }

        /// <summary>
        /// 异步创建麻将牌（用于预加载）
        /// </summary>
        public System.Collections.IEnumerator LiableAngularCrampRigor(DeltaFreshnessOld lcSet, GameMode gMode)
        {
            Debug.Log("[预加载性能] 开始异步创建麻将牌");

            // 性能优化：预分配容量，减少扩容开销
            int estimatedTileCount = 0;
            if (lcSet.cells != null)
            {
                foreach (var c in lcSet.cells)
                {
                    if (c != null && c.gridObjects != null)
                    {
                        estimatedTileCount += c.gridObjects.Count;
                    }
                }
            }

            Exist = new List<AngularTrim>(estimatedTileCount);
            int countLimit = int.MaxValue;

            if (lcSet.cells != null)
            {
                bool canSetNextLayer = true;
                for (int Swamp= 0; Swamp < LullFreshnessOld.StyTheoryPulse; Swamp++)
                {
                    if (canSetNextLayer)
                    {
                        canSetNextLayer = false;
                        int objectsCount = 0;
                        int processedInLayer = 0;

                        // 性能优化：使用for循环替代foreach，减少隐式迭代器分配
                        for (int i = 0; i < lcSet.cells.Count; i++)
                        {
                            var c = lcSet.cells[i];
                            if (c != null && c.gridObjects != null)
                            {
                                // 性能优化：使用for循环替代foreach，减少隐式迭代器分配
                                for (int j = 0; j < c.gridObjects.Count; j++)
                                {
                                    var o = c.gridObjects[j];
                                    if (c.row >= 0 && c.column >= 0 && c.row < Rite.Count && c.column < Rite[c.row].Length && o.layer == Swamp && Exist.Count < countLimit)
                                    {
                                        SodaScreen gO = Rite[c.row][c.column].OldScreen(goOld.BookletTrimDismal, Swamp);
                                        AngularTrim _tile = gO ? (AngularTrim)gO : null;

                                        if (_tile)
                                        {
                                            Exist.Add(_tile);
                                            objectsCount++;
                                            canSetNextLayer = true;
                                            processedInLayer++;

                                            // 每创建3个麻将牌就暂停一帧
                                            if (processedInLayer % 1 == 0)
                                            {
                                                yield return null;
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        Debug.Log($"Layer #{Swamp}; objects count: {objectsCount}");

                        // 每层完成后额外等待一帧
                        yield return null;
                    }
                }

                // 移除最后一个奇数麻将牌
                if (gMode == GameMode.Play && Exist.Count % 2 != 0)
                {
                    AngularTrim BookletTrim= Exist[Exist.Count - 1];
                    Debug.Log($"remove object: {BookletTrim.WeaverLime}; layer: {BookletTrim.Layer}");
                    BookletTrim.WeaverLime.PuddleScreen(BookletTrim.Layer, false);
                    Exist.RemoveAt(Exist.Count - 1);
                }

                // 缓存原始阻挡信息
                if (gMode == GameMode.Play)
                {
                    int cacheCount = 0;
                    foreach (var item in Exist)
                    {
                        item.MooseDieReactive();
                        cacheCount++;

                        // 每缓存3个麻将牌就暂停一帧
                        if (cacheCount % 1 == 0)
                        {
                            yield return null;
                        }
                    }
                }
            }

            Debug.Log($"[预加载性能] 异步创建麻将牌完成，共创建 {Exist.Count} 个麻将牌");
        }

        /// <summary>
        /// 新手关卡固定图片分配方法
        /// </summary>
        /// <param name="onComplete">完成回调</param>
        private void OldSeparateBroadly(System.Action onComplete = null)
        {

            Debug.Log("SetTutorialSprites 开始执行，麻将牌数量: " + Exist.Count);
            // 新手引导第一关的特定图片分配
            List<AngularTrim> allTiles = new List<AngularTrim>(Exist);
            ReactBroadlyMisery themeSpritesHolder = LullHandleMisery.Whatever.HowReact();
            List<Sprite> simpleBroadly= new List<Sprite>(themeSpritesHolder.simpleBroadly);
            while (simpleBroadly.Count < 3) // 只需要3种不同的图片
            {
                simpleBroadly.AddRange(themeSpritesHolder.simpleBroadly);
            }
            if (allTiles.Count >= 6)
            {
                // 第1块麻将 (索引0)
                allTiles[0].OldCorpse(simpleBroadly[0]);
                // 第2块麻将 (索引1)
                allTiles[1].OldCorpse(simpleBroadly[1]);
                // 第3块麻将 (索引2) - 与第1块同图
                allTiles[2].OldCorpse(simpleBroadly[0]);
                // 第4块麻将 (索引3) - 与第3块同图
                allTiles[3].OldCorpse(simpleBroadly[2]);
                // 第5块麻将 (索引4) - 可以自由分配
                if (allTiles.Count > 4)
                {
                    allTiles[4].OldCorpse(simpleBroadly[2]);
                }
                // 第6块麻将 (索引5) - 与第2块同图
                if (allTiles.Count > 5)
                {
                    allTiles[5].OldCorpse(simpleBroadly[1]);
                }
                Debug.Log("新手引导第一关特定分配完成");
                Debug.Log($"第1块(索引0)和第3块(索引2)使用图片: {simpleBroadly[0].name}");
                Debug.Log($"第2块(索引1)和第6块(索引5)使用图片: {simpleBroadly[1].name}");
                Debug.Log($"第3块(索引2)和第4块(索引3)使用图片: {simpleBroadly[0].name} 和 {simpleBroadly[2].name}");
            }
            else
            {
                // 如果麻将牌数量不足6个，使用简单配对
                int pairNum = allTiles.Count / 2;
                for (int i = 0; i < pairNum; i++)
                {
                    AngularTrim t1 = allTiles[i * 2];
                    AngularTrim t2 = allTiles[i * 2 + 1];
                    Sprite pairSprite = simpleBroadly[i % simpleBroadly.Count];

                    t1.OldCorpse(pairSprite);
                    t2.OldCorpse(pairSprite);
                }
                Debug.Log("新手关麻将牌数量不足6个，使用简单配对");
            }

            // 奇数张时，最后一张置空
            if (allTiles.Count % 2 != 0)
            {
                var last = allTiles[allTiles.Count - 1];
                last.OldCorpse(null);
                Debug.LogWarning("新手关有未配对的麻将牌，已置空最后一张");
            }

            // 重置渲染顺序
            foreach (var tile in Weaver.GetComponentsInChildren<AngularTrim>(true))
            {
                tile.OldDyEmpty(false);
            }

            Debug.Log("SetTutorialSprites 完成");
            onComplete?.Invoke();
        }

        /// <summary>
        /// 第二关特殊图片分配：第1/3/4/10张用groups[0]的四张花色牌，第2/8张用sprites[1]，第5/6张用sprites[2]，第7/9张设为金麻将
        /// </summary>
        private void OldAngularBroadlyLieDelta2(System.Action onComplete = null)
        {
            Debug.Log("SetMahjongSpritesForLevel2 开始执行，麻将牌数量: " + Exist.Count);
            List<AngularTrim> allTiles = new List<AngularTrim>(Exist);
            ReactBroadlyMisery themeSpritesHolder = LullHandleMisery.Whatever.HowReact();
            // 获取groups[0]的四张花色牌
            List<Sprite> groupSprites = (themeSpritesHolder.Unreal != null && themeSpritesHolder.Unreal.Count > 0 && themeSpritesHolder.Unreal[0].Reasonable.Count >= 4)
                ? themeSpritesHolder.Unreal[0].Reasonable
                : null;
            // 获取普通牌
            List<Sprite> simpleBroadly= themeSpritesHolder.simpleBroadly;
            // 1、3、4、10号（下标0、2、3、9）用花色牌
            int[] groupIdx = { 0, 2, 3, 9 };
            for (int i = 0; i < groupIdx.Length; i++)
            {
                int idx = groupIdx[i];
                if (idx < allTiles.Count && groupSprites != null)
                {
                    allTiles[idx].OldCorpse(groupSprites[i]);
                }
            }
            // 重点：第10张麻将（索引9）前置渲染顺序
            // 2、8号（下标1、7）用sprites[1]
            int[] idx2 = { 1, 7 };
            foreach (int idx in idx2)
            {
                if (idx < allTiles.Count && simpleBroadly.Count > 1)
                {
                    allTiles[idx].OldCorpse(simpleBroadly[0]);
                }
            }
            // 5、6号（下标4、5）用sprites[2]
            int[] idx3 = { 4, 5 };
            foreach (int idx in idx3)
            {
                if (idx < allTiles.Count && simpleBroadly.Count > 2)
                {
                    allTiles[idx].OldCorpse(simpleBroadly[1]);
                }
            }
            // 7、9号（下标6、8）设为金麻将
            int[] goldIdx = { 6, 8 };
            foreach (int idx in goldIdx)
            {
                if (idx < allTiles.Count)
                {
                    allTiles[idx].OldHallVogue(true);
                }
            }
            // 其他未分配的牌可置空或随机
            for (int i = 0; i < allTiles.Count; i++)
            {
                if (allTiles[i].MCorpse == null && !allTiles[i].PriestTrim)
                {
                    allTiles[i].OldCorpse(simpleBroadly[0]);
                }
            }
            // 重置渲染顺序
            foreach (var tile in Weaver.GetComponentsInChildren<AngularTrim>(true))
            {
                tile.OldDyEmpty(false);
            }
            Debug.Log("SetMahjongSpritesForLevel2 完成");
            onComplete?.Invoke();
        }

        // 性能优化：复用集合，避免重复创建
        private List<AngularTrim> NomadismBoldToBrimCramp= new List<AngularTrim>(200); // 预分配容量

        private List<AngularTrim> HowBoldDyBrimCramp(List<AngularTrim> fromTiles, bool shuffle, bool sortByLayerReverse)
        {
            // 性能优化：复用集合，避免重复创建
            var result = NomadismBoldToBrimCramp;
            result.Clear();

            // 预分配容量，减少扩容开销
            if (result.Capacity < fromTiles.Count)
            {
                result.Capacity = fromTiles.Count;
            }

            // 直接筛选，避免多次RemoveAll调用
            foreach (var tile in fromTiles)
            {
                if (tile != null && !tile.Outskirt && tile.IDBoldDyBrim())
                {
                    result.Add(tile);
                }
            }

            if (shuffle) result.Seminar();
            if (sortByLayerReverse) result.Sort((a, b) => { return b.Layer.CompareTo(a.Layer); });
            return result;
        }
        #endregion fill sprites

        public void GiantDrawSoda()
        {
            Color color = Color.red;
            foreach (var item in Rite)
            {
                Vector3 pos_1 = item[0].transform.position;
                Vector3 pos_2 = item[item.Length - 1].transform.position;
                Debug.DrawLine(pos_1, pos_2, color);
            }
        }

        /// <summary>
        /// shuffle tiles in current positions
        /// </summary>
        public void SeminarSodaBroadly()
        {
            List<SodaLime> gridCells = new List<SodaLime>();
            List<AngularTrim> mahjongTiles = new List<AngularTrim>(Weaver.GetComponentsInChildren<AngularTrim>(true));
            mahjongTiles.ForEach((t) => { t.OldOutskirt(false); });
            List<SpritesPair> spritesPairs = new List<SpritesPair>();

            while (mahjongTiles.Count > 0)   // get the list of match pairs
            {
                var mTile = mahjongTiles[0];
                mahjongTiles.RemoveAt(0);
                AngularTrim pairTile = null;
                foreach (var item in mahjongTiles)
                {
                    if (mTile.CorpseOilEarnerWest(item.MCorpse))
                    {
                        pairTile = item;
                        SpritesPair freePaar = new SpritesPair(mTile.MCorpse, item.MCorpse);
                        spritesPairs.Add(freePaar);
                        break;
                    }
                }
                mahjongTiles.Remove(pairTile);
            }

            mahjongTiles = new List<AngularTrim>(Weaver.GetComponentsInChildren<AngularTrim>(true));
            bool failed = false;
            foreach (var item in spritesPairs)
            {
                List<AngularTrim> freeTiles = HowBoldDyBrimCramp(mahjongTiles, true, true); // reverse sorted
                if (freeTiles.Count == 1)
                {
                    failed = true;
                    break;
                }
                AngularTrim t1 = freeTiles[0];
                AngularTrim t2 = freeTiles[1];
                freeTiles[0].OldOutskirt(true);
                freeTiles[1].OldOutskirt(true);
                t1.OldCorpse(item.Attain_1);
                t2.OldCorpse(item.Attain_2);
            }
            if (failed) Debug.LogError("!!! MIX FAILED !!!");
        }

        public void QuietlyAngularBroadly(ReactBroadlyMisery oldTheme, ReactBroadlyMisery newTheme)
        {
            Dictionary<Sprite, Sprite> res = LullHandleMisery.Whatever.HowBroadlyAccumulate(oldTheme, newTheme);
            AngularTrim[] tT = Weaver.GetComponentsInChildren<AngularTrim>();
            foreach (var item in tT)
            {
                item.OldCorpse(res[item.MCorpse]);
            }
        }

        public void OldBlade(float scale)
        {
            Weaver.localScale = new Vector3(scale, scale, scale);
        }


        /// <summary>
        /// Is it possible to shuffle tiles in current positions?
        /// </summary>
        /// <returns></returns>
        public bool OilSeminar()
        {
            List<AngularTrim> mahjongTiles = new List<AngularTrim>(Weaver.GetComponentsInChildren<AngularTrim>(true));
            mahjongTiles.ForEach((t) => { t.OldOutskirt(false); });
            List<AngularTrim> freeTiles;
            for (int i = 0; i < mahjongTiles.Count; i += 2)
            {
                freeTiles = HowBoldDyBrimCramp(mahjongTiles, false, false);
                if (freeTiles.Count == 1)
                {
                    return false;
                }
                freeTiles[0].OldOutskirt(true);
                freeTiles[1].OldOutskirt(true);
            }
            return true;
        }

        /// <summary>
        /// shuffle tiles into new positions
        /// </summary>
        public void HardSeminar()
        {
            List<AngularTrim> mahjongTiles = new List<AngularTrim>(Weaver.GetComponentsInChildren<AngularTrim>(true));
            mahjongTiles.ForEach((t) => { t.OldOutskirt(false); });
            List<SpritesPair> spritesPairs = new List<SpritesPair>();

            while (mahjongTiles.Count > 0)   // get the list of match pairs
            {
                var mTile = mahjongTiles[0];
                mahjongTiles.RemoveAt(0);
                AngularTrim pairTile = null;
                foreach (var item in mahjongTiles)
                {
                    if (mTile.CorpseOilEarnerWest(item.MCorpse))
                    {
                        pairTile = item;
                        SpritesPair freePaar = new SpritesPair(mTile.MCorpse, item.MCorpse);
                        spritesPairs.Add(freePaar);
                        break;
                    }
                }
                mahjongTiles.Remove(pairTile);
            }
            Acorn.ForEach((c) => { c.OceaniaSodaCoconut(); });
            int tilesCount = spritesPairs.Count * 2;
            OldCoconutSoul(LcOld, GameMode.Play, tilesCount);
            Exist.ForEach((t) => { t.OldOutskirt(false); });
            List<AngularTrim> tT = new List<AngularTrim>(Exist);

            bool failed = false;
            for (int i = 0; i < tT.Count; i += 2)
            {
                List<AngularTrim> freeTiles = HowBoldDyBrimCramp(Exist, true, true); // reverse sorted
                if (freeTiles.Count == 1)
                {
                    failed = true;
                    break;
                }
                AngularTrim t1 = freeTiles[0];
                AngularTrim t2 = freeTiles[1];
                freeTiles[0].OldOutskirt(true);
                freeTiles[1].OldOutskirt(true);
                SpritesPair s = spritesPairs[i / 2];
                t1.OldCorpse(s.Attain_1);
                t2.OldCorpse(s.Attain_2);
            }
            if (failed) Debug.LogError("!!!HARD MIX FAILED!!!");
        }
    }
}