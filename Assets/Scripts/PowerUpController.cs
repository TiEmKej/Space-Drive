using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    float baseTimeScale = 1f;
    float timeScaleModifier = 0.5f;
    Health playerHP;
    private void Start() {
        playerHP = FindObjectOfType<Health>();
    }
    public void BonusHP(Collider2D powerUp){
        if(playerHP.health < 3){
            playerHP.AddHealth();
            Destroy(powerUp.gameObject);
        }
    }
    public void SlowTime(Collider2D powerUp){
        StartCoroutine(SlowTimeCoroutine());
        Destroy(powerUp.gameObject);
    }
    public void Overdrive(Collider2D powerUp){
        playerHP.StartCoroutine("Overdrive");
        Destroy(powerUp.gameObject);
    }
    public void Blast(Collider2D powerUp){

    }
    public void AmmoBox(Collider2D powerUp){

    }

    IEnumerator SlowTimeCoroutine(){
        Time.timeScale = Time.timeScale * timeScaleModifier;
        yield return new WaitForSeconds(3f);
        Time.timeScale = baseTimeScale;
    }
}
