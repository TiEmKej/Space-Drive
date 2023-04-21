using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    [SerializeField] TMP_Text scoreDisplay;
    int score = 0;
    void Awake()
    {
        ScoreController[] objs = GameObject.FindObjectsOfType<ScoreController>();

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    public int GetScore(){
        return score;
    }

    public void ChangeScore(int value){
        score += value;
        UpdateScore();
    }

    public void UpdateScore(){
        scoreDisplay.text = score.ToString();
    }
}
