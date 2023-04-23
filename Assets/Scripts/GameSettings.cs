using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    [SerializeField] AudioSource backgroundMusic;
    float masterVolume = 1f;
    float musicVolume = 1f;
    float effectsVolume = 1f;
    void Awake()
    {
        GameSettings[] objs = GameObject.FindObjectsOfType<GameSettings>();

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        Application.targetFrameRate = 120;
        LoadSoundSettings();
    }

    public void SetBackgroundMusicVolume()
    {
        backgroundMusic.volume = 0.5f * masterVolume * musicVolume;
    }

    public void LoadSoundSettings()
    {
        if(PlayerPrefs.HasKey("masterVolume")){
            masterVolume = PlayerPrefs.GetFloat("masterVolume")/10;
            musicVolume = PlayerPrefs.GetFloat("musicVolume")/10;
            effectsVolume = PlayerPrefs.GetFloat("effectsVolume")/10;
        }
        SetBackgroundMusicVolume();
    }
}
