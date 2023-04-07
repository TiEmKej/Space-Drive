using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] GameObject asteroid;
    [SerializeField] GameObject healthUp;
    [SerializeField] GameObject asteroidSlow;

    GameController gameController;
    int currentPoints;
    [SerializeField] float timeToSpawnAsteroid = 2f;
    [SerializeField] float timeToSpawnPowerUp = 10f;
    [SerializeField] float currentSpeed;
    // Start is called before the first frame update
    void Start()
    {
        StartSpawn();
        gameController = FindAnyObjectByType<GameController>();
    }

    void Update()
    {
        currentPoints = gameController.GetScore();
    }

    public void StartSpawn()
    {
        StartCoroutine(SpawnAsteroid());
        StartCoroutine(SpawnPowerUp());
    }

    public void StopSpawn()
    {
        StopCoroutine(SpawnAsteroid());
        StopCoroutine(SpawnPowerUp());
    }

    IEnumerator SpawnAsteroid()
    {
        while (true)
        {
            GameObject newAsteroid = Instantiate(asteroid);
            Rigidbody2D newAsteroidrb2d = newAsteroid.GetComponent<Rigidbody2D>();
            newAsteroid.transform.parent = this.transform;
            newAsteroid.transform.Translate(Random.Range(-2f, 2f), 6.25f, 0f);
            float newScale = Random.Range(0.75f, 1.25f);
            newAsteroid.transform.localScale = new Vector3(newScale, newScale, 1f);
            if (currentSpeed - 0.08f < 10f)
            {
                currentSpeed = -2f - (currentPoints * 0.08f);
            }
            newAsteroidrb2d.velocity = new Vector2(0, currentSpeed);
            newAsteroidrb2d.angularVelocity = 25f;
            if(timeToSpawnAsteroid > 0.4f)
            {
                timeToSpawnAsteroid -= 0.025f;
            }
            yield return new WaitForSeconds(Random.Range(timeToSpawnAsteroid-0.05f, timeToSpawnAsteroid+0.05f));
        }
    }

    IEnumerator SpawnPowerUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToSpawnPowerUp);
            if (Random.Range(0f, 1f) > 0.25f)
            {
                GameObject newPowerUp;
                float whatToSpawn = Random.Range(0f, 1f);
                if (whatToSpawn > 0.6f)
                {
                    newPowerUp = Instantiate(asteroidSlow);
                }
                else
                {
                    newPowerUp = Instantiate(healthUp);
                }
                Rigidbody2D newPowerUprb2d = newPowerUp.GetComponent<Rigidbody2D>();
                newPowerUp.transform.parent = this.transform;
                newPowerUp.transform.Translate(Random.Range(-2f, 2f), 6.25f, 0f);
                newPowerUprb2d.velocity = new Vector2(0, -2f - ((currentPoints * 0.05f)*0.90f));
                newPowerUprb2d.angularVelocity = -25f;
            }
        }
    }
}
