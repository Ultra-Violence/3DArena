using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBtn : MonoBehaviour
{
    public GameObject menu;

    private void Start() {
        Time.timeScale = 1;
    }
    public void OpenMenuBtn(){
        if(menu.gameObject.activeInHierarchy == true){
            Time.timeScale = 1;
        }
        else{
            Time.timeScale = 0;
        }
        menu.SetActive(!menu.gameObject.activeInHierarchy);

    }
}
