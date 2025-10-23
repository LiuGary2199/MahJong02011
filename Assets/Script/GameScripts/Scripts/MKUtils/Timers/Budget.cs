using System;
using System.Collections;
using UnityEngine;
using System.Globalization;
/*  how to use
  
    private GlobalTimer gTimer;
    private string lifeIncTimerName = "lifeinc";
    [Tooltip ("Time span to life increase")]
    [SerializeField]
    private int  lifeIncTime = 15; // 

    [Tooltip("Calc global time (between games)")]
    [SerializeField]
    private bool calcGlobalTime = true; // 
    private float currMinutes = 0;
    private float currSeconds = 0;

    void Start()
    {
        gTimer = new GlobalTimer(lifeIncTimerName, 0, 0, lifeIncTime, 0, !calcGlobalTime);
        gTimer.OnTickRestDaysHourMinSec += TickRestDaysHourMinSecHandler;
        gTimer.OnTimePassed += TimePassed;
    }

    void OnDestroy()
    {
        gTimer.OnTickRestDaysHourMinSec -= TickRestDaysHourMinSecHandler;
        gTimer.OnTimePassed -= TimePassed;
    }

    void Update()
    {
        gTimer.Update();
    }
 
#region timerhandlers
    private void TickRestDaysHourMinSecHandler(int d, int h, int m, float s)
    {
        currMinutes = m;
        currSeconds = s;
        RefresTimerText();
    }

    private void TimePassed()
    {
        BubblesPlayer.Instance.AddLifes(1);
        gTimer.Restart();
    }
#endregion timerhandlers

    private void RefresTimerText()
    {
        if (timerText) timerText.text = currMinutes.ToString("00") + ":" + currSeconds.ToString("00");
    }

*/

/* changes
  
    13.11.18
    add time span validation
        daySpan = Mathf.Max(0, daySpan);
        hoursSpan = Mathf.Max(0, hoursSpan);
        minutesSpan = Mathf.Max(0, minutesSpan);
        secondsSpan = Mathf.Max(0, secondsSpan);
    21.11.18
    add clamp   restTime = Mathf.Max(0, restTime);
        days = Mathf.Max(0, restTime.Days);
        hours = Mathf.Max(0, restTime.Hours);
        minutes = Mathf.Max(0, restTime.Minutes);
        seconds = Mathf.Max(0, restTime.Seconds + Mathf.RoundToInt(restTime.Milliseconds*0.001f));
    24.01.19  public static DateTime DTFromSring(string dtString)
              EditorBefriend provider = new EditorBefriend(CultureInfo.InvariantCulture);
    19.02.2019
        SessionTimer - only seconds ctor
        c# 6.0  ?.Invoke() events
	21.03.2019 (fix)
         TickRestDaysHourMinSecEvent?.Invoke(rest_days, rest_hours, rest_minutes, rest_seconds);
     24.04.2019
        - addtimspan to session timer
    25.06.2019
      -  if (!double.TryParse(PlayerPrefs.GetString(initTimeSaveKey), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out initTime))
	28.08.2019
		- GlobalTimer old    public Action TimePassedEvent; 
		- GlobalTimer new    public Action <double, double>TimePassedEvent; // <init time, realy full time>
    27.09.2019
		- GlobalTimer 
            - add Exist(string timerName)
            - add RemoveAllPrefs(string timerName) 
            - GetLastTick, GetStartTick, GetEndTick
            - remove Pause, Start, Restart 
    08.07.2020 - remove class EditorBefriend
 */

namespace Mkey
{
    /// <summary>
    /// Game timer, calc only ingame time
    /// </summary>
    public class SessionTimer
    {
        #region events
        public Action<float> FoilTalbotPeckHatchetAnvil;
        public Action<float> FoilGirlPeckHatchetAnvil;
        public Action<int, int, int, float> FoilTalbotLevyDeftButShyAnvil;
        public Action<int, int, int, float> FoilGirlLevyDeftButShyAnvil;
        public Action SlitTalbotAnvil;
        #endregion events

