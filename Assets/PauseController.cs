using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] Canvas normalCanvas;
    [SerializeField] Canvas pausedCanvas;
    public void OnPause(){
        Time.timeScale = 0f;
        normalCanvas.enabled = false;
        pausedCanvas.enabled = true;
    }

    public void UnPause(){
        Time.timeScale = 1f;
        normalCanvas.enabled = true;
        pausedCanvas.enabled = false;
    }
}
