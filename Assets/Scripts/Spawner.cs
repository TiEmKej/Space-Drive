using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemyObject;
    
    private void Start() {
        StartCoroutine("SpawnAsteroid");
    }

    IEnumerator SpawnAsteroid(){
        while(true){
            Debug.Log("Asteroid spawned");
            float time = 1f;
            GameObject newEnemyObject = Instantiate(enemyObject);
            float newX = Random.Range(-4f, 4f);
            newEnemyObject.transform.Translate(newX,10f,0f);
            Rigidbody2D newEnemyObjectRb = newEnemyObject.GetComponent<Rigidbody2D>();
            newEnemyObjectRb.velocity = new Vector2(0f,-3f);
            newEnemyObjectRb.angularVelocity = 10;
            yield return new WaitForSeconds(time);
        }
    }
}
