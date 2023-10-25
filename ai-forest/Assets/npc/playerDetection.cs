using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDetection : MonoBehaviour
{
    bool playerdetection = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(playerdetection && Input.GetKeyDown(KeyCode.F))
        {
            print("阿巴阿巴");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "PlayerArmature")

        playerdetection = true;
    }
    private void OnTriggerExit(Collider other)
    {
        playerdetection = false;            
    }
}
