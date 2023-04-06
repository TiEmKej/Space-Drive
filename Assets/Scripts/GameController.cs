using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] int playerHealth;
    int playerScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = playerScore.ToString();
        healthText.text = playerHealth + "x";
        Application.targetFrameRate = 120;
    }

    public void AddScore()
    {
        playerScore++;
        scoreText.text = playerScore.ToString();
    }

    public void GetDemage()
    {
        playerHealth--;
        healthText.text = playerHealth + "x";
        if (playerHealth < 1)
        {
            int currentScore = int.Parse(scoreText.text);
            PlayerPrefs.SetInt("CurrentScore", currentScore);
            SceneManager.LoadScene(2);   
        }
    }
}