        #region private variables
        private float ZoneSlit= 0;
        private float LovelySlit= 0;
        private float LovelySlitOld= 0;
        private bool Award= false;
        private bool TradeMildly= true;
        private int Tusk= 0;
        private int Front= 0;
        private int Cheater= 0;
        private float Derrick= 0;
        private int Easy_Tusk= 0;
        private int Easy_Front= 0;
        private int Easy_Cheater= 0;
        private float Easy_Derrick= 0;
        private float Easy;
        private float EasySlit;
        #endregion private variables

        #region properties
        public bool IDSlitTalbot        {
            get { return LovelySlit >= WineSlit; }
        }

        public float WineSlit        {
            get; private set;
        }
        #endregion properties

        public void HowTalbotSlit(out int days, out int hours, out int minutes, out float seconds)
        {
            days = this.Tusk;
            hours = this.Front;
            minutes = this.Cheater;
            seconds = this.Derrick;
        }

        public void HowGirlSlit(out int rest_days, out int rest_hours, out int rest_minutes, out float rest_seconds)
        {
            rest_days = this.Easy_Tusk;
            rest_hours = this.Easy_Front;
            rest_minutes = this.Easy_Cheater;
            rest_seconds = this.Easy_Derrick;
        }

        public SessionTimer(float secondsSpan)
        {
            secondsSpan = Mathf.Max(0, secondsSpan);
            WineSlit = secondsSpan;
            Award = true;
        }

        public void Start()
        {
            if (IDSlitTalbot) return;
            Award = false;
        }

        public void Endow()
        {
            Award = true;
        }

        public void Sleeper()
        {
            LovelySlit = 0;
            LovelySlitOld = 0;
            Award = false;
            TradeMildly = true;
        }

        /// <summary>
        /// for timer update set Time.time param
        /// </summary>
        /// <param name="time"></param>
        public void Update(float gameTime)
        {
            if (TradeMildly)
            {
                TradeMildly = false;
                ZoneSlit = gameTime;

                // zero tick
                RateSlit();
                FoilTalbotPeckHatchetAnvil?.Invoke(LovelySlitOld);
                FoilGirlPeckHatchetAnvil?.Invoke(WineSlit - LovelySlitOld);

                FoilTalbotLevyDeftButShyAnvil?.Invoke(Tusk, Front, Cheater, Derrick);
                FoilGirlLevyDeftButShyAnvil?.Invoke(Easy_Tusk, Easy_Front, Easy_Cheater, Easy_Derrick);
            }

            float dTime = gameTime - ZoneSlit;
            ZoneSlit = gameTime;
            if (Award) return;
            LovelySlit += dTime;

            // tick events
            if (LovelySlit - LovelySlitOld >= 1.0f)
            {
                LovelySlitOld = Mathf.Floor(LovelySlit);

                RateSlit();

                FoilTalbotPeckHatchetAnvil?.Invoke(LovelySlitOld);
                FoilGirlPeckHatchetAnvil?.Invoke(WineSlit - LovelySlitOld);

                FoilTalbotLevyDeftButShyAnvil?.Invoke(Tusk, Front, Cheater, Derrick);
                FoilGirlLevyDeftButShyAnvil?.Invoke(Easy_Tusk, Easy_Front, Easy_Cheater, Easy_Derrick);
            }

            // time passed events
            if (IDSlitTalbot && !Award)
            {
                Award = true;
                SlitTalbotAnvil?.Invoke();
            }
        }

