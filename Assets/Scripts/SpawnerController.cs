using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] GameObject asteroid;
    [SerializeField] float timeToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAsteroid());
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
            newAsteroidrb2d.velocity = new Vector2(0, -2f);
            yield return new WaitForSeconds(timeToSpawn);
        }
    }
}
