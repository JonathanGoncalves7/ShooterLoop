using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    const string VOLUME_BGM = "VOLUME_BGM";
    const string VOLUME_SFX = "VOLUME_SFX";

    public static AudioManager s_instance;

    [Header("BGM")]
    [SerializeField] AudioSource BGMSource;
    [SerializeField] List<AudioClip> BGMClip;

    [Header("SFX")]
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource SpellSource1;
    [SerializeField] AudioSource SpellSource2;
    [SerializeField] FloatMinAndMax SpellPitch;
    [SerializeField] AudioClip ButtonClickClip;

    private void Awake()
    {
        if (s_instance != null && s_instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            s_instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        IniAudioVolume();

        PlayBGM();
    }

    private void Update()
    {
        PlayBGM();
    }

    private void PlayBGM()
    {
        if (!BGMSource.isPlaying)
        {
            BGMSource.clip = BGMClip[Random.Range(0, BGMClip.Count)];
            BGMSource.Play();
        }
    }

    public float GetPPVolumeBGM()
    {
        return PlayerPrefs.GetFloat(VOLUME_BGM, 0.5f);
    }

    public float GetPPVolumeSFX()
    {
        return PlayerPrefs.GetFloat(VOLUME_SFX, 0.5f);
    }

    private void ChangeVolume(AudioSource audioSource, string playerPrefsName, float volume)
    {
        volume = Mathf.Max(0, volume);
        volume = Mathf.Min(1, volume);

        PlayerPrefs.SetFloat(playerPrefsName, volume);
        audioSource.volume = volume;
    }

    public void ChangeSFXVolume(float volume)
    {
        ChangeVolume(SFXSource, VOLUME_SFX, volume);
        ChangeVolume(SpellSource1, VOLUME_SFX, volume);
        ChangeVolume(SpellSource2, VOLUME_SFX, volume);
    }

    public void ChangeBGMVolume(float volume)
    {
        ChangeVolume(BGMSource, VOLUME_BGM, volume);
    }

    private void IniAudioVolume()
    {
        //BGM
        BGMSource.volume = GetPPVolumeBGM();

        //SFX 
        float volumeSFX = GetPPVolumeSFX();

        SFXSource.volume = volumeSFX;
        SpellSource1.volume = volumeSFX;
        SpellSource2.volume = volumeSFX;
    }

    private void PlayClip(AudioSource audioSource, AudioClip audioClip)
    {
        audioSource.Stop();
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void PlaySpellCasting(AudioClip audioClip)
    {
        if (SpellSource1.isPlaying)
        {
            SpellSource2.pitch = SpellPitch.GetRandom();
            PlayClip(SpellSource2, audioClip);
        }
        else
        {
            SpellSource1.pitch = SpellPitch.GetRandom();
            PlayClip(SpellSource1, audioClip);
        }
    }

    public void PlayButtonClick()
    {
        PlayClip(SFXSource, ButtonClickClip);
    }

    public AudioClip GetButtonClickClip()
    {
        return ButtonClickClip;
    }
}
