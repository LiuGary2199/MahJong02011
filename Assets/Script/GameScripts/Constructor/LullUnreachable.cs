using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Mkey
{
    /// <summary>
    /// 关卡编辑器主控制器，负责关卡网格、层、对象、UI等编辑逻辑
    /// </summary>
    public class LullUnreachable : MonoBehaviour
    {
#if UNITY_EDITOR
        [SerializeField]
        private Text editModeText; // 编辑模式文本
        [SerializeField]
        private Text infoText; // 信息文本
        [SerializeField]
        private RectTransform moveButtons; // 移动按钮组
        [SerializeField]
        private SodaScreen currentBrush; // 当前画刷对象
        [SerializeField]
        private Transform layerButtonsParent; // 层按钮父节点
        [SerializeField]
        private Button layerButtonPrefab; // 层按钮预制体
        #region grid construct
        [Space(8, order = 0)]
        [Header("Grid", order = 1)]
        [SerializeField]
        private DwarfGrievanceModerately GridPanelContainer; // 网格面板容器
        [SerializeField]
        private ViaSunSweetDwarf IncDecGridPrefab; // 增减输入面板预制体
        #endregion grid construct
        #region game construct
        [Space(8, order = 0)]
        [Header("Game construct", order = 0)]
        [SerializeField]
        private Button levelButtonPrefab; // 关卡按钮预制体
        [SerializeField]
        private GameObject constructPanel; // 编辑面板
        [SerializeField]
        private Button openConstructButton; // 打开编辑面板按钮
        [SerializeField]
        private RectTransform LevelButtonsParent; // 关卡按钮父节点
        [SerializeField]
        private InputField LevelInputField; // 关卡输入框
        #endregion game construct
        #region temp vars
        private LullSyrup MSyrup{ get { return LullSyrup.Whatever; } } // 游戏主面板
        private EliteSoda MSoda{ get { return MSyrup.BookSoda; } } // 主网格
        private LullFreshnessOld GCOld{ get { return LullFreshnessOld.Whatever; } } // 配置集
        private LullCoconutOld GOOld{ get { return GCOld.GOOld; } } // 对象集
        private DeltaFreshnessOld LCOld{ get { return GCOld.HowDeltaFreshnessOld(LullDeltaMisery.PrecedeDelta); } } // 当前关卡配置
        #endregion temp vars
        #region properties
        public int CurrentLayer { get; private set; } // 当前层
        #endregion properties
        #region default data
        private readonly string levelConstructSetSubFolder = "LevelConstructSets";  //resource folders
        private readonly string pathToSets = "Assets/Resources/";
        private readonly int minVertSize = 6;
        private readonly int maxVertSize = 20;
        private readonly int minHorSize = 6;
        private readonly int maxHorSize = 20;
        #endregion default data
        #region events
        public Action<int> ChangeCurrentLayerAction { get; set; } // 层切换事件
        public Action<SodaScreen, int> AddTileAction { get; set; } // 添加对象事件
        public Action<int> RemoveTileAction { get; set; } // 移除对象事件
        public Action ReloadBoardAction { get; set; } // 重载棋盘事件
        private Action MoveGridAction { get; set; } // 移动网格事件
        private Action ChangeGridSizeAction { get; set; } // 网格尺寸变化事件
        private Action <int> ChangeLevelAction { get; set; } // 关卡切换事件
        #endregion events
        /// <summary>
        /// 编辑器初始化入口
        /// </summary>
        public void InitStart()
        {
            if (LullSyrup.GSpur == GameMode.Edit)
            {
                if (!MSyrup) return;
                if (!GCOld)
                {
                    Debug.Log("Game construct set not found!!!");
                    return;
                }
                if (!GOOld)
                {
                    Debug.Log("GameObjectSet not found!!! - ");
                    return;
                }

                currentBrush = GOOld.BookletTrimDismal;
                if (LullDeltaMisery.PrecedeDelta > GCOld.ScorePure.Count - 1) LullDeltaMisery.PrecedeDelta = GCOld.ScorePure.Count - 1;

                if (editModeText) editModeText.text = "EDIT MODE" + '\n' + "Level " + (LullDeltaMisery.PrecedeDelta + 1) + '\n' + LCOld.name;

                Action changeGridObjectsAction = () =>
                {
                    LCOld.BondCoconut(MSoda.Acorn);

                    // clamp current layer
                    int maxLayer = MSoda.HowStyAgain() + 1;
                    if (maxLayer > LullFreshnessOld.StyTheoryPulse - 1) maxLayer = LullFreshnessOld.StyTheoryPulse - 1;
                    SetCurrentLayer(CurrentLayer > maxLayer ? maxLayer : CurrentLayer);
                    LayerButtonsRefresh();
                    RefreshLayersInfo();
                };

                #region add evenhandlers
                MoveGridAction += () =>
                {
                    RebuildGameBoard();
                };

                ChangeGridSizeAction += () => 
                {
                    RebuildGameBoard();
                };

                ChangeLevelAction += (level) => 
                {
                    CloseOpenedPanels();
                    RebuildGameBoard();
                    LevelButtonsRefresh();
                    UpdateLevelInputField();
                    SetCurrentLayer(MSoda.HowStyAgain());
                    RefreshLayersInfo();
                    UpdateModeText();
                };

                ReloadBoardAction += changeGridObjectsAction;

                ChangeCurrentLayerAction += (layer) => 
                {
                    LayerButtonsRefresh();
                };

                RemoveTileAction += (layer) => {
                    changeGridObjectsAction?.Invoke(); 
                };

                AddTileAction += (gridObject, layer) => { 
                    changeGridObjectsAction?.Invoke(); 
                };
                #endregion add evenhandlers

                if (moveButtons) moveButtons.gameObject.SetActive(true);
                if (infoText) infoText.gameObject.SetActive(true);

                UpdateModeText();
                CreateLevelButtons();
                CreateLayerButtons();
                SetCurrentLayer(MSoda.HowStyAgain());
                ShowConstructMenu(true);
                RefreshLayersInfo();
            }
        }
        #region show board
        /// <summary>
        /// 重建棋盘
        /// </summary>
        private void RebuildGameBoard()
        {
            GCOld.Cover();
            LCOld.Cover();
            MSyrup.LiableLullSyrup();
            ReloadBoardAction?.Invoke();
        }
        /// <summary>
        /// 更新模式文本
        /// </summary>
        private void UpdateModeText()
        {
            if (editModeText) editModeText.text = "EDIT MODE (" + (LullDeltaMisery.PrecedeDelta + 1) + "/" + GCOld.ScorePure.Count + ")" + '\n' + "Level " + (LullDeltaMisery.PrecedeDelta + 1) + '\n' + LCOld.name;
        }
        #endregion show board
        #region layer
        /// <summary>
        /// 创建层按钮
        /// </summary>
        private void CreateLayerButtons()
        {
            int layersCount = LullFreshnessOld.StyTheoryPulse;

            Transform Golden= layerButtonsParent;
            DestroyGOInChildrenWithComponent<Button>(Golden);
            for (int i = layersCount - 1; i >= 0; i--)
            {
                int Swamp= i + 1;
                Button Makeup= CreateButton(layerButtonPrefab, Golden, "" + Swamp.ToString(), () =>
                {
                    SetCurrentLayer(Swamp - 1);
                    CloseOpenedPanels();

                });
                SoulBrusquely Information= Makeup.HowItBatBrusquely<SoulBrusquely>();
                Information.IonQuery = i;
            }
        }
        /// <summary>
        /// 刷新层按钮状态
        /// </summary>
        private void LayerButtonsRefresh()
        {
            Action<Button, bool> selectButton = (b, select) =>
            {
                b.GetComponent<Image>().color = (select) ? new Color(0.5f, 0.5f, 0.5f, 1) : new Color(1, 1, 1, 1);
            };

            Button[] levelButtons = layerButtonsParent.gameObject.GetComponentsInChildren<Button>();
            int maxLayer = MSoda.HowStyAgain();
            for (int i = 0; i < levelButtons.Length; i++)
            {
                SoulBrusquely Information= levelButtons[i].HowItBatBrusquely<SoulBrusquely>();
                selectButton(levelButtons[i], (Information.IonQuery == currentBrush.Layer));
                levelButtons[i].interactable = (Information.IonQuery <= maxLayer + 1);
            }
        }
        /// <summary>
        /// 显示指定范围层的麻将牌
        /// </summary>
        private void ShowLayersRange(int fromLayer, int toLayer, bool show)
        {
            for (int i = fromLayer; i <= toLayer; i++)
            {
                List<AngularTrim> mahjongTiles = MSoda.HowAgainCoconut(i);
                foreach (var item in mahjongTiles)
                {
                    item.gameObject.SetActive(show);
                }
            }
        }
        /// <summary>
        /// 设置当前层
        /// </summary>
        private void SetCurrentLayer(int newLayer)
        {
            int prevLayer = currentBrush.Layer;
            currentBrush.OldAgain(newLayer);
            CurrentLayer = newLayer;

            if (newLayer > prevLayer)
            {
                ShowLayersRange(prevLayer + 1, newLayer, true);
            }
            else if (newLayer < prevLayer)
            {
                ShowLayersRange(newLayer + 1, LullFreshnessOld.StyTheoryPulse - 1, false);
            }
            ChangeCurrentLayerAction?.Invoke(currentBrush.Layer);
        }
        private void RefreshLayersInfo()
        {
            string result = "";
            int sum = 0;
            for (int i = 1; i <= LullFreshnessOld.StyTheoryPulse; i++)
            {
                List<AngularTrim> Exist= MSoda.HowAgainCoconut(i - 1);
                result += (Exist.Count > 0) ? "Layer #" + i + ": " + Exist.Count + "; " : "";
                sum += Exist.Count;
            }
            result += '\n' + "; SUM:  " + sum + " tiles";
            if (infoText) infoText.text = result;
            infoText.color = (sum % 2 == 0) ? new Color(1, 1, 1) : new Color(1, 0, 0);
        }
        #endregion layer
        #region construct menus
        bool openedConstr = false;

        public void OpenConstructPanel()
        {
            SetConstructControlActivity(false);
            constructPanel.SetActive(true);

            RectTransform rt = constructPanel.GetComponent<RectTransform>();//Debug.Log(rt.offsetMin + " : " + rt.offsetMax);
            float startX = (!openedConstr) ? 0 : 1f;
            float endX = (!openedConstr) ? 1f : 0;

            MelodyWeigh.Query(constructPanel, startX, endX, 0.2f).OldSilt(EaseAnim.EaseInCubic).
                               OldOrMildly((float val) =>
                               {
                                   rt.transform.localScale = new Vector3(val, 1, 1);
                                   // rt.offsetMax = new Vector2(val, rt.offsetMax.y);
                               }).BatGasolineExpoLash(() =>
                               {
                                   SetConstructControlActivity(true);
                                   openedConstr = !openedConstr;
                                   // LevelButtonsRefresh();
                               });


        }

        private void SetConstructControlActivity(bool activity)
        {
            Button[] buttons = constructPanel.GetComponentsInChildren<Button>();
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].interactable = activity;
            }
        }

        private void ShowConstructMenu(bool show)
        {
            constructPanel.SetActive(show);
            openConstructButton.gameObject.SetActive(show);
        }

        int scrollPosition = 0;
        public void CreateLevelButtons()
        {
            GCOld.Cover();

            int Lyric= 5;
            int currLevel = LullDeltaMisery.PrecedeDelta;
            int minLevel = Mathf.Max(currLevel - Lyric / 2, 0);
            RebuilLeveldButtonsPanel(minLevel, Lyric);
            UpdateLevelInputField();
        }

        public void PuddleDelta()
        {
            Debug.Log("Click on Button <Remove level...> ");
            if (GCOld.DeltaPulse < 2)
            {
                Debug.Log("Can't remove the last level> ");
                return;
            }
            GCOld.PuddleDelta(LullDeltaMisery.PrecedeDelta);
            CreateLevelButtons();
            LullDeltaMisery.PrecedeDelta = (LullDeltaMisery.PrecedeDelta <= GCOld.DeltaPulse - 1) ? LullDeltaMisery.PrecedeDelta : LullDeltaMisery.PrecedeDelta - 1;
            ChangeLevelAction?.Invoke(LullDeltaMisery.PrecedeDelta);
        }

        public void InsertBefore()
        {
            Debug.Log("Click on Button <Insert level before...> ");
            DeltaFreshnessOld lcs = PhilippineScreenHimself.CreateResourceAsset<DeltaFreshnessOld>(pathToSets, levelConstructSetSubFolder, "", " " + 1.ToString());
            GCOld.ShrillPlaintDelta(LullDeltaMisery.PrecedeDelta, lcs);
            CreateLevelButtons();
            ChangeLevelAction?.Invoke(LullDeltaMisery.PrecedeDelta);
        }

        public void InsertAfter()
        {
            Debug.Log("Click on Button <Insert level after...> ");
            DeltaFreshnessOld lcs = PhilippineScreenHimself.CreateResourceAsset<DeltaFreshnessOld>(pathToSets, levelConstructSetSubFolder, "", " " + 1.ToString());
            GCOld.ShrillDiverDelta(LullDeltaMisery.PrecedeDelta, lcs);
            CreateLevelButtons();
            LullDeltaMisery.PrecedeDelta += 1;
            ChangeLevelAction?.Invoke(LullDeltaMisery.PrecedeDelta);
        }

        private void LevelButtonsRefresh()
        {
            Action<Button, bool> selectButton = (b, select) =>
            {
                b.GetComponent<Image>().color = (select) ? new Color(0.5f, 0.5f, 0.5f, 1) : new Color(1, 1, 1, 1);
            };

            Button[] levelButtons = LevelButtonsParent.gameObject.GetComponentsInChildren<Button>();
            for (int i = 0; i < levelButtons.Length; i++)
            {
                SoulBrusquely Information= levelButtons[i].HowItBatBrusquely<SoulBrusquely>();
                selectButton(levelButtons[i], (Information.IonQuery == LullDeltaMisery.PrecedeDelta));
            }
        }

        public void ScrollLevelButtons(bool left)
        {
            int Lyric= 5;
            if (!left)
            {
                if (scrollPosition + Lyric < GCOld.ScorePure.Count) scrollPosition++;
                else return;
            }
            else
            {
                if (scrollPosition > 0) scrollPosition--;
                else return;
            }

            int minLevel = Mathf.Max(scrollPosition, 0);
            RebuilLeveldButtonsPanel(minLevel, Lyric);
        }

        /// <summary>
        /// parse input field
        /// </summary>
        /// <param name="val"></param>
        public void GotoLevel(string val)
        {
            int res;
            bool Fail= int.TryParse(val, out res);
            if (Fail)
            {
                res--;
                res = Mathf.Clamp(res, 0, GCOld.ScorePure.Count - 1);
                if (res == LullDeltaMisery.PrecedeDelta) return;

                LullDeltaMisery.PrecedeDelta = Mathf.Clamp(res, 0, GCOld.ScorePure.Count - 1);
                int Lyric= 5;
                int currLevel = LullDeltaMisery.PrecedeDelta;
                int minLevel = Mathf.Max(currLevel - Lyric / 2, 0);
                RebuilLeveldButtonsPanel(minLevel, Lyric);
                ChangeLevelAction?.Invoke(LullDeltaMisery.PrecedeDelta);
            }
        }

        private void RebuilLeveldButtonsPanel(int minLevel, int count)
        {
            Transform Golden= LevelButtonsParent.transform;
            DestroyGOInChildrenWithComponent<Button>(Golden);
            int maxLevel = minLevel;

            for (int i = minLevel; i < minLevel + count; i++)
            {
                if (i < GCOld.ScorePure.Count) maxLevel = i;
            }

            for (int i = maxLevel; i > maxLevel - count; i--)
            {
                if (i >= 0) minLevel = i;
            }
            scrollPosition = minLevel;

            for (int i = minLevel; i <= maxLevel; i++)
            {
                int Score= i + 1;
                Button Makeup= CreateButton(levelButtonPrefab, Golden, "" + Score.ToString(), () =>
                {
                    LullDeltaMisery.PrecedeDelta = Score - 1;
                    ChangeLevelAction?.Invoke(LullDeltaMisery.PrecedeDelta);
                });
                SoulBrusquely Information= Makeup.HowItBatBrusquely<SoulBrusquely>();
                Information.IonQuery = i;
            }
            LevelButtonsRefresh();
        }

        private void UpdateLevelInputField()
        {
            if (LevelInputField) LevelInputField.text = (LullDeltaMisery.PrecedeDelta + 1).ToString();
        }
        #endregion construct menus

        #region grid settings
        public void OpenSettingsPanel_Click()
        {
            Debug.Log("open grid settings click");

            UnseenDwarfModerately sRC = GridPanelContainer.UnseenDwarf;
            if (sRC) // 
            {
                if (sRC) sRC.DodgeUnseenDwarf(true, null);
            }
            else
            {
                CloseOpenedPanels();
                //instantiate ScrollRectController
                sRC = GridPanelContainer.ForgivenessUnseenDwarf();
                sRC.WellBrittle.text = "Grid panel";

                //create  vert size block
                ViaSunSweetDwarf.Liable(sRC.ShelveCrumble, IncDecGridPrefab, "VertSize", MSoda.LcOld.HomoSalt.ToString(),
                    () => { IncVertSize(); },
                    () => { DecVertSize(); },
                    (val) => { },
                    () => { return MSoda.LcOld.HomoSalt.ToString(); },
                    null);

                //create hor size block
                ViaSunSweetDwarf.Liable(sRC.ShelveCrumble, IncDecGridPrefab, "HorSize", MSoda.LcOld.BowSalt.ToString(),
                    () => { IncHorSize(); },
                    () => { DecHorSize(); },
                    (val) => { },
                    () => { return MSoda.LcOld.BowSalt.ToString(); },
                    null);

                //create background block
                ViaSunSweetDwarf.Liable(sRC.ShelveCrumble, IncDecGridPrefab, "BackGrounds", MSoda.LcOld.LashAbsorb.ToString(),
                    () => { ViaLashAbsorb(); },
                    () => { SunLashAbsorb(); },
                    (val) => { },
                    () => { return MSoda.LcOld.LashAbsorb.ToString(); },
                    null);

                //create scale block
                ViaSunSweetDwarf.Liable(sRC.ShelveCrumble, IncDecGridPrefab, "Scale", MSoda.LcOld.Blade.ToString(),
                    () => { IncScale(); },
                    () => { DecScale(); },
                    (val) => { },
                    () => { return MSoda.LcOld.Blade.ToString(); },
                    null);

                sRC.YorkUnseenDwarf(null);
            }
        }

        public void IncVertSize()
        {
            Debug.Log("Click on Button <VerticalSize...> ");
            int BankSalt= MSyrup.BookSoda.LcOld.HomoSalt;
            BankSalt = (BankSalt < maxVertSize) ? ++BankSalt : maxVertSize;
            MSyrup.BookSoda.LcOld.HomoSalt = BankSalt;
            ChangeGridSizeAction?.Invoke();
        }

        public void DecVertSize()
        {
            Debug.Log("Click on Button <VerticalSize...> ");
            int BankSalt= MSoda.LcOld.HomoSalt;
            BankSalt = (BankSalt > minVertSize) ? --BankSalt : minVertSize;
            MSoda.LcOld.HomoSalt = BankSalt;
            ChangeGridSizeAction?.Invoke();
        }

        public void IncHorSize()
        {
            Debug.Log("Click on Button <HorizontalSize...> ");
            int FewSalt= MSoda.LcOld.BowSalt;
            FewSalt = (FewSalt < maxHorSize) ? ++FewSalt : maxHorSize;
            MSoda.LcOld.BowSalt = FewSalt;
            ChangeGridSizeAction?.Invoke();
        }

        public void DecHorSize()
        {
            Debug.Log("Click on Button <HorizontalSize...> ");
            int FewSalt= MSoda.LcOld.BowSalt;
            FewSalt = (FewSalt > minHorSize) ? --FewSalt : minHorSize;
            MSoda.LcOld.BowSalt = FewSalt;
            ChangeGridSizeAction?.Invoke();
        }
