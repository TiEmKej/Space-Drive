using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] public int playerHealth;
    [SerializeField] GameObject playHitSound;
    [SerializeField] GameObject playPowerUpSound;

    int playerScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = playerScore.ToString();
        healthText.text = playerHealth + "/3";
        Application.targetFrameRate = 120;
    }

    public void AddScore()
    {
        playerScore++;
        scoreText.text = playerScore.ToString();
    }

    public int GetScore()
    {
        return playerScore;
    }

    public void GetDamage()
    {
        playerHealth--;
        healthText.text = playerHealth + "/3";
        DontDestroyOnLoad(Instantiate(playHitSound));
        if (playerHealth < 1)
        {
            int currentScore = int.Parse(scoreText.text);
            PlayerPrefs.SetInt("CurrentScore", currentScore);
            GameObject.FindGameObjectWithTag("pns").GetComponent<AudioSource>().Pause();
            SceneManager.LoadScene(2);   
        }

    }

    public void HealthUp()
    {
        if(playerHealth < 3)
        {
            playerHealth++;
            healthText.text = playerHealth + "/3";
        }
    }

    public void PlayPowerUp()
    {
        DontDestroyOnLoad(Instantiate(playPowerUpSound));
    }
}
