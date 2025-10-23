/***
 * 
 * 音乐管理器
 * 
 * **/
using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarkPeg : AfarDepiction<StarkPeg>
{
    //音频组件管理队列的对象
    private ChafeFamilyRoman ChafeRoman;
    // 用于播放背景音乐的音乐源
    private AudioSource m_AtStark=null;
    //播放音效的音频组件管理列表
    private List<AudioSource> DeadChafeFamilyPeak;
    //检查已经播放的音频组件列表中没有播放的组件的更新频率
    private float BrandTreasury= 2f; 
    //背景音乐开关
    private bool _UpStarkElicit;
    //音效开关
    private bool _EncodeStarkElicit;
    //音乐音量
    private float _UpMeteor=1f;
    //音效音量
    private float _EncodeMeteor=1f;
    string BGM_Over= "";

    public Dictionary<string, AudioModel> ChafeAdjunctBarn;

    // 控制背景音乐音量大小
    public float UpMeteor    {
        get { 
            return UpStarkElicit ? EndMeteor(BGM_Over) : 0f; 
        }
        set {
            _UpMeteor = value;
            //背景音乐开的状态下，声音随控制调节
        }
    }

    //控制音效音量的大小
    public float EncodeLikely    {
        get { return _EncodeMeteor; }
        set { 
            _EncodeMeteor = value;
            OldJoyEncodeMeteor();
        }
    }
    //控制背景音乐开关
    public bool UpStarkElicit    {
        get {

            _UpStarkElicit = BondSoulEvening.HowTape("_BgMusicSwitch");
            return _UpStarkElicit; 
        }
        set {
            if(m_AtStark)
            {
                _UpStarkElicit = value;
                BondSoulEvening.OldTape("_BgMusicSwitch", _UpStarkElicit);
                m_AtStark.volume = UpMeteor; 
            }
        }
    }
    public void setBgmDodgeFixSlit()
    {
        m_AtStark.volume = 0;
    }
    public void BowAndQuietlyFixSlit()
    {
        m_AtStark.volume = UpMeteor;
    }
    //控制音效开关
    public bool EncodeStarkElicit    {
        get {
            _EncodeStarkElicit = BondSoulEvening.HowTape("_EffectMusicSwitch");
            return _EncodeStarkElicit; 
        }
        set {
            _EncodeStarkElicit = value;
            BondSoulEvening.OldTape("_EffectMusicSwitch", _EncodeStarkElicit);
            
        }
    }
    public StarkPeg()
    {
        DeadChafeFamilyPeak = new List<AudioSource>();      
    }
    protected override void Awake()
    {
        if (!PlayerPrefs.HasKey("first_music_setBool") || !BondSoulEvening.HowTape("first_music_set"))
        {
            BondSoulEvening.OldTape("first_music_set", true);
            BondSoulEvening.OldTape("_BgMusicSwitch", true);
            BondSoulEvening.OldTape("_EffectMusicSwitch", true);
        }
        ChafeRoman = new ChafeFamilyRoman(this);

        TextAsset json = Resources.Load<TextAsset>("Audio/AudioInfo");
        ChafeAdjunctBarn = JsonMapper.ToObject<Dictionary<string, AudioModel>>(json.text);
    }
    private void Start()
    {
        StartCoroutine("BrandOrFeeChafeBrusquely");
    }
    /// <summary>
    /// 定时检查没有使用的音频组件并回收
    /// </summary>
    /// <returns></returns>
    IEnumerator BrandOrFeeChafeBrusquely()
    {
        while (true)
        {
            //定时更新
            yield return new WaitForSeconds(BrandTreasury);
            for (int i = 0; i < DeadChafeFamilyPeak.Count; i++)
            {
                //防止数据越界
                if (i < DeadChafeFamilyPeak.Count)
                {
                    //确保物体存在
                    if (DeadChafeFamilyPeak[i])
                    {
                        //音频为空或者没有播放为返回队列条件
                        if ((DeadChafeFamilyPeak[i].clip == null || !DeadChafeFamilyPeak[i].isPlaying))
                        {
                            //返回队列
                            ChafeRoman.UnFeeChafeBrusquely(DeadChafeFamilyPeak[i]);
                            //从播放列表中删除
                            DeadChafeFamilyPeak.Remove(DeadChafeFamilyPeak[i]);
                        }
                    }
                    else
                    {
                        //移除在队列中被销毁但是是在list中存在的垃圾数据
                        DeadChafeFamilyPeak.Remove(DeadChafeFamilyPeak[i]);
                    }                 
                }            
               
            }
        }
    }
    /// <summary>
    /// 设置当前播放的所有音效的音量
    /// </summary>
    private void OldJoyEncodeMeteor()
    {
        for (int i = 0; i < DeadChafeFamilyPeak.Count; i++)
        {
            if (DeadChafeFamilyPeak[i] && DeadChafeFamilyPeak[i].isPlaying)
            {
                DeadChafeFamilyPeak[i].volume = _EncodeStarkElicit ? _EncodeMeteor : 0f;
            }
        }
    }
    /// <summary>
    /// 播放背景音乐，传进一个音频剪辑的name
    /// </summary>
    /// <param name="bgName"></param>
    /// <param name="restart"></param>
    private void DeadUpReal(object bgName, bool restart = false)
    {

        BGM_Over = bgName.ToString();
        if (m_AtStark == null)
        {
            //拿到一个音频组件  背景音乐组件在某一时间段唯一存在
            m_AtStark = ChafeRoman.HowChafeBrusquely();
            //开启循环
            m_AtStark.loop = true;
            //开始播放
            m_AtStark.playOnAwake = false;
            //加入播放列表
            //PlayAudioSourceList.Add(m_bgMusic);
        }

        if (!UpStarkElicit)
        {
            m_AtStark.volume = 0;
        }

        //定义一个空的字符串
        string curBgName = string.Empty;
        //如果这个音乐源的音频剪辑不为空的话
        if (m_AtStark.clip != null)
        {
            //得到这个音频剪辑的name
            curBgName = m_AtStark.clip.name;
        }

        // 根据用户的音频片段名称, 找到AuioClip, 然后播放,
        //ResourcesMgr是提前定义好的查找音频剪辑对应路径的单例脚本，并动态加载出来
        AudioClip Gulf= Resources.Load<AudioClip>(ChafeAdjunctBarn[BGM_Over].filePath);
        //如果找到了，不为空
        if (Gulf != null)
        {
            //如果这个音频剪辑已经复制给类音频源，切正在播放，那么直接跳出
            if (Gulf.name == curBgName && !restart)
            {
                return;
            }
            //否则，把改音频剪辑赋值给音频源，然后播放
            m_AtStark.clip = Gulf;
            m_AtStark.volume = UpMeteor;
            m_AtStark.Play();
        }
        else
        {
            //没找到直接报错
            // 异常, 调用写日志的工具类.
            //UnityEngine.Debug.Log("没有找到音频片段");
            if (m_AtStark.isPlaying)
            {
                m_AtStark.Stop();
            }
            m_AtStark.clip = null;
        }
    }
    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="effectName"></param>
    /// <param name="defAudio"></param>
    /// <param name="volume"></param>
    private void DeadEncodeReal(object effectName, bool defAudio = true, float volume = 1f)
    {
        if (!EncodeStarkElicit)
        {
            return;
        }
        //获取音频组件
        AudioSource m_effectMusic = ChafeRoman.HowChafeBrusquely();
        if (m_effectMusic.isPlaying) {
            //Debug.Log("-------------------------------当前音效正在播放,直接返回");
            return;
        };
        m_effectMusic.loop = false;
        m_effectMusic.playOnAwake = false;
        m_effectMusic.volume = EndMeteor(effectName.ToString());
        //Debug.Log(m_effectMusic.volume);
        //根据查找路径加载对应的音频剪辑
        AudioClip Gulf= Resources.Load<AudioClip>(ChafeAdjunctBarn[effectName.ToString()].filePath);
        //如果为空的话，直接报错，然后跳出
        if (Gulf == null)
        {
            //UnityEngine.Debug.Log("没有找到音效片段");
            //没加入播放列表直接返回给队列
            ChafeRoman.UnFeeChafeBrusquely(m_effectMusic);
            return;
        }
        m_effectMusic.clip = Gulf;
        //加入播放列表
        DeadChafeFamilyPeak.Add(m_effectMusic);
        //否则，就是clip不为空的话，如果defAudio=true，直接播放
        if (defAudio)
        {
            m_effectMusic.PlayOneShot(Gulf, volume);
        }
        else
        {
            //指定点播放
            AudioSource.PlayClipAtPoint(Gulf, Camera.main.transform.position, volume);
        }
    }

    //播放各种音频剪辑的调用方法，MusicType是提前写好的存放各种音乐名称的枚举类，便于外面直接调用
    public void DeadUp(StarkLieu.UIMusic bgName, bool restart = false)
    {
        DeadUpReal(bgName, restart);
    }

    public void DeadUp(StarkLieu.SceneMusic bgName, bool restart = false)
    {
        DeadUpReal(bgName, restart);
    }

    //播放各种音频剪辑的调用方法，MusicType是提前写好的存放各种音乐名称的枚举类，便于外面直接调用
    public void DeadEncode(StarkLieu.UIMusic effectName, bool defAudio = true, float volume = 1f)
    {
        DeadEncodeReal(effectName, defAudio, volume);
    }

    public void DeadEncode(StarkLieu.SceneMusic effectName, bool defAudio = true, float volume = 1f)
    {
        DeadEncodeReal(effectName, defAudio, volume);
    }
    float EndMeteor(string name)
    {
        if (ChafeAdjunctBarn == null)
        {
            TextAsset json = Resources.Load<TextAsset>("Audio/AudioInfo");
            ChafeAdjunctBarn = JsonMapper.ToObject<Dictionary<string, AudioModel>>(json.text);
        }

        if (ChafeAdjunctBarn.ContainsKey(name))
        {
             return (float)ChafeAdjunctBarn[name].volume;

        }
        else
        {
            return 1;
        }
    }

}