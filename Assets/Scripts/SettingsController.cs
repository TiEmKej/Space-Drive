using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [SerializeField] Slider masterVolume;
    [SerializeField] Slider musicVolume;
    [SerializeField] Slider effectsVolume;
    GameSettings gameSettings;
    // Start is called before the first frame update
    void Start()
    {
        gameSettings = FindObjectOfType<GameSettings>();
        if(PlayerPrefs.HasKey("masterValue")){
            masterVolume.value = PlayerPrefs.GetFloat("masterValue");
            musicVolume.value = PlayerPrefs.GetFloat("musicValue");
            effectsVolume.value = PlayerPrefs.GetFloat("effectsValue");
        }
    }

    public void MasterVolumeChange(){
        Debug.Log(masterVolume.value);
        PlayerPrefs.SetFloat("masterValue", masterVolume.value);
        OnValueChange();
    }

    public void MusicVolumeChange(){
        Debug.Log(musicVolume.value);
        PlayerPrefs.SetFloat("musicValue", musicVolume.value);
        OnValueChange();
    }

    public void EffectsVolumeChange(){
        Debug.Log(effectsVolume.value);
        PlayerPrefs.SetFloat("effectsValue", effectsVolume.value);
        OnValueChange();
    }

    public void OnValueChange(){
        gameSettings.SetBackgroundMusicVolume();
    }
    
}
