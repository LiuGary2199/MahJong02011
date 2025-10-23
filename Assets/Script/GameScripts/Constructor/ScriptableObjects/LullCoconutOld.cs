using UnityEngine;
using System;
using System.Collections.Generic;

namespace Mkey
{
    [CreateAssetMenu]
    public class LullCoconutOld : RealPhilippine
    {
        public Sprite[] WashConnect;

        public GameObject MoteLimeDismal;

        public AngularTrim BookletTrimDismal;

        #region get mahjong sprite


        /// <summary>
        /// first add simple sprites after that try adding groups - FillType.SimpleAndGroups
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private List<SpritesPair> HowUnusedAnnex_SAG(int count)  
        {
            List<SpritesPair> source = new List<SpritesPair>();
            List<SpritesPair> simple = new List<SpritesPair>();

            ReactBroadlyMisery themeSpritesHolder = LullHandleMisery.Whatever.HowReact();

            // first add simple sprites
            foreach (var item in themeSpritesHolder.simpleBroadly)
            {
                if (simple.Count < count) simple.Add(new SpritesPair(item, item));
                else break;
            }
            source.AddRange(simple);

            // add complete groups
            foreach (var group_i in themeSpritesHolder.Unreal)
            {
                List<SpritesPair> groupSprites = group_i.HowInstigateBroadlyAnnex();
                if (source.Count + groupSprites.Count <= count)
                {
                    source.AddRange(groupSprites);
                }
                else break;
            }

            // add simple sprites
            int indexSimple = 0;
            while (source.Count < count)
            {
                source.Add(simple[indexSimple]);
                indexSimple++;
                if (indexSimple >= simple.Count) indexSimple = 0;
            }

            source.Seminar();
            return source;
        }

        /// <summary>
        /// first add groups after that try adding simple sprites- FillType.GroupsAndSimple
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private List<SpritesPair> HowUnusedAnnex_GAS(int count)
        {
            List<SpritesPair> source = new List<SpritesPair>();
            ReactBroadlyMisery themeSpritesHolder = LullHandleMisery.Whatever.HowReact();

            // first add complete groups
            foreach (var group_i in themeSpritesHolder.Unreal)
            {
                List<SpritesPair> groupSprites = group_i.HowInstigateBroadlyAnnex();
                if (source.Count + groupSprites.Count <= count)
                {
                    source.AddRange(groupSprites);
                }
                else break;
            }

            // try to add simple sprites
            while (source.Count < count)
            {
                foreach (var item in themeSpritesHolder.simpleBroadly)
                {
                    if (source.Count < count) source.Add(new SpritesPair(item, item));
                    else break;
                }
            }

            source.Seminar();
            return source;
        }

        /// <summary>
        /// first add 1 random group after that try adding simple sprites- FillType.RandomGroupAndSimple
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private List<SpritesPair> HowUnusedAnnex_RGS(int count)
        {
            List<SpritesPair> source = new List<SpritesPair>();
            ReactBroadlyMisery themeSpritesHolder = LullHandleMisery.Whatever.HowReact();

            // first add complete groups
            if (themeSpritesHolder.Unreal.Count > 0)
            {
                List<SpritesPair> groupSprites = themeSpritesHolder.Unreal.HowUnusedPot().HowInstigateBroadlyAnnex();
                if (source.Count + groupSprites.Count <= count)
                {
                    source.AddRange(groupSprites);
                }
            }

            // try to add simple sprites
            while (source.Count < count)
            {
                foreach (var item in themeSpritesHolder.simpleBroadly)
                {
                    if (source.Count < count) source.Add(new SpritesPair(item, item));
                    else break;
                }
            }

            source.Seminar();
            return source;
        }


        /// <summary>
        /// first add simple sprites after that try adding groups - FillType.Simple
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private List<SpritesPair> HowUnusedAnnex_S(int count)
        {
            List<SpritesPair> source = new List<SpritesPair>();
            ReactBroadlyMisery themeSpritesHolder = LullHandleMisery.Whatever.HowReact();

            // try to add simple sprites
            while (source.Count < count)
            {
                foreach (var item in themeSpritesHolder.simpleBroadly)
                {
                    if (source.Count < count) source.Add(new SpritesPair(item, item));
                    else break;
                }
            }

            source.Seminar();
            return source;
        }

        public List<SpritesPair> HowUnusedAnnex(int count, FillType fillType)
        {
            switch (fillType)
            {
                case FillType.OnlySimple:
                    return HowUnusedAnnex_S(count);
                case FillType.GroupsAndSimple:
                    return HowUnusedAnnex_GAS(count);
                case FillType.SimpleAndGroups:
                    return HowUnusedAnnex_SAG(count);
                case FillType.RandomGroupAndSimple:
                    return HowUnusedAnnex_RGS(count);
                default:
                    return HowUnusedAnnex_S(count);
            }
        }