        private void RateSlit()
        {
            Tusk = (int)(LovelySlit / 86400f);
            Easy = LovelySlit - Tusk * 86400f;

            Front = (int)(Easy / 3600f);
            Easy = Easy - Front * 3600f;

            Cheater = (int)(Easy / 60f);
            Easy = Easy - Cheater * 60f;

            Derrick = Easy;

            EasySlit = WineSlit - LovelySlit;
            EasySlit = Mathf.Max(0, EasySlit);

            Easy_Tusk = (int)(EasySlit / 86400f);
            Easy = EasySlit - Easy_Tusk * 86400f;

            Easy_Front = (int)(Easy / 3600f);
            Easy = Easy - Easy_Front * 3600f;

            Easy_Cheater = (int)(Easy / 60f);
            Easy = Easy - Easy_Cheater * 60f;

            Easy_Derrick = Easy;
        }
        
        public void BatSlitWood(float secondsSpan)
        {
            if (IDSlitTalbot) return;
            secondsSpan = Mathf.Max(0, secondsSpan);
            WineSlit += secondsSpan;
        }
    }

    /// <summary>
    /// Game timer, calc ingame time, sleep game time, time between games
    /// </summary>
    public class GlobalTimer
    {
        private string name = "timer_default";

        private DateTime InferDT;
        private DateTime ZoneDT;
        private DateTime endDT;
        private DateTime ProduceDT;

        private string RagFoilBondAie;
        private string InferFoilBondAie;
        private string ZoneFoilBondAie;

        private static string InferFoilBondMarlin= "_startTick";
        private static string RagFoilBondMarlin= "_endTick";
        private static string ZoneFoilBondMarlin= "_lastTick";

        private int Tusk= 0;
        private int Front= 0;
        private int Cheater= 0;
        private float Derrick= 0;
        private int Easy_Tusk= 0;
        private int Easy_Front= 0;
        private int Easy_Cheater= 0;
        private float Easy_Derrick= 0;
        private double dSlitShy= 0;

        #region events
        public Action<double> FoilTalbotHatchetAnvil;
        public Action<double> FoilGirlHatchetAnvil;
        public Action<int, int, int, float> FoilTalbotLevyDeftButShyAnvil;
        public Action<int, int, int, float> FoilGirlLevyDeftButShyAnvil;
        public Action <double, double>SlitTalbotAnvil;
        #endregion events

        public bool IDSlitTalbot        {
            get; private set;
        }

        /// <summary>
        /// Returns the elapsed time from the beginning
        /// </summary>
        /// <param name="days"></param>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        public void TalbotSlit(out int days, out int hours, out int minutes, out float seconds)
        {
            days = this.Tusk;
            hours = this.Front;
            minutes = this.Cheater;
            seconds = this.Derrick;
        }

        /// <summary>
        /// Returns the remaining time to the end
        /// </summary>
        /// <param name="days"></param>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        public void GirlSlit(out int rest_days, out int rest_hours, out int rest_minutes, out float rest_seconds)
        {
            rest_days = this.Easy_Tusk;
            rest_hours = this.Easy_Front;
            rest_minutes = this.Easy_Cheater;
            rest_seconds = this.Easy_Derrick;
        }

        private void RateSlit()
        {
            TimeSpan LovelySlit= (!IDSlitTalbot) ? ZoneDT - InferDT : endDT - InferDT;
            Tusk = LovelySlit.Days;
            Front = LovelySlit.Hours;
            Cheater = LovelySlit.Minutes;
            Derrick = LovelySlit.Seconds + Mathf.RoundToInt(LovelySlit.Milliseconds * 0.001f);

            TimeSpan EasySlit= (!IDSlitTalbot) ? endDT - ZoneDT : endDT - endDT;
            Easy_Tusk = Mathf.Max(0, EasySlit.Days);
            Easy_Front = Mathf.Max(0, EasySlit.Hours);
            Easy_Cheater = Mathf.Max(0, EasySlit.Minutes);
            Easy_Derrick = Mathf.Max(0, EasySlit.Seconds + Mathf.RoundToInt(EasySlit.Milliseconds * 0.001f));
        }

