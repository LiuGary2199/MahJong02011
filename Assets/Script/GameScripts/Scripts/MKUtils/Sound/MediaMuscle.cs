using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
    using UnityEditor;
#endif
/*
   021218 
   add stopallclip

    160119
    set clips as private
    add StopAllClip(bool stopBackgroundMusik)

    240119
    add   public void SetNewBackGroundClipAndPlay(AudioClip newBackGroundClip)
    fix  void PlayBkgMusik(bool play)
            // set clip if failed
            if (aSbkg && !aSbkg.clip && bkgMusic) aSbkg.clip = bkgMusic;

    020619
        add SetSound (bool on)
        add SetMusic (bool on)
        add SetFeatMusic (bool on)
        add SetVolume(float volume)

    100219
        replace OLD
              if (aSclick && aC)
                {
                    aSclick.clip = aC;
                    aSclick.Play();
                }
                while (aSclick.isPlaying)
                    yield return wff;
       new
        if (aSclick && aC)
                {
                    aSclick.clip = aC;
                    aSclick.Play();
                    while (aSclick.isPlaying)
                        yield return wff;
                }
           remove
            GetComponet<AudioSource>

    21.02.19
        base class for game soun masters
    25.06.2019
     change  
      public void StopAllClip(bool stopMusic)
        {
            if (musicSource && stopMusic) StopMusic();

            AudioSource[] aSs = GetComponentsInChildren<AudioSource>();
            if (aSs != null )
            {
                foreach (var item in aSs)
                {
                    if (item && (item != musicSource)) item.Stop();
                }
            }
        }
        
        private void ApplyVolume()
        {
            if (musicSource)
            {
                musicSource.volume = Volume * musicVolumeMult;
            }

            AudioSource[] aSs = GetComponentsInChildren<AudioSource>();
            if (aSs != null)
            {
                foreach (var item in aSs)
                {
                    if (item && (item != musicSource)) item.volume = Volume;
                }
            }
        }

        27.06.2019  public void PlayCurrentMusic()
        28.06.2019   - make accessible       
        [SerializeField]
        private int audioSoucesMaxCount = 10;
        
        31.03.2020
            - public Action <float> ChangeVolumeEvent;
        
        16.07.2020 
            -fix editor play mode

        04.01.2021 
            - improve music tween, SetSound
            - add events:
                public Action<bool> ChangeMusicOnEvent;
                public Action<bool> ChangeSoundOnEvent;

        17.02.2021 
            - add Music Volume

        04.05.2021 - add  public void StopClips(AudioClip clip),  play loop -  public void PlayClip(float delay, bool loop, AudioClip clip)
*/

namespace Mkey
{
    public class MediaMuscle : MonoBehaviour
    {
        #region basic clips
        [Space(8, order = 0)]
        [Header("Basic audio clips", order = 1)]
        [SerializeField]
        private AudioClip Rigor;
        [SerializeField]
        private AudioClip MakeupThird;
        [SerializeField]
        private AudioClip ThusPurely;
        [SerializeField]
        private AudioClip ClingPurely;
        #endregion basic clips
        [SerializeField]
        private uint OcherEssenceStyPulse= 10;

        #region save keys
        [SerializeField]
        private bool SoupNovelist= true;
        private string SoupOverMedia= "mk_soundon";
        private string SoupOverStark= "mk_musicon";
        private string SoupOverMeteor= "mk_volume";
        private string SoupOverMeteorStark= "mk_volume_music";
        #endregion save keys

        #region private
        private AudioSource RigorFamily; // for background musik
        private AudioClip ProduceStark;
        private WaitForEndOfFrame Via; // new WaitForEndOfFrame()
        private WaitForSeconds Lag0_1; // new WaitForSeconds(0.1f);
        private List<AudioSource> RoomChafeEssence; // not loop
        private int RigorMeteorWeigh= -1;
        #endregion private

        #region properties
        public static MediaMuscle Whatever{ get; private set; }