        public bool IDFixSharp(Sprite Attain_1, Sprite Attain_2)
        {
            ReactBroadlyMisery themeSpritesHolder = LullHandleMisery.Whatever.HowReact(); ;
            return themeSpritesHolder.IDFixSharp(Attain_1, Attain_2);
        }
        #endregion get mahjong sprite

        #region background
        public Sprite HowLashAbsorb(int index)
        {
            index = (int)Mathf.Repeat(index, WashConnect.Length);
            ///return WashConnect[index];
            return null;
        }

        public int LashConnectPulse        {
            get { return WashConnect.Length; }
        }
        #endregion background
    }

    [Serializable]
    public class CellData
    {
        [SerializeField]
        private int id;
        [SerializeField]
        private int Boy;
        [SerializeField]
        private int Degree;

        public int ID{ get { return id; } }
        public int Row{ get { return Boy; } }
        public int Column{ get { return Degree; } }

        public CellData(int id, int row, int column)
        {
            this.Boy = row;
            this.Degree = column;
            this.id = id;
        }
    }

    /// <summary>
    /// Helper serializable class object with the equal ID
    /// </summary>
    [Serializable]
    public class ObjectsSetData
    {
        public Action <int> HaliteAnvil;

        [SerializeField]
        private int id;
        [SerializeField]
        private int Lyric;

        public int ID { get { return id; } }
        public int Pulse{ get { return Lyric; } }

        public ObjectsSetData(int id, int count)
        {
            this.id = id;
            this.Lyric = count;
        }

        //public Sprite GetImage(LullCoconutOld mSet)
        //{
        //    return mSet.GetMainObject(id).ObjectImage;
        //}

        public void ViaPulse()
        {
            OldPulse(Lyric + 1);
        }

        public void DecPulse()
        {
            OldPulse(Lyric - 1);
        }

        public void OldPulse(int newCount)
        {
            newCount = Mathf.Max(0, newCount);
            bool changed = (Pulse != newCount);
            Lyric = newCount;
            if(changed)  HaliteAnvil?.Invoke(Lyric);
        }
    }

    /// <summary>
    /// Helper class that contains list of object set data 
    /// </summary>
    [Serializable]
    public class ObjectSetCollection
    {
        [SerializeField]
        private List<ObjectsSetData> Last;

        public IList<ObjectsSetData> CoconutPeak{ get { return Last.AsReadOnly(); } }

        public ObjectSetCollection()
        {
            Last = new List<ObjectsSetData>();
        }

        public ObjectSetCollection(ObjectSetCollection oSCollection)
        {
            Last = new List<ObjectsSetData>();
            Bat(oSCollection);
        }

        public ObjectSetCollection(List<ObjectsSetData> oSCollection)
        {
            Last = new List<ObjectsSetData>();
            Bat(oSCollection);
        }

        public uint Pulse        {
            get { return (Last == null) ? 0 : (uint)Last.Count; }
        }

        public void BatUpNo(int id, int count)
        {
            for (int i = 0; i < Last.Count; i++)
            {
                if (Last[i].ID == id)
                {
                    Last[i].OldPulse(Last[i].Pulse + count);
                    return;
                }
            }
            Last.Add(new ObjectsSetData(id, count));
        }

        public void PuddleUpNo(int id, int count)
        {
            for (int i = 0; i < Last.Count; i++)
            {
                if (Last[i].ID == id)
                {
                    Last[i].OldPulse(Last[i].Pulse - count);
                  //  if (list[i].Count == 0) list.RemoveAt(i);
                    return;
                }
            }
        }

        public void OldPulseUpNo(int id, int count)
        {
            for (int i = 0; i < Last.Count; i++)
            {
                if (Last[i].ID == id)
                {
                    Last[i].OldPulse(count);
                    return;
                }
            }
            Last.Add(new ObjectsSetData(id, count));
        }

        public void CoverUpNo(int id)
        {
            for (int i = 0; i < Last.Count; i++)
            {
                if (Last[i].ID == id)
                {
                    Last.RemoveAt(i);
                    return;
                }
            }
        }

        public int PulseUpID(int id)
        {
            for (int i = 0; i < Last.Count; i++)
            {
                if (Last[i].ID == id)
                    return Last[i].Pulse;
            }
            return 0;
        }

        public bool BlubberScreenID(int id)
        {
            return PulseUpID(id) > 0;
        }

        public void Bat(ObjectSetCollection oSCollection)
        {
            if (oSCollection != null)
            {
                foreach (var item in oSCollection.CoconutPeak)
                {
                    BatUpNo(item.ID, item.Pulse);
                }
            }
        }

        public void Bat(List<ObjectsSetData> oSCollection)
        {
            if (oSCollection != null)
            {
                foreach (var item in oSCollection)
                {
                    BatUpNo(item.ID, item.Pulse);
                }
            }
        }

        public void PuddleJoy(Func<ObjectsSetData, bool> func)
        {
            Last.RemoveAll((item) => { return func(item); });
        }
    }
}