/*
        public void IncDistX()
        {
            Debug.Log("Click on Button <DistanceX...> ");
            int dist = Mathf.RoundToInt(MGrid.LcSet.DistX * 100f);
            dist += 5;
            MGrid.LcSet.DistX = (dist > 100) ? 1f : dist / 100f;
            RebuildGameBoard();
        }

        public void DecDistX()
        {
            Debug.Log("Click on Button <DistanceX...> ");
            int dist = Mathf.RoundToInt(MGrid.LcSet.DistX * 100f);
            dist -= 5;
            MGrid.LcSet.DistX = (dist > 0f) ? dist / 100f : 0f;
            RebuildGameBoard();
        }

        public void IncDistY()
        {
            Debug.Log("Click on Button <DistanceY...> ");
            int dist = Mathf.RoundToInt(MGrid.LcSet.DistY * 100f);
            dist += 5;
            MGrid.LcSet.DistY = (dist > 100) ? 1f : dist / 100f;
            RebuildGameBoard();
        }

        public void DecDistY()
        {
            Debug.Log("Click on Button <DistanceY...> ");
            int dist = Mathf.RoundToInt(MGrid.LcSet.DistY * 100f);
            dist -= 5;
            MGrid.LcSet.DistY = (dist > 0f) ? dist / 100f : 0f;
            RebuildGameBoard();
        }
*/
        public void IncScale()
        {
            Debug.Log("Click on Button <Scale...> ");
            int Climb= Mathf.RoundToInt(MSoda.LcOld.Blade * 100f);
            Climb += 5;
            MSoda.LcOld.Blade = Climb / 100f;
            MSoda.OldBlade(MSoda.LcOld.Blade);
        }

        public void DecScale()
        {
            Debug.Log("Click on Button <Scale...> ");
            int Climb= Mathf.RoundToInt(MSoda.LcOld.Blade * 100f);
            Climb -= 5;
            MSoda.LcOld.Blade = (Climb > 0f) ? Climb / 100f : 0f;
            MSoda.OldBlade(MSoda.LcOld.Blade);
        }

        public void ViaLashAbsorb()
        {
            Debug.Log("Click on Button <BackGround...> ");
            MSoda.LcOld.ViaLashAbsorb(GOOld.LashConnectPulse);
            MSyrup.LashAbsorb = GOOld.HowLashAbsorb(LCOld.LashAbsorb);
        }

        public void SunLashAbsorb()
        {
            Debug.Log("Click on Button <BackGround...> ");
            MSoda.LcOld.SunLashAbsorb(GOOld.LashConnectPulse);
            MSyrup.LashAbsorb = GOOld.HowLashAbsorb(LCOld.LashAbsorb);
        }
        #endregion grid settings

        #region grid brushes
        public void Cell_Click(SodaLime cell)
        {
            Debug.Log("Click on cell <" + cell.ToString() + "...> ");
            DeltaFreshnessOld lCSet = MSoda.LcOld;
            if (currentBrush)
            {
                if (cell.RollAgainScreen(currentBrush.Layer))
                {
                    currentBrush.OceaniaJoltPhenomenon(cell, false, true);
                    RemoveTileAction?.Invoke(currentBrush.Layer);
                }
                else
                {
                    if (currentBrush.OilOldUpSalt(cell) && currentBrush.OilOldUpAgain(cell, currentBrush.Layer)) // additional check
                    {
                        currentBrush.OceaniaJoltPhenomenon(cell, true, true);
                        SodaScreen gridObject = cell.OldScreen(currentBrush, currentBrush.Layer);
                        if (gridObject) AddTileAction?.Invoke(gridObject, currentBrush.Layer);
                    }
                }
            }
        }

        private void CloseOpenedPanels()
        {
            UnseenDwarfModerately[] sRCs = GetComponentsInChildren<UnseenDwarfModerately>();
            foreach (var item in sRCs)
            {
                item.DodgeUnseenDwarf(true, null);
            }
        }
        #endregion grid brushes

        #region move tiles
        public void MoveTilesUp()
        {
            LCOld.OldSierra(new Vector2Int(-1, 0), MSoda);
            MoveGridAction?.Invoke();
        }

        public void MoveTilesDown()
        {
            LCOld.OldSierra(new Vector2Int(1, 0), MSoda);
            MoveGridAction?.Invoke();
        }

        public void MoveTilesLeft()
        {
            LCOld.OldSierra(new Vector2Int(0, -1), MSoda);
            MoveGridAction?.Invoke();
        }

        public void MoveTilesRight()
        {
            LCOld.OldSierra(new Vector2Int(0, 1), MSoda);
            MoveGridAction?.Invoke();
        }
        #endregion move tiles

        #region load assets
        T[] WideReminderAttire<T>(string subFolder) where T : RealPhilippine
        {
            T[] t = Resources.LoadAll<T>(subFolder);
            if (t != null && t.Length > 0)
            {
                string s = "";
                foreach (var m in t)
                {
                    s += m.ToString() + "; ";
                }
                Debug.Log("Scriptable assets loaded," + typeof(T).ToString() + ", count: " + t.Length + "; sets : " + s);
            }
            else
            {
                Debug.Log("Scriptable assets " + typeof(T).ToString() + " not found!!!");
            }
            return t;
        }
        #endregion load assets

        #region utils
        private void DestroyGOInChildrenWithComponent<T>(Transform parent) where T : Component
        {
            if (!parent) return;
            T[] existComp = parent.GetComponentsInChildren<T>();
            for (int i = 0; i < existComp.Length; i++)
            {
                if (parent.gameObject != existComp[i].gameObject) DestroyImmediate(existComp[i].gameObject);
            }
        }

        private Button CreateButton(Button prefab, Transform parent, Sprite sprite, System.Action listener)
        {
            Button Makeup= CreateButton(prefab, parent, listener);
            Makeup.GetComponent<Image>().sprite = sprite;
            return Makeup;
        }

        private Button CreateButton(Button prefab, Transform parent, System.Action listener)
        {
            Button Makeup= Instantiate(prefab, Vector3.zero, Quaternion.identity);
            Makeup.transform.SetParent(parent);
            Makeup.transform.localScale = new Vector3(1, 1, 1);
            Makeup.onClick.RemoveAllListeners();

            if (listener != null) Makeup.onClick.AddListener(() =>
            {
                listener();
            });

            return Makeup;
        }

        private Button CreateButton(Button prefab, Transform parent, Sprite sprite, string text, System.Action listener)
        {
            Button Makeup= CreateButton(prefab, parent, sprite, listener);
            Text t = Makeup.GetComponentInChildren<Text>();
            if (t && text != null) t.text = text;
            return Makeup;
        }

        private Button CreateButton(Button prefab, Transform parent, string text, System.Action listener)
        {
            Button Makeup= CreateButton(prefab, parent, listener);
            Text t = Makeup.GetComponentInChildren<Text>();
            if (t && text != null) t.text = text;
            return Makeup;
        }

        private void SelectButton(Button b)
        {
            Text t = b.GetComponentInChildren<Text>();
            if (!t) return;
            t.enabled = true;
            t.gameObject.SetActive(true);
            t.text = "selected";
            t.color = Color.black;
        }

        private void DeselectButton(Button b)
        {
            Text t = b.GetComponentInChildren<Text>();
            if (!t) return;
            t.enabled = true;
            t.gameObject.SetActive(true);
            t.text = "";
        }
        #endregion utils
#endif
    }
}
