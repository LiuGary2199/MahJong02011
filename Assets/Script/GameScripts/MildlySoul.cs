using System;
using UnityEngine;

namespace Mkey
{
    public class MildlySoul
    {
        public int ID{ get; private set; }
        public int BusyPulse{ get; private set; }
        public int AidePulse{ get; private set; }

        public Action<MildlySoul> HalitePulseAnvil; // <currcount, needcount>
        public Action<MildlySoul> RefinerAnvil;

        public bool Consider{ get { return AidePulse >= BusyPulse; } }

        public MildlySoul(int id, int needCount)
        {
            ID = id;
            BusyPulse = needCount;
            AidePulse = 0;
        }

        //public Sprite GetImage(LullCoconutOld mSet)
        //{
        //    SodaScreen bD = mSet.GetTargetObject(ID);
        //    return (bD != null) ? bD.GuiImage : null;
        //}

        public void IncAidePulse()
        {
            OldAidePulse(AidePulse + 1);
        }

        public void IncAidePulse(int inccount)
        {
            OldAidePulse(AidePulse + inccount);
        }

        public void OldAidePulse(int newCount)
        {
            bool reached = (BusyPulse > 0) && (AidePulse >= BusyPulse);
            
            newCount = Mathf.Max(0, newCount);
            bool changed = (AidePulse != newCount);
            AidePulse = newCount;
            if (changed)
            { 
                HalitePulseAnvil?.Invoke(this); 
                if(!reached && (BusyPulse > 0) && (AidePulse >= BusyPulse))
                {
                    RefinerAnvil?.Invoke(this);
                } 
            }
        }

        public void ViaBusyPulse(int incCount)
        {
            OldBusyPulse(BusyPulse + incCount);
        }

        public void OldBusyPulse(int newCount)
        {
            newCount = Mathf.Max(0, newCount);
            bool changed = (BusyPulse != newCount);
            BusyPulse = newCount;
            if (changed) HalitePulseAnvil?.Invoke(this);
        }

        public MildlySoul Unlimited()
        {
            return new MildlySoul(ID, BusyPulse);
        }
    }
}