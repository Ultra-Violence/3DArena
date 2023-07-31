using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemys : MonoBehaviour
{   
    public GameObject blue;
    public GameObject red;

    private int spawnRed = 4;
    private int spawnBlue = 1;
    
    void Start()
    {
        Invoke("SpawnWave", 5f);
        Invoke("SpawnWave", 9f);
        Invoke("SpawnWave", 12f);
        Invoke("LastWave", 14f);
    }

    private void SpawnWave(){
        for(int i = 0; i < spawnRed; i++){
            Instantiate(red, Random.insideUnitSphere * 4.5f, Quaternion.identity);
        }

        for(int i = 0; i < spawnBlue; i++){
            Instantiate(blue, Random.insideUnitSphere * 4.5f, Quaternion.identity);
        }
    }

    private void LastWave(){
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn(){
        for(int i = 0; i <= spawnRed; i++){
            Instantiate(red, Random.insideUnitSphere * 4.5f, Quaternion.identity);
        }

        for(int i = 0; i <= spawnBlue; i++){
            Instantiate(blue, Random.insideUnitSphere * 4.5f, Quaternion.identity);
        }

        yield return new WaitForSeconds(2f);
        spawnRed++;
        if(spawnRed > spawnBlue*4){
            spawnBlue++;
        }
        StartCoroutine(Spawn());
    }

    
}
