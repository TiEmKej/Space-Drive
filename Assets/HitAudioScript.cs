using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAudioScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        GetComponent<AudioSource>().volume = 1f * (PlayerPrefs.GetFloat("masterVolume")/10) * (PlayerPrefs.GetFloat("effectsVolume")/10);
        Destroy(this, GetComponent<AudioSource>().clip.length);
    }
}
