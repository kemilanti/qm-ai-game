using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using TMPro;
public class npcsys : MonoBehaviour
{
    public GameObject d_template;
    public GameObject canvas;

    bool playerdetection = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(playerdetection && Input.GetKeyDown(KeyCode.F)   && !ThirdPersonController.dialogue)
        {
            canvas.SetActive(true);
            ThirdPersonController.dialogue = true;
            newdialogue("hi");
            newdialogue("i am bob");
            newdialogue("how are you");
            canvas.transform.GetChild(1).gameObject.SetActive(true); // use 'transform' to access GetChild

        }
    }

    void newdialogue(string text)
    {
        GameObject template_clone = Instantiate(d_template, d_template.transform);
        template_clone.transform.parent = canvas.transform;
        template_clone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;

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
