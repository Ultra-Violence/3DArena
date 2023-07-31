using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltaBtnColor : MonoBehaviour
{
    public Player player;

    private void Update() {
        if(player.power >= 100){
            GetComponent<Image>().color = Color.red;
        }
        else{
            GetComponent<Image>().color = Color.white;
        }
    }
}
