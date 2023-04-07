using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [SerializeField] Slider masterVolumeSlider;
    // Start is called before the first frame update

    private void Start()
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume")*10f;
        }
        else
        {
            masterVolumeSlider.value = 5f;
        }
    }

    public void OnSliderChange()
    {
        float setVolume = masterVolumeSlider.value / 10f;
        PlayerPrefs.SetFloat("MasterVolume", setVolume);
        GameObject.FindGameObjectWithTag("pns").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MasterVolume");
    }
}
