using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    Health playerhp;

    void Start()
    {
        playerhp = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //Check collider tag
        switch (collision.tag){
            case "enemyobject":
                playerhp.GetDamage();
                Destroy(collision.gameObject);
                return;
            case "bonushp":
                if(playerhp.health < 3){
                    playerhp.AddHealth();
                    Destroy(collision.gameObject);
                }
                return;
            case "slowtime":
                Destroy(collision.gameObject);
                return;
            case "blast":
                Destroy(collision.gameObject);
                return;
            case "overdrive":
                playerhp.StartCoroutine("Overdrive");
                Destroy(collision.gameObject);
                return;
            case "ammobox":
                Destroy(collision.gameObject);
                return;
        }
    }

}
