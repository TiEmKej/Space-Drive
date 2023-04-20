using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 3;
    UIUpdater uIUpdater;
    // Start is called before the first frame update
    void Start()
    {
        uIUpdater = FindObjectOfType<UIUpdater>();
        uIUpdater.HPUpdate(health);
    }

    public void AddHealth(){
        if(health < 3){
            health++;
            uIUpdater.HPUpdate(health);
        }
    }
    public void GetDamage(){
        if(health > 0){
            health--;
            uIUpdater.HPUpdate(health);
        }
        if(health == 0){
            Destroy(this.gameObject);
        }
    }
}
