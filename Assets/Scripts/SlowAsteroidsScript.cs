using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowAsteroidsScript : MonoBehaviour
{
    GameController gameController;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerShip")
        {
            gameController.PlayPowerUp();
            StartCoroutine(SlowAsteroids());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Destroyer")
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator SlowAsteroids()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<Collider2D>().enabled = false;
        Time.timeScale = 0.5f;
        //GameObject spawner = GameObject.FindGameObjectWithTag("Spawner");
        //spawner.GetComponent<SpawnerController>().StopAllCoroutines();
        //GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        //Vector2 beforeSpeed = new Vector2(0f,0f);
        //foreach(GameObject asteroid in asteroids)
        //{
        //    Rigidbody2D asteroidrb2d = asteroid.GetComponent<Rigidbody2D>();
        //    beforeSpeed = asteroidrb2d.velocity;
        //    asteroidrb2d.velocity = new Vector2(0f, -2f);
        //    Debug.Log("Slow applied");
        //}
        //Debug.Log("Przed slow");
        yield return new WaitForSeconds(5f);
        Time.timeScale = 1.0f;
        //Debug.Log("Po slow 5s");
        //foreach (GameObject asteroid in asteroids)
        //{
        //    if(asteroid != null)
        //    {
        //        Rigidbody2D asteroidrb2d = asteroid.GetComponent<Rigidbody2D>();
        //        asteroidrb2d.velocity = beforeSpeed;
        //    }
        //}
        //spawner.GetComponent<SpawnerController>().StartSpawn();
        Destroy(this.gameObject);
    }
}
