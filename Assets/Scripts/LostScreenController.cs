using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LostScreenController : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        int currentScore = PlayerPrefs.GetInt("CurrentScore");
        int highScore = PlayerPrefs.GetInt("HighScore");
        if (currentScore > highScore){
            PlayerPrefs.SetInt("HighScore", currentScore);
            scoreText.text = "New Highscore!\n"+currentScore;
        }else{
            scoreText.text = "Score: "+currentScore+"\nHighscore: "+highScore;
        }
        PlayerPrefs.SetInt("CurrentScore", 0);
    }

    public void PlayAgain(){
        SceneManager.LoadScene("Gameplay");
    }
}
