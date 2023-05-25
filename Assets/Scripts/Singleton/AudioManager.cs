using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {  get; private set; }

    private AudioSource audioSource;
    public bool IsMute { get; private set; }

    private float BGMVolumeValue = 1f;
    public float BGMVolume { get { return BGMVolumeValue; } set { BGMVolume = BGMVolumeValue; } }
    public float SFXVolume { get { return SFXVolume; } set { SFXVolume = 1f; } }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
        IsMute = audioSource.mute;
    }

    public void OnMuteToogle()
    {
        audioSource.mute = !audioSource.mute;
        IsMute = audioSource.mute;
    }

    public void OnVolumeChange(float volume)
    {
        audioSource.volume = volume;
    }

    public float GetVolumeValue()
    {
        return audioSource.volume;
    }
}