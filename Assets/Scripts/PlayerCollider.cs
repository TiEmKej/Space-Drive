using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    Health playerhp;
    PowerUpController powerUpController;
    [SerializeField] GameObject hitSoundAudio;

    void Start()
    {
        playerhp = GetComponent<Health>();
        powerUpController = FindObjectOfType<PowerUpController>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //Check collider tag
        switch (collision.tag){
            case "enemyobject":
                Instantiate(hitSoundAudio);
                playerhp.GetDamage();
                Destroy(collision.gameObject);
                return;
            case "bonushp":
                powerUpController.BonusHP(collision);
                return;
            case "slowtime":
                powerUpController.SlowTime(collision);
                return;
            case "blast":
                powerUpController.Blast(collision);
                return;
            case "overdrive":
                powerUpController.Overdrive(collision);
                return;
        }
    }
}
