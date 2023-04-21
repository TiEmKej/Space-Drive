using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    UIUpdater uIUpdater;
    int score = 0;
    private void Start() {
        uIUpdater = FindObjectOfType<UIUpdater>();
    }
    public int GetScore(){
        return score;
    }

    public void ChangeScore(int value){
        score += value;
        uIUpdater.ScoreUpdate(score);
    }
}
