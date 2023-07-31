using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemySO activeType;
    private GameObject player;
    private int power;

    private void Awake() {
        player = GameObject.Find("/Player");
        power = activeType.power;
    }

    public void DestroyEnemy(){
        player.GetComponent<Player>().GetPower(activeType.power);
        Destroy(gameObject);
    }
}
