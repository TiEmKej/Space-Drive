using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    float[] soundVolumes = {5f,5f,5f}; //[0] master, [1] music, [2] effects
    AudioSource bgAudio;
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
        UpdateSoundVolume();
    }

    public void UpdateSoundVolume(){
        LoadVolumeFromPrefs();
        bgAudio = GetComponent<AudioSource>();
        bgAudio.volume = (0.5f * (soundVolumes[0]/10) * (soundVolumes[1]/10));
        Debug.Log("BG Volume: "+bgAudio.volume);
    }

    private void LoadVolumeFromPrefs()
    {
        if(PlayerPrefs.HasKey("masterVolume")){
            soundVolumes[0] = PlayerPrefs.GetFloat("masterVolume");
            soundVolumes[1] = PlayerPrefs.GetFloat("musicVolume");
            soundVolumes[2] = PlayerPrefs.GetFloat("effectsVolume");
        }
    }
}
