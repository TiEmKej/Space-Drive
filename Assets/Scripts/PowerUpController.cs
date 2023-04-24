using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    float baseTimeScale = 1f;
    float timeScaleModifier = 0.5f;
    Health playerHP;
    AudioSource powerUpSound;
    [SerializeField] AudioClip powerUpNormal;
    [SerializeField] AudioClip powerUpBlast;
    private void Start() {
        playerHP = FindObjectOfType<Health>();
        powerUpSound = GetComponent<AudioSource>();
        powerUpSound.volume = 1f * (PlayerPrefs.GetFloat("masterVolume")/10) * (PlayerPrefs.GetFloat("effectsVolume")/10);
    }
    public void BonusHP(Collider2D powerUp){
        if(playerHP.health < 3){
            playerHP.AddHealth();
            NormalPowerUpPlay();
            Destroy(powerUp.gameObject);
        }
    }
    public void SlowTime(Collider2D powerUp){
        StartCoroutine(SlowTimeCoroutine());
        NormalPowerUpPlay();
        Destroy(powerUp.gameObject);
    }
    public void Overdrive(Collider2D powerUp){
        playerHP.StartCoroutine("Overdrive");
        NormalPowerUpPlay();
        Destroy(powerUp.gameObject);
    }
    public void Blast(Collider2D powerUp){
        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("enemyobject");
        foreach(GameObject enemy in enemyObjects){
            Destroy(enemy.gameObject);
        }
        BlastPowerUpPlay();
        Destroy(powerUp.gameObject);
    }

    private void NormalPowerUpPlay(){
        powerUpSound.clip = powerUpNormal;
        powerUpSound.Play();
    }

    private void BlastPowerUpPlay(){
        powerUpSound.clip = powerUpBlast;
        powerUpSound.Play();
    }

    IEnumerator SlowTimeCoroutine(){
        Time.timeScale = Time.timeScale * timeScaleModifier;
        yield return new WaitForSeconds(3f);
        Time.timeScale = baseTimeScale;
    }
}
