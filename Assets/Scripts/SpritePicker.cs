using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
[RequireComponent(typeof(SpriteRenderer))]
public class SpritePicker : MonoBehaviour
{
    [SerializeField] Sprite[] spriteList;
    void Start()
    {   
        GetComponent<SpriteRenderer>().sprite = spriteList[Random.Range(0,spriteList.Length)];
    }
}
