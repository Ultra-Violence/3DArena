using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPos : MonoBehaviour
{
    void Start()
    {
        Invoke("Destroy", 20f);
    }

    private void Destroy(){
        Destroy(gameObject);
    }
}
