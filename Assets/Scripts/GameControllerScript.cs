using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    void Awake()
    {
        ScoreController[] objs = GameObject.FindObjectsOfType<ScoreController>();

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        Application.targetFrameRate = 120;
    }
}
