using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Objects to spawn
    [SerializeField] GameObject enemyObject;
    [SerializeField] GameObject[] powerUps;

    [SerializeField] float enemyObjectVelocityY = -7f;
    // Timers
    [SerializeField] float timeForEnemy = 1.75f;
    float timeForPowerUp = 7.5f;
    // Score controller for difficulty
    ScoreController scoreController;
    int score;
    
    private void Start() {
        scoreController = FindObjectOfType<ScoreController>();
        StartCoroutine(SpawnEnemyObject());
        StartCoroutine(SpawnPowerUp());
    }

    private void Update() {
        score = scoreController.GetScore();
    }

    IEnumerator SpawnEnemyObject(){
        while(true){
            // Create new enemy object
            GameObject newEnemyObject = Instantiate(enemyObject);
            // Set random X posiotion beetween -4 and 4
            float newX = Random.Range(-3.5f, 3.5f);
            // Move it in hierarchy as a child of spawner
            newEnemyObject.transform.parent = this.gameObject.transform;
            // Put object above the screen
            newEnemyObject.transform.Translate(newX,10f,0f);
            // Randomize size
            float newScale = Random.Range(0.8f,1.2f);
            newEnemyObject.transform.localScale = new Vector3(newScale, newScale, 1f);
            // Grab the rigidbody
            Rigidbody2D newEnemyObjectRb = newEnemyObject.GetComponent<Rigidbody2D>();
            //Change Velocity
            if (enemyObjectVelocityY - 0.07f > -20f)
            {
                enemyObjectVelocityY = -7f - (score * 0.07f);
            }
            // Set the velocity
            newEnemyObjectRb.velocity = new Vector2(0f,enemyObjectVelocityY);
            // Set the spin
            newEnemyObjectRb.angularVelocity = 10;
            //Change spawn time
            if(timeForEnemy > 1f)
            {
                timeForEnemy -= 0.021f;
            }else if(timeForEnemy > 0.8f){
                timeForEnemy -= 0.017f;
            }else if(timeForEnemy > 0.6f){
                timeForEnemy -= 0.005f;
            }
            Debug.Log("Spawned Enemy" + Time.realtimeSinceStartupAsDouble);
            // Wait for x second and go again
            yield return new WaitForSeconds(timeForEnemy);
        }
    }

    IEnumerator SpawnPowerUp(){
        while(true){
            // Wait for x second go again
            yield return new WaitForSeconds(timeForPowerUp);
            if (Random.Range(0f,1f)>0.5f){ //50% chance to spawn powerup
                // Create power up object
                GameObject newPowerUpObject = Instantiate(powerUps[PowerUpPicker()]);
                // Set random X posiotion beetween -4 and 4
                float newX = Random.Range(-3.5f, 3.5f);
                // Move it in hierarchy as a child of spawner
                newPowerUpObject.transform.parent = this.gameObject.transform;
                // Put object above the screen
                newPowerUpObject.transform.Translate(newX,10f,0f);
                // Grab the rigidbody
                Rigidbody2D newPowerUpObjectRb = newPowerUpObject.GetComponent<Rigidbody2D>();
                // Set the velocity
                newPowerUpObjectRb.velocity = new Vector2(0f,-3f);
                // Set the spin
                newPowerUpObjectRb.angularVelocity = 10;
            } 
        }
    }
    private int PowerUpPicker(){
        float randomPowerUp = Random.Range(0f,1f);
        // Choosing random power up
        switch (randomPowerUp){
            case <= 0.15f:
                return 0; // 15% Blast
            case <= 0.30f:
                return 1; // 15% Overdrive
            case <= 0.45f:
                return 2; // 15% SlowTime
            default:
                return 3; // 55% BonusHP
        }
    }
}
