using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MasterVolume");
        Destroy(this.gameObject, GetComponent<AudioSource>().clip.length);
    }
}
