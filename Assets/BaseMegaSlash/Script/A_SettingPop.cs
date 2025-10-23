// Project  Repository-BaseA
// FileName  A_SettingPop.cs
// Author  AX
// Desc
// CreateAt  2025-09-10 10:09:59 
//


using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class A_SettingPop : MonoBehaviour
{
    public Sprite On;
    public Sprite Off;
    // public Button MusicBtn;

    public Button soundBtn;

    public Button replayBtn;

    public Button closeBtn;

    public GameObject windowPop;

    private void Start()
    {
        Application.targetFrameRate = 60;

        // int music = PlayerPrefs.GetInt("Music", 1);
        // MusicBtn.image.sprite = music == 1 ? On : Off;
        // MusicBtn.transform.GetChild(0).localPosition = new Vector2(music == 1 ? 38 : -38, 0);

        int sound = PlayerPrefs.GetInt(AxeConstant.SoundKey, 1);
        soundBtn.image.sprite = sound == 1 ? On : Off;
        // SoundBtn.transform.GetChild(0).localPosition = new Vector2(sound == 1 ? 38 : -38, 0);

        soundBtn.onClick.AddListener(Sound);

        replayBtn.onClick.AddListener(Replay);

        closeBtn.onClick.AddListener(ClosePop);
    }

    // public void Music()
    // {
    //     int music = PlayerPrefs.GetInt("Music", 1);
    //     music = music == 1 ? 0 : 1;
    //     PlayerPrefs.SetInt("Music", music);
    //     MusicBtn.image.sprite = music == 1 ? On : Off;
    //     MusicBtn.transform.GetChild(0).localPosition = new Vector2(music == 1 ? 38 : -38, 0);
    //     A_AudioManager.Instance.ToggleMusic();
    // }
    //

    
    private void OnEnable()
    {
        UiAnim(windowPop.transform);
    }

    private void UiAnim(Transform UI)
    {
        for (int i = 0; i < UI.childCount; i++)
        {
            Transform Ui = UI.GetChild(i);
            Ui.DOKill();
            Ui.localScale = Vector2.zero;
            Ui.DOScale(Vector2.one, 0.5f).SetDelay(i * .1f);
        }
    }
    

    public void ShowUI(bool onGamePop)
    {
        if (onGamePop)
        {
            replayBtn.gameObject.SetActive(true);
            closeBtn.transform.localPosition = new Vector3(0, -330f, 0);
        }
        else
        {
            replayBtn.gameObject.SetActive(false);
            closeBtn.transform.localPosition = new Vector3(0, -180f, 0);
        }
    }

    public void Sound()
    {
        A_AudioManager.Instance.PlaySound("Click");
        int sound = PlayerPrefs.GetInt(AxeConstant.SoundKey, 1);
        sound = sound == 1 ? 0 : 1;
        PlayerPrefs.SetInt(AxeConstant.SoundKey, sound);
        soundBtn.image.sprite = sound == 1 ? On : Off;
        // soundBtn.transform.GetChild(0).localPosition = new Vector2(sound == 1 ? 38 : -38, 0);
        A_AudioManager.Instance.ToggleSound();
        // A_AudioManager.Instance.ToggleMusic();
    }

    private void Replay()
    {
        A_AudioManager.Instance.PlaySound("Click");
        gameObject.SetActive(false);
        A_BattleAxeManager.Instance.ReplayGame();
    }

    private void ClosePop()
    {
        A_AudioManager.Instance.PlaySound("Click");
        gameObject.SetActive(false);
        A_BattleAxeManager.Instance.BackGame();
    }
}