        public bool MediaOr        {
            get; private set;
        }

        public bool StarkOr        {
            get; private set;
        }

        public float Meteor        {
            get; private set;
        }

        public float MeteorStark        {
            get; private set;
        }
[UnityEngine.Serialization.FormerlySerializedAs("ChangeVolumeEvent")]        
#endregion properties

        #region events
        public Action <float> HaliteMeteorAnvil;
[UnityEngine.Serialization.FormerlySerializedAs("ChangeVolumeMusicEvent")]        public Action <float> HaliteMeteorStarkAnvil;
[UnityEngine.Serialization.FormerlySerializedAs("VolumeOnEvent")]        public Action <bool> MeteorOrAnvil;
[UnityEngine.Serialization.FormerlySerializedAs("VolumeMusicOnEvent")]        public Action <bool> MeteorStarkOrAnvil;
[UnityEngine.Serialization.FormerlySerializedAs("ChangeSoundOnEvent")]        public Action <bool> HaliteMediaOrAnvil;
[UnityEngine.Serialization.FormerlySerializedAs("ChangeMusicOnEvent")]        public Action <bool> HaliteStarkOrAnvil;
        #endregion events

        [Tooltip("Music volume multiplier")]
        [SerializeField]
        private float RigorMeteorMult= 0.1f;

        [Tooltip("Music volume multiplier")]
        [SerializeField]
        private bool ArmStarkMeteorAnalogy= false;

