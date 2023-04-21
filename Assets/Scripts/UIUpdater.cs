using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    [SerializeField] Image HPImage;
    [SerializeField] Sprite[] hpState;
    [SerializeField] Sprite[] overdrive;
    
    public void HPUpdate(int health){
        HPImage.sprite = hpState[health];
    }
}
