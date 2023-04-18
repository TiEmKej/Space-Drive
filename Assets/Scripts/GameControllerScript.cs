using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        Debug.Log(camera.rect);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
