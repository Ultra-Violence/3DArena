using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : MonoBehaviour
{
    private GameObject player;
    public GameObject blueBullet;
    private Transform bulletPoint;

    private void Awake() {
        transform.position = new Vector3(transform.position.x, 0.3131f,transform.position.z );
    }
    void Start()
    {
        player = GameObject.Find("/Player");
        bulletPoint = transform.Find("BulletPoint");
        StartCoroutine(Attack());
    }

    private IEnumerator Attack(){
        Instantiate(blueBullet, bulletPoint.position, Quaternion.identity);
        yield return new WaitForSeconds(3f);
        StartCoroutine(Attack());
    }

    private void FixedUpdate() {
        transform.position = Vector3.MoveTowards(transform.position, player.GetComponent<Transform>().position, Time.fixedDeltaTime * 0.1f);
    }
}
