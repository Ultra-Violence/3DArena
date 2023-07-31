using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    [SerializeField] private GameObject bulletPref;
    [SerializeField] private Transform bulletPoint;
    public Player player;

    public void ShootBtn(){
        if(Time.timeScale == 1){
            Instantiate(bulletPref, bulletPoint.position, bulletPoint.rotation);
        }
    }

    public void UltaBtn(){
        if(player.power == player.maxPower && Time.timeScale == 1){
            GameObject[] enemyList = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemyList)
            {
                player.enemyKilled++;
                Destroy(enemy);
            }
            
            player.LossPower(player.maxPower);
        }
    }
}
