using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayButton(){
        SceneManager.LoadScene("Gameplay");
    }

    public void SettingsButton(){
        SceneManager.LoadScene("Settings");
    }

    public void InfoButton(){
        SceneManager.LoadScene("Info");
    }
}
