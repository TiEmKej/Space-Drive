using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    ScoreController scoreController;
    // Start is called before the first frame update
    void Start() {
        scoreController = FindObjectOfType<ScoreController>();    
    }
    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.tag == "enemyobject"){
            Destroy(collider.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "enemyobject"){
            scoreController.ChangeScore(1);
        }   
    }
}
