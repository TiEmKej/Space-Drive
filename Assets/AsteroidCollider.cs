using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollider : MonoBehaviour
{
    Health playerhp;
    // Start is called before the first frame update
    void Start()
    {
        playerhp = GameObject.FindGameObjectWithTag("playership").GetComponent<Health>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "playership"){
            playerhp.GetDamage();
            Destroy(this.gameObject);
        }
    }
}
