using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIUpdater : MonoBehaviour
{
    [SerializeField] Image hpImage;
    [SerializeField] Sprite[] hpState;
    [SerializeField] Sprite[] overdrive;
    [SerializeField] TMP_Text scoreText;
    
    public void HPUpdate(int health){
        hpImage.sprite = hpState[health];
    }

    public void ScoreUpdate(int score){
        scoreText.text = score.ToString();
    }
}
