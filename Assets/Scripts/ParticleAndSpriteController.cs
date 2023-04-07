using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParticleAndSpriteController : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("pns");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        
        DontDestroyOnLoad(this.gameObject);
        this.LoadMusicVolume();
    }

    void LoadMusicVolume()
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            GameObject.FindGameObjectWithTag("pns").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MasterVolume");
        }
    }
}
