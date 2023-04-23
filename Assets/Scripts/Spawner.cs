using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Objects to spawn
    [SerializeField] GameObject enemyObject;
    [SerializeField] GameObject[] powerUps;
    // Timers
    float timeForEnemy = 3f;
    float timeForPowerUp = 5f;
    // Score controller for difficulty
    ScoreController scoreController;
    int score;
    
    private void Start() {
        scoreController = FindObjectOfType<ScoreController>();
        score = scoreController.GetScore();
        StartCoroutine(SpawnAsteroid());
        StartCoroutine(SpawnPowerUp());
    }

    IEnumerator SpawnAsteroid(){
        while(true){
            // Create new enemy object
            GameObject newEnemyObject = Instantiate(enemyObject);
            // Set random X posiotion beetween -4 and 4
            float newX = Random.Range(-4f, 4f);
            // Move it in hierarchy as a child of spawner
            newEnemyObject.transform.parent = this.gameObject.transform;
            // Put object above the screen
            newEnemyObject.transform.Translate(newX,10f,0f);
            // Grab the rigidbody
            Rigidbody2D newEnemyObjectRb = newEnemyObject.GetComponent<Rigidbody2D>();
            // Set the velocity
            newEnemyObjectRb.velocity = new Vector2(0f,-3f);
            // Set the spin
            newEnemyObjectRb.angularVelocity = 10;
            // Wait for x second and go again
            yield return new WaitForSeconds(timeForEnemy);
        }
    }

    IEnumerator SpawnPowerUp(){
        while(true){
            // Wait for x second go again
            yield return new WaitForSeconds(timeForPowerUp);
            // Create power up object
            GameObject newPowerUpObject = Instantiate(powerUps[PowerUpPicker()]);
            // Set random X posiotion beetween -4 and 4
            float newX = Random.Range(-4f, 4f);
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

    private int PowerUpPicker(){
        float randomPowerUp = Random.Range(0f,1f);
        // Choosing random power up
        switch (randomPowerUp){
            case <= 0.15f:
                return 0; // 15% Blast
            case <= 0.30f:
                return 1; // 15% Overdrive
            case <= 0.40f:
                return 2; // 10% AmmoBox
            case <= 0.65f:
                return 3; // 25% Slowtime
            default:
                return 4; // 35% BonusHP
        }
    }
}
