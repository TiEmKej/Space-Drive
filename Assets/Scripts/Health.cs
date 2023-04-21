using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    int health = 3;
    UIUpdater uIUpdater;
    ScoreController scoreController;
    // Start is called before the first frame update
    void Start()
    {
        scoreController = FindObjectOfType<ScoreController>();
        uIUpdater = FindObjectOfType<UIUpdater>();
        uIUpdater.HPUpdate(health);
    }

    public void AddHealth(){
        if(health < 3){
            health++;
            uIUpdater.HPUpdate(health);
        }
    }
    public void GetDamage(){
        if(health > 0){
            health--;
            uIUpdater.HPUpdate(health);
        }
        if(health <= 0){
            PlayerPrefs.SetInt("CurrentScore",scoreController.GetScore());
            SceneManager.LoadScene("LostScreen");
        }
    }
}
