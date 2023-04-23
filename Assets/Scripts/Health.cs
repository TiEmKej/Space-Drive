using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health = 3;
    bool isOvedrive = false;
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
        health++;
        uIUpdater.HPUpdate(health);
    }
    public void GetDamage(){
        if(health > 0 && !isOvedrive){
            health--;
            uIUpdater.HPUpdate(health);
        }
        if(health <= 0 && !isOvedrive){
            PlayerPrefs.SetInt("CurrentScore",scoreController.GetScore());
            SceneManager.LoadScene("LostScreen");
        }
    }

    IEnumerator Overdrive(){
        isOvedrive = true;
        uIUpdater.OverdriveHP(health);
        yield return new WaitForSeconds(4f);
        isOvedrive = false;
        uIUpdater.HPUpdate(health);
    }
}
