using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Objects to spawn
    [SerializeField] GameObject enemyObject;
    [SerializeField] GameObject[] powerUps;

    float baseEnemyVelocity = -7f;
    // Timers
    float baseTimeForEnemySpawn = 1.75f;
    float timeForPowerUpSpawn = 7.5f;
    // Score controller for difficulty
    ScoreController scoreController;
    
    private void Start() {
        scoreController = FindObjectOfType<ScoreController>();
        StartCoroutine(SpawnEnemyObject());
        StartCoroutine(SpawnPowerUp());
    }

    IEnumerator SpawnEnemyObject(){
        float enemyVelocity = baseEnemyVelocity;
        float timeForEnemySpawn = baseTimeForEnemySpawn;
        while(true){
            GameObject newEnemyObject = GameObjectSpawner(enemyObject);
            float newScale = Random.Range(0.8f,1.2f);
            newEnemyObject.transform.localScale = new Vector3(newScale, newScale, 1f);
            //Set the Velocity for enemy object
            Rigidbody2D newEnemyObjectRb = newEnemyObject.GetComponent<Rigidbody2D>();
            if (enemyVelocity - 0.07f > -20f){
                enemyVelocity = baseEnemyVelocity - (scoreController.GetScore() * 0.07f);
            }
            newEnemyObjectRb.velocity = new Vector2(0f,enemyVelocity);
            //Set new timer for spawner
            if(timeForEnemySpawn > 1f){
                timeForEnemySpawn -= 0.021f;
            }else if(timeForEnemySpawn > 0.8f){
                timeForEnemySpawn -= 0.017f;
            }else if(timeForEnemySpawn > 0.6f){
                timeForEnemySpawn -= 0.005f;
            }
            yield return new WaitForSeconds(timeForEnemySpawn);
        }
    }

    IEnumerator SpawnPowerUp(){
        while(true){
            // Wait for x second go again
            yield return new WaitForSeconds(timeForPowerUpSpawn);
            if (Random.Range(0f,1f)>0.5f){ //50% chance to spawn powerup
                // Create power up object
                GameObject newPowerUpObject = GameObjectSpawner(powerUps[PowerUpPicker()]);
                // Set the velocity for power up
                Rigidbody2D newPowerUpObjectRb = newPowerUpObject.GetComponent<Rigidbody2D>();
                newPowerUpObjectRb.velocity = new Vector2(0f,-3f);
            } 
        }
    }

    private GameObject GameObjectSpawner(GameObject gameObject){
        GameObject spawnedGameObject = Instantiate(gameObject);
        float newX = Random.Range(-3.5f, 3.5f);
        spawnedGameObject.transform.parent = this.gameObject.transform;
        spawnedGameObject.transform.Translate(newX,10f,0f);
        Rigidbody2D spawnedGameObjectRB = spawnedGameObject.GetComponent<Rigidbody2D>();
        spawnedGameObjectRB.angularVelocity = 10;
        return spawnedGameObject;
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