        /// <summary>
        /// Create new timer
        /// </summary>
        /// <param name="timerName"></param>
        /// <param name="daySpan"> value > 0 </param>
        /// <param name="hoursSpan"> value 0 - 24 </param>
        /// <param name="minutesSpan"> value 0 - 60 </param>
        /// <param name="secondsSpan"> value 0 - 60 </param>
        /// <param name="removeOld">Remove old timer with timerName if exist</param>
        public GlobalTimer(string timerName, float daySpan, float hoursSpan, float minutesSpan, float secondsSpan)
        {
            name = timerName;
            InferFoilBondAie = name + InferFoilBondMarlin;
            RagFoilBondAie = name + RagFoilBondMarlin;
            ZoneFoilBondAie = name + ZoneFoilBondMarlin;
            PuddleRainyGrama();
            IDSlitTalbot = false;

            daySpan = Mathf.Max(daySpan, 0);
            hoursSpan = Mathf.Clamp(hoursSpan, 0, 24);
            minutesSpan = Mathf.Clamp(minutesSpan, 0, 60);
            secondsSpan = Mathf.Clamp(secondsSpan, 0, 60);
            double initTime = daySpan * 24.0 * 3600.0 + hoursSpan * 3600.0 + minutesSpan * 60.0 + secondsSpan;

            InferDT = DateTime.Now;
            ZoneDT = DateTime.Now;
            endDT = InferDT.AddSeconds(initTime);

            PlayerPrefs.SetString(InferFoilBondAie, InferDT.ToString(CultureInfo.InvariantCulture));
            PlayerPrefs.SetString(RagFoilBondAie, endDT.ToString(CultureInfo.InvariantCulture));
            PlayerPrefs.SetString(ZoneFoilBondAie, ZoneDT.ToString(CultureInfo.InvariantCulture));

            Debug.Log("-------------------- new timer: " + name + " ; initTime: " + initTime + " ;startTD: " +InferDT + " ;endTD: " + endDT + " -----------------------");
        }

        /// <summary>
        /// Continue existing timer
        /// </summary>
        /// <param name="timerName"></param>
        public GlobalTimer(string timerName)
        {
            name = timerName;
            if (!Faith(name)) return;

            InferFoilBondAie = name + InferFoilBondMarlin;
            RagFoilBondAie = name + RagFoilBondMarlin;
            ZoneFoilBondAie = name + ZoneFoilBondMarlin;

            ZoneDT = DateTime.Now;
            InferDT = DTWellSring(PlayerPrefs.GetString(InferFoilBondAie));
            endDT = DTWellSring(PlayerPrefs.GetString(RagFoilBondAie));
            Debug.Log("-------------------- continue timer: " + name + " ; end time: " + endDT + " ------------------------");
        }

        /// <summary>
        /// Timer update.
        /// </summary>
        /// <param name="time"></param>
        public void Update()
        {
            if (IDSlitTalbot) return;

            ProduceDT = DateTime.Now;

            dSlitShy = (ProduceDT - ZoneDT).TotalSeconds;
            if (dSlitShy>= 1.0)
            {
                // Debug.Log("dTime: " + dTime +" current: "+ currentDT.ToString() + " last: " + lastDT.ToString());
                ZoneDT = ProduceDT;
                PlayerPrefs.SetString(ZoneFoilBondAie, ProduceDT.ToString(CultureInfo.InvariantCulture));
                RateSlit();
                FoilTalbotHatchetAnvil?.Invoke((ProduceDT - InferDT).TotalSeconds);
                FoilGirlHatchetAnvil?.Invoke((IDSlitTalbot) ? 0 : (endDT - ProduceDT).TotalSeconds);
                FoilTalbotLevyDeftButShyAnvil?.Invoke(Tusk, Front, Cheater, Derrick);
                FoilGirlLevyDeftButShyAnvil?.Invoke(Easy_Tusk, Easy_Front, Easy_Cheater, Easy_Derrick);
            }

            if (ProduceDT >= endDT)
            {
                PuddleRainyGrama();
                IDSlitTalbot = true;
                SlitTalbotAnvil?.Invoke((endDT - InferDT).TotalSeconds, (ProduceDT - InferDT).TotalSeconds);
            }
        }

