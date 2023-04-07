using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] TextMeshProUGUI scoreText;
    int currentScore = 0;
    int highScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentScore = PlayerPrefs.GetInt("CurrentScore");
        if (PlayerPrefs.HasKey("Highscore"))
        {
            highScore = PlayerPrefs.GetInt("Highscore");
        }
        if(highScore < currentScore)
        {
            gameOverText.text = "New Highscore!";
            gameOverText.color = Color.red;
            scoreText.text = "Score: " + currentScore;
            PlayerPrefs.SetInt("Highscore", currentScore);
        }
        else
        {
            gameOverText.text = "Game over";
            scoreText.text = "Highscore: " + highScore + "\nScore: " + currentScore;
        }
        
    }

    public void PlayAgain()
    {
        GameObject.FindGameObjectWithTag("pns").GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("gameplay");
    }

    public void BackToMenu()
    {
        GameObject.FindGameObjectWithTag("pns").GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("mainmenu");
    }
}
