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
        PlayerPrefs.SetFloat("masterValue", masterVolume.value);
        Debug.Log(PlayerPrefs.GetFloat("masterValue"));
    }

    public void MusicVolumeChange(){
        PlayerPrefs.SetFloat("musicValue", musicVolume.value);
        Debug.Log(PlayerPrefs.GetFloat("musicValue"));
    }

    public void EffectsVolumeChange(){
        PlayerPrefs.SetFloat("effectsValue", effectsVolume.value);
        Debug.Log(PlayerPrefs.GetFloat("effectsValue"));
    }
    
}
