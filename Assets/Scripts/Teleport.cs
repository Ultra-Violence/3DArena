using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private GameObject player;
    public GameObject oldPosPref;
    private float xPos;
    private float zPos;

    private void Start() {
        player = GameObject.Find("/Player");
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player"){
            GameObject oldPos = Instantiate(oldPosPref, player.GetComponent<Transform>().position, Quaternion.identity);
            GameObject[] bulletList = GameObject.FindGameObjectsWithTag("BlueBullet");
            foreach(GameObject bullet in bulletList){
                if(bullet.GetComponent<BlueBullet>().lostTarget == false){
                    bullet.GetComponent<BlueBullet>().SetTarget(oldPos.GetComponent<Transform>());
                }
            }

            GameObject[] enemyList = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject enemy in enemyList){
                xPos += enemy.GetComponent<Transform>().position.x;
                zPos += enemy.GetComponent<Transform>().position.z;
            }
            Vector3 newPosition = new Vector3(xPos*5, 0, zPos*5);
            newPosition.x = Mathf.Clamp(newPosition.x, -3f, 3f);
            newPosition.z = Mathf.Clamp(newPosition.z, -3f, 3f);

            player.GetComponent<Transform>().position = -newPosition;

            xPos = 0;
            zPos = 0;

            if(-newPosition.x > 0 && -newPosition.z > 0){
                player.GetComponent<MoveControl>().yRotation = -135;
            }
            else if(-newPosition.x < 0 && -newPosition.z > 0){
                player.GetComponent<MoveControl>().yRotation = 135;
            }
            else if(-newPosition.x < 0 && -newPosition.z < 0){
                player.GetComponent<MoveControl>().yRotation = 45;
            }
            else if(-newPosition.x > 0 && -newPosition.z < 0){
                player.GetComponent<MoveControl>().yRotation = -45;
            }
        }
        else if(other.tag == "BlueBullet"){
            Destroy(other);
        }
    }
}
