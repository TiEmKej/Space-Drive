using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    float[] soundVolumes = {1f,1f,1f}; //[0] master, [1] music, [2] effects
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
        LoadVolumeFromPrefs();
    }

    private void LoadVolumeFromPrefs()
    {
        if(PlayerPrefs.HasKey("masterVolume")){
            soundVolumes[0] = PlayerPrefs.GetFloat("masterVolume");
        }
        if(PlayerPrefs.HasKey("musicVolume")){
            soundVolumes[1] = PlayerPrefs.GetFloat("musicVolume");
        }
        if(PlayerPrefs.HasKey("effectsVolume")){
            soundVolumes[2] = PlayerPrefs.GetFloat("effectsVolume");
        }
    }
}
