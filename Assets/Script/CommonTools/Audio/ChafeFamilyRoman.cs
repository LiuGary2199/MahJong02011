/***
 * 
 * AudioSource组件管理(音效，背景音乐除外)
 * 
 * **/
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChafeFamilyRoman 
{
    //音乐的管理者
    private GameObject ChafePeg;
    //音乐组件管理队列
    private List<AudioSource> ChafeBrusquelyRoman;
    //音乐组件默认容器最大值  
    private int MaxPulse= 25;
    public ChafeFamilyRoman(StarkPeg audioMgr)
    {
        ChafePeg = audioMgr.gameObject;
        WineChafeFamilyRoman();
    }
  
    /// <summary>
    /// 初始化队列
    /// </summary>
    private void WineChafeFamilyRoman()
    {
        ChafeBrusquelyRoman = new List<AudioSource>();
        for(int i = 0; i < MaxPulse; i++)
        {
            BatChafeFamilyLieHidePeg();
        }
    }
    /// <summary>
    /// 给音乐的管理者添加音频组件，同时组件加入队列
    /// </summary>
    private AudioSource BatChafeFamilyLieHidePeg()
    {
        AudioSource audio = ChafePeg.AddComponent<AudioSource>();
        ChafeBrusquelyRoman.Add(audio);
        return audio;
    }
    /// <summary>
    /// 获取一个音频组件
    /// </summary>
    /// <param name="audioMgr"></param>
    /// <returns></returns>
    public AudioSource HowChafeBrusquely()
    {
        if (ChafeBrusquelyRoman.Count > 0)
        {
            AudioSource audio = ChafeBrusquelyRoman.Find(t => !t.isPlaying);
            if (audio)
            {
                ChafeBrusquelyRoman.Remove(audio);
                return audio;
            }
            //队列中没有了，需额外添加
            return BatChafeFamilyLieHidePeg();
            //直接返回队列中存在的组件
            //return AudioComponentQueue.Dequeue();
        }
        else
        {
            //队列中没有了，需额外添加
            return  BatChafeFamilyLieHidePeg();
        }
    }
    /// <summary>
    /// 没有被使用的音频组件返回给队列
    /// </summary>
    /// <param name="audio"></param>
    public void UnFeeChafeBrusquely(AudioSource audio)
    {
        if (ChafeBrusquelyRoman.Contains(audio)) return;
        if (ChafeBrusquelyRoman.Count >= MaxPulse)
        {
            GameObject.Destroy(audio);
            //Debug.Log("删除组件");
        }
        else
        {
            audio.clip = null;
            ChafeBrusquelyRoman.Add(audio);
        }

        //Debug.Log("队列长度是" + AudioComponentQueue.Count);
    }
    
}
