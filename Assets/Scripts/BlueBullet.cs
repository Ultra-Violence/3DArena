using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBullet : MonoBehaviour
{   
    private GameObject player;
    private Transform target;
    public float speed;
    public bool lostTarget = false;

    private void Start() {
        player = GameObject.Find("/Player");
        target = player.GetComponent<Transform>();
    }

    private void FixedUpdate(){
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            player.GetComponent<Player>().LossPower(25);
            Destroy(gameObject);
        }
        else if(other.tag == "OldPos"){
            Destroy(gameObject);
        }
    }

    public void SetTarget(Transform pos){
        lostTarget = true;
        target = pos;
    }
}
