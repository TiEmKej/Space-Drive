using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Settings()
    {
        SceneManager.LoadScene(3);
    }

    public void Info()
    {
        SceneManager.LoadScene(4);
    }
}