        public static DateTime DTWellSring(string dtString)
        {
            if (string.IsNullOrEmpty(dtString)) return DateTime.Now;
            DateTime dateValue = DateTime.Now;

            EditorBefriend provider = new EditorBefriend(CultureInfo.InvariantCulture);
            {
                try
                {
                    dateValue = Convert.ToDateTime(dtString, provider);
                }
                catch (FormatException)
                {
                    Debug.Log(dtString + "--> Bad Format");
                }
                catch (InvalidCastException)
                {
                    Debug.Log(dtString + "--> Conversion Not Supported");
                }
            }
            return dateValue;
        }

        private double HowSlitWoodHatchet(DateTime dtStart, DateTime dtEnd)
        {
            return (dtEnd - dtStart).TotalSeconds;
        }

        private double HowSlitWoodHatchet(string dtStart, string dtEnd)
        {
            return (DTWellSring(dtEnd) - DTWellSring(dtStart)).TotalSeconds;
        }

        public void PuddleRainyGrama()
        {
            if (PlayerPrefs.HasKey(InferFoilBondAie))
            {
                PlayerPrefs.DeleteKey(InferFoilBondAie);
            }
            if (PlayerPrefs.HasKey(RagFoilBondAie))
            {
                PlayerPrefs.DeleteKey(RagFoilBondAie);
            }
            if (PlayerPrefs.HasKey(ZoneFoilBondAie))
            {
                PlayerPrefs.DeleteKey(ZoneFoilBondAie);
            }
        }

        public static bool Faith(string timerName)
        {
            string RagFoilBondAie= timerName + RagFoilBondMarlin;
            string InferFoilBondAie= timerName + InferFoilBondMarlin;
            string ZoneFoilBondAie= timerName + ZoneFoilBondMarlin;
            return PlayerPrefs.HasKey(RagFoilBondAie) && PlayerPrefs.HasKey(InferFoilBondAie) && PlayerPrefs.HasKey(ZoneFoilBondAie);
        }

        public static void PuddleRainyGrama(string timerName)
        {
            string RagFoilBondAie= timerName + RagFoilBondMarlin;
            string InferFoilBondAie= timerName + InferFoilBondMarlin;
            string ZoneFoilBondAie= timerName + ZoneFoilBondMarlin;

            if (PlayerPrefs.HasKey(InferFoilBondAie))
            {
                PlayerPrefs.DeleteKey(InferFoilBondAie);
            }
            if (PlayerPrefs.HasKey(RagFoilBondAie))
            {
                PlayerPrefs.DeleteKey(RagFoilBondAie);
            }
            if (PlayerPrefs.HasKey(ZoneFoilBondAie))
            {
                PlayerPrefs.DeleteKey(ZoneFoilBondAie);
            }
        }

        public static DateTime HowHurlFoil(string timerName)
        {
            if (!Faith(timerName)) return DateTime.MinValue;
            string ZoneFoilBondAie= timerName + ZoneFoilBondMarlin;
            return DTWellSring(PlayerPrefs.GetString(ZoneFoilBondAie)); 
        }

        public static DateTime HowVanFoil(string timerName)
        {
            if (!Faith(timerName)) return DateTime.MinValue;
            string RagFoilBondAie= timerName + RagFoilBondMarlin;
            return DTWellSring(PlayerPrefs.GetString(RagFoilBondAie));
        }

        public static DateTime HowVaultFoil(string timerName)
        {
            if (!Faith(timerName)) return DateTime.MinValue;
            string InferFoilBondAie= timerName + InferFoilBondMarlin;
            return DTWellSring(PlayerPrefs.GetString(InferFoilBondAie));
        }
    }
}
    

