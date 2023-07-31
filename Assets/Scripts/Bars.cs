using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bars : MonoBehaviour
{
    public Player player;
    public Slider hpFiil;
    public Slider prFiil;

    private void Update() {
        hpFiil.value = player.health;
        prFiil.value = player.power;
    }
}
