using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    void Awake()
    {
        GameSettings[] objs = GameObject.FindObjectsOfType<GameSettings>();

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