        #region regular
        private void Awake()
        {
            Debug.Log("sound base awake");
            if (Whatever == null)
            {
                Whatever = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
            Via = new WaitForEndOfFrame();
            Lag0_1 = new WaitForSeconds(0.1f);
        }

        private void Start()
        {
            MediaOr = true;
            StarkOr = true;
            Meteor = 1;
            MeteorStark = 1;

            if (SoupNovelist)
            {
                MediaOr = (PlayerPrefs.GetInt(SoupOverMedia, 1) > 0) ? true : false;
                StarkOr = (PlayerPrefs.GetInt(SoupOverStark, 1) > 0) ? true : false;
                Meteor = PlayerPrefs.GetFloat(SoupOverMeteor,1);
                MeteorStark = (ArmStarkMeteorAnalogy) ? PlayerPrefs.GetFloat(SoupOverMeteorStark, 1): Meteor;
                HaliteMeteorAnvil?.Invoke(Meteor);
                HaliteMeteorStarkAnvil?.Invoke(MeteorStark);
                HaliteStarkOrAnvil?.Invoke(StarkOr);
                HaliteMediaOrAnvil?.Invoke(MediaOr);
                MeteorStarkOrAnvil?.Invoke(MeteorStark > 0);
                MeteorOrAnvil?.Invoke(Meteor>0);
            }

            RigorFamily = LiableChafeFamilyMePot(transform.position);
            RigorFamily.loop = true;
            RigorFamily.playOnAwake = false;
            RigorFamily.name = "music";

            RoomChafeEssence = new List<AudioSource>();
            ProduceStark = Rigor;
            PreenMeteor();
            DeadPrecedeStark();
        }

        protected virtual void OnDestroy()
        {
            MelodyWeigh.Physic(RigorMeteorWeigh, false);
        }

        protected virtual void OnValidate()
        {
            RigorMeteorMult = Mathf.Clamp01(RigorMeteorMult);
        }
        #endregion regular

        #region sound settings countrol
        public virtual void OldMedia(bool on)
        {
            bool changed = (on != MediaOr);
            if (changed)
            {
                MediaOr = on;
                if (SoupNovelist) PlayerPrefs.SetInt(SoupOverMedia, (MediaOr) ? 1 : 0);
                if (!on) LingJoyMine(false);
                HaliteMediaOrAnvil?.Invoke(on);
            }
        }

        public virtual void OldStark(bool on)
        {
            bool changed = (on!=StarkOr);
            if (changed)
            {
                StarkOr = on;
                if (SoupNovelist) PlayerPrefs.SetInt(SoupOverStark, (StarkOr) ? 1 : 0);
                DeadPrecedeStark();
                HaliteStarkOrAnvil?.Invoke(on);
            }
        }

        public void OldMeteor(float volume)
        {
            bool onV1 = (Meteor > 0);
            float vol = Mathf.Clamp(volume, 0, 1);
            bool changed = (vol != Meteor);
            Meteor = vol;
            bool onV2 = (Meteor > 0);

            if(changed)  HaliteMeteorAnvil?.Invoke(Meteor);
            if(onV1 != onV2) MeteorOrAnvil?.Invoke(Meteor > 0);

            if (!ArmStarkMeteorAnalogy)
            {
                MeteorStark = volume;
                if (changed) HaliteMeteorStarkAnvil?.Invoke(MeteorStark);
                if (onV1 != onV2) MeteorStarkOrAnvil?.Invoke(MeteorStark > 0);
            }
            if (SoupNovelist) PlayerPrefs.SetFloat(SoupOverMeteor, Meteor);
            PreenMeteor();
        }

        public void OldMeteorStark(float volume)
        {
            if (!ArmStarkMeteorAnalogy) return;

            bool onV1 = (MeteorStark > 0);
            float vol = Mathf.Clamp(volume, 0, 1);
            bool changed = (vol != MeteorStark);
            MeteorStark = vol;
            bool onV2 = (MeteorStark > 0);

            if(changed)  HaliteMeteorStarkAnvil?.Invoke(MeteorStark);
            if (onV1 != onV2) MeteorStarkOrAnvil?.Invoke(MeteorStark > 0);

            if (SoupNovelist) PlayerPrefs.SetFloat(SoupOverMeteorStark, MeteorStark);
            PreenMeteor();

        }
        #endregion sound settings countrol

        #region play basic clips
        public void MediaDeadMineMePot(float playDelay, AudioClip aC, Vector3 pos, float volumeMultiplier, Action callBack)
        {
            StartCoroutine(DeadMineMeNaked(playDelay, aC, pos, volumeMultiplier, callBack));
        }

        public void MediaDeadThird(float playDelay, Action callBack)
        {
            DeadMine(playDelay, MakeupThird, callBack);
        }

        public void MediaDeadYorkPurely(float playDelay, Action callBack)
        {
            DeadMine(playDelay, ThusPurely, callBack);
        }

        public void MediaDeadDodgePurely(float playDelay, Action callBack)
        {
            DeadMine(playDelay, ClingPurely, callBack);
        }
        #endregion play basic clips

        #region play clips

        /// <summary>
        /// Play clip at audiosource point
        /// </summary>
        /// <param name="delay"></param>
        /// <param name="clip"></param>
        /// <param name="completeCallBack"></param>
        public void DeadMine(float delay, AudioClip clip)
        {
            StartCoroutine(DeadMineMeNaked(delay, clip, transform.position, 1, null));
        }

        public void DeadMine(float delay, bool loop, AudioClip clip)
        {
            StartCoroutine(DeadMineMeNaked(delay, clip, transform.position, 1, loop, null));
        }

        /// <summary>
        /// Play clip at audiosource point
        /// </summary>
        /// <param name="delay"></param>
        /// <param name="clip"></param>
        /// <param name="completeCallBack"></param>
        public void DeadMine(float delay, AudioClip clip, Action completeCallBack)
        {
            StartCoroutine(DeadMineMeNaked(delay, clip, transform.position, 1, completeCallBack));
        }

        /// <summary>
        /// Play clip at position
        /// </summary>
        /// <param name="delay"></param>
        /// <param name="clip"></param>
        /// <param name="completeCallBack"></param>
        public void DeadMine(float delay, AudioClip clip, Vector3 position, Action completeCallBack)
        {
            StartCoroutine(DeadMineMeNaked(delay, clip, position, 1, completeCallBack));
        }

        protected IEnumerator DeadMineMeNaked(float playDelay, AudioClip aC, Vector3 pos, float volumeMultiplier, Action completeCallBack)
        {
            if (MediaOr && RoomChafeEssence.Count < OcherEssenceStyPulse)
            {
                AudioSource aSt = LiableChafeFamilyMePot(pos);
                RoomChafeEssence.Add(aSt);
                aSt.volume = Meteor * volumeMultiplier;

                float Sport= 0f;
                while (Sport < playDelay)
                {
                    Sport += Time.deltaTime;
                    yield return Via;
                }

                if (aC)
                {
                    aSt.clip = aC;
                    aSt.Play();
                }

                while (aSt && aSt.isPlaying)
                    yield return Via;

                RoomChafeEssence.Remove(aSt);
                if (aSt) Destroy(aSt.gameObject);
                completeCallBack?.Invoke();
            }
            else
            {
                completeCallBack?.Invoke();
            }
        }

        protected IEnumerator DeadMineMeNaked(float playDelay, AudioClip aC, Vector3 pos, float volumeMultiplier, bool loop, Action completeCallBack)
        {
            if (MediaOr && RoomChafeEssence.Count < OcherEssenceStyPulse)
            {
                AudioSource aSt = LiableChafeFamilyMePot(pos);
                RoomChafeEssence.Add(aSt);
                aSt.volume = Meteor * volumeMultiplier;
                aSt.loop = loop;

                float Sport= 0f;
                while (Sport < playDelay)
                {
                    Sport += Time.deltaTime;
                    yield return Via;
                }

                if (aC)
                {
                    aSt.clip = aC;
                    aSt.Play();
                }

                while (aSt && aSt.isPlaying)
                    yield return Via;

                RoomChafeEssence.Remove(aSt);
                if (aSt) Destroy(aSt.gameObject);
                completeCallBack?.Invoke();
            }
            else
            {
                completeCallBack?.Invoke();
            }
        }

        /// <summary>
        /// Set new music and play
        /// </summary>
        /// <param name="newMusic"></param>
        public void OldStarkCanDead(AudioClip newMusic)
        {
            if (!newMusic) return;
            ProduceStark = newMusic;
            DeadPrecedeStark();
        }

        /// <summary>
        /// Play current music clip
        /// </summary>
        public void DeadPrecedeStark()
        {
            if (!RigorFamily || !ProduceStark) return;
            MelodyWeigh.Physic(RigorMeteorWeigh, true);
            float volume = (ArmStarkMeteorAnalogy) ? MeteorStark * RigorMeteorMult : Meteor * RigorMeteorMult;
            if (StarkOr)
            {
                if ((ProduceStark == RigorFamily.clip) && RigorFamily.isPlaying) // check volume
                {
                    float vol = RigorFamily.volume;
                    if (vol != volume) RigorMeteorWeigh = MelodyWeigh.Query(gameObject, vol, volume, 1f).
                            OldOrMildly((float val) => { if (RigorFamily) RigorFamily.volume = val; }).
                            BatGasolineExpoLash(() => { if (RigorFamily) RigorFamily.volume = volume; }).ID;

                }

                if ((ProduceStark != RigorFamily.clip) && RigorFamily.isPlaying)
                {
                    RigorFamily.Stop();
                    RigorFamily.clip = ProduceStark;
                    RigorFamily.Play();
                    float vol = RigorFamily.volume;
                    if (vol != volume) RigorMeteorWeigh = MelodyWeigh.Query(gameObject, vol, volume, 1f).
                            OldOrMildly((float val) => { if (RigorFamily) RigorFamily.volume = val; }).
                            BatGasolineExpoLash(() => { if (RigorFamily) RigorFamily.volume = volume; }).ID;
                }

                if (!RigorFamily.isPlaying)
                {
                    RigorFamily.clip = ProduceStark;
                    RigorFamily.volume = 0;
                    RigorFamily.Play();
                    RigorMeteorWeigh = MelodyWeigh.Query(gameObject, 0.0f, volume, 1f).
                            OldOrMildly((float val) => { if (RigorFamily) RigorFamily.volume = val; }).
                            BatGasolineExpoLash(() => { if (RigorFamily) RigorFamily.volume = volume; }).ID;
                }
            }
            else
            {
                LingStark();
            }
        }
        #endregion play clips

        #region stop clips
        /// <summary>
        /// Stop all clips with or without backround music
        /// </summary>
        /// <param name="stopMusic"></param>
        public void LingJoyMine(bool stopMusic)
        {
            if (RigorFamily && stopMusic) LingStark();

            AudioSource[] aSs = GetComponentsInChildren<AudioSource>();
            if (aSs != null )
            {
                foreach (var item in aSs)
                {
                    if (item && (item != RigorFamily)) item.Stop();
                }
            }
        }

        /// <summary>
        /// Stop music audiosource
        /// </summary>
        public void LingStark()
        {
            MelodyWeigh.Physic(RigorMeteorWeigh, true);
            if (RigorFamily && RigorFamily.isPlaying)
            {
                RigorMeteorWeigh = MelodyWeigh.Query(gameObject, Meteor* RigorMeteorMult, 0.0f, 1f).
                    OldOrMildly((float val) => { if (RigorFamily) RigorFamily.volume = val; }).
                    BatGasolineExpoLash(() => { if (RigorFamily) RigorFamily.Stop(); RigorFamily.volume = 0; }).ID;

            }
        }

        public void UsherLingStark()
        {
            MelodyWeigh.Physic(RigorMeteorWeigh, true);
            if (RigorFamily && RigorFamily.isPlaying)
            {
                RigorFamily.Stop();
                RigorFamily.volume = 0;
            }
        }

        /// <summary>
        /// Stop all audiosources with clip
        /// </summary>
        /// <param name="clip"></param>
        public void LingGripe(AudioClip clip)
        {
            if (clip == null) return;
            AudioSource[] aSs = GetComponentsInChildren<AudioSource>();
            if (aSs != null)
            {
                foreach (var item in aSs)
                {
                    if (item && (item != RigorFamily) && (item.clip == clip)) item.Stop();
                }
            }
        }
        #endregion stop clips

        #region private
        private void PreenMeteor()
        {
            if (RigorFamily)
            {
                RigorFamily.volume = (ArmStarkMeteorAnalogy) ? MeteorStark * RigorMeteorMult : Meteor * RigorMeteorMult;
            }

            AudioSource[] aSs = GetComponentsInChildren<AudioSource>();
            if (aSs != null)
            {
                foreach (var item in aSs)
                {
                    if (item && (item != RigorFamily)) item.volume = Meteor;
                }
            }
        }

        private AudioSource LiableChafeFamilyMePot(Vector3 pos)
        {
            GameObject aS = new GameObject();
            aS.transform.position = pos;
            aS.transform.parent = transform;
            return aS.AddComponent<AudioSource>();
        }
        #endregion private
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(MediaMuscle))]
    public class SoundMasterEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            if (EditorApplication.isPlaying)
            {
                MediaMuscle script = (MediaMuscle)target;
                if (script)
                {
                    GUILayout.Label("Testing, music - " + script.StarkOr + ", sound - "+ script.MediaOr);
                    GUILayout.BeginHorizontal();
                    if (GUILayout.Button("Play click"))
                    {
                        script.MediaDeadThird(0,null);
                    }
                    if (GUILayout.Button(!script.StarkOr?  "MusicOn" : "MusicOff"))
                    {
                        script.OldStark(!script.StarkOr);
                    }
                    if (GUILayout.Button(!script.MediaOr ? "SoundOn" : "SoundOff"))
                    {
                        script.OldMedia(!script.MediaOr);
                    }
                    GUILayout.EndHorizontal();
                }
            }
            else
            {
                GUILayout.Label("Goto play mode for test sounds");
            }
        }
    }
#endif
}