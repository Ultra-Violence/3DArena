using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : MonoBehaviour
{
    private GameObject player;
    private Transform target;
    public float speed;
    private bool readyToAttack = false;

    private void Awake() {
        transform.position = new Vector3(transform.position.x, 0.142f,transform.position.z );
        player = GameObject.Find("/Player");
    }

    private void FixedUpdate() {
        if(readyToAttack == false){
            transform.Translate(0, Time.fixedDeltaTime, 0);
        }
        else{
            Vector3 direction = player.GetComponent<Transform>().position - new Vector3(transform.position.x, transform.position.y + 90, transform.position.z);
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;
        }

        if(transform.position.y >= 1.5f){
            readyToAttack = true;
            Invoke("SetTarget", 3f);
        }
        if(target != null){
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        }

    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            player.GetComponent<Player>().Damage(15);
            Destroy(gameObject);    
        }
    }

    private void SetTarget(){
        target = player.GetComponent<Transform>();
    }
}
