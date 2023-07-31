using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bullet : MonoBehaviour
{
    private GameObject player;
    private GameObject closestEnemy;
    private Quaternion startingAngle;
    private int speed = 150;
    private bool rebound = false;

    private void Awake() {
        player = GameObject.Find("/Player");
        Invoke("Destroy", 10f);
    }

    void Start()
    {
        startingAngle = transform.rotation;
        GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Force );
    }

    private void RemoveElement<GameObject>(ref GameObject[] arr, int index){
        for(int i = index; i < arr.Length - 1; i++){
            arr[i] = arr[i + 1];
        }
        Array.Resize(ref arr, arr.Length - 1);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Enemy"){
            player.GetComponent<Player>().GetKill();
            other.gameObject.GetComponent<Enemy>().DestroyEnemy();
            if(rebound == true){
                int healOrPower = UnityEngine.Random.Range(1, 3);
                if(healOrPower == 1){
                    player.GetComponent<Player>().GetPower(25);
                }
                else{
                    player.GetComponent<Player>().GetHeal(player.GetComponent<Player>().maxHealth/2);
                }
                Destroy(gameObject);
            }
            if(player.GetComponent<Player>().health <= UnityEngine.Random.Range(20, 100)){
                int randomIndex = UnityEngine.Random.Range(1, 3);
                if(randomIndex == 1){
                    GameObject[] enemyList = GameObject.FindGameObjectsWithTag("Enemy");
                    int otherIndex = Array.IndexOf(enemyList, other.gameObject);
                    RemoveElement(ref enemyList, otherIndex); 
                    float newDis = Mathf.Infinity;
                    foreach(GameObject enemy in enemyList){
                        float enemyDis = Vector3.Distance(transform.position, enemy.GetComponent<Transform>().position);
                        if (enemyDis < newDis){                       
                            closestEnemy = enemy;
                            newDis = enemyDis;
                            }
                        }
                    if(closestEnemy != null){
                        rebound = true;
                    }
                } 
            }
            else{
                Destroy(gameObject);
            }
        }
    }


    private void FixedUpdate() {
        if(rebound == true && closestEnemy != null){
            transform.position = Vector3.MoveTowards(transform.position, closestEnemy.GetComponent<Transform>().position, speed * Time.fixedDeltaTime * 0.05f); 
        }
    }

    private void Destroy(){
        Destroy(gameObject);
    }

}
