using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsController : MonoBehaviour
{
    [SerializeField] Slider masterVolume;
    [SerializeField] Slider musicVolume;
    [SerializeField] Slider effectsVolume;
    GameSettings gameSettings;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("masterVolume")){
            masterVolume.value = PlayerPrefs.GetFloat("masterVolume");
            musicVolume.value = PlayerPrefs.GetFloat("musicVolume");
            effectsVolume.value = PlayerPrefs.GetFloat("effectsVolume");
        }
    }

    public void MasterVolumeChange(){
        FindGameSettings();
        PlayerPrefs.SetFloat("masterVolume", masterVolume.value);
        gameSettings.UpdateSoundVolume();
    }

    public void MusicVolumeChange(){
        FindGameSettings();
        PlayerPrefs.SetFloat("musicVolume", musicVolume.value);
        gameSettings.UpdateSoundVolume();
    }

    public void EffectsVolumeChange(){
        FindGameSettings();
        PlayerPrefs.SetFloat("effectsVolume", effectsVolume.value);
        gameSettings.UpdateSoundVolume();
    }

    public void BackButton(){
        SceneManager.LoadScene("MainMenu");
    }
    
    private void FindGameSettings(){
        gameSettings = FindObjectOfType<GameSettings>();
    }
}
