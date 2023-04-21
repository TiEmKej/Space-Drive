using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    Health playerhp;
    // Start is called before the first frame update
    void Start()
    {
        playerhp = GetComponent<Health>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "enemyobject"){
            playerhp.GetDamage();
            Destroy(collision.gameObject);
        }
    }

}
