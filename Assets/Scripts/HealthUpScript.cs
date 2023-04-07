using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpScript : MonoBehaviour
{
    GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerShip" && gameController.playerHealth < 3)
        {
            gameController.PlayPowerUp();
            gameController.HealthUp();
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Destroyer")
        {
            Destroy(this.gameObject);
        }
    }
}
