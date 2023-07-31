using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{   
    public GameObject player;
    public GameObject killedText;

    public void RetryBtn(){
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitBtn(){
        Application.Quit();
    }

    private void Update() {
        killedText.GetComponent<Text>().text = "Enemy killed: " + player.GetComponent<Player>().enemyKilled;
        Time.timeScale = 0;
    }
}
